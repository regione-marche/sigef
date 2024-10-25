using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for StepCollectionProvider:IStepProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class StepCollectionProvider : IStepProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Step
		protected StepCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public StepCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new StepCollection(this);
		}

		//Costruttore 2: popola la collection
		public StepCollectionProvider(IntNT IdstepEqualThis, BoolNT AutomaticoEqualThis, StringNT CodfaseEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdstepEqualThis, AutomaticoEqualThis, CodfaseEqualThis);
		}

		//Costruttore3: ha in input stepCollectionObj - non popola la collection
		public StepCollectionProvider(StepCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public StepCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new StepCollection(this);
		}

		//Get e Set
		public StepCollection CollectionObj
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
		public int SaveCollection(StepCollection collectionObj)
		{
			return StepDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Step stepObj)
		{
			return StepDAL.Save(_dbProviderObj, stepObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(StepCollection collectionObj)
		{
			return StepDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Step stepObj)
		{
			return StepDAL.Delete(_dbProviderObj, stepObj);
		}

		//getById
		public Step GetById(IntNT IdStepValue)
		{
			Step StepTemp = StepDAL.GetById(_dbProviderObj, IdStepValue);
			if (StepTemp!=null) StepTemp.Provider = this;
			return StepTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public StepCollection Select(IntNT IdstepEqualThis, StringNT CodfaseEqualThis, StringNT DescrizioneEqualThis, 
BoolNT AutomaticoEqualThis, StringNT QuerysqlEqualThis, StringNT QuerysqlpostEqualThis, 
StringNT CodemethodEqualThis, StringNT UrlEqualThis, StringNT ValminimoEqualThis, 
StringNT ValmassimoEqualThis, StringNT MisuraEqualThis)
		{
			StepCollection StepCollectionTemp = StepDAL.Select(_dbProviderObj, IdstepEqualThis, CodfaseEqualThis, DescrizioneEqualThis, 
AutomaticoEqualThis, QuerysqlEqualThis, QuerysqlpostEqualThis, 
CodemethodEqualThis, UrlEqualThis, ValminimoEqualThis, 
ValmassimoEqualThis, MisuraEqualThis);
			StepCollectionTemp.Provider = this;
			return StepCollectionTemp;
		}

		//Find: popola la collection
		public StepCollection Find(IntNT IdstepEqualThis, BoolNT AutomaticoEqualThis, StringNT CodfaseEqualThis)
		{
			StepCollection StepCollectionTemp = StepDAL.Find(_dbProviderObj, IdstepEqualThis, AutomaticoEqualThis, CodfaseEqualThis);
			StepCollectionTemp.Provider = this;
			return StepCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<STEP>
  <ViewName>vSTEP</ViewName>
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
      <ID_STEP>Equal</ID_STEP>
      <AUTOMATICO>Equal</AUTOMATICO>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroMisura>
      <MISURA>Like</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</STEP>
*/