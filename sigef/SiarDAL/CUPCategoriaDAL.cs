using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

/* STORIA
 * Data: 2016-05-24; Statoo: Creazione; Autore: 
 * 
 * TODO
 * Funzioni Insert, Update, Delete (sono implementate solo le SELECT)
*/

namespace SiarDAL
{

	/// <summary>
    /// Summary description for CUPCategoriaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


    public class CUPCategoriaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CUPCategoria CUPCategoriaObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdCategoria", CUPCategoriaObj.IdCategoria);
				// altri campi sempre valorizzati
			}
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", CUPCategoriaObj.Descrizione);
		}
		//Insert
        private static int Insert(DbProvider db, CUPCategoria CUPCategoriaObj)
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
        private static int Update(DbProvider db, CUPCategoria CUPCategoriaObj)
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
        public static int Save(DbProvider db, CUPCategoria CUPCategoriaObj)
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

        public static int SaveCollection(DbProvider db, CUPCategoriaCollection CUPCategoriaCollectionObj)
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
        public static int Delete(DbProvider db, CUPCategoria CUPCategoriaObj)
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
        private static int Delete(DbProvider db, int IdCUPCategoriaValue)
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

        public static int DeleteCollection(DbProvider db, CUPCategoriaCollection CUPCategoriaCollectionObj)
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
        public static CUPCategoria GetById(DbProvider db, string IdCUPCategoriaValue)
		{
            CUPCategoria CUPCategoriaObj = null;
            IDbCommand readCmd = db.InitCmd("ZCUPCategoriaGetById", new string[] { "IdCUPCategoria" }, new string[] { "string" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdCUPCategoria", (SiarLibrary.NullTypes.StringNT)IdCUPCategoriaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
                CUPCategoriaObj = GetFromDatareader(db);
                CUPCategoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CUPCategoriaObj.IsDirty = false;
                CUPCategoriaObj.IsPersistent = true;
			}
			db.Close();
            return CUPCategoriaObj;
		}

		//getFromDatareader
        public static CUPCategoria GetFromDatareader(DbProvider db)
		{
            CUPCategoria CUPCategoriaObj = new CUPCategoria();
            CUPCategoriaObj.IdCategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_CUP_CATEGORIE"]);
            CUPCategoriaObj.Settore = new SiarLibrary.NullTypes.StringNT(db.DataReader["Settore"]);
            CUPCategoriaObj.SottoSettore = new SiarLibrary.NullTypes.StringNT(db.DataReader["SottoSettore"]);
            CUPCategoriaObj.Categoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["Categoria"]);
            CUPCategoriaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Descrizione"]);
            CUPCategoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            CUPCategoriaObj.IsDirty = false;
            CUPCategoriaObj.IsPersistent = true;
            return CUPCategoriaObj;
		}

		//Find Select

        public static CUPCategoriaCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT IdCUPCategoriaEqualThis, SiarLibrary.NullTypes.StringNT Descrizioneequalthis)

		{

            CUPCategoriaCollection CUPCategoriaCollectionObj = new CUPCategoriaCollection();

            IDbCommand findCmd = db.InitCmd("ZCUPCategoriafindselect", new string[] { "IdCUPCategoriaequalthis", "Descrizioneequalthis" }, new string[] { "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdCUPCategoriaequalthis", IdCUPCategoriaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", Descrizioneequalthis);
            CUPCategoria CUPCategoriaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
                CUPCategoriaObj = GetFromDatareader(db);
                CUPCategoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CUPCategoriaObj.IsDirty = false;
                CUPCategoriaObj.IsPersistent = true;
                CUPCategoriaCollectionObj.Add(CUPCategoriaObj);
			}
			db.Close();
            return CUPCategoriaCollectionObj;
		}

		//Find Find

        public static CUPCategoriaCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT IdCUPCategoriaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

            CUPCategoriaCollection CUPCategoriaCollectionObj = new CUPCategoriaCollection();

            IDbCommand findCmd = db.InitCmd("ZCUPCategoriafindfind", new string[] { "IdCUPCategoriaEqualThis", "Descrizionelikethis" }, new string[] { "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdCUPCategoriaEqualThis", IdCUPCategoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
            CUPCategoria CUPCategoriaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
                CUPCategoriaObj = GetFromDatareader(db);
                CUPCategoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CUPCategoriaObj.IsDirty = false;
                CUPCategoriaObj.IsPersistent = true;
                CUPCategoriaCollectionObj.Add(CUPCategoriaObj);
			}
			db.Close();
            return CUPCategoriaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SETTORI_PRODUTTIVI>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_SETTORE_PRODUTTIVO>Equal</ID_SETTORE_PRODUTTIVO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SETTORI_PRODUTTIVI>
*/