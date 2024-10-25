using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CorrettivaRendicontazioneSpostamentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class CorrettivaRendicontazioneSpostamentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CorrettivaRendicontazioneSpostamentiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdCorrettiva", CorrettivaRendicontazioneSpostamentiObj.IdCorrettiva);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimentoDa", CorrettivaRendicontazioneSpostamentiObj.IdInvestimentoDa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimentoA", CorrettivaRendicontazioneSpostamentiObj.IdInvestimentoA);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoSpostato", CorrettivaRendicontazioneSpostamentiObj.ImportoSpostato);
			DbProvider.SetCmdParam(cmd,firstChar + "Concluso", CorrettivaRendicontazioneSpostamentiObj.Concluso);
			DbProvider.SetCmdParam(cmd,firstChar + "Annullato", CorrettivaRendicontazioneSpostamentiObj.Annullato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", CorrettivaRendicontazioneSpostamentiObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", CorrettivaRendicontazioneSpostamentiObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", CorrettivaRendicontazioneSpostamentiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdJsonLog", CorrettivaRendicontazioneSpostamentiObj.IdJsonLog);
		}
		//Insert
		private static int Insert(DbProvider db, CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCorrettivaRendicontazioneSpostamentiInsert", new string[] {"IdCorrettiva", "IdInvestimentoDa", 
"IdInvestimentoA", "ImportoSpostato", "Concluso", 
"Annullato", "IdUtente", "Data", 
"Descrizione", "IdJsonLog"}, new string[] {"int", "int", 
"int", "decimal", "bool", 
"bool", "int", "DateTime", 
"string", "int"},"");
				CompileIUCmd(false, insertCmd,CorrettivaRendicontazioneSpostamentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CorrettivaRendicontazioneSpostamentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				CorrettivaRendicontazioneSpostamentiObj.ImportoSpostato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPOSTATO"]);
				CorrettivaRendicontazioneSpostamentiObj.Concluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONCLUSO"]);
				CorrettivaRendicontazioneSpostamentiObj.Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
				}
				CorrettivaRendicontazioneSpostamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneSpostamentiObj.IsDirty = false;
				CorrettivaRendicontazioneSpostamentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCorrettivaRendicontazioneSpostamentiUpdate", new string[] {"Id", "IdCorrettiva", "IdInvestimentoDa", 
