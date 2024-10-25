using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Configuration;

namespace SiarLibrary
{
    public partial class CalamaioUtility
    {
        public static XDocument GenerateXmlSignRequestMessage()
        {
            /*
            <?xml version="1.0" encoding="UTF-8"?>
            <appletRequest xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="xmlSignRequest.xsd">
              <!-- attualmente non utilizzato -->
              <externalSessionId></externalSessionId>
              <userAuthentication>
                <!-- codice utente che invoca la firma -->
                <userCode>SLLMRC66R16I608G</userCode>
                <!-- codice applicativo chiamante -->
                <applicationCode>paleo</applicationCode>
              </userAuthentication>
              <!-- identificativo univoco della configurazione da utilizzare per la firma -->
              <configurationIdentifier>pknet</configurationIdentifier>
              <documents>
                <document>
                  <!-- identificativo del documento da firmare, solitamente il nome file -->
                  <documentIdentifier>chiusuraLambda.pdf</documentIdentifier>
                  <!-- documento da firmare codificato in base64 -->
                  <documentData>JVBER===</documentData>
                </document>
              </documents>
            </appletRequest>
            */
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XElement root = new XElement("appletRequest", new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName), new XAttribute(xsi + "noNamespaceSchemaLocation", "xmlSignRequest.xsd"));

            var doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), root);
            doc.Root.Add(new XElement("externalSessionId", ""));
            doc.Root.Add(new XElement("userAuthentication"));
            //doc.Root.Add(new XElement("configurationIdentifier"));
            doc.Descendants("userAuthentication").FirstOrDefault().Add(new XElement("userCode"));
            doc.Descendants("userAuthentication").FirstOrDefault().Add(new XElement("applicationCode", "Sigef"));
            doc.Root.Add(new XElement("configurationIdentifier", ConfigurationManager.AppSettings["Calamaio.ConfigId"]));
            doc.Root.Add(new XElement("documents"));
            //doc.Descendants("documents").FirstOrDefault().Add(new XElement("document"));
            //doc.Descendants("document").FirstOrDefault().Add(new XElement("documentIdentifier"));
            //doc.Descendants("document").FirstOrDefault().Add(new XElement("documentData"));
            return doc;
        }

        public static string GetDataToSign(byte[] file, string cf_firmatario, string identificativo_file)
        {
            var doc = GenerateXmlSignRequestMessage();
            doc.Descendants("documents").FirstOrDefault().Add(new XElement("document"));
            doc.Descendants("document").FirstOrDefault().Add(new XElement("documentIdentifier"));
            doc.Descendants("document").FirstOrDefault().Add(new XElement("documentData"));
            if (cf_firmatario != null && cf_firmatario != "")
                doc.Descendants("userCode").FirstOrDefault().SetValue(cf_firmatario);
            doc.Descendants("documentIdentifier").FirstOrDefault().SetValue(identificativo_file);
            doc.Descendants("documentData").FirstOrDefault().SetValue(Convert.ToBase64String(file));           
            return doc.ToString();
        }

        public static string GetDataToSign(List<byte[]> files, string cf_firmatario, List<string> identificativo_file)
        {
            var doc = GenerateXmlSignRequestMessage();
            doc.Descendants("userCode").FirstOrDefault().SetValue(cf_firmatario);

            for (int c = 0; c < files.Count; c++)
            {
                var el = new XElement("document");
                el.SetElementValue("documentIdentifier", identificativo_file[c]);
                el.SetElementValue("documentData", Convert.ToBase64String(files[c]));
                doc.Descendants("documents").FirstOrDefault().Add(el);
            }

            return doc.ToString();
        }

        public static string[] ExtractSignedDataCalamaio(string signedData)
        {

            var xmlDoc = XDocument.Parse(signedData); ;
            //xmlDoc.LoadXml(signedData);

            var res = xmlDoc.Descendants("signResult").FirstOrDefault();
            if (res == null || res.Value != "Success")
            {
                var err = xmlDoc.Descendants("error").FirstOrDefault();
                if (err != null)
                    throw new Exception("Errore Calamaio: " + err.Value);
            }

            //var filesFirmati = xmlDoc.SelectNodes("//document");
            var filesFirmati = xmlDoc.Descendants("document");


            //if (request.FilesFirmati == null)
            //    request.FilesFirmati = new List<File>();

            var files = new List<string>();

            foreach (XElement node in filesFirmati)
            {
                var di = node.Descendants("documentIdentifier").FirstOrDefault();
                var da = node.Descendants("documentData").FirstOrDefault();


                files.Add(da.Value);
                //var f = new File();
                //f.Content = Convert.FromBase64String(da.InnerText);
                //f.SetImpronta();
                var y = di.Value.Split(new[] { "###" }, StringSplitOptions.None);
                //if (y.Length != 2)
                //    throw new Exception("Formato stringa firmata non corretta");
                //f.IdFile = int.Parse(y[1]);
                //f.NomeFile = HttpUtility.HtmlDecode(y[0]);
                //if (System.IO.Path.GetExtension(f.NomeFile).ToLower() == ".pdf")
                //{
                //    f.MediaType = "application/pdf";
                //}
                //else
                //{
                //    f.NomeFile += ".p7m";
                //    f.MediaType = "application/pkcs7-mime";
                //}
                //request.FilesFirmati.Add(f);
            }
            return files.ToArray();
        }

        public static List<SignInfo> ExtractSignedDataCalamaio1(string signedData)
        {
            var lresult = new List<SignInfo>();
            var xmlDoc = XDocument.Parse(signedData); ;
            //xmlDoc.LoadXml(signedData);

            var res = xmlDoc.Descendants("signResult").FirstOrDefault();
            if (res == null || res.Value != "Success")
            {
                var err = xmlDoc.Descendants("error").FirstOrDefault();
                if (err != null)
                    throw new Exception("Errore Calamaio: " + err.Value);
            }

            //var filesFirmati = xmlDoc.SelectNodes("//document");
            var filesFirmati = xmlDoc.Descendants("document");


            //if (request.FilesFirmati == null)
            //    request.FilesFirmati = new List<File>();

            var files = new List<string>();

            foreach (XElement node in filesFirmati)
            {
                var signInfo = new SignInfo();
                var di = node.Descendants("documentIdentifier").FirstOrDefault();
                var da = node.Descendants("documentData").FirstOrDefault();

                signInfo.DocumentIdentifier = di.Value;
                signInfo.SignedData = da.Value;

                lresult.Add(signInfo);

                files.Add(da.Value);
                //var f = new File();
                //f.Content = Convert.FromBase64String(da.InnerText);
                //f.SetImpronta();
                var y = di.Value.Split(new[] { "###" }, StringSplitOptions.None);
                //if (y.Length != 2)
                //    throw new Exception("Formato stringa firmata non corretta");
                //f.IdFile = int.Parse(y[1]);
                //f.NomeFile = HttpUtility.HtmlDecode(y[0]);
                //if (System.IO.Path.GetExtension(f.NomeFile).ToLower() == ".pdf")
                //{
                //    f.MediaType = "application/pdf";
                //}
                //else
                //{
                //    f.NomeFile += ".p7m";
                //    f.MediaType = "application/pkcs7-mime";
                //}
                //request.FilesFirmati.Add(f);
            }
            //return files.ToArray();
            return lresult;
        }
    }

    public class SignInfo
    {
        public string DocumentIdentifier { get; set; }
        public string SignedData { get; set; }
    }
}
