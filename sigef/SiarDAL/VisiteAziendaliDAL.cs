using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VisiteAziendaliDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class VisiteAziendaliDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VisiteAziendali VisiteAziendaliObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdVisita", VisiteAziendaliObj.IdVisita);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", VisiteAziendaliObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", VisiteAziendaliObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", VisiteAziendaliObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataApertura", VisiteAziendaliObj.DataApertura);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreApertura", VisiteAziendaliObj.OperatoreApertura);
			DbProvider.SetCmdParam(cmd,firstChar + "ControlloConcluso", VisiteAziendaliObj.ControlloConcluso);
			DbProvider.SetCmdParam(cmd,firstChar + "DataChiusura", VisiteAziendaliObj.DataChiusura);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreChiusura", VisiteAziendaliObj.OperatoreChiusura);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaVerbale", VisiteAziendaliObj.SegnaturaVerbale);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaEroa", VisiteAziendaliObj.IdDomandaEroa);
		}
		//Insert
		private static int Insert(DbProvider db, VisiteAziendali VisiteAziendaliObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZVisiteAziendaliInsert", new string[] {"IdDomandaPagamento", "IdImpresa", 
"CodTipo", "DataApertura", "OperatoreApertura", 
"ControlloConcluso", "DataChiusura", "OperatoreChiusura", 
"SegnaturaVerbale", 

"IdDomandaEroa"}, new string[] {"int", "int", 
"string", "DateTime", "string", 
"bool", "DateTime", "string", 
"string", 

"int"},"");
				CompileIUCmd(false, insertCmd,VisiteAziendaliObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				VisiteAziendaliObj.IdVisita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VISITA"]);
				VisiteAziendaliObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
				}
				VisiteAziendaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VisiteAziendaliObj.IsDirty = false;
				VisiteAziendaliObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VisiteAziendali VisiteAziendaliObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVisiteAziendaliUpdate", new string[] {"IdVisita", "IdDomandaPagamento", "IdImpresa", 
"CodTipo", "DataApertura", "OperatoreApertura", 
"ControlloConcluso", "DataChiusura", "OperatoreChiusura", 
"SegnaturaVerbale", 

"IdDomandaEroa"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"bool", "DateTime", "string", 
"string", 

