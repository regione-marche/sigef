using System;
using System.Configuration;
using System.IO;
using System.Linq;
using SiarLibrary;
using SiarBLL;
using System.Collections.Generic;

namespace SiarBLL
{
    public static class StrumentiFinanziariUtility
    {
        #region campi tracciato Confidi

        private static int conf_numero = 0, 
            conf_confidi = 1,
            conf_codice_pratica = 2,
            conf_rag_sociale_impresa = 3,
            conf_piva_impresa = 4,
            conf_nace = 5,
            conf_ateco2007 = 6, 
            conf_comune_impresa = 7,
            conf_prov_impresa = 8,
            conf_tipologia_credito = 9,
            conf_finalita_operazione = 10,
            conf_banca = 11,
            conf_importo_finanziamento = 12,
            conf_data_erogazione = 13,
            conf_data_finanz = 14,
            conf_scadenza_finanz = 15,
            conf_perc_garanzia = 16,
            conf_importo_garanzia_confidi = 17,
            conf_scadenza_garanzia = 18, 
            conf_importo_garanzia_fondo = 19,
            conf_impegno_fondo = 20,
            conf_regime = 21,
            conf_importo_agevolazione = 22,
            conf_rendicontazione = 23,
            conf_perdita_fondo = 24,
            conf_dimensione_impresa = 25,
            conf_importo_erogato_netto_spese = 26;

        #endregion

        #region campi tracciato Altri Soggetti Gestori

        private static int altri_id_progetto = 0,
            altri_gestore = 1,
            altri_codice_intervento = 2,
            altri_linea_intervento = 3,
            altri_codice_pratica = 4,
            altri_data_erogazione = 5,
            altri_denominazione_impresa = 6,
            altri_piva_impresa = 7,
            altri_nace = 8,
            altri_ateco2007 = 9,
            altri_istat6_comune_sede_impresa = 10,
            altri_tipologia_credito = 11, 
            altri_finalita_operazione = 12,
            altri_abi = 13,
            altri_banca = 14,
            altri_data_delibera_confidi = 15,
            altri_esl = 16,
            altri_durata_finanziamento_erogato = 17,
            altri_scadenza_finanziamento = 18,
            altri_scadenza_garanzia_gestore = 19,
            altri_percentuale_garanzia_gestore_erogata = 20,
            altri_importo_finanziamento_erogato = 21,
            altri_importo_garanzia_gestore_erogata = 22,
            altri_importo_agevolazione_erogata = 23,
            altri_regime = 24,
            altri_rendicontazione_invio_pratica = 25,
            altri_perdita_fondo_percussione_confidi = 26,
            altri_dimensione_impresa = 27,
            altri_importo_erogato_netto_spese = 28;

        #endregion

        public enum PermessiFem
        {
            Nessuno,
            Lettura,
            Modifica
        }

