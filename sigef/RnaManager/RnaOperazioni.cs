using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Data;
using System.Transactions;

namespace RnaManager
{
    public partial class RnaOperazioni
    {
        private CallWS _ws { get; set; }
        private DALClass _dal { get; set; }
        private Logger _logger { get; set; }
        private string _xslt_path { get; set; }
        private RnaCryptography _crypt { get; set; }

        public XDocument genera_xml(int id_progetto)
        {
            var result = new ResultInfoConcessione();
            var data = _dal.GetAiuto(id_progetto);
            var doc = GetAiutoXML(data, _xslt_path);
            return doc;
        }

        public RnaOperazioni(int idRnaEnte)
        {

            string username, cryptedPsw, password;
            bool produzione;
            _dal = new DALClass();
            _logger = new Logger(_dal);
            _crypt = new RnaCryptography();

            _dal.getCredenziali(idRnaEnte, out username, out cryptedPsw, out produzione);
            password = _crypt.Decrypt(cryptedPsw);
            try
            {
                _ws = new CallWS(username, password, produzione);
            }
            catch (Exception e)
            {
                string app = e.Message;
                throw new Exception("Credenziali ente RNA errate, contattare l'Help Desk.");
            }

            if (ConfigurationManager.AppSettings["rna_transform.xslt"] != null)
            {
                string relativePath = ConfigurationManager.AppSettings["rna_transform.xslt"].ToString();
                string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                _xslt_path = rootPath;//ConfigurationManager.AppSettings["rna_transform.xslt"].ToString();
            }
        }

        #region Gestione Visure

