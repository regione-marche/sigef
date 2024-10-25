using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for WorkflowProcedureDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class WorkflowProcedureDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, WorkflowProcedure WorkflowProcedureObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoProcedura", WorkflowProcedureObj.CodTipoProcedura);
			DbProvider.SetCmdParam(cmd,firstChar + "CodWorkflow", WorkflowProcedureObj.CodWorkflow);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", WorkflowProcedureObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", WorkflowProcedureObj.Obbligatorio);
		}
		//Insert
		private static int Insert(DbProvider db, WorkflowProcedure WorkflowProcedureObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZWorkflowProcedureInsert", new string[] {"CodTipoProcedura", "CodWorkflow", "Ordine", 
"Obbligatorio"}, new string[] {"string", "string", "int", 
"bool"},"");
				CompileIUCmd(false, insertCmd,WorkflowProcedureObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				WorkflowProcedureObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
				}
				WorkflowProcedureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				WorkflowProcedureObj.IsDirty = false;
				WorkflowProcedureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, WorkflowProcedure WorkflowProcedureObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZWorkflowProcedureUpdate", new string[] {"CodTipoProcedura", "CodWorkflow", "Ordine", 
"Obbligatorio"}, new string[] {"string", "string", "int", 
"bool"},"");
				CompileIUCmd(true, updateCmd,WorkflowProcedureObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				WorkflowProcedureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				WorkflowProcedureObj.IsDirty = false;
				WorkflowProcedureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, WorkflowProcedure WorkflowProcedureObj)
		{
			switch (WorkflowProcedureObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, WorkflowProcedureObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, WorkflowProcedureObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,WorkflowProcedureObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, WorkflowProcedureCollection WorkflowProcedureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZWorkflowProcedureUpdate", new string[] {"CodTipoProcedura", "CodWorkflow", "Ordine", 
"Obbligatorio"}, new string[] {"string", "string", "int", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZWorkflowProcedureInsert", new string[] {"CodTipoProcedura", "CodWorkflow", "Ordine", 
"Obbligatorio"}, new string[] {"string", "string", "int", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZWorkflowProcedureDelete", new string[] {"CodTipoProcedura", "CodWorkflow"}, new string[] {"string", "string"},"");
				for (int i = 0; i < WorkflowProcedureCollectionObj.Count; i++)
				{
					switch (WorkflowProcedureCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,WorkflowProcedureCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									WorkflowProcedureCollectionObj[i].Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,WorkflowProcedureCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (WorkflowProcedureCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipoProcedura", (SiarLibrary.NullTypes.StringNT)WorkflowProcedureCollectionObj[i].CodTipoProcedura);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodWorkflow", (SiarLibrary.NullTypes.StringNT)WorkflowProcedureCollectionObj[i].CodWorkflow);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < WorkflowProcedureCollectionObj.Count; i++)
				{
					if ((WorkflowProcedureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (WorkflowProcedureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						WorkflowProcedureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						WorkflowProcedureCollectionObj[i].IsDirty = false;
						WorkflowProcedureCollectionObj[i].IsPersistent = true;
					}
					if ((WorkflowProcedureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						WorkflowProcedureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						WorkflowProcedureCollectionObj[i].IsDirty = false;
						WorkflowProcedureCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch 
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//Delete
		public static int Delete(DbProvider db, WorkflowProcedure WorkflowProcedureObj)
		{
			int returnValue = 0;
			if (WorkflowProcedureObj.IsPersistent) 
			{
				returnValue = Delete(db, WorkflowProcedureObj.CodTipoProcedura, WorkflowProcedureObj.CodWorkflow);
			}
			WorkflowProcedureObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			WorkflowProcedureObj.IsDirty = false;
			WorkflowProcedureObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodTipoProceduraValue, string CodWorkflowValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZWorkflowProcedureDelete", new string[] {"CodTipoProcedura", "CodWorkflow"}, new string[] {"string", "string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipoProcedura", (SiarLibrary.NullTypes.StringNT)CodTipoProceduraValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodWorkflow", (SiarLibrary.NullTypes.StringNT)CodWorkflowValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, WorkflowProcedureCollection WorkflowProcedureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZWorkflowProcedureDelete", new string[] {"CodTipoProcedura", "CodWorkflow"}, new string[] {"string", "string"},"");
				for (int i = 0; i < WorkflowProcedureCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipoProcedura", WorkflowProcedureCollectionObj[i].CodTipoProcedura);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodWorkflow", WorkflowProcedureCollectionObj[i].CodWorkflow);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < WorkflowProcedureCollectionObj.Count; i++)
				{
					if ((WorkflowProcedureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (WorkflowProcedureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						WorkflowProcedureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						WorkflowProcedureCollectionObj[i].IsDirty = false;
						WorkflowProcedureCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch 
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//getById
		public static WorkflowProcedure GetById(DbProvider db, string CodTipoProceduraValue, string CodWorkflowValue)
		{
			WorkflowProcedure WorkflowProcedureObj = null;
			IDbCommand readCmd = db.InitCmd( "ZWorkflowProcedureGetById", new string[] {"CodTipoProcedura", "CodWorkflow"}, new string[] {"string", "string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipoProcedura", (SiarLibrary.NullTypes.StringNT)CodTipoProceduraValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodWorkflow", (SiarLibrary.NullTypes.StringNT)CodWorkflowValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				WorkflowProcedureObj = GetFromDatareader(db);
				WorkflowProcedureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				WorkflowProcedureObj.IsDirty = false;
				WorkflowProcedureObj.IsPersistent = true;
			}
			db.Close();
			return WorkflowProcedureObj;
		}

		//getFromDatareader
		public static WorkflowProcedure GetFromDatareader(DbProvider db)
		{
			WorkflowProcedure WorkflowProcedureObj = new WorkflowProcedure();
			WorkflowProcedureObj.CodTipoProcedura = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_PROCEDURA"]);
			WorkflowProcedureObj.CodWorkflow = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_WORKFLOW"]);
			WorkflowProcedureObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			WorkflowProcedureObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			WorkflowProcedureObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			WorkflowProcedureObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			WorkflowProcedureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			WorkflowProcedureObj.IsDirty = false;
			WorkflowProcedureObj.IsPersistent = true;
			return WorkflowProcedureObj;
		}

		//Find Select

		public static WorkflowProcedureCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoProceduraEqualThis, SiarLibrary.NullTypes.StringNT CodWorkflowEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis)

		{

			WorkflowProcedureCollection WorkflowProcedureCollectionObj = new WorkflowProcedureCollection();

			IDbCommand findCmd = db.InitCmd("Zworkflowprocedurefindselect", new string[] {"CodTipoProceduraequalthis", "CodWorkflowequalthis", "Ordineequalthis", 
"Obbligatorioequalthis"}, new string[] {"string", "string", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoProceduraequalthis", CodTipoProceduraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodWorkflowequalthis", CodWorkflowEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			WorkflowProcedure WorkflowProcedureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				WorkflowProcedureObj = GetFromDatareader(db);
				WorkflowProcedureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				WorkflowProcedureObj.IsDirty = false;
				WorkflowProcedureObj.IsPersistent = true;
				WorkflowProcedureCollectionObj.Add(WorkflowProcedureObj);
			}
			db.Close();
			return WorkflowProcedureCollectionObj;
		}

		//Find Find

		public static WorkflowProcedureCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoProceduraEqualThis, SiarLibrary.NullTypes.StringNT CodWorkflowEqualThis, SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqGreaterThanThis)

		{

			WorkflowProcedureCollection WorkflowProcedureCollectionObj = new WorkflowProcedureCollection();

			IDbCommand findCmd = db.InitCmd("Zworkflowprocedurefindfind", new string[] {"CodTipoProceduraequalthis", "CodWorkflowequalthis", "Obbligatorioequalthis", 
"Ordineeqgreaterthanthis"}, new string[] {"string", "string", "bool", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoProceduraequalthis", CodTipoProceduraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodWorkflowequalthis", CodWorkflowEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineeqgreaterthanthis", OrdineEqGreaterThanThis);
			WorkflowProcedure WorkflowProcedureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				WorkflowProcedureObj = GetFromDatareader(db);
				WorkflowProcedureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				WorkflowProcedureObj.IsDirty = false;
				WorkflowProcedureObj.IsPersistent = true;
				WorkflowProcedureCollectionObj.Add(WorkflowProcedureObj);
			}
			db.Close();
			return WorkflowProcedureCollectionObj;
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