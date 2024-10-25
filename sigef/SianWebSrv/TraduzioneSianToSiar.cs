using SiarLibrary;
using SiarBLL;
using System;
using System.Data;

namespace SianWebSrv
{
    /// <summary> 
    /// classe di traferimento dati sul db dopo interrogazione webservice SIAN 
    /// </summary> 
    public class TraduzioneSianToSiar
    {
        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
        SiarBLL.ComuniCollectionProvider comuni_provider = null;

        public TraduzioneSianToSiar() { }

        #region trova 

        private int TrovaComune(string tipo_ricerca, string sigla_provincia, string cap_comune, string denominazione_comune,
            string cod_provincia, string istat_comune)
        {
            if (comuni_provider == null) comuni_provider = new SiarBLL.ComuniCollectionProvider();
            if (sigla_provincia == "PS") sigla_provincia = "PU";
            SiarLibrary.ComuniCollection cc = comuni_provider.RicercaComune(tipo_ricerca, sigla_provincia, cap_comune, denominazione_comune,
                cod_provincia, istat_comune, null, null);
            if (cc.Count == 0) throw new Exception("Comune non trovato.");
            return cc[0].IdComune;
        }

        private SiarLibrary.Indirizzo TrovaIndirizzo(SiarLibrary.Indirizzo i, SiarBLL.IndirizzoCollectionProvider indirizzo_provider)
        {
            SiarLibrary.IndirizzoCollection icoll = indirizzo_provider.Find(null, i.IdComune, i.Via);
            if (icoll.Count > 0) i = icoll[0];
            return i;
        }

        private string TrovaNaturaGiuridica(string descrizione)
        {
            string retVal = null;
            SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandText = "SELECT TOP 1 COD_NATURA_GIURIDICA FROM NATURA_GIURIDICA AS N INNER JOIN TIPO_NATURA_GIURIDICA AS T ON N.TIPO_NATURA_GIURIDICA=T.TIPO_NATURA_GIURIDICA WHERE N.DESCRIZIONE LIKE '%" + descrizione + "%'";
            db.InitDatareader(cmd);
            object result = null;
            if (db.DataReader.Read()) result = db.DataReader["COD_NATURA_GIURIDICA"];
            db.Close();
            if (result != null) retVal = result.ToString();
            return retVal;
        }

        #endregion

        #region anagrafe 

        /// <summary> 
        /// funzione che interroga il ws dell'anagrafe tributaria e scrive i dati sul db 
        /// </summary> 
        /// <param name="cuaa">cuaa dell'azienda o CF della persona</param> 
        /// <param name="cfRichiedente">verifica cf del richiedente per eventuale controllo su rappresentante legale</param> 
        /// <param name="cfUser">cf della persona che interroga l'anagrafe tributaria</param> 
        /// <returns> 
        /// IdImpresa se lo scarico ha funzionato, altrimenti l'errore  
        /// </returns> 
        public string ScaricaDatiAziendaConEsito(string cuaa, string cfRichiedente, string cfUser)
        {
            try
            {
                AnagrafeTributaria Trib = new AnagrafeTributaria();
                Logging.SqlDBConfig dbconf = new SianWebSrv.Logging.SqlDBConfig();
                dbconf.ConnectionString = new SiarLibrary.DbProvider(SiarLibrary.DbProvider.DbNames.SIGEF).ConnectionString;
                Trib.ErrorLogger = new Logging.SqlErrorLogger(dbconf);
                Trib.CallLogger = new Logging.SqlMethodCallLogger(dbconf);

                AnagrafeDettagliata anag = Trib.getAnagDett(cfUser, cuaa);
                //if (anag.dataInizioAttivita == null) throw new Exception("Codice CUAA errato: nessuna azienda in attività trovata."); 
                if (string.IsNullOrEmpty(anag.partitaIva))
                {
                    // caso di caa, enti, ecc (es: 80000890428, 80019550427) 
                    if (anag.codiceFiscale.Length == 11)
                        anag.partitaIva = anag.codiceFiscale;
                    else
                        throw new Exception("L'azienda cercata non è in possesso di una partita iva valida.");
                }

                AnagrafeSintetica anagRapprLegale;
                if (!string.IsNullOrEmpty(anag.codiceFiscaleRappresentante))
                    anagRapprLegale = Trib.getAnagSint(cfUser, anag.codiceFiscaleRappresentante);
                else anagRapprLegale = (AnagrafeSintetica)anag;

                string pec_impresa = null, iscrizione_rea = null, iscrizione_registro_imprese = null, codice_inps = null;

                impresa_provider.DbProviderObj.BeginTran();
                SiarLibrary.Impresa impresa = ScriviDatiAzienda(ref anag, ref impresa_provider);
                if (impresa == null)
                    throw new Exception("Dati non validi sul server Sian. Impossibile continuare.");
                if (impresa.Attiva != null && !impresa.Attiva)
                    throw new Exception("L`impresa selezionata non è più in attività. Impossibile continuare.");

                int id_storico_ultimo = AggiornaStoricoImpresa(ref anag, impresa.IdImpresa, iscrizione_rea, iscrizione_registro_imprese, codice_inps, impresa_provider.DbProviderObj);
                int id_sede_legale_ultima = AggiornaSedeImpresa(ref anag, impresa.IdImpresa, "S", impresa_provider.DbProviderObj);
                AggiornaSedeImpresa(ref anag, impresa.IdImpresa, "D", impresa_provider.DbProviderObj);
                int id_rapprlegale_ultimo = AggiornaPersonaXImpresa(ref anagRapprLegale, impresa.IdImpresa, "R", impresa_provider.DbProviderObj);
                if (cfRichiedente != null)
                {
                    if (!(cfRichiedente.ToUpper() == anag.codiceFiscaleRappresentante.ToUpper() || cfRichiedente.ToUpper() == anag.codiceFiscale.ToUpper()))
                        throw new Exception("Il richiedente non coincide con il rappresentante legale dell`azienda. Impossibile continuare.");
                    AggiornaPersonaXImpresa(ref anagRapprLegale, impresa.IdImpresa, "D", impresa_provider.DbProviderObj);
                }

                if (id_storico_ultimo > 0 && id_sede_legale_ultima > 0 && id_rapprlegale_ultimo > 0)
                {
                    impresa.IdStoricoUltimo = id_storico_ultimo;
                    impresa.IdSedelegaleUltimo = id_sede_legale_ultima;
                    impresa.IdRapprlegaleUltimo = id_rapprlegale_ultimo;
                    impresa.DataInizioAttivita = anag.dataInizioAttivita;
                    impresa_provider.Save(impresa);
                }
                else
                    throw new Exception("Dati non validi sul server Sian. Impossibile continuare.");

                impresa_provider.DbProviderObj.Commit();
                return impresa.IdImpresa;
            }
            catch (Exception ex)
            {
                impresa_provider.DbProviderObj.Rollback();
                return ex.Message;
            }
        }

