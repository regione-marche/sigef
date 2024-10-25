using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CollaboratoriXManifestazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class CollaboratoriXManifestazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CollaboratoriXManifestazione CollaboratoriXManifestazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCollaboratore", CollaboratoriXManifestazioneObj.IdCollaboratore);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", CollaboratoriXManifestazioneObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdManifestazione", CollaboratoriXManifestazioneObj.IdManifestazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CfUtente", CollaboratoriXManifestazioneObj.CfUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CollaboratoriXManifestazioneObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", CollaboratoriXManifestazioneObj.DataInserimento);
		}
		//Insert
		private static int Insert(DbProvider db, CollaboratoriXManifestazione CollaboratoriXManifestazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCollaboratoriXManifestazioneInsert", new string[] {"IdBando", "IdManifestazione", 
"CfUtente", "Operatore", 
"DataInserimento", 

}, new string[] {"int", "int", 
"string", "string", 
"DateTime", 

},"");
				CompileIUCmd(false, insertCmd,CollaboratoriXManifestazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CollaboratoriXManifestazioneObj.IdCollaboratore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COLLABORATORE"]);
				}
				CollaboratoriXManifestazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXManifestazioneObj.IsDirty = false;
				CollaboratoriXManifestazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CollaboratoriXManifestazione CollaboratoriXManifestazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCollaboratoriXManifestazioneUpdate", new string[] {"IdCollaboratore", "IdBando", "IdManifestazione", 
