using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TipoSanzioniParametriDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class TipoSanzioniParametriDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoSanzioniParametri TipoSanzioniParametriObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Codice", TipoSanzioniParametriObj.Codice);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoSanzione", TipoSanzioniParametriObj.CodTipoSanzione);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", TipoSanzioniParametriObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "NonComportaSanzione", TipoSanzioniParametriObj.NonComportaSanzione);
			DbProvider.SetCmdParam(cmd,firstChar + "Durata", TipoSanzioniParametriObj.Durata);
			DbProvider.SetCmdParam(cmd,firstChar + "Gravita", TipoSanzioniParametriObj.Gravita);
			DbProvider.SetCmdParam(cmd,firstChar + "Entita", TipoSanzioniParametriObj.Entita);
			DbProvider.SetCmdParam(cmd,firstChar + "ClasseViolazione", TipoSanzioniParametriObj.ClasseViolazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Tooltip", TipoSanzioniParametriObj.Tooltip);
		}
		//Insert
		private static int Insert(DbProvider db, TipoSanzioniParametri TipoSanzioniParametriObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTipoSanzioniParametriInsert", new string[] {"CodTipoSanzione", "Descrizione", 
"NonComportaSanzione", "Durata", "Gravita", 
"Entita", "ClasseViolazione", "Tooltip"}, new string[] {"string", "string", 
"bool", "bool", "bool", 
"bool", "int", "string"},"");
				CompileIUCmd(false, insertCmd,TipoSanzioniParametriObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TipoSanzioniParametriObj.Codice = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE"]);
				TipoSanzioniParametriObj.NonComportaSanzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NON_COMPORTA_SANZIONE"]);
				TipoSanzioniParametriObj.Durata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DURATA"]);
				TipoSanzioniParametriObj.Gravita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GRAVITA"]);
				TipoSanzioniParametriObj.Entita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ENTITA"]);
				}
				TipoSanzioniParametriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoSanzioniParametriObj.IsDirty = false;
				TipoSanzioniParametriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TipoSanzioniParametri TipoSanzioniParametriObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoSanzioniParametriUpdate", new string[] {"Codice", "CodTipoSanzione", "Descrizione", 