        /// <summary> 
        /// funzione che interroga il ws dell'anagrafe tributaria e scrive i dati sul db 
        /// </summary> 
        /// <param name="cuaa">cuaa dell'azienda o CF della persona</param> 
        /// <returns> 
        /// </returns> 
        public Impresa ScaricaDatiAziendaEdit2(string cuaa, string cf_richiedente, string user, Operatore operatore)
        {
            try
            {
                AnagrafeTributaria Trib = new AnagrafeTributaria();
                Logging.SqlDBConfig dbconf = new SianWebSrv.Logging.SqlDBConfig();
                dbconf.ConnectionString = new SiarLibrary.DbProvider(SiarLibrary.DbProvider.DbNames.SIGEF).ConnectionString;
                Trib.ErrorLogger = new Logging.SqlErrorLogger(dbconf);
                Trib.CallLogger = new Logging.SqlMethodCallLogger(dbconf);

                AnagrafeDettagliata anag = Trib.getAnagDett(user, cuaa);
                //if (anag.dataInizioAttivita == null) throw new Exception("Codice CUAA errato: nessuna azienda in attività trovata."); 
                if (string.IsNullOrEmpty(anag.partitaIva))
                {
                    // caso di caa, enti, ecc (es: 80000890428, 80019550427) 
                    if (anag.codiceFiscale.Length == 11) anag.partitaIva = anag.codiceFiscale;
                    else throw new Exception("L'azienda cercata non è in possesso di una partita iva valida.");
                }

                AnagrafeSintetica anagRapprLegale;
                if (!string.IsNullOrEmpty(anag.codiceFiscaleRappresentante)) anagRapprLegale = Trib.getAnagSint(user, anag.codiceFiscaleRappresentante);
                else anagRapprLegale = (AnagrafeSintetica)anag;

                // sigef: non hanno il fascicolo 
                string pec_impresa = null, iscrizione_rea = null, iscrizione_registro_imprese = null, codice_inps = null;

                impresa_provider.DbProviderObj.BeginTran();
                SiarLibrary.Impresa impresa = ScriviDatiAzienda(ref anag, ref impresa_provider);
                if (impresa == null) throw new Exception("Dati non validi sul server Sian. Impossibile continuare.");
                if (impresa.Attiva != null && !impresa.Attiva) throw new Exception("L`impresa selezionata non è più in attività. Impossibile continuare.");

                int id_storico_ultimo = AggiornaStoricoImpresa(ref anag, impresa.IdImpresa, iscrizione_rea, iscrizione_registro_imprese, codice_inps, impresa_provider.DbProviderObj);
                int id_sede_legale_ultima = AggiornaSedeImpresa(ref anag, impresa.IdImpresa, "S", impresa_provider.DbProviderObj);
                AggiornaSedeImpresa(ref anag, impresa.IdImpresa, "D", impresa_provider.DbProviderObj);
                int id_rapprlegale_ultimo = AggiornaPersonaXImpresa(ref anagRapprLegale, impresa.IdImpresa, "R", impresa_provider.DbProviderObj);
                if (cf_richiedente != null)
                {
                    if (!(cf_richiedente.ToUpper() == anag.codiceFiscaleRappresentante.ToUpper() || cf_richiedente.ToUpper() == anag.codiceFiscale.ToUpper()))
                        throw new Exception("Il richiedente non coincide con il rappresentante legale dell`azienda. Impossibile continuare.");
                    AggiornaPersonaXImpresa(ref anagRapprLegale, impresa.IdImpresa, "D", impresa_provider.DbProviderObj);
                }

                if (id_storico_ultimo > 0 && id_sede_legale_ultima > 0 && id_rapprlegale_ultimo > 0)
                {
                    impresa.IdStoricoUltimo = id_storico_ultimo;
                    impresa.IdSedelegaleUltimo = id_sede_legale_ultima;
                    impresa.IdRapprlegaleUltimo = id_rapprlegale_ultimo;
                    impresa.DataInizioAttivita = anag.dataInizioAttivita;
                    impresa_provider.Save(impresa);
                }
                else throw new Exception("Dati non validi sul server Sian. Impossibile continuare.");
                impresa_provider.DbProviderObj.Commit();

                return impresa;
            }
            catch (Exception ex)
            {
                //if (ex.Message.Contains("Servizio non disponibile"))
                //{
                    impresa_provider.DbProviderObj.Rollback();

                    var impresa = ScriviDatiAziendaEdit(cuaa, operatore);
                    return impresa;
                //}
                //else { impresa_provider.DbProviderObj.Rollback(); throw ex; }
            }
        }

