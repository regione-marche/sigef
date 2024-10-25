using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ControlliParametriDiRischioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class ControlliParametriDiRischioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ControlliParametriDiRischio ControlliParametriDiRischioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdParametro", ControlliParametriDiRischioObj.IdParametro);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ControlliParametriDiRischioObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Manuale", ControlliParametriDiRischioObj.Manuale);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySql", ControlliParametriDiRischioObj.QuerySql);
			DbProvider.SetCmdParam(cmd,firstChar + "Peso", ControlliParametriDiRischioObj.Peso);
		}
		//Insert
		private static int Insert(DbProvider db, ControlliParametriDiRischio ControlliParametriDiRischioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZControlliParametriDiRischioInsert", new string[] {"Descrizione", "Manuale", 
"QuerySql", "Peso"}, new string[] {"string", "bool", 
"string", "int"},"");
				CompileIUCmd(false, insertCmd,ControlliParametriDiRischioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ControlliParametriDiRischioObj.IdParametro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAMETRO"]);
				ControlliParametriDiRischioObj.Manuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANUALE"]);
				}
				ControlliParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriDiRischioObj.IsDirty = false;
				ControlliParametriDiRischioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ControlliParametriDiRischio ControlliParametriDiRischioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliParametriDiRischioUpdate", new string[] {"IdParametro", "Descrizione", "Manuale", 
"QuerySql", "Peso"}, new string[] {"int", "string", "bool", 
"string", "int"},"");
				CompileIUCmd(true, updateCmd,ControlliParametriDiRischioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ControlliParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriDiRischioObj.IsDirty = false;
				ControlliParametriDiRischioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ControlliParametriDiRischio ControlliParametriDiRischioObj)
		{
			switch (ControlliParametriDiRischioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ControlliParametriDiRischioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ControlliParametriDiRischioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ControlliParametriDiRischioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ControlliParametriDiRischioCollection ControlliParametriDiRischioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliParametriDiRischioUpdate", new string[] {"IdParametro", "Descrizione", "Manuale", 
"QuerySql", "Peso"}, new string[] {"int", "string", "bool", 
"string", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZControlliParametriDiRischioInsert", new string[] {"Descrizione", "Manuale", 
"QuerySql", "Peso"}, new string[] {"string", "bool", 
"string", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriDiRischioDelete", new string[] {"IdParametro"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliParametriDiRischioCollectionObj.Count; i++)
				{
					switch (ControlliParametriDiRischioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ControlliParametriDiRischioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ControlliParametriDiRischioCollectionObj[i].IdParametro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAMETRO"]);
									ControlliParametriDiRischioCollectionObj[i].Manuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANUALE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ControlliParametriDiRischioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ControlliParametriDiRischioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)ControlliParametriDiRischioCollectionObj[i].IdParametro);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ControlliParametriDiRischioCollectionObj.Count; i++)
				{
					if ((ControlliParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliParametriDiRischioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ControlliParametriDiRischioCollectionObj[i].IsDirty = false;
						ControlliParametriDiRischioCollectionObj[i].IsPersistent = true;
					}
					if ((ControlliParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ControlliParametriDiRischioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliParametriDiRischioCollectionObj[i].IsDirty = false;
						ControlliParametriDiRischioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ControlliParametriDiRischio ControlliParametriDiRischioObj)
		{
			int returnValue = 0;
			if (ControlliParametriDiRischioObj.IsPersistent) 
			{
				returnValue = Delete(db, ControlliParametriDiRischioObj.IdParametro);
			}
			ControlliParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ControlliParametriDiRischioObj.IsDirty = false;
			ControlliParametriDiRischioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdParametroValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriDiRischioDelete", new string[] {"IdParametro"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)IdParametroValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ControlliParametriDiRischioCollection ControlliParametriDiRischioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriDiRischioDelete", new string[] {"IdParametro"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliParametriDiRischioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", ControlliParametriDiRischioCollectionObj[i].IdParametro);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ControlliParametriDiRischioCollectionObj.Count; i++)
				{
					if ((ControlliParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliParametriDiRischioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliParametriDiRischioCollectionObj[i].IsDirty = false;
						ControlliParametriDiRischioCollectionObj[i].IsPersistent = false;
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
		public static ControlliParametriDiRischio GetById(DbProvider db, int IdParametroValue)
		{
			ControlliParametriDiRischio ControlliParametriDiRischioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZControlliParametriDiRischioGetById", new string[] {"IdParametro"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)IdParametroValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ControlliParametriDiRischioObj = GetFromDatareader(db);
				ControlliParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriDiRischioObj.IsDirty = false;
				ControlliParametriDiRischioObj.IsPersistent = true;
			}
			db.Close();
			return ControlliParametriDiRischioObj;
		}

		//getFromDatareader
		public static ControlliParametriDiRischio GetFromDatareader(DbProvider db)
		{
			ControlliParametriDiRischio ControlliParametriDiRischioObj = new ControlliParametriDiRischio();
			ControlliParametriDiRischioObj.IdParametro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAMETRO"]);
			ControlliParametriDiRischioObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ControlliParametriDiRischioObj.Manuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANUALE"]);
			ControlliParametriDiRischioObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			ControlliParametriDiRischioObj.Peso = new SiarLibrary.NullTypes.IntNT(db.DataReader["PESO"]);
			ControlliParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ControlliParametriDiRischioObj.IsDirty = false;
			ControlliParametriDiRischioObj.IsPersistent = true;
			return ControlliParametriDiRischioObj;
		}

		//Find Select

		public static ControlliParametriDiRischioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT ManualeEqualThis, 
SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, SiarLibrary.NullTypes.IntNT PesoEqualThis)

		{

			ControlliParametriDiRischioCollection ControlliParametriDiRischioCollectionObj = new ControlliParametriDiRischioCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrolliparametridirischiofindselect", new string[] {"IdParametroequalthis", "Descrizioneequalthis", "Manualeequalthis", 
"QuerySqlequalthis", "Pesoequalthis"}, new string[] {"int", "string", "bool", 
"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Manualeequalthis", ManualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pesoequalthis", PesoEqualThis);
			ControlliParametriDiRischio ControlliParametriDiRischioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliParametriDiRischioObj = GetFromDatareader(db);
				ControlliParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriDiRischioObj.IsDirty = false;
				ControlliParametriDiRischioObj.IsPersistent = true;
				ControlliParametriDiRischioCollectionObj.Add(ControlliParametriDiRischioObj);
			}
			db.Close();
			return ControlliParametriDiRischioCollectionObj;
		}

		//Find Find

		public static ControlliParametriDiRischioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, SiarLibrary.NullTypes.BoolNT ManualeEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			ControlliParametriDiRischioCollection ControlliParametriDiRischioCollectionObj = new ControlliParametriDiRischioCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrolliparametridirischiofindfind", new string[] {"IdParametroequalthis", "Manualeequalthis", "Descrizionelikethis"}, new string[] {"int", "bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Manualeequalthis", ManualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			ControlliParametriDiRischio ControlliParametriDiRischioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliParametriDiRischioObj = GetFromDatareader(db);
				ControlliParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriDiRischioObj.IsDirty = false;
				ControlliParametriDiRischioObj.IsPersistent = true;
				ControlliParametriDiRischioCollectionObj.Add(ControlliParametriDiRischioObj);
			}
			db.Close();
			return ControlliParametriDiRischioCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_DI_RISCHIO>
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
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_DI_RISCHIO>
*/