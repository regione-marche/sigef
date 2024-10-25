using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for NoteDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class NoteDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Note NoteObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", NoteObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Testo", NoteObj.Testo);
		}
		//Insert
		private static int Insert(DbProvider db, Note NoteObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZNoteInsert", new string[] {"Testo"}, new string[] {"string"},"");
				CompileIUCmd(false, insertCmd,NoteObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				NoteObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				NoteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NoteObj.IsDirty = false;
				NoteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Note NoteObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZNoteUpdate", new string[] {"Id", "Testo"}, new string[] {"int", "string"},"");
				CompileIUCmd(true, updateCmd,NoteObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				NoteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NoteObj.IsDirty = false;
				NoteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Note NoteObj)
		{
			switch (NoteObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, NoteObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, NoteObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,NoteObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, NoteCollection NoteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZNoteUpdate", new string[] {"Id", "Testo"}, new string[] {"int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZNoteInsert", new string[] {"Testo"}, new string[] {"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZNoteDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < NoteCollectionObj.Count; i++)
				{
					switch (NoteCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,NoteCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									NoteCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,NoteCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (NoteCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)NoteCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < NoteCollectionObj.Count; i++)
				{
					if ((NoteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (NoteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						NoteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						NoteCollectionObj[i].IsDirty = false;
						NoteCollectionObj[i].IsPersistent = true;
					}
					if ((NoteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						NoteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						NoteCollectionObj[i].IsDirty = false;
						NoteCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Note NoteObj)
		{
			int returnValue = 0;
			if (NoteObj.IsPersistent) 
			{
				returnValue = Delete(db, NoteObj.Id);
			}
			NoteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			NoteObj.IsDirty = false;
			NoteObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZNoteDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, NoteCollection NoteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZNoteDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < NoteCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", NoteCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < NoteCollectionObj.Count; i++)
				{
					if ((NoteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (NoteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						NoteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						NoteCollectionObj[i].IsDirty = false;
						NoteCollectionObj[i].IsPersistent = false;
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
		public static Note GetById(DbProvider db, int IdValue)
		{
			Note NoteObj = null;
			IDbCommand readCmd = db.InitCmd( "ZNoteGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				NoteObj = GetFromDatareader(db);
				NoteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NoteObj.IsDirty = false;
				NoteObj.IsPersistent = true;
			}
			db.Close();
			return NoteObj;
		}

		//getFromDatareader
		public static Note GetFromDatareader(DbProvider db)
		{
			Note NoteObj = new Note();
			NoteObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			NoteObj.Testo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO"]);
			NoteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			NoteObj.IsDirty = false;
			NoteObj.IsPersistent = true;
			return NoteObj;
		}

		//Find Select

		public static NoteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT TestoEqualThis)

		{

			NoteCollection NoteCollectionObj = new NoteCollection();

			IDbCommand findCmd = db.InitCmd("Znotefindselect", new string[] {"Idequalthis", "Testoequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Testoequalthis", TestoEqualThis);
			Note NoteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				NoteObj = GetFromDatareader(db);
				NoteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NoteObj.IsDirty = false;
				NoteObj.IsPersistent = true;
				NoteCollectionObj.Add(NoteObj);
			}
			db.Close();
			return NoteCollectionObj;
		}

		//Find Find

		public static NoteCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis)

		{

			NoteCollection NoteCollectionObj = new NoteCollection();

			IDbCommand findCmd = db.InitCmd("Znotefindfind", new string[] {"Idequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			Note NoteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				NoteObj = GetFromDatareader(db);
				NoteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NoteObj.IsDirty = false;
				NoteObj.IsPersistent = true;
				NoteCollectionObj.Add(NoteObj);
			}
			db.Close();
			return NoteCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<NOTE>
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
      <ID>Equal</ID>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</NOTE>
*/