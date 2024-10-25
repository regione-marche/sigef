using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VariantiEsitiRequisitiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class VariantiEsitiRequisitiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VariantiEsitiRequisiti VariantiEsitiRequisitiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", VariantiEsitiRequisitiObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRequisito", VariantiEsitiRequisitiObj.IdRequisito);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsito", VariantiEsitiRequisitiObj.CodEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", VariantiEsitiRequisitiObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatore", VariantiEsitiRequisitiObj.CfOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsitoIstruttore", VariantiEsitiRequisitiObj.CodEsitoIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", VariantiEsitiRequisitiObj.DataValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Istruttore", VariantiEsitiRequisitiObj.Istruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", VariantiEsitiRequisitiObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "EscludiDaComunicazione", VariantiEsitiRequisitiObj.EscludiDaComunicazione);
		}
		//Insert
		private static int Insert(DbProvider db, VariantiEsitiRequisiti VariantiEsitiRequisitiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZVariantiEsitiRequisitiInsert", new string[] {"IdVariante", "IdRequisito", "CodEsito", 
"Data", "CfOperatore", "CodEsitoIstruttore", 
"DataValutazione", "Istruttore", "Note", 
"EscludiDaComunicazione", 

}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"bool", 

},"");
				CompileIUCmd(false, insertCmd,VariantiEsitiRequisitiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				VariantiEsitiRequisitiObj.EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
				}
				VariantiEsitiRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiEsitiRequisitiObj.IsDirty = false;
				VariantiEsitiRequisitiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VariantiEsitiRequisiti VariantiEsitiRequisitiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiEsitiRequisitiUpdate", new string[] {"IdVariante", "IdRequisito", "CodEsito", 
