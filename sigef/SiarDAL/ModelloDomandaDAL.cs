using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ModelloDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class ModelloDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ModelloDomanda ModelloDomandaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdDomanda", ModelloDomandaObj.IdDomanda);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", ModelloDomandaObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Definitivo", ModelloDomandaObj.Definitivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ModelloDomandaObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Denominazione", ModelloDomandaObj.Denominazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ModelloDomandaObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, ModelloDomanda ModelloDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZModelloDomandaInsert", new string[] {"IdBando", "Definitivo", 
"Operatore", "Denominazione", "Descrizione"}, new string[] {"int", "bool", 
"string", "string", "string"},"");
				CompileIUCmd(false, insertCmd,ModelloDomandaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ModelloDomandaObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
				}
				ModelloDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ModelloDomandaObj.IsDirty = false;
				ModelloDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ModelloDomanda ModelloDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZModelloDomandaUpdate", new string[] {"IdDomanda", "IdBando", "Definitivo", 
"Operatore", "Denominazione", "Descrizione"}, new string[] {"int", "int", "bool", 
"string", "string", "string"},"");
				CompileIUCmd(true, updateCmd,ModelloDomandaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ModelloDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ModelloDomandaObj.IsDirty = false;
				ModelloDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ModelloDomanda ModelloDomandaObj)
		{
			switch (ModelloDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ModelloDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ModelloDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ModelloDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ModelloDomandaCollection ModelloDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZModelloDomandaUpdate", new string[] {"IdDomanda", "IdBando", "Definitivo", 
"Operatore", "Denominazione", "Descrizione"}, new string[] {"int", "int", "bool", 
"string", "string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZModelloDomandaInsert", new string[] {"IdBando", "Definitivo", 
"Operatore", "Denominazione", "Descrizione"}, new string[] {"int", "bool", 
"string", "string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZModelloDomandaDelete", new string[] {"IdDomanda"}, new string[] {"int"},"");
				for (int i = 0; i < ModelloDomandaCollectionObj.Count; i++)
				{
					switch (ModelloDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ModelloDomandaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ModelloDomandaCollectionObj[i].IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ModelloDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ModelloDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)ModelloDomandaCollectionObj[i].IdDomanda);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ModelloDomandaCollectionObj.Count; i++)
				{
					if ((ModelloDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ModelloDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ModelloDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ModelloDomandaCollectionObj[i].IsDirty = false;
						ModelloDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((ModelloDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ModelloDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ModelloDomandaCollectionObj[i].IsDirty = false;
						ModelloDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ModelloDomanda ModelloDomandaObj)
		{
			int returnValue = 0;
			if (ModelloDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, ModelloDomandaObj.IdDomanda);
			}
			ModelloDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ModelloDomandaObj.IsDirty = false;
			ModelloDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZModelloDomandaDelete", new string[] {"IdDomanda"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ModelloDomandaCollection ModelloDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZModelloDomandaDelete", new string[] {"IdDomanda"}, new string[] {"int"},"");
				for (int i = 0; i < ModelloDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", ModelloDomandaCollectionObj[i].IdDomanda);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ModelloDomandaCollectionObj.Count; i++)
				{
					if ((ModelloDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ModelloDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ModelloDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ModelloDomandaCollectionObj[i].IsDirty = false;
						ModelloDomandaCollectionObj[i].IsPersistent = false;
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
		public static ModelloDomanda GetById(DbProvider db, int IdDomandaValue)
		{
			ModelloDomanda ModelloDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZModelloDomandaGetById", new string[] {"IdDomanda"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ModelloDomandaObj = GetFromDatareader(db);
				ModelloDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ModelloDomandaObj.IsDirty = false;
				ModelloDomandaObj.IsPersistent = true;
			}
			db.Close();
			return ModelloDomandaObj;
		}

		//getFromDatareader
		public static ModelloDomanda GetFromDatareader(DbProvider db)
		{
			ModelloDomanda ModelloDomandaObj = new ModelloDomanda();
			ModelloDomandaObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
			ModelloDomandaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ModelloDomandaObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVO"]);
			ModelloDomandaObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			ModelloDomandaObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			ModelloDomandaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ModelloDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ModelloDomandaObj.IsDirty = false;
			ModelloDomandaObj.IsPersistent = true;
			return ModelloDomandaObj;
		}

		//Find Select

		public static ModelloDomandaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			ModelloDomandaCollection ModelloDomandaCollectionObj = new ModelloDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zmodellodomandafindselect", new string[] {"IdDomandaequalthis", "IdBandoequalthis", "Definitivoequalthis", 
"Operatoreequalthis", "Denominazioneequalthis", "Descrizioneequalthis"}, new string[] {"int", "int", "bool", 
"string", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Denominazioneequalthis", DenominazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			ModelloDomanda ModelloDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ModelloDomandaObj = GetFromDatareader(db);
				ModelloDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ModelloDomandaObj.IsDirty = false;
				ModelloDomandaObj.IsPersistent = true;
				ModelloDomandaCollectionObj.Add(ModelloDomandaObj);
			}
			db.Close();
			return ModelloDomandaCollectionObj;
		}

		//Find Find

		public static ModelloDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis)

		{

			ModelloDomandaCollection ModelloDomandaCollectionObj = new ModelloDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zmodellodomandafindfind", new string[] {"IdDomandaequalthis", "IdBandoequalthis", "Definitivoequalthis"}, new string[] {"int", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
			ModelloDomanda ModelloDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ModelloDomandaObj = GetFromDatareader(db);
				ModelloDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ModelloDomandaObj.IsDirty = false;
				ModelloDomandaObj.IsPersistent = true;
				ModelloDomandaCollectionObj.Add(ModelloDomandaObj);
			}
			db.Close();
			return ModelloDomandaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<MODELLO_DOMANDA>
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
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <ID_BANDO>Equal</ID_BANDO>
      <DEFINITIVO>Equal</DEFINITIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</MODELLO_DOMANDA>
*/