using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PianoDiSviluppoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class PianoDiSviluppoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PianoDiSviluppo PianoDiSviluppoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPiano", PianoDiSviluppoObj.IdPiano);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", PianoDiSviluppoObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", PianoDiSviluppoObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", PianoDiSviluppoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoInvestimento", PianoDiSviluppoObj.CostoInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "MezziPropri", PianoDiSviluppoObj.MezziPropri);
			DbProvider.SetCmdParam(cmd,firstChar + "RisorseTerzi", PianoDiSviluppoObj.RisorseTerzi);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributiPubblici", PianoDiSviluppoObj.ContributiPubblici);
			DbProvider.SetCmdParam(cmd,firstChar + "SpeseGestione", PianoDiSviluppoObj.SpeseGestione);
			DbProvider.SetCmdParam(cmd,firstChar + "RimborsoDebito", PianoDiSviluppoObj.RimborsoDebito);
			DbProvider.SetCmdParam(cmd,firstChar + "EntrataGestione", PianoDiSviluppoObj.EntrataGestione);
			DbProvider.SetCmdParam(cmd,firstChar + "AltreCoperture", PianoDiSviluppoObj.AltreCoperture);
		}
		//Insert
		private static int Insert(DbProvider db, PianoDiSviluppo PianoDiSviluppoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPianoDiSviluppoInsert", new string[] {"Anno", "IdImpresa", 
"IdProgetto", "CostoInvestimento", "MezziPropri", 
"RisorseTerzi", "ContributiPubblici", "SpeseGestione", 
"RimborsoDebito", "EntrataGestione", "AltreCoperture"}, new string[] {"int", "int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");
				CompileIUCmd(false, insertCmd,PianoDiSviluppoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PianoDiSviluppoObj.IdPiano = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PIANO"]);
				}
				PianoDiSviluppoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoObj.IsDirty = false;
				PianoDiSviluppoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PianoDiSviluppo PianoDiSviluppoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPianoDiSviluppoUpdate", new string[] {"IdPiano", "Anno", "IdImpresa", 
