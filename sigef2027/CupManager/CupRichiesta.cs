using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml;

namespace CupManager
{
    public partial class CupRichiesta
    {
        #region COSTANTI

        private const String CODICE_NATURA_ACQUISTO_BENI = "01";
        private const String CODICE_NATURA_PRODUZIONE_ACQUISTO_SERVIZI = "02";
        private const String CODICE_NATURA_LAVORI_PUBBLICI = "03";
        private const String CODICE_NATURA_AIUTI_SOGGETTI_NO_ATTIVITA_PRODUTTIVE = "06";
        private const String CODICE_NATURA_INCENTIVI_UNITA_PRODUTTIVE = "07";
        private const String CODICE_NATURA_ACQUISTO_PARTECIPAZIONI_AZIONARIE_CONFERIMENTO_CAPITALE = "08";

        private const String CODICE_TIPOLOGIA_CORSI_FORMAZIONE = "12";
        private const String CODICE_TIPOLOGIA_PROGETTI_RICERCA = "14";

        #endregion

        private DALClass dal;
        private string usernameCUP { get; set; }
        private string passwordCUP { get; set; }
        public ResultInfo Result { get; set; }

        //private String Natura;
        //private String Tipologia;



        public CupRichiesta()
        {
            dal = new DALClass();
            usernameCUP = ConfigurationManager.AppSettings["usernameCUP"].ToString();
            passwordCUP = ConfigurationManager.AppSettings["passwordCUP"].ToString();

        }

        //test lettura campi da tracciato risposta
        public ResultInfo TestXPath()
        {
            var xresponse = new XmlDocument();
            xresponse.Load("C:\\VSSProjects\\CupSolution\\WebCUPTest\\output_10070.xml");
            string codiceCUP = null;
            string esito = null;
            string idRichiesta;
            int? idRichiestaAssegnato;
            string descEsito = null;
            string test = string.Empty;
            esito = xresponse.SelectSingleNode("//ESITO_ELABORAZIONE").InnerText;
            idRichiesta = xresponse.SelectSingleNode("//ID_RICHIESTA").InnerText;
            int p;
            //idRichiestaAssegnato = xresponse.SelectSingleNode("ID_RICHIESTA_ASSEGNATO").Value;
            idRichiestaAssegnato = int.TryParse(xresponse.SelectSingleNode("//ID_RICHIESTA_ASSEGNATO").InnerText, out p) ? (int?)p : null;
            descEsito = xresponse.SelectSingleNode("//DESCRIZIONE_ESITO_ELABORAZIONE").InnerText;
            codiceCUP = xresponse.SelectSingleNode("//CODICE_CUP").InnerText;

            var result = new ResultInfo();
            result.CodiceCUP = codiceCUP;
            result.Esito = esito + ":id_richiesta: " + idRichiesta + ": id_rich_assegnato: " + idRichiestaAssegnato;
            result.Messaggio = xresponse.OuterXml;
            Result = result;

            return result;

        }


