using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

/* STORIA
 * Data: 2016-05-24; Statoo: Creazione; Autore: 
*/

namespace SiarDAL
{

	/// <summary>
    /// Summary description for DatiMonitoraggioFESRDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


    public class DatiMonitoraggioFESRDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DatiMonitoraggioFESR DatiMonitoraggioFESRObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdDatiMonitoraggioFESR", DatiMonitoraggioFESRObj.IdDatiMonitoraggioFESR);
				// altri campi sempre valorizzati
			}
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", DatiMonitoraggioFESRObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdCUPCategoria", DatiMonitoraggioFESRObj.IdCUPCategoria);
            DbProvider.SetCmdParam(cmd, firstChar + "IdCUPCategoriaSoggetto", DatiMonitoraggioFESRObj.IdCUPCategoriaSoggetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdTemaPrioritario", DatiMonitoraggioFESRObj.IdTemaPrioritario);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAteco2007", DatiMonitoraggioFESRObj.IdAteco2007);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAttivitaEcon", DatiMonitoraggioFESRObj.IdAttivitaEcon);
            DbProvider.SetCmdParam(cmd, firstChar + "IdCPTSettore", DatiMonitoraggioFESRObj.IdCPTSettore);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDimensioneTerr", DatiMonitoraggioFESRObj.IdDimensioneTerr);
            DbProvider.SetCmdParam(cmd, firstChar + "IdCUPNatura", DatiMonitoraggioFESRObj.IdCUPNatura);
            DbProvider.SetCmdParam(cmd, firstChar + "IdCUPCategoriaTipoOperazione", DatiMonitoraggioFESRObj.IdCUPCategoriaTipoOperazione);
		}
		//Insert
		private static int Insert(DbProvider db, DatiMonitoraggioFESR DatiMonitoraggioFESRObj)
		{
			int i = 1;
			try
			{
                IDbCommand insertCmd = db.InitCmd("ZDatiMonitoraggioFESRInsert", 
                    new string[] 
                    {"IdProgetto", "IdCUPCategoria","IdCUPCategoriaSoggetto", "IdTemaPrioritario", "IdAteco2007", "IdAttivitaEcon", "IdCPTSettore", "IdDimensioneTerr", "IdCUPNatura", "IdCUPCategoriaTipoOperazione"},
                    new string[] 
                    { "int", "string", "string", "string", "string", "string", "string", "string", "string", "string" }, "");
                CompileIUCmd(false, insertCmd, DatiMonitoraggioFESRObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                    DatiMonitoraggioFESRObj.IdDatiMonitoraggioFESR = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DATI_MONIT"]);
                DatiMonitoraggioFESRObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DatiMonitoraggioFESRObj.IsDirty = false;
                DatiMonitoraggioFESRObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
        private static int Update(DbProvider db, DatiMonitoraggioFESR DatiMonitoraggioFESRObj)
		{
			int i = 1;
			try
			{
                IDbCommand updateCmd = db.InitCmd("ZDatiMonitoraggioFESRUpdate", new string[] { "IdDatiMonitoraggioFESR", "IdProgetto", "IdCUPCategoria", "IdCUPCategoriaSoggetto", "IdTemaPrioritario", "IdAteco2007", "IdAttivitaEcon", "IdCPTSettore", "IdDimensioneTerr", "IdCUPNatura", "IdCUPCategoriaTipoOperazione" },
                    new string[] { "int", "int", "string", "string", "string", "string", "string", "string", "string", "string", "string" }, "");
                CompileIUCmd(true, updateCmd, DatiMonitoraggioFESRObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                DatiMonitoraggioFESRObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DatiMonitoraggioFESRObj.IsDirty = false;
                DatiMonitoraggioFESRObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
        public static int Save(DbProvider db, DatiMonitoraggioFESR DatiMonitoraggioFESRObj)
		{
            switch (DatiMonitoraggioFESRObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, DatiMonitoraggioFESRObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, DatiMonitoraggioFESRObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, DatiMonitoraggioFESRObj);
                default : 
                    return 0;
            }
		}

        public static int SaveCollection(DbProvider db, DatiMonitoraggioFESRCollection DatiMonitoraggioFESRCollectionObj)
		{
            db.BeginTran();
			int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDatiMonitoraggioFESRUpdate", new string[] { "IdDatiMonitoraggioFESR", "IdProgetto", "IdCUPCategoria", "IdCUPCategoriaSoggetto", "IdTemaPrioritario", "IdAteco2007", "IdAttivitaEcon", "IdCPTSettore", "IdDimensioneTerr", "IdCUPNatura", "IdCUPCategoriaTipoOperazione" },
                    new string[] { "int", "int", "string", "string", "string", "string", "string", "string", "string", "string", "string" }, "");

                IDbCommand insertCmd = db.InitCmd("ZDatiMonitoraggioFESRInsert", new string[] { "IdProgetto", "IdCUPCategoria", "IdCUPCategoriaSoggetto", "IdTemaPrioritario", "IdAteco2007", "IdAttivitaEcon", "IdCPTSettore", "IdDimensioneTerr", "IdCUPNatura", "IdCUPCategoriaTipoOperazione" },
                    new string[] { "int", "string", "string", "string", "string", "string", "string", "string", "string", "string" }, "");

                IDbCommand deleteCmd = db.InitCmd( "ZDatiMonitoraggioFESRDelete", new string[] {"IdDatiMonitoraggioFESR"}, new string[] {"int"},"");

                for (int i = 0; i < DatiMonitoraggioFESRCollectionObj.Count; i++)
                {
                    switch (DatiMonitoraggioFESRCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added : 
                            {
                                CompileIUCmd(false, insertCmd, DatiMonitoraggioFESRCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    DatiMonitoraggioFESRCollectionObj[i].IdDatiMonitoraggioFESR = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DATI_MONIT"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed : 
                            {
                                CompileIUCmd(true, updateCmd, DatiMonitoraggioFESRCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted : 
                            {
                                if (DatiMonitoraggioFESRCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDatiMonitoraggioFESR", (SiarLibrary.NullTypes.IntNT)DatiMonitoraggioFESRCollectionObj[i].IdDatiMonitoraggioFESR);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < DatiMonitoraggioFESRCollectionObj.Count; i++)
                {
                    if ((DatiMonitoraggioFESRCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DatiMonitoraggioFESRCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DatiMonitoraggioFESRCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        DatiMonitoraggioFESRCollectionObj[i].IsDirty = false;
                        DatiMonitoraggioFESRCollectionObj[i].IsPersistent = true;
                    }
                    if ((DatiMonitoraggioFESRCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        DatiMonitoraggioFESRCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DatiMonitoraggioFESRCollectionObj[i].IsDirty = false;
                        DatiMonitoraggioFESRCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, DatiMonitoraggioFESR DatiMonitoraggioFESRObj)
		{
			int returnValue = 0;
            if (DatiMonitoraggioFESRObj.IsPersistent)
            {
                returnValue = Delete(db, DatiMonitoraggioFESRObj.IdDatiMonitoraggioFESR);
            }
            DatiMonitoraggioFESRObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            DatiMonitoraggioFESRObj.IsDirty = false;
            DatiMonitoraggioFESRObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDatiMonitoraggioFESRValue)
		{
			int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDatiMonitoraggioFESRDelete", new string[] { "IdDatiMonitoraggioFESR" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDatiMonitoraggioFESR", (SiarLibrary.NullTypes.IntNT)IdDatiMonitoraggioFESRValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
			return i;
		}

        public static int DeleteCollection(DbProvider db, DatiMonitoraggioFESRCollection DatiMonitoraggioFESRCollectionObj)
		{
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDatiMonitoraggioFESRDelete", new string[] { "IdDatiMonitoraggioFESR" }, new string[] { "int" }, "");
                for (int i = 0; i < DatiMonitoraggioFESRCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDatiMonitoraggioFESR", DatiMonitoraggioFESRCollectionObj[i].IdDatiMonitoraggioFESR);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < DatiMonitoraggioFESRCollectionObj.Count; i++)
                {
                    if ((DatiMonitoraggioFESRCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DatiMonitoraggioFESRCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DatiMonitoraggioFESRCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DatiMonitoraggioFESRCollectionObj[i].IsDirty = false;
                        DatiMonitoraggioFESRCollectionObj[i].IsPersistent = false;
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
        public static DatiMonitoraggioFESR GetById(DbProvider db, int IdDatiMonitoraggioFESRValue)
		{
            DatiMonitoraggioFESR DatiMonitoraggioFESRObj = null;
            IDbCommand readCmd = db.InitCmd("ZDatiMonitoraggioFESRGetById", new string[] { "IdDatiMonitoraggioFESR" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdDatiMonitoraggioFESR", (SiarLibrary.NullTypes.IntNT)IdDatiMonitoraggioFESRValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                DatiMonitoraggioFESRObj = GetFromDatareader(db);
                DatiMonitoraggioFESRObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DatiMonitoraggioFESRObj.IsDirty = false;
                DatiMonitoraggioFESRObj.IsPersistent = true;
            }
            db.Close();
            return DatiMonitoraggioFESRObj;
		}

		//getFromDatareader
		public static DatiMonitoraggioFESR GetFromDatareader(DbProvider db)
		{
            DatiMonitoraggioFESR DatiMonitoraggioFESRObj = new DatiMonitoraggioFESR();
            DatiMonitoraggioFESRObj.IdDatiMonitoraggioFESR = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DATI_MONIT"]);
            DatiMonitoraggioFESRObj.IdCUPCategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUP_CATEGORIA"]);
            DatiMonitoraggioFESRObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            DatiMonitoraggioFESRObj.IdCUPCategoriaSoggetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUP_CATEGORIA_SOGGETTO"]);
            DatiMonitoraggioFESRObj.IdTemaPrioritario = new SiarLibrary.NullTypes.StringNT(db.DataReader["TEMA_PRIORITARIO"]);
            DatiMonitoraggioFESRObj.IdAteco2007 = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_ATECO"]);
            DatiMonitoraggioFESRObj.IdAttivitaEcon = new SiarLibrary.NullTypes.StringNT(db.DataReader["ATTIVITA_ECON"]);
            DatiMonitoraggioFESRObj.IdCPTSettore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CPT_SETTORE"]);
            DatiMonitoraggioFESRObj.IdDimensioneTerr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUP_DIMENSIONE_TERR"]);
            DatiMonitoraggioFESRObj.IdCUPNatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUP_NATURA"]);
            DatiMonitoraggioFESRObj.IdCUPCategoriaTipoOperazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUP_CATEGORIA_TIPOOPER"]);
            DatiMonitoraggioFESRObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            DatiMonitoraggioFESRObj.IsDirty = false;
            DatiMonitoraggioFESRObj.IsPersistent = true;
            return DatiMonitoraggioFESRObj;
		}

		//Find Select

        public static DatiMonitoraggioFESRCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDatiMonitoraggioFESREqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)
		{

            DatiMonitoraggioFESRCollection DatiMonitoraggioFESRCollectionObj = new DatiMonitoraggioFESRCollection();
            IDbCommand findCmd = db.InitCmd("ZDatiMonitoraggioFESRfindselect", new string[] {"IdDatiMonitoraggioFESRequalthis", "IdProgettoequalthis"}, new string[] {"int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDatiMonitoraggioFESRequalthis", IdDatiMonitoraggioFESREqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DatiMonitoraggioFESR DatiMonitoraggioFESRObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DatiMonitoraggioFESRObj = GetFromDatareader(db);
                DatiMonitoraggioFESRObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DatiMonitoraggioFESRObj.IsDirty = false;
                DatiMonitoraggioFESRObj.IsPersistent = true;
                DatiMonitoraggioFESRCollectionObj.Add(DatiMonitoraggioFESRObj);
            }
            db.Close();
            return DatiMonitoraggioFESRCollectionObj;
		}

		//Find Find

        public static DatiMonitoraggioFESRCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDatiMonitoraggioFESREqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)
		{

            DatiMonitoraggioFESRCollection DatiMonitoraggioFESRCollectionObj = new DatiMonitoraggioFESRCollection();

            IDbCommand findCmd = db.InitCmd("ZDatiMonitoraggioFESRfindfind", new string[] { "IdDatiMonitoraggioFESRequalthis", "IdProgettoequalthis" }, new string[] { "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDatiMonitoraggioFESRequalthis", IdDatiMonitoraggioFESREqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DatiMonitoraggioFESR DatiMonitoraggioFESRObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DatiMonitoraggioFESRObj = GetFromDatareader(db);
                DatiMonitoraggioFESRObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DatiMonitoraggioFESRObj.IsDirty = false;
                DatiMonitoraggioFESRObj.IsPersistent = true;
                DatiMonitoraggioFESRCollectionObj.Add(DatiMonitoraggioFESRObj);
            }
            db.Close();
            return DatiMonitoraggioFESRCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DATI_MONITORAGGIO_FESR>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
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
      <ID_DATI_MONIT>Equal</ID_DATI_MONIT>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DATI_MONITORAGGIO_FESR>
*/