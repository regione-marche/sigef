using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CollaboratoriXBandoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class CollaboratoriXBandoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CollaboratoriXBando CollaboratoriXBandoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCollaboratore", CollaboratoriXBandoObj.IdCollaboratore);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", CollaboratoriXBandoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", CollaboratoriXBandoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Provincia", CollaboratoriXBandoObj.Provincia);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", CollaboratoriXBandoObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", CollaboratoriXBandoObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", CollaboratoriXBandoObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInserimento", CollaboratoriXBandoObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreFineValidita", CollaboratoriXBandoObj.OperatoreFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", CollaboratoriXBandoObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, CollaboratoriXBando CollaboratoriXBandoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCollaboratoriXBandoInsert", new string[] {"IdBando", "IdProgetto", 
"Provincia", "DataInserimento", "DataFineValidita", 

"IdUtente", "OperatoreInserimento", "OperatoreFineValidita", 
"Attivo"}, new string[] {"int", "int", 
"string", "DateTime", "DateTime", 

"int", "int", "int", 
"bool"},"");
				CompileIUCmd(false, insertCmd,CollaboratoriXBandoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CollaboratoriXBandoObj.IdCollaboratore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COLLABORATORE"]);
				CollaboratoriXBandoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				CollaboratoriXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXBandoObj.IsDirty = false;
				CollaboratoriXBandoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CollaboratoriXBando CollaboratoriXBandoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCollaboratoriXBandoUpdate", new string[] {"IdCollaboratore", "IdBando", "IdProgetto", 
"Provincia", "DataInserimento", "DataFineValidita", 

"IdUtente", "OperatoreInserimento", "OperatoreFineValidita", 
"Attivo"}, new string[] {"int", "int", "int", 
"string", "DateTime", "DateTime", 

"int", "int", "int", 
"bool"},"");
				CompileIUCmd(true, updateCmd,CollaboratoriXBandoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CollaboratoriXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXBandoObj.IsDirty = false;
				CollaboratoriXBandoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CollaboratoriXBando CollaboratoriXBandoObj)
		{
			switch (CollaboratoriXBandoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CollaboratoriXBandoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CollaboratoriXBandoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CollaboratoriXBandoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CollaboratoriXBandoCollection CollaboratoriXBandoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCollaboratoriXBandoUpdate", new string[] {"IdCollaboratore", "IdBando", "IdProgetto", 
"Provincia", "DataInserimento", "DataFineValidita", 

"IdUtente", "OperatoreInserimento", "OperatoreFineValidita", 
"Attivo"}, new string[] {"int", "int", "int", 
"string", "DateTime", "DateTime", 

"int", "int", "int", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCollaboratoriXBandoInsert", new string[] {"IdBando", "IdProgetto", 
"Provincia", "DataInserimento", "DataFineValidita", 

"IdUtente", "OperatoreInserimento", "OperatoreFineValidita", 
"Attivo"}, new string[] {"int", "int", 
"string", "DateTime", "DateTime", 

"int", "int", "int", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriXBandoDelete", new string[] {"IdCollaboratore"}, new string[] {"int"},"");
				for (int i = 0; i < CollaboratoriXBandoCollectionObj.Count; i++)
				{
					switch (CollaboratoriXBandoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CollaboratoriXBandoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CollaboratoriXBandoCollectionObj[i].IdCollaboratore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COLLABORATORE"]);
									CollaboratoriXBandoCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CollaboratoriXBandoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CollaboratoriXBandoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCollaboratore", (SiarLibrary.NullTypes.IntNT)CollaboratoriXBandoCollectionObj[i].IdCollaboratore);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CollaboratoriXBandoCollectionObj.Count; i++)
				{
					if ((CollaboratoriXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CollaboratoriXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CollaboratoriXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CollaboratoriXBandoCollectionObj[i].IsDirty = false;
						CollaboratoriXBandoCollectionObj[i].IsPersistent = true;
					}
					if ((CollaboratoriXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CollaboratoriXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CollaboratoriXBandoCollectionObj[i].IsDirty = false;
						CollaboratoriXBandoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CollaboratoriXBando CollaboratoriXBandoObj)
		{
			int returnValue = 0;
			if (CollaboratoriXBandoObj.IsPersistent) 
			{
				returnValue = Delete(db, CollaboratoriXBandoObj.IdCollaboratore);
			}
			CollaboratoriXBandoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CollaboratoriXBandoObj.IsDirty = false;
			CollaboratoriXBandoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCollaboratoreValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriXBandoDelete", new string[] {"IdCollaboratore"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCollaboratore", (SiarLibrary.NullTypes.IntNT)IdCollaboratoreValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CollaboratoriXBandoCollection CollaboratoriXBandoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriXBandoDelete", new string[] {"IdCollaboratore"}, new string[] {"int"},"");
				for (int i = 0; i < CollaboratoriXBandoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCollaboratore", CollaboratoriXBandoCollectionObj[i].IdCollaboratore);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CollaboratoriXBandoCollectionObj.Count; i++)
				{
					if ((CollaboratoriXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CollaboratoriXBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CollaboratoriXBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CollaboratoriXBandoCollectionObj[i].IsDirty = false;
						CollaboratoriXBandoCollectionObj[i].IsPersistent = false;
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
		public static CollaboratoriXBando GetById(DbProvider db, int IdCollaboratoreValue)
		{
			CollaboratoriXBando CollaboratoriXBandoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCollaboratoriXBandoGetById", new string[] {"IdCollaboratore"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCollaboratore", (SiarLibrary.NullTypes.IntNT)IdCollaboratoreValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CollaboratoriXBandoObj = GetFromDatareader(db);
				CollaboratoriXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXBandoObj.IsDirty = false;
				CollaboratoriXBandoObj.IsPersistent = true;
			}
			db.Close();
			return CollaboratoriXBandoObj;
		}

		//getFromDatareader
		public static CollaboratoriXBando GetFromDatareader(DbProvider db)
		{
			CollaboratoriXBando CollaboratoriXBandoObj = new CollaboratoriXBando();
			CollaboratoriXBandoObj.IdCollaboratore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COLLABORATORE"]);
			CollaboratoriXBandoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CollaboratoriXBandoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			CollaboratoriXBandoObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			CollaboratoriXBandoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			CollaboratoriXBandoObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			CollaboratoriXBandoObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			CollaboratoriXBandoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			CollaboratoriXBandoObj.ProvinciaUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_UTENTE"]);
			CollaboratoriXBandoObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			CollaboratoriXBandoObj.OperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			CollaboratoriXBandoObj.OperatoreFineValidita = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_FINE_VALIDITA"]);
			CollaboratoriXBandoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			CollaboratoriXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CollaboratoriXBandoObj.IsDirty = false;
			CollaboratoriXBandoObj.IsPersistent = true;
			return CollaboratoriXBandoObj;
		}

		//Find Select

		public static CollaboratoriXBandoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCollaboratoreEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreFineValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			CollaboratoriXBandoCollection CollaboratoriXBandoCollectionObj = new CollaboratoriXBandoCollection();

			IDbCommand findCmd = db.InitCmd("Zcollaboratorixbandofindselect", new string[] {"IdCollaboratoreequalthis", "IdBandoequalthis", "IdProgettoequalthis", 
"IdUtenteequalthis", "Provinciaequalthis", "OperatoreInserimentoequalthis", 
"DataInserimentoequalthis", "OperatoreFineValiditaequalthis", "DataFineValiditaequalthis", 
"Attivoequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "int", 
"DateTime", "int", "DateTime", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCollaboratoreequalthis", IdCollaboratoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreFineValiditaequalthis", OperatoreFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			CollaboratoriXBando CollaboratoriXBandoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CollaboratoriXBandoObj = GetFromDatareader(db);
				CollaboratoriXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXBandoObj.IsDirty = false;
				CollaboratoriXBandoObj.IsPersistent = true;
				CollaboratoriXBandoCollectionObj.Add(CollaboratoriXBandoObj);
			}
			db.Close();
			return CollaboratoriXBandoCollectionObj;
		}

		//Find Find

		public static CollaboratoriXBandoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, 
SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			CollaboratoriXBandoCollection CollaboratoriXBandoCollectionObj = new CollaboratoriXBandoCollection();

			IDbCommand findCmd = db.InitCmd("Zcollaboratorixbandofindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdUtenteequalthis", 
"Provinciaequalthis", "Attivoequalthis"}, new string[] {"int", "int", "int", 
"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			CollaboratoriXBando CollaboratoriXBandoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CollaboratoriXBandoObj = GetFromDatareader(db);
				CollaboratoriXBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriXBandoObj.IsDirty = false;
				CollaboratoriXBandoObj.IsPersistent = true;
				CollaboratoriXBandoCollectionObj.Add(CollaboratoriXBandoObj);
			}
			db.Close();
			return CollaboratoriXBandoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COLLABORATORI_X_BANDO>
  <ViewName>vCOLLABORATORI_X_BANDO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <PROVINCIA>Equal</PROVINCIA>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_X_BANDO>
*/