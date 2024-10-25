using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RequisitiPagamentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class RequisitiPagamentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RequisitiPagamento RequisitiPagamentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRequisito", RequisitiPagamentoObj.IdRequisito);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", RequisitiPagamentoObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Plurivalore", RequisitiPagamentoObj.Plurivalore);
			DbProvider.SetCmdParam(cmd,firstChar + "Numerico", RequisitiPagamentoObj.Numerico);
			DbProvider.SetCmdParam(cmd,firstChar + "Datetime", RequisitiPagamentoObj.Datetime);
			DbProvider.SetCmdParam(cmd,firstChar + "TestoSemplice", RequisitiPagamentoObj.TestoSemplice);
			DbProvider.SetCmdParam(cmd,firstChar + "TestoArea", RequisitiPagamentoObj.TestoArea);
			DbProvider.SetCmdParam(cmd,firstChar + "Url", RequisitiPagamentoObj.Url);
			DbProvider.SetCmdParam(cmd,firstChar + "QueryEval", RequisitiPagamentoObj.QueryEval);
			DbProvider.SetCmdParam(cmd,firstChar + "QueryInsert", RequisitiPagamentoObj.QueryInsert);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", RequisitiPagamentoObj.Misura);
		}
		//Insert
		private static int Insert(DbProvider db, RequisitiPagamento RequisitiPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRequisitiPagamentoInsert", new string[] {"Descrizione", "Plurivalore", 
"Numerico", "Datetime", "TestoSemplice", 
"TestoArea", "Url", "QueryEval", 
"QueryInsert", "Misura"}, new string[] {"string", "bool", 
"bool", "bool", "bool", 
"bool", "string", "string", 
"string", "string"},"");
				CompileIUCmd(false, insertCmd,RequisitiPagamentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RequisitiPagamentoObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
				RequisitiPagamentoObj.Plurivalore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURIVALORE"]);
				RequisitiPagamentoObj.Numerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NUMERICO"]);
				RequisitiPagamentoObj.Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
				RequisitiPagamentoObj.TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
				RequisitiPagamentoObj.TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
				}
				RequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoObj.IsDirty = false;
				RequisitiPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RequisitiPagamento RequisitiPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRequisitiPagamentoUpdate", new string[] {"IdRequisito", "Descrizione", "Plurivalore", 
