using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PrioritaSettorialiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class PrioritaSettorialiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PrioritaSettoriali PrioritaSettorialiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPrioritaSettoriale", PrioritaSettorialiObj.IdPrioritaSettoriale);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", PrioritaSettorialiObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, PrioritaSettoriali PrioritaSettorialiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaSettorialiInsert", new string[] {"Descrizione"}, new string[] {"string"},"");
				CompileIUCmd(false, insertCmd,PrioritaSettorialiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PrioritaSettorialiObj.IdPrioritaSettoriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SETTORIALE"]);
				}
				PrioritaSettorialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSettorialiObj.IsDirty = false;
				PrioritaSettorialiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PrioritaSettoriali PrioritaSettorialiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaSettorialiUpdate", new string[] {"IdPrioritaSettoriale", "Descrizione"}, new string[] {"int", "string"},"");
				CompileIUCmd(true, updateCmd,PrioritaSettorialiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PrioritaSettorialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSettorialiObj.IsDirty = false;
				PrioritaSettorialiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PrioritaSettoriali PrioritaSettorialiObj)
		{
			switch (PrioritaSettorialiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PrioritaSettorialiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PrioritaSettorialiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PrioritaSettorialiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PrioritaSettorialiCollection PrioritaSettorialiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaSettorialiUpdate", new string[] {"IdPrioritaSettoriale", "Descrizione"}, new string[] {"int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaSettorialiInsert", new string[] {"Descrizione"}, new string[] {"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaSettorialiDelete", new string[] {"IdPrioritaSettoriale"}, new string[] {"int"},"");
				for (int i = 0; i < PrioritaSettorialiCollectionObj.Count; i++)
				{
					switch (PrioritaSettorialiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PrioritaSettorialiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PrioritaSettorialiCollectionObj[i].IdPrioritaSettoriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SETTORIALE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PrioritaSettorialiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PrioritaSettorialiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrioritaSettoriale", (SiarLibrary.NullTypes.IntNT)PrioritaSettorialiCollectionObj[i].IdPrioritaSettoriale);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PrioritaSettorialiCollectionObj.Count; i++)
				{
					if ((PrioritaSettorialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaSettorialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaSettorialiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PrioritaSettorialiCollectionObj[i].IsDirty = false;
						PrioritaSettorialiCollectionObj[i].IsPersistent = true;
					}
					if ((PrioritaSettorialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PrioritaSettorialiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaSettorialiCollectionObj[i].IsDirty = false;
						PrioritaSettorialiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PrioritaSettoriali PrioritaSettorialiObj)
		{
			int returnValue = 0;
			if (PrioritaSettorialiObj.IsPersistent) 
			{
				returnValue = Delete(db, PrioritaSettorialiObj.IdPrioritaSettoriale);
			}
			PrioritaSettorialiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PrioritaSettorialiObj.IsDirty = false;
			PrioritaSettorialiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPrioritaSettorialeValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaSettorialiDelete", new string[] {"IdPrioritaSettoriale"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrioritaSettoriale", (SiarLibrary.NullTypes.IntNT)IdPrioritaSettorialeValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PrioritaSettorialiCollection PrioritaSettorialiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaSettorialiDelete", new string[] {"IdPrioritaSettoriale"}, new string[] {"int"},"");
				for (int i = 0; i < PrioritaSettorialiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrioritaSettoriale", PrioritaSettorialiCollectionObj[i].IdPrioritaSettoriale);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PrioritaSettorialiCollectionObj.Count; i++)
				{
					if ((PrioritaSettorialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaSettorialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaSettorialiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaSettorialiCollectionObj[i].IsDirty = false;
						PrioritaSettorialiCollectionObj[i].IsPersistent = false;
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
		public static PrioritaSettoriali GetById(DbProvider db, int IdPrioritaSettorialeValue)
		{
			PrioritaSettoriali PrioritaSettorialiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPrioritaSettorialiGetById", new string[] {"IdPrioritaSettoriale"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPrioritaSettoriale", (SiarLibrary.NullTypes.IntNT)IdPrioritaSettorialeValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PrioritaSettorialiObj = GetFromDatareader(db);
				PrioritaSettorialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSettorialiObj.IsDirty = false;
				PrioritaSettorialiObj.IsPersistent = true;
			}
			db.Close();
			return PrioritaSettorialiObj;
		}

		//getFromDatareader
		public static PrioritaSettoriali GetFromDatareader(DbProvider db)
		{
			PrioritaSettoriali PrioritaSettorialiObj = new PrioritaSettoriali();
			PrioritaSettorialiObj.IdPrioritaSettoriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SETTORIALE"]);
			PrioritaSettorialiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PrioritaSettorialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PrioritaSettorialiObj.IsDirty = false;
			PrioritaSettorialiObj.IsPersistent = true;
			return PrioritaSettorialiObj;
		}

		//Find Select

		public static PrioritaSettorialiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaSettorialeEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			PrioritaSettorialiCollection PrioritaSettorialiCollectionObj = new PrioritaSettorialiCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritasettorialifindselect", new string[] {"IdPrioritaSettorialeequalthis", "Descrizioneequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaSettorialeequalthis", IdPrioritaSettorialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			PrioritaSettoriali PrioritaSettorialiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaSettorialiObj = GetFromDatareader(db);
				PrioritaSettorialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSettorialiObj.IsDirty = false;
				PrioritaSettorialiObj.IsPersistent = true;
				PrioritaSettorialiCollectionObj.Add(PrioritaSettorialiObj);
			}
			db.Close();
			return PrioritaSettorialiCollectionObj;
		}

		//Find Find

		public static PrioritaSettorialiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaSettorialeEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			PrioritaSettorialiCollection PrioritaSettorialiCollectionObj = new PrioritaSettorialiCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritasettorialifindfind", new string[] {"IdPrioritaSettorialeequalthis", "Descrizionelikethis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaSettorialeequalthis", IdPrioritaSettorialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			PrioritaSettoriali PrioritaSettorialiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaSettorialiObj = GetFromDatareader(db);
				PrioritaSettorialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSettorialiObj.IsDirty = false;
				PrioritaSettorialiObj.IsPersistent = true;
				PrioritaSettorialiCollectionObj.Add(PrioritaSettorialiObj);
			}
			db.Close();
			return PrioritaSettorialiCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_SETTORIALI>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_PRIORITA_SETTORIALE>Equal</ID_PRIORITA_SETTORIALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_SETTORIALI>
*/