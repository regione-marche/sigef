using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for QuadroDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class QuadroDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, QuadroDomanda QuadroDomandaObj)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,"@ID_QUADRO", QuadroDomandaObj.IdQuadro);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,"@DENOMINAZIONE", QuadroDomandaObj.Denominazione);
			DbProvider.SetCmdParam(cmd,"@DESCRIZIONE", QuadroDomandaObj.Descrizione);
			DbProvider.SetCmdParam(cmd,"@METODO_REPORT", QuadroDomandaObj.MetodoReport);
		}
		//Insert
		private static int Insert(DbProvider db, QuadroDomanda QuadroDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZQuadroDomandaInsert", new string[] {"DENOMINAZIONE", "DESCRIZIONE", "METODO_REPORT"}, new string[] {"string", "string", "string"},"");
				CompileIUCmd(false, insertCmd,QuadroDomandaObj);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				QuadroDomandaObj.IdQuadro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_QUADRO"]);
				}
				QuadroDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadroDomandaObj.IsDirty = false;
				QuadroDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, QuadroDomanda QuadroDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZQuadroDomandaUpdate", new string[] {"ID_QUADRO", "DENOMINAZIONE", "DESCRIZIONE", "METODO_REPORT"}, new string[] {"int", "string", "string", "string"},"");
				CompileIUCmd(true, updateCmd,QuadroDomandaObj);
			i = db.Execute(updateCmd);
				QuadroDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadroDomandaObj.IsDirty = false;
				QuadroDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, QuadroDomanda QuadroDomandaObj)
		{
			switch (QuadroDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, QuadroDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, QuadroDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,QuadroDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, QuadroDomandaCollection QuadroDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZQuadroDomandaUpdate", new string[] {"ID_QUADRO", "DENOMINAZIONE", "DESCRIZIONE", "METODO_REPORT"}, new string[] {"int", "string", "string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZQuadroDomandaInsert", new string[] {"DENOMINAZIONE", "DESCRIZIONE", "METODO_REPORT"}, new string[] {"string", "string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZQuadroDomandaDelete", new string[] {"ID_QUADRO"}, new string[] {"int"},"");
				for (int i = 0; i < QuadroDomandaCollectionObj.Count; i++)
				{
					switch (QuadroDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,QuadroDomandaCollectionObj[i]);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									QuadroDomandaCollectionObj[i].IdQuadro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_QUADRO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,QuadroDomandaCollectionObj[i]);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (QuadroDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,"@ID_QUADRO", (SiarLibrary.NullTypes.IntNT)QuadroDomandaCollectionObj[i].IdQuadro);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < QuadroDomandaCollectionObj.Count; i++)
				{
					if ((QuadroDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (QuadroDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						QuadroDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						QuadroDomandaCollectionObj[i].IsDirty = false;
						QuadroDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((QuadroDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						QuadroDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						QuadroDomandaCollectionObj[i].IsDirty = false;
						QuadroDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, QuadroDomanda QuadroDomandaObj)
		{
			int returnValue = 0;
			if (QuadroDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, QuadroDomandaObj.IdQuadro);
			}
			QuadroDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			QuadroDomandaObj.IsDirty = false;
			QuadroDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdQuadroValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZQuadroDomandaDelete", new string[] {"ID_QUADRO"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,"@ID_QUADRO", (SiarLibrary.NullTypes.IntNT)IdQuadroValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, QuadroDomandaCollection QuadroDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZQuadroDomandaDelete", new string[] {"ID_QUADRO"}, new string[] {"int"},"");
				for (int i = 0; i < QuadroDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,"@ID_QUADRO", QuadroDomandaCollectionObj[i].IdQuadro);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < QuadroDomandaCollectionObj.Count; i++)
				{
					if ((QuadroDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (QuadroDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						QuadroDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						QuadroDomandaCollectionObj[i].IsDirty = false;
						QuadroDomandaCollectionObj[i].IsPersistent = false;
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
		public static QuadroDomanda GetById(DbProvider db, int IdQuadroValue)
		{
			QuadroDomanda QuadroDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZQuadroDomandaGetById", new string[] {"ID_QUADRO"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,"@ID_QUADRO", (SiarLibrary.NullTypes.IntNT)IdQuadroValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				QuadroDomandaObj = GetFromDatareader(db);
				QuadroDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadroDomandaObj.IsDirty = false;
				QuadroDomandaObj.IsPersistent = true;
			}
			db.Close();
			return QuadroDomandaObj;
		}

		//getFromDatareader
		public static QuadroDomanda GetFromDatareader(DbProvider db)
		{
			QuadroDomanda QuadroDomandaObj = new QuadroDomanda();
			QuadroDomandaObj.IdQuadro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_QUADRO"]);
			QuadroDomandaObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			QuadroDomandaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			QuadroDomandaObj.MetodoReport = new SiarLibrary.NullTypes.StringNT(db.DataReader["METODO_REPORT"]);
			QuadroDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			QuadroDomandaObj.IsDirty = false;
			QuadroDomandaObj.IsPersistent = true;
			return QuadroDomandaObj;
		}

		//Find Find

		public static QuadroDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdQuadroEqualThis)

		{

			QuadroDomandaCollection QuadroDomandaCollectionObj = new QuadroDomandaCollection();

			IDbCommand findCmd = db.InitCmd("ZQuadroDomandaFindFind", new string[] {"ID_QUADROEQUALTHIS"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,"@ID_QUADROEQUALTHIS", IdQuadroEqualThis);
			QuadroDomanda QuadroDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				QuadroDomandaObj = GetFromDatareader(db);
				QuadroDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadroDomandaObj.IsDirty = false;
				QuadroDomandaObj.IsPersistent = true;
				QuadroDomandaCollectionObj.Add(QuadroDomandaObj);
			}
			db.Close();
			return QuadroDomandaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<QUADRO_DOMANDA>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <ID_QUADRO>Equal</ID_QUADRO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</QUADRO_DOMANDA>
*/