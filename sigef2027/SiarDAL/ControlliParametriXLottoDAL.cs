using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ControlliParametriXLottoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class ControlliParametriXLottoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ControlliParametriXLotto ControlliParametriXLottoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", ControlliParametriXLottoObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdParametro", ControlliParametriXLottoObj.IdParametro);
			DbProvider.SetCmdParam(cmd,firstChar + "PesoReale", ControlliParametriXLottoObj.PesoReale);
		}
		//Insert
		private static int Insert(DbProvider db, ControlliParametriXLotto ControlliParametriXLottoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZControlliParametriXLottoInsert", new string[] {"IdLotto", "IdParametro", "PesoReale", 
}, new string[] {"int", "int", "int", 
},"");
				CompileIUCmd(false, insertCmd,ControlliParametriXLottoObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				ControlliParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXLottoObj.IsDirty = false;
				ControlliParametriXLottoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ControlliParametriXLotto ControlliParametriXLottoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliParametriXLottoUpdate", new string[] {"IdLotto", "IdParametro", "PesoReale", 
}, new string[] {"int", "int", "int", 
},"");
				CompileIUCmd(true, updateCmd,ControlliParametriXLottoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ControlliParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXLottoObj.IsDirty = false;
				ControlliParametriXLottoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ControlliParametriXLotto ControlliParametriXLottoObj)
		{
			switch (ControlliParametriXLottoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ControlliParametriXLottoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ControlliParametriXLottoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ControlliParametriXLottoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ControlliParametriXLottoCollection ControlliParametriXLottoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliParametriXLottoUpdate", new string[] {"IdLotto", "IdParametro", "PesoReale", 
}, new string[] {"int", "int", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZControlliParametriXLottoInsert", new string[] {"IdLotto", "IdParametro", "PesoReale", 
}, new string[] {"int", "int", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriXLottoDelete", new string[] {"IdLotto", "IdParametro"}, new string[] {"int", "int"},"");
				for (int i = 0; i < ControlliParametriXLottoCollectionObj.Count; i++)
				{
					switch (ControlliParametriXLottoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ControlliParametriXLottoCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ControlliParametriXLottoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ControlliParametriXLottoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)ControlliParametriXLottoCollectionObj[i].IdLotto);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)ControlliParametriXLottoCollectionObj[i].IdParametro);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ControlliParametriXLottoCollectionObj.Count; i++)
				{
					if ((ControlliParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliParametriXLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ControlliParametriXLottoCollectionObj[i].IsDirty = false;
						ControlliParametriXLottoCollectionObj[i].IsPersistent = true;
					}
					if ((ControlliParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ControlliParametriXLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliParametriXLottoCollectionObj[i].IsDirty = false;
						ControlliParametriXLottoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ControlliParametriXLotto ControlliParametriXLottoObj)
		{
			int returnValue = 0;
			if (ControlliParametriXLottoObj.IsPersistent) 
			{
				returnValue = Delete(db, ControlliParametriXLottoObj.IdLotto, ControlliParametriXLottoObj.IdParametro);
			}
			ControlliParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ControlliParametriXLottoObj.IsDirty = false;
			ControlliParametriXLottoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLottoValue, int IdParametroValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriXLottoDelete", new string[] {"IdLotto", "IdParametro"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)IdParametroValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ControlliParametriXLottoCollection ControlliParametriXLottoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriXLottoDelete", new string[] {"IdLotto", "IdParametro"}, new string[] {"int", "int"},"");
				for (int i = 0; i < ControlliParametriXLottoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", ControlliParametriXLottoCollectionObj[i].IdLotto);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", ControlliParametriXLottoCollectionObj[i].IdParametro);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ControlliParametriXLottoCollectionObj.Count; i++)
				{
					if ((ControlliParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliParametriXLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliParametriXLottoCollectionObj[i].IsDirty = false;
						ControlliParametriXLottoCollectionObj[i].IsPersistent = false;
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
		public static ControlliParametriXLotto GetById(DbProvider db, int IdLottoValue, int IdParametroValue)
		{
			ControlliParametriXLotto ControlliParametriXLottoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZControlliParametriXLottoGetById", new string[] {"IdLotto", "IdParametro"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)IdParametroValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ControlliParametriXLottoObj = GetFromDatareader(db);
				ControlliParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXLottoObj.IsDirty = false;
				ControlliParametriXLottoObj.IsPersistent = true;
			}
			db.Close();
			return ControlliParametriXLottoObj;
		}

		//getFromDatareader
		public static ControlliParametriXLotto GetFromDatareader(DbProvider db)
		{
			ControlliParametriXLotto ControlliParametriXLottoObj = new ControlliParametriXLotto();
			ControlliParametriXLottoObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			ControlliParametriXLottoObj.IdParametro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAMETRO"]);
			ControlliParametriXLottoObj.PesoReale = new SiarLibrary.NullTypes.IntNT(db.DataReader["PESO_REALE"]);
			ControlliParametriXLottoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ControlliParametriXLottoObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			ControlliParametriXLottoObj.Peso = new SiarLibrary.NullTypes.IntNT(db.DataReader["PESO"]);
			ControlliParametriXLottoObj.Manuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANUALE"]);
			ControlliParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ControlliParametriXLottoObj.IsDirty = false;
			ControlliParametriXLottoObj.IsPersistent = true;
			return ControlliParametriXLottoObj;
		}

		//Find Select

		public static ControlliParametriXLottoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, SiarLibrary.NullTypes.IntNT PesoRealeEqualThis)

		{

			ControlliParametriXLottoCollection ControlliParametriXLottoCollectionObj = new ControlliParametriXLottoCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrolliparametrixlottofindselect", new string[] {"IdLottoequalthis", "IdParametroequalthis", "PesoRealeequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PesoRealeequalthis", PesoRealeEqualThis);
			ControlliParametriXLotto ControlliParametriXLottoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliParametriXLottoObj = GetFromDatareader(db);
				ControlliParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXLottoObj.IsDirty = false;
				ControlliParametriXLottoObj.IsPersistent = true;
				ControlliParametriXLottoCollectionObj.Add(ControlliParametriXLottoObj);
			}
			db.Close();
			return ControlliParametriXLottoCollectionObj;
		}

		//Find Find

		public static ControlliParametriXLottoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, SiarLibrary.NullTypes.BoolNT ManualeEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			ControlliParametriXLottoCollection ControlliParametriXLottoCollectionObj = new ControlliParametriXLottoCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrolliparametrixlottofindfind", new string[] {"IdLottoequalthis", "IdParametroequalthis", "Manualeequalthis", 
"Descrizionelikethis"}, new string[] {"int", "int", "bool", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Manualeequalthis", ManualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			ControlliParametriXLotto ControlliParametriXLottoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliParametriXLottoObj = GetFromDatareader(db);
				ControlliParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXLottoObj.IsDirty = false;
				ControlliParametriXLottoObj.IsPersistent = true;
				ControlliParametriXLottoCollectionObj.Add(ControlliParametriXLottoObj);
			}
			db.Close();
			return ControlliParametriXLottoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_X_LOTTO>
  <ViewName>vCONTROLLI_PARAMETRI_X_LOTTO</ViewName>
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
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_X_LOTTO>
*/