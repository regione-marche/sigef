using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using SiarBLL;
using SiarLibrary.Extensions;

namespace SiarLibrary
{
    public class Protocollo //: IDisposable
    {
        //SiarBLL.paleoWebService.PaleoServiceClient ws;
        SiarBLL.paleoWebService.PaleoService2Client ws;
        SiarBLL.paleoWebService.OperatorePaleo operatore_paleo;
        SiarBLL.paleoWebService.File documento;
        System.Collections.ArrayList allegati;
        //SiarBLL.paleoWebService.SoggettiXml corrispondenti; //, corrispondentiCC;
        SiarBLL.paleoWebService.SoggettiXml mittente;
        SiarBLL.paleoWebService.SoggettiXml destinatario;
        SiarBLL.paleoWebService.SoggettiXml destinatari;
        SiarBLL.paleoWebService.TrasmissioneUtente[] trasmissioneUtenti;

        Xconfig configurazione_ws;

        private RegistroDiProtocollo registro_selezionato;

        public enum RegistroDiProtocollo { GRM, ACF, CEI, CTC, DDS, EFR, INF, IRE, ITE, TPL }

        public static int LimiteAllegatiPaleo = 99;

        public Protocollo(RegistroDiProtocollo registro)
        {
            //#if(DEBUG)
            //            registro = RegistroDiProtocollo.GRM;
            //#endif
            CaricaWebService(registro);
        }

        public Protocollo()
        {
            CaricaWebService(RegistroDiProtocollo.GRM);
        }

        public Protocollo(string cod_ente_bando)
        {
            CaricaWebService(cod_ente_bando.Replace("RM_", ""));
        }

        private void CaricaWebService(string codice_uo)
        {
            configurazione_ws = new SiarBLL.XconfigCollectionProvider().GetById("WSPaleo" + codice_uo);
            if (configurazione_ws == null) throw new Exception("Il registro di protocollo cercato non e' stato caricato. Impossibile continuare.");
            ws = new SiarBLL.paleoWebService.PaleoService2Client(configurazione_ws.WsBinding);
            ws.Endpoint.Address = new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["WsPaleoUrl"]);
            if (!configurazione_ws.Attivo) throw new SiarException(TextErrorCodes.RegistroProtocolloNonAttivo);
            Login();
        }

        private void CaricaWebServiceProtocolloEsistente(string codice_uo)
        {
            configurazione_ws = new SiarBLL.XconfigCollectionProvider().GetById("WSPaleo" + codice_uo);
            if (configurazione_ws == null)
            {
                configurazione_ws = new SiarBLL.XconfigCollectionProvider().GetById("WSPaleo");
                if (configurazione_ws == null)
                    throw new Exception("Il registro di protocollo cercato non e' stato caricato. Impossibile continuare.");
            }

            ws = new SiarBLL.paleoWebService.PaleoService2Client(configurazione_ws.WsBinding);
            ws.Endpoint.Address = new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["WsPaleoUrl"]);
            if (!configurazione_ws.Attivo) throw new SiarException(TextErrorCodes.RegistroProtocolloNonAttivo);
            Login();
        }


        private void CaricaWebService(RegistroDiProtocollo registro)
        {
            registro_selezionato = registro;
            switch (registro)
            {
                case RegistroDiProtocollo.GRM:
                    configurazione_ws = new SiarBLL.XconfigCollectionProvider().GetById("WSPaleo");
                    if (configurazione_ws == null) throw new Exception("Il registro di protocollo cercato non e' stato caricato. Impossibile continuare.");
                    ws = new SiarBLL.paleoWebService.PaleoService2Client(configurazione_ws.WsBinding);
                    ws.Endpoint.Address = new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["WsPaleoUrl"]);
                    break;
                default:
                    throw new Exception("Registro di protocollo non specificato. Impossibile continuare.");
            }
            if (!configurazione_ws.Attivo) throw new SiarException(TextErrorCodes.RegistroProtocolloNonAttivo);
            Login();
        }

        private void Login()
        {
            ws.ClientCredentials.UserName.UserName = configurazione_ws.Dominio + "\\" + configurazione_ws.Login;
            ws.ClientCredentials.UserName.Password = configurazione_ws.Pwd;
            CaricaOperatorePaleo();
        }

        private void CaricaOperatorePaleo()
        {
            operatore_paleo = new SiarBLL.paleoWebService.OperatorePaleo();
            operatore_paleo.CodiceUO = configurazione_ws.CodiceUo;
            operatore_paleo.Cognome = configurazione_ws.Cognome;
            operatore_paleo.Nome = configurazione_ws.Nome;
            //operatore_paleo.Ruolo = configurazione_ws.Ruolo;
            operatore_paleo.CodiceRuolo = configurazione_ws.Ruolo;
        }

        public void setDocumento(string nome, byte[] contenuto)
        {
            documento = new SiarBLL.paleoWebService.File();
            documento.Impronta = GetSHA256(contenuto);
            //documento.Nome = nome;
            documento.NomeFile = nome;
            documento.Stream = contenuto;
        }

        public void addAllegato(string nome, string hash)
        {
            if (allegati == null) allegati = new System.Collections.ArrayList();
            Dictionary<string, string> all = new Dictionary<string, string>();
            all.Add("nome", nome);
            all.Add("descrizione", nome);
            all.Add("hash", hash);
            allegati.Add(all);
        }

        //private void addCorrispondente(SiarBLL.paleoWebService.SoggettiXml c)
        //{
        //    SiarBLL.paleoWebService.SoggettiXml c_supp;
        //    c_supp = corrispondenti;
        //    if (c_supp == null) c_supp = new SiarBLL.paleoWebService.SoggettiXml[1];
        //    else
        //    {
        //        SiarBLL.paleoWebService.SoggettiXml[] c_supp2 = new SiarBLL.paleoWebService.SoggettiXml[c_supp.Length + 1];
        //        c_supp.CopyTo(c_supp2, 0);
        //        c_supp = c_supp2;
        //    }
        //    c_supp[c_supp.Length - 1] = c;
        //    corrispondenti = c_supp;
        //}

