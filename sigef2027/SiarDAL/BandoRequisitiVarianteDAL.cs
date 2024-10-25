using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoRequisitiVarianteDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class BandoRequisitiVarianteDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoRequisitiVariante BandoRequisitiVarianteObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoRequisitiVarianteObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", BandoRequisitiVarianteObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRequisito", BandoRequisitiVarianteObj.IdRequisito);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", BandoRequisitiVarianteObj.Obbligatorio);
			DbProvider.SetCmdParam(cmd,firstChar + "RequisitoDiPresentazione", BandoRequisitiVarianteObj.RequisitoDiPresentazione);
			DbProvider.SetCmdParam(cmd,firstChar + "RequisitoDiIstruttoria", BandoRequisitiVarianteObj.RequisitoDiIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", BandoRequisitiVarianteObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, BandoRequisitiVariante BandoRequisitiVarianteObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoRequisitiVarianteInsert", new string[] {"IdBando", "CodTipo", "IdRequisito", 
"Obbligatorio", "RequisitoDiPresentazione", "RequisitoDiIstruttoria", 
"Ordine", 
}, new string[] {"int", "string", "int", 
"bool", "bool", "bool", 
"int", 
},"");
				CompileIUCmd(false, insertCmd,BandoRequisitiVarianteObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoRequisitiVarianteObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
				BandoRequisitiVarianteObj.RequisitoDiPresentazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_PRESENTAZIONE"]);
				BandoRequisitiVarianteObj.RequisitoDiIstruttoria = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_ISTRUTTORIA"]);
				}
				BandoRequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiVarianteObj.IsDirty = false;
				BandoRequisitiVarianteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoRequisitiVariante BandoRequisitiVarianteObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoRequisitiVarianteUpdate", new string[] {"IdBando", "CodTipo", "IdRequisito", 
