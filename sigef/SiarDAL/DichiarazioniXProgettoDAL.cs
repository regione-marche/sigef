using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DichiarazioniXProgettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class DichiarazioniXProgettoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DichiarazioniXProgetto DichiarazioniXProgettoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDichiarazione", DichiarazioniXProgettoObj.IdDichiarazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", DichiarazioniXProgettoObj.IdProgetto);
		}
		//Insert
		private static int Insert(DbProvider db, DichiarazioniXProgetto DichiarazioniXProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDichiarazioniXProgettoInsert", new string[] {"IdDichiarazione", "IdProgetto"}, new string[] {"int", "int"},"");
				CompileIUCmd(false, insertCmd,DichiarazioniXProgettoObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				DichiarazioniXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXProgettoObj.IsDirty = false;
				DichiarazioniXProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DichiarazioniXProgetto DichiarazioniXProgettoObj)
		{
			throw new NotSupportedException("Nessun campo su cui fare update in una tabella di raccordo. Cancellare e ricreare il record");
		}

		//Save
		public static int Save(DbProvider db, DichiarazioniXProgetto DichiarazioniXProgettoObj)
		{
			switch (DichiarazioniXProgettoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DichiarazioniXProgettoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DichiarazioniXProgettoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DichiarazioniXProgettoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DichiarazioniXProgettoCollection DichiarazioniXProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDichiarazioniXProgettoUpdate", new string[] {"IdDichiarazione", "IdProgetto"}, new string[] {"int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDichiarazioniXProgettoInsert", new string[] {"IdDichiarazione", "IdProgetto"}, new string[] {"int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDichiarazioniXProgettoDelete", new string[] {"IdDichiarazione", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < DichiarazioniXProgettoCollectionObj.Count; i++)
				{
					switch (DichiarazioniXProgettoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DichiarazioniXProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DichiarazioniXProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DichiarazioniXProgettoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)DichiarazioniXProgettoCollectionObj[i].IdDichiarazione);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)DichiarazioniXProgettoCollectionObj[i].IdProgetto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DichiarazioniXProgettoCollectionObj.Count; i++)
				{
					if ((DichiarazioniXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DichiarazioniXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DichiarazioniXProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DichiarazioniXProgettoCollectionObj[i].IsDirty = false;
						DichiarazioniXProgettoCollectionObj[i].IsPersistent = true;
					}
					if ((DichiarazioniXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DichiarazioniXProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DichiarazioniXProgettoCollectionObj[i].IsDirty = false;
						DichiarazioniXProgettoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DichiarazioniXProgetto DichiarazioniXProgettoObj)
		{
			int returnValue = 0;
			if (DichiarazioniXProgettoObj.IsPersistent) 
			{
				returnValue = Delete(db, DichiarazioniXProgettoObj.IdDichiarazione, DichiarazioniXProgettoObj.IdProgetto);
			}
			DichiarazioniXProgettoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DichiarazioniXProgettoObj.IsDirty = false;
			DichiarazioniXProgettoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDichiarazioneValue, int IdProgettoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDichiarazioniXProgettoDelete", new string[] {"IdDichiarazione", "IdProgetto"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)IdDichiarazioneValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DichiarazioniXProgettoCollection DichiarazioniXProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDichiarazioniXProgettoDelete", new string[] {"IdDichiarazione", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < DichiarazioniXProgettoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", DichiarazioniXProgettoCollectionObj[i].IdDichiarazione);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", DichiarazioniXProgettoCollectionObj[i].IdProgetto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DichiarazioniXProgettoCollectionObj.Count; i++)
				{
					if ((DichiarazioniXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DichiarazioniXProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DichiarazioniXProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DichiarazioniXProgettoCollectionObj[i].IsDirty = false;
						DichiarazioniXProgettoCollectionObj[i].IsPersistent = false;
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
		public static DichiarazioniXProgetto GetById(DbProvider db, int IdDichiarazioneValue, int IdProgettoValue)
		{
			DichiarazioniXProgetto DichiarazioniXProgettoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDichiarazioniXProgettoGetById", new string[] {"IdDichiarazione", "IdProgetto"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)IdDichiarazioneValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DichiarazioniXProgettoObj = GetFromDatareader(db);
				DichiarazioniXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXProgettoObj.IsDirty = false;
				DichiarazioniXProgettoObj.IsPersistent = true;
			}
			db.Close();
			return DichiarazioniXProgettoObj;
		}

		//getFromDatareader
		public static DichiarazioniXProgetto GetFromDatareader(DbProvider db)
		{
			DichiarazioniXProgetto DichiarazioniXProgettoObj = new DichiarazioniXProgetto();
			DichiarazioniXProgettoObj.IdDichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DICHIARAZIONE"]);
			DichiarazioniXProgettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			DichiarazioniXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DichiarazioniXProgettoObj.IsDirty = false;
			DichiarazioniXProgettoObj.IsPersistent = true;
			return DichiarazioniXProgettoObj;
		}

		//Find Select

		public static DichiarazioniXProgettoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDichiarazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			DichiarazioniXProgettoCollection DichiarazioniXProgettoCollectionObj = new DichiarazioniXProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zdichiarazionixprogettofindselect", new string[] {"IdDichiarazioneequalthis", "IdProgettoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDichiarazioneequalthis", IdDichiarazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DichiarazioniXProgetto DichiarazioniXProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DichiarazioniXProgettoObj = GetFromDatareader(db);
				DichiarazioniXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXProgettoObj.IsDirty = false;
				DichiarazioniXProgettoObj.IsPersistent = true;
				DichiarazioniXProgettoCollectionObj.Add(DichiarazioniXProgettoObj);
			}
			db.Close();
			return DichiarazioniXProgettoCollectionObj;
		}

		//Find Find

		public static DichiarazioniXProgettoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDichiarazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			DichiarazioniXProgettoCollection DichiarazioniXProgettoCollectionObj = new DichiarazioniXProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zdichiarazionixprogettofindfind", new string[] {"IdDichiarazioneequalthis", "IdProgettoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDichiarazioneequalthis", IdDichiarazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DichiarazioniXProgetto DichiarazioniXProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DichiarazioniXProgettoObj = GetFromDatareader(db);
				DichiarazioniXProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DichiarazioniXProgettoObj.IsDirty = false;
				DichiarazioniXProgettoObj.IsPersistent = true;
				DichiarazioniXProgettoCollectionObj.Add(DichiarazioniXProgettoObj);
			}
			db.Close();
			return DichiarazioniXProgettoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DICHIARAZIONI_X_PROGETTO>
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
    <Find>
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DICHIARAZIONI_X_PROGETTO>
*/