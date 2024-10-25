using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IterProgettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class IterProgettoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, IterProgetto IterProgettoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", IterProgettoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdStep", IterProgettoObj.IdStep);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsito", IterProgettoObj.CodEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", IterProgettoObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatore", IterProgettoObj.CfOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", IterProgettoObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsitoRevisore", IterProgettoObj.CodEsitoRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRevisore", IterProgettoObj.DataRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "Revisore", IterProgettoObj.Revisore);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteRevisore", IterProgettoObj.NoteRevisore);
		}
		//Insert
		private static int Insert(DbProvider db, IterProgetto IterProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZIterProgettoInsert", new string[] {"IdProgetto", "IdStep", "CodEsito", 
"Data", "CfOperatore", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", 




}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", 




},"");
				CompileIUCmd(false, insertCmd,IterProgettoObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				IterProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoObj.IsDirty = false;
				IterProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, IterProgetto IterProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIterProgettoUpdate", new string[] {"IdProgetto", "IdStep", "CodEsito", 
"Data", "CfOperatore", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", 




}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", 




},"");
				CompileIUCmd(true, updateCmd,IterProgettoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				IterProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoObj.IsDirty = false;
				IterProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, IterProgetto IterProgettoObj)
		{
			switch (IterProgettoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, IterProgettoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, IterProgettoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,IterProgettoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IterProgettoCollection IterProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIterProgettoUpdate", new string[] {"IdProgetto", "IdStep", "CodEsito", 
"Data", "CfOperatore", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", 




}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", 




},"");
				IDbCommand insertCmd = db.InitCmd( "ZIterProgettoInsert", new string[] {"IdProgetto", "IdStep", "CodEsito", 
"Data", "CfOperatore", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", 




}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", 




},"");
				IDbCommand deleteCmd = db.InitCmd( "ZIterProgettoDelete", new string[] {"IdProgetto", "IdStep"}, new string[] {"int", "int"},"");
				for (int i = 0; i < IterProgettoCollectionObj.Count; i++)
				{
					switch (IterProgettoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,IterProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,IterProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (IterProgettoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IterProgettoCollectionObj[i].IdProgetto);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)IterProgettoCollectionObj[i].IdStep);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IterProgettoCollectionObj.Count; i++)
				{
					if ((IterProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IterProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IterProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IterProgettoCollectionObj[i].IsDirty = false;
						IterProgettoCollectionObj[i].IsPersistent = true;
					}
					if ((IterProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IterProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IterProgettoCollectionObj[i].IsDirty = false;
						IterProgettoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, IterProgetto IterProgettoObj)
		{
			int returnValue = 0;
			if (IterProgettoObj.IsPersistent) 
			{
				returnValue = Delete(db, IterProgettoObj.IdProgetto, IterProgettoObj.IdStep);
			}
			IterProgettoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IterProgettoObj.IsDirty = false;
			IterProgettoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoValue, int IdStepValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIterProgettoDelete", new string[] {"IdProgetto", "IdStep"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)IdStepValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IterProgettoCollection IterProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIterProgettoDelete", new string[] {"IdProgetto", "IdStep"}, new string[] {"int", "int"},"");
				for (int i = 0; i < IterProgettoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", IterProgettoCollectionObj[i].IdProgetto);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", IterProgettoCollectionObj[i].IdStep);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IterProgettoCollectionObj.Count; i++)
				{
					if ((IterProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IterProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IterProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IterProgettoCollectionObj[i].IsDirty = false;
						IterProgettoCollectionObj[i].IsPersistent = false;
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
		public static IterProgetto GetById(DbProvider db, int IdProgettoValue, int IdStepValue)
		{
			IterProgetto IterProgettoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZIterProgettoGetById", new string[] {"IdProgetto", "IdStep"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)IdStepValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IterProgettoObj = GetFromDatareader(db);
				IterProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoObj.IsDirty = false;
				IterProgettoObj.IsPersistent = true;
			}
			db.Close();
			return IterProgettoObj;
		}

		//getFromDatareader
		public static IterProgetto GetFromDatareader(DbProvider db)
		{
			IterProgetto IterProgettoObj = new IterProgetto();
			IterProgettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			IterProgettoObj.IdStep = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STEP"]);
			IterProgettoObj.CodEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO"]);
			IterProgettoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			IterProgettoObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			IterProgettoObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			IterProgettoObj.CodEsitoRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO_REVISORE"]);
			IterProgettoObj.DataRevisore = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_REVISORE"]);
			IterProgettoObj.Revisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["REVISORE"]);
			IterProgettoObj.NoteRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_REVISORE"]);
			IterProgettoObj.EsitoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO_ISTRUTTORE"]);
			IterProgettoObj.EsitoPositivoIstruttore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO_ISTRUTTORE"]);
			IterProgettoObj.EsitoRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO_REVISORE"]);
			IterProgettoObj.EsitoPositivoRevisore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO_REVISORE"]);
			IterProgettoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			IterProgettoObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
			IterProgettoObj.IdCheckList = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECK_LIST"]);
			IterProgettoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			IterProgettoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			IterProgettoObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			IterProgettoObj.Step = new SiarLibrary.NullTypes.StringNT(db.DataReader["STEP"]);
			IterProgettoObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			IterProgettoObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			IterProgettoObj.QuerySqlPost = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST"]);
			IterProgettoObj.CodeMethod = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD"]);
			IterProgettoObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			IterProgettoObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
			IterProgettoObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
			IterProgettoObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			IterProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IterProgettoObj.IsDirty = false;
			IterProgettoObj.IsPersistent = true;
			return IterProgettoObj;
		}

		//Find Select

		public static IterProgettoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdStepEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoRevisoreEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRevisoreEqualThis, SiarLibrary.NullTypes.StringNT RevisoreEqualThis)

		{

			IterProgettoCollection IterProgettoCollectionObj = new IterProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Ziterprogettofindselect", new string[] {"IdProgettoequalthis", "IdStepequalthis", "CodEsitoequalthis", 
"Dataequalthis", "CfOperatoreequalthis", "CodEsitoRevisoreequalthis", 
"DataRevisoreequalthis", "Revisoreequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStepequalthis", IdStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoRevisoreequalthis", CodEsitoRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRevisoreequalthis", DataRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Revisoreequalthis", RevisoreEqualThis);
			IterProgetto IterProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IterProgettoObj = GetFromDatareader(db);
				IterProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoObj.IsDirty = false;
				IterProgettoObj.IsPersistent = true;
				IterProgettoCollectionObj.Add(IterProgettoObj);
			}
			db.Close();
			return IterProgettoCollectionObj;
		}

		//Find Find

		public static IterProgettoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdStepEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoEqualThis, 
SiarLibrary.NullTypes.StringNT CodEsitoRevisoreEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, 
SiarLibrary.NullTypes.IntNT IdCheckListEqualThis)

		{

			IterProgettoCollection IterProgettoCollectionObj = new IterProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Ziterprogettofindfind", new string[] {"IdProgettoequalthis", "IdStepequalthis", "CodEsitoequalthis", 
"CodEsitoRevisoreequalthis", "IdBandoequalthis", "CodFaseequalthis", 
"IdCheckListequalthis"}, new string[] {"int", "int", "string", 
"string", "int", "string", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStepequalthis", IdStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoRevisoreequalthis", CodEsitoRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCheckListequalthis", IdCheckListEqualThis);
			IterProgetto IterProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IterProgettoObj = GetFromDatareader(db);
				IterProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoObj.IsDirty = false;
				IterProgettoObj.IsPersistent = true;
				IterProgettoCollectionObj.Add(IterProgettoObj);
			}
			db.Close();
			return IterProgettoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ITER_PROGETTO>
  <ViewName>vITER_PROGETTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_STEP>Equal</ID_STEP>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
      <ID_BANDO>Equal</ID_BANDO>
      <COD_FASE>Equal</COD_FASE>
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
    </Find>
  </Finds>
  <Filters>
    <FiltroEsito>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
    </FiltroEsito>
    <FiltroEsitoPositivo>
      <ESITO_POSITIVO_ISTRUTTORE>Equal</ESITO_POSITIVO_ISTRUTTORE>
      <ESITO_POSITIVO_REVISORE>Equal</ESITO_POSITIVO_REVISORE>
    </FiltroEsitoPositivo>
    <FiltroNonInRevisione>
      <COD_ESITO_REVISORE>IsNull</COD_ESITO_REVISORE>
    </FiltroNonInRevisione>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ITER_PROGETTO>
*/