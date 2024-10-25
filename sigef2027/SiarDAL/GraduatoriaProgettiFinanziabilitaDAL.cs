using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiFinanziabilitaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class GraduatoriaProgettiFinanziabilitaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", GraduatoriaProgettiFinanziabilitaObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", GraduatoriaProgettiFinanziabilitaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgIntegrato", GraduatoriaProgettiFinanziabilitaObj.IdProgIntegrato);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoTotale", GraduatoriaProgettiFinanziabilitaObj.CostoTotale);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoDiMisura", GraduatoriaProgettiFinanziabilitaObj.ContributoDiMisura);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoRimanente", GraduatoriaProgettiFinanziabilitaObj.ContributoRimanente);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", GraduatoriaProgettiFinanziabilitaObj.Misura);
			DbProvider.SetCmdParam(cmd,firstChar + "MisuraPrevalente", GraduatoriaProgettiFinanziabilitaObj.MisuraPrevalente);
		}
		//Insert
		private static int Insert(DbProvider db, GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettiFinanziabilitaInsert", new string[] {"IdBando", "IdProgetto", "IdProgIntegrato", 
"CostoTotale", "ContributoDiMisura", "ContributoRimanente", 
"Misura", "MisuraPrevalente"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool"},"");
				CompileIUCmd(false, insertCmd,GraduatoriaProgettiFinanziabilitaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				GraduatoriaProgettiFinanziabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiFinanziabilitaObj.IsDirty = false;
				GraduatoriaProgettiFinanziabilitaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettiFinanziabilitaUpdate", new string[] {"IdBando", "IdProgetto", "IdProgIntegrato", 
"CostoTotale", "ContributoDiMisura", "ContributoRimanente", 
"Misura", "MisuraPrevalente"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool"},"");
				CompileIUCmd(true, updateCmd,GraduatoriaProgettiFinanziabilitaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				GraduatoriaProgettiFinanziabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiFinanziabilitaObj.IsDirty = false;
				GraduatoriaProgettiFinanziabilitaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj)
		{
			switch (GraduatoriaProgettiFinanziabilitaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, GraduatoriaProgettiFinanziabilitaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, GraduatoriaProgettiFinanziabilitaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,GraduatoriaProgettiFinanziabilitaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettiFinanziabilitaUpdate", new string[] {"IdBando", "IdProgetto", "IdProgIntegrato", 
"CostoTotale", "ContributoDiMisura", "ContributoRimanente", 
"Misura", "MisuraPrevalente"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettiFinanziabilitaInsert", new string[] {"IdBando", "IdProgetto", "IdProgIntegrato", 
"CostoTotale", "ContributoDiMisura", "ContributoRimanente", 
"Misura", "MisuraPrevalente"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiFinanziabilitaDelete", new string[] {"IdBando", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < GraduatoriaProgettiFinanziabilitaCollectionObj.Count; i++)
				{
					switch (GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,GraduatoriaProgettiFinanziabilitaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,GraduatoriaProgettiFinanziabilitaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (GraduatoriaProgettiFinanziabilitaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettiFinanziabilitaCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettiFinanziabilitaCollectionObj[i].IdProgetto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettiFinanziabilitaCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].IsPersistent = true;
					}
					if ((GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj)
		{
			int returnValue = 0;
			if (GraduatoriaProgettiFinanziabilitaObj.IsPersistent) 
			{
				returnValue = Delete(db, GraduatoriaProgettiFinanziabilitaObj.IdBando, GraduatoriaProgettiFinanziabilitaObj.IdProgetto);
			}
			GraduatoriaProgettiFinanziabilitaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			GraduatoriaProgettiFinanziabilitaObj.IsDirty = false;
			GraduatoriaProgettiFinanziabilitaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, int IdProgettoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiFinanziabilitaDelete", new string[] {"IdBando", "IdProgetto"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiFinanziabilitaDelete", new string[] {"IdBando", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < GraduatoriaProgettiFinanziabilitaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", GraduatoriaProgettiFinanziabilitaCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", GraduatoriaProgettiFinanziabilitaCollectionObj[i].IdProgetto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettiFinanziabilitaCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiFinanziabilitaCollectionObj[i].IsPersistent = false;
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
		public static GraduatoriaProgettiFinanziabilita GetById(DbProvider db, int IdBandoValue, int IdProgettoValue)
		{
			GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZGraduatoriaProgettiFinanziabilitaGetById", new string[] {"IdBando", "IdProgetto"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				GraduatoriaProgettiFinanziabilitaObj = GetFromDatareader(db);
				GraduatoriaProgettiFinanziabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiFinanziabilitaObj.IsDirty = false;
				GraduatoriaProgettiFinanziabilitaObj.IsPersistent = true;
			}
			db.Close();
			return GraduatoriaProgettiFinanziabilitaObj;
		}

		//getFromDatareader
		public static GraduatoriaProgettiFinanziabilita GetFromDatareader(DbProvider db)
		{
			GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj = new GraduatoriaProgettiFinanziabilita();
			GraduatoriaProgettiFinanziabilitaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			GraduatoriaProgettiFinanziabilitaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			GraduatoriaProgettiFinanziabilitaObj.IdProgIntegrato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROG_INTEGRATO"]);
			GraduatoriaProgettiFinanziabilitaObj.CostoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_TOTALE"]);
			GraduatoriaProgettiFinanziabilitaObj.ContributoDiMisura = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_DI_MISURA"]);
			GraduatoriaProgettiFinanziabilitaObj.ContributoRimanente = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RIMANENTE"]);
			GraduatoriaProgettiFinanziabilitaObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			GraduatoriaProgettiFinanziabilitaObj.MisuraPrevalente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MISURA_PREVALENTE"]);
			GraduatoriaProgettiFinanziabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			GraduatoriaProgettiFinanziabilitaObj.IsDirty = false;
			GraduatoriaProgettiFinanziabilitaObj.IsPersistent = true;
			return GraduatoriaProgettiFinanziabilitaObj;
		}

		//Find Select

		public static GraduatoriaProgettiFinanziabilitaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdProgIntegratoEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostoTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoDiMisuraEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRimanenteEqualThis, 
SiarLibrary.NullTypes.StringNT MisuraEqualThis, SiarLibrary.NullTypes.BoolNT MisuraPrevalenteEqualThis)

		{

			GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionObj = new GraduatoriaProgettiFinanziabilitaCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettifinanziabilitafindselect", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdProgIntegratoequalthis", 
"CostoTotaleequalthis", "ContributoDiMisuraequalthis", "ContributoRimanenteequalthis", 
"Misuraequalthis", "MisuraPrevalenteequalthis"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgIntegratoequalthis", IdProgIntegratoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoTotaleequalthis", CostoTotaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoDiMisuraequalthis", ContributoDiMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoRimanenteequalthis", ContributoRimanenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MisuraPrevalenteequalthis", MisuraPrevalenteEqualThis);
			GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettiFinanziabilitaObj = GetFromDatareader(db);
				GraduatoriaProgettiFinanziabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiFinanziabilitaObj.IsDirty = false;
				GraduatoriaProgettiFinanziabilitaObj.IsPersistent = true;
				GraduatoriaProgettiFinanziabilitaCollectionObj.Add(GraduatoriaProgettiFinanziabilitaObj);
			}
			db.Close();
			return GraduatoriaProgettiFinanziabilitaCollectionObj;
		}

		//Find Find

		public static GraduatoriaProgettiFinanziabilitaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdProgIntegratoEqualThis, 
SiarLibrary.NullTypes.StringNT MisuraEqualThis)

		{

			GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionObj = new GraduatoriaProgettiFinanziabilitaCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettifinanziabilitafindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdProgIntegratoequalthis", 
"Misuraequalthis"}, new string[] {"int", "int", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgIntegratoequalthis", IdProgIntegratoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettiFinanziabilitaObj = GetFromDatareader(db);
				GraduatoriaProgettiFinanziabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiFinanziabilitaObj.IsDirty = false;
				GraduatoriaProgettiFinanziabilitaObj.IsPersistent = true;
				GraduatoriaProgettiFinanziabilitaCollectionObj.Add(GraduatoriaProgettiFinanziabilitaObj);
			}
			db.Close();
			return GraduatoriaProgettiFinanziabilitaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_PROGETTI_FINANZIABILITA>
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
    <Find OrderBy="ORDER BY MISURA_PREVALENTE DESC, MISURA">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_PROG_INTEGRATO>Equal</ID_PROG_INTEGRATO>
      <MISURA>Equal</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTI_FINANZIABILITA>
*/