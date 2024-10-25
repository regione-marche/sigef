using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for FilieraDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class FilieraDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Filiera FilieraObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdFiliera", FilieraObj.IdFiliera);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoFiliera", FilieraObj.CodTipoFiliera);
			DbProvider.SetCmdParam(cmd,firstChar + "Denominazione", FilieraObj.Denominazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdeaProgettuale", FilieraObj.IdeaProgettuale);
			DbProvider.SetCmdParam(cmd,firstChar + "NumCertificato", FilieraObj.NumCertificato);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCertificato", FilieraObj.DataCertificato);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", FilieraObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataUltimaModifica", FilieraObj.DataUltimaModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", FilieraObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, Filiera FilieraObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZFilieraInsert", new string[] {"CodTipoFiliera", "Denominazione", 
"IdeaProgettuale", "NumCertificato", "DataCertificato", 
"DataInserimento", "DataUltimaModifica", "Operatore"}, new string[] {"string", "string", 
"string", "int", "DateTime", 
"DateTime", "DateTime", "string"},"");
				CompileIUCmd(false, insertCmd,FilieraObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				FilieraObj.IdFiliera = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILIERA"]);
				}
				FilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FilieraObj.IsDirty = false;
				FilieraObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Filiera FilieraObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFilieraUpdate", new string[] {"IdFiliera", "CodTipoFiliera", "Denominazione", 
"IdeaProgettuale", "NumCertificato", "DataCertificato", 
"DataInserimento", "DataUltimaModifica", "Operatore"}, new string[] {"int", "string", "string", 
"string", "int", "DateTime", 
"DateTime", "DateTime", "string"},"");
				CompileIUCmd(true, updateCmd,FilieraObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				FilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FilieraObj.IsDirty = false;
				FilieraObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Filiera FilieraObj)
		{
			switch (FilieraObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, FilieraObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, FilieraObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,FilieraObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, FilieraCollection FilieraCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFilieraUpdate", new string[] {"IdFiliera", "CodTipoFiliera", "Denominazione", 
"IdeaProgettuale", "NumCertificato", "DataCertificato", 
"DataInserimento", "DataUltimaModifica", "Operatore"}, new string[] {"int", "string", "string", 
"string", "int", "DateTime", 
"DateTime", "DateTime", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZFilieraInsert", new string[] {"CodTipoFiliera", "Denominazione", 
"IdeaProgettuale", "NumCertificato", "DataCertificato", 
"DataInserimento", "DataUltimaModifica", "Operatore"}, new string[] {"string", "string", 
"string", "int", "DateTime", 
"DateTime", "DateTime", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZFilieraDelete", new string[] {"IdFiliera"}, new string[] {"int"},"");
				for (int i = 0; i < FilieraCollectionObj.Count; i++)
				{
					switch (FilieraCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,FilieraCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									FilieraCollectionObj[i].IdFiliera = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILIERA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,FilieraCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (FilieraCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFiliera", (SiarLibrary.NullTypes.IntNT)FilieraCollectionObj[i].IdFiliera);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < FilieraCollectionObj.Count; i++)
				{
					if ((FilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						FilieraCollectionObj[i].IsDirty = false;
						FilieraCollectionObj[i].IsPersistent = true;
					}
					if ((FilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						FilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FilieraCollectionObj[i].IsDirty = false;
						FilieraCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Filiera FilieraObj)
		{
			int returnValue = 0;
			if (FilieraObj.IsPersistent) 
			{
				returnValue = Delete(db, FilieraObj.IdFiliera);
			}
			FilieraObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			FilieraObj.IsDirty = false;
			FilieraObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdFilieraValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFilieraDelete", new string[] {"IdFiliera"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFiliera", (SiarLibrary.NullTypes.IntNT)IdFilieraValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, FilieraCollection FilieraCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFilieraDelete", new string[] {"IdFiliera"}, new string[] {"int"},"");
				for (int i = 0; i < FilieraCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFiliera", FilieraCollectionObj[i].IdFiliera);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < FilieraCollectionObj.Count; i++)
				{
					if ((FilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FilieraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FilieraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FilieraCollectionObj[i].IsDirty = false;
						FilieraCollectionObj[i].IsPersistent = false;
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
		public static Filiera GetById(DbProvider db, int IdFilieraValue)
		{
			Filiera FilieraObj = null;
			IDbCommand readCmd = db.InitCmd( "ZFilieraGetById", new string[] {"IdFiliera"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdFiliera", (SiarLibrary.NullTypes.IntNT)IdFilieraValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				FilieraObj = GetFromDatareader(db);
				FilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FilieraObj.IsDirty = false;
				FilieraObj.IsPersistent = true;
			}
			db.Close();
			return FilieraObj;
		}

		//getFromDatareader
		public static Filiera GetFromDatareader(DbProvider db)
		{
			Filiera FilieraObj = new Filiera();
			FilieraObj.IdFiliera = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILIERA"]);
			FilieraObj.CodTipoFiliera = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_FILIERA"]);
			FilieraObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			FilieraObj.IdeaProgettuale = new SiarLibrary.NullTypes.StringNT(db.DataReader["IDEA_PROGETTUALE"]);
			FilieraObj.NumCertificato = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUM_CERTIFICATO"]);
			FilieraObj.DataCertificato = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICATO"]);
			FilieraObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			FilieraObj.DataUltimaModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ULTIMA_MODIFICA"]);
			FilieraObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			FilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			FilieraObj.IsDirty = false;
			FilieraObj.IsPersistent = true;
			return FilieraObj;
		}

		//Find Select

		public static FilieraCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdFilieraEqualThis, SiarLibrary.NullTypes.StringNT CodTipoFilieraEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneEqualThis, 
SiarLibrary.NullTypes.IntNT NumCertificatoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCertificatoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataUltimaModificaEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis)

		{

			FilieraCollection FilieraCollectionObj = new FilieraCollection();

			IDbCommand findCmd = db.InitCmd("Zfilierafindselect", new string[] {"IdFilieraequalthis", "CodTipoFilieraequalthis", "Denominazioneequalthis", 
"NumCertificatoequalthis", "DataCertificatoequalthis", "DataInserimentoequalthis", 
"DataUltimaModificaequalthis", "Operatoreequalthis"}, new string[] {"int", "string", "string", 
"int", "DateTime", "DateTime", 
"DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFilieraequalthis", IdFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoFilieraequalthis", CodTipoFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Denominazioneequalthis", DenominazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumCertificatoequalthis", NumCertificatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCertificatoequalthis", DataCertificatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataUltimaModificaequalthis", DataUltimaModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			Filiera FilieraObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FilieraObj = GetFromDatareader(db);
				FilieraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FilieraObj.IsDirty = false;
				FilieraObj.IsPersistent = true;
				FilieraCollectionObj.Add(FilieraObj);
			}
			db.Close();
			return FilieraCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FILIERA>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</FILIERA>
*/