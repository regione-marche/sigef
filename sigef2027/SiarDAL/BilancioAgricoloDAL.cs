using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BilancioAgricoloDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class BilancioAgricoloDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BilancioAgricolo BilancioAgricoloObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdBilancioAgricolo", BilancioAgricoloObj.IdBilancioAgricolo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", BilancioAgricoloObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", BilancioAgricoloObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", BilancioAgricoloObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "DataBilancio", BilancioAgricoloObj.DataBilancio);
			DbProvider.SetCmdParam(cmd,firstChar + "Previsionale", BilancioAgricoloObj.Previsionale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", BilancioAgricoloObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvRicaviNetti", BilancioAgricoloObj.PlvRicaviNetti);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvRicaviAttivita", BilancioAgricoloObj.PlvRicaviAttivita);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvRimanenzeFinali", BilancioAgricoloObj.PlvRimanenzeFinali);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvRimanenzeIniziali", BilancioAgricoloObj.PlvRimanenzeIniziali);
			DbProvider.SetCmdParam(cmd,firstChar + "VaCostiMatPrime", BilancioAgricoloObj.VaCostiMatPrime);
			DbProvider.SetCmdParam(cmd,firstChar + "VaCostiAttConnesse", BilancioAgricoloObj.VaCostiAttConnesse);
			DbProvider.SetCmdParam(cmd,firstChar + "VaNoleggi", BilancioAgricoloObj.VaNoleggi);
			DbProvider.SetCmdParam(cmd,firstChar + "VaManutenzioni", BilancioAgricoloObj.VaManutenzioni);
			DbProvider.SetCmdParam(cmd,firstChar + "VaSpeseGenerali", BilancioAgricoloObj.VaSpeseGenerali);
			DbProvider.SetCmdParam(cmd,firstChar + "VaAffitti", BilancioAgricoloObj.VaAffitti);
			DbProvider.SetCmdParam(cmd,firstChar + "VaAltriCosti", BilancioAgricoloObj.VaAltriCosti);
			DbProvider.SetCmdParam(cmd,firstChar + "PnAmmMacchine", BilancioAgricoloObj.PnAmmMacchine);
			DbProvider.SetCmdParam(cmd,firstChar + "PnAmmFabbricati", BilancioAgricoloObj.PnAmmFabbricati);
			DbProvider.SetCmdParam(cmd,firstChar + "PnAmmPiantagioni", BilancioAgricoloObj.PnAmmPiantagioni);
			DbProvider.SetCmdParam(cmd,firstChar + "RoSalari", BilancioAgricoloObj.RoSalari);
			DbProvider.SetCmdParam(cmd,firstChar + "RoOneri", BilancioAgricoloObj.RoOneri);
			DbProvider.SetCmdParam(cmd,firstChar + "RnPacRicavi", BilancioAgricoloObj.RnPacRicavi);
			DbProvider.SetCmdParam(cmd,firstChar + "RnPacCosti", BilancioAgricoloObj.RnPacCosti);
			DbProvider.SetCmdParam(cmd,firstChar + "RnPacProventi", BilancioAgricoloObj.RnPacProventi);
			DbProvider.SetCmdParam(cmd,firstChar + "RnPacPerdite", BilancioAgricoloObj.RnPacPerdite);
			DbProvider.SetCmdParam(cmd,firstChar + "RnPacInteressiAttivi", BilancioAgricoloObj.RnPacInteressiAttivi);
			DbProvider.SetCmdParam(cmd,firstChar + "RnPacInteressiPassivi", BilancioAgricoloObj.RnPacInteressiPassivi);
			DbProvider.SetCmdParam(cmd,firstChar + "RnPacImposte", BilancioAgricoloObj.RnPacImposte);
			DbProvider.SetCmdParam(cmd,firstChar + "RnPacContributiPac", BilancioAgricoloObj.RnPacContributiPac);
			DbProvider.SetCmdParam(cmd,firstChar + "MnlRedditiFam", BilancioAgricoloObj.MnlRedditiFam);
			DbProvider.SetCmdParam(cmd,firstChar + "MnlRimborso", BilancioAgricoloObj.MnlRimborso);
			DbProvider.SetCmdParam(cmd,firstChar + "MnlPrelievi", BilancioAgricoloObj.MnlPrelievi);
			DbProvider.SetCmdParam(cmd,firstChar + "CfCfTerreni", BilancioAgricoloObj.CfCfTerreni);
			DbProvider.SetCmdParam(cmd,firstChar + "CfCfImpianti", BilancioAgricoloObj.CfCfImpianti);
			DbProvider.SetCmdParam(cmd,firstChar + "CfCfPiantagioni", BilancioAgricoloObj.CfCfPiantagioni);
			DbProvider.SetCmdParam(cmd,firstChar + "CfCfMiglioramenti", BilancioAgricoloObj.CfCfMiglioramenti);
			DbProvider.SetCmdParam(cmd,firstChar + "CfCaMacchine", BilancioAgricoloObj.CfCaMacchine);
			DbProvider.SetCmdParam(cmd,firstChar + "CfCaBestiame", BilancioAgricoloObj.CfCaBestiame);
			DbProvider.SetCmdParam(cmd,firstChar + "CfIfPartecipazioni", BilancioAgricoloObj.CfIfPartecipazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "CcDfRimanenze", BilancioAgricoloObj.CcDfRimanenze);
			DbProvider.SetCmdParam(cmd,firstChar + "CcDfAnticipazioni", BilancioAgricoloObj.CcDfAnticipazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "CcLdCrediti", BilancioAgricoloObj.CcLdCrediti);
			DbProvider.SetCmdParam(cmd,firstChar + "CcLiBanca", BilancioAgricoloObj.CcLiBanca);
			DbProvider.SetCmdParam(cmd,firstChar + "CcLiCassa", BilancioAgricoloObj.CcLiCassa);
			DbProvider.SetCmdParam(cmd,firstChar + "FfPcDebitiBreveTermine", BilancioAgricoloObj.FfPcDebitiBreveTermine);
			DbProvider.SetCmdParam(cmd,firstChar + "FfPcFornitori", BilancioAgricoloObj.FfPcFornitori);
			DbProvider.SetCmdParam(cmd,firstChar + "FfPcDebiti", BilancioAgricoloObj.FfPcDebiti);
			DbProvider.SetCmdParam(cmd,firstChar + "FfPcMutui", BilancioAgricoloObj.FfPcMutui);
			DbProvider.SetCmdParam(cmd,firstChar + "FfMpCapitale", BilancioAgricoloObj.FfMpCapitale);
			DbProvider.SetCmdParam(cmd,firstChar + "FfMpRiserve", BilancioAgricoloObj.FfMpRiserve);
			DbProvider.SetCmdParam(cmd,firstChar + "FfMpUtile", BilancioAgricoloObj.FfMpUtile);
		}
		//Insert
		private static int Insert(DbProvider db, BilancioAgricolo BilancioAgricoloObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBilancioAgricoloInsert", new string[] {"IdImpresa", "IdProgetto", 
"Anno", "DataBilancio", "Previsionale", 
"DataModifica", "PlvRicaviNetti", "PlvRicaviAttivita", 
"PlvRimanenzeFinali", "PlvRimanenzeIniziali", "VaCostiMatPrime", 
"VaCostiAttConnesse", "VaNoleggi", "VaManutenzioni", 
"VaSpeseGenerali", "VaAffitti", "VaAltriCosti", 
"PnAmmMacchine", "PnAmmFabbricati", "PnAmmPiantagioni", 
"RoSalari", "RoOneri", "RnPacRicavi", 
"RnPacCosti", "RnPacProventi", "RnPacPerdite", 
"RnPacInteressiAttivi", "RnPacInteressiPassivi", "RnPacImposte", 
"RnPacContributiPac", "MnlRedditiFam", "MnlRimborso", 
"MnlPrelievi", "CfCfTerreni", "CfCfImpianti", 
"CfCfPiantagioni", "CfCfMiglioramenti", "CfCaMacchine", 
"CfCaBestiame", "CfIfPartecipazioni", "CcDfRimanenze", 
"CcDfAnticipazioni", "CcLdCrediti", "CcLiBanca", 
"CcLiCassa", "FfPcDebitiBreveTermine", "FfPcFornitori", 
"FfPcDebiti", "FfPcMutui", "FfMpCapitale", 
"FfMpRiserve", "FfMpUtile"}, new string[] {"int", "int", 
"int", "DateTime", "bool", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");
				CompileIUCmd(false, insertCmd,BilancioAgricoloObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BilancioAgricoloObj.IdBilancioAgricolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO_AGRICOLO"]);
				}
				BilancioAgricoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioAgricoloObj.IsDirty = false;
				BilancioAgricoloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BilancioAgricolo BilancioAgricoloObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBilancioAgricoloUpdate", new string[] {"IdBilancioAgricolo", "IdImpresa", "IdProgetto", 
"Anno", "DataBilancio", "Previsionale", 
"DataModifica", "PlvRicaviNetti", "PlvRicaviAttivita", 
"PlvRimanenzeFinali", "PlvRimanenzeIniziali", "VaCostiMatPrime", 
"VaCostiAttConnesse", "VaNoleggi", "VaManutenzioni", 
"VaSpeseGenerali", "VaAffitti", "VaAltriCosti", 
"PnAmmMacchine", "PnAmmFabbricati", "PnAmmPiantagioni", 
"RoSalari", "RoOneri", "RnPacRicavi", 
"RnPacCosti", "RnPacProventi", "RnPacPerdite", 
"RnPacInteressiAttivi", "RnPacInteressiPassivi", "RnPacImposte", 
"RnPacContributiPac", "MnlRedditiFam", "MnlRimborso", 
"MnlPrelievi", "CfCfTerreni", "CfCfImpianti", 
"CfCfPiantagioni", "CfCfMiglioramenti", "CfCaMacchine", 
"CfCaBestiame", "CfIfPartecipazioni", "CcDfRimanenze", 
"CcDfAnticipazioni", "CcLdCrediti", "CcLiBanca", 
"CcLiCassa", "FfPcDebitiBreveTermine", "FfPcFornitori", 
"FfPcDebiti", "FfPcMutui", "FfMpCapitale", 
"FfMpRiserve", "FfMpUtile"}, new string[] {"int", "int", "int", 
"int", "DateTime", "bool", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");
				CompileIUCmd(true, updateCmd,BilancioAgricoloObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					BilancioAgricoloObj.DataModifica = d;
				}
				BilancioAgricoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioAgricoloObj.IsDirty = false;
				BilancioAgricoloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BilancioAgricolo BilancioAgricoloObj)
		{
			switch (BilancioAgricoloObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BilancioAgricoloObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BilancioAgricoloObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BilancioAgricoloObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BilancioAgricoloCollection BilancioAgricoloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBilancioAgricoloUpdate", new string[] {"IdBilancioAgricolo", "IdImpresa", "IdProgetto", 
"Anno", "DataBilancio", "Previsionale", 
"DataModifica", "PlvRicaviNetti", "PlvRicaviAttivita", 
"PlvRimanenzeFinali", "PlvRimanenzeIniziali", "VaCostiMatPrime", 
"VaCostiAttConnesse", "VaNoleggi", "VaManutenzioni", 
"VaSpeseGenerali", "VaAffitti", "VaAltriCosti", 
"PnAmmMacchine", "PnAmmFabbricati", "PnAmmPiantagioni", 
"RoSalari", "RoOneri", "RnPacRicavi", 
"RnPacCosti", "RnPacProventi", "RnPacPerdite", 
"RnPacInteressiAttivi", "RnPacInteressiPassivi", "RnPacImposte", 
"RnPacContributiPac", "MnlRedditiFam", "MnlRimborso", 
"MnlPrelievi", "CfCfTerreni", "CfCfImpianti", 
"CfCfPiantagioni", "CfCfMiglioramenti", "CfCaMacchine", 
"CfCaBestiame", "CfIfPartecipazioni", "CcDfRimanenze", 
"CcDfAnticipazioni", "CcLdCrediti", "CcLiBanca", 
"CcLiCassa", "FfPcDebitiBreveTermine", "FfPcFornitori", 
"FfPcDebiti", "FfPcMutui", "FfMpCapitale", 
"FfMpRiserve", "FfMpUtile"}, new string[] {"int", "int", "int", 
"int", "DateTime", "bool", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBilancioAgricoloInsert", new string[] {"IdImpresa", "IdProgetto", 
"Anno", "DataBilancio", "Previsionale", 
"DataModifica", "PlvRicaviNetti", "PlvRicaviAttivita", 
"PlvRimanenzeFinali", "PlvRimanenzeIniziali", "VaCostiMatPrime", 
"VaCostiAttConnesse", "VaNoleggi", "VaManutenzioni", 
"VaSpeseGenerali", "VaAffitti", "VaAltriCosti", 
"PnAmmMacchine", "PnAmmFabbricati", "PnAmmPiantagioni", 
"RoSalari", "RoOneri", "RnPacRicavi", 
"RnPacCosti", "RnPacProventi", "RnPacPerdite", 
"RnPacInteressiAttivi", "RnPacInteressiPassivi", "RnPacImposte", 
"RnPacContributiPac", "MnlRedditiFam", "MnlRimborso", 
"MnlPrelievi", "CfCfTerreni", "CfCfImpianti", 
"CfCfPiantagioni", "CfCfMiglioramenti", "CfCaMacchine", 
"CfCaBestiame", "CfIfPartecipazioni", "CcDfRimanenze", 
"CcDfAnticipazioni", "CcLdCrediti", "CcLiBanca", 
"CcLiCassa", "FfPcDebitiBreveTermine", "FfPcFornitori", 
"FfPcDebiti", "FfPcMutui", "FfMpCapitale", 
"FfMpRiserve", "FfMpUtile"}, new string[] {"int", "int", 
"int", "DateTime", "bool", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioAgricoloDelete", new string[] {"IdBilancioAgricolo"}, new string[] {"int"},"");
				for (int i = 0; i < BilancioAgricoloCollectionObj.Count; i++)
				{
					switch (BilancioAgricoloCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BilancioAgricoloCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BilancioAgricoloCollectionObj[i].IdBilancioAgricolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO_AGRICOLO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BilancioAgricoloCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									BilancioAgricoloCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BilancioAgricoloCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancioAgricolo", (SiarLibrary.NullTypes.IntNT)BilancioAgricoloCollectionObj[i].IdBilancioAgricolo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BilancioAgricoloCollectionObj.Count; i++)
				{
					if ((BilancioAgricoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BilancioAgricoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BilancioAgricoloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BilancioAgricoloCollectionObj[i].IsDirty = false;
						BilancioAgricoloCollectionObj[i].IsPersistent = true;
					}
					if ((BilancioAgricoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BilancioAgricoloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BilancioAgricoloCollectionObj[i].IsDirty = false;
						BilancioAgricoloCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BilancioAgricolo BilancioAgricoloObj)
		{
			int returnValue = 0;
			if (BilancioAgricoloObj.IsPersistent) 
			{
				returnValue = Delete(db, BilancioAgricoloObj.IdBilancioAgricolo);
			}
			BilancioAgricoloObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BilancioAgricoloObj.IsDirty = false;
			BilancioAgricoloObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBilancioAgricoloValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioAgricoloDelete", new string[] {"IdBilancioAgricolo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancioAgricolo", (SiarLibrary.NullTypes.IntNT)IdBilancioAgricoloValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BilancioAgricoloCollection BilancioAgricoloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioAgricoloDelete", new string[] {"IdBilancioAgricolo"}, new string[] {"int"},"");
				for (int i = 0; i < BilancioAgricoloCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancioAgricolo", BilancioAgricoloCollectionObj[i].IdBilancioAgricolo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BilancioAgricoloCollectionObj.Count; i++)
				{
					if ((BilancioAgricoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BilancioAgricoloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BilancioAgricoloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BilancioAgricoloCollectionObj[i].IsDirty = false;
						BilancioAgricoloCollectionObj[i].IsPersistent = false;
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
		public static BilancioAgricolo GetById(DbProvider db, int IdBilancioAgricoloValue)
		{
			BilancioAgricolo BilancioAgricoloObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBilancioAgricoloGetById", new string[] {"IdBilancioAgricolo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBilancioAgricolo", (SiarLibrary.NullTypes.IntNT)IdBilancioAgricoloValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BilancioAgricoloObj = GetFromDatareader(db);
				BilancioAgricoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioAgricoloObj.IsDirty = false;
				BilancioAgricoloObj.IsPersistent = true;
			}
			db.Close();
			return BilancioAgricoloObj;
		}

		//getFromDatareader
		public static BilancioAgricolo GetFromDatareader(DbProvider db)
		{
			BilancioAgricolo BilancioAgricoloObj = new BilancioAgricolo();
			BilancioAgricoloObj.IdBilancioAgricolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO_AGRICOLO"]);
			BilancioAgricoloObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			BilancioAgricoloObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			BilancioAgricoloObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			BilancioAgricoloObj.DataBilancio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_BILANCIO"]);
			BilancioAgricoloObj.Previsionale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREVISIONALE"]);
			BilancioAgricoloObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			BilancioAgricoloObj.PlvRicaviNetti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_RICAVI_NETTI"]);
			BilancioAgricoloObj.PlvRicaviAttivita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_RICAVI_ATTIVITA"]);
			BilancioAgricoloObj.PlvRimanenzeFinali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_RIMANENZE_FINALI"]);
			BilancioAgricoloObj.PlvRimanenzeIniziali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_RIMANENZE_INIZIALI"]);
			BilancioAgricoloObj.VaCostiMatPrime = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VA_COSTI_MAT_PRIME"]);
			BilancioAgricoloObj.VaCostiAttConnesse = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VA_COSTI_ATT_CONNESSE"]);
			BilancioAgricoloObj.VaNoleggi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VA_NOLEGGI"]);
			BilancioAgricoloObj.VaManutenzioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VA_MANUTENZIONI"]);
			BilancioAgricoloObj.VaSpeseGenerali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VA_SPESE_GENERALI"]);
			BilancioAgricoloObj.VaAffitti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VA_AFFITTI"]);
			BilancioAgricoloObj.VaAltriCosti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VA_ALTRI_COSTI"]);
			BilancioAgricoloObj.PnAmmMacchine = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PN_AMM_MACCHINE"]);
			BilancioAgricoloObj.PnAmmFabbricati = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PN_AMM_FABBRICATI"]);
			BilancioAgricoloObj.PnAmmPiantagioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PN_AMM_PIANTAGIONI"]);
			BilancioAgricoloObj.RoSalari = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RO_SALARI"]);
			BilancioAgricoloObj.RoOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RO_ONERI"]);
			BilancioAgricoloObj.RnPacRicavi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_PAC_RICAVI"]);
			BilancioAgricoloObj.RnPacCosti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_PAC_COSTI"]);
			BilancioAgricoloObj.RnPacProventi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_PAC_PROVENTI"]);
			BilancioAgricoloObj.RnPacPerdite = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_PAC_PERDITE"]);
			BilancioAgricoloObj.RnPacInteressiAttivi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_PAC_INTERESSI_ATTIVI"]);
			BilancioAgricoloObj.RnPacInteressiPassivi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_PAC_INTERESSI_PASSIVI"]);
			BilancioAgricoloObj.RnPacImposte = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_PAC_IMPOSTE"]);
			BilancioAgricoloObj.RnPacContributiPac = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_PAC_CONTRIBUTI_PAC"]);
			BilancioAgricoloObj.MnlRedditiFam = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MNL_REDDITI_FAM"]);
			BilancioAgricoloObj.MnlRimborso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MNL_RIMBORSO"]);
			BilancioAgricoloObj.MnlPrelievi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MNL_PRELIEVI"]);
			BilancioAgricoloObj.CfCfTerreni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CF_CF_TERRENI"]);
			BilancioAgricoloObj.CfCfImpianti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CF_CF_IMPIANTI"]);
			BilancioAgricoloObj.CfCfPiantagioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CF_CF_PIANTAGIONI"]);
			BilancioAgricoloObj.CfCfMiglioramenti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CF_CF_MIGLIORAMENTI"]);
			BilancioAgricoloObj.CfCaMacchine = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CF_CA_MACCHINE"]);
			BilancioAgricoloObj.CfCaBestiame = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CF_CA_BESTIAME"]);
			BilancioAgricoloObj.CfIfPartecipazioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CF_IF_PARTECIPAZIONI"]);
			BilancioAgricoloObj.CcDfRimanenze = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CC_DF_RIMANENZE"]);
			BilancioAgricoloObj.CcDfAnticipazioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CC_DF_ANTICIPAZIONI"]);
			BilancioAgricoloObj.CcLdCrediti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CC_LD_CREDITI"]);
			BilancioAgricoloObj.CcLiBanca = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CC_LI_BANCA"]);
			BilancioAgricoloObj.CcLiCassa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CC_LI_CASSA"]);
			BilancioAgricoloObj.FfPcDebitiBreveTermine = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FF_PC_DEBITI_BREVE_TERMINE"]);
			BilancioAgricoloObj.FfPcFornitori = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FF_PC_FORNITORI"]);
			BilancioAgricoloObj.FfPcDebiti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FF_PC_DEBITI"]);
			BilancioAgricoloObj.FfPcMutui = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FF_PC_MUTUI"]);
			BilancioAgricoloObj.FfMpCapitale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FF_MP_CAPITALE"]);
			BilancioAgricoloObj.FfMpRiserve = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FF_MP_RISERVE"]);
			BilancioAgricoloObj.FfMpUtile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FF_MP_UTILE"]);
			BilancioAgricoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BilancioAgricoloObj.IsDirty = false;
			BilancioAgricoloObj.IsPersistent = true;
			return BilancioAgricoloObj;
		}

		//Find Select

		public static BilancioAgricoloCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBilancioAgricoloEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataBilancioEqualThis, SiarLibrary.NullTypes.BoolNT PrevisionaleEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.DecimalNT PlvRicaviNettiEqualThis, SiarLibrary.NullTypes.DecimalNT PlvRicaviAttivitaEqualThis, 
SiarLibrary.NullTypes.DecimalNT PlvRimanenzeFinaliEqualThis, SiarLibrary.NullTypes.DecimalNT PlvRimanenzeInizialiEqualThis, SiarLibrary.NullTypes.DecimalNT VaCostiMatPrimeEqualThis, 
SiarLibrary.NullTypes.DecimalNT VaCostiAttConnesseEqualThis, SiarLibrary.NullTypes.DecimalNT VaNoleggiEqualThis, SiarLibrary.NullTypes.DecimalNT VaManutenzioniEqualThis, 
SiarLibrary.NullTypes.DecimalNT VaSpeseGeneraliEqualThis, SiarLibrary.NullTypes.DecimalNT VaAffittiEqualThis, SiarLibrary.NullTypes.DecimalNT VaAltriCostiEqualThis, 
SiarLibrary.NullTypes.DecimalNT PnAmmMacchineEqualThis, SiarLibrary.NullTypes.DecimalNT PnAmmFabbricatiEqualThis, SiarLibrary.NullTypes.DecimalNT PnAmmPiantagioniEqualThis, 
SiarLibrary.NullTypes.DecimalNT RoSalariEqualThis, SiarLibrary.NullTypes.DecimalNT RoOneriEqualThis, SiarLibrary.NullTypes.DecimalNT RnPacRicaviEqualThis, 
SiarLibrary.NullTypes.DecimalNT RnPacCostiEqualThis, SiarLibrary.NullTypes.DecimalNT RnPacProventiEqualThis, SiarLibrary.NullTypes.DecimalNT RnPacPerditeEqualThis, 
SiarLibrary.NullTypes.DecimalNT RnPacInteressiAttiviEqualThis, SiarLibrary.NullTypes.DecimalNT RnPacInteressiPassiviEqualThis, SiarLibrary.NullTypes.DecimalNT RnPacImposteEqualThis, 
SiarLibrary.NullTypes.DecimalNT RnPacContributiPacEqualThis, SiarLibrary.NullTypes.DecimalNT MnlRedditiFamEqualThis, SiarLibrary.NullTypes.DecimalNT MnlRimborsoEqualThis, 
SiarLibrary.NullTypes.DecimalNT MnlPrelieviEqualThis, SiarLibrary.NullTypes.DecimalNT CfCfTerreniEqualThis, SiarLibrary.NullTypes.DecimalNT CfCfImpiantiEqualThis, 
SiarLibrary.NullTypes.DecimalNT CfCfPiantagioniEqualThis, SiarLibrary.NullTypes.DecimalNT CfCfMiglioramentiEqualThis, SiarLibrary.NullTypes.DecimalNT CfCaMacchineEqualThis, 
SiarLibrary.NullTypes.DecimalNT CfCaBestiameEqualThis, SiarLibrary.NullTypes.DecimalNT CfIfPartecipazioniEqualThis, SiarLibrary.NullTypes.DecimalNT CcDfRimanenzeEqualThis, 
SiarLibrary.NullTypes.DecimalNT CcDfAnticipazioniEqualThis, SiarLibrary.NullTypes.DecimalNT CcLdCreditiEqualThis, SiarLibrary.NullTypes.DecimalNT CcLiBancaEqualThis, 
SiarLibrary.NullTypes.DecimalNT CcLiCassaEqualThis, SiarLibrary.NullTypes.DecimalNT FfPcDebitiBreveTermineEqualThis, SiarLibrary.NullTypes.DecimalNT FfPcFornitoriEqualThis, 
SiarLibrary.NullTypes.DecimalNT FfPcDebitiEqualThis, SiarLibrary.NullTypes.DecimalNT FfPcMutuiEqualThis, SiarLibrary.NullTypes.DecimalNT FfMpCapitaleEqualThis, 
SiarLibrary.NullTypes.DecimalNT FfMpRiserveEqualThis, SiarLibrary.NullTypes.DecimalNT FfMpUtileEqualThis)

		{

			BilancioAgricoloCollection BilancioAgricoloCollectionObj = new BilancioAgricoloCollection();

			IDbCommand findCmd = db.InitCmd("Zbilancioagricolofindselect", new string[] {"IdBilancioAgricoloequalthis", "IdImpresaequalthis", "IdProgettoequalthis", 
"Annoequalthis", "DataBilancioequalthis", "Previsionaleequalthis", 
"DataModificaequalthis", "PlvRicaviNettiequalthis", "PlvRicaviAttivitaequalthis", 
"PlvRimanenzeFinaliequalthis", "PlvRimanenzeInizialiequalthis", "VaCostiMatPrimeequalthis", 
"VaCostiAttConnesseequalthis", "VaNoleggiequalthis", "VaManutenzioniequalthis", 
"VaSpeseGeneraliequalthis", "VaAffittiequalthis", "VaAltriCostiequalthis", 
"PnAmmMacchineequalthis", "PnAmmFabbricatiequalthis", "PnAmmPiantagioniequalthis", 
"RoSalariequalthis", "RoOneriequalthis", "RnPacRicaviequalthis", 
"RnPacCostiequalthis", "RnPacProventiequalthis", "RnPacPerditeequalthis", 
"RnPacInteressiAttiviequalthis", "RnPacInteressiPassiviequalthis", "RnPacImposteequalthis", 
"RnPacContributiPacequalthis", "MnlRedditiFamequalthis", "MnlRimborsoequalthis", 
"MnlPrelieviequalthis", "CfCfTerreniequalthis", "CfCfImpiantiequalthis", 
"CfCfPiantagioniequalthis", "CfCfMiglioramentiequalthis", "CfCaMacchineequalthis", 
"CfCaBestiameequalthis", "CfIfPartecipazioniequalthis", "CcDfRimanenzeequalthis", 
"CcDfAnticipazioniequalthis", "CcLdCreditiequalthis", "CcLiBancaequalthis", 
"CcLiCassaequalthis", "FfPcDebitiBreveTermineequalthis", "FfPcFornitoriequalthis", 
"FfPcDebitiequalthis", "FfPcMutuiequalthis", "FfMpCapitaleequalthis", 
"FfMpRiserveequalthis", "FfMpUtileequalthis"}, new string[] {"int", "int", "int", 
"int", "DateTime", "bool", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBilancioAgricoloequalthis", IdBilancioAgricoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataBilancioequalthis", DataBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Previsionaleequalthis", PrevisionaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvRicaviNettiequalthis", PlvRicaviNettiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvRicaviAttivitaequalthis", PlvRicaviAttivitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvRimanenzeFinaliequalthis", PlvRimanenzeFinaliEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvRimanenzeInizialiequalthis", PlvRimanenzeInizialiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "VaCostiMatPrimeequalthis", VaCostiMatPrimeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "VaCostiAttConnesseequalthis", VaCostiAttConnesseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "VaNoleggiequalthis", VaNoleggiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "VaManutenzioniequalthis", VaManutenzioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "VaSpeseGeneraliequalthis", VaSpeseGeneraliEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "VaAffittiequalthis", VaAffittiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "VaAltriCostiequalthis", VaAltriCostiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PnAmmMacchineequalthis", PnAmmMacchineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PnAmmFabbricatiequalthis", PnAmmFabbricatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PnAmmPiantagioniequalthis", PnAmmPiantagioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RoSalariequalthis", RoSalariEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RoOneriequalthis", RoOneriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnPacRicaviequalthis", RnPacRicaviEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnPacCostiequalthis", RnPacCostiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnPacProventiequalthis", RnPacProventiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnPacPerditeequalthis", RnPacPerditeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnPacInteressiAttiviequalthis", RnPacInteressiAttiviEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnPacInteressiPassiviequalthis", RnPacInteressiPassiviEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnPacImposteequalthis", RnPacImposteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnPacContributiPacequalthis", RnPacContributiPacEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MnlRedditiFamequalthis", MnlRedditiFamEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MnlRimborsoequalthis", MnlRimborsoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MnlPrelieviequalthis", MnlPrelieviEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfCfTerreniequalthis", CfCfTerreniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfCfImpiantiequalthis", CfCfImpiantiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfCfPiantagioniequalthis", CfCfPiantagioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfCfMiglioramentiequalthis", CfCfMiglioramentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfCaMacchineequalthis", CfCaMacchineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfCaBestiameequalthis", CfCaBestiameEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfIfPartecipazioniequalthis", CfIfPartecipazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CcDfRimanenzeequalthis", CcDfRimanenzeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CcDfAnticipazioniequalthis", CcDfAnticipazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CcLdCreditiequalthis", CcLdCreditiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CcLiBancaequalthis", CcLiBancaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CcLiCassaequalthis", CcLiCassaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FfPcDebitiBreveTermineequalthis", FfPcDebitiBreveTermineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FfPcFornitoriequalthis", FfPcFornitoriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FfPcDebitiequalthis", FfPcDebitiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FfPcMutuiequalthis", FfPcMutuiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FfMpCapitaleequalthis", FfMpCapitaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FfMpRiserveequalthis", FfMpRiserveEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FfMpUtileequalthis", FfMpUtileEqualThis);
			BilancioAgricolo BilancioAgricoloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BilancioAgricoloObj = GetFromDatareader(db);
				BilancioAgricoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioAgricoloObj.IsDirty = false;
				BilancioAgricoloObj.IsPersistent = true;
				BilancioAgricoloCollectionObj.Add(BilancioAgricoloObj);
			}
			db.Close();
			return BilancioAgricoloCollectionObj;
		}

		//Find Find

		public static BilancioAgricoloCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBilancioAgricoloEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataBilancioEqualThis, SiarLibrary.NullTypes.BoolNT PrevisionaleEqualThis)

		{

			BilancioAgricoloCollection BilancioAgricoloCollectionObj = new BilancioAgricoloCollection();

			IDbCommand findCmd = db.InitCmd("Zbilancioagricolofindfind", new string[] {"IdBilancioAgricoloequalthis", "IdImpresaequalthis", "IdProgettoequalthis", 
"Annoequalthis", "DataBilancioequalthis", "Previsionaleequalthis"}, new string[] {"int", "int", "int", 
"int", "DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBilancioAgricoloequalthis", IdBilancioAgricoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataBilancioequalthis", DataBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Previsionaleequalthis", PrevisionaleEqualThis);
			BilancioAgricolo BilancioAgricoloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BilancioAgricoloObj = GetFromDatareader(db);
				BilancioAgricoloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioAgricoloObj.IsDirty = false;
				BilancioAgricoloObj.IsPersistent = true;
				BilancioAgricoloCollectionObj.Add(BilancioAgricoloObj);
			}
			db.Close();
			return BilancioAgricoloCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_AGRICOLO>
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
      <ID_BILANCIO_AGRICOLO>Equal</ID_BILANCIO_AGRICOLO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ANNO>Equal</ANNO>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <PREVISIONALE>Equal</PREVISIONALE>
    </Find>
  </Finds>
  <Filters>
    <FiltroPrevisionale>
      <PREVISIONALE>Equal</PREVISIONALE>
    </FiltroPrevisionale>
    <FiltroDataModifica>
      <DATA_MODIFICA>EqLessThan</DATA_MODIFICA>
    </FiltroDataModifica>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BILANCIO_AGRICOLO>
*/