"IdProgetto", "CostoInvestimento", "MezziPropri", 
"RisorseTerzi", "ContributiPubblici", "SpeseGestione", 
"RimborsoDebito", "EntrataGestione", "AltreCoperture"}, new string[] {"int", "int", "int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");
				CompileIUCmd(true, updateCmd,PianoDiSviluppoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PianoDiSviluppoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoObj.IsDirty = false;
				PianoDiSviluppoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PianoDiSviluppo PianoDiSviluppoObj)
		{
			switch (PianoDiSviluppoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PianoDiSviluppoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PianoDiSviluppoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PianoDiSviluppoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PianoDiSviluppoCollection PianoDiSviluppoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPianoDiSviluppoUpdate", new string[] {"IdPiano", "Anno", "IdImpresa", 
"IdProgetto", "CostoInvestimento", "MezziPropri", 
"RisorseTerzi", "ContributiPubblici", "SpeseGestione", 
"RimborsoDebito", "EntrataGestione", "AltreCoperture"}, new string[] {"int", "int", "int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPianoDiSviluppoInsert", new string[] {"Anno", "IdImpresa", 
"IdProgetto", "CostoInvestimento", "MezziPropri", 
"RisorseTerzi", "ContributiPubblici", "SpeseGestione", 
"RimborsoDebito", "EntrataGestione", "AltreCoperture"}, new string[] {"int", "int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPianoDiSviluppoDelete", new string[] {"IdPiano"}, new string[] {"int"},"");
				for (int i = 0; i < PianoDiSviluppoCollectionObj.Count; i++)
				{
					switch (PianoDiSviluppoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PianoDiSviluppoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PianoDiSviluppoCollectionObj[i].IdPiano = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PIANO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PianoDiSviluppoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PianoDiSviluppoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPiano", (SiarLibrary.NullTypes.IntNT)PianoDiSviluppoCollectionObj[i].IdPiano);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PianoDiSviluppoCollectionObj.Count; i++)
				{
					if ((PianoDiSviluppoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PianoDiSviluppoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PianoDiSviluppoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PianoDiSviluppoCollectionObj[i].IsDirty = false;
						PianoDiSviluppoCollectionObj[i].IsPersistent = true;
					}
					if ((PianoDiSviluppoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PianoDiSviluppoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PianoDiSviluppoCollectionObj[i].IsDirty = false;
						PianoDiSviluppoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PianoDiSviluppo PianoDiSviluppoObj)
		{
			int returnValue = 0;
			if (PianoDiSviluppoObj.IsPersistent) 
			{
				returnValue = Delete(db, PianoDiSviluppoObj.IdPiano);
			}
			PianoDiSviluppoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PianoDiSviluppoObj.IsDirty = false;
			PianoDiSviluppoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPianoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPianoDiSviluppoDelete", new string[] {"IdPiano"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPiano", (SiarLibrary.NullTypes.IntNT)IdPianoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PianoDiSviluppoCollection PianoDiSviluppoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPianoDiSviluppoDelete", new string[] {"IdPiano"}, new string[] {"int"},"");
				for (int i = 0; i < PianoDiSviluppoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPiano", PianoDiSviluppoCollectionObj[i].IdPiano);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PianoDiSviluppoCollectionObj.Count; i++)
				{
					if ((PianoDiSviluppoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PianoDiSviluppoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PianoDiSviluppoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PianoDiSviluppoCollectionObj[i].IsDirty = false;
						PianoDiSviluppoCollectionObj[i].IsPersistent = false;
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
		public static PianoDiSviluppo GetById(DbProvider db, int IdPianoValue)
		{
			PianoDiSviluppo PianoDiSviluppoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPianoDiSviluppoGetById", new string[] {"IdPiano"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPiano", (SiarLibrary.NullTypes.IntNT)IdPianoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PianoDiSviluppoObj = GetFromDatareader(db);
				PianoDiSviluppoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoObj.IsDirty = false;
				PianoDiSviluppoObj.IsPersistent = true;
			}
			db.Close();
			return PianoDiSviluppoObj;
		}

		//getFromDatareader
		public static PianoDiSviluppo GetFromDatareader(DbProvider db)
		{
			PianoDiSviluppo PianoDiSviluppoObj = new PianoDiSviluppo();
			PianoDiSviluppoObj.IdPiano = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PIANO"]);
			PianoDiSviluppoObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			PianoDiSviluppoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			PianoDiSviluppoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PianoDiSviluppoObj.CostoInvestimento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_INVESTIMENTO"]);
			PianoDiSviluppoObj.MezziPropri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MEZZI_PROPRI"]);
			PianoDiSviluppoObj.RisorseTerzi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RISORSE_TERZI"]);
			PianoDiSviluppoObj.ContributiPubblici = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTI_PUBBLICI"]);
			PianoDiSviluppoObj.SpeseGestione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESE_GESTIONE"]);
			PianoDiSviluppoObj.RimborsoDebito = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RIMBORSO_DEBITO"]);
			PianoDiSviluppoObj.EntrataGestione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ENTRATA_GESTIONE"]);
			PianoDiSviluppoObj.AltreCoperture = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALTRE_COPERTURE"]);
			PianoDiSviluppoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PianoDiSviluppoObj.IsDirty = false;
			PianoDiSviluppoObj.IsPersistent = true;
			return PianoDiSviluppoObj;
		}

		//Find Select

		public static PianoDiSviluppoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPianoEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DecimalNT CostoInvestimentoEqualThis, SiarLibrary.NullTypes.DecimalNT MezziPropriEqualThis, 
SiarLibrary.NullTypes.DecimalNT RisorseTerziEqualThis, SiarLibrary.NullTypes.DecimalNT ContributiPubbliciEqualThis, SiarLibrary.NullTypes.DecimalNT SpeseGestioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT RimborsoDebitoEqualThis, SiarLibrary.NullTypes.DecimalNT EntrataGestioneEqualThis, SiarLibrary.NullTypes.DecimalNT AltreCopertureEqualThis)

		{

			PianoDiSviluppoCollection PianoDiSviluppoCollectionObj = new PianoDiSviluppoCollection();

			IDbCommand findCmd = db.InitCmd("Zpianodisviluppofindselect", new string[] {"IdPianoequalthis", "Annoequalthis", "IdImpresaequalthis", 
"IdProgettoequalthis", "CostoInvestimentoequalthis", "MezziPropriequalthis", 
"RisorseTerziequalthis", "ContributiPubbliciequalthis", "SpeseGestioneequalthis", 
"RimborsoDebitoequalthis", "EntrataGestioneequalthis", "AltreCopertureequalthis"}, new string[] {"int", "int", "int", 
"int", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPianoequalthis", IdPianoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
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
			PianoDiSviluppo PianoDiSviluppoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PianoDiSviluppoObj = GetFromDatareader(db);
				PianoDiSviluppoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoObj.IsDirty = false;
				PianoDiSviluppoObj.IsPersistent = true;
				PianoDiSviluppoCollectionObj.Add(PianoDiSviluppoObj);
			}
			db.Close();
			return PianoDiSviluppoCollectionObj;
		}

		//Find Find

		public static PianoDiSviluppoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPianoEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

		{

			PianoDiSviluppoCollection PianoDiSviluppoCollectionObj = new PianoDiSviluppoCollection();

			IDbCommand findCmd = db.InitCmd("Zpianodisviluppofindfind", new string[] {"IdPianoequalthis", "Annoequalthis", "IdProgettoequalthis", 
"IdImpresaequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPianoequalthis", IdPianoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			PianoDiSviluppo PianoDiSviluppoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PianoDiSviluppoObj = GetFromDatareader(db);
				PianoDiSviluppoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoDiSviluppoObj.IsDirty = false;
				PianoDiSviluppoObj.IsPersistent = true;
				PianoDiSviluppoCollectionObj.Add(PianoDiSviluppoObj);
			}
			db.Close();
			return PianoDiSviluppoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_DI_SVILUPPO>
  <ViewName>
  </ViewName>
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
      <ID_PIANO>Equal</ID_PIANO>
      <ANNO>Equal</ANNO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttuale>
      <ID_PROGETTO>IsNull</ID_PROGETTO>
    </FiltroAttuale>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PIANO_DI_SVILUPPO>
*/