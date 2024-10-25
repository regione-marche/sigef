using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoRequisitiPagamentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class BandoRequisitiPagamentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoRequisitiPagamento BandoRequisitiPagamentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoRequisitiPagamentoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", BandoRequisitiPagamentoObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRequisito", BandoRequisitiPagamentoObj.IdRequisito);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", BandoRequisitiPagamentoObj.Obbligatorio);
			DbProvider.SetCmdParam(cmd,firstChar + "RequisitoDiControllo", BandoRequisitiPagamentoObj.RequisitoDiControllo);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", BandoRequisitiPagamentoObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "RequisitoDiInserimento", BandoRequisitiPagamentoObj.RequisitoDiInserimento);
		}
		//Insert
		private static int Insert(DbProvider db, BandoRequisitiPagamento BandoRequisitiPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoRequisitiPagamentoInsert", new string[] {"IdBando", "CodTipo", "IdRequisito", 
"Obbligatorio", "RequisitoDiControllo", "Ordine", 




"RequisitoDiInserimento"}, new string[] {"int", "string", "int", 
"bool", "bool", "int", 




"bool"},"");
				CompileIUCmd(false, insertCmd,BandoRequisitiPagamentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoRequisitiPagamentoObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
				BandoRequisitiPagamentoObj.RequisitoDiControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_CONTROLLO"]);
				}
				BandoRequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiPagamentoObj.IsDirty = false;
				BandoRequisitiPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoRequisitiPagamento BandoRequisitiPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoRequisitiPagamentoUpdate", new string[] {"IdBando", "CodTipo", "IdRequisito", 
"Obbligatorio", "RequisitoDiControllo", "Ordine", 




