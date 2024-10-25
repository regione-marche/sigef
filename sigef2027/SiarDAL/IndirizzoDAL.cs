using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IndirizzoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class IndirizzoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Indirizzo IndirizzoObj)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,"@ID_INDIRIZZO", IndirizzoObj.IdIndirizzo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,"@VIA", IndirizzoObj.Via);
			DbProvider.SetCmdParam(cmd,"@LOCALITA", IndirizzoObj.Localita);
			DbProvider.SetCmdParam(cmd,"@ID_COMUNE", IndirizzoObj.IdComune);
			DbProvider.SetCmdParam(cmd,"@DENOMINAZIONE", IndirizzoObj.Denominazione);
		}
		//Insert
		private static int Insert(DbProvider db, Indirizzo IndirizzoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZIndirizzoInsert", new string[] {"VIA", "LOCALITA", "ID_COMUNE", "DENOMINAZIONE"}, new string[] {"string", "string", "int", "string"},"");
				CompileIUCmd(false, insertCmd,IndirizzoObj);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				IndirizzoObj.IdIndirizzo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INDIRIZZO"]);
				}
				IndirizzoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzoObj.IsDirty = false;
				IndirizzoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Indirizzo IndirizzoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIndirizzoUpdate", new string[] {"ID_INDIRIZZO", "VIA", "LOCALITA", "ID_COMUNE", "DENOMINAZIONE"}, new string[] {"int", "string", "string", "int", "string"},"");
				CompileIUCmd(true, updateCmd,IndirizzoObj);
			i = db.Execute(updateCmd);
				IndirizzoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzoObj.IsDirty = false;
				IndirizzoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Indirizzo IndirizzoObj)
		{
			switch (IndirizzoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, IndirizzoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, IndirizzoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,IndirizzoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IndirizzoCollection IndirizzoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIndirizzoUpdate", new string[] {"ID_INDIRIZZO", "VIA", "LOCALITA", "ID_COMUNE", "DENOMINAZIONE"}, new string[] {"int", "string", "string", "int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZIndirizzoInsert", new string[] {"VIA", "LOCALITA", "ID_COMUNE", "DENOMINAZIONE"}, new string[] {"string", "string", "int", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZIndirizzoDelete", new string[] {"ID_INDIRIZZO"}, new string[] {"int"},"");
				for (int i = 0; i < IndirizzoCollectionObj.Count; i++)
				{
					switch (IndirizzoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,IndirizzoCollectionObj[i]);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									IndirizzoCollectionObj[i].IdIndirizzo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INDIRIZZO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,IndirizzoCollectionObj[i]);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (IndirizzoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,"@ID_INDIRIZZO", (SiarLibrary.NullTypes.IntNT)IndirizzoCollectionObj[i].IdIndirizzo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IndirizzoCollectionObj.Count; i++)
				{
					if ((IndirizzoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IndirizzoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IndirizzoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IndirizzoCollectionObj[i].IsDirty = false;
						IndirizzoCollectionObj[i].IsPersistent = true;
					}
					if ((IndirizzoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IndirizzoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IndirizzoCollectionObj[i].IsDirty = false;
						IndirizzoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Indirizzo IndirizzoObj)
		{
			int returnValue = 0;
			if (IndirizzoObj.IsPersistent) 
			{
				returnValue = Delete(db, IndirizzoObj.IdIndirizzo);
			}
			IndirizzoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IndirizzoObj.IsDirty = false;
			IndirizzoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdIndirizzoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIndirizzoDelete", new string[] {"ID_INDIRIZZO"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,"@ID_INDIRIZZO", (SiarLibrary.NullTypes.IntNT)IdIndirizzoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IndirizzoCollection IndirizzoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIndirizzoDelete", new string[] {"ID_INDIRIZZO"}, new string[] {"int"},"");
				for (int i = 0; i < IndirizzoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,"@ID_INDIRIZZO", IndirizzoCollectionObj[i].IdIndirizzo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IndirizzoCollectionObj.Count; i++)
				{
					if ((IndirizzoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IndirizzoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IndirizzoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IndirizzoCollectionObj[i].IsDirty = false;
						IndirizzoCollectionObj[i].IsPersistent = false;
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
		public static Indirizzo GetById(DbProvider db, int IdIndirizzoValue)
		{
			Indirizzo IndirizzoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZIndirizzoGetById", new string[] {"ID_INDIRIZZO"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,"@ID_INDIRIZZO", (SiarLibrary.NullTypes.IntNT)IdIndirizzoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IndirizzoObj = GetFromDatareader(db);
				IndirizzoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzoObj.IsDirty = false;
				IndirizzoObj.IsPersistent = true;
			}
			db.Close();
			return IndirizzoObj;
		}

		//getFromDatareader
		public static Indirizzo GetFromDatareader(DbProvider db)
		{
			Indirizzo IndirizzoObj = new Indirizzo();
			IndirizzoObj.IdIndirizzo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INDIRIZZO"]);
			IndirizzoObj.Via = new SiarLibrary.NullTypes.StringNT(db.DataReader["VIA"]);
			IndirizzoObj.Localita = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOCALITA"]);
			IndirizzoObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			IndirizzoObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			IndirizzoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IndirizzoObj.IsDirty = false;
			IndirizzoObj.IsPersistent = true;
			return IndirizzoObj;
		}

		//Find Find

		public static IndirizzoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdIndirizzoEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT ViaLikeThis)

		{

			IndirizzoCollection IndirizzoCollectionObj = new IndirizzoCollection();

			IDbCommand findCmd = db.InitCmd("ZIndirizzoFindFind", new string[] {"ID_INDIRIZZOEQUALTHIS", "ID_COMUNEEQUALTHIS", "VIALIKETHIS"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,"@ID_INDIRIZZOEQUALTHIS", IdIndirizzoEqualThis);
			DbProvider.SetCmdParam(findCmd,"@ID_COMUNEEQUALTHIS", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,"@VIALIKETHIS", ViaLikeThis);
			Indirizzo IndirizzoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IndirizzoObj = GetFromDatareader(db);
				IndirizzoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IndirizzoObj.IsDirty = false;
				IndirizzoObj.IsPersistent = true;
				IndirizzoCollectionObj.Add(IndirizzoObj);
			}
			db.Close();
			return IndirizzoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<INDIRIZZO>
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
      <ID_INDIRIZZO>Equal</ID_INDIRIZZO>
      <ID_COMUNE>Equal</ID_COMUNE>
      <VIA>Like</VIA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</INDIRIZZO>
*/