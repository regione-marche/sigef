using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BilancioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class BilancioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Bilancio BilancioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdBilancio", BilancioObj.IdBilancio);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", BilancioObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", BilancioObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "DataBilancio", BilancioObj.DataBilancio);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvRicaviNettiVendita", BilancioObj.PlvRicaviNettiVendita);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvAltriRicavi", BilancioObj.PlvAltriRicavi);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvVarRimanenze", BilancioObj.PlvVarRimanenze);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvVarLavoro", BilancioObj.PlvVarLavoro);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvIncrementi", BilancioObj.PlvIncrementi);
			DbProvider.SetCmdParam(cmd,firstChar + "RoCostiProduzione", BilancioObj.RoCostiProduzione);
			DbProvider.SetCmdParam(cmd,firstChar + "RpiProventi", BilancioObj.RpiProventi);
			DbProvider.SetCmdParam(cmd,firstChar + "RpiRettifiche", BilancioObj.RpiRettifiche);
			DbProvider.SetCmdParam(cmd,firstChar + "RpiProventiStraordinari", BilancioObj.RpiProventiStraordinari);
			DbProvider.SetCmdParam(cmd,firstChar + "RnImposte", BilancioObj.RnImposte);
			DbProvider.SetCmdParam(cmd,firstChar + "TaCrediti", BilancioObj.TaCrediti);
			DbProvider.SetCmdParam(cmd,firstChar + "TaImmobilizzazioni", BilancioObj.TaImmobilizzazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "TaAttivoCircolante", BilancioObj.TaAttivoCircolante);
			DbProvider.SetCmdParam(cmd,firstChar + "TaRatei", BilancioObj.TaRatei);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPatrimonio", BilancioObj.TpPatrimonio);
			DbProvider.SetCmdParam(cmd,firstChar + "TpFondi", BilancioObj.TpFondi);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtMutuiOrdinari", BilancioObj.TpLtMutuiOrdinari);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtMutuiAgevolati", BilancioObj.TpLtMutuiAgevolati);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtPrestiti", BilancioObj.TpLtPrestiti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtDebitiFornitori", BilancioObj.TpLtDebitiFornitori);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtDebitiBanche", BilancioObj.TpLtDebitiBanche);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtAltreScadenze", BilancioObj.TpLtAltreScadenze);
			DbProvider.SetCmdParam(cmd,firstChar + "TpDebitiFornitori", BilancioObj.TpDebitiFornitori);
			DbProvider.SetCmdParam(cmd,firstChar + "TpDebitiBanche", BilancioObj.TpDebitiBanche);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPrestitiSoci", BilancioObj.TpPrestitiSoci);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPrestiti", BilancioObj.TpPrestiti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpAltriDebiti", BilancioObj.TpAltriDebiti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpRatei", BilancioObj.TpRatei);
		}
		//Insert
		private static int Insert(DbProvider db, Bilancio BilancioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBilancioInsert", new string[] {"IdImpresa", "Anno", 
"DataBilancio", "PlvRicaviNettiVendita", "PlvAltriRicavi", 
"PlvVarRimanenze", "PlvVarLavoro", "PlvIncrementi", 
"RoCostiProduzione", "RpiProventi", "RpiRettifiche", 
"RpiProventiStraordinari", "RnImposte", "TaCrediti", 
"TaImmobilizzazioni", "TaAttivoCircolante", "TaRatei", 
"TpPatrimonio", "TpFondi", "TpLtMutuiOrdinari", 
"TpLtMutuiAgevolati", "TpLtPrestiti", "TpLtDebitiFornitori", 
"TpLtDebitiBanche", "TpLtAltreScadenze", "TpDebitiFornitori", 
"TpDebitiBanche", "TpPrestitiSoci", "TpPrestiti", 
"TpAltriDebiti", "TpRatei"}, new string[] {"int", "int", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");
				CompileIUCmd(false, insertCmd,BilancioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BilancioObj.IdBilancio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO"]);
				}
				BilancioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioObj.IsDirty = false;
				BilancioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Bilancio BilancioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBilancioUpdate", new string[] {"IdBilancio", "IdImpresa", "Anno", 
"DataBilancio", "PlvRicaviNettiVendita", "PlvAltriRicavi", 
"PlvVarRimanenze", "PlvVarLavoro", "PlvIncrementi", 
"RoCostiProduzione", "RpiProventi", "RpiRettifiche", 
"RpiProventiStraordinari", "RnImposte", "TaCrediti", 
"TaImmobilizzazioni", "TaAttivoCircolante", "TaRatei", 
"TpPatrimonio", "TpFondi", "TpLtMutuiOrdinari", 
"TpLtMutuiAgevolati", "TpLtPrestiti", "TpLtDebitiFornitori", 
"TpLtDebitiBanche", "TpLtAltreScadenze", "TpDebitiFornitori", 
"TpDebitiBanche", "TpPrestitiSoci", "TpPrestiti", 
"TpAltriDebiti", "TpRatei"}, new string[] {"int", "int", "int", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");
				CompileIUCmd(true, updateCmd,BilancioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BilancioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioObj.IsDirty = false;
				BilancioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Bilancio BilancioObj)
		{
			switch (BilancioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BilancioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BilancioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BilancioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BilancioCollection BilancioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBilancioUpdate", new string[] {"IdBilancio", "IdImpresa", "Anno", 
"DataBilancio", "PlvRicaviNettiVendita", "PlvAltriRicavi", 
"PlvVarRimanenze", "PlvVarLavoro", "PlvIncrementi", 
"RoCostiProduzione", "RpiProventi", "RpiRettifiche", 
"RpiProventiStraordinari", "RnImposte", "TaCrediti", 
"TaImmobilizzazioni", "TaAttivoCircolante", "TaRatei", 
"TpPatrimonio", "TpFondi", "TpLtMutuiOrdinari", 
"TpLtMutuiAgevolati", "TpLtPrestiti", "TpLtDebitiFornitori", 
"TpLtDebitiBanche", "TpLtAltreScadenze", "TpDebitiFornitori", 
"TpDebitiBanche", "TpPrestitiSoci", "TpPrestiti", 
"TpAltriDebiti", "TpRatei"}, new string[] {"int", "int", "int", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBilancioInsert", new string[] {"IdImpresa", "Anno", 
"DataBilancio", "PlvRicaviNettiVendita", "PlvAltriRicavi", 
"PlvVarRimanenze", "PlvVarLavoro", "PlvIncrementi", 
"RoCostiProduzione", "RpiProventi", "RpiRettifiche", 
"RpiProventiStraordinari", "RnImposte", "TaCrediti", 
"TaImmobilizzazioni", "TaAttivoCircolante", "TaRatei", 
"TpPatrimonio", "TpFondi", "TpLtMutuiOrdinari", 
"TpLtMutuiAgevolati", "TpLtPrestiti", "TpLtDebitiFornitori", 
"TpLtDebitiBanche", "TpLtAltreScadenze", "TpDebitiFornitori", 
"TpDebitiBanche", "TpPrestitiSoci", "TpPrestiti", 
"TpAltriDebiti", "TpRatei"}, new string[] {"int", "int", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioDelete", new string[] {"IdBilancio"}, new string[] {"int"},"");
				for (int i = 0; i < BilancioCollectionObj.Count; i++)
				{
					switch (BilancioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BilancioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BilancioCollectionObj[i].IdBilancio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BilancioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BilancioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancio", (SiarLibrary.NullTypes.IntNT)BilancioCollectionObj[i].IdBilancio);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BilancioCollectionObj.Count; i++)
				{
					if ((BilancioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BilancioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BilancioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BilancioCollectionObj[i].IsDirty = false;
						BilancioCollectionObj[i].IsPersistent = true;
					}
					if ((BilancioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BilancioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BilancioCollectionObj[i].IsDirty = false;
						BilancioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Bilancio BilancioObj)
		{
			int returnValue = 0;
			if (BilancioObj.IsPersistent) 
			{
				returnValue = Delete(db, BilancioObj.IdBilancio);
			}
			BilancioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BilancioObj.IsDirty = false;
			BilancioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBilancioValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioDelete", new string[] {"IdBilancio"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancio", (SiarLibrary.NullTypes.IntNT)IdBilancioValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BilancioCollection BilancioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioDelete", new string[] {"IdBilancio"}, new string[] {"int"},"");
				for (int i = 0; i < BilancioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBilancio", BilancioCollectionObj[i].IdBilancio);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BilancioCollectionObj.Count; i++)
				{
					if ((BilancioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BilancioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BilancioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BilancioCollectionObj[i].IsDirty = false;
						BilancioCollectionObj[i].IsPersistent = false;
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
		public static Bilancio GetById(DbProvider db, int IdBilancioValue)
		{
			Bilancio BilancioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBilancioGetById", new string[] {"IdBilancio"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBilancio", (SiarLibrary.NullTypes.IntNT)IdBilancioValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BilancioObj = GetFromDatareader(db);
				BilancioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioObj.IsDirty = false;
				BilancioObj.IsPersistent = true;
			}
			db.Close();
			return BilancioObj;
		}

		//getFromDatareader
		public static Bilancio GetFromDatareader(DbProvider db)
		{
			Bilancio BilancioObj = new Bilancio();
			BilancioObj.IdBilancio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BILANCIO"]);
			BilancioObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			BilancioObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			BilancioObj.DataBilancio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_BILANCIO"]);
			BilancioObj.PlvRicaviNettiVendita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_RICAVI_NETTI_VENDITA"]);
			BilancioObj.PlvAltriRicavi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_ALTRI_RICAVI"]);
			BilancioObj.PlvVarRimanenze = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_VAR_RIMANENZE"]);
			BilancioObj.PlvVarLavoro = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_VAR_LAVORO"]);
			BilancioObj.PlvIncrementi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_INCREMENTI"]);
			BilancioObj.RoCostiProduzione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RO_COSTI_PRODUZIONE"]);
			BilancioObj.RpiProventi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RPI_PROVENTI"]);
			BilancioObj.RpiRettifiche = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RPI_RETTIFICHE"]);
			BilancioObj.RpiProventiStraordinari = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RPI_PROVENTI_STRAORDINARI"]);
			BilancioObj.RnImposte = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_IMPOSTE"]);
			BilancioObj.TaCrediti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_CREDITI"]);
			BilancioObj.TaImmobilizzazioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_IMMOBILIZZAZIONI"]);
			BilancioObj.TaAttivoCircolante = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_ATTIVO_CIRCOLANTE"]);
			BilancioObj.TaRatei = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_RATEI"]);
			BilancioObj.TpPatrimonio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PATRIMONIO"]);
			BilancioObj.TpFondi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_FONDI"]);
			BilancioObj.TpLtMutuiOrdinari = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_MUTUI_ORDINARI"]);
			BilancioObj.TpLtMutuiAgevolati = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_MUTUI_AGEVOLATI"]);
			BilancioObj.TpLtPrestiti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_PRESTITI"]);
			BilancioObj.TpLtDebitiFornitori = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_DEBITI_FORNITORI"]);
			BilancioObj.TpLtDebitiBanche = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_DEBITI_BANCHE"]);
			BilancioObj.TpLtAltreScadenze = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_ALTRE_SCADENZE"]);
			BilancioObj.TpDebitiFornitori = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_DEBITI_FORNITORI"]);
			BilancioObj.TpDebitiBanche = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_DEBITI_BANCHE"]);
			BilancioObj.TpPrestitiSoci = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PRESTITI_SOCI"]);
			BilancioObj.TpPrestiti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PRESTITI"]);
			BilancioObj.TpAltriDebiti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_ALTRI_DEBITI"]);
			BilancioObj.TpRatei = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_RATEI"]);
			BilancioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BilancioObj.IsDirty = false;
			BilancioObj.IsPersistent = true;
			return BilancioObj;
		}

		//Find Select

		public static BilancioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBilancioEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataBilancioEqualThis, SiarLibrary.NullTypes.DecimalNT PlvRicaviNettiVenditaEqualThis, SiarLibrary.NullTypes.DecimalNT PlvAltriRicaviEqualThis, 
SiarLibrary.NullTypes.DecimalNT PlvVarRimanenzeEqualThis, SiarLibrary.NullTypes.DecimalNT PlvVarLavoroEqualThis, SiarLibrary.NullTypes.DecimalNT PlvIncrementiEqualThis, 
SiarLibrary.NullTypes.DecimalNT RoCostiProduzioneEqualThis, SiarLibrary.NullTypes.DecimalNT RpiProventiEqualThis, SiarLibrary.NullTypes.DecimalNT RpiRettificheEqualThis, 
SiarLibrary.NullTypes.DecimalNT RpiProventiStraordinariEqualThis, SiarLibrary.NullTypes.DecimalNT RnImposteEqualThis, SiarLibrary.NullTypes.DecimalNT TaCreditiEqualThis, 
SiarLibrary.NullTypes.DecimalNT TaImmobilizzazioniEqualThis, SiarLibrary.NullTypes.DecimalNT TaAttivoCircolanteEqualThis, SiarLibrary.NullTypes.DecimalNT TaRateiEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpPatrimonioEqualThis, SiarLibrary.NullTypes.DecimalNT TpFondiEqualThis, SiarLibrary.NullTypes.DecimalNT TpLtMutuiOrdinariEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpLtMutuiAgevolatiEqualThis, SiarLibrary.NullTypes.DecimalNT TpLtPrestitiEqualThis, SiarLibrary.NullTypes.DecimalNT TpLtDebitiFornitoriEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpLtDebitiBancheEqualThis, SiarLibrary.NullTypes.DecimalNT TpLtAltreScadenzeEqualThis, SiarLibrary.NullTypes.DecimalNT TpDebitiFornitoriEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpDebitiBancheEqualThis, SiarLibrary.NullTypes.DecimalNT TpPrestitiSociEqualThis, SiarLibrary.NullTypes.DecimalNT TpPrestitiEqualThis, 
SiarLibrary.NullTypes.DecimalNT TpAltriDebitiEqualThis, SiarLibrary.NullTypes.DecimalNT TpRateiEqualThis)

		{

			BilancioCollection BilancioCollectionObj = new BilancioCollection();

			IDbCommand findCmd = db.InitCmd("Zbilanciofindselect", new string[] {"IdBilancioequalthis", "IdImpresaequalthis", "Annoequalthis", 
"DataBilancioequalthis", "PlvRicaviNettiVenditaequalthis", "PlvAltriRicaviequalthis", 
"PlvVarRimanenzeequalthis", "PlvVarLavoroequalthis", "PlvIncrementiequalthis", 
"RoCostiProduzioneequalthis", "RpiProventiequalthis", "RpiRettificheequalthis", 
"RpiProventiStraordinariequalthis", "RnImposteequalthis", "TaCreditiequalthis", 
"TaImmobilizzazioniequalthis", "TaAttivoCircolanteequalthis", "TaRateiequalthis", 
"TpPatrimonioequalthis", "TpFondiequalthis", "TpLtMutuiOrdinariequalthis", 
"TpLtMutuiAgevolatiequalthis", "TpLtPrestitiequalthis", "TpLtDebitiFornitoriequalthis", 
"TpLtDebitiBancheequalthis", "TpLtAltreScadenzeequalthis", "TpDebitiFornitoriequalthis", 
"TpDebitiBancheequalthis", "TpPrestitiSociequalthis", "TpPrestitiequalthis", 
"TpAltriDebitiequalthis", "TpRateiequalthis"}, new string[] {"int", "int", "int", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBilancioequalthis", IdBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataBilancioequalthis", DataBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvRicaviNettiVenditaequalthis", PlvRicaviNettiVenditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvAltriRicaviequalthis", PlvAltriRicaviEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvVarRimanenzeequalthis", PlvVarRimanenzeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvVarLavoroequalthis", PlvVarLavoroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PlvIncrementiequalthis", PlvIncrementiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RoCostiProduzioneequalthis", RoCostiProduzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RpiProventiequalthis", RpiProventiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RpiRettificheequalthis", RpiRettificheEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RpiProventiStraordinariequalthis", RpiProventiStraordinariEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RnImposteequalthis", RnImposteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaCreditiequalthis", TaCreditiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaImmobilizzazioniequalthis", TaImmobilizzazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaAttivoCircolanteequalthis", TaAttivoCircolanteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TaRateiequalthis", TaRateiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPatrimonioequalthis", TpPatrimonioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpFondiequalthis", TpFondiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpLtMutuiOrdinariequalthis", TpLtMutuiOrdinariEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpLtMutuiAgevolatiequalthis", TpLtMutuiAgevolatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpLtPrestitiequalthis", TpLtPrestitiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpLtDebitiFornitoriequalthis", TpLtDebitiFornitoriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpLtDebitiBancheequalthis", TpLtDebitiBancheEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpLtAltreScadenzeequalthis", TpLtAltreScadenzeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpDebitiFornitoriequalthis", TpDebitiFornitoriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpDebitiBancheequalthis", TpDebitiBancheEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPrestitiSociequalthis", TpPrestitiSociEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpPrestitiequalthis", TpPrestitiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpAltriDebitiequalthis", TpAltriDebitiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TpRateiequalthis", TpRateiEqualThis);
			Bilancio BilancioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BilancioObj = GetFromDatareader(db);
				BilancioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioObj.IsDirty = false;
				BilancioObj.IsPersistent = true;
				BilancioCollectionObj.Add(BilancioObj);
			}
			db.Close();
			return BilancioCollectionObj;
		}

		//Find Find

		public static BilancioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBilancioEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataBilancioEqualThis, 
SiarLibrary.NullTypes.IntNT AnnoEqualThis)

		{

			BilancioCollection BilancioCollectionObj = new BilancioCollection();

			IDbCommand findCmd = db.InitCmd("Zbilanciofindfind", new string[] {"IdBilancioequalthis", "IdImpresaequalthis", "DataBilancioequalthis", 
"Annoequalthis"}, new string[] {"int", "int", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBilancioequalthis", IdBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataBilancioequalthis", DataBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			Bilancio BilancioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BilancioObj = GetFromDatareader(db);
				BilancioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioObj.IsDirty = false;
				BilancioObj.IsPersistent = true;
				BilancioCollectionObj.Add(BilancioObj);
			}
			db.Close();
			return BilancioCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO>
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
      <ID_BILANCIO>Equal</ID_BILANCIO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BILANCIO>
*/