using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace web.CONTROLS
{
    public partial class FirmaDocumentoCovid : System.Web.UI.UserControl
    {

        //public string capability { get; set; }

        protected string dataToSign { get; set; }

        //public EventHandler DocumentoFirmatoEvent { get; set; }
        public bool DoppiaFirma { get; set; }
        public string FileFirmato { get; set; }
        public bool FirmaObbligatoria { get; set; }
        public int IdFileFirmato { get; set; }

        public string TipoDocumento { get; set; }
        //public string Titolo { get; set; }
        public string Titolo
        {
            get { return lblTitolo.Text; }
            set { lblTitolo.Text = value; }
        }
        public bool Preview { get; set; }

        private EventHandler _documentoFirmatoEvent;
        public EventHandler DocumentoFirmatoEvent
        {
            get { return this._documentoFirmatoEvent; }
            set { _documentoFirmatoEvent = value; }
        }

        private DatiFirmaJson _datiFirma;
        public class DatiFirmaJson
        {
            public bool DoppiaFirma = false, FirmaObbligatoria = true;
            public string ContenutoFile, CfFirmatario;
            public int StepFirma = 0; // 0: non firmato, 1: prima firma eseguita; 2: seconda firma eseguita/firme completate                
        }


        System.Web.Script.Serialization.JavaScriptSerializer jsser = new System.Web.Script.Serialization.JavaScriptSerializer() { MaxJsonLength = 9999999 };

        protected void Page_Load(object sender, EventArgs e)
        {
            btnPostFirmaDocumento.Click += new EventHandler(_documentoFirmatoEvent);
            //jsser.MaxJsonLength = 9999999; // massima lunghezza del file
            //if (!string.IsNullOrEmpty(hdnJsonDatiFirma.Value))
            //    try { _datiFirma = jsser.Deserialize<DatiFirmaJson>(hdnJsonDatiFirma.Value); }
            //    catch { hdnJsonDatiFirma.Value = ""; }
            //if (_datiFirma != null)
            //{
            //    if (_datiFirma.StepFirma < 2) completePageRender();
            //    else
            //    {
            //        hdnJsonDatiFirma.Value = ""; // pulisco l'hidden
            //        hdnSignedData.Value = "";
            //        hdnDataToSign.Value = "";
            //        hdnNomeFile.Value = "";
            //        btnPostFirmaDocumento.Click += new EventHandler(_documentoFirmatoEvent);
            //    }
            //}
        }


        public void loadDocumentoSenzaFirma(string _cf_firmatario, params string[] _parametri)
        {
            _datiFirma = new DatiFirmaJson();
            byte[] doc = null;
            if (IdFileFirmato > 0)
            {
                // file firmato parzialmente, lo recupero da archivio file
                SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(IdFileFirmato);
                if (f != null) doc = f.Contenuto;
            }
            else doc = getDocumentoFromServer(_parametri);
            if (doc == null || doc.Length == 0) throw new Exception("Non è stato possibile generare il documento richiesto.");
            _datiFirma.ContenutoFile = Convert.ToBase64String(doc);
        }

        public void loadDocumento(string _cf_firmatario, params string[] _parametri)
        {
            _datiFirma = new DatiFirmaJson();
            _datiFirma.DoppiaFirma = DoppiaFirma;
            _datiFirma.FirmaObbligatoria = FirmaObbligatoria;
            _datiFirma.CfFirmatario = _cf_firmatario;
            //txtUsernameRS.Value = _cf_firmatario;

            byte[] doc = null;
            if (IdFileFirmato > 0)
            {
                // file firmato parzialmente, lo recupero da archivio file
                SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(IdFileFirmato);
                if (f != null) doc = f.Contenuto;
                hdnNomeFile.Value = "IdFileFirmato_" + IdFileFirmato.ToString();
            }
            else doc = getDocumentoFromServer(_parametri);
            if (doc == null || doc.Length == 0) throw new Exception("Non è stato possibile generare il documento richiesto.");
            _datiFirma.ContenutoFile = Convert.ToBase64String(doc);
            completePageRender();
        }

        private void completePageRender()
        {
            //metto in sessione il report per riprenderlo dalla pagina di visualizzazione
            Session.Add("doc", Convert.FromBase64String(_datiFirma.ContenutoFile));
            //dataToSign = CalamaioUtility.GetDataToSign(Convert.FromBase64String(_datiFirma.ContenutoFile), _datiFirma.CfFirmatario, hdnNomeFile.Value);
            //byte[] byt = System.Text.Encoding.UTF8.GetBytes(dataToSign);
            //hdnDataToSign.Value = Convert.ToBase64String(byt);
            //hdnJsonDatiFirma.Value = jsser.Serialize(_datiFirma);
            ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("initFirmaDocumentoControl();");
        }

        public byte[] getDocumentoFromServer(params string[] parametri)
        {
            SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
            byte[] report;
            string[] tmp_parametri = null;
            string nome_file = "";

            switch (TipoDocumento)
            {
                #region definisco il tipo
                case "PDOMANDA":
                    tmp_parametri = new string[] { "ID_Domanda=" + parametri[0] };
                    report = rt.getReportByName("rptModelloDomanda" + parametri[1], tmp_parametri);
                    break;
                case "CHECKLIST":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0], "fase=" + parametri[1] };
                    report = rt.getReportByName("rptChecklist", tmp_parametri);
                    break;
                case "NON_RICEVIBILITA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptNonRicevibilita", tmp_parametri);
                    break;
                case "NON_AMMISSIBILITA_PROV":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneNonAmmissibilita", tmp_parametri);
                    break;
                case "NON_AMMISSIBILITA_DEF":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptProvvedimentoNonAmmissibilita", tmp_parametri);
                    break;
                case "RAPPORTO_ISTRUTTORIO":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptRapportoIstruttorio", tmp_parametri);
                    break;
                case "ESITO_ISTRUTTORIO":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptEsitoIstruttorio", tmp_parametri);
                    break;
                case "COMUNICAZIONE_ESITO_ISTRUTTORIO":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneEsitoIstruttorio", tmp_parametri);
                    break;
                case "CKL_REVISIONE":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistRevisione", tmp_parametri);
                    break;
                case "GRADUATORIA":
                    tmp_parametri = new string[] { "IdBando=" + parametri[0] };
                    report = rt.getReportByName("rptGraduatoria", tmp_parametri);
                    break;
                case "COMUNICAZIONE_FINANZIABILITA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneFinanziabilita", tmp_parametri);
                    break;
                case "COMUNICAZIONE_NON_FINANZIABILITA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneNonFinanziabilita", tmp_parametri);
                    break;
                case "RICHIESTA_CERTIFICAZIONE":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaCertificazione", tmp_parametri);
                    break;
                case "RICHIESTA_DOCUMENTAZIONE_INTEGRATIVA":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaDocumentazioneIntegrativa", tmp_parametri);
                    break;

                //case "COMUNICAZIONE_AVVIO_LAVORI":
                //    report = rt.getReportByName("rptComunicazioneAvvioLavori", new string[] { "IdProgetto=" + Request.QueryString["iddom"] });
                //    break;
                case "DOMPAGAMENTO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0] };
                    var dom_pag = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(int.Parse(parametri[0]));
                    var prog = new SiarBLL.ProgettoCollectionProvider().GetById(dom_pag.IdProgetto);

                    var utAppalto = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(prog.IdBando);
                    if (utAppalto != null && utAppalto == "Strumenti finanziari")
                        report = rt.getReportByName("rptDomandaPagamentoFem", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    else
                        report = rt.getReportByName("rptDomandaPagamento", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    break;
                case "VARIANTE":
                    tmp_parametri = new string[] { "IdVariante=" + parametri[0] };
                    report = rt.getReportByName("rptVariante", tmp_parametri);
                    break;
                case "CKL_PAGAMENTO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0] };
                    var dom_pag_checklist = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(int.Parse(parametri[0]));
                    var prog_checklist = new SiarBLL.ProgettoCollectionProvider().GetById(dom_pag_checklist.IdProgetto);

                    var utAppalto_checklist = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(prog_checklist.IdBando);
                    if (utAppalto_checklist != null && utAppalto_checklist == "Strumenti finanziari")
                        report = rt.getReportByName("rptChecklistPagamentoFem", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    else
                        report = rt.getReportByName("rptChecklistPagamento", tmp_parametri);
                    break;
                case "CKL_REVISIONE_PAGAMENTO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistRevisionePagamento", tmp_parametri);
                    break;
                case "CKL_VARIANTE":
                    tmp_parametri = new string[] { "IdVariante=" + parametri[0] };
                    report = rt.getReportByName("rptIstruttoriaVariante", tmp_parametri);
                    break;
                case "CKL_VARIANTE_AR":
                    tmp_parametri = new string[] { "IdVariante=" + parametri[0] };
                    report = rt.getReportByName("rptAcquisizioneEsitoRicorso", tmp_parametri);
                    break;
                case "ELENCO_PAGAMENTO_PROVINCIALE":
                    tmp_parametri = new string[] { "IdElencoPagamento=" + parametri[0] };
                    report = rt.getReportByName("rptElencoPagamentoProvinciale", tmp_parametri);
                    break;
                case "ELENCO_PAGAMENTO_REGIONALE":
                    tmp_parametri = new string[] { "IdElencoPagamento=" + parametri[0] };
                    report = rt.getReportByName("rptElencoPagamentoRegionale", tmp_parametri);
                    break;
                case "COMUNICAZIONE_VARIANTE":
                    tmp_parametri = new string[] { "IdVariante=" + parametri[0], "IdProgetto=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazioneVariante", tmp_parametri);
                    break;
                case "MANIFESTAZIONE_DI_INTERESSE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptManifestazione", tmp_parametri);
                    break;
                case "CHECKLIST_RICEVIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistRicevibilitaManifestazione", tmp_parametri);
                    break;
                case "CHECKLIST_AMMISSIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistAmmissibilitaManifestazione", tmp_parametri);
                    break;
                case "NON_RICEVIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneNonRicevibilitaManifestazione", tmp_parametri);
                    break;
                case "NON_AMMISSIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneNonAmmissibilitaManifestazione", tmp_parametri);
                    break;
                case "AMMISSIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneAmmissibilitaManifestazione", tmp_parametri);
                    break;
                case "RAPPORTO_ISTRUTTORIO_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptRapportoIstruttorioManifestazione", tmp_parametri);
                    break;
                case "COMUNICAZIONE_PAGAMENTO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneDomandaPagamento", tmp_parametri);
                    break;
                case "VERBALE_VALUTAZIONE_DOMANDA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptVerbaleValutazioneDomanda", tmp_parametri);
                    break;
                case "VERBALE_VALUTAZIONE_VARIANTE":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0], "IdVariante=" + parametri[1] };
                    report = rt.getReportByName("rptVerbaleValutazioneVariante", tmp_parametri);
                    break;
                case "COMUNICAZIONE_RICHIESTA_INTEGRAZIONI_DOMANDA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0], "IdIntegrazioneDomandaDiPagamento=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazioneRichiestaIntegrazioniDomandaDiPagamento", tmp_parametri);
                    break;
                case "COMUNICAZIONE_RISPOSTA_INTEGRAZIONI_DOMANDA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0], "IdIntegrazioneDomandaDiPagamento=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazioneRispostaIntegrazioniDomandaDiPagamento", tmp_parametri);
                    break;
                case "CKL_CONTROLLI_LOCO":
                    tmp_parametri = new string[] { "IdTestata=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistControlliLoco", new string[] { "IdTestata=" + parametri[0] });
                    break;
                case "COMUNICAZIONE_GENERICA":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazionGenerica", new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1] });
                    break;
                case "COMUNICAZIONE_GENERICA_BENEFICIARIO":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1], "Autocertificazione=" + parametri[2] };
                    report = rt.getReportByName("rptComunicazionGenericaBeneficiario", new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1], "Autocertificazione=" + parametri[2] });
                    break;
                case "COMUNICAZIONE_MASSIVA_GENERICA":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0], "IdBando=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazioneMassivaGenerica", new string[] { "IdComunicazione=" + parametri[0], "IdBando=" + parametri[1] });
                    break;
                case "COMUNICAZIONE_CERTIFICAZIONE":
                    tmp_parametri = new string[] { "dataFine=" + parametri[0], "dataLotto=" + parametri[1], "codPsr=" + parametri[2], "idLotto=" + parametri[3] };
                    report = rt.getReportByName("rptComunicazioneCertificazione", tmp_parametri);
                    break;
                case "COMUNICAZIONE_CERTIFICAZIONE_NEW":
                    tmp_parametri = new string[] { "dataFine=" + parametri[0], "dataLotto=" + parametri[1], "codPsr=" + parametri[2], "idLotto=" + parametri[3] };
                    report = rt.getReportByName("rptComunicazioneCertificazioneNew", tmp_parametri);
                    break;
                case "RICHIESTA_PROF":
                    tmp_parametri = new string[] { "IdRichiesta=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaProfilazione", tmp_parametri);
                    break;
                case "RICHIESTA_CONS":
                    tmp_parametri = new string[] { "IdRichiesta=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaConsulente", tmp_parametri);
                    break;
                case "RICHIESTA_CONS_APPROVA_RIFIUTA":
                    tmp_parametri = new string[] { "IdRichiesta=" + parametri[0] };
                    report = rt.getReportByName("rptGestioneRichiestaConsulente", tmp_parametri);
                    break;
                case "COVID_DOMANDA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };

                    string _connectionString;
                    ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["DB_" + SiarLibrary.DbProvider.DbNames.SIGEF];
