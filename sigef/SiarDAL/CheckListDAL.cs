using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CheckListDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class CheckListDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CheckList CheckListObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCheckList", CheckListObj.IdCheckList);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", CheckListObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagTemplate", CheckListObj.FlagTemplate);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", CheckListObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CheckListObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, CheckList CheckListObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCheckListInsert", new string[] {"Descrizione", "FlagTemplate", 
"DataModifica", "Operatore"}, new string[] {"string", "bool", 
"DateTime", "string"},"");
				CompileIUCmd(false, insertCmd,CheckListObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CheckListObj.IdCheckList = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECK_LIST"]);
				}
				CheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListObj.IsDirty = false;
				CheckListObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CheckList CheckListObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCheckListUpdate", new string[] {"IdCheckList", "Descrizione", "FlagTemplate", 
"DataModifica", "Operatore"}, new string[] {"int", "string", "bool", 
"DateTime", "string"},"");
				CompileIUCmd(true, updateCmd,CheckListObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					CheckListObj.DataModifica = d;
				}
				CheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListObj.IsDirty = false;
				CheckListObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CheckList CheckListObj)
		{
			switch (CheckListObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CheckListObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CheckListObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CheckListObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CheckListCollection CheckListCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCheckListUpdate", new string[] {"IdCheckList", "Descrizione", "FlagTemplate", 
"DataModifica", "Operatore"}, new string[] {"int", "string", "bool", 
"DateTime", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCheckListInsert", new string[] {"Descrizione", "FlagTemplate", 
"DataModifica", "Operatore"}, new string[] {"string", "bool", 
"DateTime", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCheckListDelete", new string[] {"IdCheckList"}, new string[] {"int"},"");
				for (int i = 0; i < CheckListCollectionObj.Count; i++)
				{
					switch (CheckListCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CheckListCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CheckListCollectionObj[i].IdCheckList = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECK_LIST"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CheckListCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									CheckListCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CheckListCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)CheckListCollectionObj[i].IdCheckList);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CheckListCollectionObj.Count; i++)
				{
					if ((CheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CheckListCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CheckListCollectionObj[i].IsDirty = false;
						CheckListCollectionObj[i].IsPersistent = true;
					}
					if ((CheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CheckListCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CheckListCollectionObj[i].IsDirty = false;
						CheckListCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CheckList CheckListObj)
		{
			int returnValue = 0;
			if (CheckListObj.IsPersistent) 
			{
				returnValue = Delete(db, CheckListObj.IdCheckList);
			}
			CheckListObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CheckListObj.IsDirty = false;
			CheckListObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCheckListValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCheckListDelete", new string[] {"IdCheckList"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)IdCheckListValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CheckListCollection CheckListCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCheckListDelete", new string[] {"IdCheckList"}, new string[] {"int"},"");
				for (int i = 0; i < CheckListCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", CheckListCollectionObj[i].IdCheckList);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CheckListCollectionObj.Count; i++)
				{
					if ((CheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CheckListCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CheckListCollectionObj[i].IsDirty = false;
						CheckListCollectionObj[i].IsPersistent = false;
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
		public static CheckList GetById(DbProvider db, int IdCheckListValue)
		{
			CheckList CheckListObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCheckListGetById", new string[] {"IdCheckList"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)IdCheckListValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CheckListObj = GetFromDatareader(db);
				CheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListObj.IsDirty = false;
				CheckListObj.IsPersistent = true;
			}
			db.Close();
			return CheckListObj;
		}

		//getFromDatareader
		public static CheckList GetFromDatareader(DbProvider db)
		{
			CheckList CheckListObj = new CheckList();
			CheckListObj.IdCheckList = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECK_LIST"]);
			CheckListObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CheckListObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
			CheckListObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			CheckListObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			CheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CheckListObj.IsDirty = false;
			CheckListObj.IsPersistent = true;
			return CheckListObj;
		}

		//Find Select

		public static CheckListCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCheckListEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis)

		{

			CheckListCollection CheckListCollectionObj = new CheckListCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistfindselect", new string[] {"IdCheckListequalthis", "Descrizioneequalthis", "FlagTemplateequalthis", 
"DataModificaequalthis", "Operatoreequalthis"}, new string[] {"int", "string", "bool", 
"DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCheckListequalthis", IdCheckListEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			CheckList CheckListObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CheckListObj = GetFromDatareader(db);
				CheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListObj.IsDirty = false;
				CheckListObj.IsPersistent = true;
				CheckListCollectionObj.Add(CheckListObj);
			}
			db.Close();
			return CheckListCollectionObj;
		}

		//Find Find

		public static CheckListCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis)

		{

			CheckListCollection CheckListCollectionObj = new CheckListCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistfindfind", new string[] {"Descrizionelikethis", "FlagTemplateequalthis"}, new string[] {"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			CheckList CheckListObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CheckListObj = GetFromDatareader(db);
				CheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListObj.IsDirty = false;
				CheckListObj.IsPersistent = true;
				CheckListCollectionObj.Add(CheckListObj);
			}
			db.Close();
			return CheckListCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CHECK_LIST>
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
    <Find OrderBy="ORDER BY ID_CHECK_LIST">
      <DESCRIZIONE>Like</DESCRIZIONE>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CHECK_LIST>
*/