        private SiarLibrary.Impresa ScriviDatiAziendaEdit(string codice_fiscale, Operatore operatore)
        {
            try
            {
                SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();

                //verifico se esiste già l'impresa per evitare imprese doppie
                var impresaCf = impresa_provider.GetByCuaa(codice_fiscale);
                if (impresaCf != null)
                {
                    //aggiunto mandato per casistiche in cui al consulente non può essere approvato il mandato alle imprese esistenti
                    var mandatoImpresaEsistente = new MandatiImpresa();
                    mandatoImpresaEsistente.IdImpresa = impresaCf.IdImpresa;
                    mandatoImpresaEsistente.IdUtenteAbilitato = operatore.Utente.IdUtente;
                    mandatoImpresaEsistente.IdOperatoreInizio = operatore.Utente.IdUtente;
                    mandatoImpresaEsistente.DataInizioValidita = DateTime.Now;
                    mandatoImpresaEsistente.DataFineValidita = DateTime.Now.AddYears(2);
                    mandatoImpresaEsistente.TipoMandato = "PSR";
                    mandatoImpresaEsistente.Attivo = true;
                    new MandatiImpresaCollectionProvider(impresa_provider.DbProviderObj).Save(mandatoImpresaEsistente);
                    return impresaCf;
                }
                    

                impresa_provider.DbProviderObj.BeginTran();
                SiarLibrary.Impresa impresa = new SiarLibrary.Impresa();

                impresa.CodiceFiscale = codice_fiscale;                
                impresa.Cuaa = codice_fiscale;
                impresa.DataInizioAttivita = DateTime.Now;              

                impresa_provider.Save(impresa);

                SiarBLL.ImpresaStoricoCollectionProvider storico_provider = new SiarBLL.ImpresaStoricoCollectionProvider(impresa_provider.DbProviderObj);

                SiarLibrary.ImpresaStorico impresaStorico = new SiarLibrary.ImpresaStorico();

                impresaStorico.RagioneSociale = " ";
                impresaStorico.DataInizioValidita = DateTime.Now;
                impresaStorico.IdImpresa = impresa.IdImpresa;

                storico_provider.Save(impresaStorico);

                impresa.IdStoricoUltimo = impresaStorico.IdStoricoImpresa;                

                impresa_provider.Save(impresa);

                //aggiunto mandato perché altrimenti l'utente non trova la ditta
                var mandatoImpresa = new MandatiImpresa();
                mandatoImpresa.IdImpresa = impresa.IdImpresa;
                mandatoImpresa.IdUtenteAbilitato = operatore.Utente.IdUtente;
                mandatoImpresa.IdOperatoreInizio = operatore.Utente.IdUtente;
                mandatoImpresa.DataInizioValidita = DateTime.Now;
                mandatoImpresa.DataFineValidita = DateTime.Now.AddYears(2);
                mandatoImpresa.TipoMandato = "PSR";
                mandatoImpresa.Attivo = true;
                new MandatiImpresaCollectionProvider(impresa_provider.DbProviderObj).Save(mandatoImpresa);

                //aggiunta ditta tra quelle da scaricare da anagrafe tributaria
                RicercaAziendaSian nuovoElemento = new RicercaAziendaSian();
                nuovoElemento.OperatoreInserimento = 1;
                nuovoElemento.DataInserimento = DateTime.Now;
                nuovoElemento.PivaControllo = codice_fiscale;
                nuovoElemento.DaControllare = true;
                new RicercaAziendaSianCollectionProvider(impresa_provider.DbProviderObj).Save(nuovoElemento);

                impresa_provider.DbProviderObj.Commit();

                impresa = new ImpresaCollectionProvider().GetById(impresa.IdImpresa);
                return impresa;
            }
            catch (Exception ex)
            {
                impresa_provider.DbProviderObj.Rollback();
                throw ex;
            }
        }