"IdInvestimentoA", "ImportoSpostato", "Concluso", 
"Annullato", "IdUtente", "Data", 
"Descrizione", "IdJsonLog"}, new string[] {"int", "int", "int", 
"int", "decimal", "bool", 
"bool", "int", "DateTime", 
"string", "int"},"");
				CompileIUCmd(true, updateCmd,CorrettivaRendicontazioneSpostamentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CorrettivaRendicontazioneSpostamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneSpostamentiObj.IsDirty = false;
				CorrettivaRendicontazioneSpostamentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj)
		{
			switch (CorrettivaRendicontazioneSpostamentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CorrettivaRendicontazioneSpostamentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CorrettivaRendicontazioneSpostamentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CorrettivaRendicontazioneSpostamentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CorrettivaRendicontazioneSpostamentiCollection CorrettivaRendicontazioneSpostamentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCorrettivaRendicontazioneSpostamentiUpdate", new string[] {"Id", "IdCorrettiva", "IdInvestimentoDa", 
"IdInvestimentoA", "ImportoSpostato", "Concluso", 
"Annullato", "IdUtente", "Data", 
"Descrizione", "IdJsonLog"}, new string[] {"int", "int", "int", 
"int", "decimal", "bool", 
"bool", "int", "DateTime", 
"string", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCorrettivaRendicontazioneSpostamentiInsert", new string[] {"IdCorrettiva", "IdInvestimentoDa", 
"IdInvestimentoA", "ImportoSpostato", "Concluso", 
"Annullato", "IdUtente", "Data", 
"Descrizione", "IdJsonLog"}, new string[] {"int", "int", 
"int", "decimal", "bool", 
"bool", "int", "DateTime", 
"string", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCorrettivaRendicontazioneSpostamentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CorrettivaRendicontazioneSpostamentiCollectionObj.Count; i++)
				{
					switch (CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CorrettivaRendicontazioneSpostamentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CorrettivaRendicontazioneSpostamentiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									CorrettivaRendicontazioneSpostamentiCollectionObj[i].ImportoSpostato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPOSTATO"]);
									CorrettivaRendicontazioneSpostamentiCollectionObj[i].Concluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONCLUSO"]);
									CorrettivaRendicontazioneSpostamentiCollectionObj[i].Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CorrettivaRendicontazioneSpostamentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CorrettivaRendicontazioneSpostamentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CorrettivaRendicontazioneSpostamentiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CorrettivaRendicontazioneSpostamentiCollectionObj.Count; i++)
				{
					if ((CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].IsDirty = false;
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].IsPersistent = true;
					}
					if ((CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].IsDirty = false;
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj)
		{
			int returnValue = 0;
			if (CorrettivaRendicontazioneSpostamentiObj.IsPersistent) 
			{
				returnValue = Delete(db, CorrettivaRendicontazioneSpostamentiObj.Id);
			}
			CorrettivaRendicontazioneSpostamentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CorrettivaRendicontazioneSpostamentiObj.IsDirty = false;
			CorrettivaRendicontazioneSpostamentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCorrettivaRendicontazioneSpostamentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CorrettivaRendicontazioneSpostamentiCollection CorrettivaRendicontazioneSpostamentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCorrettivaRendicontazioneSpostamentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CorrettivaRendicontazioneSpostamentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CorrettivaRendicontazioneSpostamentiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CorrettivaRendicontazioneSpostamentiCollectionObj.Count; i++)
				{
					if ((CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].IsDirty = false;
						CorrettivaRendicontazioneSpostamentiCollectionObj[i].IsPersistent = false;
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
		public static CorrettivaRendicontazioneSpostamenti GetById(DbProvider db, int IdValue)
		{
			CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCorrettivaRendicontazioneSpostamentiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CorrettivaRendicontazioneSpostamentiObj = GetFromDatareader(db);
				CorrettivaRendicontazioneSpostamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneSpostamentiObj.IsDirty = false;
				CorrettivaRendicontazioneSpostamentiObj.IsPersistent = true;
			}
			db.Close();
			return CorrettivaRendicontazioneSpostamentiObj;
		}

		//getFromDatareader
		public static CorrettivaRendicontazioneSpostamenti GetFromDatareader(DbProvider db)
		{
			CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj = new CorrettivaRendicontazioneSpostamenti();
			CorrettivaRendicontazioneSpostamentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CorrettivaRendicontazioneSpostamentiObj.IdCorrettiva = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CORRETTIVA"]);
			CorrettivaRendicontazioneSpostamentiObj.IdInvestimentoDa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO_DA"]);
			CorrettivaRendicontazioneSpostamentiObj.IdInvestimentoA = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO_A"]);
			CorrettivaRendicontazioneSpostamentiObj.ImportoSpostato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPOSTATO"]);
			CorrettivaRendicontazioneSpostamentiObj.Concluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONCLUSO"]);
			CorrettivaRendicontazioneSpostamentiObj.Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
			CorrettivaRendicontazioneSpostamentiObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			CorrettivaRendicontazioneSpostamentiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			CorrettivaRendicontazioneSpostamentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CorrettivaRendicontazioneSpostamentiObj.IdJsonLog = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_JSON_LOG"]);
			CorrettivaRendicontazioneSpostamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CorrettivaRendicontazioneSpostamentiObj.IsDirty = false;
			CorrettivaRendicontazioneSpostamentiObj.IsPersistent = true;
			return CorrettivaRendicontazioneSpostamentiObj;
		}

		//Find Select

		public static CorrettivaRendicontazioneSpostamentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdCorrettivaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoDaEqualThis, 
SiarLibrary.NullTypes.IntNT IdInvestimentoAEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSpostatoEqualThis, SiarLibrary.NullTypes.BoolNT ConclusoEqualThis, 
SiarLibrary.NullTypes.BoolNT AnnullatoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT IdJsonLogEqualThis)

		{

			CorrettivaRendicontazioneSpostamentiCollection CorrettivaRendicontazioneSpostamentiCollectionObj = new CorrettivaRendicontazioneSpostamentiCollection();

			IDbCommand findCmd = db.InitCmd("Zcorrettivarendicontazionespostamentifindselect", new string[] {"Idequalthis", "IdCorrettivaequalthis", "IdInvestimentoDaequalthis", 
"IdInvestimentoAequalthis", "ImportoSpostatoequalthis", "Conclusoequalthis", 
"Annullatoequalthis", "IdUtenteequalthis", "Dataequalthis", 
"Descrizioneequalthis", "IdJsonLogequalthis"}, new string[] {"int", "int", "int", 
"int", "decimal", "bool", 
"bool", "int", "DateTime", 
"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCorrettivaequalthis", IdCorrettivaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoDaequalthis", IdInvestimentoDaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoAequalthis", IdInvestimentoAEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoSpostatoequalthis", ImportoSpostatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Conclusoequalthis", ConclusoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullatoequalthis", AnnullatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdJsonLogequalthis", IdJsonLogEqualThis);
			CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CorrettivaRendicontazioneSpostamentiObj = GetFromDatareader(db);
				CorrettivaRendicontazioneSpostamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneSpostamentiObj.IsDirty = false;
				CorrettivaRendicontazioneSpostamentiObj.IsPersistent = true;
				CorrettivaRendicontazioneSpostamentiCollectionObj.Add(CorrettivaRendicontazioneSpostamentiObj);
			}
			db.Close();
			return CorrettivaRendicontazioneSpostamentiCollectionObj;
		}

		//Find Find

		public static CorrettivaRendicontazioneSpostamentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdCorrettivaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoDaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoAEqualThis, 
SiarLibrary.NullTypes.BoolNT ConclusoEqualThis, SiarLibrary.NullTypes.BoolNT AnnullatoEqualThis)

		{

			CorrettivaRendicontazioneSpostamentiCollection CorrettivaRendicontazioneSpostamentiCollectionObj = new CorrettivaRendicontazioneSpostamentiCollection();

			IDbCommand findCmd = db.InitCmd("Zcorrettivarendicontazionespostamentifindfind", new string[] {"IdCorrettivaequalthis", "IdInvestimentoDaequalthis", "IdInvestimentoAequalthis", 
"Conclusoequalthis", "Annullatoequalthis"}, new string[] {"int", "int", "int", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCorrettivaequalthis", IdCorrettivaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoDaequalthis", IdInvestimentoDaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoAequalthis", IdInvestimentoAEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Conclusoequalthis", ConclusoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullatoequalthis", AnnullatoEqualThis);
			CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CorrettivaRendicontazioneSpostamentiObj = GetFromDatareader(db);
				CorrettivaRendicontazioneSpostamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CorrettivaRendicontazioneSpostamentiObj.IsDirty = false;
				CorrettivaRendicontazioneSpostamentiObj.IsPersistent = true;
				CorrettivaRendicontazioneSpostamentiCollectionObj.Add(CorrettivaRendicontazioneSpostamentiObj);
			}
			db.Close();
			return CorrettivaRendicontazioneSpostamentiCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI>
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
    <Find OrderBy="ORDER BY ID">
      <ID_CORRETTIVA>Equal</ID_CORRETTIVA>
      <ID_INVESTIMENTO_DA>Equal</ID_INVESTIMENTO_DA>
      <ID_INVESTIMENTO_A>Equal</ID_INVESTIMENTO_A>
      <CONCLUSO>Equal</CONCLUSO>
      <ANNULLATO>Equal</ANNULLATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI>
*/