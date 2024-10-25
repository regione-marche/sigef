using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CatalogoDichiarazioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class CatalogoDichiarazioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CatalogoDichiarazioni CatalogoDichiarazioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdDichiarazione", CatalogoDichiarazioniObj.IdDichiarazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", CatalogoDichiarazioniObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", CatalogoDichiarazioniObj.Misura);
		}
		//Insert
		private static int Insert(DbProvider db, CatalogoDichiarazioni CatalogoDichiarazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCatalogoDichiarazioniInsert", new string[] {"Descrizione", "Misura"}, new string[] {"string", "string"},"");
				CompileIUCmd(false, insertCmd,CatalogoDichiarazioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CatalogoDichiarazioniObj.IdDichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DICHIARAZIONE"]);
				}
				CatalogoDichiarazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CatalogoDichiarazioniObj.IsDirty = false;
				CatalogoDichiarazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CatalogoDichiarazioni CatalogoDichiarazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCatalogoDichiarazioniUpdate", new string[] {"IdDichiarazione", "Descrizione", "Misura"}, new string[] {"int", "string", "string"},"");
				CompileIUCmd(true, updateCmd,CatalogoDichiarazioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CatalogoDichiarazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CatalogoDichiarazioniObj.IsDirty = false;
				CatalogoDichiarazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CatalogoDichiarazioni CatalogoDichiarazioniObj)
		{
			switch (CatalogoDichiarazioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CatalogoDichiarazioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CatalogoDichiarazioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CatalogoDichiarazioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CatalogoDichiarazioniCollection CatalogoDichiarazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCatalogoDichiarazioniUpdate", new string[] {"IdDichiarazione", "Descrizione", "Misura"}, new string[] {"int", "string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCatalogoDichiarazioniInsert", new string[] {"Descrizione", "Misura"}, new string[] {"string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCatalogoDichiarazioniDelete", new string[] {"IdDichiarazione"}, new string[] {"int"},"");
				for (int i = 0; i < CatalogoDichiarazioniCollectionObj.Count; i++)
				{
					switch (CatalogoDichiarazioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CatalogoDichiarazioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CatalogoDichiarazioniCollectionObj[i].IdDichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DICHIARAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CatalogoDichiarazioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CatalogoDichiarazioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)CatalogoDichiarazioniCollectionObj[i].IdDichiarazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CatalogoDichiarazioniCollectionObj.Count; i++)
				{
					if ((CatalogoDichiarazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CatalogoDichiarazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CatalogoDichiarazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CatalogoDichiarazioniCollectionObj[i].IsDirty = false;
						CatalogoDichiarazioniCollectionObj[i].IsPersistent = true;
					}
					if ((CatalogoDichiarazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CatalogoDichiarazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CatalogoDichiarazioniCollectionObj[i].IsDirty = false;
						CatalogoDichiarazioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CatalogoDichiarazioni CatalogoDichiarazioniObj)
		{
			int returnValue = 0;
			if (CatalogoDichiarazioniObj.IsPersistent) 
			{
				returnValue = Delete(db, CatalogoDichiarazioniObj.IdDichiarazione);
			}
			CatalogoDichiarazioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CatalogoDichiarazioniObj.IsDirty = false;
			CatalogoDichiarazioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDichiarazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCatalogoDichiarazioniDelete", new string[] {"IdDichiarazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)IdDichiarazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CatalogoDichiarazioniCollection CatalogoDichiarazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCatalogoDichiarazioniDelete", new string[] {"IdDichiarazione"}, new string[] {"int"},"");
				for (int i = 0; i < CatalogoDichiarazioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDichiarazione", CatalogoDichiarazioniCollectionObj[i].IdDichiarazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CatalogoDichiarazioniCollectionObj.Count; i++)
				{
					if ((CatalogoDichiarazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CatalogoDichiarazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CatalogoDichiarazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CatalogoDichiarazioniCollectionObj[i].IsDirty = false;
						CatalogoDichiarazioniCollectionObj[i].IsPersistent = false;
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
		public static CatalogoDichiarazioni GetById(DbProvider db, int IdDichiarazioneValue)
		{
			CatalogoDichiarazioni CatalogoDichiarazioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCatalogoDichiarazioniGetById", new string[] {"IdDichiarazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDichiarazione", (SiarLibrary.NullTypes.IntNT)IdDichiarazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CatalogoDichiarazioniObj = GetFromDatareader(db);
				CatalogoDichiarazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CatalogoDichiarazioniObj.IsDirty = false;
				CatalogoDichiarazioniObj.IsPersistent = true;
			}
			db.Close();
			return CatalogoDichiarazioniObj;
		}

		//getFromDatareader
		public static CatalogoDichiarazioni GetFromDatareader(DbProvider db)
		{
			CatalogoDichiarazioni CatalogoDichiarazioniObj = new CatalogoDichiarazioni();
			CatalogoDichiarazioniObj.IdDichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DICHIARAZIONE"]);
			CatalogoDichiarazioniObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CatalogoDichiarazioniObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			CatalogoDichiarazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CatalogoDichiarazioniObj.IsDirty = false;
			CatalogoDichiarazioniObj.IsPersistent = true;
			return CatalogoDichiarazioniObj;
		}

		//Find Select

		public static CatalogoDichiarazioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDichiarazioneEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis)

		{

			CatalogoDichiarazioniCollection CatalogoDichiarazioniCollectionObj = new CatalogoDichiarazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zcatalogodichiarazionifindselect", new string[] {"IdDichiarazioneequalthis", "Descrizioneequalthis", "Misuraequalthis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDichiarazioneequalthis", IdDichiarazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			CatalogoDichiarazioni CatalogoDichiarazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CatalogoDichiarazioniObj = GetFromDatareader(db);
				CatalogoDichiarazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CatalogoDichiarazioniObj.IsDirty = false;
				CatalogoDichiarazioniObj.IsPersistent = true;
				CatalogoDichiarazioniCollectionObj.Add(CatalogoDichiarazioniObj);
			}
			db.Close();
			return CatalogoDichiarazioniCollectionObj;
		}

		//Find Find

		public static CatalogoDichiarazioniCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDichiarazioneEqualThis, SiarLibrary.NullTypes.StringNT MisuraLikeThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)
		{
			CatalogoDichiarazioniCollection CatalogoDichiarazioniCollectionObj = new CatalogoDichiarazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zcatalogodichiarazionifindfind", new string[] {"IdDichiarazioneequalthis", "Misuralikethis", "Descrizionelikethis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDichiarazioneequalthis", IdDichiarazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuralikethis", MisuraLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			CatalogoDichiarazioni CatalogoDichiarazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CatalogoDichiarazioniObj = GetFromDatareader(db);
				CatalogoDichiarazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CatalogoDichiarazioniObj.IsDirty = false;
				CatalogoDichiarazioniObj.IsPersistent = true;
				CatalogoDichiarazioniCollectionObj.Add(CatalogoDichiarazioniObj);
			}
			db.Close();
			return CatalogoDichiarazioniCollectionObj;
		}
	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CATALOGO_DICHIARAZIONI>
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
    <Find OrderBy="ORDER BY ID_DICHIARAZIONE">
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <MISURA>Like</MISURA>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CATALOGO_DICHIARAZIONI>
*/