        /// <summary> 
        /// funzione che interroga il ws dell'anagrafe tributaria e scrive i dati sul db 
        /// </summary> 
        /// <param name="cuaa">cuaa dell'azienda o CF della persona</param> 
        /// <returns> 
        /// </returns> 
        public void ScaricaDatiAzienda(string cuaa, string cf_richiedente, string user)
        {
            try
            {
                AnagrafeTributaria Trib = new AnagrafeTributaria();
                Logging.SqlDBConfig dbconf = new SianWebSrv.Logging.SqlDBConfig();
                dbconf.ConnectionString = new SiarLibrary.DbProvider(SiarLibrary.DbProvider.DbNames.SIGEF).ConnectionString;
                Trib.ErrorLogger = new Logging.SqlErrorLogger(dbconf);
                Trib.CallLogger = new Logging.SqlMethodCallLogger(dbconf);

                AnagrafeDettagliata anag = Trib.getAnagDett(user, cuaa);
                //if (anag.dataInizioAttivita == null) throw new Exception("Codice CUAA errato: nessuna azienda in attività trovata."); 
                if (string.IsNullOrEmpty(anag.partitaIva))
                {
                    // caso di caa, enti, ecc (es: 80000890428, 80019550427) 
                    if (anag.codiceFiscale.Length == 11) anag.partitaIva = anag.codiceFiscale;
                    else throw new Exception("L'azienda cercata non è in possesso di una partita iva valida.");
                }

                AnagrafeSintetica anagRapprLegale;
                if (!string.IsNullOrEmpty(anag.codiceFiscaleRappresentante)) anagRapprLegale = Trib.getAnagSint(user, anag.codiceFiscaleRappresentante);
                else anagRapprLegale = (AnagrafeSintetica)anag;

                // sigef: non hanno il fascicolo 
                string pec_impresa = null, iscrizione_rea = null, iscrizione_registro_imprese = null, codice_inps = null;
                //SiarLibrary.ContoCorrenteCollection cc_agea = null; 
                //try 
                //{                     
                //FascicoloAziendale Fascicolo = new FascicoloAziendale(); 
                //Fascicolo.ErrorLogger = new Logging.SqlErrorLogger(dbconf); 
                //Fascicolo.CallLogger = new Logging.SqlMethodCallLogger(dbconf); 
                //RespAnagFascicolo2 AnagFasc = Fascicolo.AnagraficaAziendaFS10(user, cuaa); 
                //if (AnagFasc != null) 
                //{ 
                //    pec_impresa = AnagFasc.pec; 
                //    iscrizione_rea = AnagFasc.iscrizioneRea; 
                //    iscrizione_registro_imprese = AnagFasc.iscrizioneRegistroImprese; 
                //    codice_inps = AnagFasc.codiceInps; 
                //} 
                //cc_agea = Fascicolo.LeggiContiCorrenti(user, cuaa); 
                //} 
                //catch { /* non faccio nulla */ } 


                impresa_provider.DbProviderObj.BeginTran();
                SiarLibrary.Impresa impresa = ScriviDatiAzienda(ref anag, ref impresa_provider);
                if (impresa == null) throw new Exception("Dati non validi sul server Sian. Impossibile continuare.");
                if (impresa.Attiva != null && !impresa.Attiva) throw new Exception("L`impresa selezionata non è più in attività. Impossibile continuare.");

                int id_storico_ultimo = AggiornaStoricoImpresa(ref anag, impresa.IdImpresa, iscrizione_rea, iscrizione_registro_imprese, codice_inps, impresa_provider.DbProviderObj);
                int id_sede_legale_ultima = AggiornaSedeImpresa(ref anag, impresa.IdImpresa, "S", impresa_provider.DbProviderObj);
                AggiornaSedeImpresa(ref anag, impresa.IdImpresa, "D", impresa_provider.DbProviderObj);
                int id_rapprlegale_ultimo = AggiornaPersonaXImpresa(ref anagRapprLegale, impresa.IdImpresa, "R", impresa_provider.DbProviderObj);
                if (cf_richiedente != null)
                {
                    if (!(cf_richiedente.ToUpper() == anag.codiceFiscaleRappresentante.ToUpper() || cf_richiedente.ToUpper() == anag.codiceFiscale.ToUpper()))
                        throw new Exception("Il richiedente non coincide con il rappresentante legale dell`azienda. Impossibile continuare.");
                    AggiornaPersonaXImpresa(ref anagRapprLegale, impresa.IdImpresa, "D", impresa_provider.DbProviderObj);
                }

                if (id_storico_ultimo > 0 && id_sede_legale_ultima > 0 && id_rapprlegale_ultimo > 0)
                {
                    impresa.IdStoricoUltimo = id_storico_ultimo;
                    impresa.IdSedelegaleUltimo = id_sede_legale_ultima;
                    impresa.IdRapprlegaleUltimo = id_rapprlegale_ultimo;
                    impresa.DataInizioAttivita = anag.dataInizioAttivita;
                    impresa_provider.Save(impresa);
                }
                else throw new Exception("Dati non validi sul server Sian. Impossibile continuare.");
                // sigef: non hanno il fascicolo 
                // scrivo la pec sull'ultimo storico sede legale 
                //if (!string.IsNullOrEmpty(pec_impresa)) 
                //{ 
                //    SiarBLL.IndirizzarioCollectionProvider indirizzario_provider = new SiarBLL.IndirizzarioCollectionProvider(impresa_provider.DbProviderObj); 
                //    SiarLibrary.Indirizzario sede_legale = indirizzario_provider.GetById(id_sede_legale_ultima); 
                //    if (sede_legale != null) 
                //    { 
                //        sede_legale.Pec = pec_impresa.ToLower(); 
                //        indirizzario_provider.Save(sede_legale); 
                //    } 
                //} 
                // scrivo i conti correnti scaricati dal fascicolo 
                //if (cc_agea != null) 
                //{ 
                //    SiarBLL.ContoCorrenteCollectionProvider cc_provider = new SiarBLL.ContoCorrenteCollectionProvider(impresa_provider.DbProviderObj); 
                //    SiarLibrary.ContoCorrenteCollection conti_impresa = cc_provider.Find(null, impresa.IdImpresa, null, null, null, null); 
                //    foreach (SiarLibrary.ContoCorrente c in cc_agea) 
                //    { 
                //        try 
                //        { 
                //            // se non e' gia' registrato lo salvo 
                //            if (conti_impresa.SubSelect(null, null, null, c.CodPaese, c.CinEuro, c.Cin, c.Abi, c.Cab, c.Numero, null, null, null, null, null, null).Count == 0) 
                //            { 
                //                c.IdImpresa = impresa.IdImpresa; 
                //                System.Collections.Generic.Dictionary<string, object> dt = SiarLibrary.DbStaticProvider.GetDatiBancaByCC(c.Abi, c.Cab); 
                //                if (dt.Count > 0) 
                //                { 
                //                    c.Istituto = new SiarLibrary.NullTypes.StringNT(dt["Istituto"]); 
                //                    c.Agenzia = new SiarLibrary.NullTypes.StringNT(dt["Agenzia"]); 
                //                    c.IdComune = new SiarLibrary.NullTypes.IntNT(dt["IdComune"]); 
                //                    //c.Comune = new SiarLibrary.NullTypes.StringNT(dt["Comune"]); 
                //                    //c.Cap = new SiarLibrary.NullTypes.StringNT(dt["Cap"]); 
                //                    //c.Sigla = new SiarLibrary.NullTypes.StringNT(dt["Provincia"]); 
                //                } 
                //                cc_provider.Save(c); 
                //                impresa.IdContoCorrenteUltimo = c.IdContoCorrente; 
                //                impresa_provider.Save(impresa); 
                //            } 
                //        } 
                //        catch { /* non faccio nulla */ } 
                //    } 
                //} 
                impresa_provider.DbProviderObj.Commit();
            }
            catch (Exception ex) { impresa_provider.DbProviderObj.Rollback(); throw ex; }
        }