"Obbligatorio", "RequisitoDiPresentazione", "RequisitoDiIstruttoria", 
"Ordine", 
}, new string[] {"int", "string", "int", 
"bool", "bool", "bool", 
"int", 
},"");
				CompileIUCmd(true, updateCmd,BandoRequisitiVarianteObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoRequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiVarianteObj.IsDirty = false;
				BandoRequisitiVarianteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoRequisitiVariante BandoRequisitiVarianteObj)
		{
			switch (BandoRequisitiVarianteObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoRequisitiVarianteObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoRequisitiVarianteObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoRequisitiVarianteObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoRequisitiVarianteUpdate", new string[] {"IdBando", "CodTipo", "IdRequisito", 
"Obbligatorio", "RequisitoDiPresentazione", "RequisitoDiIstruttoria", 
"Ordine", 
}, new string[] {"int", "string", "int", 
"bool", "bool", "bool", 
"int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoRequisitiVarianteInsert", new string[] {"IdBando", "CodTipo", "IdRequisito", 
"Obbligatorio", "RequisitoDiPresentazione", "RequisitoDiIstruttoria", 
"Ordine", 
}, new string[] {"int", "string", "int", 
"bool", "bool", "bool", 
"int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRequisitiVarianteDelete", new string[] {"IdBando", "CodTipo", "IdRequisito"}, new string[] {"int", "string", "int"},"");
				for (int i = 0; i < BandoRequisitiVarianteCollectionObj.Count; i++)
				{
					switch (BandoRequisitiVarianteCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoRequisitiVarianteCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoRequisitiVarianteCollectionObj[i].Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
									BandoRequisitiVarianteCollectionObj[i].RequisitoDiPresentazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_PRESENTAZIONE"]);
									BandoRequisitiVarianteCollectionObj[i].RequisitoDiIstruttoria = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_ISTRUTTORIA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoRequisitiVarianteCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoRequisitiVarianteCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BandoRequisitiVarianteCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)BandoRequisitiVarianteCollectionObj[i].CodTipo);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)BandoRequisitiVarianteCollectionObj[i].IdRequisito);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoRequisitiVarianteCollectionObj.Count; i++)
				{
					if ((BandoRequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoRequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoRequisitiVarianteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoRequisitiVarianteCollectionObj[i].IsDirty = false;
						BandoRequisitiVarianteCollectionObj[i].IsPersistent = true;
					}
					if ((BandoRequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoRequisitiVarianteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoRequisitiVarianteCollectionObj[i].IsDirty = false;
						BandoRequisitiVarianteCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoRequisitiVariante BandoRequisitiVarianteObj)
		{
			int returnValue = 0;
			if (BandoRequisitiVarianteObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoRequisitiVarianteObj.IdBando, BandoRequisitiVarianteObj.CodTipo, BandoRequisitiVarianteObj.IdRequisito);
			}
			BandoRequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoRequisitiVarianteObj.IsDirty = false;
			BandoRequisitiVarianteObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, string CodTipoValue, int IdRequisitoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRequisitiVarianteDelete", new string[] {"IdBando", "CodTipo", "IdRequisito"}, new string[] {"int", "string", "int"},"");
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

		public static int DeleteCollection(DbProvider db, BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRequisitiVarianteDelete", new string[] {"IdBando", "CodTipo", "IdRequisito"}, new string[] {"int", "string", "int"},"");
				for (int i = 0; i < BandoRequisitiVarianteCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", BandoRequisitiVarianteCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", BandoRequisitiVarianteCollectionObj[i].CodTipo);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", BandoRequisitiVarianteCollectionObj[i].IdRequisito);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoRequisitiVarianteCollectionObj.Count; i++)
				{
					if ((BandoRequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoRequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoRequisitiVarianteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoRequisitiVarianteCollectionObj[i].IsDirty = false;
						BandoRequisitiVarianteCollectionObj[i].IsPersistent = false;
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
		public static BandoRequisitiVariante GetById(DbProvider db, int IdBandoValue, string CodTipoValue, int IdRequisitoValue)
		{
			BandoRequisitiVariante BandoRequisitiVarianteObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoRequisitiVarianteGetById", new string[] {"IdBando", "CodTipo", "IdRequisito"}, new string[] {"int", "string", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoRequisitiVarianteObj = GetFromDatareader(db);
				BandoRequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiVarianteObj.IsDirty = false;
				BandoRequisitiVarianteObj.IsPersistent = true;
			}
			db.Close();
			return BandoRequisitiVarianteObj;
		}

		//getFromDatareader
		public static BandoRequisitiVariante GetFromDatareader(DbProvider db)
		{
			BandoRequisitiVariante BandoRequisitiVarianteObj = new BandoRequisitiVariante();
			BandoRequisitiVarianteObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoRequisitiVarianteObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			BandoRequisitiVarianteObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
			BandoRequisitiVarianteObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			BandoRequisitiVarianteObj.RequisitoDiPresentazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_PRESENTAZIONE"]);
			BandoRequisitiVarianteObj.RequisitoDiIstruttoria = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REQUISITO_DI_ISTRUTTORIA"]);
			BandoRequisitiVarianteObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			BandoRequisitiVarianteObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			BandoRequisitiVarianteObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoRequisitiVarianteObj.QueryEval = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_EVAL"]);
			BandoRequisitiVarianteObj.QueryInsert = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_INSERT"]);
			BandoRequisitiVarianteObj.ValMinimo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VAL_MINIMO"]);
			BandoRequisitiVarianteObj.ValMassimo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VAL_MASSIMO"]);
			BandoRequisitiVarianteObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			BandoRequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoRequisitiVarianteObj.IsDirty = false;
			BandoRequisitiVarianteObj.IsPersistent = true;
			return BandoRequisitiVarianteObj;
		}

		//Find Select

		public static BandoRequisitiVarianteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, 
SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, SiarLibrary.NullTypes.BoolNT RequisitoDiPresentazioneEqualThis, SiarLibrary.NullTypes.BoolNT RequisitoDiIstruttoriaEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionObj = new BandoRequisitiVarianteCollection();

			IDbCommand findCmd = db.InitCmd("Zbandorequisitivariantefindselect", new string[] {"IdBandoequalthis", "CodTipoequalthis", "IdRequisitoequalthis", 
"Obbligatorioequalthis", "RequisitoDiPresentazioneequalthis", "RequisitoDiIstruttoriaequalthis", 
"Ordineequalthis"}, new string[] {"int", "string", "int", 
"bool", "bool", "bool", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RequisitoDiPresentazioneequalthis", RequisitoDiPresentazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RequisitoDiIstruttoriaequalthis", RequisitoDiIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			BandoRequisitiVariante BandoRequisitiVarianteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoRequisitiVarianteObj = GetFromDatareader(db);
				BandoRequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiVarianteObj.IsDirty = false;
				BandoRequisitiVarianteObj.IsPersistent = true;
				BandoRequisitiVarianteCollectionObj.Add(BandoRequisitiVarianteObj);
			}
			db.Close();
			return BandoRequisitiVarianteCollectionObj;
		}

		//Find Find

		public static BandoRequisitiVarianteCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis)

		{

			BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionObj = new BandoRequisitiVarianteCollection();

			IDbCommand findCmd = db.InitCmd("Zbandorequisitivariantefindfind", new string[] {"IdBandoequalthis", "CodTipoequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			BandoRequisitiVariante BandoRequisitiVarianteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoRequisitiVarianteObj = GetFromDatareader(db);
				BandoRequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRequisitiVarianteObj.IsDirty = false;
				BandoRequisitiVarianteObj.IsPersistent = true;
				BandoRequisitiVarianteCollectionObj.Add(BandoRequisitiVarianteObj);
			}
			db.Close();
			return BandoRequisitiVarianteCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_REQUISITI_VARIANTE>
  <ViewName>vBANDO_REQUISITI_VARIANTE</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroProcedura>
      <REQUISITO_DI_PRESENTAZIONE>Equal</REQUISITO_DI_PRESENTAZIONE>
      <REQUISITO_DI_ISTRUTTORIA>Equal</REQUISITO_DI_ISTRUTTORIA>
    </FiltroProcedura>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_REQUISITI_VARIANTE>
*/