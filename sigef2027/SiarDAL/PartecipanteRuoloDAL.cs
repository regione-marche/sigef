using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PartecipanteRuoloDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class PartecipanteRuoloDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PartecipanteRuolo PartecipanteRuoloObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPartcipanteRuolo", PartecipanteRuoloObj.IdPartcipanteRuolo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodFiliera", PartecipanteRuoloObj.CodFiliera);
			DbProvider.SetCmdParam(cmd,firstChar + "Cuaa", PartecipanteRuoloObj.Cuaa);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagPartecipante", PartecipanteRuoloObj.FlagPartecipante);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRuoloSitra", PartecipanteRuoloObj.CodRuoloSitra);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRuoloPartecipante", PartecipanteRuoloObj.CodRuoloPartecipante);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInserimento", PartecipanteRuoloObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", PartecipanteRuoloObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoPif", PartecipanteRuoloObj.IdProgettoPif);
			DbProvider.SetCmdParam(cmd,firstChar + "CodSistemaQualita", PartecipanteRuoloObj.CodSistemaQualita);
		}
		//Insert
		private static int Insert(DbProvider db, PartecipanteRuolo PartecipanteRuoloObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPartecipanteRuoloInsert", new string[] {"CodFiliera", "Cuaa", 
"FlagPartecipante", "CodRuoloSitra", "CodRuoloPartecipante", 
"OperatoreInserimento", "DataModifica", 
"IdProgettoPif", 
"CodSistemaQualita"}, new string[] {"string", "string", 
"bool", "string", "string", 
"string", "DateTime", 
"int", 
"string"},"");
				CompileIUCmd(false, insertCmd,PartecipanteRuoloObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PartecipanteRuoloObj.IdPartcipanteRuolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARTCIPANTE_RUOLO"]);
				}
				PartecipanteRuoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipanteRuoloObj.IsDirty = false;
				PartecipanteRuoloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PartecipanteRuolo PartecipanteRuoloObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPartecipanteRuoloUpdate", new string[] {"IdPartcipanteRuolo", "CodFiliera", "Cuaa", 
