using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

    /// <summary>
    /// Summary description for RequisitiVarianteDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    public class RequisitiVarianteDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RequisitiVariante RequisitiVarianteObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdRequisito", RequisitiVarianteObj.IdRequisito);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Automatico", RequisitiVarianteObj.Automatico);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", RequisitiVarianteObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "QueryEval", RequisitiVarianteObj.QueryEval);
            DbProvider.SetCmdParam(cmd, firstChar + "QueryInsert", RequisitiVarianteObj.QueryInsert);
            DbProvider.SetCmdParam(cmd, firstChar + "ValMinimo", RequisitiVarianteObj.ValMinimo);
            DbProvider.SetCmdParam(cmd, firstChar + "ValMassimo", RequisitiVarianteObj.ValMassimo);
            DbProvider.SetCmdParam(cmd, firstChar + "Misura", RequisitiVarianteObj.Misura);
        }
        //Insert
        private static int Insert(DbProvider db, RequisitiVariante RequisitiVarianteObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZRequisitiVarianteInsert", new string[] {"Automatico", "Descrizione", 
"QueryEval", "QueryInsert", "ValMinimo", 
"ValMassimo", "Misura"}, new string[] {"bool", "string", 
"string", "string", "decimal", 
"decimal", "string"}, "");
                CompileIUCmd(false, insertCmd, RequisitiVarianteObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    RequisitiVarianteObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
                }
                RequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RequisitiVarianteObj.IsDirty = false;
                RequisitiVarianteObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, RequisitiVariante RequisitiVarianteObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRequisitiVarianteUpdate", new string[] {"IdRequisito", "Automatico", "Descrizione", 