        //public string RequestCodiceCUP(int idProgetto) 
        public ResultInfo RequestCodiceCUP(int idProgetto)
        {
            try
            {
                var richiesta = GetDatiGeneraliRichiestaCUP(idProgetto);
                string codiceCUP = null;
                string esito = null;
                string idRichiesta;
                int? idRichiestaAssegnato;
                string descEsito = null;
                string test = string.Empty;

                var logCUP = new CupRichieste();
                var callWS = new CallWS();


                string test_req = richiesta.Serialize(false);
                var req = Encoding.UTF8.GetBytes(richiesta.Serialize(false));
                callWS.Request = req;
                callWS.CallRichiestaCUP();

                if (callWS.Response.Length > 0)
                {
                    test = Encoding.UTF8.GetString(callWS.Response);
                }

                if (callWS.EsitoWS == CupManager.svcCUP.esitoElaborazioneCUP_Type.ELABORAZIONE_ESEGUITA)
                {
                    //se l'esito è positivo estraggo i dati che mi servono per popolare la classe di log
                    var xresponse = new XmlDocument();

                    if (!string.IsNullOrEmpty(test) && test.TrimStart().StartsWith("<"))
                    {
                        xresponse.LoadXml(Encoding.UTF8.GetString(callWS.Response));
                        esito = xresponse.SelectSingleNode("//ESITO_ELABORAZIONE").InnerText;
                        idRichiesta = xresponse.SelectSingleNode("//ID_RICHIESTA").InnerText;
                        int p;
                        //idRichiestaAssegnato = xresponse.SelectSingleNode("ID_RICHIESTA_ASSEGNATO").Value;
                        idRichiestaAssegnato = int.TryParse(xresponse.SelectSingleNode("//ID_RICHIESTA_ASSEGNATO").InnerText, out p) ? (int?)p : null;
                        descEsito = xresponse.SelectSingleNode("//DESCRIZIONE_ESITO_ELABORAZIONE").InnerText;
                        if (esito == "OK")
                        {
                            codiceCUP = xresponse.SelectSingleNode("//CODICE_CUP").InnerText;
                        }
                        if (esito == "KO")
                        {
                            codiceCUP = null;
                        }

                        foreach (XmlNode node in xresponse)
                        {
                            if (node.NodeType == XmlNodeType.XmlDeclaration)
                            {
                                xresponse.RemoveChild(node);
                            }
                        }
                        logCUP.ISTANZA_RISPOSTA = xresponse.OuterXml;
                        logCUP.ISTANZA_RICHIESTA = richiesta.Serialize(false);
                    }
                    else
                    {
                        esito = "KO";
                        codiceCUP = null;
                        idRichiesta = richiesta.ID_RICHIESTA.Text[0];
                        idRichiestaAssegnato = null;
                        descEsito = test;
                        logCUP.ISTANZA_RICHIESTA = richiesta.Serialize(false);
                        logCUP.ISTANZA_RISPOSTA = null;
                    }
                    logCUP.ID_PROGETTO = int.Parse(richiesta.CUP_GENERAZIONE.id_progetto);
                    logCUP.CODICE_CUP = codiceCUP;
                    logCUP.ID_RICHIESTA = int.Parse(idRichiesta);
                    logCUP.ID_RICHIESTA_ASSEGNATA_CUP = idRichiestaAssegnato;
                    logCUP.ESITO_ELABORAZIONE_CUP = esito;
                    logCUP.DESCRIZIONE_ESITO_ELABORAZIONE_CUP = descEsito;
                    logCUP.TIPO_ESITO = callWS.EsitoWS.ToString();
                    logCUP.DATA_RICHIESTA_CUP = System.DateTime.Now;
                    logCUP.DATA_INSERIMENTO = System.DateTime.Now;
                    logCUP.DATA_AGGIORNAMENTO = System.DateTime.Now;
                    //Invoco il metodo che salva nel db il flusso della richiesta
                    //InsertLogCupRichiesta(logCUP);
                }
                //Invoco il metodo che salva nel db il flusso della richiesta
                InsertLogCupRichiesta(logCUP);
                var result = new ResultInfo();
                result.CodiceCUP = codiceCUP;
                result.Esito = esito;
                result.Messaggio = descEsito;
                result.IdProgetto = idProgetto;
                Result = result;
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<ProgettiFinanziabili> GetProgettiFinanziabili()
        {
            var list = dal.GetProgettiFinanziabili();
            return list;
        }


        public void UpdateProgetto(int id_progetto, string codice_cup)
        {
            try
            {
                dal.UpdateProgetto(id_progetto, codice_cup);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal RICHIESTA_GENERAZIONE_CUP GetDatiGeneraliRichiestaCUP(int idProgetto)
        {
            var t = dal.GetDatiGeneraliRichiestaCUP(idProgetto);

            var richiesta = new RICHIESTA_GENERAZIONE_CUP();
            var cup = new CupManager.CUP_GENERAZIONE();
            var user = new USER();
            var password = new PASSWORD();
            var idrichiesta = new ID_RICHIESTA();
            var dati_progetto = new DATI_GENERALI_PROGETTO();
            var master = new MASTER();

            cup.id_progetto = idProgetto.ToString();
            cup.soggetto_titolare = "";
            cup.uo_soggetto_titolare = "";
            cup.user_titolare = "";

            master.cup_master = "";
            master.id_master = "";
            master.ragioni_collegamento = "";

            user.Text.Add(usernameCUP);
            password.Text.Add(passwordCUP);
            idrichiesta.Text.Add(idProgetto.ToString());

            dati_progetto.anno_decisione = t.anno_decisione;
            dati_progetto.natura = t.natura;
            dati_progetto.categoria = t.categoria;
            dati_progetto.settore = t.settore;
            dati_progetto.sottosettore = t.sottosettore;
            dati_progetto.tipologia = t.tipologia;

            //dati_progetto.cumulativo = DATI_GENERALI_PROGETTOCumulativo.N;
            dati_progetto.cumulativo = "N";
            dati_progetto.codifica_locale = "";
            dati_progetto.cpv1 = "";
            dati_progetto.cpv2 = "";
            dati_progetto.cpv3 = "";
            dati_progetto.cpv4 = "";
            dati_progetto.cpv5 = "";
            dati_progetto.cpv6 = "";
            dati_progetto.cpv7 = "";


            cup.DATI_GENERALI_PROGETTO = dati_progetto;
            cup.MASTER = master;

            richiesta.ID_RICHIESTA = idrichiesta;
            richiesta.USER = user;
            richiesta.PASSWORD = password;

            var localizzazione = new LOCALIZZAZIONE();
            localizzazione.stato = t.stato;
            localizzazione.regione = t.regione;
            localizzazione.provincia = t.provincia;
            localizzazione.comune = t.comune;

            cup.LOCALIZZAZIONE.Add(localizzazione);

            cup.DESCRIZIONE.Item = GetXMLNaturaInterventoCUP(dati_progetto.natura, dati_progetto.tipologia, idProgetto);

            var att_econ = new ATTIV_ECONOMICA_BENEFICIARIO_ATECO_2007();
            att_econ.sezione = t.sezione_ateco;
            att_econ.divisione = t.divisione_ateco;
            att_econ.gruppo = t.gruppo_ateco;
            att_econ.classe = t.classe_ateco;

            if (t.natura.Equals("06") || t.natura.Equals("07") || t.natura.Equals("08"))
            {
                cup.ATTIV_ECONOMICA_BENEFICIARIO_ATECO_2007 = att_econ;
            }

            var finanziamento = new FINANZIAMENTO();
            var costo_prog = t.costo_progetto.HasValue ? t.costo_progetto / 1000 : null;
            costo_prog = costo_prog.HasValue ? (decimal?)Decimal.Round(costo_prog.Value, 3) : null;
            finanziamento.costo = costo_prog.HasValue ? costo_prog.ToString().Replace(",", ".") : string.Empty;
            var finanziamento_prog = t.finanziamento_progetto.HasValue ? t.finanziamento_progetto / 1000 : null;
            finanziamento_prog = finanziamento_prog.HasValue ? (decimal?)Decimal.Round(finanziamento_prog.Value, 3) : null;
            finanziamento.finanziamento = finanziamento_prog.HasValue ? finanziamento_prog.ToString().Replace(",", ".") : string.Empty;
            finanziamento.sponsorizzazione = FINANZIAMENTOSponsorizzazione.N;
            finanziamento.finanza_progetto = FINANZIAMENTOFinanza_progetto.N;

            var tipo_cop_001 = new CODICE_TIPOLOGIA_COP_FINANZ();
            var tipo_cop_002 = new CODICE_TIPOLOGIA_COP_FINANZ();
            var tipo_cop_006 = new CODICE_TIPOLOGIA_COP_FINANZ();
            var tipo_cop_007 = new CODICE_TIPOLOGIA_COP_FINANZ();

            var parametriBando = dal.GetParametriRichiestaCup(idProgetto);
            if(parametriBando != null)
            {
                foreach(string item in parametriBando.FONTI_FINANZIAMENTO)
                {
                    var tipo_cop = new CODICE_TIPOLOGIA_COP_FINANZ();
                    tipo_cop.Text.Add(item);
                    finanziamento.CODICE_TIPOLOGIA_COP_FINANZ.Add(tipo_cop);
                }
            }
            else
            {
                tipo_cop_001.Text.Add("001");
                tipo_cop_002.Text.Add("002");
                tipo_cop_006.Text.Add("006");
              


                finanziamento.CODICE_TIPOLOGIA_COP_FINANZ.Add(tipo_cop_001);
                if (t.check_quota_reg)
                {
                    finanziamento.CODICE_TIPOLOGIA_COP_FINANZ.Add(tipo_cop_002);
                }
                finanziamento.CODICE_TIPOLOGIA_COP_FINANZ.Add(tipo_cop_006);

            }

            if (t.costo_progetto > t.finanziamento_progetto)
            {
                tipo_cop_007.Text.Add("007");
                finanziamento.CODICE_TIPOLOGIA_COP_FINANZ.Add(tipo_cop_007);
            }

            cup.FINANZIAMENTO = finanziamento;
            richiesta.CUP_GENERAZIONE = cup;
            return richiesta;
        }


        internal void InsertLogCupRichiesta(CupRichieste cupRichiesta)
        {
            dal.InsertLogCupRichieste(cupRichiesta);
        }


        internal object GetXMLNaturaInterventoCUP(string cod_natura, string cod_tipologia, int idProgetto)
        {
            object xmlNode = null;
            string node = string.Empty;
            var parametriBando = dal.GetParametriRichiestaCup(idProgetto);
            string strum_progr = "99";
            string desc_strum_progr = dal.GetStrumentoProgrammazione(idProgetto);
            if(parametriBando != null)
            {
                strum_progr = parametriBando.COD_STRUMENTO_PROGRAMMAZIONE;
                if(parametriBando.COD_STRUMENTO_PROGRAMMAZIONE == "99")
                {
                    desc_strum_progr = parametriBando.DESC_STRUMENTO_PROGRAMMAZIONE;
                }
                else
                {
                    desc_strum_progr = "";
                }
                
            }
            switch (cod_natura)
            {
                case CODICE_NATURA_ACQUISTO_BENI: //ACQUISTO_BENI
                    var acq_beni = new ACQUISTO_BENI();
                    var desc_beni = dal.GetDescrizioneCUPAcquistoBeni(idProgetto);
                    //codice popolamento dati per acquisto beni
                    acq_beni.nome_str_infrastr = desc_beni.nome_stru_infrastr;
                    //acq_beni.tipo_ind_area_rifer = (ACQUISTO_BENITipo_ind_area_rifer)Enum.Parse(typeof(ACQUISTO_BENITipo_ind_area_rifer), GetTipoIndirizzoDescCUP(desc_beni.ind_area_rif));
                    acq_beni.tipo_ind_area_rifer = GetTipoIndirizzoDescCUP(desc_beni.ind_area_rif);
                    acq_beni.ind_area_rifer = desc_beni.ind_area_rif;
                    acq_beni.strum_progr = strum_progr;
                    acq_beni.desc_strum_progr = desc_strum_progr;
                    acq_beni.bene = desc_beni.bene;
                    acq_beni.altre_informazioni = "";

                    xmlNode = acq_beni;
                    break;
                case CODICE_NATURA_PRODUZIONE_ACQUISTO_SERVIZI: //CODICE_NATURA_PRODUZIONE_ACQUISTO_SERVIZI
                    switch (cod_tipologia)
                    {
                        case CODICE_TIPOLOGIA_CORSI_FORMAZIONE:
                            var servizi_formazione = new REALIZZ_ACQUISTO_SERVIZI_FORMAZIONE();
                            //DA RIVEDERE IN BASE AI DATI NECESSARI PER LA FORMAZIONE
                            //popolamento dati
                            var serv_formazione = dal.GetDescrizioneCUPRealizzAcquistoServiziFormazione(idProgetto);
                            servizi_formazione.denom_progetto = serv_formazione.denom_progetto;
                            servizi_formazione.obiett_corso = serv_formazione.obiett_corso;
                            servizi_formazione.mod_intervento_frequenza = serv_formazione.mod_intervento_frequenza;
                            servizi_formazione.denom_ente_corso = serv_formazione.denom_ente_corso;
                            servizi_formazione.tipo_ind_area_rifer = GetTipoIndirizzoDescCUP(serv_formazione.ind_area_rif);
                            servizi_formazione.ind_area_rifer = serv_formazione.ind_area_rif;
                            servizi_formazione.strum_progr = strum_progr;
                            servizi_formazione.desc_strum_progr = desc_strum_progr;
                            servizi_formazione.altre_informazioni = "";
                            xmlNode = servizi_formazione;
                            break;
                        case CODICE_TIPOLOGIA_PROGETTI_RICERCA:
                            var servizi_ricerca = new REALIZZ_ACQUISTO_SERVIZI_RICERCA();
                            //popolamento dati
                            var serv_ricerca = dal.GetDescrizioneCUPRealizzAcquistoServiziRicerca(idProgetto);
                            servizi_ricerca.denominazione_progetto = serv_ricerca.denominazione_progetto;
                            servizi_ricerca.descrizione_intervento = serv_ricerca.descrizione_intervento;
                            servizi_ricerca.ente = serv_ricerca.ente;
                            //servizi_ricerca.tipo_ind_area_rifer = (REALIZZ_ACQUISTO_SERVIZI_RICERCATipo_ind_area_rifer)Enum.Parse(typeof(REALIZZ_ACQUISTO_SERVIZI_RICERCATipo_ind_area_rifer), GetTipoIndirizzoDescCUP(serv_ricerca.ind_area_rifer));
                            servizi_ricerca.tipo_ind_area_rifer = GetTipoIndirizzoDescCUP(serv_ricerca.ind_area_rif);
                            servizi_ricerca.ind_area_rifer = serv_ricerca.ind_area_rif;
                            servizi_ricerca.strum_progr = strum_progr;
                            servizi_ricerca.desc_strum_progr = desc_strum_progr;
                            servizi_ricerca.altre_informazioni = "";

                            xmlNode = servizi_ricerca;
                            break;
                        default:
                            var servizi_no_form_ricerca = new REALIZZ_ACQUISTO_SERVIZI_NO_FORMAZIONE_RICERCA();
                            //popolamento dati
                            var serv_no_ricerca = dal.GetDescrizioneCUPRealizzAcquistoNoFormazioneRicerca(idProgetto);
                            servizi_no_form_ricerca.nome_str_infrastr = serv_no_ricerca.nome_stru_infrastr;
                            //servizi_no_form_ricerca.tipo_ind_area_rifer = (REALIZZ_ACQUISTO_SERVIZI_NO_FORMAZIONE_RICERCATipo_ind_area_rifer)Enum.Parse(typeof(REALIZZ_ACQUISTO_SERVIZI_NO_FORMAZIONE_RICERCATipo_ind_area_rifer), GetTipoIndirizzoDescCUP(serv_no_ricerca.ind_area_rif));
                            servizi_no_form_ricerca.tipo_ind_area_rifer = GetTipoIndirizzoDescCUP(serv_no_ricerca.ind_area_rif);
                            servizi_no_form_ricerca.ind_area_rifer = serv_no_ricerca.ind_area_rif;
                            servizi_no_form_ricerca.servizio = serv_no_ricerca.servizio;
                            servizi_no_form_ricerca.strum_progr = strum_progr;
                            servizi_no_form_ricerca.desc_strum_progr = desc_strum_progr;
                            servizi_no_form_ricerca.altre_informazioni = "";

                            xmlNode = servizi_no_form_ricerca;
                            break;
                    }
                    break;
                case CODICE_NATURA_LAVORI_PUBBLICI: //LAVORI_PUBBLICI
                    var lavori_pubblici = new LAVORI_PUBBLICI();
                    //popolamento dati
                    var lp = dal.GetDescrizioneCUPLavoriPubblici(idProgetto);
                    lavori_pubblici.descrizione_intervento = lp.descrizione_intervento;
                    lavori_pubblici.nome_str_infrastr = lp.nome_stru_infrastr;
                    //lavori_pubblici.tipo_ind_area_rifer = (LAVORI_PUBBLICITipo_ind_area_rifer)Enum.Parse(typeof(LAVORI_PUBBLICITipo_ind_area_rifer), GetTipoIndirizzoDescCUP(lp.ind_area_rif));
                    lavori_pubblici.tipo_ind_area_rifer = GetTipoIndirizzoDescCUP(lp.ind_area_rif);
                    lavori_pubblici.ind_area_rifer = lp.ind_area_rif;
                    lavori_pubblici.str_infrastr_unica = lp.str_infrastr_unica == "N" ? LAVORI_PUBBLICIStr_infrastr_unica.NO : LAVORI_PUBBLICIStr_infrastr_unica.SI;
                    lavori_pubblici.strum_progr = strum_progr;
                    lavori_pubblici.desc_strum_progr = desc_strum_progr;
                    lavori_pubblici.altre_informazioni = "";

                    xmlNode = lavori_pubblici;
                    break;
                case CODICE_NATURA_AIUTI_SOGGETTI_NO_ATTIVITA_PRODUTTIVE: //AIUTI_SOGGETTI_NO_ATTIVITA_PRODUTTIVE
                    var conc_no_prod = new CONCESSIONE_CONTRIBUTI_NO_UNITA_PRODUTTIVE();
                    //popolamento dati
                    var ccnp = dal.GetDescrizioneCUPConcessioneContributiNoUnitaProduttive(idProgetto);
                    conc_no_prod.beneficiario = ccnp.beneficiario;
                    conc_no_prod.desc_intervento = ccnp.desc_intervento;
                    conc_no_prod.struttura = ccnp.beneficiario;
                    //conc_no_prod.tipo_ind_area_rifer = (CONCESSIONE_CONTRIBUTI_NO_UNITA_PRODUTTIVETipo_ind_area_rifer)Enum.Parse(typeof(CONCESSIONE_CONTRIBUTI_NO_UNITA_PRODUTTIVETipo_ind_area_rifer), GetTipoIndirizzoDescCUP(ccnp.ind_area_rif));
                    conc_no_prod.tipo_ind_area_rifer = GetTipoIndirizzoDescCUP(ccnp.ind_area_rif);
                    conc_no_prod.ind_area_rifer = ccnp.ind_area_rif;
                    conc_no_prod.partita_iva = ccnp.partita_iva;
                    conc_no_prod.strum_progr = ccnp.struttura;
                    conc_no_prod.strum_progr = strum_progr;
                    conc_no_prod.desc_strum_progr = desc_strum_progr;
                    conc_no_prod.altre_informazioni = "";

                    xmlNode = conc_no_prod;
                    break;
                case CODICE_NATURA_INCENTIVI_UNITA_PRODUTTIVE: //INCENTIVI_UNITA_PRODUTTIVE
                    var inc_unita_prod = new CONCESSIONE_INCENTIVI_UNITA_PRODUTTIVE();
                    //popolamento dati
                    var cip = dal.GetDescrizioneCUPConcessioneIncentiviUnitaProduttive(idProgetto);
                    inc_unita_prod.denominazione_impresa_stabilimento = cip.denominazione_impresa_stabilimento;
                    inc_unita_prod.descrizione_intervento = cip.descrizione_intervento;
                    //inc_unita_prod.tipo_ind_area_rifer = (CONCESSIONE_INCENTIVI_UNITA_PRODUTTIVETipo_ind_area_rifer)Enum.Parse(typeof(CONCESSIONE_INCENTIVI_UNITA_PRODUTTIVETipo_ind_area_rifer), GetTipoIndirizzoDescCUP(cip.ind_area_rifer));
                    inc_unita_prod.tipo_ind_area_rifer = GetTipoIndirizzoDescCUP(cip.ind_area_rif);
                    inc_unita_prod.ind_area_rifer = cip.ind_area_rif;
                    inc_unita_prod.partita_iva = cip.partita_iva;
                    inc_unita_prod.strum_progr = strum_progr;
                    inc_unita_prod.desc_strum_progr = desc_strum_progr;
                    inc_unita_prod.altre_informazioni = "";

                    xmlNode = inc_unita_prod;
                    break;
                case CODICE_NATURA_ACQUISTO_PARTECIPAZIONI_AZIONARIE_CONFERIMENTO_CAPITALE: //PARTECIPAZIONI_AZIONARIE_CONFERIMENTO_CAPITALE
                    var part_az = new PARTECIP_AZIONARIE_CONFERIM_CAPITALE();
                    //popolamento dati
                    var pac = dal.GetDescrizioneCUPPartecipAzionarieConferimCapitale(idProgetto);
                    part_az.finalita = pac.finalita;
                    part_az.ind_area_rifer = pac.ind_area_rif;
                    //part_az.tipo_ind_area_rifer = (PARTECIP_AZIONARIE_CONFERIM_CAPITALETipo_ind_area_rifer)Enum.Parse(typeof(PARTECIP_AZIONARIE_CONFERIM_CAPITALETipo_ind_area_rifer), GetTipoIndirizzoDescCUP(pac.ind_area_rif));
                    part_az.tipo_ind_area_rifer = GetTipoIndirizzoDescCUP(pac.ind_area_rif);
                    part_az.partita_iva = pac.partita_iva;
                    part_az.ragione_sociale = pac.ragione_sociale;
                    part_az.strum_progr = strum_progr;
                    part_az.desc_strum_progr = desc_strum_progr;
                    part_az.altre_informazioni = "";

                    xmlNode = part_az;
                    break;
                default:
                    throw new Exception("Codice NATURA non Valorizzato correttamente. Valori ammessi 01-02-03-06-07-08");
            }
            return xmlNode;
        }


        internal string GetTipoIndirizzoDescCUP(string indirizzo)
        {
            string result;
            if (indirizzo.Length >= 3 && indirizzo.Substring(0, 3).Equals("via"))
                result = "01";
            else if (indirizzo.Length >= 5 && indirizzo.Substring(0, 5).Equals("viale"))
                result = "02";
            else if (indirizzo.Length >= 6 && indirizzo.Substring(0, 6).Equals("piazza"))
                result = "03";
            else if (indirizzo.Length >= 5 && indirizzo.Substring(0, 5).Equals("corso"))
                result = "04";
            else
                result = "05";
            return result;
        }
    }
}
