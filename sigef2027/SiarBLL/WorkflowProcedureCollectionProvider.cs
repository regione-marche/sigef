using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for WorkflowProcedureCollectionProvider:IWorkflowProcedureProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class WorkflowProcedureCollectionProvider : IWorkflowProcedureProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di WorkflowProcedure
		protected WorkflowProcedureCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public WorkflowProcedureCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new WorkflowProcedureCollection(this);
		}

		//Costruttore 2: popola la collection
		public WorkflowProcedureCollectionProvider(StringNT CodtipoproceduraEqualThis, StringNT CodworkflowEqualThis, BoolNT ObbligatorioEqualThis, 
IntNT OrdineEqGreaterThanThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodtipoproceduraEqualThis, CodworkflowEqualThis, ObbligatorioEqualThis, 
OrdineEqGreaterThanThis);
		}

		//Costruttore3: ha in input workflowprocedureCollectionObj - non popola la collection
		public WorkflowProcedureCollectionProvider(WorkflowProcedureCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public WorkflowProcedureCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new WorkflowProcedureCollection(this);
		}

		//Get e Set
		public WorkflowProcedureCollection CollectionObj
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
		public int SaveCollection(WorkflowProcedureCollection collectionObj)
		{
			return WorkflowProcedureDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(WorkflowProcedure workflowprocedureObj)
		{
			return WorkflowProcedureDAL.Save(_dbProviderObj, workflowprocedureObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(WorkflowProcedureCollection collectionObj)
		{
			return WorkflowProcedureDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(WorkflowProcedure workflowprocedureObj)
		{
			return WorkflowProcedureDAL.Delete(_dbProviderObj, workflowprocedureObj);
		}

		//getById
		public WorkflowProcedure GetById(StringNT CodTipoProceduraValue, StringNT CodWorkflowValue)
		{
			WorkflowProcedure WorkflowProcedureTemp = WorkflowProcedureDAL.GetById(_dbProviderObj, CodTipoProceduraValue, CodWorkflowValue);
			if (WorkflowProcedureTemp!=null) WorkflowProcedureTemp.Provider = this;
			return WorkflowProcedureTemp;
		}

		//Select: popola la collection
		public WorkflowProcedureCollection Select(StringNT CodtipoproceduraEqualThis, StringNT CodworkflowEqualThis, IntNT OrdineEqualThis, 
BoolNT ObbligatorioEqualThis)
		{
			WorkflowProcedureCollection WorkflowProcedureCollectionTemp = WorkflowProcedureDAL.Select(_dbProviderObj, CodtipoproceduraEqualThis, CodworkflowEqualThis, OrdineEqualThis, 
ObbligatorioEqualThis);
			WorkflowProcedureCollectionTemp.Provider = this;
			return WorkflowProcedureCollectionTemp;
		}

		//Find: popola la collection
		public WorkflowProcedureCollection Find(StringNT CodtipoproceduraEqualThis, StringNT CodworkflowEqualThis, BoolNT ObbligatorioEqualThis, 
IntNT OrdineEqGreaterThanThis)
		{
			WorkflowProcedureCollection WorkflowProcedureCollectionTemp = WorkflowProcedureDAL.Find(_dbProviderObj, CodtipoproceduraEqualThis, CodworkflowEqualThis, ObbligatorioEqualThis, 
OrdineEqGreaterThanThis);
			WorkflowProcedureCollectionTemp.Provider = this;
			return WorkflowProcedureCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<WORKFLOW_PROCEDURE>
  <ViewName>vWORKFLOW_PROCEDURE</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <COD_TIPO_PROCEDURA>Equal</COD_TIPO_PROCEDURA>
      <COD_WORKFLOW>Equal</COD_WORKFLOW>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
      <ORDINE>EqGreaterThan</ORDINE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</WORKFLOW_PROCEDURE>
*/