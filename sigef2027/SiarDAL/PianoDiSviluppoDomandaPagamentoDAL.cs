using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PianoDiSviluppoDomandaPagamentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class PianoDiSviluppoDomandaPagamentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPiano", PianoDiSviluppoDomandaPagamentoObj.IdPiano);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", PianoDiSviluppoDomandaPagamentoObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", PianoDiSviluppoDomandaPagamentoObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", PianoDiSviluppoDomandaPagamentoObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", PianoDiSviluppoDomandaPagamentoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoInvestimento", PianoDiSviluppoDomandaPagamentoObj.CostoInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "MezziPropri", PianoDiSviluppoDomandaPagamentoObj.MezziPropri);
			DbProvider.SetCmdParam(cmd,firstChar + "RisorseTerzi", PianoDiSviluppoDomandaPagamentoObj.RisorseTerzi);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributiPubblici", PianoDiSviluppoDomandaPagamentoObj.ContributiPubblici);
			DbProvider.SetCmdParam(cmd,firstChar + "SpeseGestione", PianoDiSviluppoDomandaPagamentoObj.SpeseGestione);
			DbProvider.SetCmdParam(cmd,firstChar + "RimborsoDebito", PianoDiSviluppoDomandaPagamentoObj.RimborsoDebito);
			DbProvider.SetCmdParam(cmd,firstChar + "EntrataGestione", PianoDiSviluppoDomandaPagamentoObj.EntrataGestione);
			DbProvider.SetCmdParam(cmd,firstChar + "AltreCoperture", PianoDiSviluppoDomandaPagamentoObj.AltreCoperture);
		}
		//Insert
		private static int Insert(DbProvider db, PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPianoDiSviluppoDomandaPagamentoInsert", new string[] {"Anno", "IdDomandaPagamento", 
"IdImpresa", "IdProgetto", "CostoInvestimento", 
"MezziPropri", "RisorseTerzi", "ContributiPubblici", 
"SpeseGestione", "RimborsoDebito", "EntrataGestione", 
"AltreCoperture"}, new string[] {"int", "int", 
"int", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal"},"");
				CompileIUCmd(false, insertCmd,PianoDiSviluppoDomandaPagamentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PianoDiSviluppoDomandaPagamentoObj.IdPiano = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PIANO"]);
				}
				PianoDiSviluppoDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoDomandaPagamentoObj.IsDirty = false;
				PianoDiSviluppoDomandaPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPianoDiSviluppoDomandaPagamentoUpdate", new string[] {"IdPiano", "Anno", "IdDomandaPagamento", 
"IdImpresa", "IdProgetto", "CostoInvestimento", 
"MezziPropri", "RisorseTerzi", "ContributiPubblici", 
"SpeseGestione", "RimborsoDebito", "EntrataGestione", 
"AltreCoperture"}, new string[] {"int", "int", "int", 
"int", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal"},"");
				CompileIUCmd(true, updateCmd,PianoDiSviluppoDomandaPagamentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PianoDiSviluppoDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoDomandaPagamentoObj.IsDirty = false;
				PianoDiSviluppoDomandaPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj)
		{
			switch (PianoDiSviluppoDomandaPagamentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PianoDiSviluppoDomandaPagamentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PianoDiSviluppoDomandaPagamentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PianoDiSviluppoDomandaPagamentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PianoDiSviluppoDomandaPagamentoCollection PianoDiSviluppoDomandaPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPianoDiSviluppoDomandaPagamentoUpdate", new string[] {"IdPiano", "Anno", "IdDomandaPagamento", 
"IdImpresa", "IdProgetto", "CostoInvestimento", 
"MezziPropri", "RisorseTerzi", "ContributiPubblici", 
"SpeseGestione", "RimborsoDebito", "EntrataGestione", 
"AltreCoperture"}, new string[] {"int", "int", "int", 
"int", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPianoDiSviluppoDomandaPagamentoInsert", new string[] {"Anno", "IdDomandaPagamento", 
"IdImpresa", "IdProgetto", "CostoInvestimento", 
"MezziPropri", "RisorseTerzi", "ContributiPubblici", 
"SpeseGestione", "RimborsoDebito", "EntrataGestione", 
"AltreCoperture"}, new string[] {"int", "int", 
"int", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPianoDiSviluppoDomandaPagamentoDelete", new string[] {"IdPiano"}, new string[] {"int"},"");
				for (int i = 0; i < PianoDiSviluppoDomandaPagamentoCollectionObj.Count; i++)
				{
					switch (PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PianoDiSviluppoDomandaPagamentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PianoDiSviluppoDomandaPagamentoCollectionObj[i].IdPiano = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PIANO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PianoDiSviluppoDomandaPagamentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PianoDiSviluppoDomandaPagamentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPiano", (SiarLibrary.NullTypes.IntNT)PianoDiSviluppoDomandaPagamentoCollectionObj[i].IdPiano);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PianoDiSviluppoDomandaPagamentoCollectionObj.Count; i++)
				{
					if ((PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].IsDirty = false;
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].IsPersistent = true;
					}
					if ((PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].IsDirty = false;
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj)
		{
			int returnValue = 0;
			if (PianoDiSviluppoDomandaPagamentoObj.IsPersistent) 
			{
				returnValue = Delete(db, PianoDiSviluppoDomandaPagamentoObj.IdPiano);
			}
			PianoDiSviluppoDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PianoDiSviluppoDomandaPagamentoObj.IsDirty = false;
			PianoDiSviluppoDomandaPagamentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPianoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPianoDiSviluppoDomandaPagamentoDelete", new string[] {"IdPiano"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPiano", (SiarLibrary.NullTypes.IntNT)IdPianoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PianoDiSviluppoDomandaPagamentoCollection PianoDiSviluppoDomandaPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPianoDiSviluppoDomandaPagamentoDelete", new string[] {"IdPiano"}, new string[] {"int"},"");
				for (int i = 0; i < PianoDiSviluppoDomandaPagamentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPiano", PianoDiSviluppoDomandaPagamentoCollectionObj[i].IdPiano);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PianoDiSviluppoDomandaPagamentoCollectionObj.Count; i++)
				{
					if ((PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].IsDirty = false;
						PianoDiSviluppoDomandaPagamentoCollectionObj[i].IsPersistent = false;
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
		public static PianoDiSviluppoDomandaPagamento GetById(DbProvider db, int IdPianoValue)
		{
			PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPianoDiSviluppoDomandaPagamentoGetById", new string[] {"IdPiano"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPiano", (SiarLibrary.NullTypes.IntNT)IdPianoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PianoDiSviluppoDomandaPagamentoObj = GetFromDatareader(db);
				PianoDiSviluppoDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoDomandaPagamentoObj.IsDirty = false;
				PianoDiSviluppoDomandaPagamentoObj.IsPersistent = true;
			}
			db.Close();
			return PianoDiSviluppoDomandaPagamentoObj;
		}

		//getFromDatareader
		public static PianoDiSviluppoDomandaPagamento GetFromDatareader(DbProvider db)
		{
			PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj = new PianoDiSviluppoDomandaPagamento();
			PianoDiSviluppoDomandaPagamentoObj.IdPiano = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PIANO"]);
			PianoDiSviluppoDomandaPagamentoObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			PianoDiSviluppoDomandaPagamentoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			PianoDiSviluppoDomandaPagamentoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			PianoDiSviluppoDomandaPagamentoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PianoDiSviluppoDomandaPagamentoObj.CostoInvestimento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_INVESTIMENTO"]);
			PianoDiSviluppoDomandaPagamentoObj.MezziPropri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MEZZI_PROPRI"]);
			PianoDiSviluppoDomandaPagamentoObj.RisorseTerzi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RISORSE_TERZI"]);
			PianoDiSviluppoDomandaPagamentoObj.ContributiPubblici = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTI_PUBBLICI"]);
			PianoDiSviluppoDomandaPagamentoObj.SpeseGestione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESE_GESTIONE"]);
			PianoDiSviluppoDomandaPagamentoObj.RimborsoDebito = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RIMBORSO_DEBITO"]);
			PianoDiSviluppoDomandaPagamentoObj.EntrataGestione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ENTRATA_GESTIONE"]);
			PianoDiSviluppoDomandaPagamentoObj.AltreCoperture = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALTRE_COPERTURE"]);
			PianoDiSviluppoDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PianoDiSviluppoDomandaPagamentoObj.IsDirty = false;
			PianoDiSviluppoDomandaPagamentoObj.IsPersistent = true;
			return PianoDiSviluppoDomandaPagamentoObj;
		}

		//Find Select

		public static PianoDiSviluppoDomandaPagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPianoEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DecimalNT CostoInvestimentoEqualThis, 
SiarLibrary.NullTypes.DecimalNT MezziPropriEqualThis, SiarLibrary.NullTypes.DecimalNT RisorseTerziEqualThis, SiarLibrary.NullTypes.DecimalNT ContributiPubbliciEqualThis, 
SiarLibrary.NullTypes.DecimalNT SpeseGestioneEqualThis, SiarLibrary.NullTypes.DecimalNT RimborsoDebitoEqualThis, SiarLibrary.NullTypes.DecimalNT EntrataGestioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT AltreCopertureEqualThis)

		{

			PianoDiSviluppoDomandaPagamentoCollection PianoDiSviluppoDomandaPagamentoCollectionObj = new PianoDiSviluppoDomandaPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zpianodisviluppodomandapagamentofindselect", new string[] {"IdPianoequalthis", "Annoequalthis", "IdDomandaPagamentoequalthis", 
"IdImpresaequalthis", "IdProgettoequalthis", "CostoInvestimentoequalthis", 
"MezziPropriequalthis", "RisorseTerziequalthis", "ContributiPubbliciequalthis", 
"SpeseGestioneequalthis", "RimborsoDebitoequalthis", "EntrataGestioneequalthis", 
"AltreCopertureequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPianoequalthis", IdPianoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoInvestimentoequalthis", CostoInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MezziPropriequalthis", MezziPropriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RisorseTerziequalthis", RisorseTerziEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributiPubbliciequalthis", ContributiPubbliciEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpeseGestioneequalthis", SpeseGestioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RimborsoDebitoequalthis", RimborsoDebitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EntrataGestioneequalthis", EntrataGestioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AltreCopertureequalthis", AltreCopertureEqualThis);
			PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PianoDiSviluppoDomandaPagamentoObj = GetFromDatareader(db);
				PianoDiSviluppoDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoDomandaPagamentoObj.IsDirty = false;
				PianoDiSviluppoDomandaPagamentoObj.IsPersistent = true;
				PianoDiSviluppoDomandaPagamentoCollectionObj.Add(PianoDiSviluppoDomandaPagamentoObj);
			}
			db.Close();
			return PianoDiSviluppoDomandaPagamentoCollectionObj;
		}

		//Find Find

		public static PianoDiSviluppoDomandaPagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

		{

			PianoDiSviluppoDomandaPagamentoCollection PianoDiSviluppoDomandaPagamentoCollectionObj = new PianoDiSviluppoDomandaPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zpianodisviluppodomandapagamentofindfind", new string[] {"Annoequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis", 
"IdImpresaequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PianoDiSviluppoDomandaPagamentoObj = GetFromDatareader(db);
				PianoDiSviluppoDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoDomandaPagamentoObj.IsDirty = false;
				PianoDiSviluppoDomandaPagamentoObj.IsPersistent = true;
				PianoDiSviluppoDomandaPagamentoCollectionObj.Add(PianoDiSviluppoDomandaPagamentoObj);
			}
			db.Close();
			return PianoDiSviluppoDomandaPagamentoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO>
  <ViewName>
  </ViewName>
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
    <Find OrderBy="ORDER BY ANNO DESC">
      <ANNO>Equal</ANNO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO>
*/