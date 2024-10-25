using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PartecipantiXFilieraDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class PartecipantiXFilieraDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PartecipantiXFiliera PartecipantiXFilieraObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPartecipante", PartecipantiXFilieraObj.IdPartecipante);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodFiliera", PartecipantiXFilieraObj.CodFiliera);
			DbProvider.SetCmdParam(cmd,firstChar + "Cuaa", PartecipantiXFilieraObj.Cuaa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoValidato", PartecipantiXFilieraObj.IdProgettoValidato);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRuoloSitra", PartecipantiXFilieraObj.CodRuoloSitra);
			DbProvider.SetCmdParam(cmd,firstChar + "Ammesso", PartecipantiXFilieraObj.Ammesso);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValidazione", PartecipantiXFilieraObj.DataValidazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatore", PartecipantiXFilieraObj.CfOperatore);
		}
		//Insert
		private static int Insert(DbProvider db, PartecipantiXFiliera PartecipantiXFilieraObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPartecipantiXFilieraInsert", new string[] {"CodFiliera", "Cuaa", 
"IdProgettoValidato", "CodRuoloSitra", "Ammesso", 
"DataValidazione", "CfOperatore"}, new string[] {"string", "string", 
"int", "string", "bool", 
"DateTime", "string"},"");
				CompileIUCmd(false, insertCmd,PartecipantiXFilieraObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PartecipantiXFilieraObj.IdPartecipante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARTECIPANTE"]);
				}
				PartecipantiXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiXFilieraObj.IsDirty = false;
				PartecipantiXFilieraObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PartecipantiXFiliera PartecipantiXFilieraObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPartecipantiXFilieraUpdate", new string[] {"IdPartecipante", "CodFiliera", "Cuaa", 