        public SiarLibrary.PersonaFisica ScaricaDatiPersonaFisica(string cf_persona, string user)
        {
            SiarBLL.PersonaFisicaCollectionProvider persona_provider = new SiarBLL.PersonaFisicaCollectionProvider();
            try
            {
                if (cf_persona == null || cf_persona.Length != 16) throw new Exception("Codice fiscale non valido.");
                AnagrafeTributaria Trib = new AnagrafeTributaria();
                Logging.SqlDBConfig dbconf = new SianWebSrv.Logging.SqlDBConfig();
                dbconf.ConnectionString = new SiarLibrary.DbProvider(SiarLibrary.DbProvider.DbNames.SIGEF).ConnectionString;
                Trib.ErrorLogger = new Logging.SqlErrorLogger(dbconf);
                Trib.CallLogger = new Logging.SqlMethodCallLogger(dbconf);

                AnagrafeSintetica anag = Trib.getAnagSint(user, cf_persona);
                persona_provider.DbProviderObj.BeginTran();
                SiarLibrary.PersonaFisica retval = persona_provider.GetById(AggiornaPersonaFisica(ref anag, persona_provider.DbProviderObj));
                persona_provider.DbProviderObj.Commit();
                return retval;
            }
            catch (Exception ex) { persona_provider.DbProviderObj.Rollback(); throw ex; }
        }

