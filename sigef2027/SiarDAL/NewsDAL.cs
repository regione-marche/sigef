using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for NewsDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class NewsDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, News NewsObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdNews", NewsObj.IdNews);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Titolo", NewsObj.Titolo);
			DbProvider.SetCmdParam(cmd,firstChar + "Testo", NewsObj.Testo);
			DbProvider.SetCmdParam(cmd,firstChar + "Url", NewsObj.Url);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", NewsObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", NewsObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "InterruzioneSistema", NewsObj.InterruzioneSistema);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", NewsObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", NewsObj.DataFine);
		}
		//Insert
		private static int Insert(DbProvider db, News NewsObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZNewsInsert", new string[] {"Titolo", "Testo", 
"Url", "Data", "Operatore", 
"InterruzioneSistema", "DataInizio", "DataFine"}, new string[] {"string", "string", 
"string", "DateTime", "string", 
"bool", "DateTime", "DateTime"},"");
				CompileIUCmd(false, insertCmd,NewsObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				NewsObj.IdNews = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NEWS"]);
				}
				NewsObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NewsObj.IsDirty = false;
				NewsObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, News NewsObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZNewsUpdate", new string[] {"IdNews", "Titolo", "Testo", 
"Url", "Data", "Operatore", 
"InterruzioneSistema", "DataInizio", "DataFine"}, new string[] {"int", "string", "string", 
"string", "DateTime", "string", 
"bool", "DateTime", "DateTime"},"");
				CompileIUCmd(true, updateCmd,NewsObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				NewsObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NewsObj.IsDirty = false;
				NewsObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, News NewsObj)
		{
			switch (NewsObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, NewsObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, NewsObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,NewsObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, NewsCollection NewsCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZNewsUpdate", new string[] {"IdNews", "Titolo", "Testo", 
"Url", "Data", "Operatore", 
"InterruzioneSistema", "DataInizio", "DataFine"}, new string[] {"int", "string", "string", 
"string", "DateTime", "string", 
"bool", "DateTime", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZNewsInsert", new string[] {"Titolo", "Testo", 
"Url", "Data", "Operatore", 
"InterruzioneSistema", "DataInizio", "DataFine"}, new string[] {"string", "string", 
"string", "DateTime", "string", 
"bool", "DateTime", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZNewsDelete", new string[] {"IdNews"}, new string[] {"int"},"");
				for (int i = 0; i < NewsCollectionObj.Count; i++)
				{
					switch (NewsCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,NewsCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									NewsCollectionObj[i].IdNews = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NEWS"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,NewsCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (NewsCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdNews", (SiarLibrary.NullTypes.IntNT)NewsCollectionObj[i].IdNews);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < NewsCollectionObj.Count; i++)
				{
					if ((NewsCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (NewsCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						NewsCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						NewsCollectionObj[i].IsDirty = false;
						NewsCollectionObj[i].IsPersistent = true;
					}
					if ((NewsCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						NewsCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						NewsCollectionObj[i].IsDirty = false;
						NewsCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, News NewsObj)
		{
			int returnValue = 0;
			if (NewsObj.IsPersistent) 
			{
				returnValue = Delete(db, NewsObj.IdNews);
			}
			NewsObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			NewsObj.IsDirty = false;
			NewsObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdNewsValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZNewsDelete", new string[] {"IdNews"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdNews", (SiarLibrary.NullTypes.IntNT)IdNewsValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, NewsCollection NewsCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZNewsDelete", new string[] {"IdNews"}, new string[] {"int"},"");
				for (int i = 0; i < NewsCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdNews", NewsCollectionObj[i].IdNews);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < NewsCollectionObj.Count; i++)
				{
					if ((NewsCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (NewsCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						NewsCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						NewsCollectionObj[i].IsDirty = false;
						NewsCollectionObj[i].IsPersistent = false;
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
		public static News GetById(DbProvider db, int IdNewsValue)
		{
			News NewsObj = null;
			IDbCommand readCmd = db.InitCmd( "ZNewsGetById", new string[] {"IdNews"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdNews", (SiarLibrary.NullTypes.IntNT)IdNewsValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				NewsObj = GetFromDatareader(db);
				NewsObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NewsObj.IsDirty = false;
				NewsObj.IsPersistent = true;
			}
			db.Close();
			return NewsObj;
		}

		//getFromDatareader
		public static News GetFromDatareader(DbProvider db)
		{
			News NewsObj = new News();
			NewsObj.IdNews = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NEWS"]);
			NewsObj.Titolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO"]);
			NewsObj.Testo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO"]);
			NewsObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			NewsObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			NewsObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			NewsObj.InterruzioneSistema = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTERRUZIONE_SISTEMA"]);
			NewsObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			NewsObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			NewsObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			NewsObj.IsDirty = false;
			NewsObj.IsPersistent = true;
			return NewsObj;
		}

		//Find Select

		public static NewsCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdNewsEqualThis, SiarLibrary.NullTypes.StringNT TitoloEqualThis, SiarLibrary.NullTypes.StringNT TestoEqualThis, 
SiarLibrary.NullTypes.StringNT UrlEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT InterruzioneSistemaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis)

		{

			NewsCollection NewsCollectionObj = new NewsCollection();

			IDbCommand findCmd = db.InitCmd("Znewsfindselect", new string[] {"IdNewsequalthis", "Titoloequalthis", "Testoequalthis", 
"Urlequalthis", "Dataequalthis", "Operatoreequalthis", 
"InterruzioneSistemaequalthis", "DataInizioequalthis", "DataFineequalthis"}, new string[] {"int", "string", "string", 
"string", "DateTime", "string", 
"bool", "DateTime", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNewsequalthis", IdNewsEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Titoloequalthis", TitoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Testoequalthis", TestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Urlequalthis", UrlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "InterruzioneSistemaequalthis", InterruzioneSistemaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			News NewsObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				NewsObj = GetFromDatareader(db);
				NewsObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NewsObj.IsDirty = false;
				NewsObj.IsPersistent = true;
				NewsCollectionObj.Add(NewsObj);
			}
			db.Close();
			return NewsCollectionObj;
		}

		//Find Find

		public static NewsCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT TitoloLikeThis, SiarLibrary.NullTypes.StringNT TestoLikeThis, SiarLibrary.NullTypes.BoolNT InterruzioneSistemaEqualThis)

		{

			NewsCollection NewsCollectionObj = new NewsCollection();

			IDbCommand findCmd = db.InitCmd("Znewsfindfind", new string[] {"Titololikethis", "Testolikethis", "InterruzioneSistemaequalthis"}, new string[] {"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Titololikethis", TitoloLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Testolikethis", TestoLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "InterruzioneSistemaequalthis", InterruzioneSistemaEqualThis);
			News NewsObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				NewsObj = GetFromDatareader(db);
				NewsObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				NewsObj.IsDirty = false;
				NewsObj.IsPersistent = true;
				NewsCollectionObj.Add(NewsObj);
			}
			db.Close();
			return NewsCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<NEWS>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <TITOLO>Like</TITOLO>
      <TESTO>Like</TESTO>
      <INTERRUZIONE_SISTEMA>Equal</INTERRUZIONE_SISTEMA>
    </Find>
  </Finds>
  <Filters>
    <FiltroInterruzioneDiSistema>
      <INTERRUZIONE_SISTEMA>Equal</INTERRUZIONE_SISTEMA>
      <DATA_INIZIO>EqLessThan</DATA_INIZIO>
      <DATA_FINE>EqGreaterThan</DATA_FINE>
    </FiltroInterruzioneDiSistema>
  </Filters>
  <externalFields />
  <AddedFkFields />
</NEWS>
*/