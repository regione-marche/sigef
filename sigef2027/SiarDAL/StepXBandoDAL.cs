using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for StepXBandoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class StepXBandoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, StepXBando StepXBandoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", StepXBandoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCheckList", StepXBandoObj.IdCheckList);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFase", StepXBandoObj.CodFase);
		}
		//Insert
		private static int Insert(DbProvider db, StepXBando StepXBandoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZStepXBandoInsert", new string[] {"IdBando", "IdCheckList", 
"CodFase", }, new string[] {"int", "int", 
"string", },"");
				CompileIUCmd(false, insertCmd,StepXBandoObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				StepXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepXBandoObj.IsDirty = false;
				StepXBandoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, StepXBando StepXBandoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZStepXBandoUpdate", new string[] {"IdBando", "IdCheckList", 
"CodFase", }, new string[] {"int", "int", 
"string", },"");
				CompileIUCmd(true, updateCmd,StepXBandoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				StepXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepXBandoObj.IsDirty = false;
				StepXBandoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, StepXBando StepXBandoObj)
		{
			switch (StepXBandoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, StepXBandoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, StepXBandoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,StepXBandoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, StepXBandoCollection StepXBandoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZStepXBandoUpdate", new string[] {"IdBando", "IdCheckList", 
"CodFase", }, new string[] {"int", "int", 
"string", },"");
				IDbCommand insertCmd = db.InitCmd( "ZStepXBandoInsert", new string[] {"IdBando", "IdCheckList", 
"CodFase", }, new string[] {"int", "int", 
"string", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZStepXBandoDelete", new string[] {"IdBando", "IdCheckList"}, new string[] {"int", "int"},"");
				for (int i = 0; i < StepXBandoCollectionObj.Count; i++)
				{
					switch (StepXBandoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,StepXBandoCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,StepXBandoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (StepXBandoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)StepXBandoCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)StepXBandoCollectionObj[i].IdCheckList);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < StepXBandoCollectionObj.Count; i++)
				{
					if ((StepXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (StepXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						StepXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						StepXBandoCollectionObj[i].IsDirty = false;
						StepXBandoCollectionObj[i].IsPersistent = true;
					}
					if ((StepXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						StepXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						StepXBandoCollectionObj[i].IsDirty = false;
						StepXBandoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, StepXBando StepXBandoObj)
		{
			int returnValue = 0;
			if (StepXBandoObj.IsPersistent) 
			{
				returnValue = Delete(db, StepXBandoObj.IdBando, StepXBandoObj.IdCheckList);
			}
			StepXBandoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			StepXBandoObj.IsDirty = false;
			StepXBandoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, int IdCheckListValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZStepXBandoDelete", new string[] {"IdBando", "IdCheckList"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)IdCheckListValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, StepXBandoCollection StepXBandoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZStepXBandoDelete", new string[] {"IdBando", "IdCheckList"}, new string[] {"int", "int"},"");
				for (int i = 0; i < StepXBandoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", StepXBandoCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", StepXBandoCollectionObj[i].IdCheckList);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < StepXBandoCollectionObj.Count; i++)
				{
					if ((StepXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (StepXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						StepXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						StepXBandoCollectionObj[i].IsDirty = false;
						StepXBandoCollectionObj[i].IsPersistent = false;
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
		public static StepXBando GetById(DbProvider db, int IdBandoValue, int IdCheckListValue)
		{
			StepXBando StepXBandoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZStepXBandoGetById", new string[] {"IdBando", "IdCheckList"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)IdCheckListValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				StepXBandoObj = GetFromDatareader(db);
				StepXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepXBandoObj.IsDirty = false;
				StepXBandoObj.IsPersistent = true;
			}
			db.Close();
			return StepXBandoObj;
		}

		//getFromDatareader
		public static StepXBando GetFromDatareader(DbProvider db)
		{
			StepXBando StepXBandoObj = new StepXBando();
			StepXBandoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			StepXBandoObj.IdCheckList = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECK_LIST"]);
			StepXBandoObj.CheckList = new SiarLibrary.NullTypes.StringNT(db.DataReader["CHECK_LIST"]);
			StepXBandoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			StepXBandoObj.FaseProcedurale = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE_PROCEDURALE"]);
			StepXBandoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			StepXBandoObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
			StepXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			StepXBandoObj.IsDirty = false;
			StepXBandoObj.IsPersistent = true;
			return StepXBandoObj;
		}

		//Find Select

		public static StepXBandoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdCheckListEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis)

		{

			StepXBandoCollection StepXBandoCollectionObj = new StepXBandoCollection();

			IDbCommand findCmd = db.InitCmd("Zstepxbandofindselect", new string[] {"IdBandoequalthis", "IdCheckListequalthis", "CodFaseequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCheckListequalthis", IdCheckListEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			StepXBando StepXBandoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				StepXBandoObj = GetFromDatareader(db);
				StepXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepXBandoObj.IsDirty = false;
				StepXBandoObj.IsPersistent = true;
				StepXBandoCollectionObj.Add(StepXBandoObj);
			}
			db.Close();
			return StepXBandoCollectionObj;
		}

		//Find Find

		public static StepXBandoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdCheckListEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.StringNT CodFaseEqualThis)

		{

			StepXBandoCollection StepXBandoCollectionObj = new StepXBandoCollection();

			IDbCommand findCmd = db.InitCmd("Zstepxbandofindfind", new string[] {"IdBandoequalthis", "IdCheckListequalthis", "Ordineequalthis", 
"CodFaseequalthis"}, new string[] {"int", "int", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCheckListequalthis", IdCheckListEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			StepXBando StepXBandoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				StepXBandoObj = GetFromDatareader(db);
				StepXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepXBandoObj.IsDirty = false;
				StepXBandoObj.IsPersistent = true;
				StepXBandoCollectionObj.Add(StepXBandoObj);
			}
			db.Close();
			return StepXBandoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<STEP_X_BANDO>
  <ViewName>vSTEP_X_BANDO</ViewName>
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
    <Find>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
      <ORDINE>Equal</ORDINE>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</STEP_X_BANDO>
*/