#if(DEBUG)                
                    _connectionString = cs.ConnectionString;
#else
                    try { _connectionString = System.Text.Encoding.UTF8.GetString(DecryptString("df_5OFI*xcI,", Convert.FromBase64String(cs.ConnectionString))); }
                    catch { _connectionString = cs.ConnectionString; }
#endif

                    //string db_nome = "";
                    //if (cs.ConnectionString.ToLower().Contains("produzione"))
                    //    db_nome = "SIGEF";
                    //else if (cs.ConnectionString.ToLower().Contains("test"))
                    //    db_nome = "Test";
                    //else if (cs.ConnectionString.ToLower().Contains("sviluppo"))
                    //    db_nome = "Sviluppo";

                    var csb = new SqlConnectionStringBuilder(_connectionString);
                    string db_nome_1 = csb.InitialCatalog;
                    switch (db_nome_1.ToLower())
                    {
                        case "sigefproduzione":
                            db_nome_1 = "SIGEF";
                            break;
                        case "sigeftest":
                            db_nome_1 = "Test";
                            break;
                        case "sigefsviluppo":
                            db_nome_1 = "Sviluppo";
                            break;
                    }

                    if (db_nome_1 == "SIGEF" && Convert.ToInt32( parametri[1]) < 460 )
                        report = rt.getReportByName("rptCovidDomanda", tmp_parametri);
                    else
                        report = rt.getReportByName("rptCovidDomanda_"+db_nome_1+"_" + parametri[1], tmp_parametri);
                    break;
                default:
                    throw new Exception("Tipo di documento non specificato. Impossibile continuare.");
                    #endregion
            }
            rt.Dispose();
            nome_file = TipoDocumento + "-" + String.Join("-", tmp_parametri).Replace('=', '_');
            hdnNomeFile.Value = nome_file;
            return report;
        }

        public string GetFileFirmato()
        {
            string result = "";
            try
            {
                if (hdnJsonDatiFirma.Value != null && hdnJsonDatiFirma.Value != "")
                    result = jsser.Deserialize<DatiFirmaJson>(hdnJsonDatiFirma.Value).ContenutoFile;
            }
            catch { result = ""; }
            return result;
        }

        public static byte[] DecryptString(string PASSWORD, byte[] encryptedBytes)
        {
            try
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.IV = new byte[8];
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(PASSWORD, new byte[0]);
                des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
                //string prova=Encoding.ASCII.GetString(des.Key);
                MemoryStream ms = new MemoryStream(encryptedBytes.Length);
                CryptoStream decStream = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                decStream.FlushFinalBlock();
                byte[] plainBytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(plainBytes, 0, (int)ms.Length);
                decStream.Close();
                return plainBytes;
            }
            catch { throw new Exception("Password errata."); }
        }

        private void ShowError(string message)
        {
            ((SiarLibrary.Web.Page)Page).ShowError(message);
        }


        public string BinaryToHex(byte[] data)
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

    }
}