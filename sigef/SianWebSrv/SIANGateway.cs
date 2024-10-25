using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using SianWebSrv.PSR;
using System.Collections.Specialized;


namespace SianWebSrv
{

    /// <summary>
    /// Questa classe gestisce la comunicazione SOAP con il server SIAN,
    /// non andrebbe usata mai direttamente.
    /// Le classi AnagrafeTributaria e FascicoloAziendale
    /// mantengono internamente un riferimento ad un oggetto di questa classe e lo
    /// utilizzano per inviare richieste al server SIAN. 
    /// </summary>
    public class SIANGateway
    {
        public static class XPathAT
        {
            public static StringDictionary GetNameSpaceList()
            {
                StringDictionary NameSpaceList = new System.Collections.Specialized.StringDictionary();
                NameSpaceList.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                NameSpaceList.Add("ns1", "http://cooperazione.sian.it/schema/fascicolo");
                return NameSpaceList;
            }

            public const string RootSint = "soapenv:Envelope/soapenv:Body/ns1:ISWSReturnInt";
            public const string RootDett = "soapenv:Envelope/soapenv:Body/ns1:ISWSReturnDett";

            public static class Error
            {
                public const string Root = "./soapenv:Envelope/soapenv:Body/env:Fault";
                public const string faultcode = "faultcode";
                public const string faultstring = "faultstring";
                public const string faultactor = "faultactor";
                public const string detail = "detail";
            }

            public static class rispostaType
            {
                public const string Root = "/ns1:rispostaType";
                public const string codRet = "ns1:codRet";
                public const string Segnalazione = "ns1:msgRet";
            }

            public static class rispostaSint
            {
                public const string Root = "/ns1:risposta";
                public const string capDomicilioFiscale = "ns1:capDomicilioFiscale";
                public const string capResidenza = "ns1:capResidenza";
                public const string capSedeLegale = "ns1:capSedeLegale";
                public const string codiceFiscale = "ns1:codiceFiscale";
                public const string cognome = "ns1:cognome";
                public const string comuneDomicilioFiscale = "ns1:comuneDomicilioFiscale";
                public const string comuneNascita = "ns1:comuneNascita";
                public const string comuneResidenza = "ns1:comuneResidenza";
                public const string comuneSedeLegale = "ns1:comuneSedeLegale";
                public const string dataNascita = "ns1:dataNascita";
                public const string denominazione = "ns1:denominazione";
                public const string indirizzoDomicilioFiscale = "ns1:indirizzoDomicilioFiscale";
                public const string indirizzoResidenza = "ns1:indirizzoResidenza";
                public const string indirizzoSedeLegale = "ns1:indirizzoSedeLegale";
                public const string naturaGiuridica = "ns1:naturaGiuridica";
                public const string nome = "ns1:nome";
                public const string partitaIva = "ns1:partitaIva";
                public const string provinciaDomicilioFiscale = "ns1:provinciaDomicilioFiscale";
                public const string provinciaNascita = "ns1:provinciaNascita";
                public const string provinciaResidenza = "ns1:provinciaResidenza";
                public const string provinciaSedeLegale  = "ns1:provinciaSedeLegale";
                public const string sesso = "ns1:sesso";
            }

            public static class rispostaDett
            {
                public const string Root = "/ns1:risposta/ns1:ISATDett";
                public const string dataInizioAttivita = "ns1:dataInizioAttivita";
                public const string codiceFiscaleRappresentante = "ns1:codiceFiscaleRappresentante";
                public const string cognomeRappresentante = "ns1:cognomeRappresentante";
                public const string nomeRappresentante = "ns1:nomeRappresentante";
                public const string denominazioneRappresentante = "ns1:denominazioneRappresentante";
                public const string statoAttivita = "ns1:statoAttivita";
                public const string statoAttvitaDesc = "ns1:statoAttvitaDesc";
                public const string tipoAttivita = "ns1:tipoAttivita";
                public const string tipoCarica = "ns1:tipoCarica";
                public const string tipoCaricaDesc = "ns1:tipoCaricaDesc";

                public static class cfCollegati
                {
                    public const string Root = "/ns1:cfCollegati/ns1:CUAAType";
                }

                public static class ISATDomicilioFiscaleVariato
                {
                    public const string Root = "/ns1:domiciliFiscaliVariati/ns1:ISATDomicilioFiscaleVariato";
                    public const string capDomicilioFiscale = "ns1:capDomicilioFiscale";
                    public const string comuneDomicilioFiscale = "ns1:comuneDomicilioFiscale";
                    public const string dataFine = "ns1:dataFine";
                    public const string indirizzoDomicilioFiscale = "ns1:indirizzoDomicilioFiscale";
                    public const string provinciaDomicilioFiscale = "ns1:provinciaDomicilioFiscale";
                }

                public static class ISATPartitaIvaAttribuita
                {
                    public const string Root = "/ns1:partiteIvaAttribuite/ns1:ISATPartitaIvaAttribuita";
                    public const string dataFine = "ns1:dataFine";
                    public const string decoModFine = "ns1:decoModFine";
                    public const string decoTipoFine  = "ns1:decoTipoFine";
                    public const string decoTipoFinePf = "ns1:decoTipoFinePf";
                    public const string decoTipoFinePnf = "ns1:decoTipoFinePnf";
                    public const string modelloFine = "ns1:modelloFine";
                    public const string modelloFineDesc = "ns1:modelloFineDesc";
                    public const string partitaIva = "ns1:partitaIva";
                    public const string partitaIvaConfluenza = "ns1:partitaIvaConfluenza";
                    public const string tipoFine = "ns1:tipoFine";
                    public const string tipoFineDesc = "ns1:tipoFineDesc";
                }

                public static class ISATRappresentanteSocieta
                {
                    public const string Root = "/ns1:rappresentantiSocieta/ns1:ISATRappresentanteSocieta";
                    public const string codiceFiscale = "ns1:codiceFiscale";
                    public const string dataFine = "ns1:dataFine";
                    public const string dataInizio = "ns1:dataInizio";
                    public const string decoTipoCari = "ns1:decoTipoCari";
                    public const string decoTipoCariPf = "ns1:decoTipoCariPf";
                    public const string decoTipoCariPnf = "ns1:decoTipoCariPnf";
                    public const string tipoCarica = "ns1:tipoCarica";
                    public const string tipoCaricaDesc = "ns1:tipoCaricaDesc";
                }

                public static class ISATResidenzaVariata
                {
                    public const string Root = "/ns1:residenzeVariate/ns1:ISATResidenzaVariata";
                    public const string capResidenza = "ns1:capResidenza";
                    public const string comuneResidenza = "ns1:comuneResidenza";
                    public const string dataFine = "ns1:dataFine";
                    public const string dataInizio = "ns1:dataInizio";
                    public const string indirizzoResidenza = "ns1:indirizzoResidenza";
                    public const string provinciaResidenza = "ns1:provinciaResidenza";
                }

                public static class ISATSocietaRappresentata
                {
                    public const string Root = "/ns1:societaRappresentate/ns1:ISATSocietaRappresentata";
                    public const string codiceFiscaleRappresentato = "ns1:codiceFiscaleRappresentato";
                    public const string dataFine = "ns1:dataFine";
                    public const string dataInizio = "ns1:dataInizio";
                    public const string decoTipoRapp = "ns1:decoTipoRapp";
                    public const string tipoRappresentanza = "ns1:tipoRappresentanza";
                    public const string tipoRappresentanzaDesc = "ns1:tipoRappresentanzaDesc";
                }

            }

        }


        public static class XpathZucchero2009
        {
            public static class ISWSResponseASZ
            {
                public static StringDictionary GetNameSpaceList()
                {
                    StringDictionary NameSpaceList = new System.Collections.Specialized.StringDictionary();
                    NameSpaceList.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                    NameSpaceList.Add("ns1", "http://cooperazione.sian.it/schema/Zucchero");
                    NameSpaceList.Add("env", "http://schemas.xmlsoap.org/soap/envelope/");
                    return NameSpaceList;
                }

                //public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ISWSResponseASZ"; // modificato versione 2.0
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseASZ";
                public static class CUAAType
                {
                    public const string Root = "ns1:CUAAType";
                    public const string CodiceFiscalePersonaFisica = "ns1:CodiceFiscalePersonaFisica";
                    public const string CodiceFiscalePersonaGiuridica = "ns1:CodiceFiscalePersonaFisica";
                }
                public const string IdDomaOp = "ns1:IdDomaOp";
                public const string CodiBarrCode = "ns1:CodiBarrCode";
                public const string TotaImpoRich = "ns1:TotaImpoRich";          // aggiunti versione 2.0
                public const string TotaImpoConcIstr = "ns1:TotaImpoConcIstr";  // aggiunti versione 2.0
                public const string TotaImpoConcRevi = "ns1:TotaImpoConcRevi";  // aggiunti versione 2.0

                //public const string Esito = "ns1:Esito"; eliminato versione 2.0

                public static class ISWSErroriASZ
                {
                    public const string Root = "ns1:Errore";  // modificato versione 2.0
                    public const string NomeOggetto = "ns1:NomeOggetto";
                    public const string CampoErrato = "ns1:CampoErrato";
                    public const string TipoErrore = "ns1:TipoErrore";
                    public const string DescErrore = "ns1:DescErrore";
                }

            }

            public static class Fault
            {
                public static StringDictionary GetNameSpaceList()
                {
                    StringDictionary NameSpaceList = new System.Collections.Specialized.StringDictionary();
                    NameSpaceList.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                    NameSpaceList.Add("env", "http://schemas.xmlsoap.org/soap/envelope/");
                    return NameSpaceList;
                }
                public const string Root = "soapenv:Envelope/soapenv:Body/env:Fault";
                public const string faultcode = "faultcode";
                public const string faultstring = "faultstring";
                public const string faultactor = "faultactor";
                public const string detail = "detail";
            }

