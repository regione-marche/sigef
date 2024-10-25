using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

/* STORIA
 * Data: 2016-05-26; Stato: Creazione; Autore: 
 * 
 * TODO
 * Funzioni Insert, Update, Delete (sono implementate solo le SELECT)
*/

namespace SiarDAL
{

	/// <summary>
    /// Summary description for CUPCategoriaSoggettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


    public class CUPCategoriaSoggettoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CUPCategoriaSoggetto CUPCategoriaSoggettoObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdCategoria", CUPCategoriaSoggettoObj.IdCategoria);
				// altri campi sempre valorizzati
			}
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", CUPCategoriaSoggettoObj.Descrizione);
		}
		//Insert
        private static int Insert(DbProvider db, CUPCategoriaSoggetto CUPCategoriaSoggettoObj)
		{
			int i = 1;
            //try
            //{
            //    IDbCommand insertCmd = db.InitCmd("ZCUPCategoriaInsert", new string[] { "Descrizione" }, new string[] { "string" }, "");
            //    CompileIUCmd(false, insertCmd,SettoriProduttiviObj, db.CommandFirstChar);
            //    db.InitDatareader(insertCmd);
            //    if (db.DataReader.Read())
            //{
            //    SettoriProduttiviObj.IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
            //    }
            //    SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            //    SettoriProduttiviObj.IsDirty = false;
            //    SettoriProduttiviObj.IsPersistent = true;
            //}
            //finally
            //{
            //    db.Close();
            //}
			return i;
		}

		//update
        private static int Update(DbProvider db, CUPCategoriaSoggetto CUPCategoriaSoggettoObj)
		{
			int i = 1;
            //try
            //{
            //    IDbCommand updateCmd = db.InitCmd( "ZSettoriProduttiviUpdate", new string[] {"IdSettoreProduttivo", "Descrizione"}, new string[] {"int", "string"},"");
            //    CompileIUCmd(true, updateCmd,SettoriProduttiviObj, db.CommandFirstChar);
            //i = db.Execute(updateCmd);
            //    SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            //    SettoriProduttiviObj.IsDirty = false;
            //    SettoriProduttiviObj.IsPersistent = true;
            //}
            //finally
            //{
            //    db.Close();
            //}
			return i;
		}

		//Save
        public static int Save(DbProvider db, CUPCategoriaSoggetto CUPCategoriaSoggettoObj)
		{
            //switch (SettoriProduttiviObj.ObjectState)
            //{
            //    case BaseObject.ObjectStateType.Added : return Insert(db, SettoriProduttiviObj);
            //    case BaseObject.ObjectStateType.Changed : return Update(db, SettoriProduttiviObj);
            //    case BaseObject.ObjectStateType.Deleted : return Delete(db,SettoriProduttiviObj);
            //    default : 
                    return 0;
            //}
		}

        public static int SaveCollection(DbProvider db, CUPCategoriaSoggettoCollection CUPCategoriaSoggettoCollectionObj)
		{
            //db.BeginTran();
			int returnValue = 0;
            //try
            //{
            //    IDbCommand updateCmd = db.InitCmd( "ZSettoriProduttiviUpdate", new string[] {"IdSettoreProduttivo", "Descrizione"}, new string[] {"int", "string"},"");
            //    IDbCommand insertCmd = db.InitCmd( "ZSettoriProduttiviInsert", new string[] {"Descrizione"}, new string[] {"string"},"");
            //    IDbCommand deleteCmd = db.InitCmd( "ZSettoriProduttiviDelete", new string[] {"IdSettoreProduttivo"}, new string[] {"int"},"");
            //    for (int i = 0; i < SettoriProduttiviCollectionObj.Count; i++)
            //    {
            //        switch (SettoriProduttiviCollectionObj[i].ObjectState)
            //        {
            //            case BaseObject.ObjectStateType.Added : 
            //                {
            //                    CompileIUCmd(false, insertCmd,SettoriProduttiviCollectionObj[i], db.CommandFirstChar);
            //                    db.InitDatareader(insertCmd);
            //                    if (db.DataReader.Read())
            //                    {
            //                        SettoriProduttiviCollectionObj[i].IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
            //                    }
            //                    db.DataReader.Close();
            //                    returnValue++;
            //                }
            //                break;
            //            case BaseObject.ObjectStateType.Changed : 
            //                {
            //                    CompileIUCmd(true, updateCmd,SettoriProduttiviCollectionObj[i], db.CommandFirstChar);
            //                    returnValue = returnValue + db.Execute(updateCmd);
            //                }
            //                break;
            //            case BaseObject.ObjectStateType.Deleted : 
            //                {
            //                    if (SettoriProduttiviCollectionObj[i].IsPersistent)
            //                    {
            //                        DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)SettoriProduttiviCollectionObj[i].IdSettoreProduttivo);
            //                        returnValue = returnValue + db.Execute(deleteCmd);
            //                    }
            //                }
            //                break;
            //        }
            //    }
            //    db.Commit();
            //    for (int i = 0; i < SettoriProduttiviCollectionObj.Count; i++)
            //    {
            //        if ((SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
            //        {
            //            SettoriProduttiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
            //            SettoriProduttiviCollectionObj[i].IsDirty = false;
            //            SettoriProduttiviCollectionObj[i].IsPersistent = true;
            //        }
            //        if ((SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
            //        {
            //            SettoriProduttiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
            //            SettoriProduttiviCollectionObj[i].IsDirty = false;
            //            SettoriProduttiviCollectionObj[i].IsPersistent = false;
            //        }
            //    }
            //}
            //catch 
            //{
            //    db.Rollback();
            //    throw;
            //}
            //finally
            //{
            //    db.Close();
            //}
			return returnValue;
		}

		//Delete
        public static int Delete(DbProvider db, CUPCategoriaSoggetto CUPCategoriaSoggettoObj)
		{
			int returnValue = 0;
            //if (SettoriProduttiviObj.IsPersistent) 
            //{
            //    returnValue = Delete(db, SettoriProduttiviObj.IdSettoreProduttivo);
            //}
            //SettoriProduttiviObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            //SettoriProduttiviObj.IsDirty = false;
            //SettoriProduttiviObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
        private static int Delete(DbProvider db, int IdCUPCategoriaSoggettoValue)
		{
			int i = 1;
            //try
            //{
            //    IDbCommand deleteCmd = db.InitCmd( "ZCUPCategoriaDelete", new string[] {"IdSettoreProduttivo"}, new string[] {"int"},"");
            //    DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)IdSettoreProduttivoValue);
            //    i = db.Execute(deleteCmd);
            //}
            //finally
            //{
            //    db.Close();
            //}
			return i;
		}

        public static int DeleteCollection(DbProvider db, CUPCategoriaSoggettoCollection CUPCategoriaSoggettoCollectionObj)
		{
            //db.BeginTran();
			int returnValue = 0;
            //try
            //{
            //    IDbCommand deleteCmd = db.InitCmd( "ZSettoriProduttiviDelete", new string[] {"IdSettoreProduttivo"}, new string[] {"int"},"");
            //    for (int i = 0; i < SettoriProduttiviCollectionObj.Count; i++)
            //    {
            //        DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSettoreProduttivo", SettoriProduttiviCollectionObj[i].IdSettoreProduttivo);
            //        returnValue = returnValue + db.Execute(deleteCmd);
            //    }
            //    db.Commit();
            //    for (int i = 0; i < SettoriProduttiviCollectionObj.Count; i++)
            //    {
            //        if ((SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SettoriProduttiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
            //        {
            //            SettoriProduttiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
            //            SettoriProduttiviCollectionObj[i].IsDirty = false;
            //            SettoriProduttiviCollectionObj[i].IsPersistent = false;
            //        }
            //    }
            //}
            //catch 
            //{
            //    db.Rollback();
            //    throw;
            //}
            //finally
            //{
            //    db.Close();
            //}
			return returnValue;
		}

		//getById
        public static CUPCategoriaSoggetto GetById(DbProvider db, string IdCUPCategoriaSoggettoValue)
		{
            CUPCategoriaSoggetto CUPCategoriaSoggettoObj = null;
            IDbCommand readCmd = db.InitCmd("ZCUPCategoriaSoggettoGetById", new string[] { "IdCUPCategoriaSoggetto" }, new string[] { "string" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdCUPCategoriaSoggetto", (SiarLibrary.NullTypes.StringNT)IdCUPCategoriaSoggettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
                CUPCategoriaSoggettoObj = GetFromDatareader(db);
                CUPCategoriaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CUPCategoriaSoggettoObj.IsDirty = false;
                CUPCategoriaSoggettoObj.IsPersistent = true;
			}
			db.Close();
            return CUPCategoriaSoggettoObj;
		}

		//getFromDatareader
        public static CUPCategoriaSoggetto GetFromDatareader(DbProvider db)
		{
            CUPCategoriaSoggetto CUPCategoriaSoggettoObj = new CUPCategoriaSoggetto();
            CUPCategoriaSoggettoObj.IdCategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_CUP_CATEGORIE_SOGGETTI"]);
            CUPCategoriaSoggettoObj.CodiceCategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodiceCategoria"]);
            CUPCategoriaSoggettoObj.CodiceSottocategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodiceSottocategoria"]);
            CUPCategoriaSoggettoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Descrizione"]);
            CUPCategoriaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            CUPCategoriaSoggettoObj.IsDirty = false;
            CUPCategoriaSoggettoObj.IsPersistent = true;
            return CUPCategoriaSoggettoObj;
		}

		//Find Select

        public static CUPCategoriaSoggettoCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT IdCUPCategoriaSoggettoEqualThis, SiarLibrary.NullTypes.StringNT Descrizioneequalthis)

		{

            CUPCategoriaSoggettoCollection CUPCategoriaSoggettoCollectionObj = new CUPCategoriaSoggettoCollection();

            IDbCommand findCmd = db.InitCmd("ZCUPCategoriaSoggettofindselect", new string[] { "IdCUPCategoriaSoggettoequalthis", "Descrizioneequalthis" }, new string[] { "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdCUPCategoriaSoggettoequalthis", IdCUPCategoriaSoggettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", Descrizioneequalthis);
            CUPCategoriaSoggetto CUPCategoriaSoggettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
                CUPCategoriaSoggettoObj = GetFromDatareader(db);
                CUPCategoriaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CUPCategoriaSoggettoObj.IsDirty = false;
                CUPCategoriaSoggettoObj.IsPersistent = true;
                CUPCategoriaSoggettoCollectionObj.Add(CUPCategoriaSoggettoObj);
			}
			db.Close();
            return CUPCategoriaSoggettoCollectionObj;
		}

		//Find Find

        public static CUPCategoriaSoggettoCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT IdCUPCategoriaSoggettoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

            CUPCategoriaSoggettoCollection CUPCategoriaSoggettoCollectionObj = new CUPCategoriaSoggettoCollection();

            IDbCommand findCmd = db.InitCmd("ZCUPCategoriaSoggettofindfind", new string[] { "IdCUPCategoriaSoggettoEqualThis", "Descrizionelikethis" }, new string[] { "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdCUPCategoriaSoggettoEqualThis", IdCUPCategoriaSoggettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
            CUPCategoriaSoggetto CUPCategoriaSoggettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
                CUPCategoriaSoggettoObj = GetFromDatareader(db);
                CUPCategoriaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CUPCategoriaSoggettoObj.IsDirty = false;
                CUPCategoriaSoggettoObj.IsPersistent = true;
                CUPCategoriaSoggettoCollectionObj.Add(CUPCategoriaSoggettoObj);
			}
			db.Close();
            return CUPCategoriaSoggettoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_CUP_CATEGORIE_SOGGETTI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <COD_CUP_CATEGORIE_SOGGETTI>Equal</COD_CUP_CATEGORIE_SOGGETTI>
      <Descrizione>Like</Descrizione>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_CUP_CATEGORIE_SOGGETTI>
*/