using System;
using System.IO;
using System.Linq;
using System.Net;

namespace FirmaRemotaManager
{
    /// <summary>
    /// Summary description for UTAruba
    /// </summary>
    public class FirmaEsternaAruba
    {
        //Endpoint test presi da OpenAct
        svcArubaSignTest.ArubaSignServiceClient wsCloudDemoTest;
        svcArubaVolTest.VerificationServiceClient volTest;

        //Endpoint produzione dati - Sigillo Regione Marche
        svcArubaSignProduzione.ArubaSignServiceClient wsCloudProd;
        svcArubaVolProduzione.VerificationServiceClient volProd;

        public FirmaEsternaAruba()
        {
            wsCloudDemoTest = new svcArubaSignTest.ArubaSignServiceClient("ArubaSignServicePort");
            volTest = new svcArubaVolTest.VerificationServiceClient();

            wsCloudProd = new svcArubaSignProduzione.ArubaSignServiceClient("ArubaSignServicePort1");
            volProd = new svcArubaVolProduzione.VerificationServiceClient();

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // Forza TLS 1.2
        }

        public int VerifyPdfTest(byte[] file, string nomeFile)
        {
            //var barr = System.IO.File.ReadAllBytes(@"c:\VSSProjects\Paleo2\TestProviders\1(firmato).pdf");

            var resp = volTest.Verification(new svcArubaVolTest.fileInfo()
            {
                autoDetectType = true,
                fileName = nomeFile,
                fileExtension = "pdf"
            },
            file, DateTime.Today);

            //System.IO.File.WriteAllBytes(@"C:\VSSProjects\Paleo2\TestProviders\report.pdf",resp.pdfReport);

            //if (resp.originalFile!=null)
            //    System.IO.File.WriteAllBytes(@"C:\VSSProjects\Paleo2\TestProviders\original.pdf", resp.originalFile);

            foreach (var sign in resp.signers)
            {
                //var vs = sign.validationStatus;
                var v = sign.sigValidation;
                var vm = sign.sigValidationMessage;
                var time = sign.signatureInfo.sigTime;
                var signer = sign.certificate.certName;
            }

            return resp.signers.Count();
        }

        public int VerifyP7MTest(byte[] file, string nomeFile)
        {
            //var barr = System.IO.File.ReadAllBytes(@"c:\VSSProjects\Paleo2\TestProviders\Bur.Docx.p7m");

            var resp = volTest.Verification(new svcArubaVolTest.fileInfo()
            {
                autoDetectType = true,
                fileName = nomeFile,
                fileExtension = "p7m"
            },
            file, DateTime.Today);

            //System.IO.File.WriteAllBytes(@"C:\VSSProjects\Paleo2\TestProviders\report.pdf",resp.pdfReport);

            //if (resp.originalFile != null)
            //    System.IO.File.WriteAllBytes(@"C:\VSSProjects\Paleo2\TestProviders\original.docx", resp.originalFile);

            foreach (var sign in resp.signers)
            {
                //var vs = sign.validationStatus;
                var v = sign.sigValidation;
                var vm = sign.sigValidationMessage;
                var time = sign.signatureInfo.sigTime;
                var signer = sign.certificate.certName;
            }

            return resp.signers.Count();
        }

        public string VerificaFileFirmatoUtentePostFirmaAutomaticaTest(byte[] file, string nomeFile)
        {
            var resp = volTest.Verification(new svcArubaVolTest.fileInfo()
            {
                autoDetectType = true,
                fileName = nomeFile,
                fileExtension = Path.GetExtension(nomeFile)
            },
            file, DateTime.Today);

            if (resp == null)
                return "Errore nella verifica del file, si prega di riprovare. Se il problema persiste contattare l'helpdesk.";

            if (resp.signers == null || resp.signers.Count() == 0)
                return "Il file non risulta firmato";

            if (resp.signers.Count() == 1)
            {
                var sign = resp.signers[0];

                if (sign.certificate.certName == "PROVA TEST")
                    return "Il file non risulta firmato dall'utente";

                return "Il file è stato firmato dall'utente ma non ha il certificato del server";
            }

            if (resp.signers.Count() > 1)
            {
                bool firma_server = false;
                bool firma_utente_valida = true;
                
                foreach (var sign in resp.signers)
                {
                    if (sign.certificate.certName == "PROVA TEST")
                        firma_server = true;
                    else if (sign.certificate.certValid == false)
                        firma_utente_valida = false;
                }

                if (!firma_server && !firma_utente_valida)
                    return "Il file non ha il certificato del server ed è stata trovata almeno una firma con certificato non valido";

                if (firma_server && !firma_utente_valida)
                    return "Il file ha il certificato del server ma la firma dall'utente ha il certificato non valido";

                if (!firma_server && firma_utente_valida)
                    return "Il file è stato firmato correttamente dall'utente ma non ha il certificato del server";

                return "OK";
            }

            return "Errore non gestito";
        }