            /*public static class ResponseASR
             * sostutita da ResponseASRDomanda nella versione 2.0
            {
                public static StringDictionary GetNameSpaceList()
                {
                    StringDictionary NameSpaceList = new System.Collections.Specialized.StringDictionary();
                    NameSpaceList.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                    //NameSpaceList.Add("env", "http://schemas.xmlsoap.org/soap/envelope/");
                    NameSpaceList.Add("ns1", "http://cooperazione.sian.it/schema/ASRDomanda");
                    return NameSpaceList;
                }
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseASR";
                public const string codRet = "ns1:codRet";
                public const string segnalazione = "ns1:segnalazione";
            }
            */

            // aggiunta versione 2.0
            public static class ResponseASRDomanda
            {
                public static StringDictionary GetNameSpaceList()
                {
                    StringDictionary NameSpaceList = new System.Collections.Specialized.StringDictionary();
                    NameSpaceList.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                    NameSpaceList.Add("ns1", "http://cooperazione.sian.it/schema/ASRDomanda");
                    return NameSpaceList;
                }
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseASZ";
                public static class CUAAType
                {
                    public const string Root = "ns1:CUAAType";
                    public const string CodiceFiscalePersonaFisica = "ns1:CodiceFiscalePersonaFisica";
                    public const string CodiceFiscalePersonaGiuridica = "ns1:CodiceFiscalePersonaFisica";
                }
                public const string IdDomaOp = "ns1:IdDomaOp";
                public static class ISWSErroriASZ
                {
                    public const string Root = "ns1:Errore";  
                    public const string NomeOggetto = "ns1:NomeOggetto";
                    public const string CampoErrato = "ns1:CampoErrato";
                    public const string TipoErrore = "ns1:TipoErrore";
                    public const string DescErrore = "ns1:DescErrore";
                }
            }


        }

        public static class XpathPSR
        {
            public static class ISWSAnagraficaASR
            {
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseScaricoDomandaOnlineASR/ns1:ISWSDomandaASR/ns1:ISWSAnagraficaASR";
                public static class CUAAType
                {
                    public const string Root = "ns1:CUAAType";
                    public const string PersonaFisicaTagName = "CodiceFiscalePersonaFisica";
                    public const string PersonaGiuridicaTagName = "CodiceFiscalePersonaGiuridica";
                    public const string CodiceFiscalePersonaFisica = "ns1:" + PersonaFisicaTagName;
                    public const string CodiceFiscalePersonaGiuridica = "ns1:" + PersonaGiuridicaTagName;
                }
                public const string IdDomaOP = "ns1:idDomaOP";
                public const string TipoDoma = "ns1:tipoDoma";
                public const string AnnoCampagna = "ns1:annoCampagna";
                public const string IdDomaSostituita = "ns1:idDomaSostituita";
                public const string CodiRegi = "ns1:codiRegi";
                public const string codiRea = "ns1:codiRea";
                public const string codiAsl = "ns1:codiAsl";
                public const string CodiEnte = "ns1:codiEnte";
                public const string Descrizione = "ns1:descrizione";
                public const string CodiRi = "ns1:codiRi";
                public const string codiFiscRLeg = "ns1:codiFiscRLeg";

                public static class ISWSIndirizzoASR
                {
                    public const string Root = "ns1:ISWSIndirizzoASR";
                    public const string Provincia = "ns1:provincia";
                    public const string Comune = "ns1:comune";
                    public const string Indirizzo = "ns1:indirizzo";
                    public const string CAP = "ns1:CAP";
                    public const string CodiceStatoEstero = "ns1:codiceStatoEstero";
                }

            }

            public static class ISWSSuperficiASR
            {
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseScaricoDomandaOnlineASR/ns1:ISWSDomandaASR/ns1:ISWSSuperficiASR";
                public const string idDomaOP = "ns1:idDomaOP";
                public const string annoCampagna = "ns1:annoCampagna";
                public const string provinciaISTAT = "ns1:provincia";
                public const string comuneISTAT = "ns1:comune";
                public const string sezione = "ns1:sezione";
                public const string foglio = "ns1:foglio";
                public const string particella = "ns1:particella";
                public const string subalterno = "ns1:subalterno";
                public const string prodotto = "ns1:prodotto";
                public const string varieta = "ns1:varieta";
                public const string codiFascAltiDich = "ns1:codiFascAltiDich";
                public const string decoTipoAreC = "ns1:decoTipoAreC";
                public const string decoTipoAreD = "ns1:decoTipoAreD";
                public const string flagColtBiol = "ns1:flagColtBiol";
                public const string flagPasc = "ns1:flagPasc";

                public static class ISWSInterventiASR
                {
                    public const string Root = "ns1:ISWSInterventiASR";
                    public const string codiTipoMisu = "ns1:codiTipoMisu";
                    public const string codiAzio = "ns1:codiAzio";
                    public const string codiSubbAzio = "ns1:codiSubbAzio";
                    public const string codiInte = "ns1:codiInte";
                    public const string supUtilizzata = "ns1:supUtilizzata";
                    public const string supPremio = "ns1:supPremio";
                }

            }

            public static class ISWSFormaGiuridicaASR
            {
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseScaricoDomandaOnlineASR/ns1:ISWSDomandaASR/ns1:ISWSFormaGiuridicaASR";
                public const string codiPersGiur = "ns1:codiPersGiur";
                public const string numePersGiur = "ns1:numePersGiur";
                public const string numePersGiurGiov = "ns1:numePersGiurGiov";
                public const string numePersGiurDonne = "ns1:numePersGiurDonne";
                public const string codiSociCoop = "ns1:codiSociCoop";
                public const string numeSociCoop = "ns1:numeSociCoop";
                public const string numeSociGiov = "ns1:numeSociGiov";
                public const string numeSociDonne = "ns1:numeSociDonne";
                public const string codiConsCoop = "ns1:codiConsCoop";
                public const string numeConsCoop = "ns1:numeConsCoop";
                public const string numeConsSoci = "ns1:numeConsSoci";
                public const string codiAssoProd = "ns1:codiAssoProd";
                public const string numeAssoProd = "ns1:numeAssoProd";
                public const string codiSociAccomandita = "ns1:codiSociAccomandita";
                public const string numeSociAccomandita = "ns1:numeSociAccomandita";
                public const string codiSociCapi = "ns1:codiSociCapi";
                public const string numedipendenti = "ns1:numedipendenti";
                public const string assoImprese = "ns1:assoImprese";
                public const string assoNoLucro = "ns1:assoNoLucro";
                public const string assoCategorie = "ns1:assoCategorie";
                public const string formRegi = "ns1:formRegi";
                public const string formProv = "ns1:formProv";
                public const string formComune = "ns1:formComune";
                public const string comunMontan = "ns1:comunMontan";
                public const string consComuni = "ns1:consComuni";
                public const string consForestale = "ns1:consForestale";
                public const string enteParco = "ns1:enteParco";
                public const string consBoniIrriga = "ns1:consBoniIrriga";
                public const string altroEntePubb = "ns1:altroEntePubb";
                public const string consTutela = "ns1:consTutela";
                public const string flagEnteForm = "ns1:flagEnteForm";
                public const string descAltro = "ns1:descAltro";
            }

            public static class ISWSAttivitaSvolteASR
            {
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseScaricoDomandaOnlineASR/ns1:ISWSDomandaASR/ns1:ISWSAttivitaSvolteASR";
                public const string Agriturismo = "ns1:agritur";
                public const string AttivRicreative = "ns1:attivRicr";
                public const string Artigianato = "ns1:artig";
                public const string ContoTerzismo = "ns1:contot";
                public const string Trasformazione = "ns1:lavoTransfProdAgric";
                public const string EnergiaRinnov = "ns1:prodEnergRinnov";
                public const string Altro = "ns1:altraAttivConnes";
            }

            public static class ISWSConsistenzaZooTecnicaASR
            {
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseScaricoDomandaOnlineASR/ns1:ISWSDomandaASR/ns1:ISWSConsistenzaZooTecnicaASR";
                public const string codiTipoZootecnia = "ns1:codiTipoZootecnia";
                public const string numeCapi = "ns1:numeCapi";
                public const string numeCapiFemmine = "ns1:numeCapiFemmine";
            }

            public static class ISWSFormaConduzioneAziendaleASR
            {
                public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseScaricoDomandaOnlineASR/ns1:ISWSDomandaASR/ns1:ISWSFormaConduzioneAziendaleASR";
                public const string SolaManoFam = "ns1:condDireSolaManoFam";
                public const string ManoFamiPrev = "ns1:condDireManoFamiPrev";
                public const string ManoExtrafamiPrev = "ns1:condDireManoExtrafamiPrev";
                public const string ConSalar = "ns1:condNonDireConSalar";
                public const string AltraForma = "ns1:condNonDireAltraForma";
            }

            public static class AdesioneMisura
            {
                // comuni a misure compensative e agroambientali
                public const string codiTipoMisu = "ns1:codiTipoMisu";
                public const string flagAnnoImp1 = "ns1:flagAnnoImp1";
                public const string flagAnnoImp2 = "ns1:flagAnnoImp2";
                public const string flagAnnoImp3 = "ns1:flagAnnoImp3";
                public const string flagAnnoImp4 = "ns1:flagAnnoImp4";
                public const string flagAnnoImp5 = "ns1:flagAnnoImp5";
                public const string numeAnnoImpeInco = "ns1:numeAnnoImpeInco";
                public const string numeAnnoDomaIniz = "ns1:numeAnnoDomaIniz";
                public const string numeDomaAnnoIniz = "ns1:numeDomaAnnoIniz";
                public const string numeDomaAnnoPrec = "ns1:numeDomaAnnoPrec";

                public static class ISWSCampiPersonalizzatiASR
                {
                    public const string Root = "ns1:ISWSCampiPersonalizzatiASR";
                    public const string descrizione = "ns1:descrizione";
                    public const string valore = "ns1:valore";
                }

                public static class Compensativa
                {
                    // specifici misure compensative
                    public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseScaricoDomandaOnlineASR/ns1:ISWSDomandaASR/ns1:ISWSAdesioneMisuraCompensativaASR";
                    public const string dataInizImp = "ns1:dataInizImp";
                    public const string dataFineImpe = "ns1:dataFineImpe";
                }

