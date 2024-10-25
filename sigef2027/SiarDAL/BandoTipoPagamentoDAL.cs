using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoTipoPagamentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class BandoTipoPagamentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoTipoPagamento BandoTipoPagamentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoTipoPagamentoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", BandoTipoPagamentoObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaMax", BandoTipoPagamentoObj.QuotaMax);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaMin", BandoTipoPagamentoObj.QuotaMin);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoMax", BandoTipoPagamentoObj.ImportoMax);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoMin", BandoTipoPagamentoObj.ImportoMin);
			DbProvider.SetCmdParam(cmd,firstChar + "Numero", BandoTipoPagamentoObj.Numero);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoPolizza", BandoTipoPagamentoObj.CodTipoPolizza);
		}
		//Insert
		private static int Insert(DbProvider db, BandoTipoPagamento BandoTipoPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoTipoPagamentoInsert", new string[] {"IdBando", "CodTipo", "QuotaMax", 
"QuotaMin", "ImportoMax", "ImportoMin", 

"Numero", "CodTipoPolizza", }, new string[] {"int", "string", "decimal", 
"decimal", "decimal", "decimal", 

"int", "string", },"");
				CompileIUCmd(false, insertCmd,BandoTipoPagamentoObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				BandoTipoPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoPagamentoObj.IsDirty = false;
				BandoTipoPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoTipoPagamento BandoTipoPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoTipoPagamentoUpdate", new string[] {"IdBando", "CodTipo", "QuotaMax", 
"QuotaMin", "ImportoMax", "ImportoMin", 

"Numero", "CodTipoPolizza", }, new string[] {"int", "string", "decimal", 
"decimal", "decimal", "decimal", 

"int", "string", },"");
				CompileIUCmd(true, updateCmd,BandoTipoPagamentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoTipoPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoPagamentoObj.IsDirty = false;
				BandoTipoPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoTipoPagamento BandoTipoPagamentoObj)
		{
			switch (BandoTipoPagamentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoTipoPagamentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoTipoPagamentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoTipoPagamentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoTipoPagamentoCollection BandoTipoPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoTipoPagamentoUpdate", new string[] {"IdBando", "CodTipo", "QuotaMax", 
"QuotaMin", "ImportoMax", "ImportoMin", 

"Numero", "CodTipoPolizza", }, new string[] {"int", "string", "decimal", 
"decimal", "decimal", "decimal", 

"int", "string", },"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoTipoPagamentoInsert", new string[] {"IdBando", "CodTipo", "QuotaMax", 
"QuotaMin", "ImportoMax", "ImportoMin", 

"Numero", "CodTipoPolizza", }, new string[] {"int", "string", "decimal", 
"decimal", "decimal", "decimal", 

"int", "string", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoPagamentoDelete", new string[] {"IdBando", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < BandoTipoPagamentoCollectionObj.Count; i++)
				{
					switch (BandoTipoPagamentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoTipoPagamentoCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoTipoPagamentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoTipoPagamentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BandoTipoPagamentoCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)BandoTipoPagamentoCollectionObj[i].CodTipo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoTipoPagamentoCollectionObj.Count; i++)
				{
					if ((BandoTipoPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoTipoPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoTipoPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoTipoPagamentoCollectionObj[i].IsDirty = false;
						BandoTipoPagamentoCollectionObj[i].IsPersistent = true;
					}
					if ((BandoTipoPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoTipoPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoTipoPagamentoCollectionObj[i].IsDirty = false;
						BandoTipoPagamentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoTipoPagamento BandoTipoPagamentoObj)
		{
			int returnValue = 0;
			if (BandoTipoPagamentoObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoTipoPagamentoObj.IdBando, BandoTipoPagamentoObj.CodTipo);
			}
			BandoTipoPagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoTipoPagamentoObj.IsDirty = false;
			BandoTipoPagamentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, string CodTipoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoPagamentoDelete", new string[] {"IdBando", "CodTipo"}, new string[] {"int", "string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoTipoPagamentoCollection BandoTipoPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoPagamentoDelete", new string[] {"IdBando", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < BandoTipoPagamentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", BandoTipoPagamentoCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", BandoTipoPagamentoCollectionObj[i].CodTipo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoTipoPagamentoCollectionObj.Count; i++)
				{
					if ((BandoTipoPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoTipoPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoTipoPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoTipoPagamentoCollectionObj[i].IsDirty = false;
						BandoTipoPagamentoCollectionObj[i].IsPersistent = false;
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
		public static BandoTipoPagamento GetById(DbProvider db, int IdBandoValue, string CodTipoValue)
		{
			BandoTipoPagamento BandoTipoPagamentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoTipoPagamentoGetById", new string[] {"IdBando", "CodTipo"}, new string[] {"int", "string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoTipoPagamentoObj = GetFromDatareader(db);
				BandoTipoPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoPagamentoObj.IsDirty = false;
				BandoTipoPagamentoObj.IsPersistent = true;
			}
			db.Close();
			return BandoTipoPagamentoObj;
		}

		//getFromDatareader
		public static BandoTipoPagamento GetFromDatareader(DbProvider db)
		{
			BandoTipoPagamento BandoTipoPagamentoObj = new BandoTipoPagamento();
			BandoTipoPagamentoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoTipoPagamentoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			BandoTipoPagamentoObj.QuotaMax = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_MAX"]);
			BandoTipoPagamentoObj.QuotaMin = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_MIN"]);
			BandoTipoPagamentoObj.ImportoMax = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_MAX"]);
			BandoTipoPagamentoObj.ImportoMin = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_MIN"]);
			BandoTipoPagamentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoTipoPagamentoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			BandoTipoPagamentoObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
			BandoTipoPagamentoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			BandoTipoPagamentoObj.Numero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO"]);
			BandoTipoPagamentoObj.CodTipoPolizza = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_POLIZZA"]);
			BandoTipoPagamentoObj.TipoPolizza = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_POLIZZA"]);
			BandoTipoPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoTipoPagamentoObj.IsDirty = false;
			BandoTipoPagamentoObj.IsPersistent = true;
			return BandoTipoPagamentoObj;
		}

		//Find Select

		public static BandoTipoPagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaMaxEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuotaMinEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoMaxEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoMinEqualThis, 
SiarLibrary.NullTypes.IntNT NumeroEqualThis, SiarLibrary.NullTypes.StringNT CodTipoPolizzaEqualThis)

		{

			BandoTipoPagamentoCollection BandoTipoPagamentoCollectionObj = new BandoTipoPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zbandotipopagamentofindselect", new string[] {"IdBandoequalthis", "CodTipoequalthis", "QuotaMaxequalthis", 
"QuotaMinequalthis", "ImportoMaxequalthis", "ImportoMinequalthis", 
"Numeroequalthis", "CodTipoPolizzaequalthis"}, new string[] {"int", "string", "decimal", 
"decimal", "decimal", "decimal", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaMaxequalthis", QuotaMaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaMinequalthis", QuotaMinEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoMaxequalthis", ImportoMaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoMinequalthis", ImportoMinEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoPolizzaequalthis", CodTipoPolizzaEqualThis);
			BandoTipoPagamento BandoTipoPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoTipoPagamentoObj = GetFromDatareader(db);
				BandoTipoPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoPagamentoObj.IsDirty = false;
				BandoTipoPagamentoObj.IsPersistent = true;
				BandoTipoPagamentoCollectionObj.Add(BandoTipoPagamentoObj);
			}
			db.Close();
			return BandoTipoPagamentoCollectionObj;
		}

		//Find Find

		public static BandoTipoPagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis)

		{

			BandoTipoPagamentoCollection BandoTipoPagamentoCollectionObj = new BandoTipoPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zbandotipopagamentofindfind", new string[] {"IdBandoequalthis", "CodTipoequalthis", "CodFaseequalthis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			BandoTipoPagamento BandoTipoPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoTipoPagamentoObj = GetFromDatareader(db);
				BandoTipoPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoPagamentoObj.IsDirty = false;
				BandoTipoPagamentoObj.IsPersistent = true;
				BandoTipoPagamentoCollectionObj.Add(BandoTipoPagamentoObj);
			}
			db.Close();
			return BandoTipoPagamentoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_TIPO_PAGAMENTO>
  <ViewName>vBANDO_TIPO_PAGAMENTO</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_TIPO_PAGAMENTO>
*/