        private SiarLibrary.Impresa ScriviDatiAziendaEdit(string codice_fiscale, ref SiarBLL.ImpresaCollectionProvider impresa_provider)
        {
            SiarLibrary.Impresa impresa = new SiarLibrary.Impresa();

            impresa.CodiceFiscale = codice_fiscale;
            impresa.Cuaa = codice_fiscale;
            impresa.DataInizioAttivita = DateTime.Now;
            impresa_provider.Save(impresa);

            return impresa;
        }

        private SiarLibrary.Impresa ScriviDatiAzienda(ref AnagrafeDettagliata anagrafe, ref SiarBLL.ImpresaCollectionProvider impresa_provider)
        {
            SiarLibrary.ImpresaCollection ic = impresa_provider.GetImpresaSenzaStoricoByCuaa(anagrafe.codiceFiscale);
            SiarLibrary.Impresa impresa = null;
            foreach (SiarLibrary.Impresa i in ic)
            {
                if (anagrafe.codiceFiscale == i.Cuaa && (anagrafe.partitaIva == i.CodiceFiscale || i.CodiceFiscale == "00000000000"))
                {
                    if (i.CodiceFiscale == "00000000000")
                    {
                        i.CodiceFiscale = anagrafe.partitaIva;
                        impresa_provider.Save(i);
                    }
                    impresa = i;
                    break;
                }
            }
            //se non trovo impresa la cerco per partita iva 
            if (impresa == null)
            {
                SiarLibrary.ImpresaCollection ic_pi = impresa_provider.GetImpresaSenzaStoricoByCuaa(anagrafe.partitaIva);
                //SiarLibrary.Impresa impresa = null; 
                foreach (SiarLibrary.Impresa i in ic_pi)
                {
                    if ((anagrafe.codiceFiscale == i.Cuaa || anagrafe.partitaIva == i.Cuaa) && (anagrafe.partitaIva == i.CodiceFiscale || i.CodiceFiscale == "00000000000"))
                    {
                        if (i.CodiceFiscale == "00000000000")
                        {
                            i.CodiceFiscale = anagrafe.partitaIva;
                            impresa_provider.Save(i);
                        }
                        impresa = i;
                        break;
                    }
                }
            }


            if (impresa == null)
            {
                impresa = new SiarLibrary.Impresa();
            }
            impresa.CodiceFiscale = (string.IsNullOrEmpty(anagrafe.partitaIva) ? anagrafe.codiceFiscale : anagrafe.partitaIva);
            impresa.Cuaa = anagrafe.codiceFiscale;
            impresa.DataInizioAttivita = anagrafe.dataInizioAttivita;
            impresa_provider.Save(impresa);

            return impresa;
        }

        private int AggiornaStoricoImpresa(ref AnagrafeDettagliata anagrafe, int id_impresa, string iscrizione_rea, string iscrizione_registro_imprese,
            string codice_inps, SiarLibrary.DbProvider db)
        {
            // sistemo la ragione sociale 
            string ragione_sociale = "";
            // pulisco la ragione sociale dagli spazi vuoti 
            string[] parole_denominazione = anagrafe.denominazione.Split(' ');
            foreach (string s in parole_denominazione) { if (!string.IsNullOrEmpty(s.Trim())) ragione_sociale += s + " "; }
            // se vuota dovrebbe essere una ditta individuale 
            if (string.IsNullOrEmpty(anagrafe.denominazione)) ragione_sociale = anagrafe.cognome + " " + anagrafe.nome;
            ragione_sociale = ragione_sociale.Replace("'", "‘");
            anagrafe.denominazione = ragione_sociale.Trim();

            SiarBLL.ImpresaStoricoCollectionProvider storico_provider = new SiarBLL.ImpresaStoricoCollectionProvider(db);
            SiarLibrary.ImpresaStoricoCollection storia = storico_provider.Find(id_impresa);
            SiarLibrary.ImpresaStorico storico;
            if (storia.Count == 0)
            {
                storico = new SiarLibrary.ImpresaStorico();
                storico.IdImpresa = id_impresa;
                //storico.RagioneSociale = anagrafe.denominazione; 
                //storico_provider.Save(storico); 
            }
            else
            {
                storico = storia[0];
                if (storico.DataFineValidita == null)
                {
                    // storicizzo il vecchio 
                    storico.DataFineValidita = DateTime.Now;
                    storico_provider.Save(storico);
                }
                // ne creo uno nuovo 
                storico.MarkAsNew();
            }
            storico.DataFineValidita = null;
            storico.DataInizioValidita = DateTime.Now;
            storico.RagioneSociale = anagrafe.denominazione;
            if (!string.IsNullOrEmpty(iscrizione_rea)) storico.ReaNumero = iscrizione_rea;
            if (!string.IsNullOrEmpty(iscrizione_registro_imprese)) storico.RegistroImpreseNumero = iscrizione_registro_imprese;
            if (!string.IsNullOrEmpty(codice_inps)) storico.CodiceInps = codice_inps;
            storico_provider.Save(storico);

            return storico.IdStoricoImpresa;
        }

