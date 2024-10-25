using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DomandaDiPagamentoSegnatureDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class DomandaDiPagamentoSegnatureDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", DomandaDiPagamentoSegnatureObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", DomandaDiPagamentoSegnatureObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", DomandaDiPagamentoSegnatureObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", DomandaDiPagamentoSegnatureObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", DomandaDiPagamentoSegnatureObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Motivazione", DomandaDiPagamentoSegnatureObj.Motivazione);
			DbProvider.SetCmdParam(cmd,firstChar + "RiapriDomanda", DomandaDiPagamentoSegnatureObj.RiapriDomanda);
		}
		//Insert
		private static int Insert(DbProvider db, DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDomandaDiPagamentoSegnatureInsert", new string[] {"IdDomandaPagamento", "CodTipo", "Data", 
"Operatore", "Segnatura", "Motivazione", 
"RiapriDomanda"}, new string[] {"int", "string", "DateTime", 
"string", "string", "string", 
"bool"},"");
				CompileIUCmd(false, insertCmd,DomandaDiPagamentoSegnatureObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				DomandaDiPagamentoSegnatureObj.RiapriDomanda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPRI_DOMANDA"]);
				}
				DomandaDiPagamentoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoSegnatureObj.IsDirty = false;
				DomandaDiPagamentoSegnatureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaDiPagamentoSegnatureUpdate", new string[] {"IdDomandaPagamento", "CodTipo", "Data", 
