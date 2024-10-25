using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VariantiXPrioritaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class VariantiXPrioritaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VariantiXPriorita VariantiXPrioritaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", VariantiXPrioritaObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", VariantiXPrioritaObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", VariantiXPrioritaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Punteggio", VariantiXPrioritaObj.Punteggio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", VariantiXPrioritaObj.DataValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", VariantiXPrioritaObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagDefinitivo", VariantiXPrioritaObj.FlagDefinitivo);
		}
		//Insert
		private static int Insert(DbProvider db, VariantiXPriorita VariantiXPrioritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZVariantiXPrioritaInsert", new string[] {"IdVariante", "IdPriorita", "IdProgetto", 
"Punteggio", "DataValutazione", "Operatore", 


"FlagDefinitivo"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 


"bool"},"");
				CompileIUCmd(false, insertCmd,VariantiXPrioritaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				VariantiXPrioritaObj.FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
				}
				VariantiXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiXPrioritaObj.IsDirty = false;
				VariantiXPrioritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VariantiXPriorita VariantiXPrioritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiXPrioritaUpdate", new string[] {"IdVariante", "IdPriorita", "IdProgetto", 
"Punteggio", "DataValutazione", "Operatore", 


"FlagDefinitivo"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 


"bool"},"");
				CompileIUCmd(true, updateCmd,VariantiXPrioritaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				VariantiXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiXPrioritaObj.IsDirty = false;
				VariantiXPrioritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VariantiXPriorita VariantiXPrioritaObj)
		{
			switch (VariantiXPrioritaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, VariantiXPrioritaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, VariantiXPrioritaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,VariantiXPrioritaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VariantiXPrioritaCollection VariantiXPrioritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiXPrioritaUpdate", new string[] {"IdVariante", "IdPriorita", "IdProgetto", 
"Punteggio", "DataValutazione", "Operatore", 


"FlagDefinitivo"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 


"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZVariantiXPrioritaInsert", new string[] {"IdVariante", "IdPriorita", "IdProgetto", 
"Punteggio", "DataValutazione", "Operatore", 


"FlagDefinitivo"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 


"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiXPrioritaDelete", new string[] {"IdVariante", "IdPriorita"}, new string[] {"int", "int"},"");
				for (int i = 0; i < VariantiXPrioritaCollectionObj.Count; i++)
				{
					switch (VariantiXPrioritaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,VariantiXPrioritaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VariantiXPrioritaCollectionObj[i].FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,VariantiXPrioritaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (VariantiXPrioritaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)VariantiXPrioritaCollectionObj[i].IdVariante);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)VariantiXPrioritaCollectionObj[i].IdPriorita);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VariantiXPrioritaCollectionObj.Count; i++)
				{
					if ((VariantiXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiXPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VariantiXPrioritaCollectionObj[i].IsDirty = false;
						VariantiXPrioritaCollectionObj[i].IsPersistent = true;
					}
					if ((VariantiXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VariantiXPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiXPrioritaCollectionObj[i].IsDirty = false;
						VariantiXPrioritaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VariantiXPriorita VariantiXPrioritaObj)
		{
			int returnValue = 0;
			if (VariantiXPrioritaObj.IsPersistent) 
			{
				returnValue = Delete(db, VariantiXPrioritaObj.IdVariante, VariantiXPrioritaObj.IdPriorita);
			}
			VariantiXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VariantiXPrioritaObj.IsDirty = false;
			VariantiXPrioritaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdVarianteValue, int IdPrioritaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiXPrioritaDelete", new string[] {"IdVariante", "IdPriorita"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)IdVarianteValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VariantiXPrioritaCollection VariantiXPrioritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiXPrioritaDelete", new string[] {"IdVariante", "IdPriorita"}, new string[] {"int", "int"},"");
				for (int i = 0; i < VariantiXPrioritaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", VariantiXPrioritaCollectionObj[i].IdVariante);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", VariantiXPrioritaCollectionObj[i].IdPriorita);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VariantiXPrioritaCollectionObj.Count; i++)
				{
					if ((VariantiXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiXPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiXPrioritaCollectionObj[i].IsDirty = false;
						VariantiXPrioritaCollectionObj[i].IsPersistent = false;
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
		public static VariantiXPriorita GetById(DbProvider db, int IdVarianteValue, int IdPrioritaValue)
		{
			VariantiXPriorita VariantiXPrioritaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZVariantiXPrioritaGetById", new string[] {"IdVariante", "IdPriorita"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)IdVarianteValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VariantiXPrioritaObj = GetFromDatareader(db);
				VariantiXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiXPrioritaObj.IsDirty = false;
				VariantiXPrioritaObj.IsPersistent = true;
			}
			db.Close();
			return VariantiXPrioritaObj;
		}

		//getFromDatareader
		public static VariantiXPriorita GetFromDatareader(DbProvider db)
		{
			VariantiXPriorita VariantiXPrioritaObj = new VariantiXPriorita();
			VariantiXPrioritaObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			VariantiXPrioritaObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			VariantiXPrioritaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VariantiXPrioritaObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
			VariantiXPrioritaObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			VariantiXPrioritaObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			VariantiXPrioritaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VariantiXPrioritaObj.CodLivello = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_LIVELLO"]);
			VariantiXPrioritaObj.PluriValore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE"]);
			VariantiXPrioritaObj.Eval = new SiarLibrary.NullTypes.StringNT(db.DataReader["EVAL"]);
			VariantiXPrioritaObj.FlagManuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_MANUALE"]);
			VariantiXPrioritaObj.InputNumerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INPUT_NUMERICO"]);
			VariantiXPrioritaObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			VariantiXPrioritaObj.FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
			VariantiXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VariantiXPrioritaObj.IsDirty = false;
			VariantiXPrioritaObj.IsPersistent = true;
			return VariantiXPrioritaObj;
		}

		//Find Select

		public static VariantiXPrioritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.DecimalNT PunteggioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT FlagDefinitivoEqualThis)

		{

			VariantiXPrioritaCollection VariantiXPrioritaCollectionObj = new VariantiXPrioritaCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantixprioritafindselect", new string[] {"IdVarianteequalthis", "IdPrioritaequalthis", "IdProgettoequalthis", 
"Punteggioequalthis", "DataValutazioneequalthis", "Operatoreequalthis", 
"FlagDefinitivoequalthis"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Punteggioequalthis", PunteggioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagDefinitivoequalthis", FlagDefinitivoEqualThis);
			VariantiXPriorita VariantiXPrioritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiXPrioritaObj = GetFromDatareader(db);
				VariantiXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiXPrioritaObj.IsDirty = false;
				VariantiXPrioritaObj.IsPersistent = true;
				VariantiXPrioritaCollectionObj.Add(VariantiXPrioritaObj);
			}
			db.Close();
			return VariantiXPrioritaCollectionObj;
		}

		//Find Find

		public static VariantiXPrioritaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis)

		{

			VariantiXPrioritaCollection VariantiXPrioritaCollectionObj = new VariantiXPrioritaCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantixprioritafindfind", new string[] {"IdVarianteequalthis", "IdPrioritaequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			VariantiXPriorita VariantiXPrioritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiXPrioritaObj = GetFromDatareader(db);
				VariantiXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiXPrioritaObj.IsDirty = false;
				VariantiXPrioritaObj.IsPersistent = true;
				VariantiXPrioritaCollectionObj.Add(VariantiXPrioritaObj);
			}
			db.Close();
			return VariantiXPrioritaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_X_PRIORITA>
  <ViewName>vVARIANTI_X_PRIORITA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
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
    <Find OrderBy="ORDER BY ">
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDefinitivo>
      <FLAG_DEFINITIVO>Equal</FLAG_DEFINITIVO>
    </FiltroDefinitivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_X_PRIORITA>
*/