"Numerico", "Datetime", "TestoSemplice", 
"TestoArea", "Url", "QueryEval", 
"QueryInsert", "Misura"}, new string[] {"int", "string", "bool", 
"bool", "bool", "bool", 
"bool", "string", "string", 
"string", "string"},"");
				CompileIUCmd(true, updateCmd,RequisitiPagamentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoObj.IsDirty = false;
				RequisitiPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RequisitiPagamento RequisitiPagamentoObj)
		{
			switch (RequisitiPagamentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RequisitiPagamentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RequisitiPagamentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RequisitiPagamentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RequisitiPagamentoCollection RequisitiPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRequisitiPagamentoUpdate", new string[] {"IdRequisito", "Descrizione", "Plurivalore", 
"Numerico", "Datetime", "TestoSemplice", 
"TestoArea", "Url", "QueryEval", 
"QueryInsert", "Misura"}, new string[] {"int", "string", "bool", 
"bool", "bool", "bool", 
"bool", "string", "string", 
"string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRequisitiPagamentoInsert", new string[] {"Descrizione", "Plurivalore", 
"Numerico", "Datetime", "TestoSemplice", 
"TestoArea", "Url", "QueryEval", 
"QueryInsert", "Misura"}, new string[] {"string", "bool", 
"bool", "bool", "bool", 
"bool", "string", "string", 
"string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRequisitiPagamentoDelete", new string[] {"IdRequisito"}, new string[] {"int"},"");
				for (int i = 0; i < RequisitiPagamentoCollectionObj.Count; i++)
				{
					switch (RequisitiPagamentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RequisitiPagamentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RequisitiPagamentoCollectionObj[i].IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
									RequisitiPagamentoCollectionObj[i].Plurivalore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURIVALORE"]);
									RequisitiPagamentoCollectionObj[i].Numerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NUMERICO"]);
									RequisitiPagamentoCollectionObj[i].Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
									RequisitiPagamentoCollectionObj[i].TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
									RequisitiPagamentoCollectionObj[i].TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RequisitiPagamentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RequisitiPagamentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)RequisitiPagamentoCollectionObj[i].IdRequisito);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RequisitiPagamentoCollectionObj.Count; i++)
				{
					if ((RequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RequisitiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RequisitiPagamentoCollectionObj[i].IsDirty = false;
						RequisitiPagamentoCollectionObj[i].IsPersistent = true;
					}
					if ((RequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RequisitiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RequisitiPagamentoCollectionObj[i].IsDirty = false;
						RequisitiPagamentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RequisitiPagamento RequisitiPagamentoObj)
		{
			int returnValue = 0;
			if (RequisitiPagamentoObj.IsPersistent) 
			{
				returnValue = Delete(db, RequisitiPagamentoObj.IdRequisito);
			}
			RequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RequisitiPagamentoObj.IsDirty = false;
			RequisitiPagamentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRequisitoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRequisitiPagamentoDelete", new string[] {"IdRequisito"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RequisitiPagamentoCollection RequisitiPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRequisitiPagamentoDelete", new string[] {"IdRequisito"}, new string[] {"int"},"");
				for (int i = 0; i < RequisitiPagamentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", RequisitiPagamentoCollectionObj[i].IdRequisito);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RequisitiPagamentoCollectionObj.Count; i++)
				{
					if ((RequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RequisitiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RequisitiPagamentoCollectionObj[i].IsDirty = false;
						RequisitiPagamentoCollectionObj[i].IsPersistent = false;
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
		public static RequisitiPagamento GetById(DbProvider db, int IdRequisitoValue)
		{
			RequisitiPagamento RequisitiPagamentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRequisitiPagamentoGetById", new string[] {"IdRequisito"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RequisitiPagamentoObj = GetFromDatareader(db);
				RequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoObj.IsDirty = false;
				RequisitiPagamentoObj.IsPersistent = true;
			}
			db.Close();
			return RequisitiPagamentoObj;
		}

		//getFromDatareader
		public static RequisitiPagamento GetFromDatareader(DbProvider db)
		{
			RequisitiPagamento RequisitiPagamentoObj = new RequisitiPagamento();
			RequisitiPagamentoObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
			RequisitiPagamentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			RequisitiPagamentoObj.Plurivalore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURIVALORE"]);
			RequisitiPagamentoObj.Numerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NUMERICO"]);
			RequisitiPagamentoObj.Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
			RequisitiPagamentoObj.TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
			RequisitiPagamentoObj.TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
			RequisitiPagamentoObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			RequisitiPagamentoObj.QueryEval = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_EVAL"]);
			RequisitiPagamentoObj.QueryInsert = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_INSERT"]);
			RequisitiPagamentoObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			RequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RequisitiPagamentoObj.IsDirty = false;
			RequisitiPagamentoObj.IsPersistent = true;
			return RequisitiPagamentoObj;
		}

		//Find Select

		public static RequisitiPagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT PlurivaloreEqualThis, 
SiarLibrary.NullTypes.BoolNT NumericoEqualThis, SiarLibrary.NullTypes.BoolNT DatetimeEqualThis, SiarLibrary.NullTypes.BoolNT TestoSempliceEqualThis, 
SiarLibrary.NullTypes.BoolNT TestoAreaEqualThis, SiarLibrary.NullTypes.StringNT UrlEqualThis, SiarLibrary.NullTypes.StringNT QueryEvalEqualThis, 
SiarLibrary.NullTypes.StringNT QueryInsertEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis)

		{

			RequisitiPagamentoCollection RequisitiPagamentoCollectionObj = new RequisitiPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zrequisitipagamentofindselect", new string[] {"IdRequisitoequalthis", "Descrizioneequalthis", "Plurivaloreequalthis", 
"Numericoequalthis", "Datetimeequalthis", "TestoSempliceequalthis", 
"TestoAreaequalthis", "Urlequalthis", "QueryEvalequalthis", 
"QueryInsertequalthis", "Misuraequalthis"}, new string[] {"int", "string", "bool", 
"bool", "bool", "bool", 
"bool", "string", "string", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Plurivaloreequalthis", PlurivaloreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numericoequalthis", NumericoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datetimeequalthis", DatetimeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TestoSempliceequalthis", TestoSempliceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TestoAreaequalthis", TestoAreaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Urlequalthis", UrlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QueryEvalequalthis", QueryEvalEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QueryInsertequalthis", QueryInsertEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			RequisitiPagamento RequisitiPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RequisitiPagamentoObj = GetFromDatareader(db);
				RequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoObj.IsDirty = false;
				RequisitiPagamentoObj.IsPersistent = true;
				RequisitiPagamentoCollectionObj.Add(RequisitiPagamentoObj);
			}
			db.Close();
			return RequisitiPagamentoCollectionObj;
		}

		//Find Find

		public static RequisitiPagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.StringNT MisuraLikeThis)

		{

			RequisitiPagamentoCollection RequisitiPagamentoCollectionObj = new RequisitiPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zrequisitipagamentofindfind", new string[] {"IdRequisitoequalthis", "Misuralikethis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuralikethis", MisuraLikeThis);
			RequisitiPagamento RequisitiPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RequisitiPagamentoObj = GetFromDatareader(db);
				RequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoObj.IsDirty = false;
				RequisitiPagamentoObj.IsPersistent = true;
				RequisitiPagamentoCollectionObj.Add(RequisitiPagamentoObj);
			}
			db.Close();
			return RequisitiPagamentoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REQUISITI_PAGAMENTO>
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
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <MISURA>Like</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <PLURIVALORE>Equal</PLURIVALORE>
      <NUMERICO>Equal</NUMERICO>
      <DATETIME>Equal</DATETIME>
      <TESTO_SEMPLICE>Equal</TESTO_SEMPLICE>
      <TESTO_AREA>Equal</TESTO_AREA>
      <URL>IsNull</URL>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</REQUISITI_PAGAMENTO>
*/