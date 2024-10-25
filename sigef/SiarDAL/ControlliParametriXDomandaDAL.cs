using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ControlliParametriXDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class ControlliParametriXDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ControlliParametriXDomanda ControlliParametriXDomandaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", ControlliParametriXDomandaObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdParametro", ControlliParametriXDomandaObj.IdParametro);
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", ControlliParametriXDomandaObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "Punteggio", ControlliParametriXDomandaObj.Punteggio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", ControlliParametriXDomandaObj.DataValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ControlliParametriXDomandaObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, ControlliParametriXDomanda ControlliParametriXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZControlliParametriXDomandaInsert", new string[] {"IdDomandaPagamento", "IdParametro", "IdLotto", 
"Punteggio", "DataValutazione", "Operatore", }, new string[] {"int", "int", "int", 
"int", "DateTime", "string", },"");
				CompileIUCmd(false, insertCmd,ControlliParametriXDomandaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				ControlliParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXDomandaObj.IsDirty = false;
				ControlliParametriXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ControlliParametriXDomanda ControlliParametriXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliParametriXDomandaUpdate", new string[] {"IdDomandaPagamento", "IdParametro", "IdLotto", 
"Punteggio", "DataValutazione", "Operatore", }, new string[] {"int", "int", "int", 
"int", "DateTime", "string", },"");
				CompileIUCmd(true, updateCmd,ControlliParametriXDomandaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ControlliParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXDomandaObj.IsDirty = false;
				ControlliParametriXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ControlliParametriXDomanda ControlliParametriXDomandaObj)
		{
			switch (ControlliParametriXDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ControlliParametriXDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ControlliParametriXDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ControlliParametriXDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ControlliParametriXDomandaCollection ControlliParametriXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliParametriXDomandaUpdate", new string[] {"IdDomandaPagamento", "IdParametro", "IdLotto", 
"Punteggio", "DataValutazione", "Operatore", }, new string[] {"int", "int", "int", 
"int", "DateTime", "string", },"");
				IDbCommand insertCmd = db.InitCmd( "ZControlliParametriXDomandaInsert", new string[] {"IdDomandaPagamento", "IdParametro", "IdLotto", 
"Punteggio", "DataValutazione", "Operatore", }, new string[] {"int", "int", "int", 
"int", "DateTime", "string", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriXDomandaDelete", new string[] {"IdDomandaPagamento", "IdParametro", "IdLotto"}, new string[] {"int", "int", "int"},"");
				for (int i = 0; i < ControlliParametriXDomandaCollectionObj.Count; i++)
				{
					switch (ControlliParametriXDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ControlliParametriXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ControlliParametriXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ControlliParametriXDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)ControlliParametriXDomandaCollectionObj[i].IdDomandaPagamento);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)ControlliParametriXDomandaCollectionObj[i].IdParametro);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)ControlliParametriXDomandaCollectionObj[i].IdLotto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ControlliParametriXDomandaCollectionObj.Count; i++)
				{
					if ((ControlliParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliParametriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ControlliParametriXDomandaCollectionObj[i].IsDirty = false;
						ControlliParametriXDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((ControlliParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ControlliParametriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliParametriXDomandaCollectionObj[i].IsDirty = false;
						ControlliParametriXDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ControlliParametriXDomanda ControlliParametriXDomandaObj)
		{
			int returnValue = 0;
			if (ControlliParametriXDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, ControlliParametriXDomandaObj.IdDomandaPagamento, ControlliParametriXDomandaObj.IdParametro, ControlliParametriXDomandaObj.IdLotto);
			}
			ControlliParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ControlliParametriXDomandaObj.IsDirty = false;
			ControlliParametriXDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaPagamentoValue, int IdParametroValue, int IdLottoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriXDomandaDelete", new string[] {"IdDomandaPagamento", "IdParametro", "IdLotto"}, new string[] {"int", "int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)IdParametroValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ControlliParametriXDomandaCollection ControlliParametriXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliParametriXDomandaDelete", new string[] {"IdDomandaPagamento", "IdParametro", "IdLotto"}, new string[] {"int", "int", "int"},"");
				for (int i = 0; i < ControlliParametriXDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", ControlliParametriXDomandaCollectionObj[i].IdDomandaPagamento);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParametro", ControlliParametriXDomandaCollectionObj[i].IdParametro);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", ControlliParametriXDomandaCollectionObj[i].IdLotto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ControlliParametriXDomandaCollectionObj.Count; i++)
				{
					if ((ControlliParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliParametriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliParametriXDomandaCollectionObj[i].IsDirty = false;
						ControlliParametriXDomandaCollectionObj[i].IsPersistent = false;
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
		public static ControlliParametriXDomanda GetById(DbProvider db, int IdDomandaPagamentoValue, int IdParametroValue, int IdLottoValue)
		{
			ControlliParametriXDomanda ControlliParametriXDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZControlliParametriXDomandaGetById", new string[] {"IdDomandaPagamento", "IdParametro", "IdLotto"}, new string[] {"int", "int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdParametro", (SiarLibrary.NullTypes.IntNT)IdParametroValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ControlliParametriXDomandaObj = GetFromDatareader(db);
				ControlliParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXDomandaObj.IsDirty = false;
				ControlliParametriXDomandaObj.IsPersistent = true;
			}
			db.Close();
			return ControlliParametriXDomandaObj;
		}

		//getFromDatareader
		public static ControlliParametriXDomanda GetFromDatareader(DbProvider db)
		{
			ControlliParametriXDomanda ControlliParametriXDomandaObj = new ControlliParametriXDomanda();
			ControlliParametriXDomandaObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			ControlliParametriXDomandaObj.IdParametro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAMETRO"]);
			ControlliParametriXDomandaObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			ControlliParametriXDomandaObj.Punteggio = new SiarLibrary.NullTypes.IntNT(db.DataReader["PUNTEGGIO"]);
			ControlliParametriXDomandaObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			ControlliParametriXDomandaObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			ControlliParametriXDomandaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ControlliParametriXDomandaObj.Manuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANUALE"]);
			ControlliParametriXDomandaObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			ControlliParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ControlliParametriXDomandaObj.IsDirty = false;
			ControlliParametriXDomandaObj.IsPersistent = true;
			return ControlliParametriXDomandaObj;
		}

		//Find Select

		public static ControlliParametriXDomandaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, 
SiarLibrary.NullTypes.IntNT PunteggioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis)

		{

			ControlliParametriXDomandaCollection ControlliParametriXDomandaCollectionObj = new ControlliParametriXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrolliparametrixdomandafindselect", new string[] {"IdDomandaPagamentoequalthis", "IdParametroequalthis", "IdLottoequalthis", 
"Punteggioequalthis", "DataValutazioneequalthis", "Operatoreequalthis"}, new string[] {"int", "int", "int", 
"int", "DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Punteggioequalthis", PunteggioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			ControlliParametriXDomanda ControlliParametriXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliParametriXDomandaObj = GetFromDatareader(db);
				ControlliParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXDomandaObj.IsDirty = false;
				ControlliParametriXDomandaObj.IsPersistent = true;
				ControlliParametriXDomandaCollectionObj.Add(ControlliParametriXDomandaObj);
			}
			db.Close();
			return ControlliParametriXDomandaCollectionObj;
		}

		//Find Find

		public static ControlliParametriXDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, 
SiarLibrary.NullTypes.BoolNT ManualeEqualThis)

		{

			ControlliParametriXDomandaCollection ControlliParametriXDomandaCollectionObj = new ControlliParametriXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrolliparametrixdomandafindfind", new string[] {"IdDomandaPagamentoequalthis", "IdParametroequalthis", "IdLottoequalthis", 
"Manualeequalthis"}, new string[] {"int", "int", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Manualeequalthis", ManualeEqualThis);
			ControlliParametriXDomanda ControlliParametriXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliParametriXDomandaObj = GetFromDatareader(db);
				ControlliParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliParametriXDomandaObj.IsDirty = false;
				ControlliParametriXDomandaObj.IsPersistent = true;
				ControlliParametriXDomandaCollectionObj.Add(ControlliParametriXDomandaObj);
			}
			db.Close();
			return ControlliParametriXDomandaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_X_DOMANDA>
  <ViewName>vCONTROLLI_PARAMETRI_X_DOMANDA</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <ID_LOTTO>Equal</ID_LOTTO>
      <MANUALE>Equal</MANUALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_X_DOMANDA>
*/