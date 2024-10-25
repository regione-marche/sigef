using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BilancioPrevisionaleDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class BilancioPrevisionaleDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BilancioPrevisionale BilancioPrevisionaleObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPrevisionale", BilancioPrevisionaleObj.IdPrevisionale);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", BilancioPrevisionaleObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", BilancioPrevisionaleObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "DataBilancio", BilancioPrevisionaleObj.DataBilancio);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvRicaviNettiVendita", BilancioPrevisionaleObj.PlvRicaviNettiVendita);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvAltriRicavi", BilancioPrevisionaleObj.PlvAltriRicavi);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvVarRimanenze", BilancioPrevisionaleObj.PlvVarRimanenze);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvVarLavoro", BilancioPrevisionaleObj.PlvVarLavoro);
			DbProvider.SetCmdParam(cmd,firstChar + "PlvIncrementi", BilancioPrevisionaleObj.PlvIncrementi);
			DbProvider.SetCmdParam(cmd,firstChar + "RoCostiProduzione", BilancioPrevisionaleObj.RoCostiProduzione);
			DbProvider.SetCmdParam(cmd,firstChar + "RpiProventi", BilancioPrevisionaleObj.RpiProventi);
			DbProvider.SetCmdParam(cmd,firstChar + "RpiRettifiche", BilancioPrevisionaleObj.RpiRettifiche);
			DbProvider.SetCmdParam(cmd,firstChar + "RpiProventiStraordinari", BilancioPrevisionaleObj.RpiProventiStraordinari);
			DbProvider.SetCmdParam(cmd,firstChar + "RnImposte", BilancioPrevisionaleObj.RnImposte);
			DbProvider.SetCmdParam(cmd,firstChar + "TaCrediti", BilancioPrevisionaleObj.TaCrediti);
			DbProvider.SetCmdParam(cmd,firstChar + "TaImmobilizzazioni", BilancioPrevisionaleObj.TaImmobilizzazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "TaAttivoCircolante", BilancioPrevisionaleObj.TaAttivoCircolante);
			DbProvider.SetCmdParam(cmd,firstChar + "TaRatei", BilancioPrevisionaleObj.TaRatei);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPatrimonio", BilancioPrevisionaleObj.TpPatrimonio);
			DbProvider.SetCmdParam(cmd,firstChar + "TpFondi", BilancioPrevisionaleObj.TpFondi);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtMutuiOrdinari", BilancioPrevisionaleObj.TpLtMutuiOrdinari);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtMutuiAgevolati", BilancioPrevisionaleObj.TpLtMutuiAgevolati);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtPrestiti", BilancioPrevisionaleObj.TpLtPrestiti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtDebitiFornitori", BilancioPrevisionaleObj.TpLtDebitiFornitori);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtDebitiBanche", BilancioPrevisionaleObj.TpLtDebitiBanche);
			DbProvider.SetCmdParam(cmd,firstChar + "TpLtAltreScadenze", BilancioPrevisionaleObj.TpLtAltreScadenze);
			DbProvider.SetCmdParam(cmd,firstChar + "TpDebitiFornitori", BilancioPrevisionaleObj.TpDebitiFornitori);
			DbProvider.SetCmdParam(cmd,firstChar + "TpDebitiBanche", BilancioPrevisionaleObj.TpDebitiBanche);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPrestitiSoci", BilancioPrevisionaleObj.TpPrestitiSoci);
			DbProvider.SetCmdParam(cmd,firstChar + "TpPrestiti", BilancioPrevisionaleObj.TpPrestiti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpAltriDebiti", BilancioPrevisionaleObj.TpAltriDebiti);
			DbProvider.SetCmdParam(cmd,firstChar + "TpRatei", BilancioPrevisionaleObj.TpRatei);
		}
		//Insert
		private static int Insert(DbProvider db, BilancioPrevisionale BilancioPrevisionaleObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBilancioPrevisionaleInsert", new string[] {"IdProgetto", "Anno", 
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
				CompileIUCmd(false, insertCmd,BilancioPrevisionaleObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BilancioPrevisionaleObj.IdPrevisionale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PREVISIONALE"]);
				}
				BilancioPrevisionaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioPrevisionaleObj.IsDirty = false;
				BilancioPrevisionaleObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BilancioPrevisionale BilancioPrevisionaleObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBilancioPrevisionaleUpdate", new string[] {"IdPrevisionale", "IdProgetto", "Anno", 
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
				CompileIUCmd(true, updateCmd,BilancioPrevisionaleObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BilancioPrevisionaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioPrevisionaleObj.IsDirty = false;
				BilancioPrevisionaleObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BilancioPrevisionale BilancioPrevisionaleObj)
		{
			switch (BilancioPrevisionaleObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BilancioPrevisionaleObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BilancioPrevisionaleObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BilancioPrevisionaleObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BilancioPrevisionaleCollection BilancioPrevisionaleCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBilancioPrevisionaleUpdate", new string[] {"IdPrevisionale", "IdProgetto", "Anno", 
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
				IDbCommand insertCmd = db.InitCmd( "ZBilancioPrevisionaleInsert", new string[] {"IdProgetto", "Anno", 
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
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioPrevisionaleDelete", new string[] {"IdPrevisionale"}, new string[] {"int"},"");
				for (int i = 0; i < BilancioPrevisionaleCollectionObj.Count; i++)
				{
					switch (BilancioPrevisionaleCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BilancioPrevisionaleCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BilancioPrevisionaleCollectionObj[i].IdPrevisionale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PREVISIONALE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BilancioPrevisionaleCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BilancioPrevisionaleCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrevisionale", (SiarLibrary.NullTypes.IntNT)BilancioPrevisionaleCollectionObj[i].IdPrevisionale);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BilancioPrevisionaleCollectionObj.Count; i++)
				{
					if ((BilancioPrevisionaleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BilancioPrevisionaleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BilancioPrevisionaleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BilancioPrevisionaleCollectionObj[i].IsDirty = false;
						BilancioPrevisionaleCollectionObj[i].IsPersistent = true;
					}
					if ((BilancioPrevisionaleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BilancioPrevisionaleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BilancioPrevisionaleCollectionObj[i].IsDirty = false;
						BilancioPrevisionaleCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BilancioPrevisionale BilancioPrevisionaleObj)
		{
			int returnValue = 0;
			if (BilancioPrevisionaleObj.IsPersistent) 
			{
				returnValue = Delete(db, BilancioPrevisionaleObj.IdPrevisionale);
			}
			BilancioPrevisionaleObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BilancioPrevisionaleObj.IsDirty = false;
			BilancioPrevisionaleObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPrevisionaleValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioPrevisionaleDelete", new string[] {"IdPrevisionale"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrevisionale", (SiarLibrary.NullTypes.IntNT)IdPrevisionaleValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BilancioPrevisionaleCollection BilancioPrevisionaleCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBilancioPrevisionaleDelete", new string[] {"IdPrevisionale"}, new string[] {"int"},"");
				for (int i = 0; i < BilancioPrevisionaleCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPrevisionale", BilancioPrevisionaleCollectionObj[i].IdPrevisionale);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BilancioPrevisionaleCollectionObj.Count; i++)
				{
					if ((BilancioPrevisionaleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BilancioPrevisionaleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BilancioPrevisionaleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BilancioPrevisionaleCollectionObj[i].IsDirty = false;
						BilancioPrevisionaleCollectionObj[i].IsPersistent = false;
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
		public static BilancioPrevisionale GetById(DbProvider db, int IdPrevisionaleValue)
		{
			BilancioPrevisionale BilancioPrevisionaleObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBilancioPrevisionaleGetById", new string[] {"IdPrevisionale"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPrevisionale", (SiarLibrary.NullTypes.IntNT)IdPrevisionaleValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BilancioPrevisionaleObj = GetFromDatareader(db);
				BilancioPrevisionaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioPrevisionaleObj.IsDirty = false;
				BilancioPrevisionaleObj.IsPersistent = true;
			}
			db.Close();
			return BilancioPrevisionaleObj;
		}

		//getFromDatareader
		public static BilancioPrevisionale GetFromDatareader(DbProvider db)
		{
			BilancioPrevisionale BilancioPrevisionaleObj = new BilancioPrevisionale();
			BilancioPrevisionaleObj.IdPrevisionale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PREVISIONALE"]);
			BilancioPrevisionaleObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			BilancioPrevisionaleObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			BilancioPrevisionaleObj.DataBilancio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_BILANCIO"]);
			BilancioPrevisionaleObj.PlvRicaviNettiVendita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_RICAVI_NETTI_VENDITA"]);
			BilancioPrevisionaleObj.PlvAltriRicavi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_ALTRI_RICAVI"]);
			BilancioPrevisionaleObj.PlvVarRimanenze = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_VAR_RIMANENZE"]);
			BilancioPrevisionaleObj.PlvVarLavoro = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_VAR_LAVORO"]);
			BilancioPrevisionaleObj.PlvIncrementi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PLV_INCREMENTI"]);
			BilancioPrevisionaleObj.RoCostiProduzione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RO_COSTI_PRODUZIONE"]);
			BilancioPrevisionaleObj.RpiProventi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RPI_PROVENTI"]);
			BilancioPrevisionaleObj.RpiRettifiche = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RPI_RETTIFICHE"]);
			BilancioPrevisionaleObj.RpiProventiStraordinari = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RPI_PROVENTI_STRAORDINARI"]);
			BilancioPrevisionaleObj.RnImposte = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RN_IMPOSTE"]);
			BilancioPrevisionaleObj.TaCrediti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_CREDITI"]);
			BilancioPrevisionaleObj.TaImmobilizzazioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_IMMOBILIZZAZIONI"]);
			BilancioPrevisionaleObj.TaAttivoCircolante = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_ATTIVO_CIRCOLANTE"]);
			BilancioPrevisionaleObj.TaRatei = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TA_RATEI"]);
			BilancioPrevisionaleObj.TpPatrimonio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PATRIMONIO"]);
			BilancioPrevisionaleObj.TpFondi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_FONDI"]);
			BilancioPrevisionaleObj.TpLtMutuiOrdinari = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_MUTUI_ORDINARI"]);
			BilancioPrevisionaleObj.TpLtMutuiAgevolati = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_MUTUI_AGEVOLATI"]);
			BilancioPrevisionaleObj.TpLtPrestiti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_PRESTITI"]);
			BilancioPrevisionaleObj.TpLtDebitiFornitori = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_DEBITI_FORNITORI"]);
			BilancioPrevisionaleObj.TpLtDebitiBanche = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_DEBITI_BANCHE"]);
			BilancioPrevisionaleObj.TpLtAltreScadenze = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_LT_ALTRE_SCADENZE"]);
			BilancioPrevisionaleObj.TpDebitiFornitori = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_DEBITI_FORNITORI"]);
			BilancioPrevisionaleObj.TpDebitiBanche = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_DEBITI_BANCHE"]);
			BilancioPrevisionaleObj.TpPrestitiSoci = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PRESTITI_SOCI"]);
			BilancioPrevisionaleObj.TpPrestiti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_PRESTITI"]);
			BilancioPrevisionaleObj.TpAltriDebiti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_ALTRI_DEBITI"]);
			BilancioPrevisionaleObj.TpRatei = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TP_RATEI"]);
			BilancioPrevisionaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BilancioPrevisionaleObj.IsDirty = false;
			BilancioPrevisionaleObj.IsPersistent = true;
			return BilancioPrevisionaleObj;
		}

		//Find Select

		public static BilancioPrevisionaleCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrevisionaleEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, 
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

			BilancioPrevisionaleCollection BilancioPrevisionaleCollectionObj = new BilancioPrevisionaleCollection();

			IDbCommand findCmd = db.InitCmd("Zbilancioprevisionalefindselect", new string[] {"IdPrevisionaleequalthis", "IdProgettoequalthis", "Annoequalthis", 
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

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrevisionaleequalthis", IdPrevisionaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
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
			BilancioPrevisionale BilancioPrevisionaleObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BilancioPrevisionaleObj = GetFromDatareader(db);
				BilancioPrevisionaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioPrevisionaleObj.IsDirty = false;
				BilancioPrevisionaleObj.IsPersistent = true;
				BilancioPrevisionaleCollectionObj.Add(BilancioPrevisionaleObj);
			}
			db.Close();
			return BilancioPrevisionaleCollectionObj;
		}

		//Find Find

		public static BilancioPrevisionaleCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrevisionaleEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataBilancioEqualThis, 
SiarLibrary.NullTypes.IntNT AnnoEqualThis)

		{

			BilancioPrevisionaleCollection BilancioPrevisionaleCollectionObj = new BilancioPrevisionaleCollection();

			IDbCommand findCmd = db.InitCmd("Zbilancioprevisionalefindfind", new string[] {"IdPrevisionaleequalthis", "IdProgettoequalthis", "DataBilancioequalthis", 
"Annoequalthis"}, new string[] {"int", "int", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrevisionaleequalthis", IdPrevisionaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataBilancioequalthis", DataBilancioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			BilancioPrevisionale BilancioPrevisionaleObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BilancioPrevisionaleObj = GetFromDatareader(db);
				BilancioPrevisionaleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BilancioPrevisionaleObj.IsDirty = false;
				BilancioPrevisionaleObj.IsPersistent = true;
				BilancioPrevisionaleCollectionObj.Add(BilancioPrevisionaleObj);
			}
			db.Close();
			return BilancioPrevisionaleCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_PREVISIONALE>
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
      <ID_PREVISIONALE>Equal</ID_PREVISIONALE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BILANCIO_PREVISIONALE>
*/