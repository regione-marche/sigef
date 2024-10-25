using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SettoriProduttiviDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class SettoriProduttiviDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SettoriProduttivi SettoriProduttiviObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdSettoreProduttivo", SettoriProduttiviObj.IdSettoreProduttivo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", SettoriProduttiviObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, SettoriProduttivi SettoriProduttiviObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZSettoriProduttiviInsert", new string[] {"Descrizione"}, new string[] {"string"},"");
				CompileIUCmd(false, insertCmd,SettoriProduttiviObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				SettoriProduttiviObj.IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
				}
				SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SettoriProduttiviObj.IsDirty = false;
				SettoriProduttiviObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SettoriProduttivi SettoriProduttiviObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSettoriProduttiviUpdate", new string[] {"IdSettoreProduttivo", "Descrizione"}, new string[] {"int", "string"},"");
				CompileIUCmd(true, updateCmd,SettoriProduttiviObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SettoriProduttiviObj.IsDirty = false;
				SettoriProduttiviObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SettoriProduttivi SettoriProduttiviObj)
		{
			switch (SettoriProduttiviObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, SettoriProduttiviObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, SettoriProduttiviObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,SettoriProduttiviObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SettoriProduttiviCollection SettoriProduttiviCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSettoriProduttiviUpdate", new string[] {"IdSettoreProduttivo", "Descrizione"}, new string[] {"int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZSettoriProduttiviInsert", new string[] {"Descrizione"}, new string[] {"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZSettoriProduttiviDelete", new string[] {"IdSettoreProduttivo"}, new string[] {"int"},"");
				for (int i = 0; i < SettoriProduttiviCollectionObj.Count; i++)
				{
					switch (SettoriProduttiviCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,SettoriProduttiviCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SettoriProduttiviCollectionObj[i].IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,SettoriProduttiviCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (SettoriProduttiviCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)SettoriProduttiviCollectionObj[i].IdSettoreProduttivo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SettoriProduttiviCollectionObj.Count; i++)
				{
					if ((SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SettoriProduttiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SettoriProduttiviCollectionObj[i].IsDirty = false;
						SettoriProduttiviCollectionObj[i].IsPersistent = true;
					}
					if ((SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SettoriProduttiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SettoriProduttiviCollectionObj[i].IsDirty = false;
						SettoriProduttiviCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SettoriProduttivi SettoriProduttiviObj)
		{
			int returnValue = 0;
			if (SettoriProduttiviObj.IsPersistent) 
			{
				returnValue = Delete(db, SettoriProduttiviObj.IdSettoreProduttivo);
			}
			SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SettoriProduttiviObj.IsDirty = false;
			SettoriProduttiviObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSettoreProduttivoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSettoriProduttiviDelete", new string[] {"IdSettoreProduttivo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)IdSettoreProduttivoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SettoriProduttiviCollection SettoriProduttiviCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSettoriProduttiviDelete", new string[] {"IdSettoreProduttivo"}, new string[] {"int"},"");
				for (int i = 0; i < SettoriProduttiviCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSettoreProduttivo", SettoriProduttiviCollectionObj[i].IdSettoreProduttivo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SettoriProduttiviCollectionObj.Count; i++)
				{
					if ((SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SettoriProduttiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SettoriProduttiviCollectionObj[i].IsDirty = false;
						SettoriProduttiviCollectionObj[i].IsPersistent = false;
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
		public static SettoriProduttivi GetById(DbProvider db, int IdSettoreProduttivoValue)
		{
			SettoriProduttivi SettoriProduttiviObj = null;
			IDbCommand readCmd = db.InitCmd( "ZSettoriProduttiviGetById", new string[] {"IdSettoreProduttivo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)IdSettoreProduttivoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SettoriProduttiviObj = GetFromDatareader(db);
				SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SettoriProduttiviObj.IsDirty = false;
				SettoriProduttiviObj.IsPersistent = true;
			}
			db.Close();
			return SettoriProduttiviObj;
		}

		//getFromDatareader
		public static SettoriProduttivi GetFromDatareader(DbProvider db)
		{
			SettoriProduttivi SettoriProduttiviObj = new SettoriProduttivi();
			SettoriProduttiviObj.IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
			SettoriProduttiviObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SettoriProduttiviObj.IsDirty = false;
			SettoriProduttiviObj.IsPersistent = true;
			return SettoriProduttiviObj;
		}

		//Find Select

		public static SettoriProduttiviCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSettoreProduttivoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			SettoriProduttiviCollection SettoriProduttiviCollectionObj = new SettoriProduttiviCollection();

			IDbCommand findCmd = db.InitCmd("Zsettoriproduttivifindselect", new string[] {"IdSettoreProduttivoequalthis", "Descrizioneequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSettoreProduttivoequalthis", IdSettoreProduttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			SettoriProduttivi SettoriProduttiviObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SettoriProduttiviObj = GetFromDatareader(db);
				SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SettoriProduttiviObj.IsDirty = false;
				SettoriProduttiviObj.IsPersistent = true;
				SettoriProduttiviCollectionObj.Add(SettoriProduttiviObj);
			}
			db.Close();
			return SettoriProduttiviCollectionObj;
		}

		//Find Find

		public static SettoriProduttiviCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdSettoreProduttivoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			SettoriProduttiviCollection SettoriProduttiviCollectionObj = new SettoriProduttiviCollection();

			IDbCommand findCmd = db.InitCmd("Zsettoriproduttivifindfind", new string[] {"IdSettoreProduttivoequalthis", "Descrizionelikethis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSettoreProduttivoequalthis", IdSettoreProduttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			SettoriProduttivi SettoriProduttiviObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SettoriProduttiviObj = GetFromDatareader(db);
				SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SettoriProduttiviObj.IsDirty = false;
				SettoriProduttiviObj.IsPersistent = true;
				SettoriProduttiviCollectionObj.Add(SettoriProduttiviObj);
			}
			db.Close();
			return SettoriProduttiviCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SETTORI_PRODUTTIVI>
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
      <ID_SETTORE_PRODUTTIVO>Equal</ID_SETTORE_PRODUTTIVO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SETTORI_PRODUTTIVI>
*/