"CfUtente", "Operatore", 
"DataInserimento", 

}, new string[] {"int", "int", "int", 
"string", "string", 
"DateTime", 

},"");
				CompileIUCmd(true, updateCmd,CollaboratoriXManifestazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CollaboratoriXManifestazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXManifestazioneObj.IsDirty = false;
				CollaboratoriXManifestazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CollaboratoriXManifestazione CollaboratoriXManifestazioneObj)
		{
			switch (CollaboratoriXManifestazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CollaboratoriXManifestazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CollaboratoriXManifestazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CollaboratoriXManifestazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CollaboratoriXManifestazioneCollection CollaboratoriXManifestazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCollaboratoriXManifestazioneUpdate", new string[] {"IdCollaboratore", "IdBando", "IdManifestazione", 
"CfUtente", "Operatore", 
"DataInserimento", 

}, new string[] {"int", "int", "int", 
"string", "string", 
"DateTime", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZCollaboratoriXManifestazioneInsert", new string[] {"IdBando", "IdManifestazione", 
"CfUtente", "Operatore", 
"DataInserimento", 

}, new string[] {"int", "int", 
"string", "string", 
"DateTime", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriXManifestazioneDelete", new string[] {"IdCollaboratore"}, new string[] {"int"},"");
				for (int i = 0; i < CollaboratoriXManifestazioneCollectionObj.Count; i++)
				{
					switch (CollaboratoriXManifestazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CollaboratoriXManifestazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CollaboratoriXManifestazioneCollectionObj[i].IdCollaboratore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COLLABORATORE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CollaboratoriXManifestazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CollaboratoriXManifestazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCollaboratore", (SiarLibrary.NullTypes.IntNT)CollaboratoriXManifestazioneCollectionObj[i].IdCollaboratore);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CollaboratoriXManifestazioneCollectionObj.Count; i++)
				{
					if ((CollaboratoriXManifestazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CollaboratoriXManifestazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CollaboratoriXManifestazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CollaboratoriXManifestazioneCollectionObj[i].IsDirty = false;
						CollaboratoriXManifestazioneCollectionObj[i].IsPersistent = true;
					}
					if ((CollaboratoriXManifestazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CollaboratoriXManifestazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CollaboratoriXManifestazioneCollectionObj[i].IsDirty = false;
						CollaboratoriXManifestazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CollaboratoriXManifestazione CollaboratoriXManifestazioneObj)
		{
			int returnValue = 0;
			if (CollaboratoriXManifestazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, CollaboratoriXManifestazioneObj.IdCollaboratore);
			}
			CollaboratoriXManifestazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CollaboratoriXManifestazioneObj.IsDirty = false;
			CollaboratoriXManifestazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCollaboratoreValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriXManifestazioneDelete", new string[] {"IdCollaboratore"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCollaboratore", (SiarLibrary.NullTypes.IntNT)IdCollaboratoreValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CollaboratoriXManifestazioneCollection CollaboratoriXManifestazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriXManifestazioneDelete", new string[] {"IdCollaboratore"}, new string[] {"int"},"");
				for (int i = 0; i < CollaboratoriXManifestazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCollaboratore", CollaboratoriXManifestazioneCollectionObj[i].IdCollaboratore);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CollaboratoriXManifestazioneCollectionObj.Count; i++)
				{
					if ((CollaboratoriXManifestazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CollaboratoriXManifestazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CollaboratoriXManifestazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CollaboratoriXManifestazioneCollectionObj[i].IsDirty = false;
						CollaboratoriXManifestazioneCollectionObj[i].IsPersistent = false;
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
		public static CollaboratoriXManifestazione GetById(DbProvider db, int IdCollaboratoreValue)
		{
			CollaboratoriXManifestazione CollaboratoriXManifestazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCollaboratoriXManifestazioneGetById", new string[] {"IdCollaboratore"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCollaboratore", (SiarLibrary.NullTypes.IntNT)IdCollaboratoreValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CollaboratoriXManifestazioneObj = GetFromDatareader(db);
				CollaboratoriXManifestazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXManifestazioneObj.IsDirty = false;
				CollaboratoriXManifestazioneObj.IsPersistent = true;
			}
			db.Close();
			return CollaboratoriXManifestazioneObj;
		}

		//getFromDatareader
		public static CollaboratoriXManifestazione GetFromDatareader(DbProvider db)
		{
			CollaboratoriXManifestazione CollaboratoriXManifestazioneObj = new CollaboratoriXManifestazione();
			CollaboratoriXManifestazioneObj.IdCollaboratore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COLLABORATORE"]);
			CollaboratoriXManifestazioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CollaboratoriXManifestazioneObj.IdManifestazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MANIFESTAZIONE"]);
			CollaboratoriXManifestazioneObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			CollaboratoriXManifestazioneObj.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
			CollaboratoriXManifestazioneObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			CollaboratoriXManifestazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			CollaboratoriXManifestazioneObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			CollaboratoriXManifestazioneObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			CollaboratoriXManifestazioneObj.Via = new SiarLibrary.NullTypes.StringNT(db.DataReader["VIA"]);
			CollaboratoriXManifestazioneObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			CollaboratoriXManifestazioneObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			CollaboratoriXManifestazioneObj.Sigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["SIGLA"]);
			CollaboratoriXManifestazioneObj.DataUltimaModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ULTIMA_MODIFICA"]);
			CollaboratoriXManifestazioneObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			CollaboratoriXManifestazioneObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			CollaboratoriXManifestazioneObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			CollaboratoriXManifestazioneObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			CollaboratoriXManifestazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CollaboratoriXManifestazioneObj.IsDirty = false;
			CollaboratoriXManifestazioneObj.IsPersistent = true;
			return CollaboratoriXManifestazioneObj;
		}

		//Find Select

		public static CollaboratoriXManifestazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCollaboratoreEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdManifestazioneEqualThis, 
SiarLibrary.NullTypes.StringNT CfUtenteEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis)

		{

			CollaboratoriXManifestazioneCollection CollaboratoriXManifestazioneCollectionObj = new CollaboratoriXManifestazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcollaboratorixmanifestazionefindselect", new string[] {"IdCollaboratoreequalthis", "IdBandoequalthis", "IdManifestazioneequalthis", 
"CfUtenteequalthis", "Operatoreequalthis", "DataInserimentoequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCollaboratoreequalthis", IdCollaboratoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdManifestazioneequalthis", IdManifestazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfUtenteequalthis", CfUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			CollaboratoriXManifestazione CollaboratoriXManifestazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CollaboratoriXManifestazioneObj = GetFromDatareader(db);
				CollaboratoriXManifestazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXManifestazioneObj.IsDirty = false;
				CollaboratoriXManifestazioneObj.IsPersistent = true;
				CollaboratoriXManifestazioneCollectionObj.Add(CollaboratoriXManifestazioneObj);
			}
			db.Close();
			return CollaboratoriXManifestazioneCollectionObj;
		}

		//Find Find

		public static CollaboratoriXManifestazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdManifestazioneEqualThis, SiarLibrary.NullTypes.StringNT CfUtenteEqualThis, 
SiarLibrary.NullTypes.StringNT CuaaLikeThis, SiarLibrary.NullTypes.StringNT RagioneSocialeLikeThis)

		{

			CollaboratoriXManifestazioneCollection CollaboratoriXManifestazioneCollectionObj = new CollaboratoriXManifestazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcollaboratorixmanifestazionefindfind", new string[] {"IdBandoequalthis", "IdManifestazioneequalthis", "CfUtenteequalthis", 
"Cuaalikethis", "RagioneSocialelikethis"}, new string[] {"int", "int", "string", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdManifestazioneequalthis", IdManifestazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfUtenteequalthis", CfUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaalikethis", CuaaLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialelikethis", RagioneSocialeLikeThis);
			CollaboratoriXManifestazione CollaboratoriXManifestazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CollaboratoriXManifestazioneObj = GetFromDatareader(db);
				CollaboratoriXManifestazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXManifestazioneObj.IsDirty = false;
				CollaboratoriXManifestazioneObj.IsPersistent = true;
				CollaboratoriXManifestazioneCollectionObj.Add(CollaboratoriXManifestazioneObj);
			}
			db.Close();
			return CollaboratoriXManifestazioneCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COLLABORATORI_X_MANIFESTAZIONE>
  <ViewName>vCOLLABORATORI_X_MANIFESTAZIONE</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_MANIFESTAZIONE>Equal</ID_MANIFESTAZIONE>
      <CF_UTENTE>Equal</CF_UTENTE>
      <CUAA>Like</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_X_MANIFESTAZIONE>
*/