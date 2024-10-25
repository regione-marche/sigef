using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PartecipantiIndirettiFatturatoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class PartecipantiIndirettiFatturatoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", PartecipantiIndirettiFatturatoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CuaaPromotore", PartecipantiIndirettiFatturatoObj.CuaaPromotore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", PartecipantiIndirettiFatturatoObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "Cuaa", PartecipantiIndirettiFatturatoObj.Cuaa);
			DbProvider.SetCmdParam(cmd,firstChar + "CodProdotto", PartecipantiIndirettiFatturatoObj.CodProdotto);
			DbProvider.SetCmdParam(cmd,firstChar + "CodVarieta", PartecipantiIndirettiFatturatoObj.CodVarieta);
			DbProvider.SetCmdParam(cmd,firstChar + "ProduzioneTotale", PartecipantiIndirettiFatturatoObj.ProduzioneTotale);
			DbProvider.SetCmdParam(cmd,firstChar + "PrezzoMedio", PartecipantiIndirettiFatturatoObj.PrezzoMedio);
			DbProvider.SetCmdParam(cmd,firstChar + "Fatturato", PartecipantiIndirettiFatturatoObj.Fatturato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdClasseAllevamento", PartecipantiIndirettiFatturatoObj.IdClasseAllevamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAttivitaConnessa", PartecipantiIndirettiFatturatoObj.IdAttivitaConnessa);
			DbProvider.SetCmdParam(cmd,firstChar + "CuaaTrasformatore", PartecipantiIndirettiFatturatoObj.CuaaTrasformatore);
			DbProvider.SetCmdParam(cmd,firstChar + "ProduzioneInFiliera", PartecipantiIndirettiFatturatoObj.ProduzioneInFiliera);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroCapi", PartecipantiIndirettiFatturatoObj.NumeroCapi);
		}
		//Insert
		private static int Insert(DbProvider db, PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPartecipantiIndirettiFatturatoInsert", new string[] {"CuaaPromotore", "IdImpresa", 
"Cuaa", "CodProdotto", "CodVarieta", 
"ProduzioneTotale", "PrezzoMedio", "Fatturato", 


"IdClasseAllevamento", 
"IdAttivitaConnessa", "CuaaTrasformatore", 

"ProduzioneInFiliera", "NumeroCapi"}, new string[] {"string", "int", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 


"int", 
"int", "string", 

"decimal", "int"},"");
				CompileIUCmd(false, insertCmd,PartecipantiIndirettiFatturatoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PartecipantiIndirettiFatturatoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				PartecipantiIndirettiFatturatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiIndirettiFatturatoObj.IsDirty = false;
				PartecipantiIndirettiFatturatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPartecipantiIndirettiFatturatoUpdate", new string[] {"Id", "CuaaPromotore", "IdImpresa", 
"Cuaa", "CodProdotto", "CodVarieta", 
"ProduzioneTotale", "PrezzoMedio", "Fatturato", 


"IdClasseAllevamento", 
"IdAttivitaConnessa", "CuaaTrasformatore", 

"ProduzioneInFiliera", "NumeroCapi"}, new string[] {"int", "string", "int", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 


"int", 
"int", "string", 

"decimal", "int"},"");
				CompileIUCmd(true, updateCmd,PartecipantiIndirettiFatturatoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PartecipantiIndirettiFatturatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiIndirettiFatturatoObj.IsDirty = false;
				PartecipantiIndirettiFatturatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj)
		{
			switch (PartecipantiIndirettiFatturatoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PartecipantiIndirettiFatturatoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PartecipantiIndirettiFatturatoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PartecipantiIndirettiFatturatoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPartecipantiIndirettiFatturatoUpdate", new string[] {"Id", "CuaaPromotore", "IdImpresa", 
"Cuaa", "CodProdotto", "CodVarieta", 
"ProduzioneTotale", "PrezzoMedio", "Fatturato", 


"IdClasseAllevamento", 
"IdAttivitaConnessa", "CuaaTrasformatore", 

"ProduzioneInFiliera", "NumeroCapi"}, new string[] {"int", "string", "int", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 


"int", 
"int", "string", 

"decimal", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPartecipantiIndirettiFatturatoInsert", new string[] {"CuaaPromotore", "IdImpresa", 
"Cuaa", "CodProdotto", "CodVarieta", 
"ProduzioneTotale", "PrezzoMedio", "Fatturato", 


"IdClasseAllevamento", 
"IdAttivitaConnessa", "CuaaTrasformatore", 

"ProduzioneInFiliera", "NumeroCapi"}, new string[] {"string", "int", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 


"int", 
"int", "string", 

"decimal", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipantiIndirettiFatturatoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < PartecipantiIndirettiFatturatoCollectionObj.Count; i++)
				{
					switch (PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PartecipantiIndirettiFatturatoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PartecipantiIndirettiFatturatoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PartecipantiIndirettiFatturatoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PartecipantiIndirettiFatturatoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)PartecipantiIndirettiFatturatoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PartecipantiIndirettiFatturatoCollectionObj.Count; i++)
				{
					if ((PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PartecipantiIndirettiFatturatoCollectionObj[i].IsDirty = false;
						PartecipantiIndirettiFatturatoCollectionObj[i].IsPersistent = true;
					}
					if ((PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PartecipantiIndirettiFatturatoCollectionObj[i].IsDirty = false;
						PartecipantiIndirettiFatturatoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj)
		{
			int returnValue = 0;
			if (PartecipantiIndirettiFatturatoObj.IsPersistent) 
			{
				returnValue = Delete(db, PartecipantiIndirettiFatturatoObj.Id);
			}
			PartecipantiIndirettiFatturatoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PartecipantiIndirettiFatturatoObj.IsDirty = false;
			PartecipantiIndirettiFatturatoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipantiIndirettiFatturatoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPartecipantiIndirettiFatturatoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < PartecipantiIndirettiFatturatoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", PartecipantiIndirettiFatturatoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PartecipantiIndirettiFatturatoCollectionObj.Count; i++)
				{
					if ((PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PartecipantiIndirettiFatturatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PartecipantiIndirettiFatturatoCollectionObj[i].IsDirty = false;
						PartecipantiIndirettiFatturatoCollectionObj[i].IsPersistent = false;
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
		public static PartecipantiIndirettiFatturato GetById(DbProvider db, int IdValue)
		{
			PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPartecipantiIndirettiFatturatoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PartecipantiIndirettiFatturatoObj = GetFromDatareader(db);
				PartecipantiIndirettiFatturatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiIndirettiFatturatoObj.IsDirty = false;
				PartecipantiIndirettiFatturatoObj.IsPersistent = true;
			}
			db.Close();
			return PartecipantiIndirettiFatturatoObj;
		}

		//getFromDatareader
		public static PartecipantiIndirettiFatturato GetFromDatareader(DbProvider db)
		{
			PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj = new PartecipantiIndirettiFatturato();
			PartecipantiIndirettiFatturatoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			PartecipantiIndirettiFatturatoObj.CuaaPromotore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_PROMOTORE"]);
			PartecipantiIndirettiFatturatoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			PartecipantiIndirettiFatturatoObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			PartecipantiIndirettiFatturatoObj.CodProdotto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PRODOTTO"]);
			PartecipantiIndirettiFatturatoObj.CodVarieta = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_VARIETA"]);
			PartecipantiIndirettiFatturatoObj.ProduzioneTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PRODUZIONE_TOTALE"]);
			PartecipantiIndirettiFatturatoObj.PrezzoMedio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PREZZO_MEDIO"]);
			PartecipantiIndirettiFatturatoObj.Fatturato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FATTURATO"]);
			PartecipantiIndirettiFatturatoObj.Varieta = new SiarLibrary.NullTypes.StringNT(db.DataReader["VARIETA"]);
			PartecipantiIndirettiFatturatoObj.Prodotto = new SiarLibrary.NullTypes.StringNT(db.DataReader["PRODOTTO"]);
			PartecipantiIndirettiFatturatoObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			PartecipantiIndirettiFatturatoObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			PartecipantiIndirettiFatturatoObj.CodFormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FORMA_GIURIDICA"]);
			PartecipantiIndirettiFatturatoObj.IdDimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIMENSIONE"]);
			PartecipantiIndirettiFatturatoObj.DimensioneImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["DIMENSIONE_IMPRESA"]);
			PartecipantiIndirettiFatturatoObj.FormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMA_GIURIDICA"]);
			PartecipantiIndirettiFatturatoObj.IdClasseAllevamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CLASSE_ALLEVAMENTO"]);
			PartecipantiIndirettiFatturatoObj.IdAttivitaConnessa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTIVITA_CONNESSA"]);
			PartecipantiIndirettiFatturatoObj.CuaaTrasformatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_TRASFORMATORE"]);
			PartecipantiIndirettiFatturatoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PartecipantiIndirettiFatturatoObj.PrezzoUnitario = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PREZZO_UNITARIO"]);
			PartecipantiIndirettiFatturatoObj.AttivitaConnesse = new SiarLibrary.NullTypes.StringNT(db.DataReader["ATTIVITA_CONNESSE"]);
			PartecipantiIndirettiFatturatoObj.PrezzoAttivita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PREZZO_ATTIVITA"]);
			PartecipantiIndirettiFatturatoObj.ProduzioneInFiliera = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PRODUZIONE_IN_FILIERA"]);
			PartecipantiIndirettiFatturatoObj.NumeroCapi = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_CAPI"]);
			PartecipantiIndirettiFatturatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PartecipantiIndirettiFatturatoObj.IsDirty = false;
			PartecipantiIndirettiFatturatoObj.IsPersistent = true;
			return PartecipantiIndirettiFatturatoObj;
		}

		//Find Select

		public static PartecipantiIndirettiFatturatoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT CuaaPromotoreEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CodProdottoEqualThis, SiarLibrary.NullTypes.StringNT CodVarietaEqualThis, 
SiarLibrary.NullTypes.IntNT IdClasseAllevamentoEqualThis, SiarLibrary.NullTypes.IntNT NumeroCapiEqualThis, SiarLibrary.NullTypes.IntNT IdAttivitaConnessaEqualThis, 
SiarLibrary.NullTypes.DecimalNT ProduzioneTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ProduzioneInFilieraEqualThis, SiarLibrary.NullTypes.DecimalNT PrezzoMedioEqualThis, 
SiarLibrary.NullTypes.DecimalNT FatturatoEqualThis, SiarLibrary.NullTypes.StringNT CuaaTrasformatoreEqualThis)

		{

			PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionObj = new PartecipantiIndirettiFatturatoCollection();

			IDbCommand findCmd = db.InitCmd("Zpartecipantiindirettifatturatofindselect", new string[] {"Idequalthis", "CuaaPromotoreequalthis", "IdImpresaequalthis", 
"Cuaaequalthis", "CodProdottoequalthis", "CodVarietaequalthis", 
"IdClasseAllevamentoequalthis", "NumeroCapiequalthis", "IdAttivitaConnessaequalthis", 
"ProduzioneTotaleequalthis", "ProduzioneInFilieraequalthis", "PrezzoMedioequalthis", 
"Fatturatoequalthis", "CuaaTrasformatoreequalthis"}, new string[] {"int", "string", "int", 
"string", "string", "string", 
"int", "int", "int", 
"decimal", "decimal", "decimal", 
"decimal", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CuaaPromotoreequalthis", CuaaPromotoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodProdottoequalthis", CodProdottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodVarietaequalthis", CodVarietaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdClasseAllevamentoequalthis", IdClasseAllevamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroCapiequalthis", NumeroCapiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttivitaConnessaequalthis", IdAttivitaConnessaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProduzioneTotaleequalthis", ProduzioneTotaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProduzioneInFilieraequalthis", ProduzioneInFilieraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PrezzoMedioequalthis", PrezzoMedioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Fatturatoequalthis", FatturatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CuaaTrasformatoreequalthis", CuaaTrasformatoreEqualThis);
			PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PartecipantiIndirettiFatturatoObj = GetFromDatareader(db);
				PartecipantiIndirettiFatturatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiIndirettiFatturatoObj.IsDirty = false;
				PartecipantiIndirettiFatturatoObj.IsPersistent = true;
				PartecipantiIndirettiFatturatoCollectionObj.Add(PartecipantiIndirettiFatturatoObj);
			}
			db.Close();
			return PartecipantiIndirettiFatturatoCollectionObj;
		}

		//Find Find

		public static PartecipantiIndirettiFatturatoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CuaaTrasformatoreEqualThis)

		{

			PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionObj = new PartecipantiIndirettiFatturatoCollection();

			IDbCommand findCmd = db.InitCmd("Zpartecipantiindirettifatturatofindfind", new string[] {"IdImpresaequalthis", "Cuaaequalthis", "CuaaTrasformatoreequalthis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CuaaTrasformatoreequalthis", CuaaTrasformatoreEqualThis);
			PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PartecipantiIndirettiFatturatoObj = GetFromDatareader(db);
				PartecipantiIndirettiFatturatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PartecipantiIndirettiFatturatoObj.IsDirty = false;
				PartecipantiIndirettiFatturatoObj.IsPersistent = true;
				PartecipantiIndirettiFatturatoCollectionObj.Add(PartecipantiIndirettiFatturatoObj);
			}
			db.Close();
			return PartecipantiIndirettiFatturatoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTI_INDIRETTI_FATTURATO>
  <ViewName>vPARECIPANTI_INDIRETTI_FATTURATO</ViewName>
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
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CUAA_TRASFORMATORE>Equal</CUAA_TRASFORMATORE>
    </Find>
  </Finds>
  <Filters>
    <FiltroProdotto>
      <COD_PRODOTTO>IsNull</COD_PRODOTTO>
    </FiltroProdotto>
    <FiltroAllevamento>
      <ID_CLASSE_ALLEVAMENTO>IsNull</ID_CLASSE_ALLEVAMENTO>
    </FiltroAllevamento>
    <FiltroAttivita>
      <ID_ATTIVITA_CONNESSA>IsNull</ID_ATTIVITA_CONNESSA>
    </FiltroAttivita>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PARTECIPANTI_INDIRETTI_FATTURATO>
*/