"int"},"");
				CompileIUCmd(true, updateCmd,VisiteAziendaliObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				VisiteAziendaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VisiteAziendaliObj.IsDirty = false;
				VisiteAziendaliObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VisiteAziendali VisiteAziendaliObj)
		{
			switch (VisiteAziendaliObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, VisiteAziendaliObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, VisiteAziendaliObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,VisiteAziendaliObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VisiteAziendaliCollection VisiteAziendaliCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVisiteAziendaliUpdate", new string[] {"IdVisita", "IdDomandaPagamento", "IdImpresa", 
"CodTipo", "DataApertura", "OperatoreApertura", 
"ControlloConcluso", "DataChiusura", "OperatoreChiusura", 
"SegnaturaVerbale", 

"IdDomandaEroa"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"bool", "DateTime", "string", 
"string", 

"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZVisiteAziendaliInsert", new string[] {"IdDomandaPagamento", "IdImpresa", 
"CodTipo", "DataApertura", "OperatoreApertura", 
"ControlloConcluso", "DataChiusura", "OperatoreChiusura", 
"SegnaturaVerbale", 

"IdDomandaEroa"}, new string[] {"int", "int", 
"string", "DateTime", "string", 
"bool", "DateTime", "string", 
"string", 

"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZVisiteAziendaliDelete", new string[] {"IdVisita"}, new string[] {"int"},"");
				for (int i = 0; i < VisiteAziendaliCollectionObj.Count; i++)
				{
					switch (VisiteAziendaliCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,VisiteAziendaliCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VisiteAziendaliCollectionObj[i].IdVisita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VISITA"]);
									VisiteAziendaliCollectionObj[i].ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,VisiteAziendaliCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (VisiteAziendaliCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVisita", (SiarLibrary.NullTypes.IntNT)VisiteAziendaliCollectionObj[i].IdVisita);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VisiteAziendaliCollectionObj.Count; i++)
				{
					if ((VisiteAziendaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VisiteAziendaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VisiteAziendaliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VisiteAziendaliCollectionObj[i].IsDirty = false;
						VisiteAziendaliCollectionObj[i].IsPersistent = true;
					}
					if ((VisiteAziendaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VisiteAziendaliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VisiteAziendaliCollectionObj[i].IsDirty = false;
						VisiteAziendaliCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VisiteAziendali VisiteAziendaliObj)
		{
			int returnValue = 0;
			if (VisiteAziendaliObj.IsPersistent) 
			{
				returnValue = Delete(db, VisiteAziendaliObj.IdVisita);
			}
			VisiteAziendaliObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VisiteAziendaliObj.IsDirty = false;
			VisiteAziendaliObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdVisitaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVisiteAziendaliDelete", new string[] {"IdVisita"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVisita", (SiarLibrary.NullTypes.IntNT)IdVisitaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VisiteAziendaliCollection VisiteAziendaliCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVisiteAziendaliDelete", new string[] {"IdVisita"}, new string[] {"int"},"");
				for (int i = 0; i < VisiteAziendaliCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVisita", VisiteAziendaliCollectionObj[i].IdVisita);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VisiteAziendaliCollectionObj.Count; i++)
				{
					if ((VisiteAziendaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VisiteAziendaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VisiteAziendaliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VisiteAziendaliCollectionObj[i].IsDirty = false;
						VisiteAziendaliCollectionObj[i].IsPersistent = false;
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
		public static VisiteAziendali GetById(DbProvider db, int IdVisitaValue)
		{
			VisiteAziendali VisiteAziendaliObj = null;
			IDbCommand readCmd = db.InitCmd( "ZVisiteAziendaliGetById", new string[] {"IdVisita"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdVisita", (SiarLibrary.NullTypes.IntNT)IdVisitaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VisiteAziendaliObj = GetFromDatareader(db);
				VisiteAziendaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VisiteAziendaliObj.IsDirty = false;
				VisiteAziendaliObj.IsPersistent = true;
			}
			db.Close();
			return VisiteAziendaliObj;
		}

		//getFromDatareader
		public static VisiteAziendali GetFromDatareader(DbProvider db)
		{
			VisiteAziendali VisiteAziendaliObj = new VisiteAziendali();
			VisiteAziendaliObj.IdVisita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VISITA"]);
			VisiteAziendaliObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			VisiteAziendaliObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VisiteAziendaliObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			VisiteAziendaliObj.DataApertura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APERTURA"]);
			VisiteAziendaliObj.OperatoreApertura = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_APERTURA"]);
			VisiteAziendaliObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
			VisiteAziendaliObj.DataChiusura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CHIUSURA"]);
			VisiteAziendaliObj.OperatoreChiusura = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_CHIUSURA"]);
			VisiteAziendaliObj.SegnaturaVerbale = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_VERBALE"]);
			VisiteAziendaliObj.TipoVisitaAziendale = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_VISITA_AZIENDALE"]);
			VisiteAziendaliObj.NominativoOperatoreApertura = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE_APERTURA"]);
			VisiteAziendaliObj.NominativoOperatoreChiusura = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE_CHIUSURA"]);
			VisiteAziendaliObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VisiteAziendaliObj.TipoDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOMANDA_PAGAMENTO"]);
			VisiteAziendaliObj.IdDomandaEroa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_EROA"]);
			VisiteAziendaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VisiteAziendaliObj.IsDirty = false;
			VisiteAziendaliObj.IsPersistent = true;
			return VisiteAziendaliObj;
		}

		//Find Select

		public static VisiteAziendaliCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVisitaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEroaEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAperturaEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreAperturaEqualThis, SiarLibrary.NullTypes.BoolNT ControlloConclusoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataChiusuraEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreChiusuraEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaVerbaleEqualThis)

		{

			VisiteAziendaliCollection VisiteAziendaliCollectionObj = new VisiteAziendaliCollection();

			IDbCommand findCmd = db.InitCmd("Zvisiteaziendalifindselect", new string[] {"IdVisitaequalthis", "IdDomandaPagamentoequalthis", "IdDomandaEroaequalthis", 
"IdImpresaequalthis", "CodTipoequalthis", "DataAperturaequalthis", 
"OperatoreAperturaequalthis", "ControlloConclusoequalthis", "DataChiusuraequalthis", 
"OperatoreChiusuraequalthis", "SegnaturaVerbaleequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"string", "bool", "DateTime", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVisitaequalthis", IdVisitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaEroaequalthis", IdDomandaEroaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAperturaequalthis", DataAperturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreAperturaequalthis", OperatoreAperturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloConclusoequalthis", ControlloConclusoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataChiusuraequalthis", DataChiusuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreChiusuraequalthis", OperatoreChiusuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaVerbaleequalthis", SegnaturaVerbaleEqualThis);
			VisiteAziendali VisiteAziendaliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VisiteAziendaliObj = GetFromDatareader(db);
				VisiteAziendaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VisiteAziendaliObj.IsDirty = false;
				VisiteAziendaliObj.IsPersistent = true;
				VisiteAziendaliCollectionObj.Add(VisiteAziendaliObj);
			}
			db.Close();
			return VisiteAziendaliCollectionObj;
		}

		//Find Find

		public static VisiteAziendaliCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdVisitaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEroaEqualThis)

		{

			VisiteAziendaliCollection VisiteAziendaliCollectionObj = new VisiteAziendaliCollection();

			IDbCommand findCmd = db.InitCmd("Zvisiteaziendalifindfind", new string[] {"IdVisitaequalthis", "IdDomandaPagamentoequalthis", "IdImpresaequalthis", 
"CodTipoequalthis", "IdProgettoequalthis", "IdDomandaEroaequalthis"}, new string[] {"int", "int", "int", 
"string", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVisitaequalthis", IdVisitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaEroaequalthis", IdDomandaEroaEqualThis);
			VisiteAziendali VisiteAziendaliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VisiteAziendaliObj = GetFromDatareader(db);
				VisiteAziendaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VisiteAziendaliObj.IsDirty = false;
				VisiteAziendaliObj.IsPersistent = true;
				VisiteAziendaliCollectionObj.Add(VisiteAziendaliObj);
			}
			db.Close();
			return VisiteAziendaliCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VISITE_AZIENDALI>
  <ViewName>vVISITE_AZIENDALI</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_VISITA DESC">
      <ID_VISITA>Equal</ID_VISITA>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_EROA>Equal</ID_DOMANDA_EROA>
    </Find>
  </Finds>
  <Filters>
    <FiltroControlloConcluso>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlloConcluso>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VISITE_AZIENDALI>
*/