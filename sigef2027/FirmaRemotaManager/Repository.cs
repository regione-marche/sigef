using System;
using System.Configuration;

namespace FirmaRemotaManager
{
    public partial class FirmaRemotaRequest
    {
        public FirmaRemotaRequest()
        {
            Domain = ConfigurationManager.AppSettings["CalamaioRS.DefaultDomain"].ToString();
            Configuration = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["CalamaioRS.DefaultConfig"].ToString()].ToString();
        }

        public string CfFirmatario { get; set; }
        public string Configuration { get; set; }
        public string Pin { get; set; }
        public string Otp { get; set; }
        public string Domain { get; set; }
        public int? IdFile { get; set; }
        public string NomeFile { get; set; }
        public byte[] File { get; set; }
    }

    public partial class FirmaRemotaResponse
    {
        public int? IdSignedFile { get; set; }
        public string NomeFile { get; set; }
        public byte[] SignedFile { get; set; }
        public bool result { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }

    public partial class LogInfo
    {
        public int? IdLogFirma { get; set; }
        public string TipoDocumento { get; set; }
        public string ParametriDocumento { get; set; }
        public string Operatore { get; set; }
        public string TipoFirma { get; set; }
        public string DominioFirma { get; set; }
        public string Esito { get; set; }
        public string DettaglioEsito { get; set; }
        public DateTime DataFirma { get; set; }
        public bool DownloadDocumentoCertificato { get; set; } = false;
    }
}
