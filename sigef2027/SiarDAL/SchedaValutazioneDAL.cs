using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SchedaValutazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class SchedaValutazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SchedaValutazione SchedaValutazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdSchedaValutazione", SchedaValutazioneObj.IdSchedaValutazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", SchedaValutazioneObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagTemplate", SchedaValutazioneObj.FlagTemplate);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreMax", SchedaValutazioneObj.ValoreMax);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreMin", SchedaValutazioneObj.ValoreMin);
			DbProvider.SetCmdParam(cmd,firstChar + "ParoleChiave", SchedaValutazioneObj.ParoleChiave);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", SchedaValutazioneObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, SchedaValutazione SchedaValutazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZSchedaValutazioneInsert", new string[] {"Descrizione", "FlagTemplate", 
"ValoreMax", "ValoreMin", "ParoleChiave", 
"DataModifica"}, new string[] {"string", "bool", 
"decimal", "decimal", "string", 
"DateTime"},"");
				CompileIUCmd(false, insertCmd,SchedaValutazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				SchedaValutazioneObj.IdSchedaValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_VALUTAZIONE"]);
				SchedaValutazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				SchedaValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaValutazioneObj.IsDirty = false;
				SchedaValutazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SchedaValutazione SchedaValutazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSchedaValutazioneUpdate", new string[] {"IdSchedaValutazione", "Descrizione", "FlagTemplate", 
"ValoreMax", "ValoreMin", "ParoleChiave", 
"DataModifica"}, new string[] {"int", "string", "bool", 
"decimal", "decimal", "string", 
"DateTime"},"");
				CompileIUCmd(true, updateCmd,SchedaValutazioneObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					SchedaValutazioneObj.DataModifica = d;
				}
				SchedaValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaValutazioneObj.IsDirty = false;
				SchedaValutazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SchedaValutazione SchedaValutazioneObj)
		{
			switch (SchedaValutazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, SchedaValutazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, SchedaValutazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,SchedaValutazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SchedaValutazioneCollection SchedaValutazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSchedaValutazioneUpdate", new string[] {"IdSchedaValutazione", "Descrizione", "FlagTemplate", 
"ValoreMax", "ValoreMin", "ParoleChiave", 
"DataModifica"}, new string[] {"int", "string", "bool", 
"decimal", "decimal", "string", 
"DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZSchedaValutazioneInsert", new string[] {"Descrizione", "FlagTemplate", 
"ValoreMax", "ValoreMin", "ParoleChiave", 
"DataModifica"}, new string[] {"string", "bool", 
"decimal", "decimal", "string", 
"DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaValutazioneDelete", new string[] {"IdSchedaValutazione"}, new string[] {"int"},"");
				for (int i = 0; i < SchedaValutazioneCollectionObj.Count; i++)
				{
					switch (SchedaValutazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,SchedaValutazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SchedaValutazioneCollectionObj[i].IdSchedaValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_VALUTAZIONE"]);
									SchedaValutazioneCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,SchedaValutazioneCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									SchedaValutazioneCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (SchedaValutazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)SchedaValutazioneCollectionObj[i].IdSchedaValutazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SchedaValutazioneCollectionObj.Count; i++)
				{
					if ((SchedaValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SchedaValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SchedaValutazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SchedaValutazioneCollectionObj[i].IsDirty = false;
						SchedaValutazioneCollectionObj[i].IsPersistent = true;
					}
					if ((SchedaValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SchedaValutazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SchedaValutazioneCollectionObj[i].IsDirty = false;
						SchedaValutazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SchedaValutazione SchedaValutazioneObj)
		{
			int returnValue = 0;
			if (SchedaValutazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, SchedaValutazioneObj.IdSchedaValutazione);
			}
			SchedaValutazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SchedaValutazioneObj.IsDirty = false;
			SchedaValutazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSchedaValutazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaValutazioneDelete", new string[] {"IdSchedaValutazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)IdSchedaValutazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SchedaValutazioneCollection SchedaValutazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaValutazioneDelete", new string[] {"IdSchedaValutazione"}, new string[] {"int"},"");
				for (int i = 0; i < SchedaValutazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", SchedaValutazioneCollectionObj[i].IdSchedaValutazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SchedaValutazioneCollectionObj.Count; i++)
				{
					if ((SchedaValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SchedaValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SchedaValutazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SchedaValutazioneCollectionObj[i].IsDirty = false;
						SchedaValutazioneCollectionObj[i].IsPersistent = false;
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
		public static SchedaValutazione GetById(DbProvider db, int IdSchedaValutazioneValue)
		{
			SchedaValutazione SchedaValutazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZSchedaValutazioneGetById", new string[] {"IdSchedaValutazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)IdSchedaValutazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SchedaValutazioneObj = GetFromDatareader(db);
				SchedaValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaValutazioneObj.IsDirty = false;
				SchedaValutazioneObj.IsPersistent = true;
			}
			db.Close();
			return SchedaValutazioneObj;
		}

		//getFromDatareader
		public static SchedaValutazione GetFromDatareader(DbProvider db)
		{
			SchedaValutazione SchedaValutazioneObj = new SchedaValutazione();
			SchedaValutazioneObj.IdSchedaValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_VALUTAZIONE"]);
			SchedaValutazioneObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			SchedaValutazioneObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
			SchedaValutazioneObj.ValoreMax = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_MAX"]);
			SchedaValutazioneObj.ValoreMin = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_MIN"]);
			SchedaValutazioneObj.ParoleChiave = new SiarLibrary.NullTypes.StringNT(db.DataReader["PAROLE_CHIAVE"]);
			SchedaValutazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			SchedaValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SchedaValutazioneObj.IsDirty = false;
			SchedaValutazioneObj.IsPersistent = true;
			return SchedaValutazioneObj;
		}

		//Find Select

		public static SchedaValutazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaValutazioneEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis, 
SiarLibrary.NullTypes.DecimalNT ValoreMaxEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreMinEqualThis, SiarLibrary.NullTypes.StringNT ParoleChiaveEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			SchedaValutazioneCollection SchedaValutazioneCollectionObj = new SchedaValutazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zschedavalutazionefindselect", new string[] {"IdSchedaValutazioneequalthis", "Descrizioneequalthis", "FlagTemplateequalthis", 
"ValoreMaxequalthis", "ValoreMinequalthis", "ParoleChiaveequalthis", 
"DataModificaequalthis"}, new string[] {"int", "string", "bool", 
"decimal", "decimal", "string", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSchedaValutazioneequalthis", IdSchedaValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreMaxequalthis", ValoreMaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreMinequalthis", ValoreMinEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ParoleChiaveequalthis", ParoleChiaveEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			SchedaValutazione SchedaValutazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SchedaValutazioneObj = GetFromDatareader(db);
				SchedaValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaValutazioneObj.IsDirty = false;
				SchedaValutazioneObj.IsPersistent = true;
				SchedaValutazioneCollectionObj.Add(SchedaValutazioneObj);
			}
			db.Close();
			return SchedaValutazioneCollectionObj;
		}

		//Find Find

		public static SchedaValutazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaValutazioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, 
SiarLibrary.NullTypes.StringNT ParoleChiaveLikeThis)

		{

			SchedaValutazioneCollection SchedaValutazioneCollectionObj = new SchedaValutazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zschedavalutazionefindfind", new string[] {"IdSchedaValutazioneequalthis", "FlagTemplateequalthis", "Descrizionelikethis", 
"ParoleChiavelikethis"}, new string[] {"int", "bool", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSchedaValutazioneequalthis", IdSchedaValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ParoleChiavelikethis", ParoleChiaveLikeThis);
			SchedaValutazione SchedaValutazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SchedaValutazioneObj = GetFromDatareader(db);
				SchedaValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaValutazioneObj.IsDirty = false;
				SchedaValutazioneObj.IsPersistent = true;
				SchedaValutazioneCollectionObj.Add(SchedaValutazioneObj);
			}
			db.Close();
			return SchedaValutazioneCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SCHEDA_VALUTAZIONE>
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
    <Find OrderBy="ORDER BY DATA_MODIFICA DESC">
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <PAROLE_CHIAVE>Like</PAROLE_CHIAVE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SCHEDA_VALUTAZIONE>
*/