        private int AggiornaSedeImpresa(ref AnagrafeDettagliata anagrafe, int id_impresa, string tipo_sede, SiarLibrary.DbProvider db)
        {
            SiarBLL.IndirizzoCollectionProvider indirizzo_provider = new SiarBLL.IndirizzoCollectionProvider(db);
            SiarLibrary.NullTypes.IntNT idindirizzo = AggiornaIndirizzo(anagrafe, tipo_sede, ref indirizzo_provider);
            SiarBLL.IndirizzarioCollectionProvider indirizzario_provider = new SiarBLL.IndirizzarioCollectionProvider(db);
            SiarLibrary.IndirizzarioCollection sedi = indirizzario_provider.Find(null, null, id_impresa, tipo_sede, null, null);
            SiarLibrary.Indirizzario sede;
            if (sedi.Count == 0)
            {
                sede = new SiarLibrary.Indirizzario();
                sede.IdImpresa = id_impresa;
                sede.IdIndirizzo = idindirizzo;
                sede.CodTipoSede = tipo_sede;
                sede.FlagAttivo = true;
                indirizzario_provider.Save(sede);
            }
            else
            {
                sede = sedi[0];
                if (sede.DataFineValidita != null || sede.IdIndirizzo != idindirizzo)
                {
                    //storicizzo il vecchio indirizzario 
                    sede.DataFineValidita = DateTime.Now;
                    sede.FlagAttivo = false;
                    indirizzario_provider.Save(sede);
                    // e ne creo uno nuovo 
                    sede.MarkAsNew();
                    sede.IdIndirizzo = idindirizzo;
                    sede.DataFineValidita = null;
                    sede.DataInizioValidita = DateTime.Now;
                    sede.FlagAttivo = true;
                    indirizzario_provider.Save(sede);
                }
            }
            return sede.IdIndirizzario;
        }

        private SiarLibrary.NullTypes.IntNT AggiornaIndirizzo(AnagrafeSintetica anagrafe, string tipo_sede, ref SiarBLL.IndirizzoCollectionProvider indirizzo_provider)
        {
            SiarLibrary.Indirizzo indirizzo = new SiarLibrary.Indirizzo();
            switch (tipo_sede)
            {
                case "D":
                    #region domicilio 
                    if (string.IsNullOrEmpty(anagrafe.comuneDomicilioFiscale))
                        throw new Exception("Comune del domicilio fiscale non presente in anagrafe tributaria. Impossibile continuare.");
                    indirizzo.IdComune = TrovaComune("DENOMINAZIONE", anagrafe.provinciaDomicilioFiscale,
                        anagrafe.capDomicilioFiscale, anagrafe.comuneDomicilioFiscale, null, null);
                    indirizzo.Via = anagrafe.indirizzoDomicilioFiscale;
                    #endregion
                    break;
                case "S":
                    #region sede legale 
                    if (string.IsNullOrEmpty(anagrafe.comuneSedeLegale))
                        throw new Exception("Comune della sede legale non presente in anagrafe tributaria. Impossibile continuare.");
                    indirizzo.IdComune = TrovaComune("DENOMINAZIONE", anagrafe.provinciaSedeLegale,
                        anagrafe.capSedeLegale, anagrafe.comuneSedeLegale, null, null);
                    indirizzo.Via = anagrafe.indirizzoSedeLegale;
                    #endregion
                    break;
                case "R":
                    #region residenza 
                    if (string.IsNullOrEmpty(anagrafe.comuneResidenza))
                        throw new Exception("Comune di residenza non presente in anagrafe tributaria. Impossibile continuare.");
                    indirizzo.IdComune = TrovaComune("DENOMINAZIONE", anagrafe.provinciaResidenza,
                        anagrafe.capResidenza, anagrafe.comuneResidenza, null, null);
                    indirizzo.Via = anagrafe.indirizzoResidenza;
                    #endregion
                    break;
            }
            indirizzo = TrovaIndirizzo(indirizzo, indirizzo_provider);
            indirizzo_provider.Save(indirizzo);
            return indirizzo.IdIndirizzo;
        }

