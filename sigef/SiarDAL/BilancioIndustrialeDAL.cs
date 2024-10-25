using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BilancioIndustrialeDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class BilancioIndustrialeDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BilancioIndustriale BilancioIndustrialeObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdBilancioIndustriale", BilancioIndustrialeObj.IdBilancioIndustriale);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", BilancioIndustrialeObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", BilancioIndustrialeObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", BilancioIndustrialeObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "DataBilancio", BilancioIndustrialeObj.DataBilancio);
			DbProvider.SetCmdParam(cmd,firstChar + "Previsionale", BilancioIndustrialeObj.Previsionale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", BilancioIndustrialeObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvRicaviVendita", BilancioIndustrialeObj.PlvRicaviVendita);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvAltriRicavi", BilancioIndustrialeObj.PlvAltriRicavi);
			DbProvider.SetCmdParam(cmd,firstChar + "CpMateriePrime", BilancioIndustrialeObj.CpMateriePrime);
			DbProvider.SetCmdParam(cmd,firstChar + "CpServizi", BilancioIndustrialeObj.CpServizi);
			DbProvider.SetCmdParam(cmd,firstChar + "CpBeniTerzi", BilancioIndustrialeObj.CpBeniTerzi);
			DbProvider.SetCmdParam(cmd,firstChar + "CpPersonale", BilancioIndustrialeObj.CpPersonale);
			DbProvider.SetCmdParam(cmd,firstChar + "CpAmmSvalutazioni", BilancioIndustrialeObj.CpAmmSvalutazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "CpVarRimanenze", BilancioIndustrialeObj.CpVarRimanenze);
			DbProvider.SetCmdParam(cmd,firstChar + "CpOneri", BilancioIndustrialeObj.CpOneri);
			DbProvider.SetCmdParam(cmd,firstChar + "PofAltriProventi", BilancioIndustrialeObj.PofAltriProventi);
			DbProvider.SetCmdParam(cmd,firstChar + "PofInteressiOneri", BilancioIndustrialeObj.PofInteressiOneri);
			DbProvider.SetCmdParam(cmd,firstChar + "RettValAttFinanziarie", BilancioIndustrialeObj.RettValAttFinanziarie);
			DbProvider.SetCmdParam(cmd,firstChar + "PosProventiStraord", BilancioIndustrialeObj.PosProventiStraord);
			DbProvider.SetCmdParam(cmd,firstChar + "PosOneriStraord", BilancioIndustrialeObj.PosOneriStraord);
			DbProvider.SetCmdParam(cmd,firstChar + "TotPrimaImposte", BilancioIndustrialeObj.TotPrimaImposte);
			DbProvider.SetCmdParam(cmd,firstChar + "ImposteReddito", BilancioIndustrialeObj.ImposteReddito);
			DbProvider.SetCmdParam(cmd,firstChar + "TaCreditiSoci", BilancioIndustrialeObj.TaCreditiSoci);
			DbProvider.SetCmdParam(cmd,firstChar + "TaImmImmateriali", BilancioIndustrialeObj.TaImmImmateriali);
			DbProvider.SetCmdParam(cmd,firstChar + "TaImmobMateriali", BilancioIndustrialeObj.TaImmobMateriali);
			DbProvider.SetCmdParam(cmd,firstChar + "TaImmPartecipazioni", BilancioIndustrialeObj.TaImmPartecipazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "TaImmCrediti", BilancioIndustrialeObj.TaImmCrediti);
			DbProvider.SetCmdParam(cmd,firstChar + "TaAcRimanenze", BilancioIndustrialeObj.TaAcRimanenze);
			DbProvider.SetCmdParam(cmd,firstChar + "TaAcCreditiClienti", BilancioIndustrialeObj.TaAcCreditiClienti);
			DbProvider.SetCmdParam(cmd,firstChar + "TaAcCreditiAltri", BilancioIndustrialeObj.TaAcCreditiAltri);
			DbProvider.SetCmdParam(cmd,firstChar + "TaAcDepPostali", BilancioIndustrialeObj.TaAcDepPostali);
			DbProvider.SetCmdParam(cmd,firstChar + "TaAcDispoLiquide", BilancioIndustrialeObj.TaAcDispoLiquide);
			DbProvider.SetCmdParam(cmd,firstChar + "TaRateiRisconti", BilancioIndustrialeObj.TaRateiRisconti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnCapitale", BilancioIndustrialeObj.TpPnCapitale);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnSovrapAzioni", BilancioIndustrialeObj.TpPnSovrapAzioni);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnRisRivalutazione", BilancioIndustrialeObj.TpPnRisRivalutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnRisLegale", BilancioIndustrialeObj.TpPnRisLegale);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnAzioniProprie", BilancioIndustrialeObj.TpPnAzioniProprie);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnRiserva904", BilancioIndustrialeObj.TpPnRiserva904);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnRiserveStatutarie", BilancioIndustrialeObj.TpPnRiserveStatutarie);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnAltreRiserve", BilancioIndustrialeObj.TpPnAltreRiserve);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnUtiliPrecedenti", BilancioIndustrialeObj.TpPnUtiliPrecedenti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPnUtiliEsercizio", BilancioIndustrialeObj.TpPnUtiliEsercizio);
			DbProvider.SetCmdParam(cmd,firstChar + "TpFondiRischiOneri", BilancioIndustrialeObj.TpFondiRischiOneri);
			DbProvider.SetCmdParam(cmd,firstChar + "TpFineRapporto", BilancioIndustrialeObj.TpFineRapporto);
			DbProvider.SetCmdParam(cmd,firstChar + "TpDebitiBanche", BilancioIndustrialeObj.TpDebitiBanche);
			DbProvider.SetCmdParam(cmd,firstChar + "TpDebitiFinanziatori", BilancioIndustrialeObj.TpDebitiFinanziatori);
			DbProvider.SetCmdParam(cmd,firstChar + "TpDebitiFornitori", BilancioIndustrialeObj.TpDebitiFornitori);
			DbProvider.SetCmdParam(cmd,firstChar + "TpDebitiIstPrevid", BilancioIndustrialeObj.TpDebitiIstPrevid);
			DbProvider.SetCmdParam(cmd,firstChar + "TpAltriDebiti", BilancioIndustrialeObj.TpAltriDebiti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpRateiRisconti", BilancioIndustrialeObj.TpRateiRisconti);
            DbProvider.SetCmdParam(cmd, firstChar + "NotaIntegrativa", BilancioIndustrialeObj.NotaIntegrativa);
		}
		//Insert
		private static int Insert(DbProvider db, BilancioIndustriale BilancioIndustrialeObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBilancioIndustrialeInsert", new string[] {"IdImpresa", "IdProgetto", 
"Anno", "DataBilancio", "Previsionale", 
"DataModifica", "PlvRicaviVendita", "PlvAltriRicavi", 
"CpMateriePrime", "CpServizi", "CpBeniTerzi", 
"CpPersonale", "CpAmmSvalutazioni", "CpVarRimanenze", 
"CpOneri", "PofAltriProventi", "PofInteressiOneri", 
"RettValAttFinanziarie", "PosProventiStraord", "PosOneriStraord", 
"TotPrimaImposte", "ImposteReddito", "TaCreditiSoci", 
"TaImmImmateriali", "TaImmobMateriali", "TaImmPartecipazioni", 
"TaImmCrediti", "TaAcRimanenze", "TaAcCreditiClienti", 
"TaAcCreditiAltri", "TaAcDepPostali", "TaAcDispoLiquide", 
"TaRateiRisconti", "TpPnCapitale", "TpPnSovrapAzioni", 
"TpPnRisRivalutazione", "TpPnRisLegale", "TpPnAzioniProprie", 
"TpPnRiserva904", "TpPnRiserveStatutarie", "TpPnAltreRiserve", 
"TpPnUtiliPrecedenti", "TpPnUtiliEsercizio", "TpFondiRischiOneri", 
"TpFineRapporto", "TpDebitiBanche", "TpDebitiFinanziatori", 
"TpDebitiFornitori", "TpDebitiIstPrevid", "TpAltriDebiti", 
"TpRateiRisconti","NotaIntegrativa"}, new string[] {"int", "int", 
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
"decimal","string"},"");
				CompileIUCmd(false, insertCmd,BilancioIndustrialeObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BilancioIndustrialeObj.IdBilancioIndustriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO_INDUSTRIALE"]);
				}
				BilancioIndustrialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioIndustrialeObj.IsDirty = false;
				BilancioIndustrialeObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BilancioIndustriale BilancioIndustrialeObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBilancioIndustrialeUpdate", new string[] {"IdBilancioIndustriale", "IdImpresa", "IdProgetto", 
