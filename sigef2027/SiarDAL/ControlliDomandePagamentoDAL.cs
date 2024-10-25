using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ControlliDomandePagamentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class ControlliDomandePagamentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ControlliDomandePagamento ControlliDomandePagamentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", ControlliDomandePagamentoObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", ControlliDomandePagamentoObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreAssegnato", ControlliDomandePagamentoObj.OperatoreAssegnato);
			DbProvider.SetCmdParam(cmd,firstChar + "SelezionataXControllo", ControlliDomandePagamentoObj.SelezionataXControllo);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoEstrazione", ControlliDomandePagamentoObj.TipoEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "ControlloConcluso", ControlliDomandePagamentoObj.ControlloConcluso);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreDiRischio", ControlliDomandePagamentoObj.ValoreDiRischio);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoRichiesto", ControlliDomandePagamentoObj.ContributoRichiesto);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ControlliDomandePagamentoObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ControlliDomandePagamentoObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "ClasseDiRischio", ControlliDomandePagamentoObj.ClasseDiRischio);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdineClasseDiRischio", ControlliDomandePagamentoObj.OrdineClasseDiRischio);
		}
		//Insert
		private static int Insert(DbProvider db, ControlliDomandePagamento ControlliDomandePagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZControlliDomandePagamentoInsert", new string[] {"IdLotto", "IdDomandaPagamento", "OperatoreAssegnato", 
"SelezionataXControllo", "TipoEstrazione", "ControlloConcluso", 
"ValoreDiRischio", "ContributoRichiesto", 
"DataModifica", 
"Operatore", "ClasseDiRischio", 
"OrdineClasseDiRischio"}, new string[] {"int", "int", "string", 
"bool", "string", "bool", 
"decimal", "decimal", 
"DateTime", 
"string", "string", 
"int"},"");
				CompileIUCmd(false, insertCmd,ControlliDomandePagamentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ControlliDomandePagamentoObj.SelezionataXControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_CONTROLLO"]);
				ControlliDomandePagamentoObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
				}
				ControlliDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliDomandePagamentoObj.IsDirty = false;
				ControlliDomandePagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ControlliDomandePagamento ControlliDomandePagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliDomandePagamentoUpdate", new string[] {"IdLotto", "IdDomandaPagamento", "OperatoreAssegnato", 
