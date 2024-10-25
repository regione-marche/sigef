using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProfiloXFunzioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class ProfiloXFunzioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProfiloXFunzioni ProfiloXFunzioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProfilo", ProfiloXFunzioniObj.IdProfilo);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFunzione", ProfiloXFunzioniObj.CodFunzione);
			DbProvider.SetCmdParam(cmd,firstChar + "Modifica", ProfiloXFunzioniObj.Modifica);
		}
		//Insert
		private static int Insert(DbProvider db, ProfiloXFunzioni ProfiloXFunzioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProfiloXFunzioniInsert", new string[] {"IdProfilo", 
"CodFunzione", "Modifica", 

}, new string[] {"int", 
"int", "bool", 

},"");
				CompileIUCmd(false, insertCmd,ProfiloXFunzioniObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				ProfiloXFunzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiloXFunzioniObj.IsDirty = false;
				ProfiloXFunzioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProfiloXFunzioni ProfiloXFunzioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProfiloXFunzioniUpdate", new string[] {"IdProfilo", 
"CodFunzione", "Modifica", 

}, new string[] {"int", 
"int", "bool", 

},"");
				CompileIUCmd(true, updateCmd,ProfiloXFunzioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProfiloXFunzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiloXFunzioniObj.IsDirty = false;
				ProfiloXFunzioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProfiloXFunzioni ProfiloXFunzioniObj)
		{
			switch (ProfiloXFunzioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProfiloXFunzioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProfiloXFunzioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProfiloXFunzioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProfiloXFunzioniCollection ProfiloXFunzioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProfiloXFunzioniUpdate", new string[] {"IdProfilo", 
"CodFunzione", "Modifica", 

}, new string[] {"int", 
"int", "bool", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZProfiloXFunzioniInsert", new string[] {"IdProfilo", 
"CodFunzione", "Modifica", 

}, new string[] {"int", 
"int", "bool", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProfiloXFunzioniDelete", new string[] {"IdProfilo", "CodFunzione"}, new string[] {"int", "int"},"");
				for (int i = 0; i < ProfiloXFunzioniCollectionObj.Count; i++)
				{
					switch (ProfiloXFunzioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProfiloXFunzioniCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProfiloXFunzioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProfiloXFunzioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProfilo", (SiarLibrary.NullTypes.IntNT)ProfiloXFunzioniCollectionObj[i].IdProfilo);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodFunzione", (SiarLibrary.NullTypes.IntNT)ProfiloXFunzioniCollectionObj[i].CodFunzione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProfiloXFunzioniCollectionObj.Count; i++)
				{
					if ((ProfiloXFunzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProfiloXFunzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProfiloXFunzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProfiloXFunzioniCollectionObj[i].IsDirty = false;
						ProfiloXFunzioniCollectionObj[i].IsPersistent = true;
					}
					if ((ProfiloXFunzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProfiloXFunzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProfiloXFunzioniCollectionObj[i].IsDirty = false;
						ProfiloXFunzioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProfiloXFunzioni ProfiloXFunzioniObj)
		{
			int returnValue = 0;
			if (ProfiloXFunzioniObj.IsPersistent) 
			{
				returnValue = Delete(db, ProfiloXFunzioniObj.IdProfilo, ProfiloXFunzioniObj.CodFunzione);
			}
			ProfiloXFunzioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProfiloXFunzioniObj.IsDirty = false;
			ProfiloXFunzioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProfiloValue, int CodFunzioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProfiloXFunzioniDelete", new string[] {"IdProfilo", "CodFunzione"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProfilo", (SiarLibrary.NullTypes.IntNT)IdProfiloValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodFunzione", (SiarLibrary.NullTypes.IntNT)CodFunzioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProfiloXFunzioniCollection ProfiloXFunzioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProfiloXFunzioniDelete", new string[] {"IdProfilo", "CodFunzione"}, new string[] {"int", "int"},"");
				for (int i = 0; i < ProfiloXFunzioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProfilo", ProfiloXFunzioniCollectionObj[i].IdProfilo);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodFunzione", ProfiloXFunzioniCollectionObj[i].CodFunzione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProfiloXFunzioniCollectionObj.Count; i++)
				{
					if ((ProfiloXFunzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProfiloXFunzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProfiloXFunzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProfiloXFunzioniCollectionObj[i].IsDirty = false;
						ProfiloXFunzioniCollectionObj[i].IsPersistent = false;
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
		public static ProfiloXFunzioni GetById(DbProvider db, int IdProfiloValue, int CodFunzioneValue)
		{
			ProfiloXFunzioni ProfiloXFunzioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProfiloXFunzioniGetById", new string[] {"IdProfilo", "CodFunzione"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProfilo", (SiarLibrary.NullTypes.IntNT)IdProfiloValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodFunzione", (SiarLibrary.NullTypes.IntNT)CodFunzioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProfiloXFunzioniObj = GetFromDatareader(db);
				ProfiloXFunzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiloXFunzioniObj.IsDirty = false;
				ProfiloXFunzioniObj.IsPersistent = true;
			}
			db.Close();
			return ProfiloXFunzioniObj;
		}

		//getFromDatareader
		public static ProfiloXFunzioni GetFromDatareader(DbProvider db)
		{
			ProfiloXFunzioni ProfiloXFunzioniObj = new ProfiloXFunzioni();
			ProfiloXFunzioniObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
			ProfiloXFunzioniObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ProfiloXFunzioniObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			ProfiloXFunzioniObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			ProfiloXFunzioniObj.CodFunzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_FUNZIONE"]);
			ProfiloXFunzioniObj.Modifica = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MODIFICA"]);
			ProfiloXFunzioniObj.Funzionalita = new SiarLibrary.NullTypes.StringNT(db.DataReader["FUNZIONALITA"]);
			ProfiloXFunzioniObj.FlagMenu = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_MENU"]);
			ProfiloXFunzioniObj.DescMenu = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESC_MENU"]);
			ProfiloXFunzioniObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO"]);
			ProfiloXFunzioniObj.Padre = new SiarLibrary.NullTypes.IntNT(db.DataReader["PADRE"]);
			ProfiloXFunzioniObj.Link = new SiarLibrary.NullTypes.StringNT(db.DataReader["LINK"]);
			ProfiloXFunzioniObj.OrdineFunzionalita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FUNZIONALITA"]);
			ProfiloXFunzioniObj.AbilitaInserimentoUtenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITA_INSERIMENTO_UTENTI"]);
			ProfiloXFunzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProfiloXFunzioniObj.IsDirty = false;
			ProfiloXFunzioniObj.IsPersistent = true;
			return ProfiloXFunzioniObj;
		}

		//Find Select

		public static ProfiloXFunzioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis, SiarLibrary.NullTypes.IntNT CodFunzioneEqualThis, SiarLibrary.NullTypes.BoolNT ModificaEqualThis)

		{

			ProfiloXFunzioniCollection ProfiloXFunzioniCollectionObj = new ProfiloXFunzioniCollection();

			IDbCommand findCmd = db.InitCmd("Zprofiloxfunzionifindselect", new string[] {"IdProfiloequalthis", "CodFunzioneequalthis", "Modificaequalthis"}, new string[] {"int", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFunzioneequalthis", CodFunzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Modificaequalthis", ModificaEqualThis);
			ProfiloXFunzioni ProfiloXFunzioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProfiloXFunzioniObj = GetFromDatareader(db);
				ProfiloXFunzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiloXFunzioniObj.IsDirty = false;
				ProfiloXFunzioniObj.IsPersistent = true;
				ProfiloXFunzioniCollectionObj.Add(ProfiloXFunzioniObj);
			}
			db.Close();
			return ProfiloXFunzioniCollectionObj;
		}

		//Find Find

		public static ProfiloXFunzioniCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis, SiarLibrary.NullTypes.IntNT CodFunzioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagMenuEqualThis, 
SiarLibrary.NullTypes.StringNT DescMenuEqualThis, SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.IntNT PadreEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis)

		{

			ProfiloXFunzioniCollection ProfiloXFunzioniCollectionObj = new ProfiloXFunzioniCollection();

			IDbCommand findCmd = db.InitCmd("Zprofiloxfunzionifindfind", new string[] {"IdProfiloequalthis", "CodFunzioneequalthis", "FlagMenuequalthis", 
"DescMenuequalthis", "Livelloequalthis", "Padreequalthis", 
"Ordineequalthis", "CodTipoEnteequalthis"}, new string[] {"int", "int", "bool", 
"string", "int", "int", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFunzioneequalthis", CodFunzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagMenuequalthis", FlagMenuEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescMenuequalthis", DescMenuEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Padreequalthis", PadreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
			ProfiloXFunzioni ProfiloXFunzioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProfiloXFunzioniObj = GetFromDatareader(db);
				ProfiloXFunzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiloXFunzioniObj.IsDirty = false;
				ProfiloXFunzioniObj.IsPersistent = true;
				ProfiloXFunzioniCollectionObj.Add(ProfiloXFunzioniObj);
			}
			db.Close();
			return ProfiloXFunzioniCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROFILO_X_FUNZIONI>
  <ViewName>vPROFILO_X_FUNZIONI</ViewName>
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
    <Find>
      <ID_PROFILO>Equal</ID_PROFILO>
      <COD_FUNZIONE>Equal</COD_FUNZIONE>
      <FLAG_MENU>Equal</FLAG_MENU>
      <DESC_MENU>Equal</DESC_MENU>
      <LIVELLO>Equal</LIVELLO>
      <PADRE>Equal</PADRE>
      <ORDINE>Equal</ORDINE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
    </Find>
  </Finds>
  <Filters>
    <FiltroModifica>
      <MODIFICA>Equal</MODIFICA>
    </FiltroModifica>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROFILO_X_FUNZIONI>
*/