"FlagPartecipante", "CodRuoloSitra", "CodRuoloPartecipante", 
"OperatoreInserimento", "DataModifica", 
"IdProgettoPif", 
"CodSistemaQualita"}, new string[] {"int", "string", "string", 
"bool", "string", "string", 
"string", "DateTime", 
"int", 
"string"},"");
				CompileIUCmd(true, updateCmd,PartecipanteRuoloObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					PartecipanteRuoloObj.DataModifica = d;
				}
				PartecipanteRuoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipanteRuoloObj.IsDirty = false;
				PartecipanteRuoloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PartecipanteRuolo PartecipanteRuoloObj)
		{
			switch (PartecipanteRuoloObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PartecipanteRuoloObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PartecipanteRuoloObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PartecipanteRuoloObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PartecipanteRuoloCollection PartecipanteRuoloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPartecipanteRuoloUpdate", new string[] {"IdPartcipanteRuolo", "CodFiliera", "Cuaa", 
"FlagPartecipante", "CodRuoloSitra", "CodRuoloPartecipante", 
"OperatoreInserimento", "DataModifica", 
"IdProgettoPif", 
"CodSistemaQualita"}, new string[] {"int", "string", "string", 
"bool", "string", "string", 
"string", "DateTime", 
"int", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPartecipanteRuoloInsert", new string[] {"CodFiliera", "Cuaa", 
"FlagPartecipante", "CodRuoloSitra", "CodRuoloPartecipante", 
"OperatoreInserimento", "DataModifica", 
"IdProgettoPif", 
"CodSistemaQualita"}, new string[] {"string", "string", 
"bool", "string", "string", 
"string", "DateTime", 
"int", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipanteRuoloDelete", new string[] {"IdPartcipanteRuolo"}, new string[] {"int"},"");
				for (int i = 0; i < PartecipanteRuoloCollectionObj.Count; i++)
				{
					switch (PartecipanteRuoloCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PartecipanteRuoloCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PartecipanteRuoloCollectionObj[i].IdPartcipanteRuolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARTCIPANTE_RUOLO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PartecipanteRuoloCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									PartecipanteRuoloCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PartecipanteRuoloCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPartcipanteRuolo", (SiarLibrary.NullTypes.IntNT)PartecipanteRuoloCollectionObj[i].IdPartcipanteRuolo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PartecipanteRuoloCollectionObj.Count; i++)
				{
					if ((PartecipanteRuoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PartecipanteRuoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PartecipanteRuoloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PartecipanteRuoloCollectionObj[i].IsDirty = false;
						PartecipanteRuoloCollectionObj[i].IsPersistent = true;
					}
					if ((PartecipanteRuoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PartecipanteRuoloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PartecipanteRuoloCollectionObj[i].IsDirty = false;
						PartecipanteRuoloCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PartecipanteRuolo PartecipanteRuoloObj)
		{
			int returnValue = 0;
			if (PartecipanteRuoloObj.IsPersistent) 
			{
				returnValue = Delete(db, PartecipanteRuoloObj.IdPartcipanteRuolo);
			}
			PartecipanteRuoloObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PartecipanteRuoloObj.IsDirty = false;
			PartecipanteRuoloObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPartcipanteRuoloValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipanteRuoloDelete", new string[] {"IdPartcipanteRuolo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPartcipanteRuolo", (SiarLibrary.NullTypes.IntNT)IdPartcipanteRuoloValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PartecipanteRuoloCollection PartecipanteRuoloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipanteRuoloDelete", new string[] {"IdPartcipanteRuolo"}, new string[] {"int"},"");
				for (int i = 0; i < PartecipanteRuoloCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPartcipanteRuolo", PartecipanteRuoloCollectionObj[i].IdPartcipanteRuolo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PartecipanteRuoloCollectionObj.Count; i++)
				{
					if ((PartecipanteRuoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PartecipanteRuoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PartecipanteRuoloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PartecipanteRuoloCollectionObj[i].IsDirty = false;
						PartecipanteRuoloCollectionObj[i].IsPersistent = false;
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
		public static PartecipanteRuolo GetById(DbProvider db, int IdPartcipanteRuoloValue)
		{
			PartecipanteRuolo PartecipanteRuoloObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPartecipanteRuoloGetById", new string[] {"IdPartcipanteRuolo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPartcipanteRuolo", (SiarLibrary.NullTypes.IntNT)IdPartcipanteRuoloValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PartecipanteRuoloObj = GetFromDatareader(db);
				PartecipanteRuoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipanteRuoloObj.IsDirty = false;
				PartecipanteRuoloObj.IsPersistent = true;
			}
			db.Close();
			return PartecipanteRuoloObj;
		}

		//getFromDatareader
		public static PartecipanteRuolo GetFromDatareader(DbProvider db)
		{
			PartecipanteRuolo PartecipanteRuoloObj = new PartecipanteRuolo();
			PartecipanteRuoloObj.IdPartcipanteRuolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARTCIPANTE_RUOLO"]);
			PartecipanteRuoloObj.CodFiliera = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FILIERA"]);
			PartecipanteRuoloObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			PartecipanteRuoloObj.FlagPartecipante = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_PARTECIPANTE"]);
			PartecipanteRuoloObj.CodRuoloSitra = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUOLO_SITRA"]);
			PartecipanteRuoloObj.CodRuoloPartecipante = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUOLO_PARTECIPANTE"]);
			PartecipanteRuoloObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			PartecipanteRuoloObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			PartecipanteRuoloObj.RuoloOperativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUOLO_OPERATIVO"]);
			PartecipanteRuoloObj.RuoloSitra = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUOLO_SITRA"]);
			PartecipanteRuoloObj.IdProgettoPif = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_PIF"]);
			PartecipanteRuoloObj.SistemaDiQualita = new SiarLibrary.NullTypes.StringNT(db.DataReader["SISTEMA_DI_QUALITA"]);
			PartecipanteRuoloObj.CodSistemaQualita = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_SISTEMA_QUALITA"]);
			PartecipanteRuoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PartecipanteRuoloObj.IsDirty = false;
			PartecipanteRuoloObj.IsPersistent = true;
			return PartecipanteRuoloObj;
		}

		//Find Select

		public static PartecipanteRuoloCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPartcipanteRuoloEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoPifEqualThis, SiarLibrary.NullTypes.StringNT CodFilieraEqualThis, 
SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.BoolNT FlagPartecipanteEqualThis, SiarLibrary.NullTypes.StringNT CodRuoloSitraEqualThis, 
SiarLibrary.NullTypes.StringNT CodRuoloPartecipanteEqualThis, SiarLibrary.NullTypes.StringNT CodSistemaQualitaEqualThis, SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			PartecipanteRuoloCollection PartecipanteRuoloCollectionObj = new PartecipanteRuoloCollection();

			IDbCommand findCmd = db.InitCmd("Zpartecipanteruolofindselect", new string[] {"IdPartcipanteRuoloequalthis", "IdProgettoPifequalthis", "CodFilieraequalthis", 
"Cuaaequalthis", "FlagPartecipanteequalthis", "CodRuoloSitraequalthis", 
"CodRuoloPartecipanteequalthis", "CodSistemaQualitaequalthis", "OperatoreInserimentoequalthis", 
"DataModificaequalthis"}, new string[] {"int", "int", "string", 
"string", "bool", "string", 
"string", "string", "string", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPartcipanteRuoloequalthis", IdPartcipanteRuoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoPifequalthis", IdProgettoPifEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFilieraequalthis", CodFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagPartecipanteequalthis", FlagPartecipanteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRuoloSitraequalthis", CodRuoloSitraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRuoloPartecipanteequalthis", CodRuoloPartecipanteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodSistemaQualitaequalthis", CodSistemaQualitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			PartecipanteRuolo PartecipanteRuoloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PartecipanteRuoloObj = GetFromDatareader(db);
				PartecipanteRuoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipanteRuoloObj.IsDirty = false;
				PartecipanteRuoloObj.IsPersistent = true;
				PartecipanteRuoloCollectionObj.Add(PartecipanteRuoloObj);
			}
			db.Close();
			return PartecipanteRuoloCollectionObj;
		}

		//Find Find

		public static PartecipanteRuoloCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoPifEqualThis)

		{

			PartecipanteRuoloCollection PartecipanteRuoloCollectionObj = new PartecipanteRuoloCollection();

			IDbCommand findCmd = db.InitCmd("Zpartecipanteruolofindfind", new string[] {"Cuaaequalthis", "IdProgettoPifequalthis"}, new string[] {"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoPifequalthis", IdProgettoPifEqualThis);
			PartecipanteRuolo PartecipanteRuoloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PartecipanteRuoloObj = GetFromDatareader(db);
				PartecipanteRuoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipanteRuoloObj.IsDirty = false;
				PartecipanteRuoloObj.IsPersistent = true;
				PartecipanteRuoloCollectionObj.Add(PartecipanteRuoloObj);
			}
			db.Close();
			return PartecipanteRuoloCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTE_RUOLO>
  <ViewName>vPARTECIPANTE_RUOLO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
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
    <Find OrderBy="ORDER BY ">
      <CUAA>Equal</CUAA>
      <ID_PROGETTO_PIF>Equal</ID_PROGETTO_PIF>
    </Find>
  </Finds>
  <Filters>
    <FiltroSitra>
      <COD_RUOLO_SITRA>Equal</COD_RUOLO_SITRA>
    </FiltroSitra>
    <FiltroRuoloOperativo>
      <COD_RUOLO_PARTECIPANTE>Equal</COD_RUOLO_PARTECIPANTE>
    </FiltroRuoloOperativo>
    <FiltroQualita>
      <COD_SISTEMA_QUALITA>Equal</COD_SISTEMA_QUALITA>
    </FiltroQualita>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PARTECIPANTE_RUOLO>
*/