        private int AggiornaPersonaXImpresa(ref AnagrafeSintetica anagrafe, SiarLibrary.NullTypes.IntNT idimpresa, string ruolo, SiarLibrary.DbProvider dbObj)
        {
            SiarBLL.PersoneXImpreseCollectionProvider pxi_provider = new SiarBLL.PersoneXImpreseCollectionProvider(dbObj);
            int id_persona_fisica = AggiornaPersonaFisica(ref anagrafe, dbObj);
            SiarLibrary.PersoneXImpreseCollection pxicoll = pxi_provider.Find(null, null, idimpresa, ruolo, true, null);
            SiarLibrary.PersoneXImprese persona_impresa;
            if (pxicoll.Count == 0)
            {
                persona_impresa = new SiarLibrary.PersoneXImprese();
                persona_impresa.IdImpresa = idimpresa;
                persona_impresa.IdPersona = id_persona_fisica;
                persona_impresa.CodRuolo = ruolo;
                persona_impresa.DataInizio = DateTime.Now;
                persona_impresa.Attivo = true;
                pxi_provider.Save(persona_impresa);
            }
            else
            {
                persona_impresa = pxicoll[0];
                if (persona_impresa.CodiceFiscale != anagrafe.codiceFiscale || persona_impresa.IdPersona != id_persona_fisica || !persona_impresa.Attivo)
                {
                    //storicizzo il vecchio  
                    persona_impresa.DataFine = DateTime.Now;
                    persona_impresa.Attivo = false;
                    pxi_provider.Save(persona_impresa);
                    // e ne creo uno nuovo 
                    persona_impresa.MarkAsNew();
                    persona_impresa.IdPersona = id_persona_fisica;
                    persona_impresa.DataFine = null;
                    persona_impresa.DataInizio = DateTime.Now;
                    persona_impresa.Attivo = true;
                    pxi_provider.Save(persona_impresa);
                }
            }
            return persona_impresa.IdPersoneXImprese;
        }

        private int AggiornaPersonaFisica(ref AnagrafeSintetica anagrafe, SiarLibrary.DbProvider dbObj)
        {
            SiarBLL.PersonaFisicaCollectionProvider pf_provider = new SiarBLL.PersonaFisicaCollectionProvider(dbObj);
            SiarLibrary.PersonaFisicaCollection persone = pf_provider.Find(anagrafe.codiceFiscale);
            SiarLibrary.PersonaFisica persona;
            if (persone.Count == 0) persona = InserisciPersonaFisica(ref anagrafe, ref pf_provider);
            else persona = persone[0];
            if (persona.Nome == null) ModificaPersonaFisica(ref anagrafe, ref pf_provider, ref persona);

            SiarBLL.IndirizzoCollectionProvider indirizzo_provider = new SiarBLL.IndirizzoCollectionProvider(dbObj);
            SiarLibrary.NullTypes.IntNT idindirizzo = AggiornaIndirizzo(anagrafe, "R", ref indirizzo_provider);
            SiarBLL.IndirizzarioCollectionProvider indirizzario_provider = new SiarBLL.IndirizzarioCollectionProvider(dbObj);
            SiarLibrary.IndirizzarioCollection sedi = indirizzario_provider.Find(null, persona.IdPersona, null, "R", null, null);
            SiarLibrary.Indirizzario sede;
            if (sedi.Count == 0)
            {
                sede = new SiarLibrary.Indirizzario();
                sede.IdPersona = persona.IdPersona;
                sede.IdIndirizzo = idindirizzo;
                sede.CodTipoSede = "R";
                sede.FlagAttivo = true;
                indirizzario_provider.Save(sede);
            }
            else
            {
                sede = sedi[0];
                if (sede.DataFineValidita != null || sede.IdIndirizzo != idindirizzo)
                {
                    //storicizzo il vecchio indirizzario 
                    sede.DataFineValidita = DateTime.Now;
                    sede.FlagAttivo = false;
                    indirizzario_provider.Save(sede);
                    // e ne creo uno nuovo 
                    sede.MarkAsNew();
                    sede.IdIndirizzo = idindirizzo;
                    sede.DataFineValidita = null;
                    sede.FlagAttivo = true;
                    indirizzario_provider.Save(sede);
                }
            }
            return persona.IdPersona;
        }

        private SiarLibrary.PersonaFisica InserisciPersonaFisica(ref AnagrafeSintetica anagrafe, ref SiarBLL.PersonaFisicaCollectionProvider pfprov)
        {
            SiarLibrary.PersonaFisica pf = new SiarLibrary.PersonaFisica();
            pf.CodiceFiscale = anagrafe.codiceFiscale.ToUpper();
            ModificaPersonaFisica(ref anagrafe, ref pfprov, ref pf);
            return pf;
        }

        private void ModificaPersonaFisica(ref AnagrafeSintetica anagrafe, ref SiarBLL.PersonaFisicaCollectionProvider pfprov, ref SiarLibrary.PersonaFisica pf)
        {
            pf.Nome = anagrafe.nome;
            pf.Cognome = anagrafe.cognome;
            pf.Sesso = anagrafe.sesso;
            pf.DataNascita = anagrafe.dataNascita;
            SiarLibrary.Comuni c = new SiarLibrary.Comuni();
            c.Sigla = anagrafe.provinciaNascita;
            c.Denominazione = anagrafe.comuneNascita;
            pf.IdComuneNascita = TrovaComune("DENOMINAZIONE", anagrafe.provinciaNascita, null, anagrafe.comuneNascita, null, null);
            pfprov.Save(pf);
        }

        #endregion
    }
}