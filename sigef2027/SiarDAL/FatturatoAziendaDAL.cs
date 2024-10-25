using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for FatturatoAziendaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class FatturatoAziendaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, FatturatoAzienda FatturatoAziendaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdFatturato", FatturatoAziendaObj.IdFatturato);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", FatturatoAziendaObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", FatturatoAziendaObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", FatturatoAziendaObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "Aliquota", FatturatoAziendaObj.Aliquota);
			DbProvider.SetCmdParam(cmd,firstChar + "Importo", FatturatoAziendaObj.Importo);
		}
		//Insert
		private static int Insert(DbProvider db, FatturatoAzienda FatturatoAziendaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZFatturatoAziendaInsert", new string[] {"IdImpresa", "DataModifica", 
"Anno", "Aliquota", "Importo"}, new string[] {"int", "DateTime", 
"int", "decimal", "decimal"},"");
				CompileIUCmd(false, insertCmd,FatturatoAziendaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				FatturatoAziendaObj.IdFatturato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FATTURATO"]);
				}
				FatturatoAziendaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FatturatoAziendaObj.IsDirty = false;
				FatturatoAziendaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, FatturatoAzienda FatturatoAziendaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFatturatoAziendaUpdate", new string[] {"IdFatturato", "IdImpresa", "DataModifica", 
