using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for MandatiImpresaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class MandatiImpresaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, MandatiImpresa MandatiImpresaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", MandatiImpresaObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", MandatiImpresaObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtenteAbilitato", MandatiImpresaObj.IdUtenteAbilitato);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnte", MandatiImpresaObj.CodEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceSportelloCaa", MandatiImpresaObj.CodiceSportelloCaa);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoMandato", MandatiImpresaObj.TipoMandato);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", MandatiImpresaObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", MandatiImpresaObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", MandatiImpresaObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreInizio", MandatiImpresaObj.IdOperatoreInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreFine", MandatiImpresaObj.IdOperatoreFine);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaMandato", MandatiImpresaObj.SegnaturaMandato);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaRevoca", MandatiImpresaObj.SegnaturaRevoca);
		}
		//Insert
		private static int Insert(DbProvider db, MandatiImpresa MandatiImpresaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZMandatiImpresaInsert", new string[] {"IdImpresa", "IdUtenteAbilitato", 
"CodEnte", "CodiceSportelloCaa", "TipoMandato", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", "SegnaturaMandato", 
"SegnaturaRevoca", 


}, new string[] {"int", "int", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", "string", 
"string", 


},"");
				CompileIUCmd(false, insertCmd,MandatiImpresaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				MandatiImpresaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				MandatiImpresaObj.TipoMandato = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_MANDATO"]);
				MandatiImpresaObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				MandatiImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				MandatiImpresaObj.IsDirty = false;
				MandatiImpresaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, MandatiImpresa MandatiImpresaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZMandatiImpresaUpdate", new string[] {"Id", "IdImpresa", "IdUtenteAbilitato", 
"CodEnte", "CodiceSportelloCaa", "TipoMandato", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", "SegnaturaMandato", 
"SegnaturaRevoca", 


}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", "string", 
"string", 


},"");
				CompileIUCmd(true, updateCmd,MandatiImpresaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				MandatiImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				MandatiImpresaObj.IsDirty = false;
				MandatiImpresaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, MandatiImpresa MandatiImpresaObj)
		{
			switch (MandatiImpresaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, MandatiImpresaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, MandatiImpresaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,MandatiImpresaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, MandatiImpresaCollection MandatiImpresaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZMandatiImpresaUpdate", new string[] {"Id", "IdImpresa", "IdUtenteAbilitato", 
"CodEnte", "CodiceSportelloCaa", "TipoMandato", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", "SegnaturaMandato", 
"SegnaturaRevoca", 


}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", "string", 
"string", 


},"");
				IDbCommand insertCmd = db.InitCmd( "ZMandatiImpresaInsert", new string[] {"IdImpresa", "IdUtenteAbilitato", 
"CodEnte", "CodiceSportelloCaa", "TipoMandato", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", "SegnaturaMandato", 
"SegnaturaRevoca", 


}, new string[] {"int", "int", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", "string", 
"string", 


},"");
				IDbCommand deleteCmd = db.InitCmd( "ZMandatiImpresaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < MandatiImpresaCollectionObj.Count; i++)
				{
					switch (MandatiImpresaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,MandatiImpresaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									MandatiImpresaCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									MandatiImpresaCollectionObj[i].TipoMandato = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_MANDATO"]);
									MandatiImpresaCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,MandatiImpresaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (MandatiImpresaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)MandatiImpresaCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < MandatiImpresaCollectionObj.Count; i++)
				{
					if ((MandatiImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (MandatiImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						MandatiImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						MandatiImpresaCollectionObj[i].IsDirty = false;
						MandatiImpresaCollectionObj[i].IsPersistent = true;
					}
					if ((MandatiImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						MandatiImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						MandatiImpresaCollectionObj[i].IsDirty = false;
						MandatiImpresaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, MandatiImpresa MandatiImpresaObj)
		{
			int returnValue = 0;
			if (MandatiImpresaObj.IsPersistent) 
			{
				returnValue = Delete(db, MandatiImpresaObj.Id);
			}
			MandatiImpresaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			MandatiImpresaObj.IsDirty = false;
			MandatiImpresaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZMandatiImpresaDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, MandatiImpresaCollection MandatiImpresaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZMandatiImpresaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < MandatiImpresaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", MandatiImpresaCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < MandatiImpresaCollectionObj.Count; i++)
				{
					if ((MandatiImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (MandatiImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						MandatiImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						MandatiImpresaCollectionObj[i].IsDirty = false;
						MandatiImpresaCollectionObj[i].IsPersistent = false;
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
		public static MandatiImpresa GetById(DbProvider db, int IdValue)
		{
			MandatiImpresa MandatiImpresaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZMandatiImpresaGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				MandatiImpresaObj = GetFromDatareader(db);
				MandatiImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				MandatiImpresaObj.IsDirty = false;
				MandatiImpresaObj.IsPersistent = true;
			}
			db.Close();
			return MandatiImpresaObj;
		}

		//getFromDatareader
		public static MandatiImpresa GetFromDatareader(DbProvider db)
		{
			MandatiImpresa MandatiImpresaObj = new MandatiImpresa();
			MandatiImpresaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			MandatiImpresaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			MandatiImpresaObj.IdUtenteAbilitato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_ABILITATO"]);
			MandatiImpresaObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			MandatiImpresaObj.CodiceSportelloCaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_SPORTELLO_CAA"]);
			MandatiImpresaObj.TipoMandato = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_MANDATO"]);
			MandatiImpresaObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			MandatiImpresaObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			MandatiImpresaObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			MandatiImpresaObj.IdOperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_INIZIO"]);
			MandatiImpresaObj.IdOperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_FINE"]);
			MandatiImpresaObj.SegnaturaMandato = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_MANDATO"]);
			MandatiImpresaObj.SegnaturaRevoca = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_REVOCA"]);
			MandatiImpresaObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			MandatiImpresaObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			MandatiImpresaObj.AnnoCostituzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_COSTITUZIONE"]);
			MandatiImpresaObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
			MandatiImpresaObj.IdContoCorrenteUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTO_CORRENTE_ULTIMO"]);
			MandatiImpresaObj.IdRapprlegaleUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RAPPRLEGALE_ULTIMO"]);
			MandatiImpresaObj.IdSedelegaleUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SEDELEGALE_ULTIMO"]);
			MandatiImpresaObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			MandatiImpresaObj.CodFormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FORMA_GIURIDICA"]);
			MandatiImpresaObj.IdDimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIMENSIONE"]);
			MandatiImpresaObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			MandatiImpresaObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			MandatiImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			MandatiImpresaObj.IsDirty = false;
			MandatiImpresaObj.IsPersistent = true;
			return MandatiImpresaObj;
		}

		//Find Select

		public static MandatiImpresaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteAbilitatoEqualThis, 
SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT CodiceSportelloCaaEqualThis, SiarLibrary.NullTypes.StringNT TipoMandatoEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, 
SiarLibrary.NullTypes.IntNT IdOperatoreInizioEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreFineEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaMandatoEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaRevocaEqualThis)

		{

			MandatiImpresaCollection MandatiImpresaCollectionObj = new MandatiImpresaCollection();

			IDbCommand findCmd = db.InitCmd("Zmandatiimpresafindselect", new string[] {"Idequalthis", "IdImpresaequalthis", "IdUtenteAbilitatoequalthis", 
"CodEnteequalthis", "CodiceSportelloCaaequalthis", "TipoMandatoequalthis", 
"Attivoequalthis", "DataInizioValiditaequalthis", "DataFineValiditaequalthis", 
"IdOperatoreInizioequalthis", "IdOperatoreFineequalthis", "SegnaturaMandatoequalthis", 
"SegnaturaRevocaequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"int", "int", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteAbilitatoequalthis", IdUtenteAbilitatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceSportelloCaaequalthis", CodiceSportelloCaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoMandatoequalthis", TipoMandatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreInizioequalthis", IdOperatoreInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreFineequalthis", IdOperatoreFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaMandatoequalthis", SegnaturaMandatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaRevocaequalthis", SegnaturaRevocaEqualThis);
			MandatiImpresa MandatiImpresaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				MandatiImpresaObj = GetFromDatareader(db);
				MandatiImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				MandatiImpresaObj.IsDirty = false;
				MandatiImpresaObj.IsPersistent = true;
				MandatiImpresaCollectionObj.Add(MandatiImpresaObj);
			}
			db.Close();
			return MandatiImpresaCollectionObj;
		}

		//Find Find

		public static MandatiImpresaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, 
SiarLibrary.NullTypes.StringNT RagioneSocialeLikeThis, SiarLibrary.NullTypes.IntNT IdUtenteAbilitatoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis, SiarLibrary.NullTypes.StringNT TipoMandatoEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			MandatiImpresaCollection MandatiImpresaCollectionObj = new MandatiImpresaCollection();

			IDbCommand findCmd = db.InitCmd("Zmandatiimpresafindfind", new string[] {"IdImpresaequalthis", "Cuaaequalthis", "CodiceFiscaleequalthis", 
"RagioneSocialelikethis", "IdUtenteAbilitatoequalthis", "CodEnteequalthis", 
"CodTipoEnteequalthis", "TipoMandatoequalthis", "Attivoequalthis"}, new string[] {"int", "string", "string", 
"string", "int", "string", 
"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialelikethis", RagioneSocialeLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteAbilitatoequalthis", IdUtenteAbilitatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoMandatoequalthis", TipoMandatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			MandatiImpresa MandatiImpresaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				MandatiImpresaObj = GetFromDatareader(db);
				MandatiImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				MandatiImpresaObj.IsDirty = false;
				MandatiImpresaObj.IsPersistent = true;
				MandatiImpresaCollectionObj.Add(MandatiImpresaObj);
			}
			db.Close();
			return MandatiImpresaCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<MANDATI_IMPRESA>
  <ViewName>vMANDATI_IMPRESA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, RAGIONE_SOCIALE">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <ID_UTENTE_ABILITATO>Equal</ID_UTENTE_ABILITATO>
      <COD_ENTE>Equal</COD_ENTE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
      <TIPO_MANDATO>Equal</TIPO_MANDATO>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttivoTipoMandato>
      <ATTIVO>Equal</ATTIVO>
      <TIPO_MANDATO>Equal</TIPO_MANDATO>
    </FiltroAttivoTipoMandato>
  </Filters>
  <externalFields />
  <AddedFkFields />
</MANDATI_IMPRESA>
*/