using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PrioritaSpecialeDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class PrioritaSpecialeDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PrioritaSpeciale PrioritaSpecialeObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdSchedaValutazione", PrioritaSpecialeObj.IdSchedaValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", PrioritaSpecialeObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPrioritaSelezionata", PrioritaSpecialeObj.IdPrioritaSelezionata);
			DbProvider.SetCmdParam(cmd,firstChar + "IsMax", PrioritaSpecialeObj.IsMax);
		}
		//Insert
		private static int Insert(DbProvider db, PrioritaSpeciale PrioritaSpecialeObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaSpecialeInsert", new string[] {"IdSchedaValutazione", "IdPriorita", "IdPrioritaSelezionata", 
"IsMax"}, new string[] {"int", "int", "int", 
"bool"},"");
				CompileIUCmd(false, insertCmd,PrioritaSpecialeObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				PrioritaSpecialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSpecialeObj.IsDirty = false;
				PrioritaSpecialeObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PrioritaSpeciale PrioritaSpecialeObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaSpecialeUpdate", new string[] {"IdSchedaValutazione", "IdPriorita", "IdPrioritaSelezionata", 
"IsMax"}, new string[] {"int", "int", "int", 
"bool"},"");
				CompileIUCmd(true, updateCmd,PrioritaSpecialeObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PrioritaSpecialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSpecialeObj.IsDirty = false;
				PrioritaSpecialeObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PrioritaSpeciale PrioritaSpecialeObj)
		{
			switch (PrioritaSpecialeObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PrioritaSpecialeObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PrioritaSpecialeObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PrioritaSpecialeObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PrioritaSpecialeCollection PrioritaSpecialeCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaSpecialeUpdate", new string[] {"IdSchedaValutazione", "IdPriorita", "IdPrioritaSelezionata", 
"IsMax"}, new string[] {"int", "int", "int", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaSpecialeInsert", new string[] {"IdSchedaValutazione", "IdPriorita", "IdPrioritaSelezionata", 
"IsMax"}, new string[] {"int", "int", "int", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaSpecialeDelete", new string[] {"IdSchedaValutazione", "IdPriorita", "IdPrioritaSelezionata"}, new string[] {"int", "int", "int"},"");
				for (int i = 0; i < PrioritaSpecialeCollectionObj.Count; i++)
				{
					switch (PrioritaSpecialeCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PrioritaSpecialeCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PrioritaSpecialeCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PrioritaSpecialeCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)PrioritaSpecialeCollectionObj[i].IdSchedaValutazione);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)PrioritaSpecialeCollectionObj[i].IdPriorita);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrioritaSelezionata", (SiarLibrary.NullTypes.IntNT)PrioritaSpecialeCollectionObj[i].IdPrioritaSelezionata);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PrioritaSpecialeCollectionObj.Count; i++)
				{
					if ((PrioritaSpecialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaSpecialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaSpecialeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PrioritaSpecialeCollectionObj[i].IsDirty = false;
						PrioritaSpecialeCollectionObj[i].IsPersistent = true;
					}
					if ((PrioritaSpecialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PrioritaSpecialeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaSpecialeCollectionObj[i].IsDirty = false;
						PrioritaSpecialeCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PrioritaSpeciale PrioritaSpecialeObj)
		{
			int returnValue = 0;
			if (PrioritaSpecialeObj.IsPersistent) 
			{
				returnValue = Delete(db, PrioritaSpecialeObj.IdSchedaValutazione, PrioritaSpecialeObj.IdPriorita, PrioritaSpecialeObj.IdPrioritaSelezionata);
			}
			PrioritaSpecialeObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PrioritaSpecialeObj.IsDirty = false;
			PrioritaSpecialeObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSchedaValutazioneValue, int IdPrioritaValue, int IdPrioritaSelezionataValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaSpecialeDelete", new string[] {"IdSchedaValutazione", "IdPriorita", "IdPrioritaSelezionata"}, new string[] {"int", "int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)IdSchedaValutazioneValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrioritaSelezionata", (SiarLibrary.NullTypes.IntNT)IdPrioritaSelezionataValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PrioritaSpecialeCollection PrioritaSpecialeCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaSpecialeDelete", new string[] {"IdSchedaValutazione", "IdPriorita", "IdPrioritaSelezionata"}, new string[] {"int", "int", "int"},"");
				for (int i = 0; i < PrioritaSpecialeCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", PrioritaSpecialeCollectionObj[i].IdSchedaValutazione);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", PrioritaSpecialeCollectionObj[i].IdPriorita);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrioritaSelezionata", PrioritaSpecialeCollectionObj[i].IdPrioritaSelezionata);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PrioritaSpecialeCollectionObj.Count; i++)
				{
					if ((PrioritaSpecialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaSpecialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaSpecialeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaSpecialeCollectionObj[i].IsDirty = false;
						PrioritaSpecialeCollectionObj[i].IsPersistent = false;
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
		public static PrioritaSpeciale GetById(DbProvider db, int IdSchedaValutazioneValue, int IdPrioritaValue, int IdPrioritaSelezionataValue)
		{
			PrioritaSpeciale PrioritaSpecialeObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPrioritaSpecialeGetById", new string[] {"IdSchedaValutazione", "IdPriorita", "IdPrioritaSelezionata"}, new string[] {"int", "int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)IdSchedaValutazioneValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPrioritaSelezionata", (SiarLibrary.NullTypes.IntNT)IdPrioritaSelezionataValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PrioritaSpecialeObj = GetFromDatareader(db);
				PrioritaSpecialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSpecialeObj.IsDirty = false;
				PrioritaSpecialeObj.IsPersistent = true;
			}
			db.Close();
			return PrioritaSpecialeObj;
		}

		//getFromDatareader
		public static PrioritaSpeciale GetFromDatareader(DbProvider db)
		{
			PrioritaSpeciale PrioritaSpecialeObj = new PrioritaSpeciale();
			PrioritaSpecialeObj.IdSchedaValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_VALUTAZIONE"]);
			PrioritaSpecialeObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			PrioritaSpecialeObj.IdPrioritaSelezionata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SELEZIONATA"]);
			PrioritaSpecialeObj.IsMax = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IS_MAX"]);
			PrioritaSpecialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PrioritaSpecialeObj.IsDirty = false;
			PrioritaSpecialeObj.IsPersistent = true;
			return PrioritaSpecialeObj;
		}

		//Find Select

		public static PrioritaSpecialeCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaSelezionataEqualThis, 
SiarLibrary.NullTypes.BoolNT IsMaxEqualThis)

		{

			PrioritaSpecialeCollection PrioritaSpecialeCollectionObj = new PrioritaSpecialeCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaspecialefindselect", new string[] {"IdSchedaValutazioneequalthis", "IdPrioritaequalthis", "IdPrioritaSelezionataequalthis", 
"IsMaxequalthis"}, new string[] {"int", "int", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSchedaValutazioneequalthis", IdSchedaValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaSelezionataequalthis", IdPrioritaSelezionataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IsMaxequalthis", IsMaxEqualThis);
			PrioritaSpeciale PrioritaSpecialeObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaSpecialeObj = GetFromDatareader(db);
				PrioritaSpecialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSpecialeObj.IsDirty = false;
				PrioritaSpecialeObj.IsPersistent = true;
				PrioritaSpecialeCollectionObj.Add(PrioritaSpecialeObj);
			}
			db.Close();
			return PrioritaSpecialeCollectionObj;
		}

		//Find Find

		public static PrioritaSpecialeCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaSelezionataEqualThis)

		{

			PrioritaSpecialeCollection PrioritaSpecialeCollectionObj = new PrioritaSpecialeCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaspecialefindfind", new string[] {"IdSchedaValutazioneequalthis", "IdPrioritaequalthis", "IdPrioritaSelezionataequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSchedaValutazioneequalthis", IdSchedaValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaSelezionataequalthis", IdPrioritaSelezionataEqualThis);
			PrioritaSpeciale PrioritaSpecialeObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaSpecialeObj = GetFromDatareader(db);
				PrioritaSpecialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaSpecialeObj.IsDirty = false;
				PrioritaSpecialeObj.IsPersistent = true;
				PrioritaSpecialeCollectionObj.Add(PrioritaSpecialeObj);
			}
			db.Close();
			return PrioritaSpecialeCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_SPECIALE>
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
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <ID_PRIORITA_SELEZIONATA>Equal</ID_PRIORITA_SELEZIONATA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_SPECIALE>
*/