        public ResultInfoVisura RequestVisuraAiuti(ProjectInfo projectInfo, DateTime dataInizioAnalisi)
        {
            var result = new ResultInfoVisura();

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    result = _ws.RequestVisuraAiuti(projectInfo.IdFiscaleImpresa, dataInizioAnalisi);
                    result.IdProgetto = projectInfo.IdProgetto;
                    result.TipoVisura = "aiuti";

                    _logger.InsertLogVisura(projectInfo, result);

                    ts.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResultInfoVisura RequestVisuraDeminimis(ProjectInfo projectInfo, DateTime dataFineEsercizioFinanziario, DateTime dataConcessionePrevista)
        {
            var result = new ResultInfoVisura();

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    result = _ws.RequestVisuraDeMinimis(projectInfo.IdFiscaleImpresa, dataFineEsercizioFinanziario, dataConcessionePrevista, null);
                    result.IdProgetto = projectInfo.IdProgetto;
                    result.TipoVisura = "deminimis";

                    _logger.InsertLogVisura(projectInfo, result);

                    ts.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResultInfoVisura RequestVisuraDeggendorf(ProjectInfo projectInfo)
        {
            var result = new ResultInfoVisura();

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    result = _ws.RequestVisuraDeggendorf(projectInfo.IdFiscaleImpresa);
                    result.IdProgetto = projectInfo.IdProgetto;
                    result.TipoVisura = "deggendorf";

                    _logger.InsertLogVisura(projectInfo, result);

                    ts.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResultInfoVisura GetVisura(string idRichiesta)
        {
            var result = new ResultInfoVisura();

            try
            {
                var checkResult = GetStatoRichiesta(idRichiesta);
                if (checkResult.Success && checkResult.DescrizioneEsito == "Completata")
                {
                    result = _ws.GetVisura(idRichiesta);
                }
                else
                {
                    result.Success = checkResult.Success;
                    result.CodiceEsito = checkResult.CodiceEsito;
                    result.DescrizioneEsito = checkResult.DescrizioneEsito;
                }

                checkResult.PayloadEsito = result.PayloadEsito;
                _logger.UpdateLogVisura(checkResult);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Gestione stato richieste

        public ResultInfo GetStatoRichiesta(string idRichiesta)
        {
            var result = new ResultInfo();

            try
            {
                result = _ws.GetStatoRichiesta(idRichiesta);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Registrazione aiuti

        public ResultInfoConcessione RegistraAiuto(ProjectInfo projectInfo, bool produzione)
        {
            var result = new ResultInfoConcessione();

            var idProgetto = projectInfo.IdProgetto;
            string codiceBando = projectInfo.CodiceBandoRna;

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    var data = _dal.GetAiuto(idProgetto.Value);
                    var doc = GetAiutoXML(data, _xslt_path);
                    string idProgettoRna = doc.Descendants().Where(p => p.Name.LocalName == "ID_CONCESSIONE_GEST").FirstOrDefault().Value;
                    string idFiscaleImpresa = doc.Descendants().Where(p => p.Name.LocalName == "CODICE_FISCALE").FirstOrDefault().Value;
                    string idImpresa = doc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value;
                    projectInfo.IdImpresa = int.Parse(idImpresa);
                    projectInfo.IdProgettoRna = idProgettoRna;
                    projectInfo.IdFiscaleImpresa = idFiscaleImpresa;
                    doc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value = "";
                    projectInfo.IdProgettoRna = idProgettoRna;
                    string istanza = doc.ToString(SaveOptions.DisableFormatting);
                    result = _ws.RegistraAiuto(codiceBando, istanza);
                    result.IstanzaRichiesta = istanza;
                    result.IdProgetto = projectInfo.IdProgetto;
                    result.IdProgettoRna = projectInfo.IdProgettoRna;
                    _logger.InsertLogConcessione(projectInfo, result, produzione);
                    ts.Complete();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResultInfoConcessione RegistraAiutoSingolaImpresa(ProjectInfo projectInfo,bool produzione)
        {
            var result = new ResultInfoConcessione();

            var idProgetto = projectInfo.IdProgetto;
            string codiceBando = projectInfo.CodiceBandoRna;

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    var data = _dal.GetAiutoSingolaImpresa(idProgetto.Value, projectInfo.IdImpresa,produzione);
                    var doc = GetAiutoXML(data, _xslt_path);
                    string idProgettoRna = doc.Descendants().Where(p => p.Name.LocalName == "ID_CONCESSIONE_GEST").FirstOrDefault().Value;
                    string idFiscaleImpresa = doc.Descendants().Where(p => p.Name.LocalName == "CODICE_FISCALE").FirstOrDefault().Value;
                    string idImpresa = doc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value;
                    projectInfo.IdImpresa = int.Parse(idImpresa);
                    projectInfo.IdProgettoRna = idProgettoRna;
                    projectInfo.IdFiscaleImpresa = idFiscaleImpresa;
                    doc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value = "";
                    projectInfo.IdProgettoRna = idProgettoRna;
                    string istanza = doc.ToString(SaveOptions.DisableFormatting);
                    result = _ws.RegistraAiuto(codiceBando, istanza);
                    result.IstanzaRichiesta = istanza;
                    result.IdProgetto = projectInfo.IdProgetto;
                    result.IdProgettoRna = projectInfo.IdProgettoRna;
                    _logger.InsertLogConcessione(projectInfo, result, produzione);

                    ts.Complete();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResultInfoConcessione RegistraAiutoSingolaImpresaCovid(ProjectInfo projectInfo, bool produzione)
        {
            var result = new ResultInfoConcessione();

            var idProgetto = projectInfo.IdProgetto;
            string codiceBando = projectInfo.CodiceBandoRna;

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    var data = _dal.GetAiutoSingolaImpresaCovid(idProgetto.Value, projectInfo.IdImpresa, produzione);
                    var doc = GetAiutoXML(data, _xslt_path);
                    string idProgettoRna = doc.Descendants().Where(p => p.Name.LocalName == "ID_CONCESSIONE_GEST").FirstOrDefault().Value;
                    string idFiscaleImpresa = doc.Descendants().Where(p => p.Name.LocalName == "CODICE_FISCALE").FirstOrDefault().Value;
                    string idImpresa = doc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value;
                    projectInfo.IdImpresa = int.Parse(idImpresa);
                    projectInfo.IdProgettoRna = idProgettoRna;
                    projectInfo.IdFiscaleImpresa = idFiscaleImpresa;
                    doc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value = "";
                    projectInfo.IdProgettoRna = idProgettoRna;
                    string istanza = doc.ToString(SaveOptions.DisableFormatting);
                    result = _ws.RegistraAiuto(codiceBando, istanza);
                    result.IstanzaRichiesta = istanza;
                    result.IdProgetto = projectInfo.IdProgetto;
                    result.IdProgettoRna = projectInfo.IdProgettoRna;
                    _logger.InsertLogConcessione(projectInfo, result, produzione);

                    ts.Complete();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ResultInfoConcessione> RegistraAiutoMassivo(ProjectInfo projectInfo, bool produzione)
        {
            var lresult = new List<ResultInfoConcessione>();

            var idProgetto = projectInfo.IdProgetto;
            string codiceBando = projectInfo.CodiceBandoRna;

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    var data = _dal.GetAiuto(idProgetto.Value);
                    //var doc = GetAiutoXML(data, _xslt_path).ToString(SaveOptions.DisableFormatting);
                    var doc = GetAiutoXML(data, _xslt_path);
                    var ldoc = SplitConcessioni(doc);

                    foreach (XDocument cdoc in ldoc)
                    {
                        string idProgettoRna = cdoc.Descendants().Where(p => p.Name.LocalName == "ID_CONCESSIONE_GEST").FirstOrDefault().Value;
                        string idFiscaleImpresa = cdoc.Descendants().Where(p => p.Name.LocalName == "CODICE_FISCALE").FirstOrDefault().Value;
                        string idImpresa = cdoc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value;
                        projectInfo.IdImpresa = int.Parse(idImpresa);
                        projectInfo.IdProgettoRna = idProgettoRna;
                        projectInfo.IdFiscaleImpresa = idFiscaleImpresa;
                        cdoc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value = "";
                        string istanza = cdoc.ToString(SaveOptions.DisableFormatting);
                        var result = _ws.RegistraAiuto(codiceBando, istanza);
                        result.IstanzaRichiesta = istanza;
                        result.IdProgetto = projectInfo.IdProgetto;
                        result.IdProgettoRna = projectInfo.IdProgettoRna;
                        lresult.Add(result);

                        _logger.InsertLogConcessione(projectInfo, result, produzione);
                    }



                    ts.Complete();
                }
                return lresult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //var lresult = new List<ResultInfoConcessione>();

            //var idProgetto = projectInfo.IdProgetto;
            //string codiceBando = projectInfo.CodiceBandoRna;

            //try
            //{
            //    using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
            //    {
            //        IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
            //    }))
            //    {
            //        var data = _dal.GetAiuto(idProgetto.Value);
            //        //var doc = GetAiutoXML(data, _xslt_path).ToString(SaveOptions.DisableFormatting);
            //        var doc = GetAiutoXML(data, _xslt_path);
            //        var ldoc = SplitConcessioni(doc);

            //        foreach(XDocument cdoc in ldoc)
            //        {
            //            string idProgettoRna = cdoc.Descendants().Where(p => p.Name.LocalName == "ID_CONCESSIONE_GEST").FirstOrDefault().Value;
            //            projectInfo.IdProgettoRna = idProgettoRna;
            //            string idImpresa = cdoc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value;
            //            projectInfo.IdImpresa = int.Parse(idImpresa);
            //            var result = _ws.RegistraAiuto(codiceBando, cdoc.ToString(SaveOptions.DisableFormatting));
            //            lresult.Add(result);

            //            _logger.InsertLogConcessione(projectInfo, result);
            //        }



            //        ts.Complete();
            //    }
            //    return lresult;
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }


        public ResultInfoConcessione AggiornaStatoConcessione(string IdRichiesta, bool produzione)
        {
            var result = new ResultInfoConcessione();
            var response = new ResultInfoConcessione();

            var projectInfo = new ProjectInfo();
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    var log = _dal.GetRnaLogConcessioneByIdRichiesta(IdRichiesta, true, true);

                    projectInfo.IdProgetto = log.ID_PROGETTO;
                    projectInfo.IdProgettoRna = log.ID_PROGETTO_RNA;
                    projectInfo.IdImpresa = log.ID_IMPRESA;
                    projectInfo.IdFiscaleImpresa = log.ID_FISCALE_IMPRESA;
                    projectInfo.IdOperatore = log.ID_OPERATORE_REG_AIUTO;

                    var checkResult = GetStatoRichiesta(IdRichiesta);
                    if (checkResult.Success && checkResult.DescrizioneEsito == "Completata")
                    {
                        response = _ws.GetEsitoRichiestaAiuto(IdRichiesta);
                        var istanza = Encoding.UTF8.GetString(response.PayloadEsito, 0, response.PayloadEsito.Length);
                        var doc = XDocument.Parse(istanza);
                        doc.Declaration = null;
                        var esito = GetEsito(doc).First();
                        if (esito.Key == "0") //esito positivo, recupero il COR
                        {
                            //Estrazione COR
                            var cor = GetCor(doc).First();
                            //Inserimento in Progetto_Cor

                            var progettoCor = new RnaProgettoCor();
                            progettoCor.ID_PROGETTO = log.ID_PROGETTO.Value;
                            progettoCor.ID_PROGETTO_RNA = log.ID_PROGETTO_RNA;
                            progettoCor.ID_IMPRESA = log.ID_IMPRESA;
                            progettoCor.ID_FISCALE_IMPRESA = log.ID_FISCALE_IMPRESA;
                            progettoCor.COR = cor.Key;
                            progettoCor.DATA_ASSEGNAZIONE_COR = System.DateTime.Now;
                            progettoCor.ID_OPERATORE_ASSEGNAZIONE_COR = log.ID_OPERATORE_REG_AIUTO;//projectInfo.IdOperatore;
                            progettoCor.ID_RICHIESTA = IdRichiesta;
                            progettoCor.STATO_CONCESSIONE = "Da Confermare";

                            result.StatoConcessione = progettoCor.STATO_CONCESSIONE;
                            result.CodiceEsito = log.CODICE_ESITO;
                            result.DescrizioneEsito = log.DESCRIZIONE_ESITO;
                            result.SuccessEsitoRichiesta = response.Success;
                            result.IdRichiesta = IdRichiesta;
                            result.CodiceEsitoRichiesta = response.CodiceEsitoRichiesta;
                            result.DescrizioneEsitoRichiesta = response.DescrizioneEsitoRichiesta;
                            result.IdProgetto = progettoCor.ID_PROGETTO;
                            result.IdProgettoRna = progettoCor.ID_PROGETTO_RNA;
                            result.COR = cor.Key;

                            _dal.InsertRnaProgettoCor(progettoCor);
                            //Aggiornamento log concessione
                            //projectInfo.

                        }
                        //esito con errori, restituisco l'esito all'interno dell'istanza
                        result.IstanzaRisposta = doc.ToString();
                        result.CodiceEsitoRichiesta = int.Parse(esito.Key);
                        result.DescrizioneEsitoRichiesta = esito.Value;


                    }
                    else
                    {
                        result.Success = checkResult.Success;
                        result.CodiceEsito = checkResult.CodiceEsito;
                        result.DescrizioneEsito = checkResult.DescrizioneEsito;
                    }

                    result.IdProgetto = projectInfo.IdProgetto;
                    result.IdProgettoRna = projectInfo.IdProgettoRna;


                    _logger.UpdateLogConcessione(IdRichiesta, projectInfo, result, produzione);

                    ts.Complete();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //var result = new ResultInfoConcessione();

            //try
            //{
            //    using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
            //    {
            //        IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
            //    }))
            //    {
            //        var checkResult = GetStatoRichiesta(IdRichiesta);
            //        if (checkResult.Success && checkResult.DescrizioneEsito == "Completata")
            //        {
            //            result = _ws.GetEsitoRichiestaAiuto(IdRichiesta);
            //            var istanza = Encoding.UTF8.GetString(result.PayloadEsito, 0, result.PayloadEsito.Length);
            //            var doc = XDocument.Parse(istanza);
            //            var esito = GetEsito(doc).First();
            //            if (esito.Key == "0") //esito positivo, recupero il COR
            //            {
            //                //Estrazione COR
            //                var cor = GetCor(doc).First();
            //                //Inserimento in Progetto_Cor

            //                var progettoCor = new RnaProgettoCor();
            //                progettoCor.ID_PROGETTO = projectInfo.IdProgetto.Value;
            //                progettoCor.ID_PROGETTO_RNA = cor.Value;
            //                progettoCor.COR = cor.Key;
            //                progettoCor.DATA_ASSEGNAZIONE_COR = System.DateTime.Now;
            //                progettoCor.ID_OPERATORE_ASSEGNAZIONE_COR = projectInfo.IdOperatore;
            //                progettoCor.ID_RICHIESTA = IdRichiesta;
            //                progettoCor.STATO_CONCESSIONE = "Da Confermare";

            //                result.IstanzaRisposta = istanza;
            //                result.StatoConcessione = progettoCor.STATO_CONCESSIONE;
            //                result.SuccessEsitoRichiesta = result.Success;
            //                result.IdRichiesta = IdRichiesta;

            //                _dal.InsertRnaProgettoCor(progettoCor);
            //                //Aggiornamento log concessione
            //                //projectInfo.
            //                _logger.UpdateLogConcessione(IdRichiesta, projectInfo, result);
            //            }
            //            //esito con errori, restituisco l'esito all'interno dell'istanza
            //            result.CodiceEsitoRichiesta = int.Parse(esito.Key);
            //            result.DescrizioneEsitoRichiesta = esito.Value;


            //        }
            //        else
            //        {
            //            result.Success = checkResult.Success;
            //            result.CodiceEsito = checkResult.CodiceEsito;
            //            result.DescrizioneEsito = checkResult.DescrizioneEsito;
            //        }

            //        ts.Complete();
            //    }
            //    return result;
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }

        #region metodi per la manipolazione delle istanze

        internal XDocument GetAiutoXML(DataSet ds, string xslt)
        {
            try
            {
                XPathDocument dx1 = new XPathDocument(XmlReader.Create(new StringReader(ds.GetXml())));
                XslCompiledTransform xst = new XslCompiledTransform();
                xst.Load(xslt);
                MemoryStream stream = new MemoryStream();
                xst.Transform(dx1, null, stream);
                stream.Position = 0;
                XDocument xdoc = XDocument.Load(XmlReader.Create(stream));
                stream.Close();
                stream.Dispose();
                xdoc.Descendants("CONCESSIONI").Where(n => n.IsEmpty).Remove();

                return xdoc;
            }
            catch (XsltException ex)
            {
                throw ex;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<XDocument> SplitConcessioni(XDocument doc)
        {
            var ldoc = new List<XDocument>();

            try
            {
                List<XElement> nodes = doc.Descendants().Where(p => p.Name.LocalName == "CONCESSIONE").ToList();
                XNamespace xmlns = XNamespace.Get("http://www.rna.gov.it/invio");

                foreach (XElement node in nodes)
                {
                    XElement root = new XElement(doc.Root.Name);
                    root.Add(doc.Root.Attributes().ToArray());
                    XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), root);
                    xdoc.Root.Add(doc.Root.Element(xmlns + "COD_BANDO"));
                    xdoc.Root.Add(doc.Root.Element(xmlns + "NOTIFICA_ELABORAZIONE_RICHIESTA"));
                    xdoc.Root.Add(new XElement(xmlns + "CONCESSIONI"));
                    xdoc.Root.Element(xmlns + "CONCESSIONI").Add(node);
                    ldoc.Add(xdoc);
                }

                return ldoc;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        #endregion


        #region metodi per la estrazione campi dalla istanza  esito richiesta
        internal Dictionary<string, string> GetCor(string esitoRichiesta)
        {
            try
            {
                XDocument xdoc = XDocument.Parse(esitoRichiesta);
                var esitoElement = xdoc.Descendants().Where(p => p.Name.LocalName == "ESITO").FirstOrDefault();
                string codice = esitoElement.Descendants().Where(p => p.Name.LocalName == "CODICE").FirstOrDefault().Value;
                Dictionary<string, string> dicCor = new Dictionary<string, string>();

                if (codice == "0")
                {
                    var corElements = xdoc.Descendants().Where(p => p.Name.LocalName == "ESITI_RICH_CONCESSIONI");
                    foreach (XElement item in corElements.Descendants().Where(p => p.Name.LocalName == "ESITO_RICH_CONCESSIONE"))
                    {
                        string cor = item.Elements().Where(p => p.Name.LocalName == "COR").FirstOrDefault().Value;
                        string id_conc = item.Elements().Where(p => p.Name.LocalName == "ID_CONCESSIONE_GEST").FirstOrDefault().Value;
                        dicCor.Add(cor, id_conc);
                    }
                }

                return dicCor;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal Dictionary<string, string> GetCor(XDocument esitoRichiesta)
        {
            try
            {
                Dictionary<string, string> dicCor = new Dictionary<string, string>();

                var corElements = esitoRichiesta.Descendants().Where(p => p.Name.LocalName == "ESITI_RICH_CONCESSIONI");
                foreach (XElement item in corElements.Descendants().Where(p => p.Name.LocalName == "ESITO_RICH_CONCESSIONE"))
                {
                    string cor = item.Elements().Where(p => p.Name.LocalName == "COR").FirstOrDefault().Value;
                    string id_conc = item.Elements().Where(p => p.Name.LocalName == "ID_CONCESSIONE_GEST").FirstOrDefault().Value;
                    dicCor.Add(cor, id_conc);
                }

                return dicCor;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal Dictionary<string, string> GetEsito(string msg)
        {
            var result = new Dictionary<string, string>();
            XDocument xdoc = XDocument.Parse(msg);
            var esitoElement = xdoc.Descendants().Where(p => p.Name.LocalName == "ESITO").FirstOrDefault();
            string codice = esitoElement.Descendants().Where(p => p.Name.LocalName == "CODICE").FirstOrDefault().Value;
            string descrizione = esitoElement.Descendants().Where(p => p.Name.LocalName == "DESCRIZIONE").FirstOrDefault().Value;
            result.Add(codice, descrizione);
            return result;
        }


        internal Dictionary<string, string> GetEsito(XDocument msg)
        {
            var result = new Dictionary<string, string>();
            //XDocument xdoc = XDocument.Parse(msg);
            var esitoElement = msg.Descendants().Where(p => p.Name.LocalName == "ESITO").FirstOrDefault();
            string codice = esitoElement.Descendants().Where(p => p.Name.LocalName == "CODICE").FirstOrDefault().Value;
            string descrizione = esitoElement.Descendants().Where(p => p.Name.LocalName == "DESCRIZIONE").FirstOrDefault().Value;
            result.Add(codice, descrizione);
            return result;
        }

        #endregion


        public ResultInfoConcessione GetCertificazioneRichiestaAiuto(string idRichiesta)
        {
            var result = new ResultInfoConcessione();

            try
            {
                result = _ws.GetCertificazioneRichiestaAiuto(idRichiesta);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResultInfoConcessione GetEsitoRichiestaAiuto(string idRichiesta)
        {
            var result = new ResultInfoConcessione();

            try
            {
                result = _ws.GetEsitoRichiestaAiuto(idRichiesta);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResultInfoConcessione ConfermaConcessione(string COR, int idOperatore, string numeroAtto, DateTime dataAtto)
        {
            var result = new ResultInfoConcessione();
            var response = new ResultInfoConcessione();
            var progettoCor = _dal.GetRnaProgettoCorByCor(COR);
            var logConcessione = _dal.GetRnaLogConcessioneByIdRichiesta(progettoCor.ID_RICHIESTA, false, false);
            try
            {
                response = _ws.ConfermaConcessione(COR, numeroAtto, dataAtto);

                result.IdProgetto = progettoCor.ID_PROGETTO;
                result.IdProgettoRna = progettoCor.ID_PROGETTO_RNA;
                result.IdRichiesta = progettoCor.ID_RICHIESTA;
                result.COR = COR;
                result.Success = response.Success;
                result.StatoConcessione = response.StatoConcessione;
                result.CodiceEsito = response.CodiceEsito;
                result.DescrizioneEsito = response.DescrizioneEsito;

                progettoCor.STATO_CONCESSIONE = response.StatoConcessione;
                progettoCor.CONFERMATO = response.StatoConcessione == "Confermata" ? true : false;
                //progettoCor.DATA_ASSEGNAZIONE_COR = DateTime.Now; //da togliere nell'update;
                progettoCor.DATA_CONFERMA_CONCESSIONE = DateTime.Now;
                progettoCor.ID_OPERATORE_CONFERMA_CONCESSIONE = idOperatore; //occorre passarlo tramite projectInfo?
                progettoCor.CODICE_ESITO_CONFERMA = response.CodiceEsito;
                progettoCor.DESCRIZIONE_ESITO_CONFERMA = response.DescrizioneEsito;
                _dal.UpdateRnaProgettoCor(progettoCor);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ResultInfoConcessione> ConfermaConcessione(string[] CORArray, string numeroAtto, DateTime dataAtto)
        {
            var lResult = new List<ResultInfoConcessione>();

            try
            {
                lResult = _ws.ConfermaConcessione(CORArray, numeroAtto, dataAtto);
                return lResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResultInfo ConfermaConcessioneMassivo(string message, string codiceBando)
        {
            var result = new ResultInfo();

            try
            {
                result = _ws.ConfermaConcessioneMassivo(message, codiceBando);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResultInfoConcessione AnnullaConcessione(string COR, int idOperatore)
        {
            var result = new ResultInfoConcessione();
            var response = new ResultInfoConcessione();
            var progettoCor = _dal.GetRnaProgettoCorByCor(COR);

            try
            {
                response = _ws.AnnullaConcessione(COR);

                result.IdProgetto = progettoCor.ID_PROGETTO;
                result.IdProgettoRna = progettoCor.ID_PROGETTO_RNA;
                result.IdRichiesta = progettoCor.ID_RICHIESTA;
                result.COR = COR;
                result.Success = response.Success;
                result.StatoConcessione = response.StatoConcessione;
                result.CodiceEsito = response.CodiceEsito;
                result.DescrizioneEsito = response.DescrizioneEsito;

                progettoCor.STATO_CONCESSIONE = response.StatoConcessione;
                progettoCor.ANNULLATO = response.StatoConcessione == "Annullata" ? true : false;
                //progettoCor.DATA_ASSEGNAZIONE_COR = DateTime.Now; //da togliere nell'update;
                progettoCor.DATA_ANNULLAMENTO = DateTime.Now;
                progettoCor.ID_OPERATORE_ANNULLAMENTO = idOperatore; //occorre passarlo tramite projectInfo?

                _dal.UpdateRnaProgettoCor(progettoCor);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal string GetConcessioneMassivaMessage(int[] progetti)
        {
            string result = string.Empty;

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

        #region metodi di test

        public List<ResultInfoConcessione> RegistraAiutoMassivoTest(ProjectInfo projectInfo, bool produzione)
        {
            var lresult = new List<ResultInfoConcessione>();

            var idProgetto = projectInfo.IdProgetto;
            string codiceBando = projectInfo.CodiceBandoRna;

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    var data = _dal.GetAiuto(idProgetto.Value);
                    //var doc = GetAiutoXML(data, _xslt_path).ToString(SaveOptions.DisableFormatting);
                    var doc = GetAiutoXML(data, _xslt_path);
                    var ldoc = SplitConcessioni(doc);

                    foreach (XDocument cdoc in ldoc)
                    {
                        string idProgettoRna = cdoc.Descendants().Where(p => p.Name.LocalName == "ID_CONCESSIONE_GEST").FirstOrDefault().Value;
                        string idFiscaleImpresa = cdoc.Descendants().Where(p => p.Name.LocalName == "CODICE_FISCALE").FirstOrDefault().Value;
                        string idImpresa = cdoc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value;
                        projectInfo.IdImpresa = int.Parse(idImpresa);
                        projectInfo.IdProgettoRna = idProgettoRna;
                        projectInfo.IdFiscaleImpresa = idFiscaleImpresa;
                        cdoc.Descendants().Where(p => p.Name.LocalName == "NOTE_CONCESSIONE").FirstOrDefault().Value = "";
                        string istanza = cdoc.ToString(SaveOptions.DisableFormatting);
                        var result = _ws.RegistraAiutoTest(codiceBando, istanza);
                        result.IstanzaRichiesta = istanza;
                        result.IdProgetto = projectInfo.IdProgetto;
                        result.IdProgettoRna = projectInfo.IdProgettoRna;
                        lresult.Add(result);

                        _logger.InsertLogConcessione(projectInfo, result, produzione);
                    }



                    ts.Complete();
                }
                return lresult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResultInfoConcessione AggiornaStatoConcessioneTest(string IdRichiesta, bool produzione)
        {
            var result = new ResultInfoConcessione();
            var response = new ResultInfoConcessione();

            var projectInfo = new ProjectInfo();
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                }))
                {
                    var log = _dal.GetRnaLogConcessioneByIdRichiesta(IdRichiesta, true, false);

                    projectInfo.IdProgetto = log.ID_PROGETTO;
                    projectInfo.IdProgettoRna = log.ID_PROGETTO_RNA;
                    projectInfo.IdImpresa = log.ID_IMPRESA;
                    projectInfo.IdFiscaleImpresa = log.ID_FISCALE_IMPRESA;
                    projectInfo.IdOperatore = log.ID_OPERATORE_REG_AIUTO;

                    var checkResult = GetStatoRichiestaTest(IdRichiesta);
                    if (checkResult.Success && checkResult.DescrizioneEsito == "Completata")
                    {
                        response = _ws.GetEsitoRichiestaAiutoTest(IdRichiesta);
                        var istanza = Encoding.UTF8.GetString(response.PayloadEsito, 0, response.PayloadEsito.Length);
                        var doc = XDocument.Parse(istanza);
                        var esito = GetEsito(doc).First();
                        if (esito.Key == "0") //esito positivo, recupero il COR
                        {
                            //Estrazione COR
                            var cor = GetCor(doc).First();
                            //Inserimento in Progetto_Cor

                            var progettoCor = new RnaProgettoCor();
                            progettoCor.ID_PROGETTO = log.ID_PROGETTO.Value;
                            progettoCor.ID_PROGETTO_RNA = log.ID_PROGETTO_RNA;
                            progettoCor.ID_IMPRESA = log.ID_IMPRESA;
                            progettoCor.ID_FISCALE_IMPRESA = log.ID_FISCALE_IMPRESA;
                            progettoCor.COR = cor.Key;
                            progettoCor.DATA_ASSEGNAZIONE_COR = System.DateTime.Now;
                            progettoCor.ID_OPERATORE_ASSEGNAZIONE_COR = log.ID_OPERATORE_REG_AIUTO;//projectInfo.IdOperatore;
                            progettoCor.ID_RICHIESTA = IdRichiesta;
                            progettoCor.STATO_CONCESSIONE = "Da Confermare";

                            result.IstanzaRisposta = istanza;
                            result.StatoConcessione = progettoCor.STATO_CONCESSIONE;
                            result.CodiceEsito = log.CODICE_ESITO;
                            result.DescrizioneEsito = log.DESCRIZIONE_ESITO;
                            result.SuccessEsitoRichiesta = response.Success;
                            result.IdRichiesta = IdRichiesta;
                            result.CodiceEsitoRichiesta = response.CodiceEsitoRichiesta;
                            result.DescrizioneEsitoRichiesta = response.DescrizioneEsitoRichiesta;
                            result.IdProgetto = progettoCor.ID_PROGETTO;
                            result.IdProgettoRna = progettoCor.ID_PROGETTO_RNA;
                            result.COR = cor.Key;

                            _dal.InsertRnaProgettoCor(progettoCor);
                            //Aggiornamento log concessione
                            //projectInfo.
                            _logger.UpdateLogConcessione(IdRichiesta, projectInfo, result, produzione);
                        }
                        //esito con errori, restituisco l'esito all'interno dell'istanza
                        result.CodiceEsitoRichiesta = int.Parse(esito.Key);
                        result.DescrizioneEsitoRichiesta = esito.Value;



                    }
                    else
                    {
                        result.Success = checkResult.Success;
                        result.CodiceEsito = checkResult.CodiceEsito;
                        result.DescrizioneEsito = checkResult.DescrizioneEsito;
                    }

                    result.IdProgetto = projectInfo.IdProgetto;
                    result.IdProgettoRna = projectInfo.IdProgettoRna;


                    ts.Complete();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResultInfo GetStatoRichiestaTest(string idRichiesta)
        {
            var result = new ResultInfo();

            try
            {
                result = _ws.GetStatoRichiestaTest(idRichiesta);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResultInfoConcessione ConfermaConcessioneTest(string COR, string numeroAtto, DateTime dataAtto)
        {
            var result = new ResultInfoConcessione();
            var response = new ResultInfoConcessione();
            var progettoCor = _dal.GetRnaProgettoCorByCor(COR);
            var logConcessione = _dal.GetRnaLogConcessioneByIdRichiesta(progettoCor.ID_RICHIESTA, false, false);
            try
            {
                response = _ws.ConfermaConcessioneTest(COR, numeroAtto, dataAtto);

                result.IdProgetto = progettoCor.ID_PROGETTO;
                result.IdProgettoRna = progettoCor.ID_PROGETTO_RNA;
                result.IdRichiesta = progettoCor.ID_RICHIESTA;
                result.COR = COR;
                result.Success = response.Success;
                result.StatoConcessione = response.StatoConcessione;
                result.CodiceEsito = response.CodiceEsito;
                result.DescrizioneEsito = response.DescrizioneEsito;

                progettoCor.STATO_CONCESSIONE = response.StatoConcessione;
                progettoCor.CONFERMATO = response.StatoConcessione == "Confermato" ? true : false;
                progettoCor.DATA_ASSEGNAZIONE_COR = DateTime.Now; //da togliere nell'update;
                progettoCor.DATA_CONFERMA_CONCESSIONE = DateTime.Now;
                progettoCor.ID_OPERATORE_CONFERMA_CONCESSIONE = 1; //occorre passarlo tramite projectInfo?

                _dal.UpdateRnaProgettoCor(progettoCor);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region utility

        internal ResultInfoConcessione Map(ProjectInfo projectInfo, ResultInfoConcessione resultInfo)
        {
            resultInfo.IdProgetto = projectInfo.IdProgetto;
            resultInfo.IdProgettoRna = projectInfo.IdProgettoRna;


            return resultInfo;
        }

        #endregion

    }
}
