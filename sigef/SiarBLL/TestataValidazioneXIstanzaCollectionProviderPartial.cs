using System;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;

namespace SiarBLL
{
    public partial class TestataValidazioneXIstanzaCollectionProvider : ITestataValidazioneXIstanzaProvider
    {
        public int GetProssimoOrdineXTestata(int id_testata)
        {
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT ISNULL(MAX(ORDINE), 0) + 1 
                                FROM VTESTATA_VALIDAZIONE_X_ISTANZA 
                                WHERE 1 = 1 
	                                AND ID_TESTATA_VALIDAZIONE = @ID_TESTATA ";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_TESTATA", id_testata));

            object result = DbProviderObj.ExecuteScalar(cmd);
            int.TryParse(result.ToString(), out int ordine);

            DbProviderObj.Close();

            return ordine;
        }

        public string EliminaIstanzaACascata(DbProvider db_provider, ref TestataValidazioneXIstanza istanza_testata, IntNT id_modifica)
        {
            //id_modifica != null -> salvo le modifiche nelle tabelle _MODIFICHE per registro modifiche autorizzate
            string esito_eliminazione = "";

            if (db_provider != null)
                DbProviderObj = db_provider;
            else
            {
                _dbProviderObj = new DbProvider();
                _CollectionObj = new TestataValidazioneXIstanzaCollection(this);
            }

            try
            {
                if (db_provider == null)
                    DbProviderObj.BeginTran();

                var istanza_checklist_provider = new IstanzaChecklistGenericaCollectionProvider(this.DbProviderObj);
                var checklist_provider = new ChecklistGenericaCollectionProvider(this.DbProviderObj);
                var schede_x_checklist_provider = new SchedaXChecklistCollectionProvider(this.DbProviderObj);
                var esito_istanza_provider = new EsitoIstanzaChecklistGenericoCollectionProvider(this.DbProviderObj);

                //provider per registro modifiche autorizzate
                var istanza_checklist_modifiche_provider = new IstanzaChecklistGenericaModificheCollectionProvider(this.DbProviderObj);
                var checklist_modifiche_provider = new ChecklistGenericaModificheCollectionProvider(this.DbProviderObj);
                var schede_x_checklist_modifiche_provider = new SchedaXChecklistModificheCollectionProvider(this.DbProviderObj);
                var esito_istanza_modifiche_provider = new EsitoIstanzaChecklistGenericoModificheCollectionProvider(this.DbProviderObj);
                var testata_validazione_x_istanza_modifiche_provider = new TestataValidazioneXIstanzaModificheCollectionProvider(this.DbProviderObj);
                var registro_modifiche_provider = new RegistroModificheAutorizzateCollectionProvider(this.DbProviderObj);

                //recupero tutte le entità collegate all'istanza
                var istanza_checklist_testata = istanza_checklist_provider.GetById(istanza_testata.IdIstanzaChecklistGenerica);
                var checklist_testata = checklist_provider.GetById(istanza_checklist_testata.IdChecklistGenerica);
                var schede_checklist_testata = schede_x_checklist_provider.Find(null, checklist_testata.IdChecklistGenerica, null);

                if (schede_checklist_testata.Count > 0)
                {
                    //var checklist_schede_coll = new ChecklistGenericaCollection();

                    foreach (SchedaXChecklist scheda in schede_checklist_testata)
                    {
                        var checklist_scheda = checklist_provider.GetById(scheda.IdChecklistFiglio);
                        var istanza_checklist_scheda = istanza_checklist_provider.Find(null, checklist_scheda.IdChecklistGenerica, null, checklist_testata.IdChecklistGenerica, scheda.IdSchedaXChecklist)[0];
                        var esito_istanza_scheda_coll = esito_istanza_provider.Find(istanza_checklist_scheda.IdIstanzaGenerica, null, null, null, null);

                        if (id_modifica != null)
                        {
                            var esito_istanza_scheda_modifiche_coll = new EsitoIstanzaChecklistGenericoModificheCollection();
                            foreach (EsitoIstanzaChecklistGenerico esitoIstanzaChecklistGenerico in esito_istanza_scheda_coll)
                            {
                                var esitoModifiche = new EsitoIstanzaChecklistGenericoModifiche();
                                registro_modifiche_provider.CopiaEsitoIstanzaChecklistGenerico(esitoIstanzaChecklistGenerico, esitoModifiche);
                                esitoModifiche.IdModifica = id_modifica;
                                esito_istanza_scheda_modifiche_coll.Add(esitoModifiche);
                            }
                            esito_istanza_modifiche_provider.SaveCollection(esito_istanza_scheda_modifiche_coll);

                            var istanza_checklist_scheda_modifiche = new IstanzaChecklistGenericaModifiche();
                            registro_modifiche_provider.CopiaIstanzaChecklistGenerica(istanza_checklist_scheda, istanza_checklist_scheda_modifiche);
                            istanza_checklist_scheda_modifiche.IdModifica = id_modifica;
                            istanza_checklist_modifiche_provider.Save(istanza_checklist_scheda_modifiche);
                        }

                        //elimino le singole entità collegate all'istanza a partire dai rami in fondo
                        esito_istanza_provider.DeleteCollection(esito_istanza_scheda_coll);
                        istanza_checklist_provider.Delete(istanza_checklist_scheda);

                        //elimino le checklist dopo le schede_x_checklist per chiave esterna //checklist_provider.Delete(checklist_scheda); 
                        //checklist_schede_coll.Add(checklist_scheda);
                    }

                    if (id_modifica != null)
                    {
                        var schede_checklist_modifiche_collection = new SchedaXChecklistModificheCollection();
                        foreach (SchedaXChecklist scheda_x_checklist in schede_checklist_testata)
                        {
                            var schedaModifiche = new SchedaXChecklistModifiche();
                            registro_modifiche_provider.CopiaSchedaXChecklistGenerico(scheda_x_checklist, schedaModifiche);
                            schedaModifiche.IdModifica = id_modifica;
                            schede_checklist_modifiche_collection.Add(schedaModifiche);
                        }
                        schede_x_checklist_modifiche_provider.SaveCollection(schede_checklist_modifiche_collection);
                    }

                    schede_x_checklist_provider.DeleteCollection(schede_checklist_testata);
                    //checklist_provider.DeleteCollection(checklist_schede_coll);
                }

                if (id_modifica != null)
                {
                    var testataValidazioneXIstanzaModifiche = new TestataValidazioneXIstanzaModifiche();
                    registro_modifiche_provider.CopiaTestataValidazioneXIstanza(istanza_testata, testataValidazioneXIstanzaModifiche);
                    testataValidazioneXIstanzaModifiche.IdModifica = id_modifica;
                    testata_validazione_x_istanza_modifiche_provider.Save(testataValidazioneXIstanzaModifiche);

                    var istanzaChecklistModifiche = new IstanzaChecklistGenericaModifiche();
                    registro_modifiche_provider.CopiaIstanzaChecklistGenerica(istanza_checklist_testata, istanzaChecklistModifiche);
                    istanzaChecklistModifiche.IdModifica = id_modifica;
                    istanza_checklist_modifiche_provider.Save(istanzaChecklistModifiche);

                    var checklistModifiche = new ChecklistGenericaModifiche();
                    registro_modifiche_provider.CopiaChecklistGenerica(checklist_testata, checklistModifiche);
                    checklistModifiche.IdModifica = id_modifica;
                    checklist_modifiche_provider.Save(checklistModifiche);
                }

                //alla fine cancello le entità superiori in ordine di dipendenza 
                Delete(istanza_testata);
                istanza_checklist_provider.Delete(istanza_checklist_testata);
                checklist_provider.Delete(checklist_testata);

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

        public TestataValidazioneXIstanza GeneraCopiaTestataValidazioneXIstanza(TestataValidazioneXIstanza originale, string cf_operatore)
        {
            TestataValidazioneXIstanza nuovo = new TestataValidazioneXIstanza();
            var propertyInfo = originale.GetType().GetProperties();

            foreach (var info in propertyInfo)
            {
                var propertyInfoNew = nuovo.GetType().GetProperty(info.Name);
                var value = info.GetValue(originale);
                propertyInfoNew.SetValue(nuovo, Convert.ChangeType(value, propertyInfoNew.PropertyType), null);
            }

            nuovo.IdTestataValidazioneXIstanza = null;
            nuovo.CfInserimento = nuovo.CfModifica = cf_operatore;
            nuovo.DataInserimento = nuovo.DataModifica = DateTime.Now;

            return nuovo;
        }
    }
}