"Operatore", "Segnatura", "Motivazione", 
"RiapriDomanda"}, new string[] {"int", "string", "DateTime", 
"string", "string", "string", 
"bool"},"");
				CompileIUCmd(true, updateCmd,DomandaDiPagamentoSegnatureObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				DomandaDiPagamentoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoSegnatureObj.IsDirty = false;
				DomandaDiPagamentoSegnatureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj)
		{
			switch (DomandaDiPagamentoSegnatureObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DomandaDiPagamentoSegnatureObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DomandaDiPagamentoSegnatureObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DomandaDiPagamentoSegnatureObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaDiPagamentoSegnatureUpdate", new string[] {"IdDomandaPagamento", "CodTipo", "Data", 
"Operatore", "Segnatura", "Motivazione", 
"RiapriDomanda"}, new string[] {"int", "string", "DateTime", 
"string", "string", "string", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDomandaDiPagamentoSegnatureInsert", new string[] {"IdDomandaPagamento", "CodTipo", "Data", 
"Operatore", "Segnatura", "Motivazione", 
"RiapriDomanda"}, new string[] {"int", "string", "DateTime", 
"string", "string", "string", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaDiPagamentoSegnatureDelete", new string[] {"IdDomandaPagamento", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < DomandaDiPagamentoSegnatureCollectionObj.Count; i++)
				{
					switch (DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DomandaDiPagamentoSegnatureCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DomandaDiPagamentoSegnatureCollectionObj[i].RiapriDomanda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPRI_DOMANDA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DomandaDiPagamentoSegnatureCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DomandaDiPagamentoSegnatureCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)DomandaDiPagamentoSegnatureCollectionObj[i].IdDomandaPagamento);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)DomandaDiPagamentoSegnatureCollectionObj[i].CodTipo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DomandaDiPagamentoSegnatureCollectionObj.Count; i++)
				{
					if ((DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DomandaDiPagamentoSegnatureCollectionObj[i].IsDirty = false;
						DomandaDiPagamentoSegnatureCollectionObj[i].IsPersistent = true;
					}
					if ((DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaDiPagamentoSegnatureCollectionObj[i].IsDirty = false;
						DomandaDiPagamentoSegnatureCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj)
		{
			int returnValue = 0;
			if (DomandaDiPagamentoSegnatureObj.IsPersistent) 
			{
				returnValue = Delete(db, DomandaDiPagamentoSegnatureObj.IdDomandaPagamento, DomandaDiPagamentoSegnatureObj.CodTipo);
			}
			DomandaDiPagamentoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DomandaDiPagamentoSegnatureObj.IsDirty = false;
			DomandaDiPagamentoSegnatureObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaPagamentoValue, string CodTipoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaDiPagamentoSegnatureDelete", new string[] {"IdDomandaPagamento", "CodTipo"}, new string[] {"int", "string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaDiPagamentoSegnatureDelete", new string[] {"IdDomandaPagamento", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < DomandaDiPagamentoSegnatureCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", DomandaDiPagamentoSegnatureCollectionObj[i].IdDomandaPagamento);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", DomandaDiPagamentoSegnatureCollectionObj[i].CodTipo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DomandaDiPagamentoSegnatureCollectionObj.Count; i++)
				{
					if ((DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaDiPagamentoSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaDiPagamentoSegnatureCollectionObj[i].IsDirty = false;
						DomandaDiPagamentoSegnatureCollectionObj[i].IsPersistent = false;
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
		public static DomandaDiPagamentoSegnature GetById(DbProvider db, int IdDomandaPagamentoValue, string CodTipoValue)
		{
			DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDomandaDiPagamentoSegnatureGetById", new string[] {"IdDomandaPagamento", "CodTipo"}, new string[] {"int", "string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DomandaDiPagamentoSegnatureObj = GetFromDatareader(db);
				DomandaDiPagamentoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoSegnatureObj.IsDirty = false;
				DomandaDiPagamentoSegnatureObj.IsPersistent = true;
			}
			db.Close();
			return DomandaDiPagamentoSegnatureObj;
		}

		//getFromDatareader
		public static DomandaDiPagamentoSegnature GetFromDatareader(DbProvider db)
		{
			DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj = new DomandaDiPagamentoSegnature();
			DomandaDiPagamentoSegnatureObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			DomandaDiPagamentoSegnatureObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			DomandaDiPagamentoSegnatureObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			DomandaDiPagamentoSegnatureObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			DomandaDiPagamentoSegnatureObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			DomandaDiPagamentoSegnatureObj.Motivazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["MOTIVAZIONE"]);
			DomandaDiPagamentoSegnatureObj.RiapriDomanda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPRI_DOMANDA"]);
			DomandaDiPagamentoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DomandaDiPagamentoSegnatureObj.IsDirty = false;
			DomandaDiPagamentoSegnatureObj.IsPersistent = true;
			return DomandaDiPagamentoSegnatureObj;
		}

		//Find Select

		public static DomandaDiPagamentoSegnatureCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.BoolNT RiapriDomandaEqualThis)

		{

			DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionObj = new DomandaDiPagamentoSegnatureCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandadipagamentosegnaturefindselect", new string[] {"IdDomandaPagamentoequalthis", "CodTipoequalthis", "Dataequalthis", 
"Operatoreequalthis", "Segnaturaequalthis", "RiapriDomandaequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RiapriDomandaequalthis", RiapriDomandaEqualThis);
			DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaDiPagamentoSegnatureObj = GetFromDatareader(db);
				DomandaDiPagamentoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoSegnatureObj.IsDirty = false;
				DomandaDiPagamentoSegnatureObj.IsPersistent = true;
				DomandaDiPagamentoSegnatureCollectionObj.Add(DomandaDiPagamentoSegnatureObj);
			}
			db.Close();
			return DomandaDiPagamentoSegnatureCollectionObj;
		}

		//Find Find

		public static DomandaDiPagamentoSegnatureCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.BoolNT RiapriDomandaEqualThis)

		{

			DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionObj = new DomandaDiPagamentoSegnatureCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandadipagamentosegnaturefindfind", new string[] {"IdDomandaPagamentoequalthis", "CodTipoequalthis", "RiapriDomandaequalthis"}, new string[] {"int", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RiapriDomandaequalthis", RiapriDomandaEqualThis);
			DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaDiPagamentoSegnatureObj = GetFromDatareader(db);
				DomandaDiPagamentoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoSegnatureObj.IsDirty = false;
				DomandaDiPagamentoSegnatureObj.IsPersistent = true;
				DomandaDiPagamentoSegnatureCollectionObj.Add(DomandaDiPagamentoSegnatureObj);
			}
			db.Close();
			return DomandaDiPagamentoSegnatureCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_DI_PAGAMENTO_SEGNATURE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_DOMANDA>Equal</RIAPRI_DOMANDA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_DOMANDA>Equal</RIAPRI_DOMANDA>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOMANDA_DI_PAGAMENTO_SEGNATURE>
*/