using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

/* STORIA
 * Data: 2016-05-27; Statoo: Creazione; Autore: 
 * 
 * TODO
 * Funzioni Insert, Update, Delete (sono implementate solo le SELECT)
*/

namespace SiarDAL
{

	/// <summary>
    /// Summary description for Ateco2007DAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


    public class Ateco2007DAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Ateco2007 Ateco2007Obj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdAteco", Ateco2007Obj.IdAteco2007);
				// altri campi sempre valorizzati
			}
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", Ateco2007Obj.Descrizione);
		}
		//Insert
        private static int Insert(DbProvider db, Ateco2007 Ateco2007Obj)
		{
			int i = 1;
            //try
            //{
            //    IDbCommand insertCmd = db.InitCmd("ZAteco2007Insert", new string[] { "Descrizione" }, new string[] { "string" }, "");
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
        private static int Update(DbProvider db, Ateco2007 Ateco2007Obj)
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
        public static int Save(DbProvider db, Ateco2007 Ateco2007Obj)
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

        public static int SaveCollection(DbProvider db, Ateco2007Collection Ateco2007CollectionObj)
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
        public static int Delete(DbProvider db, Ateco2007 Ateco2007Obj)
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
        private static int Delete(DbProvider db, string IdAteco2007Value)
		{
			int i = 1;
            //try
            //{
            //    IDbCommand deleteCmd = db.InitCmd( "ZAteco2007Delete", new string[] {"IdSettoreProduttivo"}, new string[] {"int"},"");
            //    DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSettoreProduttivo", (SiarLibrary.NullTypes.IntNT)IdSettoreProduttivoValue);
            //    i = db.Execute(deleteCmd);
            //}
            //finally
            //{
            //    db.Close();
            //}
			return i;
		}

        public static int DeleteCollection(DbProvider db, Ateco2007Collection Ateco2007CollectionObj)
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
        public static Ateco2007 GetById(DbProvider db, string IdAteco2007Value)
		{
            Ateco2007 Ateco2007Obj = null;
            IDbCommand readCmd = db.InitCmd("ZAteco2007GetById", new string[] { "IdAteco2007" }, new string[] { "string" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdAteco2007", (SiarLibrary.NullTypes.StringNT)IdAteco2007Value);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
                Ateco2007Obj = GetFromDatareader(db);
                Ateco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                Ateco2007Obj.IsDirty = false;
                Ateco2007Obj.IsPersistent = true;
			}
			db.Close();
            return Ateco2007Obj;
		}

		//getFromDatareader
        public static Ateco2007 GetFromDatareader(DbProvider db)
		{
            Ateco2007 Ateco2007Obj = new Ateco2007();
            Ateco2007Obj.IdAteco2007 = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ATECO2007"]);
            Ateco2007Obj.Sezione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Sezione"]);
            Ateco2007Obj.Divisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Divisione"]);
            Ateco2007Obj.Gruppo = new SiarLibrary.NullTypes.StringNT(db.DataReader["Gruppo"]);
            Ateco2007Obj.Classe = new SiarLibrary.NullTypes.StringNT(db.DataReader["Classe"]);
            Ateco2007Obj.Categoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["Categoria"]);
            Ateco2007Obj.Sottocategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["Sottocategoria"]);
            Ateco2007Obj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Descrizione"]);
            Ateco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            Ateco2007Obj.IsDirty = false;
            Ateco2007Obj.IsPersistent = true;
            return Ateco2007Obj;
		}

		//Find Select

        public static Ateco2007Collection Select(DbProvider db, SiarLibrary.NullTypes.StringNT IdAteco2007EqualThis, SiarLibrary.NullTypes.StringNT Descrizioneequalthis)

		{

            Ateco2007Collection Ateco2007CollectionObj = new Ateco2007Collection();

            IDbCommand findCmd = db.InitCmd("ZAteco2007findselect", new string[] { "IdAteco2007equalthis", "Descrizioneequalthis" }, new string[] { "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAteco2007equalthis", IdAteco2007EqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", Descrizioneequalthis);
            Ateco2007 Ateco2007Obj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
                Ateco2007Obj = GetFromDatareader(db);
                Ateco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                Ateco2007Obj.IsDirty = false;
                Ateco2007Obj.IsPersistent = true;
                Ateco2007CollectionObj.Add(Ateco2007Obj);
			}
			db.Close();
            return Ateco2007CollectionObj;
		}

		//Find Find

        public static Ateco2007Collection Find(DbProvider db, SiarLibrary.NullTypes.StringNT IdAteco2007StartWithThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.IntNT idBandoequalthis)

		{

            Ateco2007Collection Ateco2007CollectionObj = new Ateco2007Collection();

            IDbCommand findCmd = db.InitCmd("ZAteco2007findfind", new string[] { "IdAteco2007StartWithThis", "Descrizionelikethis", "idBandoequalthis" }, new string[] { "string", "string", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAteco2007StartWithThis", IdAteco2007StartWithThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "idBandoequalthis", idBandoequalthis);
            Ateco2007 Ateco2007Obj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
                Ateco2007Obj = GetFromDatareader(db);
                Ateco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                Ateco2007Obj.IsDirty = false;
                Ateco2007Obj.IsPersistent = true;
                Ateco2007CollectionObj.Add(Ateco2007Obj);
			}
			db.Close();
            return Ateco2007CollectionObj;
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