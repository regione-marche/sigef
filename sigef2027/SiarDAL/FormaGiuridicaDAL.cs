using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for FormaGiuridicaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class FormaGiuridicaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, FormaGiuridica FormaGiuridicaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodIstat", FormaGiuridicaObj.CodIstat);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", FormaGiuridicaObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Foglia", FormaGiuridicaObj.Foglia);
		}
		//Insert
		private static int Insert(DbProvider db, FormaGiuridica FormaGiuridicaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZFormaGiuridicaInsert", new string[] {"CodIstat", "Descrizione", "Foglia"}, new string[] {"string", "string", "bool"},"");
				CompileIUCmd(false, insertCmd,FormaGiuridicaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				FormaGiuridicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FormaGiuridicaObj.IsDirty = false;
				FormaGiuridicaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, FormaGiuridica FormaGiuridicaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFormaGiuridicaUpdate", new string[] {"CodIstat", "Descrizione", "Foglia"}, new string[] {"string", "string", "bool"},"");
				CompileIUCmd(true, updateCmd,FormaGiuridicaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				FormaGiuridicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FormaGiuridicaObj.IsDirty = false;
				FormaGiuridicaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, FormaGiuridica FormaGiuridicaObj)
		{
			switch (FormaGiuridicaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, FormaGiuridicaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, FormaGiuridicaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,FormaGiuridicaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, FormaGiuridicaCollection FormaGiuridicaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFormaGiuridicaUpdate", new string[] {"CodIstat", "Descrizione", "Foglia"}, new string[] {"string", "string", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZFormaGiuridicaInsert", new string[] {"CodIstat", "Descrizione", "Foglia"}, new string[] {"string", "string", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZFormaGiuridicaDelete", new string[] {"CodIstat"}, new string[] {"string"},"");
				for (int i = 0; i < FormaGiuridicaCollectionObj.Count; i++)
				{
					switch (FormaGiuridicaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,FormaGiuridicaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,FormaGiuridicaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (FormaGiuridicaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodIstat", (SiarLibrary.NullTypes.StringNT)FormaGiuridicaCollectionObj[i].CodIstat);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < FormaGiuridicaCollectionObj.Count; i++)
				{
					if ((FormaGiuridicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FormaGiuridicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FormaGiuridicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						FormaGiuridicaCollectionObj[i].IsDirty = false;
						FormaGiuridicaCollectionObj[i].IsPersistent = true;
					}
					if ((FormaGiuridicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						FormaGiuridicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FormaGiuridicaCollectionObj[i].IsDirty = false;
						FormaGiuridicaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, FormaGiuridica FormaGiuridicaObj)
		{
			int returnValue = 0;
			if (FormaGiuridicaObj.IsPersistent) 
			{
				returnValue = Delete(db, FormaGiuridicaObj.CodIstat);
			}
			FormaGiuridicaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			FormaGiuridicaObj.IsDirty = false;
			FormaGiuridicaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodIstatValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFormaGiuridicaDelete", new string[] {"CodIstat"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodIstat", (SiarLibrary.NullTypes.StringNT)CodIstatValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, FormaGiuridicaCollection FormaGiuridicaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFormaGiuridicaDelete", new string[] {"CodIstat"}, new string[] {"string"},"");
				for (int i = 0; i < FormaGiuridicaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodIstat", FormaGiuridicaCollectionObj[i].CodIstat);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < FormaGiuridicaCollectionObj.Count; i++)
				{
					if ((FormaGiuridicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FormaGiuridicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FormaGiuridicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FormaGiuridicaCollectionObj[i].IsDirty = false;
						FormaGiuridicaCollectionObj[i].IsPersistent = false;
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
		public static FormaGiuridica GetById(DbProvider db, string CodIstatValue)
		{
			FormaGiuridica FormaGiuridicaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZFormaGiuridicaGetById", new string[] {"CodIstat"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodIstat", (SiarLibrary.NullTypes.StringNT)CodIstatValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				FormaGiuridicaObj = GetFromDatareader(db);
				FormaGiuridicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FormaGiuridicaObj.IsDirty = false;
				FormaGiuridicaObj.IsPersistent = true;
			}
			db.Close();
			return FormaGiuridicaObj;
		}

		//getFromDatareader
		public static FormaGiuridica GetFromDatareader(DbProvider db)
		{
			FormaGiuridica FormaGiuridicaObj = new FormaGiuridica();
			FormaGiuridicaObj.CodIstat = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ISTAT"]);
			FormaGiuridicaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			FormaGiuridicaObj.Foglia = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FOGLIA"]);
			FormaGiuridicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			FormaGiuridicaObj.IsDirty = false;
			FormaGiuridicaObj.IsPersistent = true;
			return FormaGiuridicaObj;
		}

		//Find Select

		public static FormaGiuridicaCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodIstatEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT FogliaEqualThis)

		{

			FormaGiuridicaCollection FormaGiuridicaCollectionObj = new FormaGiuridicaCollection();

			IDbCommand findCmd = db.InitCmd("Zformagiuridicafindselect", new string[] {"CodIstatequalthis", "Descrizioneequalthis", "Fogliaequalthis"}, new string[] {"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodIstatequalthis", CodIstatEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Fogliaequalthis", FogliaEqualThis);
			FormaGiuridica FormaGiuridicaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FormaGiuridicaObj = GetFromDatareader(db);
				FormaGiuridicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FormaGiuridicaObj.IsDirty = false;
				FormaGiuridicaObj.IsPersistent = true;
				FormaGiuridicaCollectionObj.Add(FormaGiuridicaObj);
			}
			db.Close();
			return FormaGiuridicaCollectionObj;
		}

		//Find Find

		public static FormaGiuridicaCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodIstatEqualThis)

		{

			FormaGiuridicaCollection FormaGiuridicaCollectionObj = new FormaGiuridicaCollection();

			IDbCommand findCmd = db.InitCmd("Zformagiuridicafindfind", new string[] {"CodIstatequalthis"}, new string[] {"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodIstatequalthis", CodIstatEqualThis);
			FormaGiuridica FormaGiuridicaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FormaGiuridicaObj = GetFromDatareader(db);
				FormaGiuridicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FormaGiuridicaObj.IsDirty = false;
				FormaGiuridicaObj.IsPersistent = true;
				FormaGiuridicaCollectionObj.Add(FormaGiuridicaObj);
			}
			db.Close();
			return FormaGiuridicaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FORMA_GIURIDICA>
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
    <Find>
      <COD_ISTAT>Equal</COD_ISTAT>
    </Find>
  </Finds>
  <Filters>
    <FiltroFoglia>
      <FOGLIA>Equal</FOGLIA>
    </FiltroFoglia>
  </Filters>
  <externalFields />
  <AddedFkFields />
</FORMA_GIURIDICA>
*/