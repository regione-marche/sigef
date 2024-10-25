using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for StepDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class StepDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Step StepObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdStep", StepObj.IdStep);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", StepObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Automatico", StepObj.Automatico);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySql", StepObj.QuerySql);
			DbProvider.SetCmdParam(cmd,firstChar + "CodeMethod", StepObj.CodeMethod);
			DbProvider.SetCmdParam(cmd,firstChar + "Url", StepObj.Url);
			DbProvider.SetCmdParam(cmd,firstChar + "ValMassimo", StepObj.ValMassimo);
			DbProvider.SetCmdParam(cmd,firstChar + "ValMinimo", StepObj.ValMinimo);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySqlPost", StepObj.QuerySqlPost);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFase", StepObj.CodFase);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", StepObj.Misura);
		}
		//Insert
		private static int Insert(DbProvider db, Step StepObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZStepInsert", new string[] {"Descrizione", "Automatico", 
"QuerySql", "CodeMethod", "Url", 
"ValMassimo", "ValMinimo", "QuerySqlPost", 
"CodFase", 
"Misura"}, new string[] {"string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string", 
"string"},"");
				CompileIUCmd(false, insertCmd,StepObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				StepObj.IdStep = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STEP"]);
				}
				StepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepObj.IsDirty = false;
				StepObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Step StepObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZStepUpdate", new string[] {"IdStep", "Descrizione", "Automatico", 
"QuerySql", "CodeMethod", "Url", 
"ValMassimo", "ValMinimo", "QuerySqlPost", 
"CodFase", 
"Misura"}, new string[] {"int", "string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string", 
"string"},"");
				CompileIUCmd(true, updateCmd,StepObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				StepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepObj.IsDirty = false;
				StepObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Step StepObj)
		{
			switch (StepObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, StepObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, StepObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,StepObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, StepCollection StepCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZStepUpdate", new string[] {"IdStep", "Descrizione", "Automatico", 
"QuerySql", "CodeMethod", "Url", 
"ValMassimo", "ValMinimo", "QuerySqlPost", 
"CodFase", 
"Misura"}, new string[] {"int", "string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZStepInsert", new string[] {"Descrizione", "Automatico", 
"QuerySql", "CodeMethod", "Url", 
"ValMassimo", "ValMinimo", "QuerySqlPost", 
"CodFase", 
"Misura"}, new string[] {"string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZStepDelete", new string[] {"IdStep"}, new string[] {"int"},"");
				for (int i = 0; i < StepCollectionObj.Count; i++)
				{
					switch (StepCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,StepCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									StepCollectionObj[i].IdStep = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STEP"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,StepCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (StepCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)StepCollectionObj[i].IdStep);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < StepCollectionObj.Count; i++)
				{
					if ((StepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (StepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						StepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						StepCollectionObj[i].IsDirty = false;
						StepCollectionObj[i].IsPersistent = true;
					}
					if ((StepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						StepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						StepCollectionObj[i].IsDirty = false;
						StepCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Step StepObj)
		{
			int returnValue = 0;
			if (StepObj.IsPersistent) 
			{
				returnValue = Delete(db, StepObj.IdStep);
			}
			StepObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			StepObj.IsDirty = false;
			StepObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdStepValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZStepDelete", new string[] {"IdStep"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)IdStepValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, StepCollection StepCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZStepDelete", new string[] {"IdStep"}, new string[] {"int"},"");
				for (int i = 0; i < StepCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", StepCollectionObj[i].IdStep);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < StepCollectionObj.Count; i++)
				{
					if ((StepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (StepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						StepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						StepCollectionObj[i].IsDirty = false;
						StepCollectionObj[i].IsPersistent = false;
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
		public static Step GetById(DbProvider db, int IdStepValue)
		{
			Step StepObj = null;
			IDbCommand readCmd = db.InitCmd( "ZStepGetById", new string[] {"IdStep"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)IdStepValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				StepObj = GetFromDatareader(db);
				StepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepObj.IsDirty = false;
				StepObj.IsPersistent = true;
			}
			db.Close();
			return StepObj;
		}

		//getFromDatareader
		public static Step GetFromDatareader(DbProvider db)
		{
			Step StepObj = new Step();
			StepObj.IdStep = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STEP"]);
			StepObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			StepObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			StepObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			StepObj.CodeMethod = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD"]);
			StepObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			StepObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
			StepObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
			StepObj.QuerySqlPost = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST"]);
			StepObj.FaseProcedurale = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE_PROCEDURALE"]);
			StepObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			StepObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			StepObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			StepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			StepObj.IsDirty = false;
			StepObj.IsPersistent = true;
			return StepObj;
		}

		//Find Select

		public static StepCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdStepEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis, SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, SiarLibrary.NullTypes.StringNT QuerySqlPostEqualThis, 
SiarLibrary.NullTypes.StringNT CodeMethodEqualThis, SiarLibrary.NullTypes.StringNT UrlEqualThis, SiarLibrary.NullTypes.StringNT ValMinimoEqualThis, 
SiarLibrary.NullTypes.StringNT ValMassimoEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis)

		{

			StepCollection StepCollectionObj = new StepCollection();

			IDbCommand findCmd = db.InitCmd("Zstepfindselect", new string[] {"IdStepequalthis", "CodFaseequalthis", "Descrizioneequalthis", 
"Automaticoequalthis", "QuerySqlequalthis", "QuerySqlPostequalthis", 
"CodeMethodequalthis", "Urlequalthis", "ValMinimoequalthis", 
"ValMassimoequalthis", "Misuraequalthis"}, new string[] {"int", "string", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStepequalthis", IdStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlPostequalthis", QuerySqlPostEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodeMethodequalthis", CodeMethodEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Urlequalthis", UrlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValMinimoequalthis", ValMinimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValMassimoequalthis", ValMassimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			Step StepObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				StepObj = GetFromDatareader(db);
				StepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepObj.IsDirty = false;
				StepObj.IsPersistent = true;
				StepCollectionObj.Add(StepObj);
			}
			db.Close();
			return StepCollectionObj;
		}

		//Find Find

		public static StepCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdStepEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis)

		{

			StepCollection StepCollectionObj = new StepCollection();

			IDbCommand findCmd = db.InitCmd("Zstepfindfind", new string[] {"IdStepequalthis", "Automaticoequalthis", "CodFaseequalthis"}, new string[] {"int", "bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStepequalthis", IdStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			Step StepObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				StepObj = GetFromDatareader(db);
				StepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				StepObj.IsDirty = false;
				StepObj.IsPersistent = true;
				StepCollectionObj.Add(StepObj);
			}
			db.Close();
			return StepCollectionObj;
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