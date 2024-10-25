using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoTipoVariantiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class BandoTipoVariantiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoTipoVarianti BandoTipoVariantiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoTipoVariantiObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", BandoTipoVariantiObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroMassimo", BandoTipoVariantiObj.NumeroMassimo);
		}
		//Insert
		private static int Insert(DbProvider db, BandoTipoVarianti BandoTipoVariantiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoTipoVariantiInsert", new string[] {"IdBando", "CodTipo", "NumeroMassimo"}, new string[] {"int", "string", "int"},"");
				CompileIUCmd(false, insertCmd,BandoTipoVariantiObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				BandoTipoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoVariantiObj.IsDirty = false;
				BandoTipoVariantiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoTipoVarianti BandoTipoVariantiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoTipoVariantiUpdate", new string[] {"IdBando", "CodTipo", "NumeroMassimo"}, new string[] {"int", "string", "int"},"");
				CompileIUCmd(true, updateCmd,BandoTipoVariantiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoTipoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoVariantiObj.IsDirty = false;
				BandoTipoVariantiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoTipoVarianti BandoTipoVariantiObj)
		{
			switch (BandoTipoVariantiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoTipoVariantiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoTipoVariantiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoTipoVariantiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoTipoVariantiCollection BandoTipoVariantiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoTipoVariantiUpdate", new string[] {"IdBando", "CodTipo", "NumeroMassimo"}, new string[] {"int", "string", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoTipoVariantiInsert", new string[] {"IdBando", "CodTipo", "NumeroMassimo"}, new string[] {"int", "string", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoVariantiDelete", new string[] {"IdBando", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < BandoTipoVariantiCollectionObj.Count; i++)
				{
					switch (BandoTipoVariantiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoTipoVariantiCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoTipoVariantiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoTipoVariantiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BandoTipoVariantiCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)BandoTipoVariantiCollectionObj[i].CodTipo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoTipoVariantiCollectionObj.Count; i++)
				{
					if ((BandoTipoVariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoTipoVariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoTipoVariantiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoTipoVariantiCollectionObj[i].IsDirty = false;
						BandoTipoVariantiCollectionObj[i].IsPersistent = true;
					}
					if ((BandoTipoVariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoTipoVariantiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoTipoVariantiCollectionObj[i].IsDirty = false;
						BandoTipoVariantiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoTipoVarianti BandoTipoVariantiObj)
		{
			int returnValue = 0;
			if (BandoTipoVariantiObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoTipoVariantiObj.IdBando, BandoTipoVariantiObj.CodTipo);
			}
			BandoTipoVariantiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoTipoVariantiObj.IsDirty = false;
			BandoTipoVariantiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, string CodTipoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoVariantiDelete", new string[] {"IdBando", "CodTipo"}, new string[] {"int", "string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoTipoVariantiCollection BandoTipoVariantiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoVariantiDelete", new string[] {"IdBando", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < BandoTipoVariantiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", BandoTipoVariantiCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", BandoTipoVariantiCollectionObj[i].CodTipo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoTipoVariantiCollectionObj.Count; i++)
				{
					if ((BandoTipoVariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoTipoVariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoTipoVariantiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoTipoVariantiCollectionObj[i].IsDirty = false;
						BandoTipoVariantiCollectionObj[i].IsPersistent = false;
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
		public static BandoTipoVarianti GetById(DbProvider db, int IdBandoValue, string CodTipoValue)
		{
			BandoTipoVarianti BandoTipoVariantiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoTipoVariantiGetById", new string[] {"IdBando", "CodTipo"}, new string[] {"int", "string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoTipoVariantiObj = GetFromDatareader(db);
				BandoTipoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoVariantiObj.IsDirty = false;
				BandoTipoVariantiObj.IsPersistent = true;
			}
			db.Close();
			return BandoTipoVariantiObj;
		}

		//getFromDatareader
		public static BandoTipoVarianti GetFromDatareader(DbProvider db)
		{
			BandoTipoVarianti BandoTipoVariantiObj = new BandoTipoVarianti();
			BandoTipoVariantiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoTipoVariantiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			BandoTipoVariantiObj.NumeroMassimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_MASSIMO"]);
			BandoTipoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoTipoVariantiObj.IsDirty = false;
			BandoTipoVariantiObj.IsPersistent = true;
			return BandoTipoVariantiObj;
		}

		//Find Select

		public static BandoTipoVariantiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT NumeroMassimoEqualThis)

		{

			BandoTipoVariantiCollection BandoTipoVariantiCollectionObj = new BandoTipoVariantiCollection();

			IDbCommand findCmd = db.InitCmd("Zbandotipovariantifindselect", new string[] {"IdBandoequalthis", "CodTipoequalthis", "NumeroMassimoequalthis"}, new string[] {"int", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroMassimoequalthis", NumeroMassimoEqualThis);
			BandoTipoVarianti BandoTipoVariantiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoTipoVariantiObj = GetFromDatareader(db);
				BandoTipoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoVariantiObj.IsDirty = false;
				BandoTipoVariantiObj.IsPersistent = true;
				BandoTipoVariantiCollectionObj.Add(BandoTipoVariantiObj);
			}
			db.Close();
			return BandoTipoVariantiCollectionObj;
		}

		//Find Find

		public static BandoTipoVariantiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis)

		{

			BandoTipoVariantiCollection BandoTipoVariantiCollectionObj = new BandoTipoVariantiCollection();

			IDbCommand findCmd = db.InitCmd("Zbandotipovariantifindfind", new string[] {"IdBandoequalthis", "CodTipoequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			BandoTipoVarianti BandoTipoVariantiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoTipoVariantiObj = GetFromDatareader(db);
				BandoTipoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoVariantiObj.IsDirty = false;
				BandoTipoVariantiObj.IsPersistent = true;
				BandoTipoVariantiCollectionObj.Add(BandoTipoVariantiObj);
			}
			db.Close();
			return BandoTipoVariantiCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_TIPO_VARIANTI>
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
    <Find OrderBy="ORDER BY ">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_TIPO_VARIANTI>
*/