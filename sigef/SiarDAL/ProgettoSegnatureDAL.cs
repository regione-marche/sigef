using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoSegnatureDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class ProgettoSegnatureDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoSegnature ProgettoSegnatureObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoSegnatureObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", ProgettoSegnatureObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", ProgettoSegnatureObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ProgettoSegnatureObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ProgettoSegnatureObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "RiapriDomanda", ProgettoSegnatureObj.RiapriDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "Motivazione", ProgettoSegnatureObj.Motivazione);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoSegnature ProgettoSegnatureObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoSegnatureInsert", new string[] {"IdProgetto", "CodTipo", "Data", 
"Operatore", "Segnatura", 


"RiapriDomanda", "Motivazione"}, new string[] {"int", "string", "DateTime", 
"string", "string", 


"bool", "string"},"");
				CompileIUCmd(false, insertCmd,ProgettoSegnatureObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoSegnatureObj.RiapriDomanda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPRI_DOMANDA"]);
				}
				ProgettoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSegnatureObj.IsDirty = false;
				ProgettoSegnatureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoSegnature ProgettoSegnatureObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoSegnatureUpdate", new string[] {"IdProgetto", "CodTipo", "Data", 
"Operatore", "Segnatura", 


"RiapriDomanda", "Motivazione"}, new string[] {"int", "string", "DateTime", 
"string", "string", 


"bool", "string"},"");
				CompileIUCmd(true, updateCmd,ProgettoSegnatureObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSegnatureObj.IsDirty = false;
				ProgettoSegnatureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoSegnature ProgettoSegnatureObj)
		{
			switch (ProgettoSegnatureObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoSegnatureObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoSegnatureObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoSegnatureObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoSegnatureCollection ProgettoSegnatureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoSegnatureUpdate", new string[] {"IdProgetto", "CodTipo", "Data", 
"Operatore", "Segnatura", 


"RiapriDomanda", "Motivazione"}, new string[] {"int", "string", "DateTime", 
"string", "string", 


"bool", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoSegnatureInsert", new string[] {"IdProgetto", "CodTipo", "Data", 
"Operatore", "Segnatura", 


"RiapriDomanda", "Motivazione"}, new string[] {"int", "string", "DateTime", 
"string", "string", 


"bool", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoSegnatureDelete", new string[] {"IdProgetto", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < ProgettoSegnatureCollectionObj.Count; i++)
				{
					switch (ProgettoSegnatureCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoSegnatureCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoSegnatureCollectionObj[i].RiapriDomanda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPRI_DOMANDA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoSegnatureCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoSegnatureCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)ProgettoSegnatureCollectionObj[i].IdProgetto);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)ProgettoSegnatureCollectionObj[i].CodTipo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoSegnatureCollectionObj.Count; i++)
				{
					if ((ProgettoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoSegnatureCollectionObj[i].IsDirty = false;
						ProgettoSegnatureCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoSegnatureCollectionObj[i].IsDirty = false;
						ProgettoSegnatureCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoSegnature ProgettoSegnatureObj)
		{
			int returnValue = 0;
			if (ProgettoSegnatureObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoSegnatureObj.IdProgetto, ProgettoSegnatureObj.CodTipo);
			}
			ProgettoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoSegnatureObj.IsDirty = false;
			ProgettoSegnatureObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoValue, string CodTipoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoSegnatureDelete", new string[] {"IdProgetto", "CodTipo"}, new string[] {"int", "string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoSegnatureCollection ProgettoSegnatureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoSegnatureDelete", new string[] {"IdProgetto", "CodTipo"}, new string[] {"int", "string"},"");
				for (int i = 0; i < ProgettoSegnatureCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", ProgettoSegnatureCollectionObj[i].IdProgetto);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", ProgettoSegnatureCollectionObj[i].CodTipo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoSegnatureCollectionObj.Count; i++)
				{
					if ((ProgettoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoSegnatureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoSegnatureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoSegnatureCollectionObj[i].IsDirty = false;
						ProgettoSegnatureCollectionObj[i].IsPersistent = false;
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
		public static ProgettoSegnature GetById(DbProvider db, int IdProgettoValue, string CodTipoValue)
		{
			ProgettoSegnature ProgettoSegnatureObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoSegnatureGetById", new string[] {"IdProgetto", "CodTipo"}, new string[] {"int", "string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoSegnatureObj = GetFromDatareader(db);
				ProgettoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSegnatureObj.IsDirty = false;
				ProgettoSegnatureObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoSegnatureObj;
		}

		//getFromDatareader
		public static ProgettoSegnature GetFromDatareader(DbProvider db)
		{
			ProgettoSegnature ProgettoSegnatureObj = new ProgettoSegnature();
			ProgettoSegnatureObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoSegnatureObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			ProgettoSegnatureObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ProgettoSegnatureObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			ProgettoSegnatureObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ProgettoSegnatureObj.TipoSegnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_SEGNATURA"]);
			ProgettoSegnatureObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
			ProgettoSegnatureObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			ProgettoSegnatureObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
			ProgettoSegnatureObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			ProgettoSegnatureObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			ProgettoSegnatureObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			ProgettoSegnatureObj.RiapriDomanda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPRI_DOMANDA"]);
			ProgettoSegnatureObj.Motivazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["MOTIVAZIONE"]);
			ProgettoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoSegnatureObj.IsDirty = false;
			ProgettoSegnatureObj.IsPersistent = true;
			return ProgettoSegnatureObj;
		}

		//Find Select

		public static ProgettoSegnatureCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.BoolNT RiapriDomandaEqualThis)

		{

			ProgettoSegnatureCollection ProgettoSegnatureCollectionObj = new ProgettoSegnatureCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettosegnaturefindselect", new string[] {"IdProgettoequalthis", "CodTipoequalthis", "Dataequalthis", 
"Operatoreequalthis", "Segnaturaequalthis", "RiapriDomandaequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RiapriDomandaequalthis", RiapriDomandaEqualThis);
			ProgettoSegnature ProgettoSegnatureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoSegnatureObj = GetFromDatareader(db);
				ProgettoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSegnatureObj.IsDirty = false;
				ProgettoSegnatureObj.IsPersistent = true;
				ProgettoSegnatureCollectionObj.Add(ProgettoSegnatureObj);
			}
			db.Close();
			return ProgettoSegnatureCollectionObj;
		}

		//Find Find

		public static ProgettoSegnatureCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoLikeThis)

		{

			ProgettoSegnatureCollection ProgettoSegnatureCollectionObj = new ProgettoSegnatureCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettosegnaturefindfind", new string[] {"IdProgettoequalthis", "Operatoreequalthis", "Segnaturaequalthis", 
"CodTipolikethis"}, new string[] {"int", "string", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipolikethis", CodTipoLikeThis);
			ProgettoSegnature ProgettoSegnatureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoSegnatureObj = GetFromDatareader(db);
				ProgettoSegnatureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSegnatureObj.IsDirty = false;
				ProgettoSegnatureObj.IsPersistent = true;
				ProgettoSegnatureCollectionObj.Add(ProgettoSegnatureObj);
			}
			db.Close();
			return ProgettoSegnatureCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_SEGNATURE>
  <ViewName>vPROGETTO_SEGNATURE</ViewName>
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
    <Find OrderBy="ORDER BY ID_PROGETTO, DATA DESC">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <OPERATORE>Equal</OPERATORE>
      <SEGNATURA>Equal</SEGNATURA>
      <COD_TIPO>Like</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroLikeTipoSegnatura>
      <COD_TIPO>Like</COD_TIPO>
    </FiltroLikeTipoSegnatura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_SEGNATURE>
*/