"IdProgettoValidato", "CodRuoloSitra", "Ammesso", 
"DataValidazione", "CfOperatore"}, new string[] {"int", "string", "string", 
"int", "string", "bool", 
"DateTime", "string"},"");
				CompileIUCmd(true, updateCmd,PartecipantiXFilieraObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PartecipantiXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiXFilieraObj.IsDirty = false;
				PartecipantiXFilieraObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PartecipantiXFiliera PartecipantiXFilieraObj)
		{
			switch (PartecipantiXFilieraObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PartecipantiXFilieraObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PartecipantiXFilieraObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PartecipantiXFilieraObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PartecipantiXFilieraCollection PartecipantiXFilieraCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPartecipantiXFilieraUpdate", new string[] {"IdPartecipante", "CodFiliera", "Cuaa", 
"IdProgettoValidato", "CodRuoloSitra", "Ammesso", 
"DataValidazione", "CfOperatore"}, new string[] {"int", "string", "string", 
"int", "string", "bool", 
"DateTime", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPartecipantiXFilieraInsert", new string[] {"CodFiliera", "Cuaa", 
"IdProgettoValidato", "CodRuoloSitra", "Ammesso", 
"DataValidazione", "CfOperatore"}, new string[] {"string", "string", 
"int", "string", "bool", 
"DateTime", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipantiXFilieraDelete", new string[] {"IdPartecipante"}, new string[] {"int"},"");
				for (int i = 0; i < PartecipantiXFilieraCollectionObj.Count; i++)
				{
					switch (PartecipantiXFilieraCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PartecipantiXFilieraCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PartecipantiXFilieraCollectionObj[i].IdPartecipante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARTECIPANTE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PartecipantiXFilieraCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PartecipantiXFilieraCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPartecipante", (SiarLibrary.NullTypes.IntNT)PartecipantiXFilieraCollectionObj[i].IdPartecipante);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PartecipantiXFilieraCollectionObj.Count; i++)
				{
					if ((PartecipantiXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PartecipantiXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PartecipantiXFilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PartecipantiXFilieraCollectionObj[i].IsDirty = false;
						PartecipantiXFilieraCollectionObj[i].IsPersistent = true;
					}
					if ((PartecipantiXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PartecipantiXFilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PartecipantiXFilieraCollectionObj[i].IsDirty = false;
						PartecipantiXFilieraCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PartecipantiXFiliera PartecipantiXFilieraObj)
		{
			int returnValue = 0;
			if (PartecipantiXFilieraObj.IsPersistent) 
			{
				returnValue = Delete(db, PartecipantiXFilieraObj.IdPartecipante);
			}
			PartecipantiXFilieraObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PartecipantiXFilieraObj.IsDirty = false;
			PartecipantiXFilieraObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPartecipanteValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipantiXFilieraDelete", new string[] {"IdPartecipante"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPartecipante", (SiarLibrary.NullTypes.IntNT)IdPartecipanteValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PartecipantiXFilieraCollection PartecipantiXFilieraCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipantiXFilieraDelete", new string[] {"IdPartecipante"}, new string[] {"int"},"");
				for (int i = 0; i < PartecipantiXFilieraCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPartecipante", PartecipantiXFilieraCollectionObj[i].IdPartecipante);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PartecipantiXFilieraCollectionObj.Count; i++)
				{
					if ((PartecipantiXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PartecipantiXFilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PartecipantiXFilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PartecipantiXFilieraCollectionObj[i].IsDirty = false;
						PartecipantiXFilieraCollectionObj[i].IsPersistent = false;
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
		public static PartecipantiXFiliera GetById(DbProvider db, int IdPartecipanteValue)
		{
			PartecipantiXFiliera PartecipantiXFilieraObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPartecipantiXFilieraGetById", new string[] {"IdPartecipante"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPartecipante", (SiarLibrary.NullTypes.IntNT)IdPartecipanteValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PartecipantiXFilieraObj = GetFromDatareader(db);
				PartecipantiXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiXFilieraObj.IsDirty = false;
				PartecipantiXFilieraObj.IsPersistent = true;
			}
			db.Close();
			return PartecipantiXFilieraObj;
		}

		//getFromDatareader
		public static PartecipantiXFiliera GetFromDatareader(DbProvider db)
		{
			PartecipantiXFiliera PartecipantiXFilieraObj = new PartecipantiXFiliera();
			PartecipantiXFilieraObj.IdPartecipante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARTECIPANTE"]);
			PartecipantiXFilieraObj.CodFiliera = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FILIERA"]);
			PartecipantiXFilieraObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			PartecipantiXFilieraObj.IdProgettoValidato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_VALIDATO"]);
			PartecipantiXFilieraObj.CodRuoloSitra = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUOLO_SITRA"]);
			PartecipantiXFilieraObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
			PartecipantiXFilieraObj.DataValidazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALIDAZIONE"]);
			PartecipantiXFilieraObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			PartecipantiXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PartecipantiXFilieraObj.IsDirty = false;
			PartecipantiXFilieraObj.IsPersistent = true;
			return PartecipantiXFilieraObj;
		}

		//Find Select

		public static PartecipantiXFilieraCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPartecipanteEqualThis, SiarLibrary.NullTypes.StringNT CodFilieraEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoValidatoEqualThis, SiarLibrary.NullTypes.StringNT CodRuoloSitraEqualThis, SiarLibrary.NullTypes.BoolNT AmmessoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataValidazioneEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis)

		{

			PartecipantiXFilieraCollection PartecipantiXFilieraCollectionObj = new PartecipantiXFilieraCollection();

			IDbCommand findCmd = db.InitCmd("Zpartecipantixfilierafindselect", new string[] {"IdPartecipanteequalthis", "CodFilieraequalthis", "Cuaaequalthis", 
"IdProgettoValidatoequalthis", "CodRuoloSitraequalthis", "Ammessoequalthis", 
"DataValidazioneequalthis", "CfOperatoreequalthis"}, new string[] {"int", "string", "string", 
"int", "string", "bool", 
"DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPartecipanteequalthis", IdPartecipanteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFilieraequalthis", CodFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoValidatoequalthis", IdProgettoValidatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRuoloSitraequalthis", CodRuoloSitraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValidazioneequalthis", DataValidazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			PartecipantiXFiliera PartecipantiXFilieraObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PartecipantiXFilieraObj = GetFromDatareader(db);
				PartecipantiXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiXFilieraObj.IsDirty = false;
				PartecipantiXFilieraObj.IsPersistent = true;
				PartecipantiXFilieraCollectionObj.Add(PartecipantiXFilieraObj);
			}
			db.Close();
			return PartecipantiXFilieraCollectionObj;
		}

		//Find Find

		public static PartecipantiXFilieraCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPartecipanteEqualThis, SiarLibrary.NullTypes.StringNT CodFilieraEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoValidatoEqualThis)

		{

			PartecipantiXFilieraCollection PartecipantiXFilieraCollectionObj = new PartecipantiXFilieraCollection();

			IDbCommand findCmd = db.InitCmd("Zpartecipantixfilierafindfind", new string[] {"IdPartecipanteequalthis", "CodFilieraequalthis", "Cuaaequalthis", 
"IdProgettoValidatoequalthis"}, new string[] {"int", "string", "string", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPartecipanteequalthis", IdPartecipanteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFilieraequalthis", CodFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoValidatoequalthis", IdProgettoValidatoEqualThis);
			PartecipantiXFiliera PartecipantiXFilieraObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PartecipantiXFilieraObj = GetFromDatareader(db);
				PartecipantiXFilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiXFilieraObj.IsDirty = false;
				PartecipantiXFilieraObj.IsPersistent = true;
				PartecipantiXFilieraCollectionObj.Add(PartecipantiXFilieraObj);
			}
			db.Close();
			return PartecipantiXFilieraCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTI_X_FILIERA>
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
      <ID_PARTECIPANTE>Equal</ID_PARTECIPANTE>
      <COD_FILIERA>Equal</COD_FILIERA>
      <CUAA>Equal</CUAA>
      <ID_PROGETTO_VALIDATO>Equal</ID_PROGETTO_VALIDATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PARTECIPANTI_X_FILIERA>
*/