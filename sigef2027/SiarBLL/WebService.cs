using System;
using System.Text;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Net;

namespace SiarBLL
{
    public class WebService
    {
        public string Url { get; set; }
        public string SoapAction { get; set; }
        //public Dictionary<string, string> Params = new Dictionary<string, string>();
        public XmlDocument ResultXML;
        public string ResultString;

        public WebService() { }

        public WebService(string url, string soapactionMethod)
        {
            Url = url;
            if (soapactionMethod.StartsWith("http")) SoapAction = soapactionMethod;
            else SoapAction = "http://tempuri.org/" + soapactionMethod;
        }


        /// <summary>
        /// per invocare il metodo
        /// </summary>
        /// <param name="encode">stringa con il corpo del messaggio</param>
        public void Invoke(string xmlEnvelope)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
            req.Headers.Add("SOAPAction", "\"" + SoapAction + "\"");
            req.ContentType = "text/xml;charset=\"utf-8\"";
            req.Accept = "text/xml";
            req.Method = "POST";

            using (Stream stm = req.GetRequestStream())
            {
                using (StreamWriter stmw = new StreamWriter(stm))
                {
                    stmw.Write(xmlEnvelope);
                }
            }

            using (StreamReader responseReader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                string result = responseReader.ReadToEnd();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                ResultXML = doc;
                ResultString = result;
            }
        }
    }

    public class BdnizsWebService
    {
        // sovrascritti tramite xconfig
        protected string izsuser = "marche_BDR";
        protected string izspw = "mar23";
        protected string codRegione = "110";

        //protected SiarLibrary.Xconfig cfgBovini,cfgEquini,cfgAvicoli;

        public BdnizsWebService()
        {
            var cfg = new SiarBLL.XconfigCollectionProvider().GetById("WSizsVeterinaria");
            if (cfg != null)
            {
                izsuser = cfg.Login;
                izspw = cfg.Pwd;
                codRegione = cfg.CodiceUo;
            }

            //cfgBovini =xp.GetById("WSizsBovini");
            //cfgEquini = xp.GetById("WSizsEquini");
            //cfgAvicoli = xp.GetById("WSizsAvicoli");

        }
        private string autHeader()
        {
            return @"   <soapenv:Header>
      <web:SOAPAutenticazione>
         <web:username>" + izsuser + @"</web:username>
         <web:password>" + izspw + @"</web:password>
      </web:SOAPAutenticazione>
   </soapenv:Header>";
        }

        private string autHeaderRegione()
        {
            return @"   <soapenv:Header>
     <ws:SOAPAutenticazioneWS>
         <username>" + izsuser + @"</username>
         <password>" + izspw + @"</password>
         <ruoloCodice>REG</ruoloCodice>
         <ruoloValoreCodice>" + codRegione + @"</ruoloValoreCodice>
      </ws:SOAPAutenticazioneWS>
   </soapenv:Header>";
        }

        public DataSet bdnDataset(string url, string actionmethod, string envelope, string datasetPath, string errorPath)
        {
            // metodo generico per i webservice bdn che tornano un dataset


            var wsbdnfind01 = new SiarBLL.WebService(url, actionmethod);


            wsbdnfind01.Invoke(envelope);

            if (!string.IsNullOrEmpty(errorPath))
            {	// controllo errore
                var nerr = wsbdnfind01.ResultXML.SelectSingleNode(errorPath);
                string strerr = (nerr != null ? nerr.InnerText.Trim() : "");
                if (strerr != "" && strerr != "0")
                {
                    throw new Exception(nerr.InnerXml);
                }
            }
            var ndoc = wsbdnfind01.ResultXML.SelectSingleNode(datasetPath);
            string strres = ndoc.InnerXml;
            if (!string.IsNullOrEmpty(strres))
            {
                var ds = new System.Data.DataSet();
                using (System.IO.StringReader reader = new System.IO.StringReader(strres))
                {
                    ds.ReadXml(reader);
                }
                return ds;
            }
            return null;
        }

        public DataSet FindAllevamento01(string cuaa)
        {
            // metodo FindAllevamento01
            return bdnDataset("http://wap.izs.it/wsBDNInterrogazioni/wsaziendeqry.asmx"
                , "http://bdr.izs.it/webservices/FindAllevamento01"
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://bdr.izs.it/webservices"" >
   " + autHeader() + @"
   <soapenv:Body>
      <web:FindAllevamento01>
         <!--Optional:-->
         <web:p_azienda_codice></web:p_azienda_codice>
         <!--Optional:-->
         <web:p_allev_id_fiscale>" + cuaa + @"</web:p_allev_id_fiscale>
         <!--Optional:-->
         <web:p_denominazione></web:p_denominazione>
         <!--Optional:-->
         <web:p_specie_codice></web:p_specie_codice>
         <!--Optional:-->
         <web:p_proprietario></web:p_proprietario>
      </web:FindAllevamento01>

   </soapenv:Body>
</soapenv:Envelope>"
                , "//*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='FindAllevamento01Response']"
                    + "/*[local-name()='FindAllevamento01Result']/*[local-name()='root']/*[local-name()='dati']"
                , "//*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='FindAllevamento01Response']"
                    + "/*[local-name()='FindAllevamento01Result']/*[local-name()='root']/*[local-name()='error_info']"
                    + "/*[local-name()='error']");


        }
        public DataSet BOVGet_Capi_Allevamento(string p_allev_id)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='Get_Capi_AllevamentoResponse']"
                    + "/*[local-name()='Get_Capi_AllevamentoResult']/*[local-name()='root']";
            return bdnDataset("http://wap.izs.it/wsBDNInterrogazioni/wsAnagraficaCapoQry.asmx"
                , "http://bdr.izs.it/webservices/Get_Capi_Allevamento"
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://bdr.izs.it/webservices"" >
   " + autHeader() + @"
   <soapenv:Body>
      <web:Get_Capi_Allevamento>
         <!--Optional:-->
         <web:p_allev_id>" + p_allev_id + @"</web:p_allev_id>
         <!--Optional:-->
         <web:p_storico>N</web:p_storico>
         <!--Optional:-->
         <web:p_cod_capo></web:p_cod_capo>
      </web:Get_Capi_Allevamento>
   </soapenv:Body>
</soapenv:Envelope>"
                , path + "/*[local-name()='dati']"
                , null); //, path + "/*[local-name()='error_info']/*[local-name()='error']");
        }

        public DataSet OVIgetCapiOviniAllevamento(string p_allev_id)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='getCapiOviniAllevamentoResponse']"
                    + "/*[local-name()='getCapiOviniAllevamentoResult']/*[local-name()='root']";
            return bdnDataset("http://wap.izs.it/wsBDNInterrogazioni/wsAnagraficaCapoQry.asmx"
                , "http://bdr.izs.it/webservices/getCapiOviniAllevamento"
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://bdr.izs.it/webservices"" >
   " + autHeader() + @"
   <soapenv:Body>
      <web:getCapiOviniAllevamento>
         <!--Optional:-->
         <web:p_allev_id>" + p_allev_id + @"</web:p_allev_id>
         <!--Optional:-->
         <web:p_storico>N</web:p_storico>
         <!--Optional:-->
         <web:p_cod_capo></web:p_cod_capo>
      </web:getCapiOviniAllevamento>
   </soapenv:Body>
</soapenv:Envelope>"
                , path + "/*[local-name()='dati']"
                , null); //, path + "/*[local-name()='error_info']/*[local-name()='error']");
        }

        public DataSet EQUgetRegistroStallaFromUnire(string p_codice_azienda)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='getRegistroStallaFromUnireResponse']"
                    + "/*[local-name()='getRegistroStallaFromUnireResult']/*[local-name()='root']";
            return bdnDataset("http://bdrizsam.izs.it/wsEquidiFromUnire/wsEquidiGet.asmx"
                , "http://bdr.izs.it/webservices/getRegistroStallaFromUnire"
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://bdr.izs.it/webservices"" >
   " + autHeader() + @"
   <soapenv:Body>
      <web:getRegistroStallaFromUnire>
         <!--Optional:-->
         <web:p_codice_azienda>" + p_codice_azienda + @"</web:p_codice_azienda>
      </web:getRegistroStallaFromUnire>
   </soapenv:Body>
</soapenv:Envelope>"
                , path + "/*[local-name()='dati']"
                , null); //, path + "/*[local-name()='error_info']/*[local-name()='error']");
        }

        public DataSet AVIsearchDettaglioAttivitaByAziendaCodice(string p_codice_azienda)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']";
            return bdnDataset("http://ws.izs.it:80/j6_bdn/ws/anagrafica/unitaproduttiva"
                , ""
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://ws.anagrafica.bdn.izs.it/"" >
   " + autHeaderRegione() + @"
	<soapenv:Body>
      <ws:searchDettaglioAttivitaByAziendaCodice>
         <DettaglioAttivitaUkSearchTO>
            <aziendaCodice>" + p_codice_azienda + @"</aziendaCodice>
         </DettaglioAttivitaUkSearchTO>
      </ws:searchDettaglioAttivitaByAziendaCodice>
   </soapenv:Body>

</soapenv:Envelope>"
                , path //+ "/*[local-name()='searchDettaglioAttivitaByAziendaCodiceResponse']"
                , null); //, path + "/*[local-name()='Fault']/*[local-name()='detail']");
        }

        public DataSet AVIsearchCensimento(string avidetattId, string p_codice_azienda)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']";
            return bdnDataset("http://ws.izs.it:80/j6_bdn/ws/anagrafica/censimenti"
                , ""
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://ws.anagrafica.bdn.izs.it/"" >
   " + autHeaderRegione() + @"
	<soapenv:Body>
      <ws:searchCensimento>
         <CensimentoSearchTO>
            <avidetattId>" + avidetattId + @"</avidetattId>
            <uniproAziendaCodice>" + p_codice_azienda + @"</uniproAziendaCodice>
         </CensimentoSearchTO>
      </ws:searchCensimento>

   </soapenv:Body>

</soapenv:Envelope>"
                , path //+ "/*[local-name()='searchCensimentoResponse']"
                , null); //, path + "/*[local-name()='Fault']/*[local-name()='detail']");
        }

        public DataSet AVIsearchGruppi(string avidetattId)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']";
            return bdnDataset("http://ws.izs.it:80/j6_bdn/ws/movimentazioni/gruppi"
                , ""
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://ws.movimentazione.bdn.izs.it/"">
      " + autHeaderRegione() + @"
   <soapenv:Body>
      <ws:searchGruppi>
         <GruppiSearchTO>
  <avidetattId>" + avidetattId + @"</avidetattId>
         </GruppiSearchTO>
      </ws:searchGruppi>
   </soapenv:Body>
</soapenv:Envelope>"
                , path //+ "/*[local-name()='searchCensimentoResponse']"
                , null); //, path + "/*[local-name()='Fault']/*[local-name()='detail']");
        }

        public DataSet SUIGet_CensimentiSuini(string P_ID_FISCALE, string P_AZIENDE_CODICE)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='Get_CensimentiSuiniResponse']"
                    + "/*[local-name()='Get_CensimentiSuiniResult']/*[local-name()='root']";
            return bdnDataset("http://wap.izs.it/wsSuiniAut/wsSuiniUpd.asmx"
                , "http://bdr.izs.it/webservices/Get_CensimentiSuini"
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://bdr.izs.it/webservices"" >
   " + autHeader() + @"
   <soapenv:Body>
      <web:Get_CensimentiSuini>
         <web:strRecord>
				&lt;dsCENSIMENTISUINI_GET xmlns=&quot;http://bdr.izs.it/XMLSchema/dsCENSIMENTISUINI_GET.xsd&quot;&gt;
                &lt;CENSIMENTOSUINI&gt;
                   &lt;P_ID_FISCALE&gt;" + P_ID_FISCALE + @"&lt;/P_ID_FISCALE&gt;
                   &lt;P_AZIENDE_CODICE&gt;" + P_AZIENDE_CODICE + @"&lt;/P_AZIENDE_CODICE&gt;
                   &lt;P_SPECIE_CODICE&gt;0122&lt;/P_SPECIE_CODICE&gt;
                &lt;/CENSIMENTOSUINI&gt;
             &lt;/dsCENSIMENTISUINI_GET&gt;
	    </web:strRecord>
      </web:Get_CensimentiSuini>
   </soapenv:Body>
</soapenv:Envelope>"
                , path + "/*[local-name()='dati']"
                , null); //, path + "/*[local-name()='error_info']/*[local-name()='error']");
        }

        //occorrono anche i censimenti ovini per chi non ha la situazione in allevamento
        public DataSet OVIFindOviCensimenti(string P_ID_FISCALE, string P_AZIENDE_CODICE, string P_SPE_CODICE)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']/*[local-name()='FindOviCensimentiResponse']"
                    + "/*[local-name()='FindOviCensimentiResult']/*[local-name()='root']";
            return bdnDataset("http://wap.izs.it/wsBDNInterrogazioni/wsaziendeqry.asmx"
                , "http://bdr.izs.it/webservices/FindOviCensimenti"
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://bdr.izs.it/webservices"" >
   " + autHeader() + @"
      <soapenv:Body>
      <web:FindOviCensimenti>
         <!--Optional:-->
         <web:p_azienda_codice>" + P_AZIENDE_CODICE + @"</web:p_azienda_codice>
         <!--Optional:-->
         <web:p_allev_idfiscale>" + P_ID_FISCALE + @"</web:p_allev_idfiscale>
         <!--Optional:-->
         <web:p_spe_codice>" + P_SPE_CODICE + @"</web:p_spe_codice>
      </web:FindOviCensimenti>
   </soapenv:Body>

</soapenv:Envelope>"
                , path + "/*[local-name()='dati']"
                , null); //, path + "/*[local-name()='error_info']/*[local-name()='error']");
        }

        //webservice apicoltura per aziende e poi censimenti
        /// <summary>
        /// attivita apicole per cf/piva
        /// </summary>
        /// <param name="P_ID_FISCALE"></param>
        /// <returns></returns>
        public DataSet APIsearchApiAttivita(string P_ID_FISCALE)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']";
            return bdnDataset("http://ws.izs.it:80/j6_bdn/ws/apicoltura/apianagrafica/apiattivita"
                , ""
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://ws.apianagrafica.apicoltura.izs.it/"">
      " + autHeaderRegione() + @"
   <soapenv:Body>
		<ws:searchApiAttivita>
         <ApiAttivitaSearch>
            <regSlCodice>" + codRegione + @"</regSlCodice>
            <propIdFiscale>" + P_ID_FISCALE + @"</propIdFiscale>
         </ApiAttivitaSearch>
      </ws:searchApiAttivita>
   </soapenv:Body>
</soapenv:Envelope>"
                , path //+ "/*[local-name()='searchCensimentoResponse']"
                , null); //, path + "/*[local-name()='Fault']/*[local-name()='detail']");
        }


        public DataSet APIsearchApiCensimento(string P_AZIENDE_CODICE)
        {
            string path = "//*[local-name()='Envelope']/*[local-name()='Body']";
            return bdnDataset("http://ws.izs.it:80/j6_bdn/ws/apicoltura/apianagrafica/apicensimento"
                , ""
                , @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ws=""http://ws.apianagrafica.apicoltura.izs.it/"">
      " + autHeaderRegione() + @"
    <soapenv:Body>
	  <ws:searchApiCensimento>
         <ApiCensimentoSearchTO>
            <apiApiattAziendaCodice>" + P_AZIENDE_CODICE + @"</apiApiattAziendaCodice>
         </ApiCensimentoSearchTO>
      </ws:searchApiCensimento>

   </soapenv:Body>
</soapenv:Envelope>"
                , path //+ "/*[local-name()='searchCensimentoResponse']"
                , null); //, path + "/*[local-name()='Fault']/*[local-name()='detail']");
        }

    }

}