//        public void setCorrispondenteRubrica(string cod_rubrica, bool cc)
//        {
//            if (string.IsNullOrEmpty(cod_rubrica)) throw new Exception("Codice rubrica paleo non valido.");
//#if(!DEBUG)
//            SiarBLL.paleoWebService.Corrispondente c = new SiarBLL.paleoWebService.Corrispondente();
//            c.CodiceRubrica = cod_rubrica;
//            addCorrispondente(c, cc);
//#else
//            setCorrispondente(cod_rubrica, cod_rubrica, null, cc);
//#endif
//        }

        public void setCorrispondenteDestinatario(string cognome, string nome, string email)
        {
            //Distinzione se il soggetto è fisico o giuridico(o PAI)
            SiarBLL.paleoWebService.PFType PF = new SiarBLL.paleoWebService.PFType();
            //SiarBLL.paleoWebService.PGType PG = new SiarBLL.paleoWebService.PGType();
            //ProtocolType pt = new ProtocolType(); 
            //if (im.tipoIntestatario == GEDISIConst.PERSONA_FISICA)
            //{
            PF.Cognome = cognome;
            PF.Nome = nome;
            PF.IndirizziDigitaliDiRiferimento = new List<string> { email }.ToArray();
            //}
            //else { PG.DenominazioneOrganizzazione = im.intestatario; PG.CodiceFiscale_PartitaIva = im.partitaIvaIntestatario; }
            //Dichiarazione di un oggetto TipoSoggetto32Type al cui interno viene inserito il soggetto fisico / giuridico / PAI di cui sopra
            SiarBLL.paleoWebService.TipoSoggetto31Type soggetto = new SiarBLL.paleoWebService.TipoSoggetto31Type();
            //if (im.tipoIntestatario == GEDISIConst.PERSONA_FISICA)
            //{
            soggetto.Item = PF;
            //}
            //else { mittente.Item = PG; }

            //Il mittente viene associato al tipo ruolo Mittente(TipoRuolo predefinito)
            soggetto.TipoRuolo = "Destinatario";
            //Creazione di un nuovo oggetto di tipo RuoloType al cui campo Item si associa il valore” mittente”
            SiarBLL.paleoWebService.RuoloType rt = new SiarBLL.paleoWebService.RuoloType();
            rt.Item = soggetto;
            //Creazione lista di tipo RuoloType a cui viene aggiunto quello creato in precedenza
            List<SiarBLL.paleoWebService.RuoloType> listaRuoli = new List<SiarBLL.paleoWebService.RuoloType>();
            listaRuoli.Add(rt);

            SiarBLL.paleoWebService.SoggettiXml soggettiDestinatari = new SiarBLL.paleoWebService.SoggettiXml()
            {
                Ruolo = listaRuoli.ToArray()
            };

            destinatari = soggettiDestinatari;
        }

        public void setCorrispondenteMittente(string cognome, string nome, string email)
        {
            //Distinzione se il soggetto è fisico o giuridico(o PAI)
            SiarBLL.paleoWebService.PFType PF = new SiarBLL.paleoWebService.PFType();
            //SiarBLL.paleoWebService.PGType PG = new SiarBLL.paleoWebService.PGType();
            //ProtocolType pt = new ProtocolType(); 
            //if (im.tipoIntestatario == GEDISIConst.PERSONA_FISICA)
            //{
            PF.Cognome = cognome;
            PF.Nome = nome;
            PF.IndirizziDigitaliDiRiferimento = new List<string> { email }.ToArray();
            //}
            //else { PG.DenominazioneOrganizzazione = im.intestatario; PG.CodiceFiscale_PartitaIva = im.partitaIvaIntestatario; }
            //Dichiarazione di un oggetto TipoSoggetto32Type al cui interno viene inserito il soggetto fisico / giuridico / PAI di cui sopra
            SiarBLL.paleoWebService.TipoSoggetto32Type soggetto = new SiarBLL.paleoWebService.TipoSoggetto32Type();
            //if (im.tipoIntestatario == GEDISIConst.PERSONA_FISICA)
            //{
            soggetto.Item = PF;
            //}
            //else { mittente.Item = PG; }

            //Il mittente viene associato al tipo ruolo Mittente(TipoRuolo predefinito)
            soggetto.TipoRuolo = "Mittente";
            //Creazione di un nuovo oggetto di tipo RuoloType al cui campo Item si associa il valore” mittente”
            SiarBLL.paleoWebService.RuoloType rt = new SiarBLL.paleoWebService.RuoloType();
            rt.Item = soggetto;
            //Creazione lista di tipo RuoloType a cui viene aggiunto quello creato in precedenza
            List<SiarBLL.paleoWebService.RuoloType> listaRuoli = new List<SiarBLL.paleoWebService.RuoloType>();
            listaRuoli.Add(rt);

            SiarBLL.paleoWebService.SoggettiXml soggettoMittente = new SiarBLL.paleoWebService.SoggettiXml()
            {
                Ruolo = listaRuoli.ToArray()
            };

            mittente = soggettoMittente;

            //corrispondente.CorrispondenteOccasionale = new SiarBLL.paleoWebService.DatiCorrispondente();
            //corrispondente.CorrispondenteOccasionale.Cognome = cognome;
            //corrispondente.CorrispondenteOccasionale.Nome = nome;
            ////TEST
            ////email = "testpaleo1@pecgruppo.gpi.it";
            //corrispondente.CorrispondenteOccasionale.Email = email;
            //corrispondente.CorrispondenteOccasionale.Tipo = SiarBLL.paleoWebService.TipoVoceRubrica.Persona;
            //addCorrispondente(corrispondente);
        }

        public void setCorrispondente(string cognome, string nome, string email, string tipoCorrispondente)
        {
            if (tipoCorrispondente == "mittente")
                setCorrispondenteMittente(cognome, nome, email);
            else if (tipoCorrispondente == "destinatario") {
                setCorrispondenteDestinatario(cognome, nome, email);
            }
        }

        public void setCorrispondente(SiarLibrary.Impresa i, int? id_progetto, string tipoCorrispondente)
        {
            SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(i.IdRapprlegaleUltimo);
            if (rlegale == null) throw new Exception("L'impresa destinataria della comunicazione non ha un rappresentante legale valido. Impossibile continuare.");
            SiarLibrary.Indirizzario slegale = new SiarBLL.IndirizzarioCollectionProvider().GetById(i.IdSedelegaleUltimo);
            if (slegale == null) throw new Exception("L'impresa destinataria della comunicazione non ha una sede legale valida. Impossibile continuare.");
            if (slegale.Pec == null) throw new Exception("L'impresa destinataria della comunicazione non ha una casella di pec valida. Impossibile continuare.");
            string pec = slegale.Pec;
            if (id_progetto != null)
            {
                SiarLibrary.ProgettoPecCollection pec_coll = new SiarBLL.ProgettoPecCollectionProvider().Find(null, id_progetto, null);
                if (pec_coll.Count > 0)
                {
                    if (pec_coll[0].Pec != null && pec_coll[0].Pec != "")
                        pec = pec_coll[0].Pec;
                }
            }

            //TEST
            //string pec = "testpaleo1@pecgruppo.gpi.it";
            //setCorrispondente(rlegale.Cognome, rlegale.Nome, pec, cc);
            if (tipoCorrispondente == "mittente")
                setCorrispondenteMittente(rlegale.Cognome, rlegale.Nome, pec);
            else if (tipoCorrispondente == "destinatario")
            {
                setCorrispondenteDestinatario(rlegale.Cognome, rlegale.Nome, pec);
            }
            
        }

        public void setImpreseDestinatario(SiarLibrary.Impresa i, int? id_progetto, bool cc)
        {
            SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(i.IdRapprlegaleUltimo);
            if (rlegale == null) throw new Exception("L'impresa destinataria della comunicazione non ha un rappresentante legale valido. Impossibile continuare.");
            SiarLibrary.Indirizzario slegale = new SiarBLL.IndirizzarioCollectionProvider().GetById(i.IdSedelegaleUltimo);
            if (slegale == null) throw new Exception("L'impresa destinataria della comunicazione non ha una sede legale valida. Impossibile continuare.");
            if (slegale.Pec == null) throw new Exception("L'impresa destinataria della comunicazione non ha una casella di pec valida. Impossibile continuare.");
            string pec = slegale.Pec;
            if (id_progetto != null)
            {
                SiarLibrary.ProgettoPecCollection pec_coll = new SiarBLL.ProgettoPecCollectionProvider().Find(null, id_progetto, null);
                if (pec_coll.Count > 0)
                {
                    if (pec_coll[0].Pec != null && pec_coll[0].Pec != "")
                        pec = pec_coll[0].Pec;
                }
            }

            //TEST
            //string pec = "testpaleo1@pecgruppo.gpi.it";
            //setCorrispondente(rlegale.Cognome, rlegale.Nome, pec, cc);
            setCorrispondenteDestinatario(rlegale.Cognome, rlegale.Nome, pec);            
        }
       
        //public void setCorrispondenti(List<SiarLibrary.Impresa> imprese, bool cc)
        //{
        //    foreach (SiarLibrary.Impresa i in imprese)
        //    {
        //        SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(i.IdRapprlegaleUltimo);
        //        if (rlegale == null) throw new Exception("L'impresa destinataria della comunicazione non ha un rappresentante legale valido. Impossibile continuare.");
        //        SiarLibrary.Indirizzario slegale = new SiarBLL.IndirizzarioCollectionProvider().GetById(i.IdSedelegaleUltimo);
        //        if (slegale == null) throw new Exception("L'impresa destinataria della comunicazione non ha una sede legale valida. Impossibile continuare.");
        //        if (slegale.Pec == null) throw new Exception("L'impresa destinataria della comunicazione non ha una casella di pec valida. Impossibile continuare.");
        //        //TEST
        //        //string pec = "testpaleo1@pecgruppo.gpi.it";
        //        //setCorrispondente(rlegale.Cognome, rlegale.Nome, pec, cc);
        //        setCorrispondenteMittente(rlegale.Cognome, rlegale.Nome, slegale.Pec, cc);
        //    }
        //}

        public void setCorrispondenti(List<SiarLibrary.Progetto> progetti)
        {
            List<SiarBLL.paleoWebService.RuoloType> listaRuoli = new List<SiarBLL.paleoWebService.RuoloType>();

            foreach (SiarLibrary.Progetto p in progetti)
            {
                SiarLibrary.Impresa i = new SiarBLL.ImpresaCollectionProvider().GetById(p.IdImpresa);

                SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(i.IdRapprlegaleUltimo);
                if (rlegale == null) throw new Exception("L'impresa destinataria della comunicazione non ha un rappresentante legale valido. Impossibile continuare.");
                SiarLibrary.Indirizzario slegale = new SiarBLL.IndirizzarioCollectionProvider().GetById(i.IdSedelegaleUltimo);
                if (slegale == null) throw new Exception("L'impresa destinataria della comunicazione non ha una sede legale valida. Impossibile continuare.");
                if (slegale.Pec == null) throw new Exception("L'impresa destinataria della comunicazione non ha una casella di pec valida. Impossibile continuare.");
                string pec = slegale.Pec;
                if (p != null)
                {
                    SiarLibrary.ProgettoPecCollection pec_coll = new SiarBLL.ProgettoPecCollectionProvider().Find(null, p.IdProgetto, null);
                    if (pec_coll.Count > 0)
                    {
                        if (pec_coll[0].Pec != null && pec_coll[0].Pec != "")
                            pec = pec_coll[0].Pec;
                    }
                }

                //Distinzione se il soggetto è fisico o giuridico(o PAI)
                SiarBLL.paleoWebService.PFType PF = new SiarBLL.paleoWebService.PFType();
                //SiarBLL.paleoWebService.PGType PG = new SiarBLL.paleoWebService.PGType();
                //ProtocolType pt = new ProtocolType(); 
                //if (im.tipoIntestatario == GEDISIConst.PERSONA_FISICA)
                //{
                PF.Cognome = rlegale.Cognome;
                PF.Nome = rlegale.Nome;
                PF.IndirizziDigitaliDiRiferimento = new List<string> { pec }.ToArray();
                //}
                //else { PG.DenominazioneOrganizzazione = im.intestatario; PG.CodiceFiscale_PartitaIva = im.partitaIvaIntestatario; }
                //Dichiarazione di un oggetto TipoSoggetto32Type al cui interno viene inserito il soggetto fisico / giuridico / PAI di cui sopra
                SiarBLL.paleoWebService.TipoSoggetto31Type soggetto = new SiarBLL.paleoWebService.TipoSoggetto31Type();
                //if (im.tipoIntestatario == GEDISIConst.PERSONA_FISICA)
                //{
                soggetto.Item = PF;
                //}
                //else { mittente.Item = PG; }

                //Il mittente viene associato al tipo ruolo Mittente(TipoRuolo predefinito)
                soggetto.TipoRuolo = "Destinatario";
                //Creazione di un nuovo oggetto di tipo RuoloType al cui campo Item si associa il valore” mittente”
                SiarBLL.paleoWebService.RuoloType rt = new SiarBLL.paleoWebService.RuoloType();
                rt.Item = soggetto;
                //Creazione lista di tipo RuoloType a cui viene aggiunto quello creato in precedenza

                listaRuoli.Add(rt);

            }
            
            SiarBLL.paleoWebService.SoggettiXml soggettiDestinatari = new SiarBLL.paleoWebService.SoggettiXml()
            {
                Ruolo = listaRuoli.ToArray()
            };

            destinatari = soggettiDestinatari;
        }

        // : TODO
        public string CreaFascicolo(string Descrizione, string codice_classifica, string CustodeCognome, string CustodeNome, string CustodeRuolo, string CustodeUO)
        {
            //Codice classifica, obbligatorio: indica la classifica in cui inserire il fascicolo
            //Descrizione, obbligatorio: descrizione del fascicolo
            //Custode, obbligatorio: indicare l’operatore del sistema a cui è affidata la custodia del fascicolo (Cognome, Nome, Ruolo e codice UO tutti obbligatori)
            // Protocollare un documento che dichiara l'apertura del fascicolo/pubblicazione del bando
            return "";
        }

        private string getUoDaSegnaturaProtocollo(string segnatura)
        {
            try
            {
                // es.: 0031512|28/06/2016|R_MARCHE|GRM|INF|A|150.30.130/2016/INF/409 --> prendo "INF"
                // 9986961|17/06/2016|AEA --> "AEA"
                string[] ss = segnatura.Split('|');
                if (ss.Length > 4) return ss[4];
                return ss[2];
            }
            catch { return null; }
        }

        private int getDocNumberDaSegnaturaProtocollo(string segnatura)
        {
            // es.: 0031512|28/06/2016|R_MARCHE|GRM|INF|A|150.30.130/2016/INF/409 --> prendo "0031512"
            // 9986961|17/06/2016|AEA --> "9986961"
            string[] ss = segnatura.Split('|');
            int doc_number;
            if (int.TryParse(ss[0], out doc_number))
                return doc_number;

            throw new Exception("La segnatura " + segnatura + " non contiene il numero documento");
        }

        public DateTime getDataSegnaturaProtocollo(string segnatura)
        {
            // es.: 0031512|28/06/2016|R_MARCHE|GRM|INF|A|150.30.130/2016/INF/409 --> prendo "28/06/2016"
            // 9986961|17/06/2016|AEA --> "17/06/2016"
            string[] ss = segnatura.Split('|');
            DateTime dataSegnatura;
            if (DateTime.TryParse(ss[1], out dataSegnatura))
                return dataSegnatura;

            throw new Exception("La segnatura " + segnatura + " non contiene la data");
        }

        public bool isProtocollo(string segnatura)
        {
            return segnatura.Contains("|A|") || segnatura.EndsWith("|A") || segnatura.Contains("|P|") || segnatura.EndsWith("|P");
        }

        public string ProtocolloIngresso(string oggetto, string codice_fascicolo)
        {
            SiarBLL.paleoWebService.reqProtocolloArrivo request = new SiarBLL.paleoWebService.reqProtocolloArrivo();
            request.Operatore = operatore_paleo;
            request.CodiceRegistro = registro_selezionato.ToString();
            request.Privato = false;
            request.Oggetto = oggetto;
            request.DataArrivo = DateTime.Now;
            // dati mittente
            //if (corrispondenti != null && corrispondenti.Length > 0)
            request.SoggettiAgid = mittente;
            // documento principale
            if (documento != null)
            {
                request.DocumentoPrincipale = documento;
                request.DocumentoPrincipaleAcquisitoIntegralmente = true;
                //request.DocumentoPrincipaleOriginaleSpecified = true;
                //request.DocumentoPrincipaleOriginale = SiarBLL.paleoWebService.TipoOriginale.Digitale;
                request.DocumentoPrincipaleModalitaFormazione = SiarBLL.paleoWebService.TipoOriginale.Digitale;
            }

            //Impronta degli allegati
            if (allegati != null)
            {
                request.DocumentiAllegati = new SiarBLL.paleoWebService.Allegato[allegati.Count];
                int i = 0;
                foreach (Dictionary<string, string> a in allegati)
                {
                    //request.DocumentiAllegati[i] = (SiarBLL.paleoWebService.Allegato)allegati[i];
                    request.DocumentiAllegati[i] = new SiarBLL.paleoWebService.Allegato();
                    request.DocumentiAllegati[i].Documento = new SiarBLL.paleoWebService.File();
                    request.DocumentiAllegati[i].Documento.Impronta = a["hash"].ToString();
                    request.DocumentiAllegati[i].Descrizione = a["descrizione"].ToString();
                    request.DocumentiAllegati[i].ModalitaFormazione = SiarBLL.paleoWebService.TipoOriginale.Digitale;
                    //request.DocumentiAllegati[i].Documento.Nome = a["nome"].ToString();
                    request.DocumentiAllegati[i].Documento.NomeFile = a["nome"].ToString();
                    i++;
                }
            }

            // classificazione
            request.Classificazioni = new SiarBLL.paleoWebService.Classificazione[1];
            request.Classificazioni[0] = new SiarBLL.paleoWebService.Classificazione();
            request.Classificazioni[0].CodiceFascicolo = codice_fascicolo;

            if (trasmissioneUtenti != null)
            {
                request.Trasmissione = new SiarBLL.paleoWebService.Trasmissione();
                request.Trasmissione.TrasmissioniUtente = trasmissioneUtenti;
            }

            try
            {
                var resp = ws.ProtocollazioneEntrata(request);
                if (resp == null)
                    throw new SiarException(TextErrorCodes.DocumentoNonProtocollato);
                if (resp.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                    throw new SiarException(TextErrorCodes.RegistroProtocolloChiuso);
                if (resp.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error)
                    throw new Exception(resp.MessaggioRisultato.Descrizione);

                //if (allegati != null)
                //{
                //    request.DocumentiAllegati = new SiarBLL.paleoWebService.Allegato[allegati.Count];
                //    for (int i = 0; i < allegati.Count; i++)
                //        addAllegatoProtocollo(request, resp.Segnatura, (SiarBLL.paleoWebService.Allegato)allegati[i]);
                //}

                return resp.Oggetto.Segnatura.Replace("ID:", "").Trim();
            }
            catch (Exception ex)
            {
                string oggettoEmail = "Errore durante la protocollazione di un documento";
                string testEmail = "metodo: ProtocolloIngresso()\noggetto documento: " + oggetto.ToCleanJsString()
                    + "\nclassificazione: " + codice_fascicolo.ToCleanJsString() + "\n\n" + ex.Message.ToCleanJsString();
                EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                throw ex;
            }
            finally { Close(); }
        }

        public void addAllegatiProtocollo(System.Collections.ArrayList allegatiProtocollo, string segnaturaPaleo)
        {
            Open();

            SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();

            foreach (Dictionary<string, object> a in allegatiProtocollo)
            {
                try
                {
                    int idfile = 0;
                    int.TryParse(a["id_file"].ToString(), out idfile);

                    int idOrigine = 0;
                    int.TryParse(a["id_origine"].ToString(), out idOrigine);

                    string tipoOrigine = a["tipo_origine"].ToString();

                    ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(idfile);

                    SiarBLL.paleoWebService.reqAddAllegati request = new SiarBLL.paleoWebService.reqAddAllegati();

                    //if (segnaturaPaleo.Contains("|"))
                    //    request.SegnaturaProtocollo = segnaturaPaleo;
                    //else
                    //    request.DocNumber = Convert.ToInt32(segnaturaPaleo);
                    request.SegnaturaProtocollo = segnaturaPaleo;
                    request.Operatore = operatore_paleo;
                    request.Allegati = new SiarBLL.paleoWebService.Allegato[1];

                    SiarBLL.paleoWebService.Allegato allegato = (SiarBLL.paleoWebService.Allegato)a["allegato"];

                    SiarBLL.paleoWebService.Allegato currAlleg = new SiarBLL.paleoWebService.Allegato();
                    currAlleg.Descrizione = allegato.Descrizione;
                    currAlleg.Documento = new SiarBLL.paleoWebService.File();
                    //currAlleg.Documento.Nome = allegato.Documento.Nome;
                    currAlleg.Documento.NomeFile = allegato.Documento.NomeFile;
                    if (idfile != -1)
                    {
                        currAlleg.Documento.Stream = f.Contenuto;
                        currAlleg.Documento.Impronta = f.HashCode;
                    }
                    else
                    {
                        currAlleg.Documento.Stream = allegato.Documento.Stream;
                        currAlleg.Documento.Impronta = GetSHA256(allegato.Documento.Stream);
                    }
                    // aggiunta impronta allegati

                    request.Allegati[0] = currAlleg;

                    var result = ws.AddAllegatiDocumentoProtocollo(request);

                    AllegatiProtocollatiCollection all = new AllegatiProtocollatiCollection();

                    switch (tipoOrigine)
                    {
                        case "progetto":
                            all = allegatiProtocollatiProvider.Find(idOrigine, null, null, null, null, idfile, false, null);
                            break;
                        case "pagamento":
                            all = allegatiProtocollatiProvider.Find(null, idOrigine, null, null, null, idfile, false, null);
                            break;
                        case "variante":
                            all = allegatiProtocollatiProvider.Find(null, null, idOrigine, null, null, idfile, false, null);
                            break;
                        case "integrazione":
                            all = allegatiProtocollatiProvider.Find(null, null, null, idOrigine, null, idfile, false, null);
                            break;
                        case "comunicazione":
                            all = allegatiProtocollatiProvider.Find(null, null, null, null, idOrigine, idfile, false, null);
                            break;
                        case "istruttoria":

                            break;

                    }

                    foreach (AllegatiProtocollati ap in all)
                    {
                        ap.Protocollato = true;
                        ap.Protocollo = segnaturaPaleo;
                        allegatiProtocollatiProvider.Save(ap);
                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
            }

            Close();
        }

        public void addAllegatiDocInterno(System.Collections.ArrayList allegatiProtocollo, string segnaturaPaleo, string DocNumber)
        {
            Open();

            SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();

            foreach (Dictionary<string, object> a in allegatiProtocollo)
            {
                try
                {
                    int idfile = 0;
                    int.TryParse(a["id_file"].ToString(), out idfile);

                    int idOrigine = 0;
                    int.TryParse(a["id_origine"].ToString(), out idOrigine);

                    string tipoOrigine = a["tipo_origine"].ToString();

                    ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(idfile);

                    SiarBLL.paleoWebService.reqAddAllegati request = new SiarBLL.paleoWebService.reqAddAllegati();

                    request.DocNumber = Convert.ToInt32(DocNumber);
                    //request.SegnaturaProtocollo = segnaturaPaleo;  
                    request.Operatore = operatore_paleo;
                    request.Allegati = new SiarBLL.paleoWebService.Allegato[1];

                    SiarBLL.paleoWebService.Allegato allegato = (SiarBLL.paleoWebService.Allegato)a["allegato"];

                    SiarBLL.paleoWebService.Allegato currAlleg = new SiarBLL.paleoWebService.Allegato();
                    currAlleg.Descrizione = allegato.Descrizione;
                    currAlleg.Documento = new SiarBLL.paleoWebService.File();
                    //currAlleg.Documento.Nome = allegato.Documento.Nome;
                    currAlleg.Documento.NomeFile = allegato.Documento.NomeFile;
                    if (idfile != -1)
                    {
                        currAlleg.Documento.Stream = f.Contenuto;
                        currAlleg.Documento.Impronta = f.HashCode;
                    }
                    else
                    {
                        currAlleg.Documento.Stream = allegato.Documento.Stream;
                        currAlleg.Documento.Impronta = GetSHA256(allegato.Documento.Stream);
                    }
                    // aggiunta impronta allegati 

                    request.Allegati[0] = currAlleg;

                    var result = ws.AddAllegatiDocumentoProtocollo(request);

                    AllegatiProtocollatiCollection all = new AllegatiProtocollatiCollection();

                    switch (tipoOrigine)
                    {
                        case "progetto":
                            all = allegatiProtocollatiProvider.Find(idOrigine, null, null, null, null, idfile, false, null);
                            break;
                        case "pagamento":
                            all = allegatiProtocollatiProvider.Find(null, idOrigine, null, null, null, idfile, false, null);
                            break;
                        case "variante":
                            all = allegatiProtocollatiProvider.Find(null, null, idOrigine, null, null, idfile, false, null);
                            break;
                        case "integrazione":
                            all = allegatiProtocollatiProvider.Find(null, null, null, idOrigine, null, idfile, false, null);
                            break;
                        case "comunicazione":
                            all = allegatiProtocollatiProvider.Find(null, null, null, null, idOrigine, idfile, false, null);
                            break;
                    }

                    foreach (SiarLibrary.AllegatiProtocollati ap in all)
                    {
                        ap.Protocollato = true;
                        ap.Protocollo = segnaturaPaleo;
                        allegatiProtocollatiProvider.Save(ap);
                    }
                }
                catch (Exception ex)
                {
                    //throw ex; 
                }
            }

            Close();
        }

        public void addAllegatiProtocollo(ArchivioFileCollection af_collection, string segnatura)
        {
            Open();

            foreach (ArchivioFile file in af_collection)
            {
                try
                {
                    SiarBLL.paleoWebService.reqAddAllegati request = new SiarBLL.paleoWebService.reqAddAllegati();
                    request.SegnaturaProtocollo = segnatura;
                    request.Operatore = operatore_paleo;
                    request.Allegati = new SiarBLL.paleoWebService.Allegato[1];

                    SiarBLL.paleoWebService.Allegato currAlleg = new SiarBLL.paleoWebService.Allegato();
                    currAlleg.Descrizione = file.NomeFile;
                    currAlleg.Documento = new SiarBLL.paleoWebService.File();
                    //currAlleg.Documento.Nome = file.NomeFile;
                    currAlleg.Documento.NomeFile = file.NomeFile;
                    currAlleg.Documento.Stream = file.Contenuto;

                    request.Allegati[0] = currAlleg;

                    var result = ws.AddAllegatiDocumentoProtocollo(request);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            Close();
        }

        public string ProtocolloUscita(string oggetto, string codice_fascicolo)
        {
            return ProtocolloUscita(oggetto, codice_fascicolo, false);
        }

        public string ProtocolloUscita(string oggetto, string codice_fascicolo, bool spedisci_pec)
        {
            SiarBLL.paleoWebService.reqProtocolloPartenza request = new SiarBLL.paleoWebService.reqProtocolloPartenza();
            request.Operatore = operatore_paleo;
            request.CodiceRegistro = registro_selezionato.ToString();
            request.Privato = false;
            request.Oggetto = oggetto;
            // dati destinatario
            request.SoggettiAgid = destinatari;
            //if (corrispondentiCC != null) request.DestinatariCC = corrispondentiCC;
            // documento principale
            if (documento != null)
            {
                request.DocumentoPrincipale = documento;
                request.DocumentoPrincipaleAcquisitoIntegralmente = true;
                //                request.DocumentoPrincipaleOriginaleSpecified = true;
                //request.DocumentoPrincipaleOriginale = SiarBLL.paleoWebService.TipoOriginale.Digitale;
                request.DocumentoPrincipaleModalitaFormazione = SiarBLL.paleoWebService.TipoOriginale.Digitale;
            }

            //Impronta degli allegati
            if (allegati != null)
            {
                request.DocumentiAllegati = new SiarBLL.paleoWebService.Allegato[allegati.Count];
                int i = 0;
                foreach (Dictionary<string, string> a in allegati)
                {
                    //request.DocumentiAllegati[i] = (SiarBLL.paleoWebService.Allegato)allegati[i];
                    request.DocumentiAllegati[i] = new SiarBLL.paleoWebService.Allegato();
                    request.DocumentiAllegati[i].Documento = new SiarBLL.paleoWebService.File();
                    request.DocumentiAllegati[i].Documento.Impronta = a["hash"].ToString();
                    //request.DocumentiAllegati[i].Documento.Nome = a["nome"].ToString();
                    request.DocumentiAllegati[i].Documento.NomeFile = a["nome"].ToString();
                    request.DocumentiAllegati[i].Descrizione = a["descrizione"].ToString();
                    request.DocumentiAllegati[i].ModalitaFormazione = SiarBLL.paleoWebService.TipoOriginale.Digitale;
                    i++;
                }
            }

            // classificazione
            if (!string.IsNullOrEmpty(codice_fascicolo))
            {
                request.Classificazioni = new SiarBLL.paleoWebService.Classificazione[1];
                request.Classificazioni[0] = new SiarBLL.paleoWebService.Classificazione();
                request.Classificazioni[0].CodiceFascicolo = codice_fascicolo;
            }
            string segnatura = null;
            try
            {
                var resp = ws.ProtocollazionePartenza(request);
                if (resp == null) throw new SiarException(TextErrorCodes.DocumentoNonProtocollato);
                if (resp.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.RegistroProtocolloChiuso);
                if (resp.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error) throw new Exception(resp.MessaggioRisultato.Descrizione);
                segnatura = resp.Oggetto.Segnatura.Replace("ID:", "").Trim();
            }
            catch (Exception ex)
            {
                string oggettoEmail = "Errore durante la protocollazione di un documento";
                string testEmail = "metodo: ProtocolloUscita()\noggetto documento: " + oggetto.ToCleanJsString()
                    + "\nclassificazione: " + codice_fascicolo.ToCleanJsString() + "\n\n" + ex.Message.ToCleanJsString();
                EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                throw ex;
            }
            if (spedisci_pec) SpedisciViaPec(segnatura);
            else Close();
            return segnatura;
        }

        public void SpedisciViaPec(string segnatura)
        {
            string destinatari_non_inviati = "";
            var errori_collection = new ErroriPecCollection();

            try
            {
                //if (ws.State == CommunicationState.Closed) ws.Open();
                Open();
                SiarBLL.paleoWebService.reqSpedisciProtocollo request = new SiarBLL.paleoWebService.reqSpedisciProtocollo();
                request.Operatore = operatore_paleo;
                request.Segnatura = segnatura;
                var result = ws.SpedisciProtocollo(request);
                if (result == null)
                    throw new Exception("L'invio della PEC ai destinatari non è riuscito.");

                foreach (SiarBLL.paleoWebService.DestinatarioInfoInterop di in result.Oggetto.Destinatari)
                {
                    var statoSpedizione = di.MessaggiInterop.Length == 0 ? null : result.Oggetto.Destinatari[0].MessaggiInterop[0].StatoSpedizione;

                    if (di.MessaggiInterop.Length == 0
                        || result.Oggetto.Destinatari[0].MessaggiInterop[0].StatoSpedizione != SiarBLL.paleoWebService.TipoStatoSpedizione.Spedito)
                    {
                        destinatari_non_inviati += "\ndestinatario: " + di.Descrizione + " - Email: " + di.Email;

                        var errore = new ErroriPec(); ;
                        errore.Segnatura = segnatura;
                        errore.Destinatario = di.Descrizione;
                        errore.EmailDestinatario = di.Email;
                        if (statoSpedizione == null)
                        {
                            errore.IdStato = -1;
                            errore.Stato = "Errore in invio PEC.";
                        }
                        else
                        {
                            errore.IdStato = Convert.ToInt32(statoSpedizione);
                            errore.Stato = statoSpedizione.Value.ToString();
                        }
                        errore.DataInserimento = DateTime.Now;
                        errori_collection.Add(errore);
                    }
                }

                if (!string.IsNullOrEmpty(destinatari_non_inviati))
                    throw new Exception("Elenco destinatari a cui non è stato possibile recapitare la PEC: "
                      + destinatari_non_inviati);
            }
            catch (Exception ex)
            {
                new ErroriPecCollectionProvider().SaveCollection(errori_collection);
                string oggettoEmail = "Errore durante l'invio di documenti tramite pec paleo";
                string testEmail = "segnatura: " + segnatura;
                EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
            }
            finally { Close(); }
        }

        public string RispedisciPec(SiarLibrary.ErroriPec errore)
        {
            string destinatari_non_inviati = "";
            var errori_new_collection = new ErroriPecCollection();
            var errori_pec_provider = new SiarBLL.ErroriPecCollectionProvider();
            string segnatura = errore.Segnatura;
            string messaggio = "";

            string uo_segnatura = getUoDaSegnaturaProtocollo(segnatura);
            CaricaWebService(uo_segnatura);

            try
            {
                //if (ws.State == CommunicationState.Closed) ws.Open();
                SiarBLL.paleoWebService.reqSpedisciProtocollo request = new SiarBLL.paleoWebService.reqSpedisciProtocollo();
                request.Operatore = operatore_paleo;
                request.Segnatura = segnatura;
                var result = ws.SpedisciProtocollo(request);
                if (result == null)
                    throw new Exception("L'invio della PEC ai destinatari non è riuscito.");

                if (result.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error)
                    messaggio = result.MessaggioRisultato.Descrizione;

                foreach (SiarBLL.paleoWebService.DestinatarioInfoInterop di in result.Oggetto.Destinatari)
                {
                    var statoSpedizione = di.MessaggiInterop.Length == 0 ? null : result.Oggetto.Destinatari[0].MessaggiInterop[0].StatoSpedizione;

                    if (di.MessaggiInterop.Length == 0
                        || result.Oggetto.Destinatari[0].MessaggiInterop[0].StatoSpedizione == SiarBLL.paleoWebService.TipoStatoSpedizione.NonSpedito)
                    {
                        destinatari_non_inviati += "\ndestinatario: " + di.Descrizione + " - Email: " + di.Email;

                        var errore_new = new ErroriPec(); ;
                        errore_new.Segnatura = segnatura;
                        errore_new.Destinatario = di.Descrizione;
                        errore_new.EmailDestinatario = di.Email;
                        if (statoSpedizione == null)
                        {
                            errore_new.IdStato = -1;
                            errore_new.Stato = "Errore in invio PEC.";
                        }
                        else
                        {
                            errore_new.IdStato = Convert.ToInt32(statoSpedizione);
                            errore_new.Stato = statoSpedizione.Value.ToString();
                        }
                        errore_new.DataInserimento = DateTime.Now;
                        errori_new_collection.Add(errore);
                    }

                    var err_coll = errori_pec_provider.FindErroriPec(segnatura, null, null, null, null);
                    foreach (SiarLibrary.ErroriPec err in err_coll)
                    {
                        if (statoSpedizione == null)
                        {
                            err.IdStato = -1;
                            err.Stato = "Errore in invio PEC.";
                        }
                        else
                        {
                            err.IdStato = Convert.ToInt32(statoSpedizione);
                            err.Stato = statoSpedizione.Value.ToString();
                        }
                        err.DataModifica = DateTime.Now;
                        errori_pec_provider.Save(err);
                    }
                }

                if (!string.IsNullOrEmpty(destinatari_non_inviati))
                    throw new Exception("Elenco destinatari a cui non è stato possibile recapitare la PEC: "
                      + destinatari_non_inviati);
            }
            catch (Exception ex)
            {
                messaggio = "Errore durante l'invio di documenti tramite pec paleo.";
                errori_pec_provider.SaveCollection(errori_new_collection);
                string oggettoEmail = "Errore durante l'invio di documenti tramite pec paleo";
                string testEmail = "segnatura: " + segnatura;
                EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
            }
            finally
            {
                Close();
            }

            return messaggio;
        }

        public string DocumentoInterno(string oggetto, string classificazione)
        {
            SiarBLL.paleoWebService.reqDocumento doc = new SiarBLL.paleoWebService.reqDocumento();
            doc.DocumentoPrincipale = documento;
            doc.DocumentoPrincipaleAcquisitoIntegralmente = true;
            //doc.DocumentoPrincipaleOriginaleSpecified = true;
            //doc.DocumentoPrincipaleOriginale = SiarBLL.paleoWebService.TipoOriginale.Digitale;
            doc.DocumentoPrincipaleModalitaFormazione = SiarBLL.paleoWebService.TipoOriginale.Digitale;
            doc.Oggetto = oggetto;

            //Impronta degli allegati 
            if (allegati != null)
            {
                doc.DocumentiAllegati = new SiarBLL.paleoWebService.Allegato[allegati.Count];
                int i = 0;
                foreach (Dictionary<string, string> a in allegati)
                {
                    //request.DocumentiAllegati[i] = (SiarBLL.paleoWebService.Allegato)allegati[i]; 
                    doc.DocumentiAllegati[i] = new SiarBLL.paleoWebService.Allegato();
                    doc.DocumentiAllegati[i].Documento = new SiarBLL.paleoWebService.File();
                    doc.DocumentiAllegati[i].Documento.Impronta = a["hash"].ToString();
                    //doc.DocumentiAllegati[i].Documento.Nome = a["nome"].ToString();
                    doc.DocumentiAllegati[i].Documento.NomeFile = a["nome"].ToString();
                    doc.DocumentiAllegati[i].Descrizione = a["descrizione"].ToString();
                    doc.DocumentiAllegati[i].ModalitaFormazione = SiarBLL.paleoWebService.TipoOriginale.Digitale;
                    i++;
                }
            }

            // classificazione
            doc.Classificazioni = new SiarBLL.paleoWebService.Classificazione[1];
            doc.Classificazioni[0] = new SiarBLL.paleoWebService.Classificazione();
            doc.Classificazioni[0].CodiceFascicolo = classificazione;
            doc.Operatore = operatore_paleo;
            try
            {
                var resp = ws.ArchiviaDocumentoInterno(doc);
                if (resp == null) throw new SiarException(TextErrorCodes.DocumentoNonProtocollato);
                if (resp.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.RegistroProtocolloChiuso);
                if (resp.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error) throw new Exception(resp.MessaggioRisultato.Descrizione);
                return resp.Oggetto.SegnaturaDocumento.Replace("ID:", "").Trim();
            }
            catch (Exception ex)
            {
                string oggettoEmail = "Errore durante la protocollazione di un documento";
                string testEmail = "metodo: DocumentoInterno()\noggetto documento: " + oggetto.ToCleanJsString()
                    + "\nclassificazione: " + classificazione.ToCleanJsString() + "\n\n" + ex.Message.ToCleanJsString();
                EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                throw ex;
            }
            finally { Close(); }
        }

        public byte[] RicercaProtocollo(string segnatura, bool is_protocollo)
        {
            if (string.IsNullOrEmpty(segnatura)) return null;
            string uo_segnatura = getUoDaSegnaturaProtocollo(segnatura);
            if (operatore_paleo.CodiceUO != uo_segnatura) CaricaWebService(uo_segnatura);
            SiarBLL.paleoWebService.reqCercaProtocollo proto = new SiarBLL.paleoWebService.reqCercaProtocollo();
            proto.Operatore = operatore_paleo;

            if (is_protocollo)
                proto.Segnatura = segnatura;
            else
            {
                string[] str = segnatura.Split('|');
                if (str[0] == null) return null;
                proto.DocNumber = int.Parse(str[0]);

            }
            byte[] out_array = null;

            try
            {
                var doc = ws.CercaDocumentoProtocollo(proto);
                if (!CheckDocumentoValido(doc))
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);
                if (doc.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                    throw new SiarException(TextErrorCodes.RegistroProtocolloChiuso);
                if (doc.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error)
                    throw new Exception(doc.MessaggioRisultato.Descrizione);

                if (doc.Oggetto.DocumentoPrincipale.MimeType == "application/pdf")
                {
                    out_array = doc.Oggetto.DocumentoPrincipale.Stream;

                    //Cerco di evitare l'errore "Il contenuto dei files è stato soppresso; utilizzare il metodo GetFile"
                    if (out_array == null)
                    {
                        SiarBLL.paleoWebService.BEBaseOfFilec14f1rMd docNew = ws.GetFile(operatore_paleo, doc.Oggetto.DocumentoPrincipale.IdFile);

                        if (docNew != null && docNew.Oggetto != null && docNew.Oggetto.Stream != null)
                            out_array = docNew.Oggetto.Stream;
                    }
                }
                else
                {
                    foreach (SiarBLL.paleoWebService.Allegato a in doc.Oggetto.Allegati)
                        if (a.Documento != null && a.Documento.MimeType == "application/pdf") { out_array = a.Documento.Stream; break; }
                }
            }
            catch (Exception ex)
            {
                //new SiarLibrary.Email("Errore in ricerca protocollo", "segnatura: " + proto.Segnatura + " " + proto.DocNumber
                //    + "\noperatore: " + proto.Operatore.Nome + " " + proto.Operatore.Cognome + " " + proto.Operatore.Ruolo + " " + proto.Operatore.CodiceUO + "\n\n"
                //    + ex.Message.ToCleanJsString())
                //    .SendAlert();
                throw ex;
            }
            finally { Close(); }
            return out_array;
        }

        public bool ProtocolloEsistente(string segnatura)
        {
            if (string.IsNullOrEmpty(segnatura)) return false;
            string uo_segnatura = getUoDaSegnaturaProtocollo(segnatura);
            if (operatore_paleo.CodiceUO != uo_segnatura) CaricaWebServiceProtocolloEsistente(uo_segnatura);
            SiarBLL.paleoWebService.reqCercaProtocollo proto = new SiarBLL.paleoWebService.reqCercaProtocollo();
            proto.Operatore = operatore_paleo;
            if (isProtocollo(segnatura)) proto.Segnatura = segnatura;
            else
            {
                string[] str = segnatura.Split('|');
                if (str[0] == null) return false;
                proto.DocNumber = int.Parse(str[0]);
            }
            try
            {
                var doc = ws.CercaDocumentoProtocollo(proto);
                if (doc.MessaggioRisultato.Descrizione == "Il registro è chiuso.") throw new SiarException(TextErrorCodes.RegistroProtocolloChiuso);
                if (doc.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error) throw new Exception(doc.MessaggioRisultato.Descrizione);
                if (!CheckDocumentoValido(doc)) return false;
                return true;
            }
            catch { return false; }
            finally { Close(); }
        }

        public byte[] AF_RicercaFile(string segnatura, int idFile)
        {
            if (string.IsNullOrEmpty(segnatura)) return null;
            string uo_segnatura = getUoDaSegnaturaProtocollo(segnatura);
            if (operatore_paleo.CodiceUO != uo_segnatura) CaricaWebServiceProtocolloEsistente(uo_segnatura);
            SiarBLL.paleoWebService.reqCercaProtocollo proto = new SiarBLL.paleoWebService.reqCercaProtocollo();
            proto.Operatore = operatore_paleo;
            if (isProtocollo(segnatura)) proto.Segnatura = segnatura;
            else
            {
                string[] str = segnatura.Split('|');
                if (str[0] == null) return null;
                proto.DocNumber = int.Parse(str[0]);
            }
            try
            {
                var doc = ws.GetFile(operatore_paleo, idFile);
                // documento principale
                return doc.Oggetto.Stream;
            }
            catch (Exception ex)
            {
                //new SiarLibrary.Email("Errore in ricerca protocollo", "segnatura: " + proto.Segnatura + " " + proto.DocNumber
                //    + "\noperatore: " + proto.Operatore.Nome + " " + proto.Operatore.Cognome + " " + proto.Operatore.Ruolo + " " + proto.Operatore.CodiceUO + "\n\n"
                //    + ex.Message.ToCleanJsString())
                //    .SendAlert();
                throw ex;
            }
            finally { Close(); }
        }

        public ArchivioFileCollection AF_RicercaProtocolloSingolo(string segnatura, bool withoutStream)
        {
            if (string.IsNullOrEmpty(segnatura))
                return null;

            string uo_segnatura = getUoDaSegnaturaProtocollo(segnatura);
            if (operatore_paleo.CodiceUO != uo_segnatura)
                CaricaWebServiceProtocolloEsistente(uo_segnatura);
            SiarBLL.paleoWebService.reqCercaProtocollo proto = new SiarBLL.paleoWebService.reqCercaProtocollo();
            proto.Operatore = operatore_paleo;
            proto.WithoutStream = withoutStream;

            if (isProtocollo(segnatura))
                proto.Segnatura = segnatura;
            else
            {
                string[] str = segnatura.Split('|');
                if (str[0] == null) return null;
                proto.DocNumber = int.Parse(str[0]);
            }

            try
            {
                var doc = ws.CercaDocumentoProtocollo(proto);
                if (!CheckDocumentoValido(doc))
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);
                if (doc.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                    throw new SiarException(TextErrorCodes.RegistroProtocolloChiuso);
                if (doc.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error)
                    throw new Exception(doc.MessaggioRisultato.Descrizione);

                ArchivioFileCollection docs = new ArchivioFileCollection();
                // documento principale
                ArchivioFile dp = new ArchivioFile();
                dp.NomeFile = dp.NomeCompleto = doc.Oggetto.DocumentoPrincipale.NomeFile.ToCleanJsString();
                dp.Id = doc.Oggetto.DocumentoPrincipale.IdFile;
                dp.NomeCompleto = segnatura;
                //dp.Contenuto = doc.DocumentoPrincipale.Stream;
                dp.Tipo = doc.Oggetto.DocumentoPrincipale.MimeType;
                docs.Add(dp);

                foreach (SiarBLL.paleoWebService.Allegato a in doc.Oggetto.Allegati)
                {
                    if (a.Documento != null)// doc_supp.Add(new NP_ProtocolloDocSupp(a.Documento.Nome.ToCleanJsString(), a.Documento.Estensione, a.Documento.Stream));
                    {
                        ArchivioFile af = new ArchivioFile();
                        //af.NomeFile = af.NomeCompleto = a.Documento.Nome.ToCleanJsString() + "." + a.Documento.Estensione;
                        af.NomeFile = af.NomeCompleto = a.Documento.NomeFile.ToCleanJsString();
                        dp.NomeCompleto = segnatura;
                        //af.Contenuto = a.Documento.Stream;
                        af.Id = a.Documento.IdFile;
                        af.Tipo = a.Documento.MimeType;
                        docs.Add(af);
                    }
                }

                return docs;
            }
            catch (Exception ex)
            {
                //new SiarLibrary.Email("Errore in ricerca protocollo", "segnatura: " + proto.Segnatura + " " + proto.DocNumber
                //    + "\noperatore: " + proto.Operatore.Nome + " " + proto.Operatore.Cognome + " " + proto.Operatore.Ruolo + " " + proto.Operatore.CodiceUO + "\n\n"
                //    + ex.Message.ToCleanJsString())
                //    .SendAlert();
                throw ex;
            }
            finally { Close(); }
        }

        public ArrayList GetAllegatiProtocollo(string segnatura)
        {
            ArrayList risultati = new ArrayList();

            string uo_segnatura = getUoDaSegnaturaProtocollo(segnatura);
            if (operatore_paleo.CodiceUO != uo_segnatura)
                CaricaWebServiceProtocolloEsistente(uo_segnatura);
            SiarBLL.paleoWebService.reqCercaProtocollo proto = new SiarBLL.paleoWebService.reqCercaProtocollo();
            proto.Operatore = operatore_paleo;
            proto.WithoutStream = false;

            if (isProtocollo(segnatura))
                proto.Segnatura = segnatura;
            else
            {
                string[] str = segnatura.Split('|');
                if (str[0] == null) return null;
                proto.DocNumber = int.Parse(str[0]);
            }

            try
            {
                var doc = ws.CercaDocumentoProtocollo(proto);
                if (!CheckDocumentoValido(doc))
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);
                if (doc.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                    throw new SiarException(TextErrorCodes.RegistroProtocolloChiuso);
                if (doc.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error)
                    throw new Exception(doc.MessaggioRisultato.Descrizione);

                foreach (SiarBLL.paleoWebService.Allegato a in doc.Oggetto.Allegati)
                {
                    risultati.Add(a);
                }

                return risultati;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Close(); }
        }

        public ArchivioFileCollection AF_RicercaProtocollo(string segnatura, bool withoutStream)
        {
            if (string.IsNullOrEmpty(segnatura))
                return null;

            string uo_segnatura = getUoDaSegnaturaProtocollo(segnatura);
            if (operatore_paleo.CodiceUO != uo_segnatura)
                CaricaWebServiceProtocolloEsistente(uo_segnatura);
            SiarBLL.paleoWebService.reqCercaProtocollo proto = new SiarBLL.paleoWebService.reqCercaProtocollo();
            proto.Operatore = operatore_paleo;
            proto.WithoutStream = withoutStream;

            if (isProtocollo(segnatura))
                proto.Segnatura = segnatura;
            else
            {
                string[] str = segnatura.Split('|');
                if (str[0] == null) return null;
                proto.DocNumber = int.Parse(str[0]);
            }

            try
            {
                var doc = ws.CercaDocumentoProtocollo(proto);
                if (!CheckDocumentoValido(doc))
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);
                if (doc.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                    throw new SiarException(TextErrorCodes.RegistroProtocolloChiuso);
                if (doc.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error)
                    throw new Exception(doc.MessaggioRisultato.Descrizione);

                ArchivioFileCollection docs = new ArchivioFileCollection();
                // documento principale
                ArchivioFile documentoPrincipale = new ArchivioFile();
                //documentoPrincipale.NomeFile = documentoPrincipale.NomeCompleto = doc.Oggetto.ToCleanJsString() + "." + doc.Oggetto.DocumentoPrincipale.Estensione;
                documentoPrincipale.NomeFile = documentoPrincipale.NomeCompleto = doc.Oggetto.DocumentoPrincipale.NomeFile.ToCleanJsString();
                documentoPrincipale.Id = doc.Oggetto.DocumentoPrincipale.IdFile;
                documentoPrincipale.NomeCompleto = segnatura;
                //documentoPrincipale.Contenuto = doc.DocumentoPrincipale.Stream;
                documentoPrincipale.Tipo = doc.Oggetto.DocumentoPrincipale.MimeType;
                docs.Add(documentoPrincipale);

                foreach (SiarBLL.paleoWebService.Allegato a in doc.Oggetto.Allegati)
                {
                    if (a.Documento != null)// doc_supp.Add(new NP_ProtocolloDocSupp(a.Documento.Nome.ToCleanJsString(), a.Documento.Estensione, a.Documento.Stream));
                    {
                        ArchivioFile af = new ArchivioFile();
                        //af.NomeFile = af.NomeCompleto = a.Documento.Nome.ToCleanJsString() + "." + a.Documento.Estensione;
                        af.NomeFile = af.NomeCompleto = a.Documento.NomeFile.ToCleanJsString();
                        af.NomeCompleto = segnatura;
                        //af.Contenuto = a.Documento.Stream;
                        af.Id = a.Documento.IdFile;
                        af.Tipo = a.Documento.MimeType;
                        docs.Add(af);
                    }
                }

                //aggiunto controllo per segnature multiple e aggiunta dei suoi allegati
                var segnatureMultipleCollectionProvider = new SiarBLL.SegnatureMultipleCollectionProvider();
                var segnatureMultipleCollection = segnatureMultipleCollectionProvider.FindPerSignaturaPrincipale(segnatura);

                if (segnatureMultipleCollection.Count > 0)
                {
                    foreach (SegnatureMultiple segnaturaMultipla in segnatureMultipleCollection)
                    {
                        uo_segnatura = getUoDaSegnaturaProtocollo(segnaturaMultipla.SegnaturaSecondaria);
                        if (operatore_paleo.CodiceUO != uo_segnatura)
                            CaricaWebServiceProtocolloEsistente(uo_segnatura);
                        proto = new SiarBLL.paleoWebService.reqCercaProtocollo();
                        proto.Operatore = operatore_paleo;
                        proto.WithoutStream = withoutStream;

                        if (isProtocollo(segnaturaMultipla.SegnaturaSecondaria))
                            proto.Segnatura = segnaturaMultipla.SegnaturaSecondaria;
                        else
                        {
                            string[] str = segnaturaMultipla.SegnaturaSecondaria.ToString().Split('|');
                            if (str[0] == null) return null;
                            proto.DocNumber = int.Parse(str[0]);
                        }

                        doc = ws.CercaDocumentoProtocollo(proto);
                        if (!CheckDocumentoValido(doc))
                            throw new SiarException(TextErrorCodes.DocumentoNonValido);
                        if (doc.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                            throw new SiarException(TextErrorCodes.RegistroProtocolloChiuso);
                        if (doc.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error)
                            throw new Exception(doc.MessaggioRisultato.Descrizione);

                        // documento principale
                        documentoPrincipale = new ArchivioFile();
                        //documentoPrincipale.NomeFile = documentoPrincipale.NomeCompleto = doc.Oggetto.ToCleanJsString() + "." + doc.Oggetto.DocumentoPrincipale.Estensione;
                        documentoPrincipale.NomeFile = documentoPrincipale.NomeCompleto = doc.Oggetto.DocumentoPrincipale.NomeFile.ToCleanJsString();
                        documentoPrincipale.Id = doc.Oggetto.DocumentoPrincipale.IdFile;
                        documentoPrincipale.NomeCompleto = segnaturaMultipla.SegnaturaSecondaria;
                        //dp.Contenuto = doc.DocumentoPrincipale.Stream;
                        documentoPrincipale.Tipo = doc.Oggetto.DocumentoPrincipale.MimeType;
                        docs.Add(documentoPrincipale);

                        foreach (SiarBLL.paleoWebService.Allegato a in doc.Oggetto.Allegati)
                        {
                            if (a.Documento != null)// doc_supp.Add(new NP_ProtocolloDocSupp(a.Documento.Nome.ToCleanJsString(), a.Documento.Estensione, a.Documento.Stream));
                            {
                                ArchivioFile af = new ArchivioFile();
                                //af.NomeFile = af.NomeCompleto = a.Documento.Nome.ToCleanJsString() + "." + a.Documento.Estensione;
                                af.NomeFile = af.NomeCompleto = a.Documento.NomeFile.ToCleanJsString();
                                af.NomeCompleto = segnaturaMultipla.SegnaturaSecondaria;
                                //af.Contenuto = a.Documento.Stream;
                                af.Id = a.Documento.IdFile;
                                af.Tipo = a.Documento.MimeType;
                                docs.Add(af);
                            }
                        }
                    }
                }

                return docs;
            }
            catch (Exception ex)
            {
                //new SiarLibrary.Email("Errore in ricerca protocollo", "segnatura: " + proto.Segnatura + " " + proto.DocNumber
                //    + "\noperatore: " + proto.Operatore.Nome + " " + proto.Operatore.Cognome + " " + proto.Operatore.Ruolo + " " + proto.Operatore.CodiceUO + "\n\n"
                //    + ex.Message.ToCleanJsString())
                //    .SendAlert();
                throw ex;
            }
            finally { Close(); }
        }

        public string AddVersioneDocumento(string segnatura, string note)
        {
            try
            {
                if (string.IsNullOrEmpty(segnatura) || string.IsNullOrEmpty(note) || documento == null)
                    return null;

                string uo_segnatura = getUoDaSegnaturaProtocollo(segnatura);
                int doc_number = getDocNumberDaSegnaturaProtocollo(segnatura);
                if (operatore_paleo.CodiceUO != uo_segnatura)
                    CaricaWebService(uo_segnatura);

                SiarBLL.paleoWebService.reqAddVersione proto = new SiarBLL.paleoWebService.reqAddVersione();
                proto.Operatore = operatore_paleo;
                proto.DocNumber = doc_number;
                proto.DocumentoPrincipale = documento;
                proto.NoteVersione = note;

                var resp = ws.AddVersioneDocumento(proto);
                if (resp == null)
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);
                if (resp.MessaggioRisultato.Descrizione == "Il registro è chiuso.")
                    throw new SiarException(TextErrorCodes.RegistroProtocolloChiuso);
                if (resp.MessaggioRisultato.TipoRisultato == SiarBLL.paleoWebService.TipoRisultato.Error)
                    throw new Exception(resp.MessaggioRisultato.Descrizione);
                return resp.MessaggioRisultato.Descrizione;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Close(); }
        }

        private bool CheckDocumentoValido(SiarBLL.paleoWebService.BEBaseOfRespDocumentoExtc14f1rMd doc)
        {
            return !(doc == null || doc.Oggetto.DocumentoPrincipale == null);
            //|| 
            //doc.DocumentoPrincipale.Stream == null ||
            //(doc.DocumentoPrincipale.Stream.Length == 0 && (doc.Allegati.Length == 0 || doc.Allegati[0].Documento.Stream == null || doc.Allegati[0].Documento.Stream.Length == 0)));
        }

        private void Close() { if (ws != null) ws.Close(); }

        private void Open()
        {
            try
            {
                if (ws.State == CommunicationState.Closed)
                {
                    ws = new SiarBLL.paleoWebService.PaleoService2Client(configurazione_ws.WsBinding);
                    ws.Endpoint.Address = new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["WsPaleoUrl"]);
                    if (!configurazione_ws.Attivo) throw new SiarException(TextErrorCodes.RegistroProtocolloNonAttivo);
                    Login();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public String GetSHA256(byte[] content)
        {
            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(content);

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void addTrasmissioneUtente(SiarBLL.paleoWebService.TrasmissioneUtente u)
        {
            SiarBLL.paleoWebService.TrasmissioneUtente[] u_supp;
            u_supp = trasmissioneUtenti;
            if (u_supp == null) u_supp = new SiarBLL.paleoWebService.TrasmissioneUtente[1];
            else
            {
                SiarBLL.paleoWebService.TrasmissioneUtente[] u_supp2 = new SiarBLL.paleoWebService.TrasmissioneUtente[u_supp.Length + 1];
                u_supp.CopyTo(u_supp2, 0);
                u_supp = u_supp2;
            }
            u_supp[u_supp.Length - 1] = u;
            trasmissioneUtenti = u_supp;
        }

        public void setTrasmisisoneUtente(string cognome, string nome, string struttura, string cod_ruolo, string ragione)
        {
            SiarBLL.paleoWebService.TrasmissioneUtente trasmissioneUtente = new SiarBLL.paleoWebService.TrasmissioneUtente();
            trasmissioneUtente.OperatoreDestinatario = new SiarBLL.paleoWebService.OperatorePaleo();
            trasmissioneUtente.OperatoreDestinatario.Cognome = cognome;
            trasmissioneUtente.OperatoreDestinatario.Nome = nome;
            trasmissioneUtente.OperatoreDestinatario.CodiceUO = struttura;
            trasmissioneUtente.OperatoreDestinatario.CodiceRuolo = cod_ruolo;
            //trasmissioneUtente.Ragione = ragione;
            trasmissioneUtente.CodiceRagione = ragione;
            addTrasmissioneUtente(trasmissioneUtente);
        }

    }
}
