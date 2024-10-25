using System;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data.SqlClient;
using SiarLibrary.Extensions;
using System.Linq;

namespace SiarBLL
{
    public partial class TestataValidazioneCollectionProvider : ITestataValidazioneProvider
    {
        public TestataValidazioneCollection FindByLottoApprovata(int IdLottoEqualThis, bool? ApprovataNotEqualThis)
        {
            TestataValidazioneCollection RevisioneDomandaPagamentoCollectionObj = new TestataValidazioneCollection();
            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            TestataValidazione RevisioneDomandaPagamentoObj;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpTestataValidazioneFindByLottoApprovata";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdLottoequalthis", IdLottoEqualThis));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("Approvatanotequalthis", ApprovataNotEqualThis));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                RevisioneDomandaPagamentoObj = TestataValidazioneDAL.GetFromDatareader(db);
                RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RevisioneDomandaPagamentoObj.IsDirty = false;
                RevisioneDomandaPagamentoObj.IsPersistent = true;
                RevisioneDomandaPagamentoCollectionObj.Add(RevisioneDomandaPagamentoObj);
            }
            db.Close();
            return RevisioneDomandaPagamentoCollectionObj;
        }

        public TestataValidazioneCollection GetRevisioneDomandeRup(IntNT id_utente_rup, IntNT id_bando, IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTestataValidazioneDomandeRup";
            if (id_utente_rup != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente_rup.Value));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetRevisioneDomandeRupFem(IntNT id_utente_rup, IntNT id_bando, IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTestataValidazioneDomandeRupFem";
            if (id_utente_rup != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", id_utente_rup.Value));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetUltimaRevisioneDomandaValida(IntNT id_domanda_pagamento)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetUltimaTestataValidazioneDomandaValida";
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetRevisioniProgettoValide(IntNT id_progetto)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetRevisioniProgettoValide";
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetRevisioniProgettoValideFem(IntNT id_progetto)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetRevisioniProgettoValideFem";
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetUltimaRevisioneDomandaValidaFem(IntNT id_domanda_pagamento)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetUltimaTestataValidazioneDomandaValidaFem";
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetTestataValidazioneValidatore(string cf_validatore, IntNT id_bando, IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTestataValidazioneValidatore";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CF_VALIDATORE", cf_validatore));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetTestataValidazioneValidatoreFem(string cf_validatore, IntNT id_bando, IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTestataValidazioneValidatoreFem";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CF_VALIDATORE", cf_validatore));
            if (id_bando != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetTestataValidazioneGenerico(IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTestataValidazioneGenerico";
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazioneCollection GetTestataValidazioneGenericoFem(IntNT id_progetto, IntNT id_domanda_pagamento)
        {
            TestataValidazioneCollection tvc = new TestataValidazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTestataValidazioneGenericoFem";
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto.Value));
            if (id_domanda_pagamento != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var r = TestataValidazioneDAL.GetFromDatareader(DbProviderObj);
                r.AdditionalAttributes.Add("DESCRIZIONE", new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]));
                tvc.Add(r);
            }
            DbProviderObj.Close();
            return tvc;
        }

        public TestataValidazione GeneraTestataValidazione(DbProvider db_provider, int id_lotto, int id_domanda_pagamento, string cf_operatore, string cf_validatore, bool selezionata_x_revisione, int ordine, int numero_estrazione, string segnatura_revisione, string segnatura_seconda_revisione)
        {
            var testata = new TestataValidazione();

            testata.IdLotto = id_lotto;
            testata.IdDomandaPagamento = id_domanda_pagamento;
            testata.CfInserimento = cf_operatore;
            testata.DataInserimento = DateTime.Now;
            testata.CfModifica = cf_operatore;
            testata.DataModifica = DateTime.Now;
            testata.CfValidatore = cf_validatore;
            testata.SelezionataXRevisione = selezionata_x_revisione;
            testata.NumeroEstrazione = numero_estrazione;
            testata.Ordine = ordine;
            testata.SegnaturaRevisione = segnatura_revisione;
            testata.SegnaturaSecondaRevisione = segnatura_seconda_revisione;

            return testata;
        }

        public string GeneraChecklistValidazioneAiuti(DbProvider db_provider, ref TestataValidazione testata, string cf_operatore_inserimento)
        {
            string errore = "";
            IstanzaChecklistGenericaCollectionProvider istanza_provider;
            if (db_provider != null)
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider(db_provider);
            else
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider();

            try
            {
                if (db_provider == null)
                    istanza_provider.DbProviderObj.BeginTran();

                this.DbProviderObj = istanza_provider.DbProviderObj;
                var chklst_provider = new ChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var schede_x_checklist_provider = new SchedaXChecklistCollectionProvider(istanza_provider.DbProviderObj);
                var testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider(istanza_provider.DbProviderObj);
                var domanda_pagamento_provider = new DomandaDiPagamentoCollectionProvider(istanza_provider.DbProviderObj);

                //prendo la checklist in base al tipo di domanda pagamento
                var dom_pag = domanda_pagamento_provider.GetById(testata.IdDomandaPagamento);
                ChecklistGenerica checklist_aiuti = null;

                if (dom_pag.CodTipo == "ANT")
                {
                    var check_coll = chklst_provider.Find("Checklist validazione Aiuti (ANT)", false);
                    if (check_coll.Count != 1)
                        throw new Exception("Checklist validazione degli aiuti (anticipi) non trovata");
                    checklist_aiuti = check_coll[0];
                }
                else
                {
                    var check_coll = chklst_provider.Find("Checklist validazione Aiuti", false);
                    if (check_coll.Count != 1)
                        throw new Exception("Checklist validazione degli aiuti non trovata");
                    checklist_aiuti = check_coll[0];
                }

                var checklist_aiuti_nuova = (ChecklistGenerica)checklist_aiuti.CloneAsNew();
                checklist_aiuti_nuova.IdChecklistGenerica = null;
                checklist_aiuti_nuova.Descrizione = checklist_aiuti_nuova.Descrizione + " - Domanda di aiuto " + testata.IdProgetto + " - Domanda di pagamento " + testata.IdDomandaPagamento;
                chklst_provider.Save(checklist_aiuti_nuova);

                var nuova_istanza_generica = new IstanzaChecklistGenerica();
                nuova_istanza_generica.CfInserimento = cf_operatore_inserimento;
                nuova_istanza_generica.DataInserimento = DateTime.Now;
                nuova_istanza_generica.CfModifica = cf_operatore_inserimento;
                nuova_istanza_generica.DataModifica = DateTime.Now;
                nuova_istanza_generica.IdChecklistGenerica = checklist_aiuti_nuova.IdChecklistGenerica;
                istanza_provider.Save(nuova_istanza_generica);

                var testata_x_istanza = new TestataValidazioneXIstanza();
                testata_x_istanza.CfInserimento = cf_operatore_inserimento;
                testata_x_istanza.DataInserimento = DateTime.Now;
                testata_x_istanza.CfModifica = cf_operatore_inserimento;
                testata_x_istanza.DataModifica = DateTime.Now;
                testata_x_istanza.Ordine = 1;
                testata_x_istanza.IdTestataValidazione = testata.IdTestata;
                testata_x_istanza.IdIstanzaChecklistGenerica = nuova_istanza_generica.IdIstanzaGenerica;
                testata_x_istanza_provider.Save(testata_x_istanza);

                testata.CfModifica = cf_operatore_inserimento;
                testata.DataModifica = DateTime.Now;
                this.Save(testata);

                int ordine = 1;

                var schede_coll = schede_x_checklist_provider.Find(null, checklist_aiuti.IdChecklistGenerica, null);
                foreach (SchedaXChecklist scheda in schede_coll)
                {
                    var scheda_aiuti_nuova = (SchedaXChecklist)scheda.CloneAsNew();
                    scheda_aiuti_nuova.IdSchedaXChecklist = null;
                    scheda_aiuti_nuova.IdChecklistPadre = checklist_aiuti_nuova.IdChecklistGenerica; //cambio il padre associato
                    scheda_aiuti_nuova.Ordine = ordine++; //cambio l'ordine e poi incremento la variabile
                    scheda_aiuti_nuova.CfInserimento = scheda_aiuti_nuova.CfModifica = cf_operatore_inserimento;
                    scheda_aiuti_nuova.DataInserimento = scheda_aiuti_nuova.DataModifica = DateTime.Now;
                    //scheda_validazione.MarkAsNew();
                    schede_x_checklist_provider.Save(scheda_aiuti_nuova);

                    //PRENDO LA CHECKLIST_FIGLIA PER INSERIRE LA NUOVA ISTANZA
                    var checklist_figlia_aiuti_nuova = chklst_provider.GetById(scheda.IdChecklistFiglio);

                    nuova_istanza_generica = new IstanzaChecklistGenerica();
                    nuova_istanza_generica.IdChecklistGenerica = checklist_figlia_aiuti_nuova.IdChecklistGenerica;
                    nuova_istanza_generica.IdChecklistPadre = checklist_aiuti_nuova.IdChecklistGenerica;
                    nuova_istanza_generica.IdSchedaXChecklist = scheda_aiuti_nuova.IdSchedaXChecklist;
                    nuova_istanza_generica.CfInserimento = nuova_istanza_generica.CfModifica = cf_operatore_inserimento;
                    nuova_istanza_generica.DataInserimento = nuova_istanza_generica.DataModifica = DateTime.Now;
                    istanza_provider.Save(nuova_istanza_generica);
                }

                if (db_provider == null)
                    istanza_provider.DbProviderObj.Commit();
            }
            catch(Exception ex)
            {
                errore = ex.Message;
                if (db_provider == null)
                    istanza_provider.DbProviderObj.Rollback();
            }

            return errore;
        }

        public string GeneraChecklistDaAutovalutazione(DbProvider db_provider, ref TestataValidazione testata_validazione, string cf_operatore_inserimento, int id_lotto, int ordine_lotto, string cf_validatore)
        {
            string errore = "";
            //TestataValidazione testata_validazione = null;
            IstanzaChecklistGenericaCollectionProvider istanza_provider;
            if (db_provider != null)
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider(db_provider);
            else
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider();

            try
            {
                if (db_provider == null)
                    istanza_provider.DbProviderObj.BeginTran();

                this.DbProviderObj = istanza_provider.DbProviderObj;
                var testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider(istanza_provider.DbProviderObj);
                var checklist_provider = new ChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var schede_x_checklist_provider = new SchedaXChecklistCollectionProvider(istanza_provider.DbProviderObj);
                var istanza_checklist_provider = new IstanzaChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var esiti_provider = new EsitoIstanzaChecklistGenericoCollectionProvider(istanza_provider.DbProviderObj);

                if (testata_validazione == null || testata_validazione.IdProgetto == null || testata_validazione.IdDomandaPagamento == null)
                    throw new Exception("Domanda di pagamento di riferimento mancante");

                //RECUPERO L'AUTOVALUTAZIONE
                var progetto = new ProgettoCollectionProvider().GetById(testata_validazione.IdProgetto);
                var autovalutazioni_coll = this.FindAutovalutazione(null, testata_validazione.IdProgetto, testata_validazione.IdDomandaPagamento, true);
                if (autovalutazioni_coll.Count != 1)
                    throw new Exception("Autovalutazione della domanda di pagamento mancante");
                var autovalutazione = autovalutazioni_coll[0];

                /*
                 * NON GENERO LA TESTATA PERCHE' LA SALVO DAL METODO CHIAMANTE
                //GENERO LA TESTATA DELLA VALIDAZIONE
                testata_validazione = (TestataValidazione)autovalutazione.CloneAsNew();
                testata_validazione.IdTestata = null;
                testata_validazione.Autovalutazione = false;
                testata_validazione.IdLotto = id_lotto;
                testata_validazione.CfValidatore = cf_validatore;
                testata_validazione.SelezionataXRevisione = true;
                testata_validazione.NumeroEstrazione = 1;
                testata_validazione.Ordine = ordine_lotto;
                testata_validazione.SegnaturaRevisione = null;
                testata_validazione.SegnaturaSecondaRevisione = null;
                testata_validazione.CfInserimento = testata_validazione.CfModifica = cf_operatore_inserimento;
                testata_validazione.DataInserimento = testata_validazione.DataModifica = DateTime.Now;
                //testata_validazione.MarkAsNew();
                this.Save(testata_validazione);
                */
                
                //PER TUTTE LE ISTANZE DELL'AUTOVALUTAZIONE
                var autovalutazione_istanze_coll = testata_x_istanza_provider.Find(null, autovalutazione.IdTestata, null, null, true);
                foreach (TestataValidazioneXIstanza istanza_testata_autovalutazione in autovalutazione_istanze_coll)
                {
                    //PRENDO LA CHECKLIST DELL'ISTANZA E NE FACCIO UNA COPIA
                    var checklist_padre_autovalutazione = checklist_provider.GetById(istanza_testata_autovalutazione.IdChecklistGenerica);
                    var checklist_padre_validazione = (ChecklistGenerica)checklist_padre_autovalutazione.CloneAsNew();
                    checklist_padre_validazione.IdChecklistGenerica = null;
                    checklist_padre_validazione.CfInserimento = checklist_padre_validazione.CfModifica = cf_operatore_inserimento;
                    checklist_padre_validazione.DataInserimento = checklist_padre_validazione.DataModifica = DateTime.Now;
                    //checklist_padre_validazione.MarkAsNew();
                    //checklist_provider.Descrizione = la devo cambiare?
                    checklist_provider.Save(checklist_padre_validazione);

                    //PRENDO L'ISTANZA CHEKLIST E NE FACCIO UNA COPIA
                    var istanza_checklist_padre_autovalutazione = istanza_checklist_provider.GetById(istanza_testata_autovalutazione.IdIstanzaChecklistGenerica);
                    var istanza_checklist_padre_validazione = (IstanzaChecklistGenerica)istanza_checklist_padre_autovalutazione.CloneAsNew();
                    istanza_checklist_padre_validazione.IdIstanzaGenerica = null;
                    istanza_checklist_padre_validazione.IdChecklistGenerica = checklist_padre_validazione.IdChecklistGenerica; //cambio la checklist associata
                    istanza_checklist_padre_validazione.CfInserimento = istanza_checklist_padre_validazione.CfModifica = cf_operatore_inserimento;
                    istanza_checklist_padre_validazione.DataInserimento = istanza_checklist_padre_validazione.DataModifica = DateTime.Now;
                    //istanza_checklist_padre_validazione.MarkAsNew();
                    istanza_checklist_provider.Save(istanza_checklist_padre_validazione);

                    //CREO LA COPIA DELLA TESTATA X ISTANZA 
                    TestataValidazioneXIstanza istanza_testata_validazione = (TestataValidazioneXIstanza)istanza_testata_autovalutazione.CloneAsNew();
                    istanza_testata_validazione.IdTestataValidazioneXIstanza = null;
                    istanza_testata_validazione.IdTestataValidazione = testata_validazione.IdTestata; //cambio la testata associata
                    istanza_testata_validazione.IdIstanzaChecklistGenerica = istanza_checklist_padre_validazione.IdIstanzaGenerica;
                    istanza_testata_validazione.CfInserimento = istanza_testata_validazione.CfModifica = cf_operatore_inserimento;
                    istanza_testata_validazione.DataInserimento = istanza_testata_validazione.DataModifica = DateTime.Now;
                    //istanza_testata_validazione.MarkAsNew();
                    testata_x_istanza_provider.Save(istanza_testata_validazione);

                    int ordine = 1;

                    //AGGIUNGO ALLA CHECKLIST DELLA VALIDAZIONE LE SCHEDE PRIMA DELL'AUTOVALUTAZIONE
                    var checklist_pre_autovalutazione = GetSchedeChecklistAppaltiPreAutovalutazione();
                    foreach (ChecklistGenerica check_pre in checklist_pre_autovalutazione)
                    {
                        //CREO LA SCHEDA_X_CHECKLIST ASSOCIATA
                        var scheda_pre = new SchedaXChecklist();
                        scheda_pre.CfInserimento = scheda_pre.CfModifica = cf_operatore_inserimento;
                        scheda_pre.DataInserimento = scheda_pre.DataModifica = DateTime.Now;
                        scheda_pre.IdChecklistPadre = checklist_padre_validazione.IdChecklistGenerica;
                        scheda_pre.IdChecklistFiglio = check_pre.IdChecklistGenerica;
                        scheda_pre.Ordine = ordine++; //assegno l'ordine e poi lo incremento
                        scheda_pre.Obbligatorio = true;
                        scheda_pre.Peso = 1.00;
                        schede_x_checklist_provider.Save(scheda_pre);

                        //E LA RELATIVA ISTANZA
                        var istanza_checklist_pre = new IstanzaChecklistGenerica();
                        istanza_checklist_pre.IdChecklistGenerica = check_pre.IdChecklistGenerica;
                        istanza_checklist_pre.IdChecklistPadre = istanza_checklist_padre_validazione.IdChecklistGenerica;
                        istanza_checklist_pre.IdSchedaXChecklist = scheda_pre.IdSchedaXChecklist;
                        istanza_checklist_pre.CfInserimento = istanza_checklist_pre.CfModifica = cf_operatore_inserimento;
                        istanza_checklist_pre.DataInserimento = istanza_checklist_pre.DataModifica = DateTime.Now;
                        istanza_checklist_provider.Save(istanza_checklist_pre);
                    }

                    //AGGIUNGO ALLA CHECKLIST DELLA VALIDAZIONE LE SCHEDE DELL'AUTOVALUTAZIONE
                    var schede_autovalutazione_coll = schede_x_checklist_provider.Find(null, istanza_testata_autovalutazione.IdChecklistGenerica, null);
                    foreach (SchedaXChecklist scheda_autovalutazione in schede_autovalutazione_coll)
                    {
                        var scheda_validazione = (SchedaXChecklist)scheda_autovalutazione.CloneAsNew();
                        scheda_validazione.IdSchedaXChecklist = null;
                        scheda_validazione.IdChecklistPadre = istanza_checklist_padre_validazione.IdChecklistGenerica; //cambio il padre associato
                        scheda_validazione.Ordine = ordine++; //cambio l'ordine e poi incremento la variabile
                        scheda_validazione.CfInserimento = scheda_validazione.CfModifica = cf_operatore_inserimento;
                        scheda_validazione.DataInserimento = scheda_validazione.DataModifica = DateTime.Now;
                        //scheda_validazione.MarkAsNew();
                        schede_x_checklist_provider.Save(scheda_validazione);

                        //PRENDO LA CHECKLIST_FIGLIA PER COPIARE L'ISTANZA E GLI ESITI
                        var checklist_figlia_autovalutazione = checklist_provider.GetById(scheda_autovalutazione.IdChecklistFiglio);
                        var istanza_checklist_figlia_autovalutazione = istanza_provider.Find(null, scheda_autovalutazione.IdChecklistFiglio, null, scheda_autovalutazione.IdChecklistPadre, scheda_autovalutazione.IdSchedaXChecklist)[0];

                        var istanza_checklist_figlia_validazione = (IstanzaChecklistGenerica)istanza_checklist_figlia_autovalutazione.CloneAsNew();
                        istanza_checklist_figlia_validazione.IdChecklistPadre = istanza_checklist_padre_validazione.IdChecklistGenerica; //cambio il padre associato
                        istanza_checklist_figlia_validazione.IdSchedaXChecklist = scheda_validazione.IdSchedaXChecklist; //cambio l'id_scheda_x_checklist associato
                        istanza_checklist_figlia_validazione.CfInserimento = istanza_checklist_figlia_validazione.CfModifica = cf_operatore_inserimento;
                        istanza_checklist_figlia_validazione.DataInserimento = istanza_checklist_figlia_validazione.DataModifica = DateTime.Now;
                        //istanza_checklist_figlia_validazione.MarkAsNew();
                        istanza_checklist_provider.Save(istanza_checklist_figlia_validazione);

                        var esiti_checklist_figlia_autovalutazione_coll = esiti_provider.Find(istanza_checklist_figlia_autovalutazione.IdIstanzaGenerica, null, null, null, istanza_checklist_figlia_autovalutazione.IdChecklistGenerica);
                        foreach (EsitoIstanzaChecklistGenerico esito_checklist_figlia_autovalutazione in esiti_checklist_figlia_autovalutazione_coll)
                        {
                            var esito_checklist_figlia_validazione = (EsitoIstanzaChecklistGenerico)esito_checklist_figlia_autovalutazione.CloneAsNew();
                            esito_checklist_figlia_validazione.IdIstanzaGenerica = istanza_checklist_figlia_validazione.IdIstanzaGenerica; //cambio l'id dell'istanza checklist associato
                            esito_checklist_figlia_validazione.CfInserimento = esito_checklist_figlia_validazione.CfModifica = cf_operatore_inserimento;
                            esito_checklist_figlia_validazione.DataInserimento = esito_checklist_figlia_validazione.DataModifica = DateTime.Now;
                            //esito_checklist_figlia_validazione.MarkAsNew();
                            esiti_provider.Save(esito_checklist_figlia_validazione);
                        }
                    }

                    //AGGIUNGO ALLA CHECKLIST DELLA VALIDAZIONE LE SCHEDE DOPO DELL'AUTOVALUTAZIONE
                    var checklist_post_autovalutazione = GetSchedeChecklistAppaltiPostAutovalutazione();
                    foreach (ChecklistGenerica check_post in checklist_post_autovalutazione)
                    {
                        //CREO LA SCHEDA_X_CHECKLIST ASSOCIATA
                        var scheda_post = new SchedaXChecklist();
                        scheda_post.CfInserimento = scheda_post.CfModifica = cf_operatore_inserimento;
                        scheda_post.DataInserimento = scheda_post.DataModifica = DateTime.Now;
                        scheda_post.IdChecklistPadre = checklist_padre_validazione.IdChecklistGenerica;
                        scheda_post.IdChecklistFiglio = check_post.IdChecklistGenerica;
                        scheda_post.Ordine = ordine++; //assegno l'ordine e poi lo incremento
                        scheda_post.Obbligatorio = true;
                        scheda_post.Peso = 1.00;
                        schede_x_checklist_provider.Save(scheda_post);

                        //E LA RELATIVA ISTANZA
                        var istanza_checklist_post = new IstanzaChecklistGenerica();
                        istanza_checklist_post.IdChecklistGenerica = check_post.IdChecklistGenerica;
                        istanza_checklist_post.IdChecklistPadre = istanza_checklist_padre_validazione.IdChecklistGenerica;
                        istanza_checklist_post.IdSchedaXChecklist = scheda_post.IdSchedaXChecklist;
                        istanza_checklist_post.CfInserimento = istanza_checklist_post.CfModifica = cf_operatore_inserimento;
                        istanza_checklist_post.DataInserimento = istanza_checklist_post.DataModifica = DateTime.Now;
                        istanza_checklist_provider.Save(istanza_checklist_post);
                    }
                }

                if (db_provider == null)
                    istanza_provider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
                if (db_provider == null)
                    istanza_provider.DbProviderObj.Rollback();
            }

            return errore;
        }

        public string GeneraTestataDaPrecedente(DbProvider db_provider, TestataValidazione testata_validazione_precedente, ref TestataValidazione testata_validazione_nuova, string cf_operatore_inserimento, bool svuota_istanze_nuova_testata, bool is_autovalutazione)
        {
            string errore = "";
            //TestataValidazione testata_validazione = null;
            IstanzaChecklistGenericaCollectionProvider istanza_provider;
            if (db_provider != null)
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider(db_provider);
            else
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider();

            try
            {
                if (db_provider == null)
                    istanza_provider.DbProviderObj.BeginTran();

                this.DbProviderObj = istanza_provider.DbProviderObj;
                var testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider(istanza_provider.DbProviderObj);
                var checklist_provider = new ChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var schede_x_checklist_provider = new SchedaXChecklistCollectionProvider(istanza_provider.DbProviderObj);
                var istanza_checklist_provider = new IstanzaChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var esiti_provider = new EsitoIstanzaChecklistGenericoCollectionProvider(istanza_provider.DbProviderObj);

                if (testata_validazione_precedente == null || testata_validazione_precedente.IdProgetto == null || testata_validazione_precedente.IdDomandaPagamento == null)
                    throw new Exception("Domanda di pagamento di riferimento mancante");

                /*
                 * NON GENERO LA TESTATA PERCHE' LA SALVO DAL METODO CHIAMANTE
                */

                if (svuota_istanze_nuova_testata)
                {
                    //Elimino prima le istanze che ho già associate alla testata nuova
                    var istanze_testate_coll = testata_x_istanza_provider.Find(null, testata_validazione_nuova.IdTestata, null, null, null);
                    testata_x_istanza_provider.DeleteCollection(istanze_testate_coll);
                }

                //PER TUTTE LE ISTANZE DELLA TESTATA PRECEDENTE
                var validazione_vecchia_istanze_coll = testata_x_istanza_provider.Find(null, testata_validazione_precedente.IdTestata, null, null, is_autovalutazione);
                foreach (TestataValidazioneXIstanza istanza_testata_vecchia in validazione_vecchia_istanze_coll)
                {
                    //PRENDO LA CHECKLIST DELL'ISTANZA E NE FACCIO UNA COPIA
                    var checklist_padre_validazione_vecchia = checklist_provider.GetById(istanza_testata_vecchia.IdChecklistGenerica);
                    var checklist_padre_validazione_nuova = (ChecklistGenerica)checklist_padre_validazione_vecchia.CloneAsNew();
                    checklist_padre_validazione_nuova.IdChecklistGenerica = null;
                    checklist_padre_validazione_nuova.CfInserimento = checklist_padre_validazione_nuova.CfModifica = cf_operatore_inserimento;
                    checklist_padre_validazione_nuova.DataInserimento = checklist_padre_validazione_nuova.DataModifica = DateTime.Now;
                    //checklist_padre_validazione.MarkAsNew();
                    //Cambio la descrizione con id progetto e id domanda corretti e se ho la descrizione alla fine l'aggiungo
                    if (checklist_padre_validazione_nuova.Descrizione.Contains("Domanda aiuto"))
                    {
                        var descrizione_nuova = "Domanda aiuto " + testata_validazione_nuova.IdProgetto + " - Domanda pagamento " + testata_validazione_nuova.IdDomandaPagamento;
                        
                        var splittato = checklist_padre_validazione_nuova.Descrizione.Value.Split('-');
                        if (splittato.Count() > 2) 
                        { 
                            var desc_finale = splittato[2];
                            descrizione_nuova += " -" + desc_finale;
                        }
                        checklist_padre_validazione_nuova.Descrizione = descrizione_nuova;
                    }
                        
                    //checklist_provider.Descrizione = la devo cambiare?
                    checklist_provider.Save(checklist_padre_validazione_nuova);

                    //PRENDO L'ISTANZA CHEKLIST E NE FACCIO UNA COPIA
                    var istanza_checklist_padre_validazione_vecchia = istanza_checklist_provider.GetById(istanza_testata_vecchia.IdIstanzaChecklistGenerica);
                    var istanza_checklist_padre_validazione_nuova = (IstanzaChecklistGenerica)istanza_checklist_padre_validazione_vecchia.CloneAsNew();
                    istanza_checklist_padre_validazione_nuova.IdIstanzaGenerica = null;
                    istanza_checklist_padre_validazione_nuova.IdChecklistGenerica = checklist_padre_validazione_nuova.IdChecklistGenerica; //cambio la checklist associata
                    istanza_checklist_padre_validazione_nuova.CfInserimento = istanza_checklist_padre_validazione_nuova.CfModifica = cf_operatore_inserimento;
                    istanza_checklist_padre_validazione_nuova.DataInserimento = istanza_checklist_padre_validazione_nuova.DataModifica = DateTime.Now;
                    //istanza_checklist_padre_validazione.MarkAsNew();
                    istanza_checklist_provider.Save(istanza_checklist_padre_validazione_nuova);

                    //CREO LA COPIA DELLA TESTATA X ISTANZA 
                    TestataValidazioneXIstanza istanza_testata_validazione_nuova = (TestataValidazioneXIstanza)istanza_testata_vecchia.CloneAsNew();
                    istanza_testata_validazione_nuova.IdTestataValidazioneXIstanza = null;
                    istanza_testata_validazione_nuova.IdTestataValidazione = testata_validazione_nuova.IdTestata; //cambio la testata associata
                    istanza_testata_validazione_nuova.IdIstanzaChecklistGenerica = istanza_checklist_padre_validazione_nuova.IdIstanzaGenerica;
                    istanza_testata_validazione_nuova.CfInserimento = istanza_testata_validazione_nuova.CfModifica = cf_operatore_inserimento;
                    istanza_testata_validazione_nuova.DataInserimento = istanza_testata_validazione_nuova.DataModifica = DateTime.Now;
                    //istanza_testata_validazione.MarkAsNew();
                    testata_x_istanza_provider.Save(istanza_testata_validazione_nuova);

                    int ordine = 1;

                    //AGGIUNGO ALLA CHECKLIST DELLA VALIDAZIONE NUOVA LE SCHEDE DELLA VALIDAZIONE VECCHIA
                    var schede_validazione_vecchia_coll = schede_x_checklist_provider.Find(null, istanza_testata_vecchia.IdChecklistGenerica, null);
                    foreach (SchedaXChecklist scheda_validazione_vecchia in schede_validazione_vecchia_coll)
                    {
                        var scheda_validazione_nuova = (SchedaXChecklist)scheda_validazione_vecchia.CloneAsNew();
                        scheda_validazione_nuova.IdSchedaXChecklist = null;
                        scheda_validazione_nuova.IdChecklistPadre = istanza_checklist_padre_validazione_nuova.IdChecklistGenerica; //cambio il padre associato
                        scheda_validazione_nuova.Ordine = ordine++; //cambio l'ordine e poi incremento la variabile
                        scheda_validazione_nuova.CfInserimento = scheda_validazione_nuova.CfModifica = cf_operatore_inserimento;
                        scheda_validazione_nuova.DataInserimento = scheda_validazione_nuova.DataModifica = DateTime.Now;
                        //scheda_validazione.MarkAsNew();
                        schede_x_checklist_provider.Save(scheda_validazione_nuova);

                        //PRENDO LA CHECKLIST_FIGLIA PER COPIARE L'ISTANZA E GLI ESITI
                        var checklist_figlia_validazione_vecchia = checklist_provider.GetById(scheda_validazione_vecchia.IdChecklistFiglio);
                        var istanza_checklist_figlia_validazione_vecchia = istanza_provider.Find(null, scheda_validazione_vecchia.IdChecklistFiglio, null, scheda_validazione_vecchia.IdChecklistPadre, scheda_validazione_vecchia.IdSchedaXChecklist)[0];

                        var istanza_checklist_figlia_validazione_nuova = (IstanzaChecklistGenerica)istanza_checklist_figlia_validazione_vecchia.CloneAsNew();
                        istanza_checklist_figlia_validazione_nuova.IdChecklistPadre = istanza_checklist_padre_validazione_nuova.IdChecklistGenerica; //cambio il padre associato
                        istanza_checklist_figlia_validazione_nuova.IdSchedaXChecklist = scheda_validazione_nuova.IdSchedaXChecklist; //cambio l'id_scheda_x_checklist associato
                        istanza_checklist_figlia_validazione_nuova.CfInserimento = istanza_checklist_figlia_validazione_nuova.CfModifica = cf_operatore_inserimento;
                        istanza_checklist_figlia_validazione_nuova.DataInserimento = istanza_checklist_figlia_validazione_nuova.DataModifica = DateTime.Now;
                        //istanza_checklist_figlia_validazione.MarkAsNew();
                        istanza_checklist_provider.Save(istanza_checklist_figlia_validazione_nuova);

                        var esiti_checklist_figlia_validazione_vecchia_coll = esiti_provider.Find(istanza_checklist_figlia_validazione_vecchia.IdIstanzaGenerica, null, null, null, istanza_checklist_figlia_validazione_vecchia.IdChecklistGenerica);
                        foreach (EsitoIstanzaChecklistGenerico esito_checklist_figlia_validazione_vecchia in esiti_checklist_figlia_validazione_vecchia_coll)
                        {
                            var esito_checklist_figlia_validazione_nuova = (EsitoIstanzaChecklistGenerico)esito_checklist_figlia_validazione_vecchia.CloneAsNew();
                            esito_checklist_figlia_validazione_nuova.IdIstanzaGenerica = istanza_checklist_figlia_validazione_nuova.IdIstanzaGenerica; //cambio l'id dell'istanza checklist associato
                            esito_checklist_figlia_validazione_nuova.CfInserimento = esito_checklist_figlia_validazione_nuova.CfModifica = cf_operatore_inserimento;
                            esito_checklist_figlia_validazione_nuova.DataInserimento = esito_checklist_figlia_validazione_nuova.DataModifica = DateTime.Now;
                            //esito_checklist_figlia_validazione.MarkAsNew();
                            esiti_provider.Save(esito_checklist_figlia_validazione_nuova);
                        }
                    }
                }

                if (db_provider == null)
                    istanza_provider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
                if (db_provider == null)
                    istanza_provider.DbProviderObj.Rollback();
            }

            return errore;
        }

        public string GeneraChecklistSenzaAutovalutazione(DbProvider db_provider, ref TestataValidazione testata_validazione, string cf_operatore_inserimento, int id_lotto, int ordine_lotto, string cf_validatore)
        {
            string errore = "";
            //TestataValidazione testata_validazione = null;
            IstanzaChecklistGenericaCollectionProvider istanza_provider;
            if (db_provider != null)
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider(db_provider);
            else
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider();

            try
            {
                if (db_provider == null)
                    istanza_provider.DbProviderObj.BeginTran();

                this.DbProviderObj = istanza_provider.DbProviderObj;
                var testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider(istanza_provider.DbProviderObj);
                var checklist_provider = new ChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var schede_x_checklist_provider = new SchedaXChecklistCollectionProvider(istanza_provider.DbProviderObj);
                var istanza_checklist_provider = new IstanzaChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var esiti_provider = new EsitoIstanzaChecklistGenericoCollectionProvider(istanza_provider.DbProviderObj);

                if (testata_validazione == null || testata_validazione.IdProgetto == null || testata_validazione.IdDomandaPagamento == null)
                    throw new Exception("Domanda di pagamento di riferimento mancante");

                /*
                 * NON GENERO LA TESTATA PERCHE' LA SALVO DAL METODO CHIAMANTE
                //GENERO LA TESTATA DELLA VALIDAZIONE
                testata_validazione = (TestataValidazione)autovalutazione.CloneAsNew();
                testata_validazione.IdTestata = null;
                testata_validazione.Autovalutazione = false;
                testata_validazione.IdLotto = id_lotto;
                testata_validazione.CfValidatore = cf_validatore;
                testata_validazione.SelezionataXRevisione = true;
                testata_validazione.NumeroEstrazione = 1;
                testata_validazione.Ordine = ordine_lotto;
                testata_validazione.SegnaturaRevisione = null;
                testata_validazione.SegnaturaSecondaRevisione = null;
                testata_validazione.CfInserimento = testata_validazione.CfModifica = cf_operatore_inserimento;
                testata_validazione.DataInserimento = testata_validazione.DataModifica = DateTime.Now;
                //testata_validazione.MarkAsNew();
                this.Save(testata_validazione);
                */

                var checklist_testata = new ChecklistGenerica();
                checklist_testata.IdTipo = 3; //checklist di schede
                checklist_testata.CfInserimento = checklist_testata.CfModifica = cf_operatore_inserimento;
                checklist_testata.DataInserimento = checklist_testata.DataModifica = DateTime.Now;
                checklist_testata.FlagTemplate = 0;
                checklist_testata.Descrizione = "Domanda aiuto " + testata_validazione.IdProgetto + " - Domanda pagamento " + testata_validazione.IdDomandaPagamento;
                checklist_provider.Save(checklist_testata);

                var istanza_checklist_testa = new IstanzaChecklistGenerica();
                istanza_checklist_testa.IdChecklistGenerica = checklist_testata.IdChecklistGenerica; 
                istanza_checklist_testa.CfInserimento = istanza_checklist_testa.CfModifica = cf_operatore_inserimento;
                istanza_checklist_testa.DataInserimento = istanza_checklist_testa.DataModifica = DateTime.Now;
                istanza_checklist_provider.Save(istanza_checklist_testa);

                var istanza_testata = new TestataValidazioneXIstanza();
                istanza_testata.CfInserimento = istanza_testata.CfModifica = cf_operatore_inserimento;
                istanza_testata.DataInserimento = istanza_testata.DataModifica = DateTime.Now;
                istanza_testata.IdTestataValidazione = testata_validazione.IdTestata;
                istanza_testata.IdChecklistGenerica = checklist_testata.IdChecklistGenerica;
                istanza_testata.IdIstanzaChecklistGenerica = istanza_checklist_testa.IdIstanzaGenerica;
                testata_x_istanza_provider.Save(istanza_testata);

                int ordine = 1;

                //AGGIUNGO ALLA CHECKLIST DELLA VALIDAZIONE LE SCHEDE PRIMA DELL'AUTOVALUTAZIONE
                var checklist_pre_autovalutazione = GetSchedeChecklistAppaltiPreAutovalutazione();
                foreach (ChecklistGenerica check_pre in checklist_pre_autovalutazione)
                {
                    //CREO LA SCHEDA_X_CHECKLIST ASSOCIATA
                    var scheda_pre = new SchedaXChecklist();
                    scheda_pre.CfInserimento = scheda_pre.CfModifica = cf_operatore_inserimento;
                    scheda_pre.DataInserimento = scheda_pre.DataModifica = DateTime.Now;
                    scheda_pre.IdChecklistPadre = checklist_testata.IdChecklistGenerica;
                    scheda_pre.IdChecklistFiglio = check_pre.IdChecklistGenerica;
                    scheda_pre.Ordine = ordine++; //assegno l'ordine e poi lo incremento
                    scheda_pre.Obbligatorio = true;
                    scheda_pre.Peso = 1.00;
                    schede_x_checklist_provider.Save(scheda_pre);

                    //E LA RELATIVA ISTANZA
                    var istanza_checklist_pre = new IstanzaChecklistGenerica();
                    istanza_checklist_pre.IdChecklistGenerica = check_pre.IdChecklistGenerica;
                    istanza_checklist_pre.IdChecklistPadre = istanza_testata.IdChecklistGenerica;
                    istanza_checklist_pre.IdSchedaXChecklist = scheda_pre.IdSchedaXChecklist;
                    istanza_checklist_pre.CfInserimento = istanza_checklist_pre.CfModifica = cf_operatore_inserimento;
                    istanza_checklist_pre.DataInserimento = istanza_checklist_pre.DataModifica = DateTime.Now;
                    istanza_checklist_provider.Save(istanza_checklist_pre);
                }

                //AGGIUNGO ALLA CHECKLIST DELLA VALIDAZIONE LE SCHEDE DOPO DELL'AUTOVALUTAZIONE
                var checklist_post_autovalutazione = GetSchedeChecklistAppaltiPostAutovalutazione();
                foreach (ChecklistGenerica check_post in checklist_post_autovalutazione)
                {
                    //CREO LA SCHEDA_X_CHECKLIST ASSOCIATA
                    var scheda_post = new SchedaXChecklist();
                    scheda_post.CfInserimento = scheda_post.CfModifica = cf_operatore_inserimento;
                    scheda_post.DataInserimento = scheda_post.DataModifica = DateTime.Now;
                    scheda_post.IdChecklistPadre = checklist_testata.IdChecklistGenerica;
                    scheda_post.IdChecklistFiglio = check_post.IdChecklistGenerica;
                    scheda_post.Ordine = ordine++; //assegno l'ordine e poi lo incremento
                    scheda_post.Obbligatorio = true;
                    scheda_post.Peso = 1.00;
                    schede_x_checklist_provider.Save(scheda_post);

                    //E LA RELATIVA ISTANZA
                    var istanza_checklist_post = new IstanzaChecklistGenerica();
                    istanza_checklist_post.IdChecklistGenerica = check_post.IdChecklistGenerica;
                    istanza_checklist_post.IdChecklistPadre = istanza_testata.IdChecklistGenerica;
                    istanza_checklist_post.IdSchedaXChecklist = scheda_post.IdSchedaXChecklist;
                    istanza_checklist_post.CfInserimento = istanza_checklist_post.CfModifica = cf_operatore_inserimento;
                    istanza_checklist_post.DataInserimento = istanza_checklist_post.DataModifica = DateTime.Now;
                    istanza_checklist_provider.Save(istanza_checklist_post);
                }

                if (db_provider == null)
                    istanza_provider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
                if (db_provider == null)
                    istanza_provider.DbProviderObj.Rollback();
            }

            return errore;
        }

        public ChecklistGenericaCollection GetSchedeChecklistAppalti()
        {
            ChecklistGenericaCollection ckc = new ChecklistGenericaCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            //Modifica fatta su scheda rapporto per distinguere quella degli anticipi 
            cmd.CommandText = @"SELECT * 
                                FROM VCHECKLIST_GENERICA 
                                WHERE 1 = 1 
	                                AND DESCRIZIONE_TIPO = 'Scheda' 
	                                AND (DESCRIZIONE LIKE ('%Scheda Ambiente%') 
		                                OR DESCRIZIONE LIKE ('%Scheda Rapporto') 

		                                OR DESCRIZIONE LIKE ('%Scheda Procedura%') 
		                                 
		                                OR DESCRIZIONE LIKE ('%Scheda Ammissibilità%') 
		                                OR DESCRIZIONE LIKE ('%Scheda Pagamenti Fattura%') 
		                                OR DESCRIZIONE LIKE ('%Scheda Pubblicità%') 

		                                ) 
                                ORDER BY ORDINE_FILTRO ";

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var c = ChecklistGenericaDAL.GetFromDatareader(DbProviderObj);
                ckc.Add(c);
            }
            DbProviderObj.Close();

            return ckc;
        }

        public ChecklistGenericaCollection GetSchedeChecklistAppaltiPreAutovalutazione()
        {
            ChecklistGenericaCollection ckc = new ChecklistGenericaCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            //Modifica fatta su scheda rapporto per distinguere quella degli anticipi 
            cmd.CommandText = @"SELECT * 
                                FROM VCHECKLIST_GENERICA 
                                WHERE 1 = 1 
	                                AND DESCRIZIONE_TIPO = 'Scheda' 
	                                AND (DESCRIZIONE LIKE ('%Scheda Ambiente%') 
		                                OR DESCRIZIONE LIKE ('%Scheda Rapporto')
		                                ) 
                                ORDER BY ORDINE_FILTRO ";

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var c = ChecklistGenericaDAL.GetFromDatareader(DbProviderObj);
                ckc.Add(c);
            }
            DbProviderObj.Close();

            return ckc;
        }

        public ChecklistGenericaCollection GetSchedeChecklistAppaltiPostAutovalutazione()
        {
            ChecklistGenericaCollection ckc = new ChecklistGenericaCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT * 
                                FROM VCHECKLIST_GENERICA 
                                WHERE 1 = 1 
	                                AND DESCRIZIONE_TIPO = 'Scheda' 
	                                AND (DESCRIZIONE LIKE ('%Scheda Ammissibilità%') 
		                                OR DESCRIZIONE LIKE ('%Scheda Pagamenti Fattura%') 
		                                OR DESCRIZIONE LIKE ('%Scheda Pubblicità%') 
		                                ) 
                                ORDER BY ORDINE_FILTRO ";

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var c = ChecklistGenericaDAL.GetFromDatareader(DbProviderObj);
                ckc.Add(c);
            }
            DbProviderObj.Close();

            return ckc;
        }

        public ChecklistGenericaCollection GetSchedeAutovalutazione()
        {
            ChecklistGenericaCollection ckc = new ChecklistGenericaCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT * 
                                FROM VCHECKLIST_GENERICA 
                                WHERE 1 = 1 
	                                AND DESCRIZIONE_TIPO = 'Scheda' 
	                                AND (DESCRIZIONE LIKE ('%Scheda Procedura%') 
		                                ) 
                                ORDER BY ORDINE_FILTRO ";

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var c = ChecklistGenericaDAL.GetFromDatareader(DbProviderObj);
                ckc.Add(c);
            }
            DbProviderObj.Close();

            return ckc;
        }

        public string GetDescrizioneTab(string descrizione_checklist)
        {
            string desc = "";

            switch (descrizione_checklist)
            {
                case "Scheda Procedura 1 - LAVORI - PROCEDURA APERTA (sotto soglia) e procedura aperta indetta ai sensi dell`art. 36, comma 2, lett. D)":
                    desc = "Scheda Procedura 1 - LAVORI";
                    break;
                case "Scheda Procedura 2 - LAVORI - PROCEDURA APERTA (sopra soglia)":
                    desc = "Scheda Procedura 2 - LAVORI";
                    break;
                case "Scheda Procedura 3 - FORNITURE E SERVIZI - PROCEDURA APERTA (sopra soglia)":
                    desc = "Scheda Procedura 3 - FORNITURE E SERVIZI";
                    break;
                case "Scheda Procedura 4 - FORNITURE E SERVIZI - PROCEDURA APERTA (sopra 40.000 Euro e fino alla soglia comunitaria)":
                    desc = "Scheda Procedura 4 - FORNITURE E SERVIZI";
                    break;
                case "Scheda Procedura 5 - FORNITURE E SERVIZI - PROCEDURA NEGOZIATA SOTTO SOGLIA CON INVITO ex art. 36, comma 2, lett. b) d. lGS. 50/2016 [procedura con invito a 5 operatori per importi sopra euro 40.00,00 e inferiori alle soglie di rilevanza comunitaria; dal 19 aprile 2019 per importi sopra euro 40.000 fino alle soglie comunitarie con affidamento diretto previa valutazione di 5 operatori economici] anche mediante MEPA, ex DECRETO SEMPLIFICAZIONI ed ex decreto 77/21":
                    desc = "Scheda Procedura 5 - FORNITURE E SERVIZI";
                    break;
                case "Scheda Procedura 6 - LAVORI - PROCEDURA INDETTA AI SENSI DELL`ART. 36, comma 2, lett. b) c) e c-bis [procedura con invito per importi superiori ad euro 40.000,00 e inferiori a euro 1.000.000,00] anche mediante MEPA":
                    desc = "Scheda Procedura 6 - LAVORI";
                    break;
                case "Scheda Procedura 7 - FORNITURE E SERVIZI -SOTTO SOGLIA-AFFIDAMENTO DIRETTO (ex art. 36, comma 2, lett. a) 50/2016, EX DECRETO SEMPLIFICAZIONI E EX DECRETO 77/21) anche mediante MEPA":
                    desc = "Scheda Procedura 7 - FORNITURE E SERVIZI";
                    break;
                case "Scheda Procedura 8 - LAVORI - PROCEDURA NEGOZIATA ex art. 36, comma 2, lett. a) [affidamento diretto] anche mediante MEPA":
                    desc = "Scheda Procedura 8 - LAVORI";
                    break;
                case "Scheda Procedura 9 - LAVORI - PROCEDURA NEGOZIATA SENZA PREVIA PUBBLICAZIONE DI UN BANDO DI GARA EX ART. 63, PER LAVORI SOPRA E SOTTO SOGLIA":
                    desc = "Scheda Procedura 9 - LAVORI";
                    break;
                case "Scheda Procedura 10 - FORNITURE E SERVIZI - PROCEDURA NEGOZIATA SENZA PREVIA PUBBLICAZIONE DI UN BANDO DI GARA EX ART. 63, PER ACQUISIZIONI DI BENI E SERVIZI":
                    desc = "Scheda Procedura 10 - FORNITURE E SERVIZI";
                    break;
                case "Scheda Procedura 11 - IN HOUSE":
                    desc = "Scheda Procedura 11 - IN HOUSE";
                    break;
                //case "Scheda procedura 12 - Ex D. LGS 163/2006":
                //    desc = "Decreto legislativo 163/2006, ";
                //    break;
                default: 
                    desc = descrizione_checklist;
                    break;
            }

            return desc;
        }

        public string GetDescrizioneSchedaXAutovalutazione(string descrizione_checklist)
        {
            string desc = "";

            switch (descrizione_checklist)
            {
                case "Scheda Procedura 1 - LAVORI - PROCEDURA APERTA (sotto soglia) e procedura aperta indetta ai sensi dell`art. 36, comma 2, lett. D)":
                    desc = "Procedura aperta Lavori  sotto soglia comunitaria, ";
                    break;
                case "Scheda Procedura 2 - LAVORI - PROCEDURA APERTA (sopra soglia)":
                    desc = "Procedura aperta Lavori  sopra soglia comunitaria, ";
                    break;
                case "Scheda Procedura 3 - FORNITURE E SERVIZI - PROCEDURA APERTA (sopra soglia)":
                    desc = "Procedura aperta Servizi e Forniture sopra soglia comunitaria, ";
                    break;
                case "Scheda Procedura 4 - FORNITURE E SERVIZI - PROCEDURA APERTA (sopra 40.000 Euro e fino alla soglia comunitaria)":
                    desc = "Procedura aperta Servizi e Forniture > 40.000 < 1.000.000, ";
                    break;
                case "Scheda Procedura 5 - FORNITURE E SERVIZI - PROCEDURA NEGOZIATA SOTTO SOGLIA CON INVITO ex art. 36, comma 2, lett. b) d. lGS. 50/2016 [procedura con invito a 5 operatori per importi sopra euro 40.00,00 e inferiori alle soglie di rilevanza comunitaria; dal 19 aprile 2019 per importi sopra euro 40.000 fino alle soglie comunitarie con affidamento diretto previa valutazione di 5 operatori economici] anche mediante MEPA, ex DECRETO SEMPLIFICAZIONI ed ex decreto 77/21":
                    desc = "Procedura negoziata Servizi e Forniture > 40.000 < soglia comunitaria, ";
                    break;
                case "Scheda Procedura 6 - LAVORI - PROCEDURA INDETTA AI SENSI DELL`ART. 36, comma 2, lett. b) c) e c-bis [procedura con invito per importi superiori ad euro 40.000,00 e inferiori a euro 1.000.000,00] anche mediante MEPA":
                    desc = "Procedura negoziata Lavori > 40.000 < 1.000.000, ";
                    break;
                case "Scheda Procedura 7 - FORNITURE E SERVIZI -SOTTO SOGLIA-AFFIDAMENTO DIRETTO (ex art. 36, comma 2, lett. a) 50/2016, EX DECRETO SEMPLIFICAZIONI E EX DECRETO 77/21) anche mediante MEPA":
                    desc = "Affidamento diretto Servizi e Forniture < 40.000, ";
                    break;
                case "Scheda Procedura 8 - LAVORI - PROCEDURA NEGOZIATA ex art. 36, comma 2, lett. a) [affidamento diretto] anche mediante MEPA":
                    desc = "Affidamento diretto Lavori < 40.000, ";
                    break;
                case "Scheda Procedura 9 - LAVORI - PROCEDURA NEGOZIATA SENZA PREVIA PUBBLICAZIONE DI UN BANDO DI GARA EX ART. 63, PER LAVORI SOPRA E SOTTO SOGLIA":
                    desc = "Procedura negoziata Lavori, ";
                    break;
                case "Scheda Procedura 10 - FORNITURE E SERVIZI - PROCEDURA NEGOZIATA SENZA PREVIA PUBBLICAZIONE DI UN BANDO DI GARA EX ART. 63, PER ACQUISIZIONI DI BENI E SERVIZI":
                    desc = "Procedura negoziata Servizi e Forniture, ";
                    break;
                case "Scheda Procedura 11 - IN HOUSE":
                    desc = "IN HOUSE, ";
                    break;
                case "Scheda procedura 12 - Ex D. LGS 163/2006":
                    desc = "Decreto legislativo 163/2006, ";
                    break;
                default:
                    desc = descrizione_checklist + ", ";
                    break;
            }

            return desc;
        }

        public TestataValidazione GeneraTestataAutovalutazione(int id_domanda_pagamento, string cf_operatore)
        {
            var tv = new TestataValidazione();

            try
            {
                this.DbProviderObj.BeginTran();

                tv.CfInserimento = cf_operatore;
                tv.DataInserimento = DateTime.Now;
                tv.CfModifica = cf_operatore;
                tv.DataModifica = DateTime.Now;
                tv.Autovalutazione = true;
                tv.IdDomandaPagamento = id_domanda_pagamento;

                this.Save(tv);
                this.DbProviderObj.Commit();

                return tv;
            }
            catch (Exception ex)
            {
                this.DbProviderObj.Rollback();
                return null;
            }
        }

        public string GeneraChecklistValidazioneStrumentiFinanziari(DbProvider db_provider, ref TestataValidazione testata, string cf_operatore_inserimento, StringNT cod_tipo_domanda)
        {
            string errore = "";
            IstanzaChecklistGenericaCollectionProvider istanza_provider;
            if (db_provider != null)
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider(db_provider);
            else
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider();

            try
            {
                if (db_provider == null)
                    istanza_provider.DbProviderObj.BeginTran();

                this.DbProviderObj = istanza_provider.DbProviderObj;
                var chklst_provider = new ChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var schede_x_checklist_provider = new SchedaXChecklistCollectionProvider(istanza_provider.DbProviderObj);
                var testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider(istanza_provider.DbProviderObj);
                var voci_x_check_provider = new VoceXChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);

                if (cod_tipo_domanda == null || cod_tipo_domanda == "")
                    throw new Exception("Tipo di domanda non valido");

                var checklist_strum_fin_coll = chklst_provider.Find("Checklist Strumenti Finanziari (" + cod_tipo_domanda + ")", false);
                if (checklist_strum_fin_coll.Count != 1)
                    throw new Exception("Checklist strumenti finanziari non trovata per la tipologia " + cod_tipo_domanda);
                var checklist_strum_fin = checklist_strum_fin_coll[0];

                var checklist_strum_fin_nuova = (ChecklistGenerica)checklist_strum_fin.CloneAsNew();
                checklist_strum_fin_nuova.IdChecklistGenerica = null;
                checklist_strum_fin_nuova.Descrizione = checklist_strum_fin_nuova.Descrizione + " - Domanda di aiuto " + testata.IdProgetto + " - Domanda di pagamento " + testata.IdDomandaPagamento;
                chklst_provider.Save(checklist_strum_fin_nuova);

                var nuova_istanza_generica = new IstanzaChecklistGenerica();
                nuova_istanza_generica.CfInserimento = cf_operatore_inserimento;
                nuova_istanza_generica.DataInserimento = DateTime.Now;
                nuova_istanza_generica.CfModifica = cf_operatore_inserimento;
                nuova_istanza_generica.DataModifica = DateTime.Now;
                nuova_istanza_generica.IdChecklistGenerica = checklist_strum_fin_nuova.IdChecklistGenerica;
                istanza_provider.Save(nuova_istanza_generica);

                var testata_x_istanza = new TestataValidazioneXIstanza();
                testata_x_istanza.CfInserimento = cf_operatore_inserimento;
                testata_x_istanza.DataInserimento = DateTime.Now;
                testata_x_istanza.CfModifica = cf_operatore_inserimento;
                testata_x_istanza.DataModifica = DateTime.Now;
                testata_x_istanza.Ordine = 1;
                testata_x_istanza.IdTestataValidazione = testata.IdTestata;
                testata_x_istanza.IdIstanzaChecklistGenerica = nuova_istanza_generica.IdIstanzaGenerica;
                testata_x_istanza_provider.Save(testata_x_istanza);

                testata.CfModifica = cf_operatore_inserimento;
                testata.DataModifica = DateTime.Now;
                this.Save(testata);

                //associo tutte le voci della checklist alla nuova checklist
                var voci_x_check_collection = voci_x_check_provider.GetStepByChecklist(checklist_strum_fin.IdChecklistGenerica, null);
                foreach (VoceXChecklistGenerica voce_x_check in voci_x_check_collection)
                {
                    var vxc_new = (VoceXChecklistGenerica)voce_x_check.CloneAsNew();
                    vxc_new.IdChecklistGenerica = checklist_strum_fin_nuova.IdChecklistGenerica;
                    vxc_new.DataInserimento = vxc_new.DataModifica = DateTime.Now;
                    vxc_new.CfInserimento = vxc_new.CfModifica = cf_operatore_inserimento;
                    voci_x_check_provider.Save(vxc_new);
                }

                if (db_provider == null)
                    istanza_provider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
                if (db_provider == null)
                    istanza_provider.DbProviderObj.Rollback();
            }

            return errore;
        }

        public string EliminaTestataACascata(DbProvider db_provider, ref TestataValidazione testata, IntNT id_modifica)
        {
            //id_modifica != null -> salvo le modifiche nelle tabelle _MODIFICHE per registro modifiche autorizzate
            string esito_eliminazione = "";

            if (db_provider != null)
                DbProviderObj = db_provider;
            else
            {
                _dbProviderObj = new DbProvider();
                _CollectionObj = new TestataValidazioneCollection(this);
            }
                
            try
            {
                if (testata == null || testata.IdTestata == null)
                    throw new Exception("Testata non esistente o non ancora salvata");

                if (db_provider == null)
                    DbProviderObj.BeginTran();

                var testata_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider(DbProviderObj);

                var istanze_testate_coll = testata_istanza_provider.Find(null, testata.IdTestata, null, null, null);
                for (int i = 0; i < istanze_testate_coll.Count; i++) //foreach (TestataValidazioneXIstanza istanza_testata in istanze_testate_coll)
                {
                    var istanza_testata = istanze_testate_coll[i];

                    string esito = testata_istanza_provider.EliminaIstanzaACascata(DbProviderObj, ref istanza_testata, id_modifica);

                    if (esito == null || esito != "")
                        throw new Exception(esito);
                }

                if (id_modifica != null)
                {
                    var testataValidazioneProvider = new TestataValidazioneModificheCollectionProvider(DbProviderObj);
                    var registro_modifiche_provider = new RegistroModificheAutorizzateCollectionProvider(DbProviderObj);

                    var testataValidazioneModifiche = new TestataValidazioneModifiche();
                    registro_modifiche_provider.CopiaTestataValidazione(testata, testataValidazioneModifiche);
                    testataValidazioneModifiche.IdModifica = id_modifica;
                    testataValidazioneProvider.Save(testataValidazioneModifiche);
                }

                Delete(testata);

                if (db_provider == null)
                    DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                if (db_provider == null)
                    DbProviderObj.Rollback();
                esito_eliminazione = ex.Message;
            }

            return esito_eliminazione;
        }

        public TestataValidazione GetTestataValidazioneDaCte(int id_domanda_pagamento)
        {
            TestataValidazione tv = null;
            string strSql = String.Format(@"SELECT * FROM CTE_TESTATA_VALIDAZIONE WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento ");
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Add(new SqlParameter("@IdDomandaPagamento", id_domanda_pagamento));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                tv = (TestataValidazioneDAL.GetFromDatareader(dbPro));;
            }
            dbPro.Close();
            return tv;
        }

        public string CopiaValidazioneAiuti(DbProvider db_provider, IntNT id_domanda_pagamento_da_copiare, ref TestataValidazione testata_validazione, string cf_operatore_inserimento)
        {
            //Metodo copiato e adattato da GeneraTestataDaPrecedente
            string errore = "";
            IstanzaChecklistGenericaCollectionProvider istanza_provider;
            if (db_provider != null)
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider(db_provider);
            else
                istanza_provider = new IstanzaChecklistGenericaCollectionProvider();

            try
            {
                if (db_provider == null)
                    istanza_provider.DbProviderObj.BeginTran();

                this.DbProviderObj = istanza_provider.DbProviderObj;
                var testata_validazione_provider = new TestataValidazioneCollectionProvider(istanza_provider.DbProviderObj);
                var testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider(istanza_provider.DbProviderObj);
                var checklist_provider = new ChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var schede_x_checklist_provider = new SchedaXChecklistCollectionProvider(istanza_provider.DbProviderObj);
                var istanza_checklist_provider = new IstanzaChecklistGenericaCollectionProvider(istanza_provider.DbProviderObj);
                var esiti_provider = new EsitoIstanzaChecklistGenericoCollectionProvider(istanza_provider.DbProviderObj);

                var testataDaCopiareCollection = testata_validazione_provider.GetUltimaRevisioneDomandaValida(id_domanda_pagamento_da_copiare);
                if (testataDaCopiareCollection == null || testataDaCopiareCollection.Count == 0)
                    throw new Exception("Non ho trovato la validazione valida per la domanda di pagamento " + id_domanda_pagamento_da_copiare);
                var testataDaCopiare = testataDaCopiareCollection[0];

                if (testataDaCopiare.SegnaturaRevisione == null || !testataDaCopiare.Approvata)
                    throw new Exception("La validazione della domanda di pagamento non risulta approvata o non è stata firmata");

                //Verifico che siano entrambe le domande un aiuto
                var dati_monitoraggioCopiare = new DatiMonitoraggioFESRCollectionProvider().Find(null, testataDaCopiare.IdProgetto)[0];
                if (!(dati_monitoraggioCopiare.IdCUPNatura == "06" || dati_monitoraggioCopiare.IdCUPNatura == "07"))
                    throw new Exception("La domanda di pagamento selezionata non è un aiuto: impossibile copiare gli esiti");

                var dati_monitoraggio = new DatiMonitoraggioFESRCollectionProvider().Find(null, testata_validazione.IdProgetto)[0];
                if (!(dati_monitoraggio.IdCUPNatura == "06" || dati_monitoraggioCopiare.IdCUPNatura == "07"))
                    throw new Exception("La domanda di pagamento non è un aiuto: impossibile copiare gli esiti da un aiuto");

                //Le checklist devono essere dello stesso tipo
                // o entrambe ANT o entrambe non ANT
                // le checklist degli aiuti sono ANT o non ANT
                if ((testata_validazione.TipoDomandaPagamento == "ANTICIPO"
                        && testataDaCopiare.TipoDomandaPagamento != "ANTICIPO")
                     ||
                     (testata_validazione.TipoDomandaPagamento != "ANTICIPO"
                        && testataDaCopiare.TipoDomandaPagamento == "ANTICIPO")
                     )
                    throw new Exception("Le domande di pagamento hanno checklist degli aiuti differenti: impossibile copiare gli esiti");

                /*
                 * NON GENERO LA TESTATA PERCHE' LA SALVO DAL METODO CHIAMANTE
                */

                //Elimino prima le istanze che ho già associate alla testata nuova
                // dovrei averne solo una in realtà da cui prendo la descrizione della nuova checklist
                var istanze_testate_coll = testata_x_istanza_provider.Find(null, testata_validazione.IdTestata, null, null, null);
                for (int i = 0; i < istanze_testate_coll.Count; i++) 
                {
                    var istanza_testata = istanze_testate_coll[i];

                    //Se una delle istanze ha una checklist vecchia non copio nulla
                    if (istanza_testata.DescrizioneChecklist.StartsWith("Revisione_Old"))
                        throw new Exception("La funzionalità non è disponibile per le vecchie checklist");

                    string esito = testata_x_istanza_provider.EliminaIstanzaACascata(DbProviderObj, ref istanza_testata, null);

                    if (esito == null || esito != "")
                        throw new Exception(esito);
                }

                //PER TUTTE LE ISTANZE DELLA TESTATA DA COPIARE
                var validazione_DaCopiare_istanze_coll = testata_x_istanza_provider.Find(null, testataDaCopiare.IdTestata, null, null, false);
                foreach (TestataValidazioneXIstanza istanza_testata_DaCopiare in validazione_DaCopiare_istanze_coll)
                {
                    //Se una delle istanze ha una checklist vecchia non copio nulla
                    if (istanza_testata_DaCopiare.DescrizioneChecklist.StartsWith("Revisione_Old"))
                        throw new Exception("La funzionalità non prevede la copia da una domanda di pagamento con le vecchie checklist");

                    //PRENDO LA CHECKLIST DELL'ISTANZA E NE FACCIO UNA COPIA
                    var checklist_padre_validazione_DaCopiare = checklist_provider.GetById(istanza_testata_DaCopiare.IdChecklistGenerica);
                    var checklist_padre_validazione_nuova = (ChecklistGenerica)checklist_padre_validazione_DaCopiare.CloneAsNew();
                    checklist_padre_validazione_nuova.IdChecklistGenerica = null;
                    checklist_padre_validazione_nuova.CfInserimento = checklist_padre_validazione_nuova.CfModifica = cf_operatore_inserimento;
                    checklist_padre_validazione_nuova.DataInserimento = checklist_padre_validazione_nuova.DataModifica = DateTime.Now;
                    //checklist_padre_validazione.MarkAsNew();
                    string descrizioneVecchia = checklist_padre_validazione_DaCopiare.Descrizione.ToString();
                    checklist_padre_validazione_nuova.Descrizione = descrizioneVecchia
                        .Substring(0, descrizioneVecchia.IndexOf(" - ")) //serve per distinguere tra gli anticipi e non 
                        + " - Domanda di aiuto " + testata_validazione.IdProgetto + " - Domanda di pagamento " + testata_validazione.IdDomandaPagamento;
                    checklist_provider.Save(checklist_padre_validazione_nuova);

                    //PRENDO L'ISTANZA CHEKLIST E NE FACCIO UNA COPIA
                    var istanza_checklist_padre_validazione_DaCopiare = istanza_checklist_provider.GetById(istanza_testata_DaCopiare.IdIstanzaChecklistGenerica);
                    var istanza_checklist_padre_validazione_nuova = (IstanzaChecklistGenerica)istanza_checklist_padre_validazione_DaCopiare.CloneAsNew();
                    istanza_checklist_padre_validazione_nuova.IdIstanzaGenerica = null;
                    istanza_checklist_padre_validazione_nuova.IdChecklistGenerica = checklist_padre_validazione_nuova.IdChecklistGenerica; //cambio la checklist associata
                    istanza_checklist_padre_validazione_nuova.CfInserimento = istanza_checklist_padre_validazione_nuova.CfModifica = cf_operatore_inserimento;
                    istanza_checklist_padre_validazione_nuova.DataInserimento = istanza_checklist_padre_validazione_nuova.DataModifica = DateTime.Now;
                    //istanza_checklist_padre_validazione.MarkAsNew();
                    istanza_checklist_provider.Save(istanza_checklist_padre_validazione_nuova);

                    //CREO LA COPIA DELLA TESTATA X ISTANZA 
                    TestataValidazioneXIstanza istanza_testata_validazione_nuova = (TestataValidazioneXIstanza)istanza_testata_DaCopiare.CloneAsNew();
                    istanza_testata_validazione_nuova.IdTestataValidazioneXIstanza = null;
                    istanza_testata_validazione_nuova.IdTestataValidazione = testata_validazione.IdTestata; //cambio la testata associata
                    istanza_testata_validazione_nuova.IdIstanzaChecklistGenerica = istanza_checklist_padre_validazione_nuova.IdIstanzaGenerica;
                    istanza_testata_validazione_nuova.CfInserimento = istanza_testata_validazione_nuova.CfModifica = cf_operatore_inserimento;
                    istanza_testata_validazione_nuova.DataInserimento = istanza_testata_validazione_nuova.DataModifica = DateTime.Now;
                    //istanza_testata_validazione.MarkAsNew();
                    testata_x_istanza_provider.Save(istanza_testata_validazione_nuova);

                    int ordine = 1;

                    //AGGIUNGO ALLA CHECKLIST DELLA VALIDAZIONE NUOVA LE SCHEDE DELLA VALIDAZIONE DA COPIARE
                    var schede_validazione_DaCopiare_coll = schede_x_checklist_provider.Find(null, istanza_testata_DaCopiare.IdChecklistGenerica, null);
                    foreach (SchedaXChecklist scheda_validazione_DaCopiare in schede_validazione_DaCopiare_coll)
                    {
                        var scheda_validazione_nuova = (SchedaXChecklist)scheda_validazione_DaCopiare.CloneAsNew();
                        scheda_validazione_nuova.IdSchedaXChecklist = null;
                        scheda_validazione_nuova.IdChecklistPadre = istanza_checklist_padre_validazione_nuova.IdChecklistGenerica; //cambio il padre associato
                        scheda_validazione_nuova.Ordine = ordine++; //cambio l'ordine e poi incremento la variabile
                        scheda_validazione_nuova.CfInserimento = scheda_validazione_nuova.CfModifica = cf_operatore_inserimento;
                        scheda_validazione_nuova.DataInserimento = scheda_validazione_nuova.DataModifica = DateTime.Now;
                        //scheda_validazione.MarkAsNew();
                        schede_x_checklist_provider.Save(scheda_validazione_nuova);

                        //PRENDO LA CHECKLIST_FIGLIA PER COPIARE L'ISTANZA E GLI ESITI
                        var checklist_figlia_validazione_DaCopiare = checklist_provider.GetById(scheda_validazione_DaCopiare.IdChecklistFiglio);
                        var istanza_checklist_figlia_validazione_DaCopiare = istanza_provider.Find(null, scheda_validazione_DaCopiare.IdChecklistFiglio, null, scheda_validazione_DaCopiare.IdChecklistPadre, scheda_validazione_DaCopiare.IdSchedaXChecklist)[0];

                        var istanza_checklist_figlia_validazione_nuova = (IstanzaChecklistGenerica)istanza_checklist_figlia_validazione_DaCopiare.CloneAsNew();
                        istanza_checklist_figlia_validazione_nuova.IdChecklistPadre = istanza_checklist_padre_validazione_nuova.IdChecklistGenerica; //cambio il padre associato
                        istanza_checklist_figlia_validazione_nuova.IdSchedaXChecklist = scheda_validazione_nuova.IdSchedaXChecklist; //cambio l'id_scheda_x_checklist associato
                        istanza_checklist_figlia_validazione_nuova.CfInserimento = istanza_checklist_figlia_validazione_nuova.CfModifica = cf_operatore_inserimento;
                        istanza_checklist_figlia_validazione_nuova.DataInserimento = istanza_checklist_figlia_validazione_nuova.DataModifica = DateTime.Now;
                        //istanza_checklist_figlia_validazione.MarkAsNew();
                        istanza_checklist_provider.Save(istanza_checklist_figlia_validazione_nuova);

                        var esiti_checklist_figlia_validazione_DaCopiare_coll = esiti_provider.Find(istanza_checklist_figlia_validazione_DaCopiare.IdIstanzaGenerica, null, null, null, istanza_checklist_figlia_validazione_DaCopiare.IdChecklistGenerica);
                        foreach (EsitoIstanzaChecklistGenerico esito_checklist_figlia_validazione_DaCopiare in esiti_checklist_figlia_validazione_DaCopiare_coll)
                        {
                            var esito_checklist_figlia_validazione_nuova = (EsitoIstanzaChecklistGenerico)esito_checklist_figlia_validazione_DaCopiare.CloneAsNew();
                            esito_checklist_figlia_validazione_nuova.IdIstanzaGenerica = istanza_checklist_figlia_validazione_nuova.IdIstanzaGenerica; //cambio l'id dell'istanza checklist associato
                            esito_checklist_figlia_validazione_nuova.CfInserimento = esito_checklist_figlia_validazione_nuova.CfModifica = cf_operatore_inserimento;
                            esito_checklist_figlia_validazione_nuova.DataInserimento = esito_checklist_figlia_validazione_nuova.DataModifica = DateTime.Now;
                            //esito_checklist_figlia_validazione.MarkAsNew();
                            esiti_provider.Save(esito_checklist_figlia_validazione_nuova);
                        }
                    }
                }

                if (db_provider == null)
                    istanza_provider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                errore = ex.Message;
                if (db_provider == null)
                    istanza_provider.DbProviderObj.Rollback();
            }

            return errore;
        }
    }
}
