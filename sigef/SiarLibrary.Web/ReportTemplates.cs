using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using SiarLibrary.Web.WsReportExecutionService;
using SiarLibrary.Web.WsReportingService2010;

namespace SiarLibrary.Web
{
    public class ReportTemplates : IDisposable
    {
        ReportExecutionService reportExecution;
        ReportingService2010 reportService;
        Xconfig configurazione_ws;

        public ReportTemplates()
        {
            initConfig();
        }

        private void initConfig()
        {
            string rptTpoConfigurazione = ConfigurationManager.AppSettings["WSreportTipoConfigurazione"].ToString();
            if (configurazione_ws == null) configurazione_ws = new SiarBLL.XconfigCollectionProvider().GetById(rptTpoConfigurazione);
            if (!configurazione_ws.Attivo) throw new Exception("Servizio report non attivo, si prega di riprovare in un secondo momento.");
        }

        private void initReportExecution()
        {
            if (reportExecution == null)
            {
                if (configurazione_ws == null) throw new Exception("Servizio report non configurato correttamente. Impossibile continuare.");
                reportExecution = new ReportExecutionService();
                reportExecution.Url = ConfigurationManager.AppSettings["WSreportExecutionUrl"];
                reportExecution.Credentials = new NetworkCredential(configurazione_ws.Login, configurazione_ws.Pwd, configurazione_ws.Dominio);
            }
        }

        private void initReportService()
        {
            if (reportService == null)
            {
                if (configurazione_ws == null) throw new Exception("Servizio report non configurato correttamente. Impossibile continuare.");
                reportService = new ReportingService2010();
                reportService.Url = ConfigurationManager.AppSettings["WSreportServiceUrl"];
                reportService.Credentials = new NetworkCredential(configurazione_ws.Login, configurazione_ws.Pwd, configurazione_ws.Dominio);
            }
        }

        private XmlNode CreateReportItem(ref XmlDocument xDoc, int index, string reportName, string namespaceuri)
        {
            const int dimension = 2;

            // Elemento Subreport
            XmlElement subreport = xDoc.CreateElement("Subreport", namespaceuri);

            XmlAttribute nameElem = xDoc.CreateAttribute("Name");
            nameElem.Value = "subreport" + index;
            subreport.Attributes.Append(nameElem);

            XmlElement report_name = xDoc.CreateElement("ReportName", namespaceuri);
            report_name.InnerText = reportName;
            subreport.AppendChild(report_name);

            XmlElement report_DataElementOutput = xDoc.CreateElement("DataElementOutput", namespaceuri);
            report_DataElementOutput.InnerText = "Output";
            subreport.AppendChild(report_DataElementOutput);

            XmlElement ParametersXmlElem = xDoc.CreateElement("Parameters", namespaceuri);
            XmlElement ParameterXmlElem = xDoc.CreateElement("Parameter", namespaceuri);

            XmlAttribute ParameterNameElem = xDoc.CreateAttribute("Name");
            ParameterNameElem.Value = "ID_Domanda";
            ParameterXmlElem.Attributes.Append(ParameterNameElem);

            XmlElement ValueXmlElem = xDoc.CreateElement("Value", namespaceuri);
            ValueXmlElem.InnerText = "=Parameters!ID_Domanda.Value";

            ParameterXmlElem.AppendChild(ValueXmlElem);
            ParametersXmlElem.AppendChild(ParameterXmlElem);
            subreport.AppendChild(ParametersXmlElem);

            if (index > 0)
            {
                XmlElement top = xDoc.CreateElement("Top", namespaceuri);
                top.InnerText = (dimension * index).ToString() + "cm";
                subreport.AppendChild(top);

                XmlElement zindex = xDoc.CreateElement("ZIndex", namespaceuri);
                zindex.InnerText = dimension.ToString();
                subreport.AppendChild(zindex);
            }

            XmlElement widthElem = xDoc.CreateElement("Width", namespaceuri);
            widthElem.InnerText = dimension + "cm";
            subreport.AppendChild(widthElem);

            XmlElement heightElem = xDoc.CreateElement("Height", namespaceuri);
            heightElem.InnerText = dimension + "cm";
            subreport.AppendChild(heightElem);

            return subreport;
        }