"Anno", "DataBilancio", "Previsionale", 
"DataModifica", "PlvRicaviVendita", "PlvAltriRicavi", 
"CpMateriePrime", "CpServizi", "CpBeniTerzi", 
"CpPersonale", "CpAmmSvalutazioni", "CpVarRimanenze", 
"CpOneri", "PofAltriProventi", "PofInteressiOneri", 
"RettValAttFinanziarie", "PosProventiStraord", "PosOneriStraord", 
"TotPrimaImposte", "ImposteReddito", "TaCreditiSoci", 
"TaImmImmateriali", "TaImmobMateriali", "TaImmPartecipazioni", 
"TaImmCrediti", "TaAcRimanenze", "TaAcCreditiClienti", 
"TaAcCreditiAltri", "TaAcDepPostali", "TaAcDispoLiquide", 
"TaRateiRisconti", "TpPnCapitale", "TpPnSovrapAzioni", 
"TpPnRisRivalutazione", "TpPnRisLegale", "TpPnAzioniProprie", 
"TpPnRiserva904", "TpPnRiserveStatutarie", "TpPnAltreRiserve", 
"TpPnUtiliPrecedenti", "TpPnUtiliEsercizio", "TpFondiRischiOneri", 
"TpFineRapporto", "TpDebitiBanche", "TpDebitiFinanziatori", 
"TpDebitiFornitori", "TpDebitiIstPrevid", "TpAltriDebiti", 
"TpRateiRisconti","NotaIntegrativa"}, new string[] {"int", "int", "int", 
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
"decimal","string"},"");
				CompileIUCmd(true, updateCmd,BilancioIndustrialeObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					BilancioIndustrialeObj.DataModifica = d;
				}
				BilancioIndustrialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioIndustrialeObj.IsDirty = false;
				BilancioIndustrialeObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BilancioIndustriale BilancioIndustrialeObj)
		{
			switch (BilancioIndustrialeObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BilancioIndustrialeObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BilancioIndustrialeObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BilancioIndustrialeObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BilancioIndustrialeCollection BilancioIndustrialeCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBilancioIndustrialeUpdate", new string[] {"IdBilancioIndustriale", "IdImpresa", "IdProgetto", 
"Anno", "DataBilancio", "Previsionale", 
"DataModifica", "PlvRicaviVendita", "PlvAltriRicavi", 
"CpMateriePrime", "CpServizi", "CpBeniTerzi", 
"CpPersonale", "CpAmmSvalutazioni", "CpVarRimanenze", 
"CpOneri", "PofAltriProventi", "PofInteressiOneri", 
"RettValAttFinanziarie", "PosProventiStraord", "PosOneriStraord", 
"TotPrimaImposte", "ImposteReddito", "TaCreditiSoci", 
"TaImmImmateriali", "TaImmobMateriali", "TaImmPartecipazioni", 
"TaImmCrediti", "TaAcRimanenze", "TaAcCreditiClienti", 
"TaAcCreditiAltri", "TaAcDepPostali", "TaAcDispoLiquide", 
"TaRateiRisconti", "TpPnCapitale", "TpPnSovrapAzioni", 
"TpPnRisRivalutazione", "TpPnRisLegale", "TpPnAzioniProprie", 
"TpPnRiserva904", "TpPnRiserveStatutarie", "TpPnAltreRiserve", 
"TpPnUtiliPrecedenti", "TpPnUtiliEsercizio", "TpFondiRischiOneri", 
"TpFineRapporto", "TpDebitiBanche", "TpDebitiFinanziatori", 
"TpDebitiFornitori", "TpDebitiIstPrevid", "TpAltriDebiti", 
"TpRateiRisconti","NotaIntegrativa"}, new string[] {"int", "int", "int", 
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
"decimal","string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBilancioIndustrialeInsert", new string[] {"IdImpresa", "IdProgetto", 
"Anno", "DataBilancio", "Previsionale", 
"DataModifica", "PlvRicaviVendita", "PlvAltriRicavi", 
"CpMateriePrime", "CpServizi", "CpBeniTerzi", 
"CpPersonale", "CpAmmSvalutazioni", "CpVarRimanenze", 
"CpOneri", "PofAltriProventi", "PofInteressiOneri", 
"RettValAttFinanziarie", "PosProventiStraord", "PosOneriStraord", 
"TotPrimaImposte", "ImposteReddito", "TaCreditiSoci", 
"TaImmImmateriali", "TaImmobMateriali", "TaImmPartecipazioni", 
"TaImmCrediti", "TaAcRimanenze", "TaAcCreditiClienti", 
"TaAcCreditiAltri", "TaAcDepPostali", "TaAcDispoLiquide", 
"TaRateiRisconti", "TpPnCapitale", "TpPnSovrapAzioni", 
"TpPnRisRivalutazione", "TpPnRisLegale", "TpPnAzioniProprie", 
"TpPnRiserva904", "TpPnRiserveStatutarie", "TpPnAltreRiserve", 
"TpPnUtiliPrecedenti", "TpPnUtiliEsercizio", "TpFondiRischiOneri", 
"TpFineRapporto", "TpDebitiBanche", "TpDebitiFinanziatori", 
"TpDebitiFornitori", "TpDebitiIstPrevid", "TpAltriDebiti", 
"TpRateiRisconti","NotaIntegrativa"}, new string[] {"int", "int", 
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
"decimal","string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioIndustrialeDelete", new string[] {"IdBilancioIndustriale"}, new string[] {"int"},"");
				for (int i = 0; i < BilancioIndustrialeCollectionObj.Count; i++)
				{
					switch (BilancioIndustrialeCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BilancioIndustrialeCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BilancioIndustrialeCollectionObj[i].IdBilancioIndustriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO_INDUSTRIALE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BilancioIndustrialeCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									BilancioIndustrialeCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BilancioIndustrialeCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancioIndustriale", (SiarLibrary.NullTypes.IntNT)BilancioIndustrialeCollectionObj[i].IdBilancioIndustriale);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BilancioIndustrialeCollectionObj.Count; i++)
				{
					if ((BilancioIndustrialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BilancioIndustrialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BilancioIndustrialeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BilancioIndustrialeCollectionObj[i].IsDirty = false;
						BilancioIndustrialeCollectionObj[i].IsPersistent = true;
					}
					if ((BilancioIndustrialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BilancioIndustrialeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BilancioIndustrialeCollectionObj[i].IsDirty = false;
						BilancioIndustrialeCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BilancioIndustriale BilancioIndustrialeObj)
		{
			int returnValue = 0;
			if (BilancioIndustrialeObj.IsPersistent) 
			{
				returnValue = Delete(db, BilancioIndustrialeObj.IdBilancioIndustriale);
			}
			BilancioIndustrialeObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BilancioIndustrialeObj.IsDirty = false;
			BilancioIndustrialeObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBilancioIndustrialeValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioIndustrialeDelete", new string[] {"IdBilancioIndustriale"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancioIndustriale", (SiarLibrary.NullTypes.IntNT)IdBilancioIndustrialeValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BilancioIndustrialeCollection BilancioIndustrialeCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioIndustrialeDelete", new string[] {"IdBilancioIndustriale"}, new string[] {"int"},"");
				for (int i = 0; i < BilancioIndustrialeCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancioIndustriale", BilancioIndustrialeCollectionObj[i].IdBilancioIndustriale);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BilancioIndustrialeCollectionObj.Count; i++)
				{
					if ((BilancioIndustrialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BilancioIndustrialeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BilancioIndustrialeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BilancioIndustrialeCollectionObj[i].IsDirty = false;
						BilancioIndustrialeCollectionObj[i].IsPersistent = false;
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
		public static BilancioIndustriale GetById(DbProvider db, int IdBilancioIndustrialeValue)
		{
			BilancioIndustriale BilancioIndustrialeObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBilancioIndustrialeGetById", new string[] {"IdBilancioIndustriale"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBilancioIndustriale", (SiarLibrary.NullTypes.IntNT)IdBilancioIndustrialeValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BilancioIndustrialeObj = GetFromDatareader(db);
				BilancioIndustrialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioIndustrialeObj.IsDirty = false;
				BilancioIndustrialeObj.IsPersistent = true;
			}
			db.Close();
			return BilancioIndustrialeObj;
		}

		//getFromDatareader
		public static BilancioIndustriale GetFromDatareader(DbProvider db)
		{
			BilancioIndustriale BilancioIndustrialeObj = new BilancioIndustriale();
			BilancioIndustrialeObj.IdBilancioIndustriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO_INDUSTRIALE"]);
			BilancioIndustrialeObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			BilancioIndustrialeObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			BilancioIndustrialeObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			BilancioIndustrialeObj.DataBilancio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_BILANCIO"]);
			BilancioIndustrialeObj.Previsionale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREVISIONALE"]);
			BilancioIndustrialeObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			BilancioIndustrialeObj.PlvRicaviVendita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_RICAVI_VENDITA"]);
			BilancioIndustrialeObj.PlvAltriRicavi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_ALTRI_RICAVI"]);
			BilancioIndustrialeObj.CpMateriePrime = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CP_MATERIE_PRIME"]);
			BilancioIndustrialeObj.CpServizi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CP_SERVIZI"]);
			BilancioIndustrialeObj.CpBeniTerzi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CP_BENI_TERZI"]);
			BilancioIndustrialeObj.CpPersonale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CP_PERSONALE"]);
			BilancioIndustrialeObj.CpAmmSvalutazioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CP_AMM_SVALUTAZIONI"]);
			BilancioIndustrialeObj.CpVarRimanenze = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CP_VAR_RIMANENZE"]);
			BilancioIndustrialeObj.CpOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CP_ONERI"]);
			BilancioIndustrialeObj.PofAltriProventi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["POF_ALTRI_PROVENTI"]);
			BilancioIndustrialeObj.PofInteressiOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["POF_INTERESSI_ONERI"]);
			BilancioIndustrialeObj.RettValAttFinanziarie = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RETT_VAL_ATT_FINANZIARIE"]);
			BilancioIndustrialeObj.PosProventiStraord = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["POS_PROVENTI_STRAORD"]);
			BilancioIndustrialeObj.PosOneriStraord = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["POS_ONERI_STRAORD"]);
			BilancioIndustrialeObj.TotPrimaImposte = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_PRIMA_IMPOSTE"]);
			BilancioIndustrialeObj.ImposteReddito = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPOSTE_REDDITO"]);
			BilancioIndustrialeObj.TaCreditiSoci = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_CREDITI_SOCI"]);
			BilancioIndustrialeObj.TaImmImmateriali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_IMM_IMMATERIALI"]);
			BilancioIndustrialeObj.TaImmobMateriali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_IMMOB_MATERIALI"]);
			BilancioIndustrialeObj.TaImmPartecipazioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_IMM_PARTECIPAZIONI"]);
			BilancioIndustrialeObj.TaImmCrediti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_IMM_CREDITI"]);
			BilancioIndustrialeObj.TaAcRimanenze = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_AC_RIMANENZE"]);
			BilancioIndustrialeObj.TaAcCreditiClienti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_AC_CREDITI_CLIENTI"]);
			BilancioIndustrialeObj.TaAcCreditiAltri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_AC_CREDITI_ALTRI"]);
			BilancioIndustrialeObj.TaAcDepPostali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_AC_DEP_POSTALI"]);
			BilancioIndustrialeObj.TaAcDispoLiquide = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_AC_DISPO_LIQUIDE"]);
			BilancioIndustrialeObj.TaRateiRisconti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_RATEI_RISCONTI"]);
			BilancioIndustrialeObj.TpPnCapitale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_CAPITALE"]);
			BilancioIndustrialeObj.TpPnSovrapAzioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_SOVRAP_AZIONI"]);
			BilancioIndustrialeObj.TpPnRisRivalutazione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_RIS_RIVALUTAZIONE"]);
			BilancioIndustrialeObj.TpPnRisLegale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_RIS_LEGALE"]);
			BilancioIndustrialeObj.TpPnAzioniProprie = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_AZIONI_PROPRIE"]);
			BilancioIndustrialeObj.TpPnRiserva904 = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_RISERVA_904"]);
			BilancioIndustrialeObj.TpPnRiserveStatutarie = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_RISERVE_STATUTARIE"]);
			BilancioIndustrialeObj.TpPnAltreRiserve = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_ALTRE_RISERVE"]);
			BilancioIndustrialeObj.TpPnUtiliPrecedenti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_UTILI_PRECEDENTI"]);
			BilancioIndustrialeObj.TpPnUtiliEsercizio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PN_UTILI_ESERCIZIO"]);
			BilancioIndustrialeObj.TpFondiRischiOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_FONDI_RISCHI_ONERI"]);
			BilancioIndustrialeObj.TpFineRapporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_FINE_RAPPORTO"]);
			BilancioIndustrialeObj.TpDebitiBanche = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_DEBITI_BANCHE"]);
			BilancioIndustrialeObj.TpDebitiFinanziatori = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_DEBITI_FINANZIATORI"]);
			BilancioIndustrialeObj.TpDebitiFornitori = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_DEBITI_FORNITORI"]);
			BilancioIndustrialeObj.TpDebitiIstPrevid = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_DEBITI_IST_PREVID"]);
			BilancioIndustrialeObj.TpAltriDebiti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_ALTRI_DEBITI"]);
			BilancioIndustrialeObj.TpRateiRisconti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_RATEI_RISCONTI"]);
            BilancioIndustrialeObj.NotaIntegrativa = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTA_INTEGRATIVA"]);
			BilancioIndustrialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BilancioIndustrialeObj.IsDirty = false;
			BilancioIndustrialeObj.IsPersistent = true;
			return BilancioIndustrialeObj;
		}

		//Find Select

		public static BilancioIndustrialeCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBilancioIndustrialeEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataBilancioEqualThis, SiarLibrary.NullTypes.BoolNT PrevisionaleEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.DecimalNT PlvRicaviVenditaEqualThis, SiarLibrary.NullTypes.DecimalNT PlvAltriRicaviEqualThis, 
SiarLibrary.NullTypes.DecimalNT CpMateriePrimeEqualThis, SiarLibrary.NullTypes.DecimalNT CpServiziEqualThis, SiarLibrary.NullTypes.DecimalNT CpBeniTerziEqualThis, 
SiarLibrary.NullTypes.DecimalNT CpPersonaleEqualThis, SiarLibrary.NullTypes.DecimalNT CpAmmSvalutazioniEqualThis, SiarLibrary.NullTypes.DecimalNT CpVarRimanenzeEqualThis, 
SiarLibrary.NullTypes.DecimalNT CpOneriEqualThis, SiarLibrary.NullTypes.DecimalNT PofAltriProventiEqualThis, SiarLibrary.NullTypes.DecimalNT PofInteressiOneriEqualThis, 
SiarLibrary.NullTypes.DecimalNT RettValAttFinanziarieEqualThis, SiarLibrary.NullTypes.DecimalNT PosProventiStraordEqualThis, SiarLibrary.NullTypes.DecimalNT PosOneriStraordEqualThis, 
SiarLibrary.NullTypes.DecimalNT TotPrimaImposteEqualThis, SiarLibrary.NullTypes.DecimalNT ImposteRedditoEqualThis, SiarLibrary.NullTypes.DecimalNT TaCreditiSociEqualThis, 
SiarLibrary.NullTypes.DecimalNT TaImmImmaterialiEqualThis, SiarLibrary.NullTypes.DecimalNT TaImmobMaterialiEqualThis, SiarLibrary.NullTypes.DecimalNT TaImmPartecipazioniEqualThis, 
SiarLibrary.NullTypes.DecimalNT TaImmCreditiEqualThis, SiarLibrary.NullTypes.DecimalNT TaAcRimanenzeEqualThis, SiarLibrary.NullTypes.DecimalNT TaAcCreditiClientiEqualThis, 
SiarLibrary.NullTypes.DecimalNT TaAcCreditiAltriEqualThis, SiarLibrary.NullTypes.DecimalNT TaAcDepPostaliEqualThis, SiarLibrary.NullTypes.DecimalNT TaAcDispoLiquideEqualThis, 
SiarLibrary.NullTypes.DecimalNT TaRateiRiscontiEqualThis, SiarLibrary.NullTypes.DecimalNT TpPnCapitaleEqualThis, SiarLibrary.NullTypes.DecimalNT TpPnSovrapAzioniEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpPnRisRivalutazioneEqualThis, SiarLibrary.NullTypes.DecimalNT TpPnRisLegaleEqualThis, SiarLibrary.NullTypes.DecimalNT TpPnAzioniProprieEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpPnRiserva904EqualThis, SiarLibrary.NullTypes.DecimalNT TpPnRiserveStatutarieEqualThis, SiarLibrary.NullTypes.DecimalNT TpPnAltreRiserveEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpPnUtiliPrecedentiEqualThis, SiarLibrary.NullTypes.DecimalNT TpPnUtiliEsercizioEqualThis, SiarLibrary.NullTypes.DecimalNT TpFondiRischiOneriEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpFineRapportoEqualThis, SiarLibrary.NullTypes.DecimalNT TpDebitiBancheEqualThis, SiarLibrary.NullTypes.DecimalNT TpDebitiFinanziatoriEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpDebitiFornitoriEqualThis, SiarLibrary.NullTypes.DecimalNT TpDebitiIstPrevidEqualThis, SiarLibrary.NullTypes.DecimalNT TpAltriDebitiEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpRateiRiscontiEqualThis)

		{

			BilancioIndustrialeCollection BilancioIndustrialeCollectionObj = new BilancioIndustrialeCollection();

			IDbCommand findCmd = db.InitCmd("Zbilancioindustrialefindselect", new string[] {"IdBilancioIndustrialeequalthis", "IdImpresaequalthis", "IdProgettoequalthis", 
"Annoequalthis", "DataBilancioequalthis", "Previsionaleequalthis", 
"DataModificaequalthis", "PlvRicaviVenditaequalthis", "PlvAltriRicaviequalthis", 
"CpMateriePrimeequalthis", "CpServiziequalthis", "CpBeniTerziequalthis", 
"CpPersonaleequalthis", "CpAmmSvalutazioniequalthis", "CpVarRimanenzeequalthis", 
"CpOneriequalthis", "PofAltriProventiequalthis", "PofInteressiOneriequalthis", 
"RettValAttFinanziarieequalthis", "PosProventiStraordequalthis", "PosOneriStraordequalthis", 
"TotPrimaImposteequalthis", "ImposteRedditoequalthis", "TaCreditiSociequalthis", 
"TaImmImmaterialiequalthis", "TaImmobMaterialiequalthis", "TaImmPartecipazioniequalthis", 
"TaImmCreditiequalthis", "TaAcRimanenzeequalthis", "TaAcCreditiClientiequalthis", 
"TaAcCreditiAltriequalthis", "TaAcDepPostaliequalthis", "TaAcDispoLiquideequalthis", 
"TaRateiRiscontiequalthis", "TpPnCapitaleequalthis", "TpPnSovrapAzioniequalthis", 
"TpPnRisRivalutazioneequalthis", "TpPnRisLegaleequalthis", "TpPnAzioniProprieequalthis", 
"TpPnRiserva904equalthis", "TpPnRiserveStatutarieequalthis", "TpPnAltreRiserveequalthis", 
"TpPnUtiliPrecedentiequalthis", "TpPnUtiliEsercizioequalthis", "TpFondiRischiOneriequalthis", 
"TpFineRapportoequalthis", "TpDebitiBancheequalthis", "TpDebitiFinanziatoriequalthis", 
"TpDebitiFornitoriequalthis", "TpDebitiIstPrevidequalthis", "TpAltriDebitiequalthis", 
"TpRateiRiscontiequalthis"}, new string[] {"int", "int", "int", 
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
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBilancioIndustrialeequalthis", IdBilancioIndustrialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataBilancioequalthis", DataBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Previsionaleequalthis", PrevisionaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvRicaviVenditaequalthis", PlvRicaviVenditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvAltriRicaviequalthis", PlvAltriRicaviEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CpMateriePrimeequalthis", CpMateriePrimeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CpServiziequalthis", CpServiziEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CpBeniTerziequalthis", CpBeniTerziEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CpPersonaleequalthis", CpPersonaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CpAmmSvalutazioniequalthis", CpAmmSvalutazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CpVarRimanenzeequalthis", CpVarRimanenzeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CpOneriequalthis", CpOneriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PofAltriProventiequalthis", PofAltriProventiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PofInteressiOneriequalthis", PofInteressiOneriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RettValAttFinanziarieequalthis", RettValAttFinanziarieEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PosProventiStraordequalthis", PosProventiStraordEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PosOneriStraordequalthis", PosOneriStraordEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TotPrimaImposteequalthis", TotPrimaImposteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImposteRedditoequalthis", ImposteRedditoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaCreditiSociequalthis", TaCreditiSociEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaImmImmaterialiequalthis", TaImmImmaterialiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaImmobMaterialiequalthis", TaImmobMaterialiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaImmPartecipazioniequalthis", TaImmPartecipazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaImmCreditiequalthis", TaImmCreditiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaAcRimanenzeequalthis", TaAcRimanenzeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaAcCreditiClientiequalthis", TaAcCreditiClientiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaAcCreditiAltriequalthis", TaAcCreditiAltriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaAcDepPostaliequalthis", TaAcDepPostaliEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaAcDispoLiquideequalthis", TaAcDispoLiquideEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaRateiRiscontiequalthis", TaRateiRiscontiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnCapitaleequalthis", TpPnCapitaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnSovrapAzioniequalthis", TpPnSovrapAzioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnRisRivalutazioneequalthis", TpPnRisRivalutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnRisLegaleequalthis", TpPnRisLegaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnAzioniProprieequalthis", TpPnAzioniProprieEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnRiserva904equalthis", TpPnRiserva904EqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnRiserveStatutarieequalthis", TpPnRiserveStatutarieEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnAltreRiserveequalthis", TpPnAltreRiserveEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnUtiliPrecedentiequalthis", TpPnUtiliPrecedentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPnUtiliEsercizioequalthis", TpPnUtiliEsercizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpFondiRischiOneriequalthis", TpFondiRischiOneriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpFineRapportoequalthis", TpFineRapportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpDebitiBancheequalthis", TpDebitiBancheEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpDebitiFinanziatoriequalthis", TpDebitiFinanziatoriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpDebitiFornitoriequalthis", TpDebitiFornitoriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpDebitiIstPrevidequalthis", TpDebitiIstPrevidEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpAltriDebitiequalthis", TpAltriDebitiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpRateiRiscontiequalthis", TpRateiRiscontiEqualThis);
			BilancioIndustriale BilancioIndustrialeObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BilancioIndustrialeObj = GetFromDatareader(db);
				BilancioIndustrialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioIndustrialeObj.IsDirty = false;
				BilancioIndustrialeObj.IsPersistent = true;
				BilancioIndustrialeCollectionObj.Add(BilancioIndustrialeObj);
			}
			db.Close();
			return BilancioIndustrialeCollectionObj;
		}

		//Find Find

		public static BilancioIndustrialeCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBilancioIndustrialeEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataBilancioEqualThis, SiarLibrary.NullTypes.BoolNT PrevisionaleEqualThis)

		{

			BilancioIndustrialeCollection BilancioIndustrialeCollectionObj = new BilancioIndustrialeCollection();

			IDbCommand findCmd = db.InitCmd("Zbilancioindustrialefindfind", new string[] {"IdBilancioIndustrialeequalthis", "IdImpresaequalthis", "IdProgettoequalthis", 
"Annoequalthis", "DataBilancioequalthis", "Previsionaleequalthis"}, new string[] {"int", "int", "int", 
"int", "DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBilancioIndustrialeequalthis", IdBilancioIndustrialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataBilancioequalthis", DataBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Previsionaleequalthis", PrevisionaleEqualThis);
			BilancioIndustriale BilancioIndustrialeObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BilancioIndustrialeObj = GetFromDatareader(db);
				BilancioIndustrialeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioIndustrialeObj.IsDirty = false;
				BilancioIndustrialeObj.IsPersistent = true;
				BilancioIndustrialeCollectionObj.Add(BilancioIndustrialeObj);
			}
			db.Close();
			return BilancioIndustrialeCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_INDUSTRIALE>
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
    <Find OrderBy="ORDER BY ANNO DESC">
      <ID_BILANCIO_INDUSTRIALE>Equal</ID_BILANCIO_INDUSTRIALE>
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
</BILANCIO_INDUSTRIALE>
*/