"Anno", "Aliquota", "Importo"}, new string[] {"int", "int", "DateTime", 
"int", "decimal", "decimal"},"");
				CompileIUCmd(true, updateCmd,FatturatoAziendaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					FatturatoAziendaObj.DataModifica = d;
				}
				FatturatoAziendaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FatturatoAziendaObj.IsDirty = false;
				FatturatoAziendaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, FatturatoAzienda FatturatoAziendaObj)
		{
			switch (FatturatoAziendaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, FatturatoAziendaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, FatturatoAziendaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,FatturatoAziendaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, FatturatoAziendaCollection FatturatoAziendaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFatturatoAziendaUpdate", new string[] {"IdFatturato", "IdImpresa", "DataModifica", 
"Anno", "Aliquota", "Importo"}, new string[] {"int", "int", "DateTime", 
"int", "decimal", "decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZFatturatoAziendaInsert", new string[] {"IdImpresa", "DataModifica", 
"Anno", "Aliquota", "Importo"}, new string[] {"int", "DateTime", 
"int", "decimal", "decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZFatturatoAziendaDelete", new string[] {"IdFatturato"}, new string[] {"int"},"");
				for (int i = 0; i < FatturatoAziendaCollectionObj.Count; i++)
				{
					switch (FatturatoAziendaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,FatturatoAziendaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									FatturatoAziendaCollectionObj[i].IdFatturato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FATTURATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,FatturatoAziendaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									FatturatoAziendaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (FatturatoAziendaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFatturato", (SiarLibrary.NullTypes.IntNT)FatturatoAziendaCollectionObj[i].IdFatturato);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < FatturatoAziendaCollectionObj.Count; i++)
				{
					if ((FatturatoAziendaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FatturatoAziendaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FatturatoAziendaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						FatturatoAziendaCollectionObj[i].IsDirty = false;
						FatturatoAziendaCollectionObj[i].IsPersistent = true;
					}
					if ((FatturatoAziendaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						FatturatoAziendaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FatturatoAziendaCollectionObj[i].IsDirty = false;
						FatturatoAziendaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, FatturatoAzienda FatturatoAziendaObj)
		{
			int returnValue = 0;
			if (FatturatoAziendaObj.IsPersistent) 
			{
				returnValue = Delete(db, FatturatoAziendaObj.IdFatturato);
			}
			FatturatoAziendaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			FatturatoAziendaObj.IsDirty = false;
			FatturatoAziendaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdFatturatoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFatturatoAziendaDelete", new string[] {"IdFatturato"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFatturato", (SiarLibrary.NullTypes.IntNT)IdFatturatoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, FatturatoAziendaCollection FatturatoAziendaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFatturatoAziendaDelete", new string[] {"IdFatturato"}, new string[] {"int"},"");
				for (int i = 0; i < FatturatoAziendaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFatturato", FatturatoAziendaCollectionObj[i].IdFatturato);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < FatturatoAziendaCollectionObj.Count; i++)
				{
					if ((FatturatoAziendaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FatturatoAziendaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FatturatoAziendaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FatturatoAziendaCollectionObj[i].IsDirty = false;
						FatturatoAziendaCollectionObj[i].IsPersistent = false;
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
		public static FatturatoAzienda GetById(DbProvider db, int IdFatturatoValue)
		{
			FatturatoAzienda FatturatoAziendaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZFatturatoAziendaGetById", new string[] {"IdFatturato"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdFatturato", (SiarLibrary.NullTypes.IntNT)IdFatturatoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				FatturatoAziendaObj = GetFromDatareader(db);
				FatturatoAziendaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FatturatoAziendaObj.IsDirty = false;
				FatturatoAziendaObj.IsPersistent = true;
			}
			db.Close();
			return FatturatoAziendaObj;
		}

		//getFromDatareader
		public static FatturatoAzienda GetFromDatareader(DbProvider db)
		{
			FatturatoAzienda FatturatoAziendaObj = new FatturatoAzienda();
			FatturatoAziendaObj.IdFatturato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FATTURATO"]);
			FatturatoAziendaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			FatturatoAziendaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			FatturatoAziendaObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			FatturatoAziendaObj.Aliquota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALIQUOTA"]);
			FatturatoAziendaObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			FatturatoAziendaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			FatturatoAziendaObj.IsDirty = false;
			FatturatoAziendaObj.IsPersistent = true;
			return FatturatoAziendaObj;
		}

		//Find Select

		public static FatturatoAziendaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdFatturatoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.DecimalNT AliquotaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis)

		{

			FatturatoAziendaCollection FatturatoAziendaCollectionObj = new FatturatoAziendaCollection();

			IDbCommand findCmd = db.InitCmd("Zfatturatoaziendafindselect", new string[] {"IdFatturatoequalthis", "IdImpresaequalthis", "DataModificaequalthis", 
"Annoequalthis", "Aliquotaequalthis", "Importoequalthis"}, new string[] {"int", "int", "DateTime", 
"int", "decimal", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFatturatoequalthis", IdFatturatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Aliquotaequalthis", AliquotaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			FatturatoAzienda FatturatoAziendaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FatturatoAziendaObj = GetFromDatareader(db);
				FatturatoAziendaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FatturatoAziendaObj.IsDirty = false;
				FatturatoAziendaObj.IsPersistent = true;
				FatturatoAziendaCollectionObj.Add(FatturatoAziendaObj);
			}
			db.Close();
			return FatturatoAziendaCollectionObj;
		}

		//Find Find

		public static FatturatoAziendaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdFatturatoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, 
SiarLibrary.NullTypes.DecimalNT AliquotaEqualThis)

		{

			FatturatoAziendaCollection FatturatoAziendaCollectionObj = new FatturatoAziendaCollection();

			IDbCommand findCmd = db.InitCmd("Zfatturatoaziendafindfind", new string[] {"IdFatturatoequalthis", "IdImpresaequalthis", "Annoequalthis", 
"Aliquotaequalthis"}, new string[] {"int", "int", "int", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFatturatoequalthis", IdFatturatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Aliquotaequalthis", AliquotaEqualThis);
			FatturatoAzienda FatturatoAziendaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FatturatoAziendaObj = GetFromDatareader(db);
				FatturatoAziendaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FatturatoAziendaObj.IsDirty = false;
				FatturatoAziendaObj.IsPersistent = true;
				FatturatoAziendaCollectionObj.Add(FatturatoAziendaObj);
			}
			db.Close();
			return FatturatoAziendaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FATTURATO_AZIENDA>
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
      <ID_FATTURATO>Equal</ID_FATTURATO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ANNO>Equal</ANNO>
      <ALIQUOTA>Equal</ALIQUOTA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDataModifica>
      <DATA_MODIFICA>EqLessThan</DATA_MODIFICA>
    </FiltroDataModifica>
    <FiltroAliquota>
      <ALIQUOTA>Equal</ALIQUOTA>
    </FiltroAliquota>
  </Filters>
  <externalFields />
  <AddedFkFields />
</FATTURATO_AZIENDA>
*/