"QueryEval", "QueryInsert", "ValMinimo", 
"ValMassimo", "Misura"}, new string[] {"int", "bool", "string", 
"string", "string", "decimal", 
"decimal", "string"}, "");
                CompileIUCmd(true, updateCmd, RequisitiVarianteObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                RequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RequisitiVarianteObj.IsDirty = false;
                RequisitiVarianteObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, RequisitiVariante RequisitiVarianteObj)
        {
            switch (RequisitiVarianteObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, RequisitiVarianteObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, RequisitiVarianteObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, RequisitiVarianteObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, RequisitiVarianteCollection RequisitiVarianteCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRequisitiVarianteUpdate", new string[] {"IdRequisito", "Automatico", "Descrizione", 
"QueryEval", "QueryInsert", "ValMinimo", 
"ValMassimo", "Misura"}, new string[] {"int", "bool", "string", 
"string", "string", "decimal", 
"decimal", "string"}, "");
                IDbCommand insertCmd = db.InitCmd("ZRequisitiVarianteInsert", new string[] {"Automatico", "Descrizione", 
"QueryEval", "QueryInsert", "ValMinimo", 
"ValMassimo", "Misura"}, new string[] {"bool", "string", 
"string", "string", "decimal", 
"decimal", "string"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZRequisitiVarianteDelete", new string[] { "IdRequisito" }, new string[] { "int" }, "");
                for (int i = 0; i < RequisitiVarianteCollectionObj.Count; i++)
                {
                    switch (RequisitiVarianteCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, RequisitiVarianteCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    RequisitiVarianteCollectionObj[i].IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, RequisitiVarianteCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (RequisitiVarianteCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)RequisitiVarianteCollectionObj[i].IdRequisito);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < RequisitiVarianteCollectionObj.Count; i++)
                {
                    if ((RequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RequisitiVarianteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        RequisitiVarianteCollectionObj[i].IsDirty = false;
                        RequisitiVarianteCollectionObj[i].IsPersistent = true;
                    }
                    if ((RequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        RequisitiVarianteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RequisitiVarianteCollectionObj[i].IsDirty = false;
                        RequisitiVarianteCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, RequisitiVariante RequisitiVarianteObj)
        {
            int returnValue = 0;
            if (RequisitiVarianteObj.IsPersistent)
            {
                returnValue = Delete(db, RequisitiVarianteObj.IdRequisito);
            }
            RequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            RequisitiVarianteObj.IsDirty = false;
            RequisitiVarianteObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdRequisitoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRequisitiVarianteDelete", new string[] { "IdRequisito" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, RequisitiVarianteCollection RequisitiVarianteCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRequisitiVarianteDelete", new string[] { "IdRequisito" }, new string[] { "int" }, "");
                for (int i = 0; i < RequisitiVarianteCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRequisito", RequisitiVarianteCollectionObj[i].IdRequisito);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < RequisitiVarianteCollectionObj.Count; i++)
                {
                    if ((RequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RequisitiVarianteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RequisitiVarianteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RequisitiVarianteCollectionObj[i].IsDirty = false;
                        RequisitiVarianteCollectionObj[i].IsPersistent = false;
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
        public static RequisitiVariante GetById(DbProvider db, int IdRequisitoValue)
        {
            RequisitiVariante RequisitiVarianteObj = null;
            IDbCommand readCmd = db.InitCmd("ZRequisitiVarianteGetById", new string[] { "IdRequisito" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdRequisito", (SiarLibrary.NullTypes.IntNT)IdRequisitoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                RequisitiVarianteObj = GetFromDatareader(db);
                RequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RequisitiVarianteObj.IsDirty = false;
                RequisitiVarianteObj.IsPersistent = true;
            }
            db.Close();
            return RequisitiVarianteObj;
        }

        //getFromDatareader
        public static RequisitiVariante GetFromDatareader(DbProvider db)
        {
            RequisitiVariante RequisitiVarianteObj = new RequisitiVariante();
            RequisitiVarianteObj.IdRequisito = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REQUISITO"]);
            RequisitiVarianteObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
            RequisitiVarianteObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            RequisitiVarianteObj.QueryEval = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_EVAL"]);
            RequisitiVarianteObj.QueryInsert = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_INSERT"]);
            RequisitiVarianteObj.ValMinimo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VAL_MINIMO"]);
            RequisitiVarianteObj.ValMassimo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VAL_MASSIMO"]);
            RequisitiVarianteObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
            RequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            RequisitiVarianteObj.IsDirty = false;
            RequisitiVarianteObj.IsPersistent = true;
            return RequisitiVarianteObj;
        }

        //Find Select

        public static RequisitiVarianteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis,
SiarLibrary.NullTypes.StringNT QueryEvalEqualThis, SiarLibrary.NullTypes.StringNT QueryInsertEqualThis, SiarLibrary.NullTypes.DecimalNT ValMinimoEqualThis,
SiarLibrary.NullTypes.DecimalNT ValMassimoEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis)
        {

            RequisitiVarianteCollection RequisitiVarianteCollectionObj = new RequisitiVarianteCollection();

            IDbCommand findCmd = db.InitCmd("Zrequisitivariantefindselect", new string[] {"IdRequisitoequalthis", "Automaticoequalthis", "Descrizioneequalthis", 
"QueryEvalequalthis", "QueryInsertequalthis", "ValMinimoequalthis", 
"ValMassimoequalthis", "Misuraequalthis"}, new string[] {"int", "bool", "string", 
"string", "string", "decimal", 
"decimal", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QueryEvalequalthis", QueryEvalEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QueryInsertequalthis", QueryInsertEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValMinimoequalthis", ValMinimoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValMassimoequalthis", ValMassimoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
            RequisitiVariante RequisitiVarianteObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RequisitiVarianteObj = GetFromDatareader(db);
                RequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RequisitiVarianteObj.IsDirty = false;
                RequisitiVarianteObj.IsPersistent = true;
                RequisitiVarianteCollectionObj.Add(RequisitiVarianteObj);
            }
            db.Close();
            return RequisitiVarianteCollectionObj;
        }

        //Find Find

        public static RequisitiVarianteCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRequisitoEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis)
        {

            RequisitiVarianteCollection RequisitiVarianteCollectionObj = new RequisitiVarianteCollection();

            IDbCommand findCmd = db.InitCmd("Zrequisitivariantefindfind", new string[] { "IdRequisitoequalthis", "Automaticoequalthis" }, new string[] { "int", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRequisitoequalthis", IdRequisitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
            RequisitiVariante RequisitiVarianteObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RequisitiVarianteObj = GetFromDatareader(db);
                RequisitiVarianteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RequisitiVarianteObj.IsDirty = false;
                RequisitiVarianteObj.IsPersistent = true;
                RequisitiVarianteCollectionObj.Add(RequisitiVarianteObj);
            }
            db.Close();
            return RequisitiVarianteCollectionObj;
        }

    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REQUISITI_VARIANTE>
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
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <AUTOMATICO>Equal</AUTOMATICO>
    </Find>
  </Finds>
  <Filters>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</REQUISITI_VARIANTE>
*/