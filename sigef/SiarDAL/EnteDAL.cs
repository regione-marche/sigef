using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for EnteDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class EnteDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Ente EnteObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnte", EnteObj.CodEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoEnte", EnteObj.CodTipoEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", EnteObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodSian", EnteObj.CodSian);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", EnteObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, Ente EnteObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZEnteInsert", new string[] {"CodEnte", "CodTipoEnte", "Descrizione", 
"CodSian", "Attivo"}, new string[] {"string", "string", "string", 
"string", "bool"},"");
				CompileIUCmd(false, insertCmd,EnteObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				EnteObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				EnteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EnteObj.IsDirty = false;
				EnteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Ente EnteObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZEnteUpdate", new string[] {"CodEnte", "CodTipoEnte", "Descrizione", 
"CodSian", "Attivo"}, new string[] {"string", "string", "string", 
"string", "bool"},"");
				CompileIUCmd(true, updateCmd,EnteObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				EnteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EnteObj.IsDirty = false;
				EnteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Ente EnteObj)
		{
			switch (EnteObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, EnteObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, EnteObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,EnteObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, EnteCollection EnteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZEnteUpdate", new string[] {"CodEnte", "CodTipoEnte", "Descrizione", 
"CodSian", "Attivo"}, new string[] {"string", "string", "string", 
"string", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZEnteInsert", new string[] {"CodEnte", "CodTipoEnte", "Descrizione", 
"CodSian", "Attivo"}, new string[] {"string", "string", "string", 
"string", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZEnteDelete", new string[] {"CodEnte"}, new string[] {"string"},"");
				for (int i = 0; i < EnteCollectionObj.Count; i++)
				{
					switch (EnteCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,EnteCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									EnteCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,EnteCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (EnteCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodEnte", (SiarLibrary.NullTypes.StringNT)EnteCollectionObj[i].CodEnte);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < EnteCollectionObj.Count; i++)
				{
					if ((EnteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (EnteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						EnteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						EnteCollectionObj[i].IsDirty = false;
						EnteCollectionObj[i].IsPersistent = true;
					}
					if ((EnteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						EnteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						EnteCollectionObj[i].IsDirty = false;
						EnteCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Ente EnteObj)
		{
			int returnValue = 0;
			if (EnteObj.IsPersistent) 
			{
				returnValue = Delete(db, EnteObj.CodEnte);
			}
			EnteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			EnteObj.IsDirty = false;
			EnteObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodEnteValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZEnteDelete", new string[] {"CodEnte"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodEnte", (SiarLibrary.NullTypes.StringNT)CodEnteValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, EnteCollection EnteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZEnteDelete", new string[] {"CodEnte"}, new string[] {"string"},"");
				for (int i = 0; i < EnteCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodEnte", EnteCollectionObj[i].CodEnte);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < EnteCollectionObj.Count; i++)
				{
					if ((EnteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (EnteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						EnteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						EnteCollectionObj[i].IsDirty = false;
						EnteCollectionObj[i].IsPersistent = false;
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
		public static Ente GetById(DbProvider db, string CodEnteValue)
		{
			Ente EnteObj = null;
			IDbCommand readCmd = db.InitCmd( "ZEnteGetById", new string[] {"CodEnte"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodEnte", (SiarLibrary.NullTypes.StringNT)CodEnteValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				EnteObj = GetFromDatareader(db);
				EnteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EnteObj.IsDirty = false;
				EnteObj.IsPersistent = true;
			}
			db.Close();
			return EnteObj;
		}

		//getFromDatareader
		public static Ente GetFromDatareader(DbProvider db)
		{
			Ente EnteObj = new Ente();
			EnteObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			EnteObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			EnteObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			EnteObj.CodSian = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_SIAN"]);
			EnteObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			EnteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			EnteObj.IsDirty = false;
			EnteObj.IsPersistent = true;
			return EnteObj;
		}

		//Find Select

		public static EnteCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodSianEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			EnteCollection EnteCollectionObj = new EnteCollection();

			IDbCommand findCmd = db.InitCmd("Zentefindselect", new string[] {"CodEnteequalthis", "CodTipoEnteequalthis", "Descrizioneequalthis", 
"CodSianequalthis", "Attivoequalthis"}, new string[] {"string", "string", "string", 
"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodSianequalthis", CodSianEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			Ente EnteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				EnteObj = GetFromDatareader(db);
				EnteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EnteObj.IsDirty = false;
				EnteObj.IsPersistent = true;
				EnteCollectionObj.Add(EnteObj);
			}
			db.Close();
			return EnteCollectionObj;
		}

		//Find Find

		public static EnteCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			EnteCollection EnteCollectionObj = new EnteCollection();

			IDbCommand findCmd = db.InitCmd("Zentefindfind", new string[] {"CodEnteequalthis", "CodTipoEnteequalthis", "Attivoequalthis"}, new string[] {"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			Ente EnteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				EnteObj = GetFromDatareader(db);
				EnteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EnteObj.IsDirty = false;
				EnteObj.IsPersistent = true;
				EnteCollectionObj.Add(EnteObj);
			}
			db.Close();
			return EnteCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ENTE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY COD_TIPO_ENTE, ATTIVO DESC, COD_ENTE">
      <COD_ENTE>Equal</COD_ENTE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ENTE>
*/