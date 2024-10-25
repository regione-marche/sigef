using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RequisitiPagamentoPlurivaloreDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class RequisitiPagamentoPlurivaloreDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdValore", RequisitiPagamentoPlurivaloreObj.IdValore);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdRequisito", RequisitiPagamentoPlurivaloreObj.IdRequisito);
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", RequisitiPagamentoPlurivaloreObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", RequisitiPagamentoPlurivaloreObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRequisitiPagamentoPlurivaloreInsert", new string[] {"IdRequisito", "Codice", 
"Descrizione"}, new string[] {"int", "string", 
"string"},"");
				CompileIUCmd(false, insertCmd,RequisitiPagamentoPlurivaloreObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RequisitiPagamentoPlurivaloreObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
				}
				RequisitiPagamentoPlurivaloreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoPlurivaloreObj.IsDirty = false;
				RequisitiPagamentoPlurivaloreObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRequisitiPagamentoPlurivaloreUpdate", new string[] {"IdValore", "IdRequisito", "Codice", 
"Descrizione"}, new string[] {"int", "int", "string", 
"string"},"");
				CompileIUCmd(true, updateCmd,RequisitiPagamentoPlurivaloreObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RequisitiPagamentoPlurivaloreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoPlurivaloreObj.IsDirty = false;
				RequisitiPagamentoPlurivaloreObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj)
		{
			switch (RequisitiPagamentoPlurivaloreObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RequisitiPagamentoPlurivaloreObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RequisitiPagamentoPlurivaloreObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RequisitiPagamentoPlurivaloreObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RequisitiPagamentoPlurivaloreCollection RequisitiPagamentoPlurivaloreCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRequisitiPagamentoPlurivaloreUpdate", new string[] {"IdValore", "IdRequisito", "Codice", 
"Descrizione"}, new string[] {"int", "int", "string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRequisitiPagamentoPlurivaloreInsert", new string[] {"IdRequisito", "Codice", 
"Descrizione"}, new string[] {"int", "string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRequisitiPagamentoPlurivaloreDelete", new string[] {"IdValore"}, new string[] {"int"},"");
				for (int i = 0; i < RequisitiPagamentoPlurivaloreCollectionObj.Count; i++)
				{
					switch (RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RequisitiPagamentoPlurivaloreCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RequisitiPagamentoPlurivaloreCollectionObj[i].IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RequisitiPagamentoPlurivaloreCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RequisitiPagamentoPlurivaloreCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValore", (SiarLibrary.NullTypes.IntNT)RequisitiPagamentoPlurivaloreCollectionObj[i].IdValore);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RequisitiPagamentoPlurivaloreCollectionObj.Count; i++)
				{
					if ((RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RequisitiPagamentoPlurivaloreCollectionObj[i].IsDirty = false;
						RequisitiPagamentoPlurivaloreCollectionObj[i].IsPersistent = true;
					}
					if ((RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RequisitiPagamentoPlurivaloreCollectionObj[i].IsDirty = false;
						RequisitiPagamentoPlurivaloreCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj)
		{
			int returnValue = 0;
			if (RequisitiPagamentoPlurivaloreObj.IsPersistent) 
			{
				returnValue = Delete(db, RequisitiPagamentoPlurivaloreObj.IdValore);
			}
			RequisitiPagamentoPlurivaloreObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RequisitiPagamentoPlurivaloreObj.IsDirty = false;
			RequisitiPagamentoPlurivaloreObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValoreValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRequisitiPagamentoPlurivaloreDelete", new string[] {"IdValore"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValore", (SiarLibrary.NullTypes.IntNT)IdValoreValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RequisitiPagamentoPlurivaloreCollection RequisitiPagamentoPlurivaloreCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRequisitiPagamentoPlurivaloreDelete", new string[] {"IdValore"}, new string[] {"int"},"");
				for (int i = 0; i < RequisitiPagamentoPlurivaloreCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValore", RequisitiPagamentoPlurivaloreCollectionObj[i].IdValore);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RequisitiPagamentoPlurivaloreCollectionObj.Count; i++)
				{
					if ((RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RequisitiPagamentoPlurivaloreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RequisitiPagamentoPlurivaloreCollectionObj[i].IsDirty = false;
						RequisitiPagamentoPlurivaloreCollectionObj[i].IsPersistent = false;
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
		public static RequisitiPagamentoPlurivalore GetById(DbProvider db, int IdValoreValue)
		{
			RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRequisitiPagamentoPlurivaloreGetById", new string[] {"IdValore"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdValore", (SiarLibrary.NullTypes.IntNT)IdValoreValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RequisitiPagamentoPlurivaloreObj = GetFromDatareader(db);
				RequisitiPagamentoPlurivaloreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoPlurivaloreObj.IsDirty = false;
				RequisitiPagamentoPlurivaloreObj.IsPersistent = true;
			}
			db.Close();
			return RequisitiPagamentoPlurivaloreObj;
		}

		//getFromDatareader
		public static RequisitiPagamentoPlurivalore GetFromDatareader(DbProvider db)
		{
			RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj = new RequisitiPagamentoPlurivalore();
			RequisitiPagamentoPlurivaloreObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
			RequisitiPagamentoPlurivaloreObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
			RequisitiPagamentoPlurivaloreObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			RequisitiPagamentoPlurivaloreObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			RequisitiPagamentoPlurivaloreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RequisitiPagamentoPlurivaloreObj.IsDirty = false;
			RequisitiPagamentoPlurivaloreObj.IsPersistent = true;
			return RequisitiPagamentoPlurivaloreObj;
		}

		//Find Select

		public static RequisitiPagamentoPlurivaloreCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			RequisitiPagamentoPlurivaloreCollection RequisitiPagamentoPlurivaloreCollectionObj = new RequisitiPagamentoPlurivaloreCollection();

			IDbCommand findCmd = db.InitCmd("Zrequisitipagamentoplurivalorefindselect", new string[] {"IdValoreequalthis", "IdRequisitoequalthis", "Codiceequalthis", 
"Descrizioneequalthis"}, new string[] {"int", "int", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RequisitiPagamentoPlurivaloreObj = GetFromDatareader(db);
				RequisitiPagamentoPlurivaloreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoPlurivaloreObj.IsDirty = false;
				RequisitiPagamentoPlurivaloreObj.IsPersistent = true;
				RequisitiPagamentoPlurivaloreCollectionObj.Add(RequisitiPagamentoPlurivaloreObj);
			}
			db.Close();
			return RequisitiPagamentoPlurivaloreCollectionObj;
		}

		//Find Find

		public static RequisitiPagamentoPlurivaloreCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis)

		{

			RequisitiPagamentoPlurivaloreCollection RequisitiPagamentoPlurivaloreCollectionObj = new RequisitiPagamentoPlurivaloreCollection();

			IDbCommand findCmd = db.InitCmd("Zrequisitipagamentoplurivalorefindfind", new string[] {"IdValoreequalthis", "IdRequisitoequalthis", "Codiceequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RequisitiPagamentoPlurivaloreObj = GetFromDatareader(db);
				RequisitiPagamentoPlurivaloreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RequisitiPagamentoPlurivaloreObj.IsDirty = false;
				RequisitiPagamentoPlurivaloreObj.IsPersistent = true;
				RequisitiPagamentoPlurivaloreCollectionObj.Add(RequisitiPagamentoPlurivaloreObj);
			}
			db.Close();
			return RequisitiPagamentoPlurivaloreCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REQUISITI_PAGAMENTO_PLURIVALORE>
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
    <Find OrderBy="ORDER BY CODICE">
      <ID_VALORE>Equal</ID_VALORE>
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <CODICE>Equal</CODICE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</REQUISITI_PAGAMENTO_PLURIVALORE>
*/