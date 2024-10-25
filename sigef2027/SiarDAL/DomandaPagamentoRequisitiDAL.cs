using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DomandaPagamentoRequisitiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class DomandaPagamentoRequisitiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", DomandaPagamentoRequisitiObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRequisito", DomandaPagamentoRequisitiObj.IdRequisito);
			DbProvider.SetCmdParam(cmd,firstChar + "IdValore", DomandaPagamentoRequisitiObj.IdValore);
			DbProvider.SetCmdParam(cmd,firstChar + "ValNumerico", DomandaPagamentoRequisitiObj.ValNumerico);
			DbProvider.SetCmdParam(cmd,firstChar + "ValData", DomandaPagamentoRequisitiObj.ValData);
			DbProvider.SetCmdParam(cmd,firstChar + "ValTesto", DomandaPagamentoRequisitiObj.ValTesto);
			DbProvider.SetCmdParam(cmd,firstChar + "Esito", DomandaPagamentoRequisitiObj.Esito);
			DbProvider.SetCmdParam(cmd,firstChar + "DataEsito", DomandaPagamentoRequisitiObj.DataEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "Selezionato", DomandaPagamentoRequisitiObj.Selezionato);
		}
		//Insert
		private static int Insert(DbProvider db, DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDomandaPagamentoRequisitiInsert", new string[] {"IdDomandaPagamento", "IdRequisito", "IdValore", 
"ValNumerico", "ValData", "ValTesto", 
"Esito", "DataEsito", 



"Selezionato"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 
"string", "DateTime", 



"bool"},"");
				CompileIUCmd(false, insertCmd,DomandaPagamentoRequisitiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				DomandaPagamentoRequisitiObj.Selezionato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATO"]);
				}
				DomandaPagamentoRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoRequisitiObj.IsDirty = false;
				DomandaPagamentoRequisitiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaPagamentoRequisitiUpdate", new string[] {"IdDomandaPagamento", "IdRequisito", "IdValore", 
"ValNumerico", "ValData", "ValTesto", 
"Esito", "DataEsito", 



"Selezionato"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 
"string", "DateTime", 