"NonComportaSanzione", "Durata", "Gravita", 
"Entita", "ClasseViolazione", "Tooltip"}, new string[] {"int", "string", "string", 
"bool", "bool", "bool", 
"bool", "int", "string"},"");
				CompileIUCmd(true, updateCmd,TipoSanzioniParametriObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				TipoSanzioniParametriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoSanzioniParametriObj.IsDirty = false;
				TipoSanzioniParametriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TipoSanzioniParametri TipoSanzioniParametriObj)
		{
			switch (TipoSanzioniParametriObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TipoSanzioniParametriObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TipoSanzioniParametriObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TipoSanzioniParametriObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TipoSanzioniParametriCollection TipoSanzioniParametriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoSanzioniParametriUpdate", new string[] {"Codice", "CodTipoSanzione", "Descrizione", 
"NonComportaSanzione", "Durata", "Gravita", 
"Entita", "ClasseViolazione", "Tooltip"}, new string[] {"int", "string", "string", 
"bool", "bool", "bool", 
"bool", "int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTipoSanzioniParametriInsert", new string[] {"CodTipoSanzione", "Descrizione", 
"NonComportaSanzione", "Durata", "Gravita", 
"Entita", "ClasseViolazione", "Tooltip"}, new string[] {"string", "string", 
"bool", "bool", "bool", 
"bool", "int", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTipoSanzioniParametriDelete", new string[] {"Codice"}, new string[] {"int"},"");
				for (int i = 0; i < TipoSanzioniParametriCollectionObj.Count; i++)
				{
					switch (TipoSanzioniParametriCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TipoSanzioniParametriCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TipoSanzioniParametriCollectionObj[i].Codice = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE"]);
									TipoSanzioniParametriCollectionObj[i].NonComportaSanzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NON_COMPORTA_SANZIONE"]);
									TipoSanzioniParametriCollectionObj[i].Durata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DURATA"]);
									TipoSanzioniParametriCollectionObj[i].Gravita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GRAVITA"]);
									TipoSanzioniParametriCollectionObj[i].Entita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ENTITA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TipoSanzioniParametriCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TipoSanzioniParametriCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.IntNT)TipoSanzioniParametriCollectionObj[i].Codice);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TipoSanzioniParametriCollectionObj.Count; i++)
				{
					if ((TipoSanzioniParametriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoSanzioniParametriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoSanzioniParametriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TipoSanzioniParametriCollectionObj[i].IsDirty = false;
						TipoSanzioniParametriCollectionObj[i].IsPersistent = true;
					}
					if ((TipoSanzioniParametriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TipoSanzioniParametriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoSanzioniParametriCollectionObj[i].IsDirty = false;
						TipoSanzioniParametriCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TipoSanzioniParametri TipoSanzioniParametriObj)
		{
			int returnValue = 0;
			if (TipoSanzioniParametriObj.IsPersistent) 
			{
				returnValue = Delete(db, TipoSanzioniParametriObj.Codice);
			}
			TipoSanzioniParametriObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TipoSanzioniParametriObj.IsDirty = false;
			TipoSanzioniParametriObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int CodiceValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoSanzioniParametriDelete", new string[] {"Codice"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.IntNT)CodiceValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TipoSanzioniParametriCollection TipoSanzioniParametriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoSanzioniParametriDelete", new string[] {"Codice"}, new string[] {"int"},"");
				for (int i = 0; i < TipoSanzioniParametriCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", TipoSanzioniParametriCollectionObj[i].Codice);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TipoSanzioniParametriCollectionObj.Count; i++)
				{
					if ((TipoSanzioniParametriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoSanzioniParametriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoSanzioniParametriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoSanzioniParametriCollectionObj[i].IsDirty = false;
						TipoSanzioniParametriCollectionObj[i].IsPersistent = false;
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
		public static TipoSanzioniParametri GetById(DbProvider db, int CodiceValue)
		{
			TipoSanzioniParametri TipoSanzioniParametriObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTipoSanzioniParametriGetById", new string[] {"Codice"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.IntNT)CodiceValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TipoSanzioniParametriObj = GetFromDatareader(db);
				TipoSanzioniParametriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoSanzioniParametriObj.IsDirty = false;
				TipoSanzioniParametriObj.IsPersistent = true;
			}
			db.Close();
			return TipoSanzioniParametriObj;
		}

		//getFromDatareader
		public static TipoSanzioniParametri GetFromDatareader(DbProvider db)
		{
			TipoSanzioniParametri TipoSanzioniParametriObj = new TipoSanzioniParametri();
			TipoSanzioniParametriObj.Codice = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE"]);
			TipoSanzioniParametriObj.CodTipoSanzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_SANZIONE"]);
			TipoSanzioniParametriObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			TipoSanzioniParametriObj.NonComportaSanzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NON_COMPORTA_SANZIONE"]);
			TipoSanzioniParametriObj.Durata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DURATA"]);
			TipoSanzioniParametriObj.Gravita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GRAVITA"]);
			TipoSanzioniParametriObj.Entita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ENTITA"]);
			TipoSanzioniParametriObj.ClasseViolazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["CLASSE_VIOLAZIONE"]);
			TipoSanzioniParametriObj.Tooltip = new SiarLibrary.NullTypes.StringNT(db.DataReader["TOOLTIP"]);
			TipoSanzioniParametriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TipoSanzioniParametriObj.IsDirty = false;
			TipoSanzioniParametriObj.IsPersistent = true;
			return TipoSanzioniParametriObj;
		}

		//Find Select

		public static TipoSanzioniParametriCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT CodTipoSanzioneEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.BoolNT NonComportaSanzioneEqualThis, SiarLibrary.NullTypes.BoolNT DurataEqualThis, SiarLibrary.NullTypes.BoolNT GravitaEqualThis, 
SiarLibrary.NullTypes.BoolNT EntitaEqualThis, SiarLibrary.NullTypes.IntNT ClasseViolazioneEqualThis, SiarLibrary.NullTypes.StringNT TooltipEqualThis)

		{

			TipoSanzioniParametriCollection TipoSanzioniParametriCollectionObj = new TipoSanzioniParametriCollection();

			IDbCommand findCmd = db.InitCmd("Ztiposanzioniparametrifindselect", new string[] {"Codiceequalthis", "CodTipoSanzioneequalthis", "Descrizioneequalthis", 
"NonComportaSanzioneequalthis", "Durataequalthis", "Gravitaequalthis", 
"Entitaequalthis", "ClasseViolazioneequalthis", "Tooltipequalthis"}, new string[] {"int", "string", "string", 
"bool", "bool", "bool", 
"bool", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSanzioneequalthis", CodTipoSanzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NonComportaSanzioneequalthis", NonComportaSanzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Durataequalthis", DurataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Gravitaequalthis", GravitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Entitaequalthis", EntitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ClasseViolazioneequalthis", ClasseViolazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tooltipequalthis", TooltipEqualThis);
			TipoSanzioniParametri TipoSanzioniParametriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoSanzioniParametriObj = GetFromDatareader(db);
				TipoSanzioniParametriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoSanzioniParametriObj.IsDirty = false;
				TipoSanzioniParametriObj.IsPersistent = true;
				TipoSanzioniParametriCollectionObj.Add(TipoSanzioniParametriObj);
			}
			db.Close();
			return TipoSanzioniParametriCollectionObj;
		}

		//Find Find

		public static TipoSanzioniParametriCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT CodTipoSanzioneEqualThis, SiarLibrary.NullTypes.BoolNT DurataEqualThis, 
SiarLibrary.NullTypes.BoolNT GravitaEqualThis, SiarLibrary.NullTypes.BoolNT EntitaEqualThis)

		{

			TipoSanzioniParametriCollection TipoSanzioniParametriCollectionObj = new TipoSanzioniParametriCollection();

			IDbCommand findCmd = db.InitCmd("Ztiposanzioniparametrifindfind", new string[] {"Codiceequalthis", "CodTipoSanzioneequalthis", "Durataequalthis", 
"Gravitaequalthis", "Entitaequalthis"}, new string[] {"int", "string", "bool", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSanzioneequalthis", CodTipoSanzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Durataequalthis", DurataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Gravitaequalthis", GravitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Entitaequalthis", EntitaEqualThis);
			TipoSanzioniParametri TipoSanzioniParametriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoSanzioniParametriObj = GetFromDatareader(db);
				TipoSanzioniParametriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoSanzioniParametriObj.IsDirty = false;
				TipoSanzioniParametriObj.IsPersistent = true;
				TipoSanzioniParametriCollectionObj.Add(TipoSanzioniParametriObj);
			}
			db.Close();
			return TipoSanzioniParametriCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_SANZIONI_PARAMETRI>
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
    <Find OrderBy="ORDER BY CLASSE_VIOLAZIONE">
      <CODICE>Equal</CODICE>
      <COD_TIPO_SANZIONE>Equal</COD_TIPO_SANZIONE>
      <DURATA>Equal</DURATA>
      <GRAVITA>Equal</GRAVITA>
      <ENTITA>Equal</ENTITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipoParametro>
      <DURATA>Equal</DURATA>
      <GRAVITA>Equal</GRAVITA>
      <ENTITA>Equal</ENTITA>
    </FiltroTipoParametro>
  </Filters>
  <externalFields />
  <AddedFkFields />
</TIPO_SANZIONI_PARAMETRI>
*/