"RequisitoDiInserimento"}, new string[] {"int", "string", "int", 
"bool", "bool", "int", 




"bool"},"");
				CompileIUCmd(true, updateCmd,BandoRequisitiPagamentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoRequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiPagamentoObj.IsDirty = false;
				BandoRequisitiPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoRequisitiPagamento BandoRequisitiPagamentoObj)
		{
			switch (BandoRequisitiPagamentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoRequisitiPagamentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoRequisitiPagamentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoRequisitiPagamentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoRequisitiPagamentoUpdate", new string[] {"IdBando", "CodTipo", "IdRequisito", 
"Obbligatorio", "RequisitoDiControllo", "Ordine", 




"RequisitoDiInserimento"}, new string[] {"int", "string", "int", 
"bool", "bool", "int", 




"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoRequisitiPagamentoInsert", new string[] {"IdBando", "CodTipo", "IdRequisito", 
"Obbligatorio", "RequisitoDiControllo", "Ordine", 




"RequisitoDiInserimento"}, new string[] {"int", "string", "int", 
"bool", "bool", "int", 




"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRequisitiPagamentoDelete", new string[] {"IdBando", "CodTipo", "IdRequisito"}, new string[] {"int", "string", "int"},"");
				for (int i = 0; i < BandoRequisitiPagamentoCollectionObj.Count; i++)
				{
					switch (BandoRequisitiPagamentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoRequisitiPagamentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoRequisitiPagamentoCollectionObj[i].Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
									BandoRequisitiPagamentoCollectionObj[i].RequisitoDiControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_CONTROLLO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoRequisitiPagamentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoRequisitiPagamentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BandoRequisitiPagamentoCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)BandoRequisitiPagamentoCollectionObj[i].CodTipo);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)BandoRequisitiPagamentoCollectionObj[i].IdRequisito);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoRequisitiPagamentoCollectionObj.Count; i++)
				{
					if ((BandoRequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoRequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoRequisitiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoRequisitiPagamentoCollectionObj[i].IsDirty = false;
						BandoRequisitiPagamentoCollectionObj[i].IsPersistent = true;
					}
					if ((BandoRequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoRequisitiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoRequisitiPagamentoCollectionObj[i].IsDirty = false;
						BandoRequisitiPagamentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoRequisitiPagamento BandoRequisitiPagamentoObj)
		{
			int returnValue = 0;
			if (BandoRequisitiPagamentoObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoRequisitiPagamentoObj.IdBando, BandoRequisitiPagamentoObj.CodTipo, BandoRequisitiPagamentoObj.IdRequisito);
			}
			BandoRequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoRequisitiPagamentoObj.IsDirty = false;
			BandoRequisitiPagamentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, string CodTipoValue, int IdRequisitoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRequisitiPagamentoDelete", new string[] {"IdBando", "CodTipo", "IdRequisito"}, new string[] {"int", "string", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRequisitiPagamentoDelete", new string[] {"IdBando", "CodTipo", "IdRequisito"}, new string[] {"int", "string", "int"},"");
				for (int i = 0; i < BandoRequisitiPagamentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", BandoRequisitiPagamentoCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", BandoRequisitiPagamentoCollectionObj[i].CodTipo);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", BandoRequisitiPagamentoCollectionObj[i].IdRequisito);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoRequisitiPagamentoCollectionObj.Count; i++)
				{
					if ((BandoRequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoRequisitiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoRequisitiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoRequisitiPagamentoCollectionObj[i].IsDirty = false;
						BandoRequisitiPagamentoCollectionObj[i].IsPersistent = false;
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
		public static BandoRequisitiPagamento GetById(DbProvider db, int IdBandoValue, string CodTipoValue, int IdRequisitoValue)
		{
			BandoRequisitiPagamento BandoRequisitiPagamentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoRequisitiPagamentoGetById", new string[] {"IdBando", "CodTipo", "IdRequisito"}, new string[] {"int", "string", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoRequisitiPagamentoObj = GetFromDatareader(db);
				BandoRequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiPagamentoObj.IsDirty = false;
				BandoRequisitiPagamentoObj.IsPersistent = true;
			}
			db.Close();
			return BandoRequisitiPagamentoObj;
		}

		//getFromDatareader
		public static BandoRequisitiPagamento GetFromDatareader(DbProvider db)
		{
			BandoRequisitiPagamento BandoRequisitiPagamentoObj = new BandoRequisitiPagamento();
			BandoRequisitiPagamentoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoRequisitiPagamentoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			BandoRequisitiPagamentoObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
			BandoRequisitiPagamentoObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			BandoRequisitiPagamentoObj.RequisitoDiControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_CONTROLLO"]);
			BandoRequisitiPagamentoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			BandoRequisitiPagamentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoRequisitiPagamentoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			BandoRequisitiPagamentoObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
			BandoRequisitiPagamentoObj.OrdineFase = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FASE"]);
			BandoRequisitiPagamentoObj.Requisito = new SiarLibrary.NullTypes.StringNT(db.DataReader["REQUISITO"]);
			BandoRequisitiPagamentoObj.Plurivalore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURIVALORE"]);
			BandoRequisitiPagamentoObj.Numerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NUMERICO"]);
			BandoRequisitiPagamentoObj.Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
			BandoRequisitiPagamentoObj.TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
			BandoRequisitiPagamentoObj.TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
			BandoRequisitiPagamentoObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			BandoRequisitiPagamentoObj.QueryEval = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_EVAL"]);
			BandoRequisitiPagamentoObj.QueryInsert = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_INSERT"]);
			BandoRequisitiPagamentoObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			BandoRequisitiPagamentoObj.RequisitoDiInserimento = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_INSERIMENTO"]);
			BandoRequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoRequisitiPagamentoObj.IsDirty = false;
			BandoRequisitiPagamentoObj.IsPersistent = true;
			return BandoRequisitiPagamentoObj;
		}

		//Find Select

		public static BandoRequisitiPagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, 
SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, SiarLibrary.NullTypes.BoolNT RequisitoDiInserimentoEqualThis, SiarLibrary.NullTypes.BoolNT RequisitoDiControlloEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionObj = new BandoRequisitiPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zbandorequisitipagamentofindselect", new string[] {"IdBandoequalthis", "CodTipoequalthis", "IdRequisitoequalthis", 
"Obbligatorioequalthis", "RequisitoDiInserimentoequalthis", "RequisitoDiControlloequalthis", 
"Ordineequalthis"}, new string[] {"int", "string", "int", 
"bool", "bool", "bool", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RequisitoDiInserimentoequalthis", RequisitoDiInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RequisitoDiControlloequalthis", RequisitoDiControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			BandoRequisitiPagamento BandoRequisitiPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoRequisitiPagamentoObj = GetFromDatareader(db);
				BandoRequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiPagamentoObj.IsDirty = false;
				BandoRequisitiPagamentoObj.IsPersistent = true;
				BandoRequisitiPagamentoCollectionObj.Add(BandoRequisitiPagamentoObj);
			}
			db.Close();
			return BandoRequisitiPagamentoCollectionObj;
		}

		//Find Find

		public static BandoRequisitiPagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis)

		{

			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionObj = new BandoRequisitiPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zbandorequisitipagamentofindfind", new string[] {"IdBandoequalthis", "CodTipoequalthis", "IdRequisitoequalthis"}, new string[] {"int", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			BandoRequisitiPagamento BandoRequisitiPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoRequisitiPagamentoObj = GetFromDatareader(db);
				BandoRequisitiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiPagamentoObj.IsDirty = false;
				BandoRequisitiPagamentoObj.IsPersistent = true;
				BandoRequisitiPagamentoCollectionObj.Add(BandoRequisitiPagamentoObj);
			}
			db.Close();
			return BandoRequisitiPagamentoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_REQUISITI_PAGAMENTO>
  <ViewName>vBANDO_REQUISITI_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE, ORDINE_FASE">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_REQUISITO>Equal</ID_REQUISITO>
    </Find>
  </Finds>
  <Filters>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroDiControllo>
      <REQUISITO_DI_CONTROLLO>Equal</REQUISITO_DI_CONTROLLO>
    </FiltroDiControllo>
    <FiltroDiInserimento>
      <REQUISITO_DI_INSERIMENTO>Equal</REQUISITO_DI_INSERIMENTO>
    </FiltroDiInserimento>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_REQUISITI_PAGAMENTO>
*/