                public static class Agroambientali
                {
                    // specifici misure Agroambientali
                    public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ResponseScaricoDomandaOnlineASR/ns1:ISWSDomandaASR/ns1:ISWSAdesioneMisuraAgroASR";
                    public const string DomaIniz = "ns1:flagFinaDomaIniz";
                    public const string SostImpe = "ns1:flagFinaSostImpe";
                    public const string TrasImpe = "ns1:flagFinaTrasImpe";
                    public const string CambMisuAzio = "ns1:flagFinaCambMisuAzio";
                    public const string AggiAnnu = "ns1:flagFinaAggiAnnu";
                    public const string CambBene = "ns1:flagFinaCambBene";
                    public const string AmplImpe = "ns1:flagFinaAmplImpe";

                    public static class ISWSImpegniAdesioneMisuraAgroASR
                    {
                        public const string Root = "ns1:ISWSImpegniAdesioneMisuraAgroASR";
                        public const string codiTipoMisu = "ns1:codiTipoMisu";
                        public const string codiAzio = "ns1:codiAzio";
                        public const string descAzio = "ns1:descAzio";
                        public const string supeAzio = "ns1:supeAzio";
                        public const string quantitaUBA = "ns1:quantitaUBA";
                        public const string dataInizImpeUBAA = "ns1:dataInizImpeUBAA";
                        public const string dataFineImpeUBAA = "ns1:dataFineImpeUBAA";
                        public const string dataInizImp = "ns1:dataInizImp";
                        public const string dataFineImpe = "ns1:dataFineImpe";
                    }
                }

            }


        }

        public static class XPathFascicolo20
        {
            public static StringDictionary GetNameSpaceList(){
                StringDictionary NameSpaceList = new System.Collections.Specialized.StringDictionary();
                NameSpaceList.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                NameSpaceList.Add("ns1", "http://cooperazione.sian.it/schema/fascicolo");
                NameSpaceList.Add("env", "http://schemas.xmlsoap.org/soap/envelope/");
                return NameSpaceList;
            }

            public const string Root = "soapenv:Envelope/soapenv:Body/ns1:ISWSToOprResponse";

            public static class Error
            {
                public const string Root = "./soapenv:Envelope/soapenv:Body/env:Fault";
                public const string faultcode = "faultcode";
                public const string faultstring = "faultstring";
                public const string faultactor = "faultactor";
                public const string detail = "detail";
            }

            public static class rispostaType
            {
                public const string Root = "/ns1:rispostaType";
                public const string codRet = "ns1:codRet";
                public const string Segnalazione = "ns1:Segnalazione";
            }

            public static class ISWSResponse
            {
                public const string Root = "/ns1:ISWSResponse";
                public const string codRet = "ns1:codRet";
                public const string Segnalazione = "ns1:Segnalazione";
            }

            public static class risposta1
            {
                public const string Root = "/ns1:risposta1";
                public const string CUAA = "ns1:CUAA";
                public const string tipoAzienda = "ns1:tipoAzienda";
                public const string denominazione = "ns1:denominazione";
                public const string nomePF = "ns1:nomePF";
                public const string sessoPF = "ns1:sessoPF";
                public const string dataNascitaPF = "ns1:dataNascitaPF";
                public const string comuneNascitaPF = "ns1:comuneNascitaPF";
                public const string partitaIVA = "ns1:partitaIVA";
                public const string iscrizioneRea = "ns1:iscrizioneRea";
                public const string iscrizioneRegistroImprese = "ns1:iscrizioneRegistroImprese";
                public const string codiceInps = "ns1:codiceInps";
                public const string organismoPagatore = "ns1:organismoPagatore";
                public const string dataAperturaFascicolo = "ns1:dataAperturaFascicolo";
                public const string dataChiusuraFascicolo = "ns1:dataChiusuraFascicolo";
                public const string tipoDetentore = "ns1:tipoDetentore";
                public const string detentore = "ns1:detentore";
                public const string dataValidazFascicolo = "ns1:dataValidazFascicolo";
                public const string dataElaborazione = "ns1:dataElaborazione";

                public static class sedeResidenza
                {
                    public const string Root = "/ns1:sedeResidenza";
                    public const string provincia = "ns1:provincia";
                    public const string comune = "ns1:comune";
                    public const string indirizzo = "ns1:indirizzo";
                    public const string cap = "ns1:cap";
                    public const string codiceStatoEstero = "ns1:codiceStatoEstero";
                }

                public static class recapito
                {
                    public const string Root = "/ns1:recapito";
                    public const string provincia = "ns1:provincia";
                    public const string comune = "ns1:comune";
                    public const string indirizzo = "ns1:indirizzo";
                    public const string cap = "ns1:cap";
                    public const string codiceStatoEstero = "ns1:codiceStatoEstero";
                }

            }

            public static class risposta2
            {
                public const string Root = "/ns1:risposta2";

                public static class ISWSTerritorio
                {
                    public const string Root = "/ns1:ISWSTerritorio";
                    public const string Sezione = "ns1:Sezione";
                    public const string Foglio = "ns1:Foglio";
                    public const string Particella = "ns1:Particella";
                    public const string Subalterno = "ns1:Subalterno";
                    public const string codiceTipoConduzione = "ns1:codiceTipoConduzione";
                    public const string DataInizioConduzione = "ns1:DataInizioConduzione";
                    public const string DataFineConduzione = "ns1:DataFineConduzione";
                    public const string SuperficieCatastale = "ns1:SuperficieCatastale";
                    public const string SuperficieCondotta = "ns1:SuperficieCondotta";
                    public const string CUAA = "ns1:CUAA";
                    public const string Comune = "ns1:Comune";
                    public const string Provincia = "ns1:Provincia";

                    public static class Proprietari
                    {
                        public const string Root = "ns1:Proprietari";
                        public const string Proprietario = "ns1:Proprietario";
                    }

                    public static class Destinazione
                    {
                        public const string Root = "ns1:Destinazione";
                        public static class ISWSUtilizzoTerra
                        {
                            public const string Root = "ns1:ISWSUtilizzoTerra";
                            public const string codiceProdotto = "ns1:codiceProdotto";
                            public const string codiceVarieta = "ns1:codiceVarieta";
                            public const string superficieUtilizzata = "ns1:superficieUtilizzata";
                        }
                    }
                }

                public static class ISWSAllevamenti
                {
                    public const string Root = "ns1:ISWSAllevamenti";
                }
            }

            public static class risposta2TP
            {
                public const string Root = "/ns1:risposta2";
                public const string Sezione = "ns1:Sezione";
                public const string Foglio = "ns1:Foglio";
                public const string Particella = "ns1:Particella";
                public const string Subalterno = "ns1:Subalterno";
                public const string codiceTipoConduzione = "ns1:codiceTipoConduzione";
                public const string DataInizioConduzione = "ns1:DataInizioConduzione";
                public const string DataFineConduzione = "ns1:DataFineConduzione";
                public const string SuperficieCatastale = "ns1:SuperficieCatastale";
                public const string SuperficieCondotta = "ns1:SuperficieCondotta";
                public const string CUAA = "ns1:CUAA";
                public const string Comune = "ns1:Comune";
                public const string Provincia = "ns1:Provincia";

                public static class Proprietari
                {
                    public const string Root = "ns1:Proprietari";
                    public const string Proprietario = "ns1:proprietario";
                }

                public static class Destinazione
                {
                    public const string Root = "ns1:Destinazione";
                    public const string codiceProdotto = "ns1:codiceProdotto";
                    public const string codiceVarieta = "ns1:codiceVarieta";
                    public const string superficieUtilizzata = "ns1:superficieUtilizzata";
                }
            }

            public static class risposta5
            {
                public const string Root = "/ns1:risposta5";

                public const string Sezione = "ns1:Sezione";
                public const string Foglio = "ns1:Foglio";
                public const string Particella = "ns1:Particella";
                public const string Subalterno = "ns1:Subalterno";
                public const string codiceTipoConduzione = "ns1:codiceTipoConduzione";
                public const string DataInizioConduzione = "ns1:DataInizioConduzione";
                public const string DataFineConduzione = "ns1:DataFineConduzione";
                public static class Proprietari
                {
                    public const string Root = "ns1:Proprietari";
                    public const string proprietario = "ns1:proprietario";
                }
                public const string SuperficieCatastale = "ns1:SuperficieCatastale";
                public const string SuperficieCondotta = "ns1:SuperficieCondotta";
                public const string CUAA = "ns1:CUAA";
                public const string Comune = "ns1:Comune";
                public const string Provincia = "ns1:Provincia";
                public static class Destinazione
                {
                    public const string Root = "ns1:Destinazione";
                    public const string codiceMacrouso = "ns1:codiceMacrouso";
                    public const string codiceQualita = "ns1:codiceQualita";
                    public const string superficieUtilizzata = "ns1:superficieUtilizzata";

                    public static class Dettagli
                    {
                        public const string Root = "ns1:Dettagli";
                        public const string codiceProdotto = "ns1:codiceProdotto";
                        public const string codiceVarieta = "ns1:codiceVarieta";
                        public const string superficieUtilizzata = "ns1:superficieUtilizzata";
                    }
                }
                public const string TipoDocumento = "ns1:TipoDocumento";
                public const string NumeroDocumento = "ns1:NumeroDocumento";
                public const string DataDocumento = "ns1:DataDocumento";
                public const string FlagIrrigua = "ns1:FlagIrrigua";
                public const string FlagTerrazzata = "ns1:FlagTerrazzata";
                public const string RotazioneColtureOrtive = "ns1:RotazioneColtureOrtive";
                public const string EffluentiZootecnici = "ns1:EffluentiZootecnici";
                public const string SostanzePericolose = "ns1:SostanzePericolose";
                public const string CasiParticolari = "ns1:CasiParticolari ";
                public const string FlagGiust = "ns1:FlagGiust";
            }

            public static class risposta21
            {
                public const string Root = "/ns1:risposta21";