"SelezionataXControllo", "TipoEstrazione", "ControlloConcluso", 
"ValoreDiRischio", "ContributoRichiesto", 
"DataModifica", 
"Operatore", "ClasseDiRischio", 
"OrdineClasseDiRischio"}, new string[] {"int", "int", "string", 
"bool", "string", "bool", 
"decimal", "decimal", 
"DateTime", 
"string", "string", 
"int"},"");
				CompileIUCmd(true, updateCmd,ControlliDomandePagamentoObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					ControlliDomandePagamentoObj.DataModifica = d;
				}
				ControlliDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliDomandePagamentoObj.IsDirty = false;
				ControlliDomandePagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ControlliDomandePagamento ControlliDomandePagamentoObj)
		{
			switch (ControlliDomandePagamentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ControlliDomandePagamentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ControlliDomandePagamentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ControlliDomandePagamentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliDomandePagamentoUpdate", new string[] {"IdLotto", "IdDomandaPagamento", "OperatoreAssegnato", 
"SelezionataXControllo", "TipoEstrazione", "ControlloConcluso", 
"ValoreDiRischio", "ContributoRichiesto", 
"DataModifica", 
"Operatore", "ClasseDiRischio", 
"OrdineClasseDiRischio"}, new string[] {"int", "int", "string", 
"bool", "string", "bool", 
"decimal", "decimal", 
"DateTime", 
"string", "string", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZControlliDomandePagamentoInsert", new string[] {"IdLotto", "IdDomandaPagamento", "OperatoreAssegnato", 
"SelezionataXControllo", "TipoEstrazione", "ControlloConcluso", 
"ValoreDiRischio", "ContributoRichiesto", 
"DataModifica", 
"Operatore", "ClasseDiRischio", 
"OrdineClasseDiRischio"}, new string[] {"int", "int", "string", 
"bool", "string", "bool", 
"decimal", "decimal", 
"DateTime", 
"string", "string", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZControlliDomandePagamentoDelete", new string[] {"IdLotto", "IdDomandaPagamento"}, new string[] {"int", "int"},"");
				for (int i = 0; i < ControlliDomandePagamentoCollectionObj.Count; i++)
				{
					switch (ControlliDomandePagamentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ControlliDomandePagamentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ControlliDomandePagamentoCollectionObj[i].SelezionataXControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_CONTROLLO"]);
									ControlliDomandePagamentoCollectionObj[i].ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ControlliDomandePagamentoCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									ControlliDomandePagamentoCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ControlliDomandePagamentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)ControlliDomandePagamentoCollectionObj[i].IdLotto);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)ControlliDomandePagamentoCollectionObj[i].IdDomandaPagamento);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ControlliDomandePagamentoCollectionObj.Count; i++)
				{
					if ((ControlliDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliDomandePagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ControlliDomandePagamentoCollectionObj[i].IsDirty = false;
						ControlliDomandePagamentoCollectionObj[i].IsPersistent = true;
					}
					if ((ControlliDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ControlliDomandePagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliDomandePagamentoCollectionObj[i].IsDirty = false;
						ControlliDomandePagamentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ControlliDomandePagamento ControlliDomandePagamentoObj)
		{
			int returnValue = 0;
			if (ControlliDomandePagamentoObj.IsPersistent) 
			{
				returnValue = Delete(db, ControlliDomandePagamentoObj.IdLotto, ControlliDomandePagamentoObj.IdDomandaPagamento);
			}
			ControlliDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ControlliDomandePagamentoObj.IsDirty = false;
			ControlliDomandePagamentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLottoValue, int IdDomandaPagamentoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliDomandePagamentoDelete", new string[] {"IdLotto", "IdDomandaPagamento"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliDomandePagamentoDelete", new string[] {"IdLotto", "IdDomandaPagamento"}, new string[] {"int", "int"},"");
				for (int i = 0; i < ControlliDomandePagamentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", ControlliDomandePagamentoCollectionObj[i].IdLotto);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", ControlliDomandePagamentoCollectionObj[i].IdDomandaPagamento);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ControlliDomandePagamentoCollectionObj.Count; i++)
				{
					if ((ControlliDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliDomandePagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliDomandePagamentoCollectionObj[i].IsDirty = false;
						ControlliDomandePagamentoCollectionObj[i].IsPersistent = false;
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
		public static ControlliDomandePagamento GetById(DbProvider db, int IdLottoValue, int IdDomandaPagamentoValue)
		{
			ControlliDomandePagamento ControlliDomandePagamentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZControlliDomandePagamentoGetById", new string[] {"IdLotto", "IdDomandaPagamento"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ControlliDomandePagamentoObj = GetFromDatareader(db);
				ControlliDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliDomandePagamentoObj.IsDirty = false;
				ControlliDomandePagamentoObj.IsPersistent = true;
			}
			db.Close();
			return ControlliDomandePagamentoObj;
		}

		//getFromDatareader
		public static ControlliDomandePagamento GetFromDatareader(DbProvider db)
		{
			ControlliDomandePagamento ControlliDomandePagamentoObj = new ControlliDomandePagamento();
			ControlliDomandePagamentoObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			ControlliDomandePagamentoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			ControlliDomandePagamentoObj.OperatoreAssegnato = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_ASSEGNATO"]);
			ControlliDomandePagamentoObj.SelezionataXControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_CONTROLLO"]);
			ControlliDomandePagamentoObj.TipoEstrazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ESTRAZIONE"]);
			ControlliDomandePagamentoObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
			ControlliDomandePagamentoObj.ValoreDiRischio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_DI_RISCHIO"]);
			ControlliDomandePagamentoObj.ContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
			ControlliDomandePagamentoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			ControlliDomandePagamentoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ControlliDomandePagamentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ControlliDomandePagamentoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ControlliDomandePagamentoObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			ControlliDomandePagamentoObj.DataPresentazioneDomandaPagamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO"]);
			ControlliDomandePagamentoObj.ClasseDiRischio = new SiarLibrary.NullTypes.StringNT(db.DataReader["CLASSE_DI_RISCHIO"]);
			ControlliDomandePagamentoObj.OrdineClasseDiRischio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_CLASSE_DI_RISCHIO"]);
			ControlliDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ControlliDomandePagamentoObj.IsDirty = false;
			ControlliDomandePagamentoObj.IsPersistent = true;
			return ControlliDomandePagamentoObj;
		}

		//Find Select

		public static ControlliDomandePagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT OperatoreAssegnatoEqualThis, 
SiarLibrary.NullTypes.BoolNT SelezionataXControlloEqualThis, SiarLibrary.NullTypes.StringNT TipoEstrazioneEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreDiRischioEqualThis, 
SiarLibrary.NullTypes.StringNT ClasseDiRischioEqualThis, SiarLibrary.NullTypes.IntNT OrdineClasseDiRischioEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRichiestoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.BoolNT ControlloConclusoEqualThis)

		{

			ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionObj = new ControlliDomandePagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollidomandepagamentofindselect", new string[] {"IdLottoequalthis", "IdDomandaPagamentoequalthis", "OperatoreAssegnatoequalthis", 
"SelezionataXControlloequalthis", "TipoEstrazioneequalthis", "ValoreDiRischioequalthis", 
"ClasseDiRischioequalthis", "OrdineClasseDiRischioequalthis", "ContributoRichiestoequalthis", 
"DataModificaequalthis", "Operatoreequalthis", "ControlloConclusoequalthis"}, new string[] {"int", "int", "string", 
"bool", "string", "decimal", 
"string", "int", "decimal", 
"DateTime", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreAssegnatoequalthis", OperatoreAssegnatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXControlloequalthis", SelezionataXControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoEstrazioneequalthis", TipoEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreDiRischioequalthis", ValoreDiRischioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ClasseDiRischioequalthis", ClasseDiRischioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineClasseDiRischioequalthis", OrdineClasseDiRischioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloConclusoequalthis", ControlloConclusoEqualThis);
			ControlliDomandePagamento ControlliDomandePagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliDomandePagamentoObj = GetFromDatareader(db);
				ControlliDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliDomandePagamentoObj.IsDirty = false;
				ControlliDomandePagamentoObj.IsPersistent = true;
				ControlliDomandePagamentoCollectionObj.Add(ControlliDomandePagamentoObj);
			}
			db.Close();
			return ControlliDomandePagamentoCollectionObj;
		}

		//Find Find

		public static ControlliDomandePagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionObj = new ControlliDomandePagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollidomandepagamentofindfind", new string[] {"IdLottoequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			ControlliDomandePagamento ControlliDomandePagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliDomandePagamentoObj = GetFromDatareader(db);
				ControlliDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliDomandePagamentoObj.IsDirty = false;
				ControlliDomandePagamentoObj.IsPersistent = true;
				ControlliDomandePagamentoCollectionObj.Add(ControlliDomandePagamentoObj);
			}
			db.Close();
			return ControlliDomandePagamentoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_DOMANDE_PAGAMENTO>
  <ViewName>vCONTROLLI_DOMANDE_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE, COD_TIPO DESC, VALORE_DI_RISCHIO DESC, CONTRIBUTO_RICHIESTO DESC">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
    <FiltroControlli>
      <SELEZIONATA_X_CONTROLLO>Equal</SELEZIONATA_X_CONTROLLO>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlli>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CONTROLLI_DOMANDE_PAGAMENTO>
*/