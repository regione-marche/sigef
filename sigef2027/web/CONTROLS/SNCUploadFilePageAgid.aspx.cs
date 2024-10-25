using System;
using SiarLibrary.Extensions;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using SiarLibrary;
using System.Text;

namespace web.CONTROLS
{
    public partial class SNCUploadFilePageAgid : System.Web.UI.Page
    {
        string id_SNCUFActiveElement = null;
        private TipoFile tipo_file;
        private DimensioneFile dimensione_massima;

        static System.Collections.Generic.Dictionary<string, string> _dict = new System.Collections.Generic.Dictionary<string, string>
        {
            {"pdf","application/pdf"},
            {"doc","application/msword"},
            {"xls","application/vnd.ms-excel"},
            {"rtf","application/rtf"},
            {"txt","text/plain"},
            {"p7m","application/pkcs7-mime"},
            {"tif","image/tiff"},
            {"msg","application/msg"},
            {"jpg","image/jpeg"},
            {"htm","text/html"},
            {"gif","image/gif"},
            {"ai","application/postscript"},
            {"xml","application/xml"},
            {"bmp","image/bmp"},
            {"eml","message/rfc822"},
            {"odt","application/vnd.oasis.opendocument.text"},
            {"ods","application/vnd.oasis.opendocument.spreadsheet"},
            {"zip","application/zip"},
            {"docx","application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
            {"xlsx","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
            {"csv","text/comma-separated-values"},
            {"dat","application/octet-stream"},
            {"ssp","text/plain"},
            {"rar","application/x-rar-compressed"},
            {"p7s","application/pkcs7-signature"},
            {"svg","image/svg+xml"},
            {"jpeg","image/jpeg"},
            {"tsd","application/timestamped-data"},
            {"html","test/html"},
            {"tsr","application/timestamp-reply"}
        };

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            string messaggio = "Si è verificato un errore durante il caricamento del file selezionato.";
            if (exc.Message == "Maximum request length exceeded." || exc.Message == "Superata la lunghezza massima della richiesta.")
            {
                // controllo le impostazioni da web.config
                System.Web.Configuration.HttpRuntimeSection section = (System.Web.Configuration.HttpRuntimeSection)System.Configuration.
                    ConfigurationManager.GetSection("system.web/httpRuntime");
                int max_kb = 4096;
                if (section != null && section.MaxRequestLength > 0) max_kb = section.MaxRequestLength;
                messaggio = string.Format("I file non possono avere dimensioni maggiori di {0} Mb.", max_kb / 1024);
            }
            Response.ClearHeaders();
            Response.ClearContent();
            if (!string.IsNullOrEmpty(Request.QueryString["idtb"])) id_SNCUFActiveElement = Request.QueryString["idtb"].ToCleanJsString();
            Response.Write("<html><head><script type=\"text/javascript\">top.SNCUFUpdateActiveElement({ 'id': '','nome_file': 'File non valido.','id_SNCUFActiveElement': '"
                + id_SNCUFActiveElement + "' });alert('Attenzione! " + messaggio + "');</script></head><body></body></html>");
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link href=\"" + Request.ApplicationPath + "/SiarStyle.css\" type=\"text/css\" rel=\"stylesheet\" />"));
            ucFileUpload.Attributes.Add("onchange", "SNCUFPFileSelected(this);");
            if (!string.IsNullOrEmpty(Request.QueryString["idtb"])) id_SNCUFActiveElement = Request.QueryString["idtb"].ToCleanJsString();
            dimensione_massima = (DimensioneFile)Enum.Parse(typeof(DimensioneFile), Request.QueryString["dimx"]);
            tipo_file = (TipoFile)Enum.Parse(typeof(TipoFile), Request.QueryString["tf"]);
        }

       
        protected void   btnSNCUFCarica_Click(object sender, EventArgs e)
        {
            string script_finale = "";
            try
            {
                if (!ucFileUpload.HasFile) throw new Exception("Per proseguire è necessario specificare un file.");
                string tipo_file_ammesso = null;
                switch (tipo_file) //Immagine = 2, Documento = 3, WordFile = 4, ExcelsFile = 5, DocumentoFE = 6
                {
                    case 0:
                        if (!checkTipoGenerico(ucFileUpload.PostedFile)) tipo_file_ammesso = "pdf, doc, xls, rtf, txt, p7m, tif, msg, jpg, htm, gif, ai, xml, bmp, eml, odt, ods, zip, docx, xlsx, csv, dat, ssp, rar, p7s, svg, jpeg, tsd, html, tsr";
                        break;
                    case TipoFile.NonSpecificato:
                        if (!checkTipoGenerico(ucFileUpload.PostedFile)) tipo_file_ammesso = "pdf, doc, xls, rtf, txt, p7m, tif, msg, jpg, htm, gif, ai, xml, bmp, eml, odt, ods, zip, docx, xlsx, csv, dat, ssp, rar, p7s, svg, jpeg, tsd, html, tsr";
                        break;
                    case TipoFile.Immagine:
                        if (!ucFileUpload.PostedFile.ContentType.Contains("image")) tipo_file_ammesso = "immagine";
                        break;
                    case TipoFile.Documento: // solo pdf
                        if (ucFileUpload.PostedFile.ContentType != "application/pdf") tipo_file_ammesso = "pdf";
                        break;
                    case TipoFile.WordFile:
                        if (!ucFileUpload.PostedFile.ContentType.FindValueIn("application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
                            tipo_file_ammesso = "word o rtf";
                        break;
                    case TipoFile.ExcelsFile:
                        if (!ucFileUpload.PostedFile.ContentType.FindValueIn("application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                            tipo_file_ammesso = "excels o csv";
                        break;
                    case TipoFile.DocumentoFE:
                        if (!ucFileUpload.PostedFile.ContentType.FindValueIn("application/pdf", "text/xml", "application/pkcs7-mime")) tipo_file_ammesso = "pdf, xml, p7m";
                        break;
                    case TipoFile.DocumentoFirmato: //pdf e p7m
                        if (!ucFileUpload.PostedFile.ContentType.FindValueIn("application/pdf", "application/pkcs7-mime")) tipo_file_ammesso = "pdf, p7m";
                        break;
                }
                if (!string.IsNullOrEmpty(tipo_file_ammesso))
                    throw new Exception("Il file specificato non è valido, sono ammessi solo i formati " + tipo_file_ammesso + ".");

                string dimensione_ammessa = null; int dimensione_file = ucFileUpload.PostedFile.ContentLength;
                switch (dimensione_massima)
                {
                    case DimensioneFile._500kb: if (dimensione_file > 500000) dimensione_ammessa = "500kb"; break;
                    case DimensioneFile._1Mb: if (dimensione_file > 1000000) dimensione_ammessa = "1Mb"; break;
                    case DimensioneFile._2Mb: if (dimensione_file > 2000000) dimensione_ammessa = "2Mb"; break;
                }
                if (!string.IsNullOrEmpty(dimensione_ammessa))
                    throw new Exception("Sono ammessi solo file con dimensioni pari o inferiori a " + dimensione_ammessa + ".");
                else
                {
                    if (dimensione_file > Convert.ToInt32( System.Configuration.ConfigurationManager.AppSettings["dimensione_max_upload_file"]))
                        throw new Exception("Sono ammessi solo file con dimensioni pari o inferiori a "+ System.Configuration.ConfigurationManager.AppSettings["dimensione_max_upload_file"] + " Byte.");
                }
                    

                // leggo lo stream
                byte[] contenuto_file = new byte[ucFileUpload.PostedFile.ContentLength];
                System.IO.Stream str = ucFileUpload.PostedFile.InputStream;
                str.Read(contenuto_file, 0, ucFileUpload.PostedFile.ContentLength);
                str.Dispose();
                // genero l'hash
                HashAlgorithm alg = HashAlgorithm.Create("SHA256");
                byte[] fileHashValue = alg.ComputeHash(contenuto_file);
                string hash_code = BinaryToHex(fileHashValue);
                SiarBLL.ArchivioFileCollectionProvider file_provider = new SiarBLL.ArchivioFileCollectionProvider();
                SiarLibrary.ArchivioFile af = file_provider.GetSenzaContenutoByHashCode(hash_code);
                if (af == null) // se non è già presente su db lo creo nuovo
                {
                    var nomeFile = ucFileUpload.FileName.ToCleanJsString();
                    var nomeFileCompleto = ucFileUpload.PostedFile.FileName.ToCleanJsString();

                    af = new SiarLibrary.ArchivioFile();
                    af.Tipo = ucFileUpload.PostedFile.ContentType;
                    af.NomeFile = ReplaceNonPrintableCharacters(nomeFile, null); //rimuovo anche i caratteri non stampabili 
                    af.NomeCompleto = ReplaceNonPrintableCharacters(nomeFileCompleto, null); 
                    af.Contenuto = contenuto_file;
                    af.Dimensione = contenuto_file.Length;
                    af.HashCode = hash_code;
                    new SiarBLL.ArchivioFileCollectionProvider().Save(af);
                }

                string jsonFattura = string.Empty;

                //Gestione fattura elettronica
                if (tipo_file == TipoFile.DocumentoFE)
                {
                    var xdoc = new XDocument();
                    bool f_check = false;
                    switch (ucFileUpload.PostedFile.ContentType)
                    {
                        case "application/pkcs7-mime":
                            CryptoUtility crypto = new CryptoUtility();
                            var result = crypto.ReadSignedDocument(contenuto_file, false);
                            xdoc = CheckValidXml(result.SignedContent);
                            f_check = true;
                            if (xdoc == null)
                            {
                                f_check = false;
                                throw new Exception("Il file p7m non contiene un tracciato xml valido");
                            }
                            break;
                        case "text/xml":
                            f_check = true;
                            using (MemoryStream stream = new MemoryStream(contenuto_file))
                            {
                                xdoc = XDocument.Load(stream);
                            }
                            break;
                    }

                    if (f_check)
                    {
                        if (CheckFatturaElettronica(xdoc))
                        {
                            jsonFattura = GetDatiFatturaElettronica(xdoc);
                        }
                        else if (tipo_file == TipoFile.DocumentoFE) //da sostituire con DocumentoFE nel dettaglio spesa
                        {
                            throw new Exception("Il file xml non è una fattura elettronica valida");
                        }
                    }                   
                }

                script_finale = "SNCUFPDone(" + af.Id + ",'" + af.NomeFile + "','" + id_SNCUFActiveElement + "'," + jsonFattura +");";
            }
            catch (Exception ex) { script_finale = "alert('Attenzione! " + ex.Message.ToCleanJsString() + "');"; txtPercorsoFile.Text = ""; }
            finally { ClientScript.RegisterClientScriptBlock(this.GetType(), "scptSNCUPControl", script_finale, true); }
        }

        private bool checkTipoGenerico(System.Web.HttpPostedFile file)
        {
            return ( _dict.ContainsKey(System.IO.Path.GetExtension(file.FileName).Replace(".", "").ToLower()));
        }

        private string BinaryToHex(byte[] data)
        {
            char[] hex = new char[data.Length * 2];

            for (int iter = 0; iter < data.Length; iter++)
            {
                byte hexChar = ((byte)(data[iter] >> 4));
                hex[iter * 2] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
                hexChar = ((byte)(data[iter] & 0xF));
                hex[(iter * 2) + 1] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
            }
            return new string(hex);
        }


        private string GetDatiFatturaElettronica(XDocument xdoc)
        {
            string result = "[ ";
            string apice = "'";

            foreach(XElement doc in xdoc.Descendants().Where(p => p.Name.LocalName == "FatturaElettronicaBody"))
            {
                XElement datiFattura = doc.Descendants().Where(p => p.Name.LocalName == "DatiGeneraliDocumento").FirstOrDefault();
                XElement cedentePrestatore = xdoc.Descendants().Where(p => p.Name.LocalName == "CedentePrestatore").FirstOrDefault();
                XElement datiRiepilogo = doc.Descendants().Where(p => p.Name.LocalName == "DatiRiepilogo").FirstOrDefault();

                string partitaIva = cedentePrestatore.DescendantsAndSelf("IdCodice").First().Value;
                string ragioneSociale = cedentePrestatore.DescendantsAndSelf("Denominazione").First().Value;

                string numeroFattura = datiFattura.DescendantsAndSelf("Numero").First().Value;
                string dataFattura = DateTime.Parse(datiFattura.DescendantsAndSelf("Data").First().Value).ToString("dd/MM/yyyy");
                string causaleFattura = datiFattura.Elements("Causale").Count() == 0 ? string.Empty : datiFattura.Elements("Causale").FirstOrDefault().Value;

                result += "{";
                result += "'partitaIva': " + apice + partitaIva + apice + ", ";
                result += "'ragioneSociale': " + apice + ragioneSociale.Replace("'", @"\'") + apice + ", ";
                result += "'numeroFattura': " + apice + numeroFattura + apice + ", ";
                result += "'dataFattura': " + apice + dataFattura + apice + ", ";
                result += "'causaleFattura': " + apice + causaleFattura.Replace("'", @"\'") + apice + ", ";
                result += "'datiRiepilogo': [";
                foreach (XElement item in doc.Descendants().Where(p => p.Name.LocalName == "DatiRiepilogo"))
                {
                    result += "{";
                    result += "'importoImponibile': " + item.Element("ImponibileImporto").Value + ", ";
                    result += "'importoImposta': " + item.Element("Imposta").Value + ", ";
                    result += "'aliquotaIva': " + item.Element("AliquotaIVA").Value + "},";
                }
                result = result.Remove(result.LastIndexOf(","), 1);
                result += "]},";
            }
            result = result.Remove(result.LastIndexOf(","), 1);
            result += "]";


            return result;
        }

        private bool CheckFatturaElettronica(XDocument xdoc)
        {
            bool result = false;
            XElement datiFattura = xdoc.Elements().Where(p => p.Name.LocalName == "FatturaElettronica").FirstOrDefault();
            if(datiFattura != null)
            {
                result = true;
            }

            return result;
        }

        private XDocument CheckValidXml(byte[] doc)
        {
            try
            {
                var xdoc = new XDocument();
                using (MemoryStream stream = new MemoryStream(doc))
                {
                    xdoc = XDocument.Load(stream);
                }

                return xdoc;
            }
            catch
            {               
               return null;
            }
            
        }

        private string ReplaceNonPrintableCharacters(string s, char? replaceWith)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int b = (int)c;
                if (b < 32 || b > 127)
                    result.Append(replaceWith);
                else
                    result.Append(c);
            }
            return result.ToString();
        }
    }
}
