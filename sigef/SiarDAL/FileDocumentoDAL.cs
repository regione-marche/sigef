using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for FileDocumentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class FileDocumentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, FileDocumento FileDocumentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdFile", FileDocumentoObj.IdFile);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDocumento", FileDocumentoObj.IdDocumento);
			DbProvider.SetCmdParam(cmd,firstChar + "Nome", FileDocumentoObj.Nome);
			DbProvider.SetCmdParam(cmd,firstChar + "Tipo", FileDocumentoObj.Tipo);
			DbProvider.SetCmdParam(cmd,firstChar + "SizeFile", FileDocumentoObj.SizeFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", FileDocumentoObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdArchivioFile", FileDocumentoObj.IdArchivioFile);
		}
		//Insert
		private static int Insert(DbProvider db, FileDocumento FileDocumentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZFileDocumentoInsert", new string[] {"IdDocumento", "Nome", 
"Tipo", "SizeFile", "Descrizione", 
"IdArchivioFile"}, new string[] {"int", "string", 
"string", "int", "string", 
"int"},"");
				CompileIUCmd(false, insertCmd,FileDocumentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				FileDocumentoObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
				}
				FileDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FileDocumentoObj.IsDirty = false;
				FileDocumentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, FileDocumento FileDocumentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFileDocumentoUpdate", new string[] {"IdFile", "IdDocumento", "Nome", 
"Tipo", "SizeFile", "Descrizione", 
"IdArchivioFile"}, new string[] {"int", "int", "string", 
"string", "int", "string", 
"int"},"");
				CompileIUCmd(true, updateCmd,FileDocumentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				FileDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FileDocumentoObj.IsDirty = false;
				FileDocumentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, FileDocumento FileDocumentoObj)
		{
			switch (FileDocumentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, FileDocumentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, FileDocumentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,FileDocumentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, FileDocumentoCollection FileDocumentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFileDocumentoUpdate", new string[] {"IdFile", "IdDocumento", "Nome", 
"Tipo", "SizeFile", "Descrizione", 
"IdArchivioFile"}, new string[] {"int", "int", "string", 
"string", "int", "string", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZFileDocumentoInsert", new string[] {"IdDocumento", "Nome", 
"Tipo", "SizeFile", "Descrizione", 
"IdArchivioFile"}, new string[] {"int", "string", 
"string", "int", "string", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZFileDocumentoDelete", new string[] {"IdFile"}, new string[] {"int"},"");
				for (int i = 0; i < FileDocumentoCollectionObj.Count; i++)
				{
					switch (FileDocumentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,FileDocumentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									FileDocumentoCollectionObj[i].IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,FileDocumentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (FileDocumentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFile", (SiarLibrary.NullTypes.IntNT)FileDocumentoCollectionObj[i].IdFile);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < FileDocumentoCollectionObj.Count; i++)
				{
					if ((FileDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FileDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FileDocumentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						FileDocumentoCollectionObj[i].IsDirty = false;
						FileDocumentoCollectionObj[i].IsPersistent = true;
					}
					if ((FileDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						FileDocumentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FileDocumentoCollectionObj[i].IsDirty = false;
						FileDocumentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, FileDocumento FileDocumentoObj)
		{
			int returnValue = 0;
			if (FileDocumentoObj.IsPersistent) 
			{
				returnValue = Delete(db, FileDocumentoObj.IdFile);
			}
			FileDocumentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			FileDocumentoObj.IsDirty = false;
			FileDocumentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdFileValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFileDocumentoDelete", new string[] {"IdFile"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFile", (SiarLibrary.NullTypes.IntNT)IdFileValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, FileDocumentoCollection FileDocumentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFileDocumentoDelete", new string[] {"IdFile"}, new string[] {"int"},"");
				for (int i = 0; i < FileDocumentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFile", FileDocumentoCollectionObj[i].IdFile);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < FileDocumentoCollectionObj.Count; i++)
				{
					if ((FileDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FileDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FileDocumentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FileDocumentoCollectionObj[i].IsDirty = false;
						FileDocumentoCollectionObj[i].IsPersistent = false;
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
		public static FileDocumento GetById(DbProvider db, int IdFileValue)
		{
			FileDocumento FileDocumentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZFileDocumentoGetById", new string[] {"IdFile"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdFile", (SiarLibrary.NullTypes.IntNT)IdFileValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				FileDocumentoObj = GetFromDatareader(db);
				FileDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FileDocumentoObj.IsDirty = false;
				FileDocumentoObj.IsPersistent = true;
			}
			db.Close();
			return FileDocumentoObj;
		}

		//getFromDatareader
		public static FileDocumento GetFromDatareader(DbProvider db)
		{
			FileDocumento FileDocumentoObj = new FileDocumento();
			FileDocumentoObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			FileDocumentoObj.IdDocumento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOCUMENTO"]);
			FileDocumentoObj.Nome = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME"]);
			FileDocumentoObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			FileDocumentoObj.SizeFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["SIZE_FILE"]);
			FileDocumentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			FileDocumentoObj.IdArchivioFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ARCHIVIO_FILE"]);
			FileDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			FileDocumentoObj.IsDirty = false;
			FileDocumentoObj.IsPersistent = true;
			return FileDocumentoObj;
		}

		//Find Select

		public static FileDocumentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.IntNT IdDocumentoEqualThis, SiarLibrary.NullTypes.StringNT NomeEqualThis, 
SiarLibrary.NullTypes.StringNT TipoEqualThis, SiarLibrary.NullTypes.IntNT SizeFileEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdArchivioFileEqualThis)

		{

			FileDocumentoCollection FileDocumentoCollectionObj = new FileDocumentoCollection();

			IDbCommand findCmd = db.InitCmd("Zfiledocumentofindselect", new string[] {"IdFileequalthis", "IdDocumentoequalthis", "Nomeequalthis", 
"Tipoequalthis", "SizeFileequalthis", "Descrizioneequalthis", 
"IdArchivioFileequalthis"}, new string[] {"int", "int", "string", 
"string", "int", "string", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDocumentoequalthis", IdDocumentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nomeequalthis", NomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SizeFileequalthis", SizeFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdArchivioFileequalthis", IdArchivioFileEqualThis);
			FileDocumento FileDocumentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FileDocumentoObj = GetFromDatareader(db);
				FileDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FileDocumentoObj.IsDirty = false;
				FileDocumentoObj.IsPersistent = true;
				FileDocumentoCollectionObj.Add(FileDocumentoObj);
			}
			db.Close();
			return FileDocumentoCollectionObj;
		}

		//Find Find

		public static FileDocumentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDocumentoEqualThis)

		{

			FileDocumentoCollection FileDocumentoCollectionObj = new FileDocumentoCollection();

			IDbCommand findCmd = db.InitCmd("Zfiledocumentofindfind", new string[] {"IdDocumentoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDocumentoequalthis", IdDocumentoEqualThis);
			FileDocumento FileDocumentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FileDocumentoObj = GetFromDatareader(db);
				FileDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FileDocumentoObj.IsDirty = false;
				FileDocumentoObj.IsPersistent = true;
				FileDocumentoCollectionObj.Add(FileDocumentoObj);
			}
			db.Close();
			return FileDocumentoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FILE_DOCUMENTO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_DOCUMENTO>Equal</ID_DOCUMENTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</FILE_DOCUMENTO>
*/