                public const string Sezione = "ns1:Sezione";
                public const string Foglio = "ns1:Foglio";
                public const string Particella = "ns1:Particella";
                public const string Subalterno = "ns1:Subalterno";
                public const string codiceTipoConduzione = "ns1:codiceTipoConduzione";
                public const string DataInizioConduzione = "ns1:DataInizioConduzione";
                public const string DataFineConduzione = "ns1:DataFineConduzione";
                public static class Proprietari
                {
                    public const string Root = "ns1:Proprietari";
                    public const string proprietario = "ns1:proprietario";
                }
                public const string SuperficieCatastale = "ns1:SuperficieCatastale";
                public const string SuperficieCondotta = "ns1:SuperficieCondotta";
                public const string CUAA = "ns1:CUAA";
                public const string Comune = "ns1:Comune";
                public const string Provincia = "ns1:Provincia";
                public static class Destinazione
                {
                    public const string Root = "ns1:Destinazione";
                    public const string codiceMacrouso = "ns1:codiceMacrouso";
                    public const string codiceQualita = "ns1:codiceQualita";
                    public const string superficieUtilizzata = "ns1:superficieUtilizzata";
                    public const string superficieEligibile = "ns1:superficieEligibile";
                    public const string dataInizioUtilizzo = "ns1:DataInizioUtilizzo";
                    public const string dataFineUtilizzo = "ns1:DataFineUtilizzo"; 
                    public static class Dettagli
                    {
                        public const string Root = "ns1:Dettagli";
                        public const string codiceProdotto = "ns1:codiceProdotto";
                        public const string codiceVarieta = "ns1:codiceVarieta";
                        public const string superficieUtilizzata = "ns1:SuperficieUtilizzata";
                        public const string superficieEligibile = "ns1:SuperficieEligibile";
                        public const string numeroPiante = "ns1:NumeroPiante";
                        public const string flagColtPrincipale = "ns1:FlagColtPrincipale";
                        public const string formaAllevamento = "ns1:FormaAllevamento";
                        public const string annoImpianto = "ns1:AnnoImpianto";
                        public const string sestoImpiantoSuFila = "ns1:SestoImpiantoSuFila";
                        public const string sestoImpiantoTraFile = "ns1:SestoImpiantoTraFile";
                        public const string tipoImpianto = "ns1:TipoImpianto";
                        public const string coltivazioneBiologica = "ns1:ColtivazioneBiologica";
                        public const string tipologiaSemina = "ns1:TipologiaSemina";
                        public const string tipologiaIrrigazione = "ns1:TipologiaIrrigazione";
                        public const string protezioneColture = "ns1:ProtezioneColture";
                        public const string faseAllevamento = "ns1:FaseAllevamento";
                        public const string mantPratiPermanente = "ns1:MantPratiPermanente";
                        public const string mantenSupAgricola = "ns1:MantenSupAgricola";
                        public const string tipoCertificazione = "ns1:tipoCertificazione";
                        public const string percentuale = "ns1:percentuale";
                        public const string menzione = "ns1:menzione";
                        public const string tipoUtilizzoOlivo = "ns1:tipoUtilizzoOlivo";
                        public const string capacitaProduttiva = "ns1:capacitaProduttiva";
                        public const string altitudine = "ns1:altitudine";
                    }
                }
                public const string TipoDocumento = "ns1:TipoDocumento";
                public const string NumeroDocumento = "ns1:NumeroDocumento";
                public const string DataDocumento = "ns1:DataDocumento";
                public const string FlagIrrigua = "ns1:FlagIrrigua";
                public const string FlagTerrazzata = "ns1:FlagTerrazzata";
                public const string RotazioneColtureOrtive = "ns1:RotazioneColtureOrtive";
                public const string EffluentiZootecnici = "ns1:EffluentiZootecnici";
                public const string SostanzePericolose = "ns1:SostanzePericolose";
                public const string CasiParticolari = "ns1:CasiParticolari";
                public const string FlagGiust = "ns1:FlagGiust";
            }


            public static class risposta7
            {
                public const string Root = "/ns1:risposta7";
                public const string CUAA = "ns1:CUAA";
                public const string TipoMacchina = "ns1:TipoMacchina";
                public const string FormaPossesso = "ns1:FormaPossesso";
                public const string Targa = "ns1:Targa";
                public const string TipoTarga = "ns1:TipoTarga";
                public const string Marca = "ns1:Marca";
                public const string Modello = "ns1:Modello";
                public const string Telaio = "ns1:Telaio";
                public const string Carburante = "ns1:Carburante";
                public const string Trazione = "ns1:Trazione";
                public const string DataIscrizione = "ns1:DataIscrizione";
                public const string DataCessazione = "ns1:DataCessazione";
            }

            public static class ISWSFabbricato
            {
                public const string Root = "/ns1:risposta8";
                public const string CUAA = "ns1:CUAA";
                public const string provincia = "ns1:provincia";
                public const string comune = "ns1:comune";
                public const string sezione = "ns1:sezione";
                public const string foglio = "ns1:foglio";
                public const string particella = "ns1:particella";
                public const string subalterno = "ns1:subalterno";
                public const string tipo = "ns1:tipo";
                public const string destinazione = "ns1:destinazione";
                public const string CasiParticolari = "ns1:CasiParticolari";
                public const string SuperficieCoperta = "ns1:SuperficieCoperta";
                public const string SuperficieScoperta = "ns1:SuperficieScoperta";
                public const string Volume = "ns1:Volume";
                public const string NumeroPosti = "ns1:NumeroPosti";
                public const string TipoConduzione = "ns1:TipoConduzione";
                public const string DataInizioConduzione = "ns1:DataInizioConduzione";
                public const string DataFineConduzione = "ns1:DataFineConduzione";

                public static class ISWSUtilizzoFabbricato
                {
                    public const string Root = "ns1:uso";
                    public const string CUAA = "ns1:CUAA";
                    public const string qualifica = "ns1:qualifica";
                }

                public static class ISWSProprietario
                {
                    public const string Root = "ns1:proprietari";
                    public const string proprietario = "ns1:proprietario";

                }
            }

            public static class ISWSLavoro
            {
                public const string Root = "/ns1:risposta6";

                public const string CUAA = "ns1:CUAA";
                public const string TipoLavoroPrevalente = "ns1:TipoLavoroPrevalente";
                public const string TipoCollaborazione = "ns1:TipoCollaborazione";
                public const string TipoLavoratori = "ns1:TipoLavoratori";
                public const string UnitaMisura = "ns1:UnitaMisura";
                public const string Quantita = "ns1:Quantita";
            }

            public static class ISWSCondizionalita
            {
                public const string Root = "/ns1:risposta4";

                public const string CUAA = "ns1:CUAA";
                public const string CodiceCondizionalita = "ns1:CodiceCondizionalita";
            }

            public static class ISWSSegnalazione
            {
                public const string Root = "/ns1:risposta3";

                public const string CUAA = "ns1:CUAA";
                public const string provincia = "ns1:provincia";
                public const string comune = "ns1:comune";
                public const string sezione = "ns1:sezione";
                public const string foglio = "ns1:foglio";
                public const string particella = "ns1:particella";
                public const string subalterno = "ns1:subalterno";
                public const string CodiceMacrouso = "ns1:CodiceMacrouso";
                public const string CodiceTipoSegnalazione = "ns1:CodiceTipoSegnalazione";
                public const string CodiceSegnalazione = "ns1:CodiceSegnalazione";
            }

            public static class ISWSContoCorrente
            {
                public const string Root = "/ns1:risposta14";

                public const string ContoCorrente = "ns1:ContoCorrente";
                public const string Codi_swift1 = "ns1:Codi_swift1";
                public const string Codi_swift2 = "ns1:Codi_swift2";
                public const string Data_fine = "ns1:Data_fine";
            }

            public static class risposta9
            {
                public const string Root = "/ns1:risposta9";

                public const string CUAA = "ns1:CUAA";
                public const string Provincia = "ns1:Provincia";
                public const string Comune = "ns1:Comune";
                public const string Sezione = "ns1:Sezione";
                public const string Foglio = "ns1:Foglio";
                public const string Particella = "ns1:Particella";
                public const string Subalterno = "ns1:Subalterno";
                public const string CodiceTipoConduzione = "ns1:CodiceTipoConduzione";

                public static class Destinazione
                {
                    public const string Root = "ns1:Destinazione";
                    public const string codiceProdotto = "ns1:codiceProdotto";
                    public const string codiceVarieta = "ns1:codiceVarieta";
                    public const string superficieUtilizzata = "ns1:superficieUtilizzata";
                }

            }

            public static class risposta10
            {
                public const string Root = "/ns1:risposta10";

                public const string CUAA = "ns1:CUAA";
                public const string tipoAzienda = "ns1:tipoAzienda";
                public const string denominazione = "ns1:denominazione";
                public const string nomePF = "ns1:nomePF";
                public const string sessoPF = "ns1:sessoPF";
                public const string dataNascitaPF = "ns1:dataNascitaPF";
                public const string comuneNascitaPF = "ns1:comuneNascitaPF";
                public const string TipoDocumento = "ns1:TipoDocumento";
                public const string NumeroDocumento = "ns1:NumeroDocumento";
                public const string DataDocumento = "ns1:DataDocumento";
                public const string DataScadDocumento = "ns1:DataScadDocumento";

                public static class sedeResidenza
                {
                    public const string Root = "/ns1:sedeResidenza";
                    public const string provincia = "ns1:provincia";
                    public const string comune = "ns1:comune";
                    public const string indirizzo = "ns1:indirizzo";
                    public const string cap = "ns1:cap";
                    public const string codiceStatoEstero = "ns1:codiceStatoEstero";
                }

                public static class recapito
                {
                    public const string Root = "/ns1:recapito";
                    public const string provincia = "ns1:provincia";
                    public const string comune = "ns1:comune";
                    public const string indirizzo = "ns1:indirizzo";
                    public const string cap = "ns1:cap";
                    public const string codiceStatoEstero = "ns1:codiceStatoEstero";
                }