"bool"},"");
				CompileIUCmd(true, updateCmd,DomandaPagamentoRequisitiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				DomandaPagamentoRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoRequisitiObj.IsDirty = false;
				DomandaPagamentoRequisitiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj)
		{
			switch (DomandaPagamentoRequisitiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DomandaPagamentoRequisitiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DomandaPagamentoRequisitiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DomandaPagamentoRequisitiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaPagamentoRequisitiUpdate", new string[] {"IdDomandaPagamento", "IdRequisito", "IdValore", 
"ValNumerico", "ValData", "ValTesto", 
"Esito", "DataEsito", 



"Selezionato"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 
"string", "DateTime", 



"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDomandaPagamentoRequisitiInsert", new string[] {"IdDomandaPagamento", "IdRequisito", "IdValore", 
"ValNumerico", "ValData", "ValTesto", 
"Esito", "DataEsito", 



"Selezionato"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 
"string", "DateTime", 



"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoRequisitiDelete", new string[] {"IdDomandaPagamento", "IdRequisito"}, new string[] {"int", "int"},"");
				for (int i = 0; i < DomandaPagamentoRequisitiCollectionObj.Count; i++)
				{
					switch (DomandaPagamentoRequisitiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DomandaPagamentoRequisitiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DomandaPagamentoRequisitiCollectionObj[i].Selezionato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DomandaPagamentoRequisitiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DomandaPagamentoRequisitiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)DomandaPagamentoRequisitiCollectionObj[i].IdDomandaPagamento);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)DomandaPagamentoRequisitiCollectionObj[i].IdRequisito);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DomandaPagamentoRequisitiCollectionObj.Count; i++)
				{
					if ((DomandaPagamentoRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaPagamentoRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DomandaPagamentoRequisitiCollectionObj[i].IsDirty = false;
						DomandaPagamentoRequisitiCollectionObj[i].IsPersistent = true;
					}
					if ((DomandaPagamentoRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DomandaPagamentoRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaPagamentoRequisitiCollectionObj[i].IsDirty = false;
						DomandaPagamentoRequisitiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj)
		{
			int returnValue = 0;
			if (DomandaPagamentoRequisitiObj.IsPersistent) 
			{
				returnValue = Delete(db, DomandaPagamentoRequisitiObj.IdDomandaPagamento, DomandaPagamentoRequisitiObj.IdRequisito);
			}
			DomandaPagamentoRequisitiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DomandaPagamentoRequisitiObj.IsDirty = false;
			DomandaPagamentoRequisitiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaPagamentoValue, int IdRequisitoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoRequisitiDelete", new string[] {"IdDomandaPagamento", "IdRequisito"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoRequisitiDelete", new string[] {"IdDomandaPagamento", "IdRequisito"}, new string[] {"int", "int"},"");
				for (int i = 0; i < DomandaPagamentoRequisitiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", DomandaPagamentoRequisitiCollectionObj[i].IdDomandaPagamento);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", DomandaPagamentoRequisitiCollectionObj[i].IdRequisito);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DomandaPagamentoRequisitiCollectionObj.Count; i++)
				{
					if ((DomandaPagamentoRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaPagamentoRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaPagamentoRequisitiCollectionObj[i].IsDirty = false;
						DomandaPagamentoRequisitiCollectionObj[i].IsPersistent = false;
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
		public static DomandaPagamentoRequisiti GetById(DbProvider db, int IdDomandaPagamentoValue, int IdRequisitoValue)
		{
			DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDomandaPagamentoRequisitiGetById", new string[] {"IdDomandaPagamento", "IdRequisito"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DomandaPagamentoRequisitiObj = GetFromDatareader(db);
				DomandaPagamentoRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoRequisitiObj.IsDirty = false;
				DomandaPagamentoRequisitiObj.IsPersistent = true;
			}
			db.Close();
			return DomandaPagamentoRequisitiObj;
		}

		//getFromDatareader
		public static DomandaPagamentoRequisiti GetFromDatareader(DbProvider db)
		{
			DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj = new DomandaPagamentoRequisiti();
			DomandaPagamentoRequisitiObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			DomandaPagamentoRequisitiObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
			DomandaPagamentoRequisitiObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
			DomandaPagamentoRequisitiObj.ValNumerico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VAL_NUMERICO"]);
			DomandaPagamentoRequisitiObj.ValData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VAL_DATA"]);
			DomandaPagamentoRequisitiObj.ValTesto = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_TESTO"]);
			DomandaPagamentoRequisitiObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
			DomandaPagamentoRequisitiObj.DataEsito = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ESITO"]);
			DomandaPagamentoRequisitiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			DomandaPagamentoRequisitiObj.Plurivalore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURIVALORE"]);
			DomandaPagamentoRequisitiObj.Numerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NUMERICO"]);
			DomandaPagamentoRequisitiObj.Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
			DomandaPagamentoRequisitiObj.TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
			DomandaPagamentoRequisitiObj.TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
			DomandaPagamentoRequisitiObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			DomandaPagamentoRequisitiObj.QueryEval = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_EVAL"]);
			DomandaPagamentoRequisitiObj.QueryInsert = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_INSERT"]);
			DomandaPagamentoRequisitiObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			DomandaPagamentoRequisitiObj.CodiceValore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_VALORE"]);
			DomandaPagamentoRequisitiObj.DescrizioneValore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_VALORE"]);
			DomandaPagamentoRequisitiObj.Selezionato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATO"]);
			DomandaPagamentoRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DomandaPagamentoRequisitiObj.IsDirty = false;
			DomandaPagamentoRequisitiObj.IsPersistent = true;
			return DomandaPagamentoRequisitiObj;
		}

		//Find Select

		public static DomandaPagamentoRequisitiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, 
SiarLibrary.NullTypes.DecimalNT ValNumericoEqualThis, SiarLibrary.NullTypes.DatetimeNT ValDataEqualThis, SiarLibrary.NullTypes.StringNT ValTestoEqualThis, 
SiarLibrary.NullTypes.StringNT EsitoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEsitoEqualThis, SiarLibrary.NullTypes.BoolNT SelezionatoEqualThis)

		{

			DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionObj = new DomandaPagamentoRequisitiCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandapagamentorequisitifindselect", new string[] {"IdDomandaPagamentoequalthis", "IdRequisitoequalthis", "IdValoreequalthis", 
"ValNumericoequalthis", "ValDataequalthis", "ValTestoequalthis", 
"Esitoequalthis", "DataEsitoequalthis", "Selezionatoequalthis"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "string", 
"string", "DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValNumericoequalthis", ValNumericoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValDataequalthis", ValDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValTestoequalthis", ValTestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataEsitoequalthis", DataEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Selezionatoequalthis", SelezionatoEqualThis);
			DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaPagamentoRequisitiObj = GetFromDatareader(db);
				DomandaPagamentoRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoRequisitiObj.IsDirty = false;
				DomandaPagamentoRequisitiObj.IsPersistent = true;
				DomandaPagamentoRequisitiCollectionObj.Add(DomandaPagamentoRequisitiObj);
			}
			db.Close();
			return DomandaPagamentoRequisitiCollectionObj;
		}

		//Find Find

		public static DomandaPagamentoRequisitiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.StringNT MisuraLikeThis)

		{

			DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionObj = new DomandaPagamentoRequisitiCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandapagamentorequisitifindfind", new string[] {"IdDomandaPagamentoequalthis", "IdRequisitoequalthis", "Misuralikethis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuralikethis", MisuraLikeThis);
			DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaPagamentoRequisitiObj = GetFromDatareader(db);
				DomandaPagamentoRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoRequisitiObj.IsDirty = false;
				DomandaPagamentoRequisitiObj.IsPersistent = true;
				DomandaPagamentoRequisitiCollectionObj.Add(DomandaPagamentoRequisitiObj);
			}
			db.Close();
			return DomandaPagamentoRequisitiCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_PAGAMENTO_REQUISITI>
  <ViewName>vDOMANDA_REQUISITI_PAGAMENTO</ViewName>
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
</DOMANDA_PAGAMENTO_REQUISITI>
*/