using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VariantiSegnatureDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class VariantiSegnatureDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VariantiSegnature VariantiSegnatureObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", VariantiSegnatureObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", VariantiSegnatureObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", VariantiSegnatureObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", VariantiSegnatureObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", VariantiSegnatureObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Motivazione", VariantiSegnatureObj.Motivazione);
			DbProvider.SetCmdParam(cmd,firstChar + "RiapriVariante", VariantiSegnatureObj.RiapriVariante);
		}
		//Insert
		private static int Insert(DbProvider db, VariantiSegnature VariantiSegnatureObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZVariantiSegnatureInsert", new string[] {"IdVariante", "CodTipo", "Segnatura", 
"Data", "Operatore", "Motivazione", 
"RiapriVariante"}, new string[] {"int", "string", "string", 
"DateTime", "string", "string", 
"bool"},"");
				CompileIUCmd(false, insertCmd,VariantiSegnatureObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				VariantiSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiSegnatureObj.IsDirty = false;
				VariantiSegnatureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VariantiSegnature VariantiSegnatureObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiSegnatureUpdate", new string[] {"IdVariante", "CodTipo", "Segnatura", 
"Data", "Operatore", "Motivazione", 
"RiapriVariante"}, new string[] {"int", "string", "string", 
"DateTime", "string", "string", 
"bool"},"");
				CompileIUCmd(true, updateCmd,VariantiSegnatureObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				VariantiSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiSegnatureObj.IsDirty = false;
				VariantiSegnatureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VariantiSegnature VariantiSegnatureObj)
		{
			switch (VariantiSegnatureObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, VariantiSegnatureObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, VariantiSegnatureObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,VariantiSegnatureObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VariantiSegnatureCollection VariantiSegnatureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiSegnatureUpdate", new string[] {"IdVariante", "CodTipo", "Segnatura", 
"Data", "Operatore", "Motivazione", 
"RiapriVariante"}, new string[] {"int", "string", "string", 
"DateTime", "string", "string", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZVariantiSegnatureInsert", new string[] {"IdVariante", "CodTipo", "Segnatura", 
"Data", "Operatore", "Motivazione", 
"RiapriVariante"}, new string[] {"int", "string", "string", 
"DateTime", "string", "string", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiSegnatureDelete", new string[] {"IdVariante", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < VariantiSegnatureCollectionObj.Count; i++)
				{
					switch (VariantiSegnatureCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,VariantiSegnatureCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,VariantiSegnatureCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (VariantiSegnatureCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)VariantiSegnatureCollectionObj[i].IdVariante);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)VariantiSegnatureCollectionObj[i].CodTipo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VariantiSegnatureCollectionObj.Count; i++)
				{
					if ((VariantiSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VariantiSegnatureCollectionObj[i].IsDirty = false;
						VariantiSegnatureCollectionObj[i].IsPersistent = true;
					}
					if ((VariantiSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VariantiSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiSegnatureCollectionObj[i].IsDirty = false;
						VariantiSegnatureCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VariantiSegnature VariantiSegnatureObj)
		{
			int returnValue = 0;
			if (VariantiSegnatureObj.IsPersistent) 
			{
				returnValue = Delete(db, VariantiSegnatureObj.IdVariante, VariantiSegnatureObj.CodTipo);
			}
			VariantiSegnatureObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VariantiSegnatureObj.IsDirty = false;
			VariantiSegnatureObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdVarianteValue, string CodTipoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiSegnatureDelete", new string[] {"IdVariante", "CodTipo"}, new string[] {"int", "string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)IdVarianteValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VariantiSegnatureCollection VariantiSegnatureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiSegnatureDelete", new string[] {"IdVariante", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < VariantiSegnatureCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVariante", VariantiSegnatureCollectionObj[i].IdVariante);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", VariantiSegnatureCollectionObj[i].CodTipo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VariantiSegnatureCollectionObj.Count; i++)
				{
					if ((VariantiSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiSegnatureCollectionObj[i].IsDirty = false;
						VariantiSegnatureCollectionObj[i].IsPersistent = false;
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
		public static VariantiSegnature GetById(DbProvider db, int IdVarianteValue, string CodTipoValue)
		{
			VariantiSegnature VariantiSegnatureObj = null;
			IDbCommand readCmd = db.InitCmd( "ZVariantiSegnatureGetById", new string[] {"IdVariante", "CodTipo"}, new string[] {"int", "string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)IdVarianteValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VariantiSegnatureObj = GetFromDatareader(db);
				VariantiSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiSegnatureObj.IsDirty = false;
				VariantiSegnatureObj.IsPersistent = true;
			}
			db.Close();
			return VariantiSegnatureObj;
		}

		//getFromDatareader
		public static VariantiSegnature GetFromDatareader(DbProvider db)
		{
			VariantiSegnature VariantiSegnatureObj = new VariantiSegnature();
			VariantiSegnatureObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			VariantiSegnatureObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			VariantiSegnatureObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			VariantiSegnatureObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			VariantiSegnatureObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			VariantiSegnatureObj.Motivazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["MOTIVAZIONE"]);
			VariantiSegnatureObj.RiapriVariante = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPRI_VARIANTE"]);
			VariantiSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VariantiSegnatureObj.IsDirty = false;
			VariantiSegnatureObj.IsPersistent = true;
			return VariantiSegnatureObj;
		}

		//Find Select

		public static VariantiSegnatureCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.BoolNT RiapriVarianteEqualThis)

		{

			VariantiSegnatureCollection VariantiSegnatureCollectionObj = new VariantiSegnatureCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantisegnaturefindselect", new string[] {"IdVarianteequalthis", "CodTipoequalthis", "Segnaturaequalthis", 
"Dataequalthis", "Operatoreequalthis", "RiapriVarianteequalthis"}, new string[] {"int", "string", "string", 
"DateTime", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RiapriVarianteequalthis", RiapriVarianteEqualThis);
			VariantiSegnature VariantiSegnatureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiSegnatureObj = GetFromDatareader(db);
				VariantiSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiSegnatureObj.IsDirty = false;
				VariantiSegnatureObj.IsPersistent = true;
				VariantiSegnatureCollectionObj.Add(VariantiSegnatureObj);
			}
			db.Close();
			return VariantiSegnatureCollectionObj;
		}

		//Find Find

		public static VariantiSegnatureCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.BoolNT RiapriVarianteEqualThis)

		{

			VariantiSegnatureCollection VariantiSegnatureCollectionObj = new VariantiSegnatureCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantisegnaturefindfind", new string[] {"IdVarianteequalthis", "CodTipoequalthis", "RiapriVarianteequalthis"}, new string[] {"int", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RiapriVarianteequalthis", RiapriVarianteEqualThis);
			VariantiSegnature VariantiSegnatureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiSegnatureObj = GetFromDatareader(db);
				VariantiSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiSegnatureObj.IsDirty = false;
				VariantiSegnatureObj.IsPersistent = true;
				VariantiSegnatureCollectionObj.Add(VariantiSegnatureObj);
			}
			db.Close();
			return VariantiSegnatureCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_SEGNATURE>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_VARIANTE>Equal</RIAPRI_VARIANTE>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_VARIANTE>Equal</RIAPRI_VARIANTE>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_SEGNATURE>
*/