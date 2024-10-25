using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DocumentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class DocumentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Documenti DocumentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdDocumento", DocumentiObj.IdDocumento);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Titolo", DocumentiObj.Titolo);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", DocumentiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", DocumentiObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", DocumentiObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", DocumentiObj.DataFineValidita);
		}
		//Insert
		private static int Insert(DbProvider db, Documenti DocumentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDocumentiInsert", new string[] {"Titolo", "Descrizione", 
"DataModifica", "Operatore", "DataFineValidita"}, new string[] {"string", "string", 
"DateTime", "string", "DateTime"},"");
				CompileIUCmd(false, insertCmd,DocumentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				DocumentiObj.IdDocumento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOCUMENTO"]);
				}
				DocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DocumentiObj.IsDirty = false;
				DocumentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Documenti DocumentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDocumentiUpdate", new string[] {"IdDocumento", "Titolo", "Descrizione", 
"DataModifica", "Operatore", "DataFineValidita"}, new string[] {"int", "string", "string", 
"DateTime", "string", "DateTime"},"");
				CompileIUCmd(true, updateCmd,DocumentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				DocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DocumentiObj.IsDirty = false;
				DocumentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Documenti DocumentiObj)
		{
			switch (DocumentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DocumentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DocumentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DocumentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DocumentiCollection DocumentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDocumentiUpdate", new string[] {"IdDocumento", "Titolo", "Descrizione", 
"DataModifica", "Operatore", "DataFineValidita"}, new string[] {"int", "string", "string", 
"DateTime", "string", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDocumentiInsert", new string[] {"Titolo", "Descrizione", 
"DataModifica", "Operatore", "DataFineValidita"}, new string[] {"string", "string", 
"DateTime", "string", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDocumentiDelete", new string[] {"IdDocumento"}, new string[] {"int"},"");
				for (int i = 0; i < DocumentiCollectionObj.Count; i++)
				{
					switch (DocumentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DocumentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DocumentiCollectionObj[i].IdDocumento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOCUMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DocumentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DocumentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDocumento", (SiarLibrary.NullTypes.IntNT)DocumentiCollectionObj[i].IdDocumento);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DocumentiCollectionObj.Count; i++)
				{
					if ((DocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DocumentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DocumentiCollectionObj[i].IsDirty = false;
						DocumentiCollectionObj[i].IsPersistent = true;
					}
					if ((DocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DocumentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DocumentiCollectionObj[i].IsDirty = false;
						DocumentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Documenti DocumentiObj)
		{
			int returnValue = 0;
			if (DocumentiObj.IsPersistent) 
			{
				returnValue = Delete(db, DocumentiObj.IdDocumento);
			}
			DocumentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DocumentiObj.IsDirty = false;
			DocumentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDocumentoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDocumentiDelete", new string[] {"IdDocumento"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDocumento", (SiarLibrary.NullTypes.IntNT)IdDocumentoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DocumentiCollection DocumentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDocumentiDelete", new string[] {"IdDocumento"}, new string[] {"int"},"");
				for (int i = 0; i < DocumentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDocumento", DocumentiCollectionObj[i].IdDocumento);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DocumentiCollectionObj.Count; i++)
				{
					if ((DocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DocumentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DocumentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DocumentiCollectionObj[i].IsDirty = false;
						DocumentiCollectionObj[i].IsPersistent = false;
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
		public static Documenti GetById(DbProvider db, int IdDocumentoValue)
		{
			Documenti DocumentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDocumentiGetById", new string[] {"IdDocumento"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDocumento", (SiarLibrary.NullTypes.IntNT)IdDocumentoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DocumentiObj = GetFromDatareader(db);
				DocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DocumentiObj.IsDirty = false;
				DocumentiObj.IsPersistent = true;
			}
			db.Close();
			return DocumentiObj;
		}

		//getFromDatareader
		public static Documenti GetFromDatareader(DbProvider db)
		{
			Documenti DocumentiObj = new Documenti();
			DocumentiObj.IdDocumento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOCUMENTO"]);
			DocumentiObj.Titolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO"]);
			DocumentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			DocumentiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			DocumentiObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			DocumentiObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			DocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DocumentiObj.IsDirty = false;
			DocumentiObj.IsPersistent = true;
			return DocumentiObj;
		}

		//Find Select

		public static DocumentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDocumentoEqualThis, SiarLibrary.NullTypes.StringNT TitoloEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis)

		{

			DocumentiCollection DocumentiCollectionObj = new DocumentiCollection();

			IDbCommand findCmd = db.InitCmd("Zdocumentifindselect", new string[] {"IdDocumentoequalthis", "Titoloequalthis", "Descrizioneequalthis", 
"DataModificaequalthis", "Operatoreequalthis", "DataFineValiditaequalthis"}, new string[] {"int", "string", "string", 
"DateTime", "string", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDocumentoequalthis", IdDocumentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Titoloequalthis", TitoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			Documenti DocumentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DocumentiObj = GetFromDatareader(db);
				DocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DocumentiObj.IsDirty = false;
				DocumentiObj.IsPersistent = true;
				DocumentiCollectionObj.Add(DocumentiObj);
			}
			db.Close();
			return DocumentiCollectionObj;
		}

		//Find Find

		public static DocumentiCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT TitoloLikeThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqGreaterThanThis)

		{

			DocumentiCollection DocumentiCollectionObj = new DocumentiCollection();

			IDbCommand findCmd = db.InitCmd("Zdocumentifindfind", new string[] {"Titololikethis", "Descrizionelikethis", "DataFineValiditaeqgreaterthanthis"}, new string[] {"string", "string", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Titololikethis", TitoloLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaeqgreaterthanthis", DataFineValiditaEqGreaterThanThis);
			Documenti DocumentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DocumentiObj = GetFromDatareader(db);
				DocumentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DocumentiObj.IsDirty = false;
				DocumentiObj.IsPersistent = true;
				DocumentiCollectionObj.Add(DocumentiObj);
			}
			db.Close();
			return DocumentiCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOCUMENTI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY DATA_MODIFICA DESC">
      <TITOLO>Like</TITOLO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <DATA_FINE_VALIDITA>EqGreaterThan</DATA_FINE_VALIDITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDescrizione>
      <TITOLO>Like</TITOLO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </FiltroDescrizione>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOCUMENTI>
*/