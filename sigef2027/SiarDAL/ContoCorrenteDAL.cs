using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ContoCorrenteDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class ContoCorrenteDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ContoCorrente ContoCorrenteObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdContoCorrente", ContoCorrenteObj.IdContoCorrente);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", ContoCorrenteObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPersona", ContoCorrenteObj.IdPersona);
			DbProvider.SetCmdParam(cmd,firstChar + "CodPaese", ContoCorrenteObj.CodPaese);
			DbProvider.SetCmdParam(cmd,firstChar + "CinEuro", ContoCorrenteObj.CinEuro);
			DbProvider.SetCmdParam(cmd,firstChar + "Cin", ContoCorrenteObj.Cin);
			DbProvider.SetCmdParam(cmd,firstChar + "Abi", ContoCorrenteObj.Abi);
			DbProvider.SetCmdParam(cmd,firstChar + "Cab", ContoCorrenteObj.Cab);
			DbProvider.SetCmdParam(cmd,firstChar + "Numero", ContoCorrenteObj.Numero);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", ContoCorrenteObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", ContoCorrenteObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", ContoCorrenteObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "Istituto", ContoCorrenteObj.Istituto);
			DbProvider.SetCmdParam(cmd,firstChar + "Agenzia", ContoCorrenteObj.Agenzia);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComune", ContoCorrenteObj.IdComune);
		}
		//Insert
		private static int Insert(DbProvider db, ContoCorrente ContoCorrenteObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZContoCorrenteInsert", new string[] {"IdImpresa", "IdPersona", 
"CodPaese", "CinEuro", "Cin", 
"Abi", "Cab", "Numero", 
"Note", "DataInizioValidita", "DataFineValidita", 
"Istituto", "Agenzia", "IdComune", 
}, new string[] {"int", "int", 
"string", "string", "string", 
"string", "string", "string", 
"string", "DateTime", "DateTime", 
"string", "string", "int", 
},"");
				CompileIUCmd(false, insertCmd,ContoCorrenteObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ContoCorrenteObj.IdContoCorrente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTO_CORRENTE"]);
				ContoCorrenteObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
				}
				ContoCorrenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContoCorrenteObj.IsDirty = false;
				ContoCorrenteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ContoCorrente ContoCorrenteObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZContoCorrenteUpdate", new string[] {"IdContoCorrente", "IdImpresa", "IdPersona", 