                public const string partitaIVA = "ns1:partitaIVA";
                public const string iscrizioneRea = "ns1:iscrizioneRea";
                public const string iscrizioneRegistroImprese = "ns1:iscrizioneRegistroImprese";
                public const string codiceInps = "ns1:codiceInps";
                public const string organismoPagatore = "ns1:organismoPagatore";
                public const string dataAperturaFascicolo = "ns1:dataAperturaFascicolo";
                public const string dataChiusuraFascicolo = "ns1:dataChiusuraFascicolo";
                public const string tipoDetentore = "ns1:tipoDetentore";
                public const string detentore = "ns1:detentore";
                public const string pec = "ns1:DescPec";
                public const string dataValidazFascicolo = "ns1:dataValidazFascicolo";
                public const string schedaValidazione = "ns1:schedaValidazione";
                public const string dataSchedaValidazione = "ns1:dataSchedaValidazione";
                public const string dataSottMandato = "ns1:dataSottMandato";
                public const string dataElaborazione = "ns1:dataElaborazione";

            }
        }

        public static class XPathInterscambioWS
        {
            public static StringDictionary GetNameSpaceList()
            {
                StringDictionary NameSpaceList = new System.Collections.Specialized.StringDictionary();
                NameSpaceList.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                NameSpaceList.Add("env",     "http://schemas.xmlsoap.org/soap/envelope/");
                NameSpaceList.Add("ns1",     "http://bdr.izs.it/webservices");
                NameSpaceList.Add("ns2",     "http://bdr.izs.it/webservices/ResponseQuery.xsd");
                return NameSpaceList;
            }

            public static class Error
            {
                public const string Root = "./soapenv:Envelope/soapenv:Body/env:Fault";
                public const string faultcode = "faultcode";
                public const string faultstring = "faultstring";
                public const string faultactor = "faultactor";
                public const string detail = "detail";
            }

            public static class Response
            {
                public const string Root = "./soapenv:Envelope/soapenv:Body/ns1:Anagrafica_AllevamentiResponse/ns2:Anagrafica_AllevamentiResult";

                public static class Warning
                {
                    public const string Root = "/ns2:error_info";
                    public const string info = "ns2:info";
                    public const string warning = "ns2:warning";

                    public static class Error
                    {
                        public const string Root = "/ns2:error";
                        public const string id = "ns2:id";
                        public const string des = "ns2:des";
                    }
                }

                public static class ANAGRAFICA_ALLEVAMENTO
                {
                    public const string Root = "/ns2:dati/ns2:dsANAGRAFICA_ALLEVAMENTI/ns2:ANAGRAFICA_ALLEVAMENTO";
                    public const string ALLEV_ID = "ns2:ALLEV_ID";
                    public const string AZIENDA_CODICE = "ns2:AZIENDA_CODICE";
                    public const string SPE_CODICE = "ns2:SPE_CODICE";
                    public const string DENOMINAZIONE = "ns2:DENOMINAZIONE";
                    public const string INDIRIZZO = "ns2:INDIRIZZO";
                    public const string CAP = "ns2:CAP";
                    public const string COMUNE = "ns2:COMUNE";
                    public const string TIPO_PRODUZIONE = "ns2:TIPO_PRODUZIONE";
                    public const string ORIENTAMENTO_PRODUTTIVO = "ns2:ORIENTAMENTO_PRODUTTIVO";
                    public const string AUTORIZZAZIONE_LATTE = "ns2:AUTORIZZAZIONE_LATTE";
                    public const string DT_INIZIO_ATTIVITA = "ns2:DT_INIZIO_ATTIVITA";
                    public const string DT_FINE_ATTIVITA = "ns2:DT_FINE_ATTIVITA";
                    public const string COD_FISCALE_PROP = "ns2:COD_FISCALE_PROP";
                    public const string DENOM_PROPRIETARIO = "ns2:DENOM_PROPRIETARIO";
                    public const string COD_FISCALE_DETEN = "ns2:COD_FISCALE_DETEN";
                    public const string DENOM_DETENTORE = "ns2:DENOM_DETENTORE";
                    public const string SOCCIDA = "ns2:SOCCIDA";
                    public const string LATITUDINE = "ns2:LATITUDINE";
                    public const string LONGITUDINE = "ns2:LONGITUDINE";
                    public const string LOCALITA = "ns2:LOCALITA";
                    public const string CAPI_TOTALI = "ns2:CAPI_TOTALI";
                    public const string DATA_CALCOLO_CAPI = "ns2:DATA_CALCOLO_CAPI";
                    public const string DT_INIZIO_DETENTORE = "ns2:DT_INIZIO_DETENTORE";
                    public const string DT_FINE_DETENTORE = "ns2:DT_FINE_DETENTORE";
                    public const string FOGLIO_CATASTALE = "ns2:FOGLIO_CATASTALE";
                    public const string SEZIONE = "ns2:SEZIONE";
                    public const string PARTICELLA = "ns2:PARTICELLA";
                    public const string SUBALTERNO = "ns2:SUBALTERNO";
                }

            }
        }

        /// <summary>
        /// Riferimento ad un eventuale metodo delegato il cui codice 
        /// verrà eseguito dopo avere preparato la richiesta Soap,
        /// ma prima di inviarla al server SIAN.
        /// </summary>
        public WebSian.SendSoapRequest OnSendSoapRequest = null;
        /// <summary>
        /// Riferimento ad un eventuale metodo delegato il cui codice 
        /// verrà eseguito dopo avere acquisito la risposta Soap,
        /// ma prima di eseguirne il parsing.
        /// </summary>
        public WebSian.ReceiveSoapResponse OnReceiveSoapResponse = null;

        /// <summary>
        /// Oggetto che si occupa di registrare i le richieste SOAP
        /// inviate al server SIAN
        /// </summary>
        public Logging.ISoapMsgLogger SoapRequestLogger;
        /// <summary>
        /// Oggetto che si occupa di registrare i le risposte SOAP
        /// ricevute dal server SIAN
        /// </summary>
        public Logging.ISoapMsgLogger SoapResponseLogger;

        public WebSian.ProxyWebConfig Proxy;

        public int Timeout = WebSian.DEFAULT_TIMEOUT;

        public struct soapResult
        {
            public string codRet;
            public string msgRet;
            public XPathNavigator xmlData;
            //public XmlNamespaceManager NsManager;
            //public XmlDocument SoapResponse;
        }

        # region Parametri accesso Web Service in esercizio
        /// URL del web service wsAnagrafeAT
        //public const string AnagrafeTributariaUrl = "http://www.sian.it:80/iswsanagrafeat/services/wsAnagrafeAT";
        public const string AnagrafeTributariaUrl = "http://cooperazione.sian.it/wspdd/services/AnagrafeAT";
        /// Nome utente richiesto da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string AnagrafeTributariaLogin = ""; //"regimrch";
        /// Password richiesta da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string AnagrafeTributariaPassword = ""; //"1rrmrcsrvwbh2";

        /// URL del web service wsAgeaToOpr
        public const string FascicoloUrl = "http://www.sian.it:80/iswsAgeaToOpr/services/wsAgeaToOpr";
        /// Password richiesta da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string FascicoloLogin = "";
        /// Nome utente richiesto da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string FascicoloPassword = "";

        /// URL del web service OprFascicolo
        public const string Fascicolo20Url = "http://cooperazione.sian.it/wspdd/services/OprFascicolo";
        /// Password richiesta da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string Fascicolo20Login = "";
        /// Nome utente richiesto da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string Fascicolo20Password = "";

        /// URL del web service InterscambioWS
        public const string InterscambioWSUrl = "http://andromeda.sian.it/wspdd/services/InterscambioWS";
        /// Password richiesta da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string InterscambioWSLogin = "";
        /// Nome utente richiesto da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string InterscambioWSPassword = "";


        /// URL del web service WSAcquisizioneDomandaASR
        public const string DomandaPSRUrl = "http://cooperazione.sian.it/wspdd/services/WSAcquisizioneDomandaASR";
        /// Password richiesta da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string DomandaPSRLogin = ""; //"regimrch";
        /// Nome utente richiesto da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string DomandaPSRPassword = ""; //"1rrmrcsrvwbh2";

        /// URL del web service WSZuccheroASZ
        public const string ZuccheroUrl = "http://cooperazione.sian.it/wspdd/services/WSAcquisizioneDomandaASR";
        /// Password richiesta da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string ZuccheroLogin = ""; //"regimrch";
        /// Nome utente richiesto da AGRISIAN da inserire nell'intestazione della richiesta SOAP
        public const string ZuccheroPassword = ""; //"1rrmrcsrvwbh2";

        /// Codice di ritorno risposta SOAP che indica tutto ok
        public const string retCodeOk = "012";
        # endregion

        private string GetSianRequest(string soapAction, string soapUser, string soapPwd, string soapParam)
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:SOAP-ENC=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
                    "<SOAP-ENV:Header SOAP-ENV:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:NS1=\"http://agea.it/webservices\">" +
                    "<NS1:SOAPAutenticazione xsi:type=\"NS1:SOAPAutenticazione\">" +
                    "<username xsi:type=\"xsd:string\">" + soapUser + "</username>" +
                    "<password xsi:type=\"xsd:string\">" + soapPwd + "</password>" +
                    "</NS1:SOAPAutenticazione>" +
                    "</SOAP-ENV:Header>" +
                    "<SOAP-ENV:Body SOAP-ENV:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
                    "<NS2:" + soapAction + " xmlns:NS2=\"x\">" + soapParam + "</NS2:" + soapAction + ">" +
                    "</SOAP-ENV:Body>" +
                    "</SOAP-ENV:Envelope>";
        }

