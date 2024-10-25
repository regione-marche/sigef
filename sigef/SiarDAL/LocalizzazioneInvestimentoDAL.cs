using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for LocalizzazioneInvestimentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class LocalizzazioneInvestimentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, LocalizzazioneInvestimento LocalizzazioneInvestimentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdLocalizzazione", LocalizzazioneInvestimentoObj.IdLocalizzazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimento", LocalizzazioneInvestimentoObj.IdInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCatasto", LocalizzazioneInvestimentoObj.IdCatasto);
		}
		//Insert
		private static int Insert(DbProvider db, LocalizzazioneInvestimento LocalizzazioneInvestimentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZLocalizzazioneInvestimentoInsert", new string[] {"IdInvestimento", "IdCatasto", 

}, new string[] {"int", "int", 

},"");
				CompileIUCmd(false, insertCmd,LocalizzazioneInvestimentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				LocalizzazioneInvestimentoObj.IdLocalizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE"]);
				}
				LocalizzazioneInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneInvestimentoObj.IsDirty = false;
				LocalizzazioneInvestimentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, LocalizzazioneInvestimento LocalizzazioneInvestimentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZLocalizzazioneInvestimentoUpdate", new string[] {"IdLocalizzazione", "IdInvestimento", "IdCatasto", 

}, new string[] {"int", "int", "int", 

},"");
				CompileIUCmd(true, updateCmd,LocalizzazioneInvestimentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				LocalizzazioneInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneInvestimentoObj.IsDirty = false;
				LocalizzazioneInvestimentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, LocalizzazioneInvestimento LocalizzazioneInvestimentoObj)
		{
			switch (LocalizzazioneInvestimentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, LocalizzazioneInvestimentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, LocalizzazioneInvestimentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,LocalizzazioneInvestimentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, LocalizzazioneInvestimentoCollection LocalizzazioneInvestimentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZLocalizzazioneInvestimentoUpdate", new string[] {"IdLocalizzazione", "IdInvestimento", "IdCatasto", 

}, new string[] {"int", "int", "int", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZLocalizzazioneInvestimentoInsert", new string[] {"IdInvestimento", "IdCatasto", 

}, new string[] {"int", "int", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZLocalizzazioneInvestimentoDelete", new string[] {"IdLocalizzazione"}, new string[] {"int"},"");
				for (int i = 0; i < LocalizzazioneInvestimentoCollectionObj.Count; i++)
				{
					switch (LocalizzazioneInvestimentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,LocalizzazioneInvestimentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									LocalizzazioneInvestimentoCollectionObj[i].IdLocalizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,LocalizzazioneInvestimentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (LocalizzazioneInvestimentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLocalizzazione", (SiarLibrary.NullTypes.IntNT)LocalizzazioneInvestimentoCollectionObj[i].IdLocalizzazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < LocalizzazioneInvestimentoCollectionObj.Count; i++)
				{
					if ((LocalizzazioneInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LocalizzazioneInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LocalizzazioneInvestimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						LocalizzazioneInvestimentoCollectionObj[i].IsDirty = false;
						LocalizzazioneInvestimentoCollectionObj[i].IsPersistent = true;
					}
					if ((LocalizzazioneInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						LocalizzazioneInvestimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LocalizzazioneInvestimentoCollectionObj[i].IsDirty = false;
						LocalizzazioneInvestimentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, LocalizzazioneInvestimento LocalizzazioneInvestimentoObj)
		{
			int returnValue = 0;
			if (LocalizzazioneInvestimentoObj.IsPersistent) 
			{
				returnValue = Delete(db, LocalizzazioneInvestimentoObj.IdLocalizzazione);
			}
			LocalizzazioneInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			LocalizzazioneInvestimentoObj.IsDirty = false;
			LocalizzazioneInvestimentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLocalizzazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZLocalizzazioneInvestimentoDelete", new string[] {"IdLocalizzazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLocalizzazione", (SiarLibrary.NullTypes.IntNT)IdLocalizzazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, LocalizzazioneInvestimentoCollection LocalizzazioneInvestimentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZLocalizzazioneInvestimentoDelete", new string[] {"IdLocalizzazione"}, new string[] {"int"},"");
				for (int i = 0; i < LocalizzazioneInvestimentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLocalizzazione", LocalizzazioneInvestimentoCollectionObj[i].IdLocalizzazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < LocalizzazioneInvestimentoCollectionObj.Count; i++)
				{
					if ((LocalizzazioneInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LocalizzazioneInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LocalizzazioneInvestimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LocalizzazioneInvestimentoCollectionObj[i].IsDirty = false;
						LocalizzazioneInvestimentoCollectionObj[i].IsPersistent = false;
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
		public static LocalizzazioneInvestimento GetById(DbProvider db, int IdLocalizzazioneValue)
		{
			LocalizzazioneInvestimento LocalizzazioneInvestimentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZLocalizzazioneInvestimentoGetById", new string[] {"IdLocalizzazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdLocalizzazione", (SiarLibrary.NullTypes.IntNT)IdLocalizzazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				LocalizzazioneInvestimentoObj = GetFromDatareader(db);
				LocalizzazioneInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneInvestimentoObj.IsDirty = false;
				LocalizzazioneInvestimentoObj.IsPersistent = true;
			}
			db.Close();
			return LocalizzazioneInvestimentoObj;
		}

		//getFromDatareader
		public static LocalizzazioneInvestimento GetFromDatareader(DbProvider db)
		{
			LocalizzazioneInvestimento LocalizzazioneInvestimentoObj = new LocalizzazioneInvestimento();
			LocalizzazioneInvestimentoObj.IdLocalizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOCALIZZAZIONE"]);
			LocalizzazioneInvestimentoObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
			LocalizzazioneInvestimentoObj.IdCatasto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CATASTO"]);
			LocalizzazioneInvestimentoObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			LocalizzazioneInvestimentoObj.FoglioCatastale = new SiarLibrary.NullTypes.StringNT(db.DataReader["FOGLIO_CATASTALE"]);
			LocalizzazioneInvestimentoObj.Particella = new SiarLibrary.NullTypes.StringNT(db.DataReader["PARTICELLA"]);
			LocalizzazioneInvestimentoObj.Sezione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEZIONE"]);
			LocalizzazioneInvestimentoObj.Subalterno = new SiarLibrary.NullTypes.StringNT(db.DataReader["SUBALTERNO"]);
			LocalizzazioneInvestimentoObj.SuperficieCatastale = new SiarLibrary.NullTypes.IntNT(db.DataReader["SUPERFICIE_CATASTALE"]);
			LocalizzazioneInvestimentoObj.Svantaggio = new SiarLibrary.NullTypes.StringNT(db.DataReader["SVANTAGGIO"]);
			LocalizzazioneInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			LocalizzazioneInvestimentoObj.IsDirty = false;
			LocalizzazioneInvestimentoObj.IsPersistent = true;
			return LocalizzazioneInvestimentoObj;
		}

		//Find Select

		public static LocalizzazioneInvestimentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLocalizzazioneEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdCatastoEqualThis)

		{

			LocalizzazioneInvestimentoCollection LocalizzazioneInvestimentoCollectionObj = new LocalizzazioneInvestimentoCollection();

			IDbCommand findCmd = db.InitCmd("Zlocalizzazioneinvestimentofindselect", new string[] {"IdLocalizzazioneequalthis", "IdInvestimentoequalthis", "IdCatastoequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLocalizzazioneequalthis", IdLocalizzazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCatastoequalthis", IdCatastoEqualThis);
			LocalizzazioneInvestimento LocalizzazioneInvestimentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LocalizzazioneInvestimentoObj = GetFromDatareader(db);
				LocalizzazioneInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneInvestimentoObj.IsDirty = false;
				LocalizzazioneInvestimentoObj.IsPersistent = true;
				LocalizzazioneInvestimentoCollectionObj.Add(LocalizzazioneInvestimentoObj);
			}
			db.Close();
			return LocalizzazioneInvestimentoCollectionObj;
		}

		//Find Find

		public static LocalizzazioneInvestimentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLocalizzazioneEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdCatastoEqualThis, 
SiarLibrary.NullTypes.IntNT IdComuneEqualThis)

		{

			LocalizzazioneInvestimentoCollection LocalizzazioneInvestimentoCollectionObj = new LocalizzazioneInvestimentoCollection();

			IDbCommand findCmd = db.InitCmd("Zlocalizzazioneinvestimentofindfind", new string[] {"IdLocalizzazioneequalthis", "IdInvestimentoequalthis", "IdCatastoequalthis", 
"IdComuneequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLocalizzazioneequalthis", IdLocalizzazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCatastoequalthis", IdCatastoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			LocalizzazioneInvestimento LocalizzazioneInvestimentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LocalizzazioneInvestimentoObj = GetFromDatareader(db);
				LocalizzazioneInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LocalizzazioneInvestimentoObj.IsDirty = false;
				LocalizzazioneInvestimentoObj.IsPersistent = true;
				LocalizzazioneInvestimentoCollectionObj.Add(LocalizzazioneInvestimentoObj);
			}
			db.Close();
			return LocalizzazioneInvestimentoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<LOCALIZZAZIONE_INVESTIMENTO>
  <ViewName>vLOCALIZZAZIONE_INVESTIMENTO</ViewName>
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
      <ID_LOCALIZZAZIONE>Equal</ID_LOCALIZZAZIONE>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_CATASTO>Equal</ID_CATASTO>
      <ID_COMUNE>Equal</ID_COMUNE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOCALIZZAZIONE_INVESTIMENTO>
*/