"CodPaese", "CinEuro", "Cin", 
"Abi", "Cab", "Numero", 
"Note", "DataInizioValidita", "DataFineValidita", 
"Istituto", "Agenzia", "IdComune", 
}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"string", "string", "string", 
"string", "DateTime", "DateTime", 
"string", "string", "int", 
},"");
				CompileIUCmd(true, updateCmd,ContoCorrenteObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ContoCorrenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContoCorrenteObj.IsDirty = false;
				ContoCorrenteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ContoCorrente ContoCorrenteObj)
		{
			switch (ContoCorrenteObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ContoCorrenteObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ContoCorrenteObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ContoCorrenteObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ContoCorrenteCollection ContoCorrenteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZContoCorrenteUpdate", new string[] {"IdContoCorrente", "IdImpresa", "IdPersona", 
"CodPaese", "CinEuro", "Cin", 
"Abi", "Cab", "Numero", 
"Note", "DataInizioValidita", "DataFineValidita", 
"Istituto", "Agenzia", "IdComune", 
}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"string", "string", "string", 
"string", "DateTime", "DateTime", 
"string", "string", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZContoCorrenteInsert", new string[] {"IdImpresa", "IdPersona", 
"CodPaese", "CinEuro", "Cin", 
"Abi", "Cab", "Numero", 
"Note", "DataInizioValidita", "DataFineValidita", 
"Istituto", "Agenzia", "IdComune", 
}, new string[] {"int", "int", 
"string", "string", "string", 
"string", "string", "string", 
"string", "DateTime", "DateTime", 
"string", "string", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZContoCorrenteDelete", new string[] {"IdContoCorrente"}, new string[] {"int"},"");
				for (int i = 0; i < ContoCorrenteCollectionObj.Count; i++)
				{
					switch (ContoCorrenteCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ContoCorrenteCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ContoCorrenteCollectionObj[i].IdContoCorrente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTO_CORRENTE"]);
									ContoCorrenteCollectionObj[i].DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ContoCorrenteCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ContoCorrenteCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdContoCorrente", (SiarLibrary.NullTypes.IntNT)ContoCorrenteCollectionObj[i].IdContoCorrente);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ContoCorrenteCollectionObj.Count; i++)
				{
					if ((ContoCorrenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ContoCorrenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ContoCorrenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ContoCorrenteCollectionObj[i].IsDirty = false;
						ContoCorrenteCollectionObj[i].IsPersistent = true;
					}
					if ((ContoCorrenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ContoCorrenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ContoCorrenteCollectionObj[i].IsDirty = false;
						ContoCorrenteCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ContoCorrente ContoCorrenteObj)
		{
			int returnValue = 0;
			if (ContoCorrenteObj.IsPersistent) 
			{
				returnValue = Delete(db, ContoCorrenteObj.IdContoCorrente);
			}
			ContoCorrenteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ContoCorrenteObj.IsDirty = false;
			ContoCorrenteObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdContoCorrenteValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZContoCorrenteDelete", new string[] {"IdContoCorrente"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdContoCorrente", (SiarLibrary.NullTypes.IntNT)IdContoCorrenteValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ContoCorrenteCollection ContoCorrenteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZContoCorrenteDelete", new string[] {"IdContoCorrente"}, new string[] {"int"},"");
				for (int i = 0; i < ContoCorrenteCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdContoCorrente", ContoCorrenteCollectionObj[i].IdContoCorrente);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ContoCorrenteCollectionObj.Count; i++)
				{
					if ((ContoCorrenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ContoCorrenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ContoCorrenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ContoCorrenteCollectionObj[i].IsDirty = false;
						ContoCorrenteCollectionObj[i].IsPersistent = false;
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
		public static ContoCorrente GetById(DbProvider db, int IdContoCorrenteValue)
		{
			ContoCorrente ContoCorrenteObj = null;
			IDbCommand readCmd = db.InitCmd( "ZContoCorrenteGetById", new string[] {"IdContoCorrente"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdContoCorrente", (SiarLibrary.NullTypes.IntNT)IdContoCorrenteValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ContoCorrenteObj = GetFromDatareader(db);
				ContoCorrenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContoCorrenteObj.IsDirty = false;
				ContoCorrenteObj.IsPersistent = true;
			}
			db.Close();
			return ContoCorrenteObj;
		}

		//getFromDatareader
		public static ContoCorrente GetFromDatareader(DbProvider db)
		{
			ContoCorrente ContoCorrenteObj = new ContoCorrente();
			ContoCorrenteObj.IdContoCorrente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTO_CORRENTE"]);
			ContoCorrenteObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			ContoCorrenteObj.IdPersona = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA"]);
			ContoCorrenteObj.CodPaese = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PAESE"]);
			ContoCorrenteObj.CinEuro = new SiarLibrary.NullTypes.StringNT(db.DataReader["CIN_EURO"]);
			ContoCorrenteObj.Cin = new SiarLibrary.NullTypes.StringNT(db.DataReader["CIN"]);
			ContoCorrenteObj.Abi = new SiarLibrary.NullTypes.StringNT(db.DataReader["ABI"]);
			ContoCorrenteObj.Cab = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAB"]);
			ContoCorrenteObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			ContoCorrenteObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			ContoCorrenteObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			ContoCorrenteObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			ContoCorrenteObj.Istituto = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTITUTO"]);
			ContoCorrenteObj.Agenzia = new SiarLibrary.NullTypes.StringNT(db.DataReader["AGENZIA"]);
			ContoCorrenteObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			ContoCorrenteObj.CodBelfiore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_BELFIORE"]);
			ContoCorrenteObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			ContoCorrenteObj.Sigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["SIGLA"]);
			ContoCorrenteObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			ContoCorrenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ContoCorrenteObj.IsDirty = false;
			ContoCorrenteObj.IsPersistent = true;
			return ContoCorrenteObj;
		}

		//Find Select

		public static ContoCorrenteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdContoCorrenteEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdPersonaEqualThis, 
SiarLibrary.NullTypes.StringNT CodPaeseEqualThis, SiarLibrary.NullTypes.StringNT CinEuroEqualThis, SiarLibrary.NullTypes.StringNT CinEqualThis, 
SiarLibrary.NullTypes.StringNT AbiEqualThis, SiarLibrary.NullTypes.StringNT CabEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, 
SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, 
SiarLibrary.NullTypes.StringNT IstitutoEqualThis, SiarLibrary.NullTypes.StringNT AgenziaEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis)

		{

			ContoCorrenteCollection ContoCorrenteCollectionObj = new ContoCorrenteCollection();

			IDbCommand findCmd = db.InitCmd("Zcontocorrentefindselect", new string[] {"IdContoCorrenteequalthis", "IdImpresaequalthis", "IdPersonaequalthis", 
"CodPaeseequalthis", "CinEuroequalthis", "Cinequalthis", 
"Abiequalthis", "Cabequalthis", "Numeroequalthis", 
"Noteequalthis", "DataInizioValiditaequalthis", "DataFineValiditaequalthis", 
"Istitutoequalthis", "Agenziaequalthis", "IdComuneequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"string", "string", "string", 
"string", "DateTime", "DateTime", 
"string", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdContoCorrenteequalthis", IdContoCorrenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaequalthis", IdPersonaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPaeseequalthis", CodPaeseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CinEuroequalthis", CinEuroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cinequalthis", CinEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Abiequalthis", AbiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cabequalthis", CabEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istitutoequalthis", IstitutoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Agenziaequalthis", AgenziaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			ContoCorrente ContoCorrenteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ContoCorrenteObj = GetFromDatareader(db);
				ContoCorrenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContoCorrenteObj.IsDirty = false;
				ContoCorrenteObj.IsPersistent = true;
				ContoCorrenteCollectionObj.Add(ContoCorrenteObj);
			}
			db.Close();
			return ContoCorrenteCollectionObj;
		}

		//Find Find

		public static ContoCorrenteCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdContoCorrenteEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdPersonaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqLessThanThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqGreaterThanThis, SiarLibrary.NullTypes.BoolNT DataFineValiditaIsNull)

		{

			ContoCorrenteCollection ContoCorrenteCollectionObj = new ContoCorrenteCollection();

			IDbCommand findCmd = db.InitCmd("Zcontocorrentefindfind", new string[] {"IdContoCorrenteequalthis", "IdImpresaequalthis", "IdPersonaequalthis", 
"DataInizioValiditaeqlessthanthis", "DataFineValiditaeqgreaterthanthis", "DataFineValiditaisnull"}, new string[] {"int", "int", "int", 
"DateTime", "DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdContoCorrenteequalthis", IdContoCorrenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaequalthis", IdPersonaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaeqlessthanthis", DataInizioValiditaEqLessThanThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaeqgreaterthanthis", DataFineValiditaEqGreaterThanThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaisnull", DataFineValiditaIsNull);
			ContoCorrente ContoCorrenteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ContoCorrenteObj = GetFromDatareader(db);
				ContoCorrenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContoCorrenteObj.IsDirty = false;
				ContoCorrenteObj.IsPersistent = true;
				ContoCorrenteCollectionObj.Add(ContoCorrenteObj);
			}
			db.Close();
			return ContoCorrenteCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTO_CORRENTE>
  <ViewName>vCONTO_CORRENTE</ViewName>
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
    <Find OrderBy="ORDER BY DATA_INIZIO_VALIDITA DESC">
      <ID_CONTO_CORRENTE>Equal</ID_CONTO_CORRENTE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PERSONA>Equal</ID_PERSONA>
      <DATA_INIZIO_VALIDITA>EqLessThan</DATA_INIZIO_VALIDITA>
      <DATA_FINE_VALIDITA>EqGreaterThan</DATA_FINE_VALIDITA>
      <DATA_FINE_VALIDITA>IsNull</DATA_FINE_VALIDITA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTO_CORRENTE>
*/