        private string GetNewSianRequest(string nomeServizio, string soapUser, string soapPwd, string paramXml)
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                    "<soap:Header>" +
                    "<SOAPAutenticazione xmlns=\"http://cooperazione.sian.it/schema/SoapAutenticazione\">" +
                    "<username xmlns=\"\">" + soapUser + "</username>" +
                    "<password xmlns=\"\">" + soapPwd + "</password>" +
                    "<nomeServizio xmlns=\"\">" + nomeServizio + "</nomeServizio>" +
                    "</SOAPAutenticazione>" +
                    "</soap:Header>" +
                    "<soap:Body>" + paramXml + "</soap:Body></soap:Envelope>";
        }

        private string GetPSRRequest(string soapAction, string soapUser, string soapPwd, string soapParam)
        {
            return  "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>"+
                    "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"+
                    "<SOAP-ENV:Header>"+
                    "<SOAPAutenticazione>"+
                    "<username>"+soapUser+"</username>"+
                    "<password>"+soapPwd+"</password>"+
                    "<nomeServizio>"+soapAction+"</nomeServizio>"+
                    "</SOAPAutenticazione>"+
                    "</SOAP-ENV:Header>"+
                    "<SOAP-ENV:Body>"+
                    "<" + soapAction + 
                       " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\""+
                       " xsi:schemaLocation=\"http://cooperazione.sian.it/schema/ASRDomanda ScaricaDomandaASR.xsd\""+
                       " xmlns=\"http://cooperazione.sian.it/schema/ASRDomanda\">"+
                    soapParam +
                    "</"+soapAction+">"+
                    "</SOAP-ENV:Body>"+
                    "</SOAP-ENV:Envelope>";
        }

        private string sendSoapReq(string soapReq, string soapAction, string url)
        {
            Guid RequestGuid = System.Guid.NewGuid();

            if (OnSendSoapRequest != null)
            {   
                OnSendSoapRequest(ref soapReq);
            }

            if (SoapRequestLogger != null)
            {
                // registro quello che realmente invio, quindi con le eventuali
                // modifiche fatte da OnSendSoapRequest
                SoapRequestLogger.LogSoapMsg(soapReq, RequestGuid, Logging.SoapMessageType.request);
            }

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] ByteToSend = encoding.GetBytes(soapReq);

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myHttpWebRequest.Method = "POST";
            myHttpWebRequest.ContentType = "text/xml;charset=\"utf-8\"";
            myHttpWebRequest.Headers.Add("SOAPAction:" + soapAction);
            myHttpWebRequest.KeepAlive = true;
            myHttpWebRequest.ContentLength = ByteToSend.Length; // soapReq.Length;
            myHttpWebRequest.Timeout = Timeout;

            if (Proxy == null)
            {  
                // se non è assegnata una configurazione proxy in modo esplicito ne cerca una nel web.gomfig
                Proxy = new WebSian.ProxyWebConfig();
                //myHttpWebRequest.Proxy = new WebProxy("proxisa", 8080);
            }
            if (Proxy.Active)
            {
                //impostazioni proxy
                myHttpWebRequest.Proxy = new WebProxy(Proxy.Host, Proxy.Port);
            }

            /* ConfigurationSettings.AppSettings è obsoleto!!! ma...
            if (bool.Parse(System.Configuration.ConfigurationSettings.AppSettings["UseProxyWsSian"]))
            {
                string[] proxyconf = System.Configuration.ConfigurationSettings.AppSettings["InfoProxyWsSian"].Split('|');
                myHttpWebRequest.Proxy = new WebProxy(proxyconf[0], int.Parse(proxyconf[1]));//"proxisa.intra", 8080);
            }
            */

            try
            {
                Stream newStream = myHttpWebRequest.GetRequestStream();
                newStream.Write(ByteToSend, 0, ByteToSend.Length);
                newStream.Close();

                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string strRet = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                if (SoapResponseLogger != null)
                {
                    // registro quello che ho realmente ricevuto quindi prima delle
                    // eventuali modifiche introdotte da OnReceiveSoapResponse
                    SoapResponseLogger.LogSoapMsg(strRet, RequestGuid, Logging.SoapMessageType.response);
                }

                if (OnReceiveSoapResponse != null)
                {
                    OnReceiveSoapResponse(ref strRet);
                }

                return strRet;
            }
            catch (Exception e)
            {
                throw new Exception("Non è stato possibile contattare il server SIAN, riprovare più tardi. Dettaglio errore: " + e.Message);
            }
        }


        public SianResult AnagraficaAziendaFS10(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "AnagraficaAziendaFS1.0";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Error.Root;
            obj.CodRetXPath = XPathFascicolo20.Error.faultcode;
            obj.MsgErrPath = XPathFascicolo20.Error.faultstring;

            if (obj.getValue(obj.CodRetXPath, false) == "")
            {
                obj.RootXPath = XPathFascicolo20.Root;
                obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                                  XPathFascicolo20.ISWSResponse.codRet;
                obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                                  XPathFascicolo20.ISWSResponse.Segnalazione;
            }

            return obj;
        }


        public SianResult TrovaFascicolo20(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "TrovaFascicoloFS2.0";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>" ;
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        /// <summary>
        /// invia la richiesta http messaggio all'url
        /// </summary>
        public string SpedisciSoap(string Messaggio, string url)
        {
            return sendSoapReq(Messaggio, "", url);
        }
        public string SpedisciSoapEnv(string Messaggio, string url, string nomeMetodo, string soapUser, string soapPwd)
        {
            string _Messaggio = Messaggio;
            int posDicXml = Messaggio.IndexOf("<?xml");
            if (posDicXml >= 0)
            {
                int endDicXml = Messaggio.IndexOf("?>");
                _Messaggio = Messaggio.Remove(posDicXml, endDicXml + 2);
            }

            string soapRequest = GetNewSianRequest(nomeMetodo, soapUser, soapPwd, _Messaggio);
            return sendSoapReq(soapRequest, "", url);
            
        }

        public SianResult LeggiConsistenzaFS50(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiConsistenzaFS5.0";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }


        public SianResult LeggiConsistenzaFS20(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiConsistenzaFS2.0";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult ConsistenzaAziendaFS10(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "ConsistenzaAziendaFS1.0";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Error.Root;
            obj.CodRetXPath = XPathFascicolo20.Error.faultcode;
            obj.MsgErrPath = XPathFascicolo20.Error.faultstring;

            if (obj.getValue(obj.CodRetXPath, false) == "")
            {
                obj.RootXPath = XPathFascicolo20.Root;
                obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                                  XPathFascicolo20.ISWSResponse.codRet;
                obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                                  XPathFascicolo20.ISWSResponse.Segnalazione;
            }

            return obj;
        }

        public SianResult LeggiPianoColturale(string soapUser, string soapPwd, string cuaa, string anno, string url)
        {
            string nomeServizio = "LeggiPianoColturale";
            string soapParam =
                "<ISWSPiano xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">"+
                "<Cuaa>"+cuaa+"</Cuaa>"+
                "<Anno>"+anno+"</Anno>"+
                "</ISWSPiano>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult LeggiTerritorio20(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiTerritorio";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.rispostaType.Root + "/" +
                              XPathFascicolo20.rispostaType.codRet;
            obj.MsgErrPath = XPathFascicolo20.rispostaType.Root + "/" +
                              XPathFascicolo20.rispostaType.Segnalazione;

            return obj;
        }

        public SianResult TrovaParticella(string soapUser, string soapPwd, string url
                    , string ISTATProv, string ISTATCom, string sezione, string foglio
                    , string particella, string subalterno)
        {
            if ((ISTATProv.Trim() == "") ||
                 (ISTATCom.Trim() == "") ||
                 (foglio.Trim() == "") ||
                 (particella.Trim() == ""))
            {
                throw new Exception("Per cercare una particella si devono specificare ISTATProv, ISTATCom, foglio e particella");
            }
            string nomeServizio = "TrovaParticella";
            string xmlSez, xmlSub;
            if (sezione.Trim() == "")
            {
                xmlSez = "<sezione xsi:nil=\"true\" />";
            }
            else
            {
                xmlSez = "<sezione>" + sezione.Trim() + "</sezione>";
            }
            if (subalterno.Trim() == "")
            {
                xmlSub = "<subalterno xsi:nil=\"true\" />";
            }
            else
            {
                xmlSub = "<subalterno>" + subalterno.Trim() + "</subalterno>";
            }
            string soapParam =
                "<ISWSIdParticella xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" +
                "<provincia>" + ISTATProv + "</provincia>" +
                "<comune>" + ISTATCom + "</comune>" + xmlSez +
                "<foglio>" + foglio + "</foglio>" +
                "<particella>" + particella + "</particella>" + xmlSub +
                "</ISWSIdParticella>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult LeggiMacchine(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiMacchine";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult LeggiFabbricati(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiFabbricati";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult LeggiManodopera(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiManodopera";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult LeggiCondizionalita(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiCondizionalita";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult LeggiSegnalazioni(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiSegnalazioni";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult LeggiContiCorrenti(string soapUser, string soapPwd, string cuaa, string url)
        {
            string nomeServizio = "LeggiContiCorrenti";
            string soapParam = "<Cuaa xmlns=\"http://cooperazione.sian.it/schema/fascicolo\">" + cuaa + "</Cuaa>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathFascicolo20.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathFascicolo20.Root;
            obj.CodRetXPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.codRet;
            obj.MsgErrPath = XPathFascicolo20.ISWSResponse.Root + "/" +
                              XPathFascicolo20.ISWSResponse.Segnalazione;

            return obj;
        }

        public SianResult getAnagraficaSintetica(string soapUser, string soapPwd, string cuaa, string url)
        {
            string soapAction = "anagraficaSintetica";
            string soapParam = "<idFisc xsi:type=\"xsd:string\">" + cuaa + "</idFisc>";
            string soapRequest = GetSianRequest(soapAction, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, soapAction, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("n", "x");

            SianResult obj = new SianResult(xmlMessage, nsManager);
            obj.RootXPath = "./soap:Envelope/soap:Body/n:anagraficaSinteticaResponse/Result/risposta/i";
            obj.CodRetXPath = "./soap:Envelope/soap:Body/n:anagraficaSinteticaResponse/Result/rispostaType/codRet";
            obj.MsgErrPath = "./soap:Envelope/soap:Body/n:anagraficaSinteticaResponse/Result/rispostaType/msgRet";
            return obj;

        }

        public SianResult getAnagraficaSintetica02(string soapUserRegione, string soapPwd, string utenteCF
                                                 , string IdUtenteEnte, string RuoloUtente, string cuaa, string url)
        {
            //string nomeServizio = "anagraficaSintetica";
            string nomeServizio = "AnagraficaSintetica";
            string tipoCuaa;
            if (cuaa.Length == 11)
            {
                tipoCuaa = "<CodiceFiscalePersonaGiuridica>" + cuaa + "</CodiceFiscalePersonaGiuridica>";
            }
            else
            {
                tipoCuaa = "<CodiceFiscalePersonaFisica>" + cuaa + "</CodiceFiscalePersonaFisica>";
            }
            string paramXml = "<idFisc xsi:type=\"xsd:string\">" + cuaa + "</idFisc>";
            string soapRequest =
                        "<?xml version=\"1.0\"?>" + 
                        "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                        "<SOAP-ENV:Header>" +
                        "<SOAPAutenticazione xmlns=\"http://cooperazione.sian.it/schema/SoapAutenticazione\">" +
                        "<username xmlns=\"\">" + soapUserRegione + "</username>" +
                        "<password xmlns=\"\">"+ soapPwd +"</password>" +
                        "<nomeServizio xmlns=\"\">" + nomeServizio + "</nomeServizio>" +
                        "<utenteCF xmlns=\"\">" + utenteCF + "</utenteCF>" +
                        "<ruolo xmlns=\"\">"+ RuoloUtente +"</ruolo>" +
                        "<idUtenteEnte xmlns=\"\">"+IdUtenteEnte+"</idUtenteEnte>" +
                        "</SOAPAutenticazione>" +
                        "</SOAP-ENV:Header>" +
                        "<SOAP-ENV:Body>" +
                        "<CUAAType xmlns=\"http://cooperazione.sian.it/schema/interscambio/\">" +
                        tipoCuaa +
                        "</CUAAType>" +
                        "</SOAP-ENV:Body>" +
                        "</SOAP-ENV:Envelope>" ;

            //string soapRequest = GetSianRequest(soapAction, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, nomeServizio, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("ns1", "http://cooperazione.sian.it/schema/interscambio/");

            SianResult obj = new SianResult(xmlMessage, nsManager);
            obj.RootXPath = "./soapenv:Envelope/soapenv:Body/ns1:ISWSReturnInt/ns1:risposta";
            obj.CodRetXPath = "./soapenv:Envelope/soapenv:Body/ns1:ISWSReturnInt/ns1:rispostaType/ns1:codRet";
            obj.MsgErrPath = "./soapenv:Envelope/soapenv:Body/ns1:ISWSReturnInt/ns1:rispostaType/ns1:msgRet";
            return obj;
             

        }

        public soapResult getAnagraficaDettagliata(string soapUser, string soapPwd, string cuaa, string url)
        {
            //string soapAction = "anagraficaDettaglio";
            string soapAction = "AnagraficaDettaglio";
            string soapParam = "<idFisc xsi:type=\"xsd:string\">" + cuaa + "</idFisc>";
            string soapRequest = GetSianRequest(soapAction, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, soapParam, url);

            // per alcuni CUAA si è avuto un problema relativo a caratteri non validi
            // questo pezzo di codice è un hack per ovviare al problema
            // 0x00 non è in ogni caso ammesso in uno stream XML
            char NonValido = System.Convert.ToChar(0x00);
            if (SoapResponse.IndexOf(NonValido) > 0)
            {
                SoapResponse = SoapResponse.Replace(NonValido.ToString(), "");
            }

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("n", "x");

            XPathExpression codRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:anagraficaDettaglioResponse/Result/rispostaType/codRet", nsManager);
            XPathExpression msgRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:anagraficaDettaglioResponse/Result/rispostaType/msgRet", nsManager);
            XPathExpression datiXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:anagraficaDettaglioResponse/Result/risposta/i", nsManager);

            return getSoapResult(xmlMessage, codRetXPATH, msgRetXPATH, datiXPATH);

        }

        public SianResult getAnagraficaDettagliata02(string soapUserRegione, string soapPwd, string utenteCF
                                                 , string IdUtenteEnte, string RuoloUtente, string cuaa, string url)
        {
            string nomeServizio = "AnagraficaDettaglio";
            string tipoCuaa;
            if (cuaa.Length == 11)
            {
                tipoCuaa = "<CodiceFiscalePersonaGiuridica>" + cuaa + "</CodiceFiscalePersonaGiuridica>";
            }
            else
            {
                tipoCuaa = "<CodiceFiscalePersonaFisica>" + cuaa + "</CodiceFiscalePersonaFisica>";
            }
            string paramXml = "<idFisc xsi:type=\"xsd:string\">" + cuaa + "</idFisc>";

            string soapRequest =
                        "<?xml version=\"1.0\"?>" +
                        "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                        "<SOAP-ENV:Header>" +
                        "<SOAPAutenticazione xmlns=\"http://cooperazione.sian.it/schema/SoapAutenticazione\">" +
                        "<username xmlns=\"\">" + soapUserRegione + "</username>" +
                        "<password xmlns=\"\">" + soapPwd + "</password>" +
                        "<nomeServizio xmlns=\"\">" + nomeServizio + "</nomeServizio>" +
                        "<utenteCF xmlns=\"\">" + utenteCF + "</utenteCF>" +
                        "<ruolo xmlns=\"\">" + RuoloUtente + "</ruolo>" +
                        "<idUtenteEnte xmlns=\"\">" + IdUtenteEnte + "</idUtenteEnte>" +
                        "</SOAPAutenticazione>" +
                        "</SOAP-ENV:Header>" +
                        "<SOAP-ENV:Body>" +
                        "<CUAAType xmlns=\"http://cooperazione.sian.it/schema/interscambio/\">" +
                        tipoCuaa +
                        "</CUAAType>" +
                        "</SOAP-ENV:Body>" +
                        "</SOAP-ENV:Envelope>";


            string SoapResponse = sendSoapReq(soapRequest, paramXml, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);

            // controllo utente abilitato a scaricare da SIAN (aggiunta giorgio 22/11/2011)
            XmlNodeList nodi_abilitazione = xmlMessage.GetElementsByTagName("faultstring");
            if (nodi_abilitazione.Count > 0 && nodi_abilitazione[0].InnerText == "015-Utente non autenticato")
                throw new Exception("L`operatore attuale non è abilitato ad utilizzare il servizio di Anagrafe Tributaria per scaricare i dati richiesti.");

            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("ns1", "http://cooperazione.sian.it/schema/interscambio/");

            SianResult obj = new SianResult(xmlMessage, nsManager);
            obj.RootXPath = XPathAT.RootDett + XPathAT.rispostaDett.Root; ;
            obj.CodRetXPath = XPathAT.RootDett + XPathAT.rispostaType.Root + "/" + XPathAT.rispostaType.codRet;
            obj.MsgErrPath = XPathAT.RootDett + XPathAT.rispostaType.Root + "/" + XPathAT.rispostaType.Segnalazione;
            return obj;
        }

        public soapResult trovaFascicolo(string soapUser, string soapPwd, string cuaa, string url)
        {
            string soapAction = "trovaFascicolo";
            string soapParam = "<arg0 xsi:type=\"xsd:string\">" + cuaa + "</arg0>";
            string soapRequest = GetSianRequest(soapAction, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, soapAction, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("n", "x");

            XPathExpression codRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:trovaFascicoloResponse/Result/rispostaType/codRet", nsManager);
            XPathExpression msgRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:trovaFascicoloResponse/Result/rispostaType/msgRet", nsManager);
            XPathExpression datiXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:trovaFascicoloResponse/Result/risposta/i", nsManager);

            return getSoapResult(xmlMessage, codRetXPATH, msgRetXPATH, datiXPATH);

        }

        public soapResult leggiTerritorio(string soapUser, string soapPwd, string cuaa, string url)
        {
            string soapAction = "leggiTerritorio";
            string soapParam = "<arg0 xsi:type=\"xsd:string\">" + cuaa + "</arg0>";
            string soapRequest = GetSianRequest(soapAction, soapUser, soapPwd, soapParam);

            string SoapResponse = sendSoapReq(soapRequest, soapAction, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("n", "x");

            XPathExpression codRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:leggiTerritorioResponse/Result/rispostaType/codRet", nsManager);
            XPathExpression msgRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:leggiTerritorioResponse/Result/rispostaType/msgRet", nsManager);
            XPathExpression datiXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:leggiTerritorioResponse/Result/risposta", nsManager);

            return getSoapResult(xmlMessage, codRetXPATH, msgRetXPATH, datiXPATH);

        }

        public soapResult leggiAllevamenti(string soapUser, string soapPwd, string cuaa, string url)
        {
            string soapAction = "leggiAllevamenti";
            string soapParam = "<arg0 xsi:type=\"xsd:string\">" + cuaa + "</arg0>";
            string soapRequest = GetSianRequest(soapAction, soapUser, soapPwd, soapParam);

            string SoapResponse = sendSoapReq(soapRequest, soapAction, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("n", "x");

            XPathExpression codRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:leggiAllevamentiResponse/Result/rispostaType/codRet", nsManager);
            XPathExpression msgRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:leggiAllevamentiResponse/Result/rispostaType/msgRet", nsManager);
            XPathExpression datiXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:leggiAllevamentiResponse/Result/risposta", nsManager);

            return getSoapResult(xmlMessage, codRetXPATH, msgRetXPATH, datiXPATH);

        }

        public SianResult leggiAllevamenti2(string soapUser, string soapPwd, string cuaa, DateTime data, string url)
        {
            string nomeServizio = "LeggiAllevamenti";
            string soapParam =
                "<Anagrafica_Allevamenti xmlns=\"http://bdr.izs.it/webservices\">" +
                "<CUUA>" + cuaa + "</CUUA>" +
                "<p_data_richiesta>" + data.ToString("dd/MM/yyyy") + "</p_data_richiesta>" +
                "</Anagrafica_Allevamenti>";
            string soapRequest = GetNewSianRequest(nomeServizio, soapUser, soapPwd, soapParam);
            string SoapResponse = sendSoapReq(soapRequest, "", url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);

            System.Collections.Specialized.StringDictionary NameSpaceList = XPathInterscambioWS.GetNameSpaceList();

            foreach (System.Collections.DictionaryEntry Entry in NameSpaceList)
            {
                nsManager.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }

            SianResult obj = new SianResult(xmlMessage, nsManager);

            obj.RootXPath = XPathInterscambioWS.Error.Root;
            obj.CodRetXPath = XPathInterscambioWS.Error.faultcode;
            obj.MsgErrPath = XPathInterscambioWS.Error.faultstring;

            return obj;
        }

        public soapResult quoteLatte(string soapUser, string soapPwd, string cuaa, string anno, string url)
        {
            string soapAction = "quoteLatte";
            string soapParam = "<arg0 xsi:type=\"xsd:string\">" + cuaa + "</arg0>"+
                               "<arg1 xsi:type=\"xsd:string\">" + anno + "</arg1>";
            string soapRequest = GetSianRequest(soapAction, soapUser, soapPwd, soapParam);

            string SoapResponse = sendSoapReq(soapRequest, soapAction, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("n", "x");

            XPathExpression codRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:quoteLatteResponse/Result/rispostaType/codRet", nsManager);
            XPathExpression msgRetXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:quoteLatteResponse/Result/rispostaType/msgRet", nsManager);
            XPathExpression datiXPATH = XPathExpression.Compile("./soap:Envelope/soap:Body/n:quoteLatteResponse/Result/risposta", nsManager);

            return getSoapResult(xmlMessage, codRetXPATH, msgRetXPATH, datiXPATH);

        }

//        public enum TipiCodFisc { PersonaFisica, PersonaGiuridica }
        public soapResult ScaricaListaCodiciBarreASR(string soapUser, string soapPwd, string CodFisc, Utils.TipiCodFisc TipoCodFisc, int Anno, string CodMisura, string url)
        {
            string soapAction = "ScaricaListaCodiciBarreASR";
            string soapParam = "";
            switch (TipoCodFisc){
                case Utils.TipiCodFisc.PersonaFisica:
                    soapParam = "<CUAAType>" +
                        "<CodiceFiscalePersonaFisica>" + CodFisc + "</CodiceFiscalePersonaFisica>" +
                        "</CUAAType>" +
                        "<numeAnno>"+System.Convert.ToString(Anno)+"</numeAnno>" +
                        "<codiTipoMisu>" + CodMisura + "</codiTipoMisu>";
                    break;
                case Utils.TipiCodFisc.PersonaGiuridica:
                    soapParam = "<CUAAType>" +
                        "<CodiceFiscalePersonaGiuridica>" + CodFisc + "</CodiceFiscalePersonaGiuridica>" +
                        "</CUAAType>" +
                        "<numeAnno>" + System.Convert.ToString(Anno) + "</numeAnno>" +
                        "<codiTipoMisu>" + CodMisura + "</codiTipoMisu>";
                    break;
            }

            string soapRequest = GetPSRRequest(soapAction, soapUser, soapPwd, soapParam);

            string SoapResponse = sendSoapReq(soapRequest, soapAction, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("ns1", "http://cooperazione.sian.it/schema/ASRDomanda");

            XPathExpression codRetXPATH = XPathExpression.Compile("./soapenv:Envelope/soapenv:Body/ns1:ResponseASR/ns1:codRet", nsManager);
            XPathExpression msgRetXPATH = XPathExpression.Compile("./soapenv:Envelope/soapenv:Body/ns1:ResponseASR/ns1:segnalazione", nsManager);
            XPathExpression datiXPATH = XPathExpression.Compile("./soapenv:Envelope/soapenv:Body/ns1:ScaricaListaCodiciBarreASR/ns1:ISWSDomandaASR", nsManager);

            return getSoapResult(xmlMessage, codRetXPATH, msgRetXPATH, datiXPATH);
        }

        public class SianResult
        {
            private XmlNamespaceManager _nsManager;
            private XmlDocument _xmlDoc;
            private XPathNavigator Navigator;

            private string _RootXPath;
            public string RootXPath {
                get { return _RootXPath; }
                set { _RootXPath = value; }
            }
            public string CodRetXPath = "";
            public string MsgErrPath = "";

            public SianResult(XmlDocument xmlDoc, XmlNamespaceManager nsManager)
            {
              _nsManager = nsManager;
              _xmlDoc = xmlDoc;
              _RootXPath = "";
              Navigator = _xmlDoc.CreateNavigator();
            }

            public XPathNodeIterator getIterator(string XPath)
            {
                XPathExpression XPathExpr;
                if (_RootXPath!="")
                {
                    if (XPath.StartsWith("/"))
                    {
                        XPathExpr = XPathExpression.Compile(_RootXPath + XPath, _nsManager);
                    }
                    else
                    {
                        XPathExpr = XPathExpression.Compile(_RootXPath + "/" + XPath, _nsManager);
                    }
                }
                else {
                    XPathExpr = XPathExpression.Compile(XPath, _nsManager);
                }
                return Navigator.Select(XPathExpr);
            }

            public XPathNodeIterator getIterator(string XPathRelative, XPathNodeIterator Root, bool ThrowOnEmpty)
            {
                XPathExpression XPathExpr;
                XPathExpr = XPathExpression.Compile(XPathRelative, _nsManager);
                XPathNodeIterator xp = Root.Current.Select(XPathExpr);
                if ((xp.Count < 1) && (ThrowOnEmpty))
                {
                    throw new System.Exception("La query XPath [" + XPathRelative +
                                        "] non ha trovato nessun elemento.");
                }
                return xp;
            }

            public XPathNavigator getNavigator(string XPath)
            {
                XPathExpression XPathExpr;
                if (_RootXPath!="")
                {
                    XPathExpr = XPathExpression.Compile(_RootXPath + "/" + XPath, _nsManager);
                }
                else
                {
                    XPathExpr = XPathExpression.Compile(XPath, _nsManager);
                }
                XPathNodeIterator Iter = Navigator.Select(XPathExpr);
                if (Iter.Count == 0)
                {
                    throw new Exception("La query XPath [" + XPath +
                                        "] non ha trovato nessun elemento.");
                }
                Iter.MoveNext();
                return Iter.Current;
            }

            public string getValue(string XPath)
            {
                return getValue(XPath, true);
            }

            public string getValue(string XPath, bool ThrowOnEmpty)
            {
                XPathNodeIterator XIterator = getIterator(XPath);
                if (XIterator.Count > 1)
                {
                    throw new Exception("La query XPath [" + XPath +
                                        "] ha trovato più di un elemento.");
                }
                if (XIterator.Count == 0)
                {
                    if (ThrowOnEmpty)
                    {
                        throw new Exception("La query XPath [" + XPath +
                                            "] non ha trovato nessun elemento.");
                    }else{
                        return "";
                    }
                }
                // posiziono il cursore sull'elemento trovato che è unico
                XIterator.MoveNext();
                // controllo che non abbia figli
                XPathNodeIterator xChilds = XIterator.Current.SelectDescendants(XPathNodeType.Element, false);
                if (xChilds.Count > 0)
                {
                    throw new Exception("La query XPath [" + XPath +
                            "] ha trovato un elemento che ne contiene altri.");
                }
                return XIterator.Current.Value.Trim();
            }


            public string getValue(string XPathRelative, XPathNodeIterator Root)
            {
                return getValue(XPathRelative, Root, true);
            }

            public string getValue(string XPathRelative, XPathNodeIterator Root, bool ThrowOnEmpty)
            {
                XPathNodeIterator xpn = Root.Current.Select(XPathRelative, _nsManager);
                if (xpn.Count > 1) 
                {
                    throw new Exception("La query XPath [" + XPathRelative + 
                                        "] ha trovato più di un elemento.");
                }
                if (xpn.Count == 0)
                {
                    if (ThrowOnEmpty)
                    {
                        throw new Exception("La query XPath [" + XPathRelative +
                                            "] non ha trovato nessun elemento.");
                    }
                    else
                    {
                        return "";
                    }
                }
                xpn.MoveNext();
                XPathNodeIterator xChilds = xpn.Current.SelectDescendants(XPathNodeType.Element, false);
                if (xChilds.Count > 0)
                {
                    throw new Exception("La query XPath [" + XPathRelative +
                            "] ha trovato un elemento che ne contiene altri.");
                }
                return xpn.Current.Value.Trim();
            }

        }

        public SianResult ScaricoDomandaOnlineASR(string soapUser, string soapPwd, string CodBarre, string url)
        {
            const string soapAction = "ScaricoDomandaOnlineASR";
            string soapParam = "<codiceBarre>" + CodBarre + "</codiceBarre>";

            string soapRequest = GetPSRRequest(soapAction, soapUser, soapPwd, soapParam);

            string SoapResponse = sendSoapReq(soapRequest, soapAction, url);

            XmlDocument xmlMessage = new XmlDocument();
            xmlMessage.LoadXml(SoapResponse);
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlMessage.NameTable);
            nsManager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            nsManager.AddNamespace("ns1", "http://cooperazione.sian.it/schema/ASRDomanda");

            SianResult obj = new SianResult(xmlMessage, nsManager);
            return obj;
        }

        public soapResult getSoapResult(XmlDocument xmlMessage, XPathExpression codRetXPATH, XPathExpression msgRetXPATH, XPathExpression datiXPATH)
        {
            soapResult obj = new soapResult();

            XPathNavigator messageNavigator = xmlMessage.CreateNavigator();

            XPathNodeIterator codRetXml = messageNavigator.Select(codRetXPATH);
            XPathNodeIterator msgRetXml = messageNavigator.Select(msgRetXPATH);
            XPathNodeIterator datiXML = messageNavigator.Select(datiXPATH);

            if (codRetXml.Count == 1)
            {
                if (codRetXml.MoveNext())
                {
                    // estrae il codice di ritorno
                    obj.codRet = codRetXml.Current.Value;
                }
            }
            else { obj.codRet = retCodeOk;  }

            if (msgRetXml.Count == 1)
            {
                if (msgRetXml.MoveNext())
                {
                    // estrae il messaggio di ritorno
                    obj.msgRet = msgRetXml.Current.Value;
                }
            }
            else { obj.msgRet = "Il server SIAN non ha riportato errori."; }

            if (datiXML.Count == 1)
            {
                if (datiXML.MoveNext())
                {
                    // estrae i dati di ritorno
                    obj.xmlData = datiXML.Current;
                }
            }

            //obj.SoapResponse = xmlMessage;
            return obj;
        }

    }
}