        public byte[] FirmaAutomaticaTest(byte[] file)
        {
            var resp = wsCloudDemoTest.pdfsignatureV2(new svcArubaSignTest.signRequestV2
            {
                binaryinput = file,
                identity = new svcArubaSignTest.auth()
                {
                    otpPwd = "dsign",
                    typeOtpAuth = "demoprod",
                    typeHSM = "COSIGN",
                    delegated_domain = "demoprod",
                    delegated_user = "delegato",
                    delegated_password = "password11",
                    user = "titolare_aut"
                },
                requiredmark = false,
                transport = svcArubaSignTest.typeTransport.BYNARYNET
            }, null, null, svcArubaSignTest.pdfProfile.PADESBES, null, null);

            return resp.binaryoutput; 
        }

        public string VerificaFileFirmatoUtentePostFirmaAutomaticaProd(byte[] file, string nomeFile)
        {
            var resp = volProd.Verification(new svcArubaVolProduzione.fileInfo()
            {
                autoDetectType = true,
                fileName = nomeFile,
                fileExtension = Path.GetExtension(nomeFile)
            },
            file, DateTime.Today);

            if (resp == null)
                return "Errore nella verifica del file, si prega di riprovare. Se il problema persiste contattare l'helpdesk.";
            
            if (resp.signers == null || resp.signers.Count() == 0)
                return "Il file non risulta firmato";

            if (resp.signers.Count() == 1)
            {
                var sign = resp.signers[0];

                if (sign.certificate.certName == "Regione Marche Giunta Regionale")
                    return "Il file non risulta firmato dall'utente";

                return "Il file è stato firmato dall'utente ma non ha il certificato del server";
            }

            if (resp.signers.Count() > 1)
            {
                bool firma_server = false;
                bool firma_utente_valida = true;

                foreach (var sign in resp.signers)
                {
                    if (sign.certificate.certName == "Regione Marche Giunta Regionale")
                        firma_server = true;
                    else if (sign.certificate.certValid == false)
                        firma_utente_valida = false;
                }

                if (!firma_server && !firma_utente_valida)
                    return "Il file non ha il certificato del server ed è stata trovata almeno una firma con certificato non valido";

                if (firma_server && !firma_utente_valida)
                    return "Il file ha il certificato del server ma la firma dell'utente ha il certificato non valido";

                if (!firma_server && firma_utente_valida)
                    return "Il file è stato firmato correttamente dall'utente ma non ha il certificato del server";

                return "OK";
            }

            return "Errore non gestito";
        }

        public byte[] FirmaAutomaticaProd(byte[] file)
        {
            var resp = wsCloudProd.pdfsignatureV2(
                new svcArubaSignProduzione.signRequestV2
                {
                    binaryinput = file,
                    identity = new svcArubaSignProduzione.auth()
                    {
                        otpPwd = "dsign",
                        typeOtpAuth = "faRegMarche",
                        typeHSM = "COSIGN",
                        delegated_domain = "faRegMarche",
                        delegated_user = "AppSIGEF",
                        delegated_password = "Sigef_061123",
                        user = "regionemarchegiuntaregionale"
                    },
                    requiredmark = false,
                    transport = svcArubaSignProduzione.typeTransport.BYNARYNET
                }, 
                null,
                svcArubaSignProduzione.pdfProfile.PADESBES, 
                null, 
                new svcArubaSignProduzione.dictionarySignedAttributes()
                );

            return resp.binaryoutput;
        }
    }
}
