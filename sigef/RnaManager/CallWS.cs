using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Linq;
using System.Net;

namespace RnaManager
{
    internal partial class CallWS
    {
        private const string _caller = "SIGEF";
        private string _usernameRNA { get; set; }
        private string _passwordRNA { get; set; }
        private svcRna.RnasServiceClient _client { get; set; }

        public CallWS(string username, string password, bool produzione)
        {

            var binding = new BasicHttpBinding(ConfigurationManager.AppSettings["bindingRNA"].ToString());
            var endpoint = new EndpointAddress(produzione ? ConfigurationManager.AppSettings["endpointProd"].ToString() : ConfigurationManager.AppSettings["endpointColl"].ToString());

            _client = new svcRna.RnasServiceClient(binding, endpoint);
            _client.ClientCredentials.UserName.UserName = username;
            _client.ClientCredentials.UserName.Password = password;

            //Implementazione della preemptive authentication, senza questa l'autenticazione non risulta valida
            OperationContextScope scope = new OperationContextScope(_client.InnerChannel);
            string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(_client.ClientCredentials.UserName.UserName + ":" + _client.ClientCredentials.UserName.Password));
            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
            requestMessage.Headers["Authorization"] = auth;
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
        }
    

        #region richiesta visure

        internal ResultInfoVisura RequestVisuraDeMinimis(string codiceFiscale, DateTime dataFineEsercizioFinanziario, DateTime dataConcessionePrevista, svcRna.impresaPartecipante[] impresePartecipanti)
        {
            var result = new ResultInfoVisura();

            try
            {
                var response = _client.RichiediVisuraDeminimis(_caller, codiceFiscale, dataFineEsercizioFinanziario, dataConcessionePrevista, impresePartecipanti);

                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.IdRichiesta = response.idRichiesta.ToString();
                
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal ResultInfoVisura RequestVisuraAiuti(string codiceFiscale, DateTime dataInizioAnalisi)
        {
            var result = new ResultInfoVisura();

            try
            {
                var response = _client.RichiediVisuraAiuti(_caller, codiceFiscale, dataInizioAnalisi);
                
                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.IdRichiesta = response.idRichiesta.ToString();
                
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal ResultInfoVisura RequestVisuraDeggendorf(string codiceFiscale)
        {
            var result = new ResultInfoVisura();

            try
            {

                var response = _client.RichiediVisuraDeggendorf(_caller, codiceFiscale);

                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.IdRichiesta = response.idRichiesta.ToString();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal ResultInfoVisura GetVisura(string idRichiesta)
        {
            var result = new ResultInfoVisura();
            try
            {
                long.TryParse(idRichiesta, out long t);
                var response = _client.ScaricaVisura(_caller, t, svcRna.outputVisuraEnum.PDF_VISURA);

                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.IdRichiesta = response.idRichiesta.ToString();
                result.PayloadEsito = response.visura;
                

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }                      
        }

        #endregion

        #region verifica stato richieste

        internal ResultInfo GetStatoRichiesta(string idRichiesta)
        {
            var result = new ResultInfo();

            try
            {
                long.TryParse(idRichiesta, out long t);
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // Forza TLS 1.2 
                var response = _client.StatoRichiesta(_caller, t);

                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.IdRichiesta = idRichiesta;
                
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region registrazione aiuti

        internal ResultInfoConcessione RegistraAiuto(string codiceBando, string istanzaAiuto)
        {
            var result = new ResultInfoConcessione();
            long.TryParse(codiceBando, out long t);

            byte[] request = Encoding.UTF8.GetBytes(istanzaAiuto);

            try
            {
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // Forza TLS 1.2 
                var response = _client.RegistraAiuto(_caller, t, request);

                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.IdRichiesta = response.idRichiesta.ToString();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        internal ResultInfoConcessione GetCertificazioneRichiestaAiuto(string idRichiesta)
        {
            var result = new ResultInfoConcessione();

            try
            {
                long.TryParse(idRichiesta, out long t);

                var response = _client.ScaricaCertificazione(_caller, t);

                result.Success = response.success;
                result.IdRichiesta = response.idRichiesta.ToString();
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.PayloadEsito = response.certificazione;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal ResultInfoConcessione GetEsitoRichiestaAiuto(string idRichiesta)
        {
            var result = new ResultInfoConcessione();

            try
            {
                long.TryParse(idRichiesta, out long t);
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // Forza TLS 1.2 
                var response = _client.ScaricaEsitoRichiesta(_caller, t);


                result.Success = response.success;
                result.IdRichiesta = response.idRichiesta.ToString(); //verificare se la property è vuota, altrimenti mettere il parametro del metodo
                result.CodiceEsitoRichiesta = response.retCode;
                result.DescrizioneEsitoRichiesta = response.retMessage;
                result.PayloadEsito = response.esito;

                //result.Success = response.success;
                //result.IdRichiesta = response.idRichiesta.ToString(); //verificare se la property è vuota, altrimenti mettere il parametro del metodo
                //result.CodiceEsito = response.retCode;
                //result.DescrizioneEsito = response.retMessage;
                //result.PayloadEsito = response.esito;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal ResultInfoConcessione ConfermaConcessione(string COR, string numeroAtto, DateTime dataAtto)
        {
            var result = new ResultInfoConcessione();
            //const string linkConcessione = "http://www.regione.marche.it";
            long.TryParse(COR, out long t);
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // Forza TLS 1.2 
            var response = _client.ConfermaConcessione(_caller, t, svcRna.notificaElaborazioneRichiestaEnum.NO, numeroAtto, null, dataAtto);

            result.Success = response.success;
            result.COR = COR;//response.cor.ToString();
            result.CodiceEsito = response.retCode;
            result.DescrizioneEsito = response.retMessage;
            result.StatoConcessione = response.statoConcessione;

            try
            {
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal List<ResultInfoConcessione> ConfermaConcessione(string[] CORArray, string numeroAtto, DateTime dataAtto)
        {
            var lResult = new List<ResultInfoConcessione>();

            try
            {
                foreach( string c in CORArray)
                {
                    var result = ConfermaConcessione(c, numeroAtto, dataAtto);
                    lResult.Add(result);
                }
                return lResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal ResultInfo ConfermaConcessioneMassivo(string message, string codiceBando)
        {
            var result = new ResultInfo();

            try
            {
                long.TryParse(codiceBando, out long t);
                byte[] request = Encoding.UTF8.GetBytes(message);

                var response = _client.ConfermaConcessioneMassivo(_caller, t, request);

                result.Success = response.success;
                result.IdRichiesta = response.idRichiesta.ToString();
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.PayloadEsito = response.certificazione;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal ResultInfoConcessione AnnullaConcessione(string cor)
        {
            var result = new ResultInfoConcessione();

            try
            {
                long.TryParse(cor, out long t);
                var response = _client.AnnullaConcessione(_caller, t, svcRna.notificaElaborazioneRichiestaEnum.NO);
                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.StatoConcessione = response.statoConcessione;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region metodi di test

        internal ResultInfoConcessione RegistraAiutoTest(string codiceBando, string istanzaAiuto)
        {
            var result = new ResultInfoConcessione();
            long.TryParse(codiceBando, out long t);

            byte[] request = Encoding.UTF8.GetBytes(istanzaAiuto);

            Random random = new Random();

            int current = random.Next(100000, 500000);

            try
            {
                var response = new svcRna.rnasServiceRichiestaResponse();// _client.RegistraAiuto(_caller, t, request);

                response.success = true;
                response.retCode = 0;
                response.retMessage = "Da confermare";
                response.idRichiesta = current;

                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.IdRichiesta = response.idRichiesta.ToString();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        internal ResultInfo GetStatoRichiestaTest(string idRichiesta)
        {
            var result = new ResultInfo();

            try
            {
                long.TryParse(idRichiesta, out long t);

                var response = new svcRna.baseResponse(); //_client.StatoRichiesta(_caller, t);

                response.success = true;
                response.retCode = 0;
                response.retMessage = "Completata";
                

                result.Success = response.success;
                result.CodiceEsito = response.retCode;
                result.DescrizioneEsito = response.retMessage;
                result.IdRichiesta = idRichiesta;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal ResultInfoConcessione GetEsitoRichiestaAiutoTest(string idRichiesta)
        {
            var result = new ResultInfoConcessione();

            try
            {
                long.TryParse(idRichiesta, out long t);
                XDocument xdoc = XDocument.Load("" + idRichiesta + ".xml");
                byte[] request = Encoding.UTF8.GetBytes(xdoc.ToString());

                var response = new svcRna.rnasServiceRichiestaResponse();// _client.ScaricaEsitoRichiesta(_caller, t);

                response.success = true;
                response.retCode = 0;
                response.retMessage = "Da confermare";
                response.esito = request;

                result.Success = response.success;
                result.IdRichiesta = response.idRichiesta.ToString(); //verificare se la property è vuota, altrimenti mettere il parametro del metodo
                result.CodiceEsitoRichiesta = response.retCode;
                result.DescrizioneEsitoRichiesta = response.retMessage;
                result.PayloadEsito = response.esito;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal ResultInfoConcessione ConfermaConcessioneTest(string COR, string numeroAtto, DateTime dataAtto)
        {
            var result = new ResultInfoConcessione();
            //const string linkConcessione = "http://www.regione.marche.it";
            long.TryParse(COR, out long t);

            var response = new svcRna.statoConcessioneResponse(); //_client.ConfermaConcessione(_caller, t, svcRna.notificaElaborazioneRichiestaEnum.NO, numeroAtto, null, dataAtto);

            response.success = true;
            response.statoConcessione = "Confermato";
            response.retCode = 0;
            response.retMessage = "Completato";

            result.Success = response.success;
            result.COR = COR;//response.cor.ToString();
            result.CodiceEsito = response.retCode;
            result.DescrizioneEsito = response.retMessage;
            result.StatoConcessione = response.statoConcessione;

            try
            {
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