        public static string ImportaContrattiConfidi(DbProvider provider, int id_file, byte[] file, int id_operatore, out int contratti_nuovi, out int contratti_aggiornati)
        {
            string errore = "";
            ContrattiFemCollectionProvider contratti_provider = null;
            contratti_nuovi = 0;
            contratti_aggiornati = 0;

            try
            {
                //Gestione provider
                if (provider != null)
                    contratti_provider = new ContrattiFemCollectionProvider(provider);
                else
                {
                    contratti_provider = new ContrattiFemCollectionProvider();
                    contratti_provider.DbProviderObj.BeginTran();
                }

                var pagamenti_provider = new ContrattiFemPagamentiCollectionProvider(contratti_provider.DbProviderObj);
                var imprese_provider = new ImpresaCollectionProvider(contratti_provider.DbProviderObj);
                var imprese_storico_provider = new ImpresaStoricoCollectionProvider(contratti_provider.DbProviderObj);
                var archivio_file_provider = new ArchivioFileCollectionProvider(contratti_provider.DbProviderObj);

                var map_dimensioni_impresa = ImpresaCollectionProvider.GetMapDimensioniImprese();

                Stream stream = new MemoryStream(file);
                var file_stream = new StreamReader(stream);

                //Cerco i progetti di Confidi
                // QUESTA VA BENE SE SI VUOLE INCLUDERE I BANDI COVID DI GARBATI
                //var prog_utente_list = new ProgettoSoggettoGestoreCollectionProvider().FindOperatoreCreazioneSoggettoGestore(
                //    (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi,
                //    null,
                //    null,
                //    null,
                //    null)
                //    .ToArrayList<ProgettoSoggettoGestore>();

                // QUESTA VA BENE SE SI VUOLE ESCLUDERE I BANDI COVID DI GARBATI
                var prog_utente_list = new ProgettoSoggettoGestoreCollectionProvider()
                    .FindOperatoreCreazioneSoggettoGestore(id_operatore, false)
                    .ToArrayList<ProgettoSoggettoGestore>();

                if (prog_utente_list.Count == 0)
                    throw new Exception("Progetti di Confidi non trovati");

                do
                {
                    if (errore == "") //se ho già trovato un errore non continuo a leggere il file
                    {
                        string textLine = file_stream.ReadLine();
                        var record = textLine.Split('|');
                        DateTime dt;
                        Decimal imp;
                        ContrattiFem contratto = null;
                        ContrattiFemPagamenti contratto_pagamento;
                        var contratto_da_aggiornare = false;

                        var numero = record[conf_numero];
                        if (numero == null || numero == "")
                            continue;

                        int id_prog;
                        if (!int.TryParse(numero.Split('_')[0], out id_prog))
                            throw new Exception("Progetto " + numero.Split('_')[0] + " non trovato nel campo corrispondente");

                        var temp_list = prog_utente_list
                            .Where(p => p.IdProgettoRiferimento == id_prog)
                            .ToList<ProgettoSoggettoGestore>();
                        if (temp_list.Count != 1)
                            throw new Exception("Progetto " + id_prog + " non esistente o non di competenza");
                        var prog_sogg_gestore = temp_list[0];

                        //cerco un contratto con lo stesso numero, se è presente lo aggiorno altrimenti lo creo
                        var contratti_coll = contratti_provider.FindConfidi(numero, true, (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico, null);
                        if (contratti_coll.Count > 0)
                        {
                            contratto_da_aggiornare = true;
                            contratti_aggiornati++;

                            contratto = contratti_coll[0];
                        }
                        else
                        {
                            contratti_nuovi++;

                            contratto = new ContrattiFem();
                            contratto.OperatoreCreazione = id_operatore;
                            contratto.DataCreazione = DateTime.Now;
                            contratto.Confidi = true;
                            contratto.Numero = numero;
                            contratto.IdSoggettoGestore = (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico;

                            contratto.IdProgetto = prog_sogg_gestore.IdProgettoRiferimento;
                            contratto.IdBando = prog_sogg_gestore.IdBando;
                            contratto.IdProgettoSoggettoGestore = prog_sogg_gestore.IdProgettoSoggettoGestore;
                        }

                        contratto.OperatoreAggiornamento = id_operatore;
                        contratto.DataAggiornamento = DateTime.Now;
                        contratto.IdFile = id_file;
                        contratto.CodicePratica = record[conf_codice_pratica];

                        //Gestisco l'impresa del contratto
                        //se è presente verifico solo se devo mettere l'id_dimensione
                        //se non è presente creo le informazioni minime
                        Impresa impresa = null;
                        var ragione_sociale = record[conf_rag_sociale_impresa];
                        var piva = record[conf_piva_impresa];
                        var comune = record[conf_comune_impresa]; //per ora non lo gestisco...

                        if (!VerificaPartitaIvaBase(piva))
                            throw new Exception("Partita Iva " + piva + " non corretta: si prega di verificare");

                        string dimensione = "";
                        try
                        {
                            dimensione = record[conf_dimensione_impresa];
                        }
                        catch(Exception ex)
                        {
                            errore += "Dimensione impresa non presente nel tracciato. <br/>";
                        }

                        var impresa_find = imprese_provider.GetByCuaa(piva);
                        if (impresa_find != null && impresa_find.IdImpresa != null) 
                        {
                            impresa = impresa_find;

                            if (impresa.IdDimensione == null 
                                && dimensione != null && dimensione != "")
                            {
                                var impresa_storico = imprese_storico_provider.GetById(impresa.IdStoricoUltimo);

                                int id_dimensione;
                                if (map_dimensioni_impresa.TryGetValue(dimensione, out id_dimensione))
                                {
                                    impresa_storico.IdDimensione = id_dimensione;
                                    imprese_storico_provider.Save(impresa_storico);
                                }
                                else
                                    errore += "Dimensione impresa " + dimensione + " con formato errato. <br/>";
                            }
                        }
                        else
                        {
                            impresa = new Impresa();
                            impresa.Cuaa = piva;
                            impresa.CodiceFiscale = piva;
                            imprese_provider.Save(impresa);

                            var impresa_storico = new ImpresaStorico();
                            impresa_storico.IdImpresa = impresa.IdImpresa;
                            impresa_storico.RagioneSociale = ragione_sociale;
                            impresa_storico.DataInizioValidita = DateTime.Now;
                            
                            int id_dimensione;
                            if (map_dimensioni_impresa.TryGetValue(dimensione, out id_dimensione))
                                impresa_storico.IdDimensione = id_dimensione;
                            else
                                errore += "Dimensione impresa " + dimensione + " con formato errato. <br/>";

                            imprese_storico_provider.Save(impresa_storico);

                            impresa.IdStoricoUltimo = impresa_storico.IdStoricoImpresa;
                            imprese_provider.Save(impresa);
                        }

                        contratto.IdImpresa = impresa.IdImpresa;
                        contratto.TipologiaCredito = record[conf_tipologia_credito];
                        contratto.FinalitaOperazione = record[conf_finalita_operazione];

                        //gestisco l'importo finanziamento
                        var importo_finanziamento = record[conf_importo_finanziamento];
                        if (Decimal.TryParse(importo_finanziamento, out imp))
                            contratto.ImportoFinanziamento = imp;
                        else
                            errore += "Importo finanziamento " + importo_finanziamento + " con formato errato. <br/>";

                        //gestisco la data erogazione 
                        var data_erogazione = record[conf_data_erogazione];
                        if (data_erogazione == null || data_erogazione == "")
                            contratto.DataStipulaContratto = null;
                        else if (DateTime.TryParse(data_erogazione, out dt))
                            contratto.DataStipulaContratto = dt;
                        else
                            errore += "Data erogazione " + data_erogazione + " con formato errato. <br/>";

                        //gestisco l'importo garanzia Confidi
                        var importo_garanzia_confidi = record[conf_importo_garanzia_confidi];
                        if (Decimal.TryParse(importo_garanzia_confidi, out imp))
                            contratto.ImportoGaranziaConfidi = imp; 
                        else
                            errore += "Importo garanzia Confidi " + importo_garanzia_confidi + " con formato errato. <br/>";

                        //gestisco l'importo garanzia Fondo
                        var importo_garanzia_fondo = record[conf_importo_garanzia_fondo];
                        if (Decimal.TryParse(importo_garanzia_fondo, out imp))
                            contratto.ImportoGaranziaFondo = imp; 
                        else
                            errore += "Importo garanzia Fondo " + importo_garanzia_fondo + " con formato errato. <br/>";

                        //gestisco l'impegno Fondo Accantonamento
                        var importo_impegno_fondo = record[conf_impegno_fondo];
                        if (Decimal.TryParse(importo_impegno_fondo, out imp))
                            contratto.Importo = imp; 
                        else
                            errore += "Importo impegno Fondo " + importo_impegno_fondo + " con formato errato. <br/>";

                        contratto.Regime = record[conf_regime];

                        //gestisco Perdita Fondo per escussione Confidi 
                        // 02/03/2023 Modificato su richiesta di Edoardo Balestra via email: da conf_impegno_fondo a conf_perdita_fondo
                        var importo_perdita_fondo = record[conf_perdita_fondo]; 
                        if (Decimal.TryParse(importo_perdita_fondo, out imp))
                            contratto.PerditaFondoEscussioneConfidi = imp;
                        else
                            errore += "Importo perdita Fondo per escussione Confidi " + importo_perdita_fondo + " con formato errato. <br/>";

                        //gestisco Importo erogato al netto delle spese sostenute dalle imprese
                        string importo_erogato_netto_spese = null; 
                        try
                        {
                            importo_erogato_netto_spese = record[conf_importo_erogato_netto_spese];

                            if (Decimal.TryParse(importo_erogato_netto_spese, out imp))
                                contratto.ImportoErogatoAlNettoDelleSpese = imp;
                            else
                                errore += "Importo erogato al netto delle spese sostenute dalle imprese " + importo_erogato_netto_spese + " con formato errato. <br/>";
                        }
                        catch (Exception ex)
                        {
                            errore += "Importo erogato al netto delle spese sostenute dalle imprese non presente nel tracciato. <br/>";
                        }

                        if (errore == "") //se ho trovato un errore non cerco neanche di creare il pagamento
                        {
                            contratti_provider.Save(contratto);

                            //se il contratto è da aggiornare cerco di aggiornare il pagamento esistente, altrimenti lo creo
                            if (contratto_da_aggiornare)
                            {
                                var pagamenti_coll = pagamenti_provider.Find(null, contratto.IdContrattoFem, null, null, null);

                                if (pagamenti_coll.Count > 0)
                                {
                                    contratto_pagamento = pagamenti_coll[0];
                                }
                                else
                                {
                                    contratto_pagamento = new ContrattiFemPagamenti();
                                    contratto_pagamento.OperatoreCreazione = id_operatore;
                                    contratto_pagamento.DataCreazione = DateTime.Now;
                                    contratto_pagamento.IdContrattoFem = contratto.IdContrattoFem;
                                }
                            }
                            else
                            {
                                contratto_pagamento = new ContrattiFemPagamenti();
                                contratto_pagamento.OperatoreCreazione = id_operatore;
                                contratto_pagamento.DataCreazione = DateTime.Now;
                                contratto_pagamento.IdContrattoFem = contratto.IdContrattoFem;
                            }

                            contratto_pagamento.OperatoreAggiornamento = id_operatore;
                            contratto_pagamento.DataAggiornamento = DateTime.Now;
                            contratto_pagamento.IdImpresa = contratto.IdImpresa;
                            contratto_pagamento.IdFile = id_file;

                            if (data_erogazione == null || data_erogazione == "")
                                contratto_pagamento.Data = null;
                            else if (DateTime.TryParse(data_erogazione, out dt))
                                contratto_pagamento.Data = dt;

                            if (Decimal.TryParse(importo_impegno_fondo, out imp))
                            {
                                contratto_pagamento.Importo = imp;
                                contratto_pagamento.ImportoAmmesso = imp;
                            }

                            pagamenti_provider.Save(contratto_pagamento);
                        }
                        else
                            throw new Exception(errore);
                    }
                    else
                        throw new Exception(errore);
                } while (file_stream.Peek() != -1);

                if (provider == null && errore == "")
                    contratti_provider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                if (provider == null)
                    contratti_provider.DbProviderObj.Rollback();

                errore = ex.Message;
            }

            return errore;
        }

        public static string ImportaContrattiAltriSoggetti(DbProvider provider, int id_file, byte[] file, int id_operatore, out int contratti_nuovi, out int contratti_aggiornati)
        {
            string errore = "";
            ContrattiFemCollectionProvider contratti_provider = null;
            contratti_nuovi = 0;
            contratti_aggiornati = 0;

            try
            {
                //Gestione provider
                if (provider != null)
                    contratti_provider = new ContrattiFemCollectionProvider(provider);
                else
                {
                    contratti_provider = new ContrattiFemCollectionProvider();
                    contratti_provider.DbProviderObj.BeginTran();
                }

                var pagamenti_provider = new ContrattiFemPagamentiCollectionProvider(contratti_provider.DbProviderObj);
                var imprese_provider = new ImpresaCollectionProvider(contratti_provider.DbProviderObj);
                var imprese_storico_provider = new ImpresaStoricoCollectionProvider(contratti_provider.DbProviderObj);
                var archivio_file_provider = new ArchivioFileCollectionProvider(contratti_provider.DbProviderObj);

                var map_dimensioni_impresa = ImpresaCollectionProvider.GetMapDimensioniImprese();

                Stream stream = new MemoryStream(file);
                var file_stream = new StreamReader(stream);

                //Cerco i progetti dell'utente
                // QUESTA VA BENE SE SI VUOLE ESCLUDERE UNI.CO.
                //var prog_utente_list = new ProgettoSoggettoGestoreCollectionProvider().FindOperatoreCreazioneSoggettoGestore(
                //    null,
                //    null,
                //    null,
                //    null,
                //    id_operatore)
                //    .ToArrayList<ProgettoSoggettoGestore>();

                // QUESTA VA BENE SE SI VUOLE INCLUDERE UNI.CO.
                var prog_utente_list = new ProgettoSoggettoGestoreCollectionProvider()
                    .FindOperatoreCreazioneSoggettoGestore(id_operatore, true)
                    .ToArrayList<ProgettoSoggettoGestore>();

                if (prog_utente_list.Count == 0)
                    throw new Exception("L'utente non ha i permessi per nessun progetto");

                do
                {
                    if (errore == "") //se ho già trovato un errore non continuo a leggere il file
                    {
                        string textLine = file_stream.ReadLine();
                        var record = textLine.Split('|');
                        DateTime dt;
                        Decimal imp;
                        ContrattiFem contratto = null;
                        ContrattiFemPagamenti contratto_pagamento;
                        var contratto_da_aggiornare = false;

                        string id_prog_string = record[altri_id_progetto];
                        if (id_prog_string == null || id_prog_string == "")
                            continue;

                        int id_prog = 0;
                        if (!int.TryParse(id_prog_string, out id_prog))
                            errore += "Id progetto " + id_prog_string + " con formato errato. <br/>";

                        var temp_list = prog_utente_list
                            .Where(p => p.IdProgettoRiferimento == id_prog)
                            .ToList<ProgettoSoggettoGestore>();
                        if (temp_list.Count != 1)
                            throw new Exception("Progetto " + id_prog+ " non esistente o non di competenza"); 
                        var prog_sogg_gestore = temp_list[0];

                        var cod_pratica = record[altri_codice_pratica];
                        if (cod_pratica == null || cod_pratica == "")
                            continue;
                        var numero = id_prog + "_" + cod_pratica; //numero contratto ricavato come IdProgetto_CodicePratica da pass con Balestra

                        //cerco un contratto con lo stesso numero, se è presente lo aggiorno altrimenti lo creo
                        var contratti_coll = contratti_provider.FindConfidi(numero, null, prog_sogg_gestore.IdSoggettoGestore, null);
                        if (contratti_coll.Count > 0)
                        {
                            contratto_da_aggiornare = true;
                            contratti_aggiornati++;

                            contratto = contratti_coll[0];
                        }
                        else
                        {
                            contratti_nuovi++;

                            contratto = new ContrattiFem();
                            contratto.OperatoreCreazione = id_operatore;
                            contratto.DataCreazione = DateTime.Now;
                            contratto.Confidi = true;
                            contratto.Numero = numero;
                            contratto.CodicePratica = cod_pratica;
                            contratto.IdSoggettoGestore = prog_sogg_gestore.IdSoggettoGestore;

                            contratto.IdProgetto = prog_sogg_gestore.IdProgettoRiferimento;
                            contratto.IdBando = prog_sogg_gestore.IdBando;
                            contratto.IdProgettoSoggettoGestore = prog_sogg_gestore.IdProgettoSoggettoGestore;
                        }

                        contratto.OperatoreAggiornamento = id_operatore;
                        contratto.DataAggiornamento = DateTime.Now;
                        contratto.IdFile = id_file;

                        //Gestisco l'impresa del contratto
                        //se è presente verifico solo se devo mettere l'id_dimensione
                        //se non è presente creo le informazioni minime
                        Impresa impresa = null;
                        var ragione_sociale = record[altri_denominazione_impresa];
                        var piva = record[altri_piva_impresa];
                        var comune = record[altri_istat6_comune_sede_impresa]; //per ora non lo gestisco...
                        var dimensione = record[altri_dimensione_impresa];

                        if(!VerificaPartitaIvaBase(piva))
                            throw new Exception("Partita Iva " + piva + " non corretta: si prega di verificare");

                        var impresa_find = imprese_provider.GetByCuaa(piva);
                        if (impresa_find != null && impresa_find.IdImpresa != null)
                        {
                            impresa = impresa_find;

                            if (impresa.IdDimensione == null
                                && dimensione != null && dimensione != "")
                            {
                                var impresa_storico = imprese_storico_provider.GetById(impresa.IdStoricoUltimo);

                                int id_dimensione;
                                if (map_dimensioni_impresa.TryGetValue(dimensione, out id_dimensione))
                                {
                                    impresa_storico.IdDimensione = id_dimensione;
                                    imprese_storico_provider.Save(impresa_storico);
                                }
                                else
                                    errore += "Dimensione impresa " + dimensione + " con formato errato. <br/>";
                            }
                        }
                        else
                        {
                            impresa = new Impresa();
                            impresa.Cuaa = piva;
                            impresa.CodiceFiscale = piva;
                            imprese_provider.Save(impresa);

                            var impresa_storico = new ImpresaStorico();
                            impresa_storico.IdImpresa = impresa.IdImpresa;
                            impresa_storico.RagioneSociale = ragione_sociale;
                            impresa_storico.DataInizioValidita = DateTime.Now;

                            int id_dimensione;
                            if (map_dimensioni_impresa.TryGetValue(dimensione, out id_dimensione))
                                impresa_storico.IdDimensione = id_dimensione;
                            else
                                errore += "Dimensione impresa " + dimensione + " con formato errato. <br/>";

                            imprese_storico_provider.Save(impresa_storico);

                            impresa.IdStoricoUltimo = impresa_storico.IdStoricoImpresa;
                            imprese_provider.Save(impresa);
                        }

                        contratto.IdImpresa = impresa.IdImpresa;
                        contratto.TipologiaCredito = record[altri_tipologia_credito];
                        contratto.FinalitaOperazione = record[altri_finalita_operazione];
                        contratto.Gestore = record[altri_gestore];
                        contratto.LineaIntervento = record[altri_linea_intervento];

                        //gestisco la durata del finanziamento erogato
                        int durata;
                        var durata_finanziamento = record[altri_durata_finanziamento_erogato];
                        if (int.TryParse(durata_finanziamento, out durata))
                            contratto.DurataFinanziamentoErogato = durata;
                        else
                            errore += "Durata finanziamento erogato " + durata_finanziamento + " con formato errato. <br/>";

                        //gestisco l'importo finanziamento
                        var importo_finanziamento = record[altri_importo_finanziamento_erogato];
                        if (Decimal.TryParse(importo_finanziamento, out imp))
                            contratto.ImportoFinanziamento = imp;
                        else
                            errore += "Importo finanziamento " + importo_finanziamento + " con formato errato. <br/>";

                        //gestisco la data erogazione 
                        var data_erogazione = record[altri_data_erogazione];
                        if (data_erogazione == null || data_erogazione == "")
                            contratto.DataStipulaContratto = null;
                        else if (DateTime.TryParse(data_erogazione, out dt))
                            contratto.DataStipulaContratto = dt;
                        else
                            errore += "Data erogazione " + data_erogazione + " con formato errato. <br/>";

                        //gestisco l'importo garanzia Gestore erogata
                        var importo_garanzia_gestore = record[altri_importo_garanzia_gestore_erogata];
                        if (Decimal.TryParse(importo_garanzia_gestore, out imp))
                            contratto.ImportoGaranziaConfidi = imp;
                        else
                            errore += "Importo garanzia Gestore erogata " + importo_garanzia_gestore + " con formato errato. <br/>";

                        //gestisco l'impegno agevolazione erogata
                        var importo_agevolazione_erogata = record[altri_importo_agevolazione_erogata];
                        if (Decimal.TryParse(importo_agevolazione_erogata, out imp))
                            contratto.Importo = imp;
                        else
                            errore += "Importo agevolazione erogata " + importo_agevolazione_erogata + " con formato errato. <br/>";

                        contratto.Regime = record[altri_regime];

                        //gestisco Perdita Fondo per escussione Confidi
                        var importo_perdita_fondo = record[altri_perdita_fondo_percussione_confidi];
                        if (Decimal.TryParse(importo_perdita_fondo, out imp))
                            contratto.PerditaFondoEscussioneConfidi = imp;
                        else
                            errore += "Importo perdita Fondo per escussione Confidi " + importo_perdita_fondo + " con formato errato. <br/>";

                        //gestisco Importo erogato al netto delle spese sostenute dalle imprese
                        var importo_erogato_netto_spese = record[altri_importo_erogato_netto_spese];
                        if (Decimal.TryParse(importo_erogato_netto_spese, out imp))
                            contratto.ImportoErogatoAlNettoDelleSpese = imp;
                        else
                            errore += "Importo erogato al netto delle spese sostenute dalle imprese " + importo_erogato_netto_spese + " con formato errato. <br/>";

                        if (errore == "") //se ho trovato un errore non cerco neanche di creare il pagamento
                        {
                            contratti_provider.Save(contratto);

                            //se il contratto è da aggiornare cerco di aggiornare il pagamento esistente, altrimenti lo creo
                            if (contratto_da_aggiornare)
                            {
                                var pagamenti_coll = pagamenti_provider.Find(null, contratto.IdContrattoFem, null, null, null);

                                if (pagamenti_coll.Count > 0)
                                {
                                    contratto_pagamento = pagamenti_coll[0];
                                }
                                else
                                {
                                    contratto_pagamento = new ContrattiFemPagamenti();
                                    contratto_pagamento.OperatoreCreazione = id_operatore;
                                    contratto_pagamento.DataCreazione = DateTime.Now;
                                    contratto_pagamento.IdContrattoFem = contratto.IdContrattoFem;
                                }
                            }
                            else
                            {
                                contratto_pagamento = new ContrattiFemPagamenti();
                                contratto_pagamento.OperatoreCreazione = id_operatore;
                                contratto_pagamento.DataCreazione = DateTime.Now;
                                contratto_pagamento.IdContrattoFem = contratto.IdContrattoFem;
                            }

                            contratto_pagamento.OperatoreAggiornamento = id_operatore;
                            contratto_pagamento.DataAggiornamento = DateTime.Now;
                            contratto_pagamento.IdImpresa = contratto.IdImpresa;
                            contratto_pagamento.IdFile = id_file;

                            if (data_erogazione == null || data_erogazione == "")
                                contratto_pagamento.Data = null;
                            else if (DateTime.TryParse(data_erogazione, out dt))
                                contratto_pagamento.Data = dt;

                            if (Decimal.TryParse(importo_agevolazione_erogata, out imp))
                            {
                                contratto_pagamento.Importo = imp;
                                contratto_pagamento.ImportoAmmesso = imp;
                            }

                            pagamenti_provider.Save(contratto_pagamento);
                        }
                        else
                            throw new Exception(errore);
                    }
                    else
                        throw new Exception(errore);
                } while (file_stream.Peek() != -1);

                if (provider == null && errore == "")
                    contratti_provider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                if (provider == null)
                    contratti_provider.DbProviderObj.Rollback();

                errore = ex.Message;
            }

            return errore;
        }

        public static PermessiFem VerificaPermessiUtente(Operatore operatore, SoggettoGestoreCollectionProvider.EnumSoggettiGestore soggetto)
        {
            PermessiFem permessi = PermessiFem.Nessuno;

            if (operatore.Utente.Profilo == "Amministratore")
                permessi = PermessiFem.Modifica;
            else if (operatore.Utente.Profilo == "Operatore FEM")
            {
                var progetti_coll = new ProgettoSoggettoGestoreCollectionProvider().FindOperatoreCreazioneSoggettoGestore(
                    (int)soggetto,
                    null,
                    null,
                    null,
                    operatore.Utente.IdUtente);

                permessi = progetti_coll.Count > 0 ? PermessiFem.Modifica : PermessiFem.Nessuno;
            }
            else
                permessi = PermessiFem.Lettura;

            return permessi;
        }

        public static List<ProgettoSoggettoGestore> GetProgettiUtenteAltriSoggetti(Operatore operatore)
        {
            List<ProgettoSoggettoGestore> progetti_list = new List<ProgettoSoggettoGestore>();

            if (operatore.Utente.Profilo == "Operatore FEM")
                progetti_list = new ProgettoSoggettoGestoreCollectionProvider().FindOperatoreCreazioneSoggettoGestore(
                    null,
                    null,
                    null,
                    null,
                    operatore.Utente.IdUtente)
                    .ToArrayList<ProgettoSoggettoGestore>();
            else
            {
                progetti_list = new ProgettoSoggettoGestoreCollectionProvider().FindOperatoreCreazioneSoggettoGestore(
                    null,
                    null,
                    null,
                    null,
                    null)
                     .ToArrayList<ProgettoSoggettoGestore>();

                //Cerco ed escludo Artigiancassa e Confidi che vengono gestiti a parte
                var sog_provider = new SoggettoGestoreCollectionProvider();
                var sog_art = sog_provider.GetById((int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa);
                var sog_conf = sog_provider.GetById((int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico);

                var sog_escludere_coll = new SoggettoGestoreCollection();
                sog_escludere_coll.Add(sog_art);
                sog_escludere_coll.Add(sog_conf);

                var sog_escludere_list = sog_escludere_coll.ToArrayList<SoggettoGestore>();

                progetti_list = (from p in progetti_list
                                 where !(from s in sog_escludere_list
                                         select s.IdSoggettoGestore)
                                         .Contains(p.IdSoggettoGestore)
                                 select p)
                                .ToList<ProgettoSoggettoGestore>();
            }

            return progetti_list;
        }

        public static List<ProgettoSoggettoGestore> GetProgettiUtenteAltriSoggettiCompresoUnicoBandoVela(Operatore operatore)
        {
            List<ProgettoSoggettoGestore> progetti_list = new List<ProgettoSoggettoGestore>();

            if (operatore.Utente.Profilo == "Operatore FEM")
                progetti_list = new ProgettoSoggettoGestoreCollectionProvider()
                    .FindOperatoreCreazioneSoggettoGestoreNonPoc(operatore.Utente.IdUtente, true)
                    .ToArrayList<ProgettoSoggettoGestore>();
            else
            {
                progetti_list = new ProgettoSoggettoGestoreCollectionProvider()
                    .FindOperatoreCreazioneSoggettoGestoreNonPoc(null, true)
                    .ToArrayList<ProgettoSoggettoGestore>();
            }

            return progetti_list;
        }

        public static List<ProgettoSoggettoGestore> GetProgettiUtenteFondoPoc(Operatore operatore)
        {
            List<ProgettoSoggettoGestore> progetti_list = new List<ProgettoSoggettoGestore>();

            if (operatore.Utente.Profilo == "Operatore FEM")
                progetti_list = new ProgettoSoggettoGestoreCollectionProvider()
                    .FindOperatoreCreazioneSoggettoGestoreFondiPoc(operatore.Utente.IdUtente)
                    .ToArrayList<ProgettoSoggettoGestore>();
            else
            {
                progetti_list = new ProgettoSoggettoGestoreCollectionProvider()
                    .FindOperatoreCreazioneSoggettoGestoreFondiPoc(null)
                    .ToArrayList<ProgettoSoggettoGestore>();
            }

            return progetti_list;
        }

        //Parzialmente ricavata dal controllo presente sul Main.js, controlla solo se la piva è estera o lunga 11 o 16
        public static bool VerificaPartitaIvaBase(string piva)
        {
            if (VerificaPartitaIvaEstera(piva))
                return true;

            if (piva.Length == 11
                || piva.Length == 16)
                return true;
            else
                return false;

            /*
            if (piva.Length != 11)
                return false;

            int n_Val, n_Som1 = 0,
                n_Som2 = 0,
                lcv;
            double temp;
            var piva_array = piva.ToCharArray(); 
            for (lcv = 0; lcv < 9; lcv += 2)
            {
                n_Val = int.Parse(piva_array[lcv].ToString());
                n_Som1 += n_Val;
                n_Val = int.Parse(piva_array[lcv + 1].ToString());
                temp = n_Val / 5;
                n_Som1 += Math.Floor(temp) + (n_Val << 1) % 10;
            }
            n_Som2 = 10 - (n_Som1 % 10);
            n_Val = int.Parse(piva_array[10].ToString());
            if (n_Som2 == 10) 
                n_Som2 = 0;
            
            if (n_Som2 == n_Val) 
                return true;
            return false;
            */
        }

        private static bool VerificaPartitaIvaEstera(string piva)
        {
            if (piva.Length < 9)
                return false;

            var ctrlPE = piva.Substring(0, 3);

            if (ctrlPE == "DE "
                || ctrlPE == "GB "
                || ctrlPE == "FR "
                || ctrlPE == "BE "
                || ctrlPE == "AT "
                || ctrlPE == "NL "
                || ctrlPE == "DK "
                || ctrlPE == "ES "
                || ctrlPE == "CH "
                || ctrlPE == "IE " 
                || ctrlPE == "CZ " 
                || ctrlPE == "PL " 
                || ctrlPE == "HU " 
                || ctrlPE == "BE " 
                || ctrlPE == "MT " 
                || ctrlPE == "RO ")
                return true;

            return false;
        }
    }
}