        /// <summary>
        /// Crea e registra il nuovo report Modello di Domanda
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="idmodello"></param>
        /// <returns></returns>
        public void RegistraModelloDomanda(int IdModello)
        {
            initReportService();
            string ReportName = "rptModelloDomanda" + IdModello.ToString();
            // 1. Load del Report 'contenitore'
            XmlDocument xDoc = new XmlDocument();
            byte[] reportDefinition = reportService.GetItemDefinition(configurazione_ws.DefaultDirectory + "/rptModelloDomanda");
            xDoc.Load(new MemoryStream(reportDefinition));
            // 2. Caricamento Quadri per Modello Domanda            
            QuadriXDomandaCollection qxdcoll = new SiarBLL.QuadriXDomandaCollectionProvider().Find(null, IdModello, null);
            if (qxdcoll.Count > 0)
            {
                qxdcoll.Sort("Ordine");

                XmlNode BodyXmlNode = xDoc.GetElementsByTagName("Body")[0];
                XmlNode ReportItems = xDoc.CreateElement("ReportItems", BodyXmlNode.NamespaceURI);

                // Intestazione Modello Domanda
                ReportItems.AppendChild(CreateReportItem(ref xDoc, 0, "IntestazioneModelloDomanda", BodyXmlNode.NamespaceURI));

                int index = 1;
                foreach (QuadriXDomanda qXd in qxdcoll)
                {
                    // Caricamento quadri
                    if (!string.IsNullOrEmpty(qXd.MetodoReport))
                    {
                        ReportItems.AppendChild(CreateReportItem(ref xDoc, index, qXd.MetodoReport, BodyXmlNode.NamespaceURI));
                        index += 1;
                    }
                }
                // Aggiunta dei SubReports al Body del report container
                BodyXmlNode.InsertAfter(ReportItems, BodyXmlNode.ChildNodes[BodyXmlNode.ChildNodes.Count - 1]);
            }

            // Registrazione del report
            SiarLibrary.Web.WsReportingService2010.Warning[] warning2010;
            reportService.CreateCatalogItem("Report", ReportName, configurazione_ws.DefaultDirectory, true,
                    Encoding.UTF8.GetBytes(xDoc.InnerXml), null, out warning2010);
        }

        public bool ModelloDomandaReportExists(string IdModello)
        {
            try
            {
                initReportService();
                byte[] reportDefinition = reportService.GetItemDefinition(configurazione_ws.DefaultDirectory + "/rptModelloDomanda" + IdModello);
                return reportDefinition != null;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// metodo pubblico l'esecuzione di un report tramite il nome
        /// </summary>
        /// <param name="name">nome del report</param>
        /// <param name="parametri">ogni elemento deve essere una stringa del tipo nome_parametro=valore</param>
        /// <returns>il report in byte[]</returns>
        public byte[] getReportByName(string name, string[] parametri)
        {
            return getReportByName(name, ReportFormat.PDF, parametri);
        }

        public byte[] getReportByName(string name, int rformat, string[] parametri)
        {
            if (rformat < 1 || rformat > 4) throw new Exception("Il formato del documento richiesto non è valido.");
            return getReportByName(name, (ReportFormat)rformat, parametri);
        }

        public byte[] getReportByName(string reportName, ReportFormat formato, string[] parametri)
        {
            string extension;
            string historyID = null;
            string devInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";
            SiarLibrary.Web.WsReportExecutionService.ParameterValue[] parameters = null;
            string encoding;
            string mimeType;
            string[] streamIDs = null;
            WsReportExecutionService.Warning[] warnings = null;

            initReportExecution();
            ExecutionInfo execInfo = new ExecutionInfo();
            ExecutionHeader execHeader = new ExecutionHeader();
            reportExecution.ExecutionHeaderValue = execHeader;
            execInfo = reportExecution.LoadReport(configurazione_ws.DefaultDirectory + "/" + reportName, historyID);
            String SessionId = reportExecution.ExecutionHeaderValue.ExecutionID;
            if (parametri != null && parametri.Length > 0)
            {
                int numero_parametri = parametri.Length;
                parameters = new SiarLibrary.Web.WsReportExecutionService.ParameterValue[numero_parametri];
                for (int i = 0; i < numero_parametri; i++)
                {
                    if (!string.IsNullOrEmpty(parametri[i]))
                    {
                        string[] str = parametri[i].Split('=');
                        SiarLibrary.Web.WsReportExecutionService.ParameterValue p = new SiarLibrary.Web.WsReportExecutionService.ParameterValue();
                        p.Name = str[0];
                        p.Value = str[1];
                        parameters[i] = p;
                    }
                }
                reportExecution.SetExecutionParameters(parameters, "it-it");
            }
            byte[] report = reportExecution.Render(formato.ToString(), devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);
            //execInfo = reportExecution.GetExecutionInfo();
            return report;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (reportExecution != null)
            {
                reportExecution.Dispose();
                reportExecution = null;
            }
        }

        #endregion
    }

    //public static class ReportDefinition
    //{
    //    public static string GetReportURl(string nome_report, ReportFormat formato)
    //    {
    //        return System.Configuration.ConfigurationManager.AppSettings["ReportServer"] + "/" + nome_report
    //            + "&rs:Command=Render&rs:Format=" + formato + "&";
    //    }
    //}

    public enum ReportFormat
    {
        PDF = 1, Excel = 2, Word = 3, CSV = 4, TXT = 5, NonSpecificato = 6
    }
}