"Data", "CfOperatore", "CodEsitoIstruttore", 
"DataValutazione", "Istruttore", "Note", 
"EscludiDaComunicazione", 

}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"bool", 

},"");
				CompileIUCmd(true, updateCmd,VariantiEsitiRequisitiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				VariantiEsitiRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiEsitiRequisitiObj.IsDirty = false;
				VariantiEsitiRequisitiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VariantiEsitiRequisiti VariantiEsitiRequisitiObj)
		{
			switch (VariantiEsitiRequisitiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, VariantiEsitiRequisitiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, VariantiEsitiRequisitiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,VariantiEsitiRequisitiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiEsitiRequisitiUpdate", new string[] {"IdVariante", "IdRequisito", "CodEsito", 
"Data", "CfOperatore", "CodEsitoIstruttore", 
"DataValutazione", "Istruttore", "Note", 
"EscludiDaComunicazione", 

}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"bool", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZVariantiEsitiRequisitiInsert", new string[] {"IdVariante", "IdRequisito", "CodEsito", 
"Data", "CfOperatore", "CodEsitoIstruttore", 
"DataValutazione", "Istruttore", "Note", 
"EscludiDaComunicazione", 

}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"bool", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiEsitiRequisitiDelete", new string[] {"IdVariante", "IdRequisito"}, new string[] {"int", "int"},"");
				for (int i = 0; i < VariantiEsitiRequisitiCollectionObj.Count; i++)
				{
					switch (VariantiEsitiRequisitiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,VariantiEsitiRequisitiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VariantiEsitiRequisitiCollectionObj[i].EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,VariantiEsitiRequisitiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (VariantiEsitiRequisitiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)VariantiEsitiRequisitiCollectionObj[i].IdVariante);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)VariantiEsitiRequisitiCollectionObj[i].IdRequisito);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VariantiEsitiRequisitiCollectionObj.Count; i++)
				{
					if ((VariantiEsitiRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiEsitiRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiEsitiRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VariantiEsitiRequisitiCollectionObj[i].IsDirty = false;
						VariantiEsitiRequisitiCollectionObj[i].IsPersistent = true;
					}
					if ((VariantiEsitiRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VariantiEsitiRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiEsitiRequisitiCollectionObj[i].IsDirty = false;
						VariantiEsitiRequisitiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VariantiEsitiRequisiti VariantiEsitiRequisitiObj)
		{
			int returnValue = 0;
			if (VariantiEsitiRequisitiObj.IsPersistent) 
			{
				returnValue = Delete(db, VariantiEsitiRequisitiObj.IdVariante, VariantiEsitiRequisitiObj.IdRequisito);
			}
			VariantiEsitiRequisitiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VariantiEsitiRequisitiObj.IsDirty = false;
			VariantiEsitiRequisitiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdVarianteValue, int IdRequisitoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiEsitiRequisitiDelete", new string[] {"IdVariante", "IdRequisito"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)IdVarianteValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiEsitiRequisitiDelete", new string[] {"IdVariante", "IdRequisito"}, new string[] {"int", "int"},"");
				for (int i = 0; i < VariantiEsitiRequisitiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", VariantiEsitiRequisitiCollectionObj[i].IdVariante);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRequisito", VariantiEsitiRequisitiCollectionObj[i].IdRequisito);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VariantiEsitiRequisitiCollectionObj.Count; i++)
				{
					if ((VariantiEsitiRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiEsitiRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiEsitiRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiEsitiRequisitiCollectionObj[i].IsDirty = false;
						VariantiEsitiRequisitiCollectionObj[i].IsPersistent = false;
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
		public static VariantiEsitiRequisiti GetById(DbProvider db, int IdVarianteValue, int IdRequisitoValue)
		{
			VariantiEsitiRequisiti VariantiEsitiRequisitiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZVariantiEsitiRequisitiGetById", new string[] {"IdVariante", "IdRequisito"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)IdVarianteValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VariantiEsitiRequisitiObj = GetFromDatareader(db);
				VariantiEsitiRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiEsitiRequisitiObj.IsDirty = false;
				VariantiEsitiRequisitiObj.IsPersistent = true;
			}
			db.Close();
			return VariantiEsitiRequisitiObj;
		}

		//getFromDatareader
		public static VariantiEsitiRequisiti GetFromDatareader(DbProvider db)
		{
			VariantiEsitiRequisiti VariantiEsitiRequisitiObj = new VariantiEsitiRequisiti();
			VariantiEsitiRequisitiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			VariantiEsitiRequisitiObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
			VariantiEsitiRequisitiObj.CodEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO"]);
			VariantiEsitiRequisitiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			VariantiEsitiRequisitiObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			VariantiEsitiRequisitiObj.CodEsitoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO_ISTRUTTORE"]);
			VariantiEsitiRequisitiObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			VariantiEsitiRequisitiObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
			VariantiEsitiRequisitiObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			VariantiEsitiRequisitiObj.EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
			VariantiEsitiRequisitiObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			VariantiEsitiRequisitiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VariantiEsitiRequisitiObj.QueryEval = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_EVAL"]);
			VariantiEsitiRequisitiObj.QueryInsert = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_INSERT"]);
			VariantiEsitiRequisitiObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
			VariantiEsitiRequisitiObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
			VariantiEsitiRequisitiObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			VariantiEsitiRequisitiObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
			VariantiEsitiRequisitiObj.EsitoPositivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO"]);
			VariantiEsitiRequisitiObj.EsitoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO_ISTRUTTORE"]);
			VariantiEsitiRequisitiObj.EsitoPositivoIstruttore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO_ISTRUTTORE"]);
			VariantiEsitiRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VariantiEsitiRequisitiObj.IsDirty = false;
			VariantiEsitiRequisitiObj.IsPersistent = true;
			return VariantiEsitiRequisitiObj;
		}

		//Find Select

		public static VariantiEsitiRequisitiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoIstruttoreEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis, SiarLibrary.NullTypes.BoolNT EscludiDaComunicazioneEqualThis)

		{

			VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionObj = new VariantiEsitiRequisitiCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantiesitirequisitifindselect", new string[] {"IdVarianteequalthis", "IdRequisitoequalthis", "CodEsitoequalthis", 
"Dataequalthis", "CfOperatoreequalthis", "CodEsitoIstruttoreequalthis", 
"DataValutazioneequalthis", "Istruttoreequalthis", "EscludiDaComunicazioneequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoIstruttoreequalthis", CodEsitoIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EscludiDaComunicazioneequalthis", EscludiDaComunicazioneEqualThis);
			VariantiEsitiRequisiti VariantiEsitiRequisitiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiEsitiRequisitiObj = GetFromDatareader(db);
				VariantiEsitiRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiEsitiRequisitiObj.IsDirty = false;
				VariantiEsitiRequisitiObj.IsPersistent = true;
				VariantiEsitiRequisitiCollectionObj.Add(VariantiEsitiRequisitiObj);
			}
			db.Close();
			return VariantiEsitiRequisitiCollectionObj;
		}

		//Find Find

		public static VariantiEsitiRequisitiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis)

		{

			VariantiEsitiRequisitiCollection VariantiEsitiRequisitiCollectionObj = new VariantiEsitiRequisitiCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantiesitirequisitifindfind", new string[] {"IdVarianteequalthis", "IdRequisitoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
			VariantiEsitiRequisiti VariantiEsitiRequisitiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiEsitiRequisitiObj = GetFromDatareader(db);
				VariantiEsitiRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiEsitiRequisitiObj.IsDirty = false;
				VariantiEsitiRequisitiObj.IsPersistent = true;
				VariantiEsitiRequisitiCollectionObj.Add(VariantiEsitiRequisitiObj);
			}
			db.Close();
			return VariantiEsitiRequisitiCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_ESITI_REQUISITI>
  <ViewName>vVARIANTI_ESITI_REQUISITI</ViewName>
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
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_REQUISITO>Equal</ID_REQUISITO>
    </Find>
  </Finds>
  <Filters>
    <FiltroEsitoPositivo>
      <ESITO_POSITIVO>Equal</ESITO_POSITIVO>
      <ESITO_POSITIVO_ISTRUTTORE>Equal</ESITO_POSITIVO_ISTRUTTORE>
    </FiltroEsitoPositivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_ESITI_REQUISITI>
*/