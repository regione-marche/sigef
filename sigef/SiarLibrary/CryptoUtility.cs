using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.X509.Store;
using iTextSharp.text.pdf;

namespace SiarLibrary
{
    public partial class CryptoUtility
    {
        public SignatureResult ReadSignedDocument(byte[] signedDocument, bool validateSignature = true, SignatureResult refResult = null)
        {
            var result = new SignatureResult();
            List<string> Names = new List<string>();
            if (refResult != null)
            {
                result = refResult;
                Names = refResult.Signers;
            }
                       
            try
            {
                //Branch di fine ricorsione
                try
                {
                    var d = new CmsSignedData(signedDocument);
                }
                catch
                {
                    result.SignedContent = signedDocument;
                    return result;
                }


                CmsSignedData signedFile = new CmsSignedData(signedDocument);

                var sis = signedFile.GetSignerInfos();

                if (validateSignature)
                {

                    IX509Store certStore = signedFile.GetCertificates("Collection");
                    ICollection certs = certStore.GetMatches(new X509CertStoreSelector());
                    SignerInformationStore signerStore = signedFile.GetSignerInfos();
                    ICollection signers = signerStore.GetSigners();

                    foreach (object tempCertification in certs)
                    {
                        Org.BouncyCastle.X509.X509Certificate certification = tempCertification as Org.BouncyCastle.X509.X509Certificate;
                        foreach (object tempSigner in signers)
                        {
                            SignerInformation signer = tempSigner as SignerInformation;
                            var cert2 = new X509Certificate2(certification.GetEncoded());
                            Names.Add(cert2.SubjectName.Name);
                            if (!signer.Verify(certification.GetPublicKey()))
                            {
                                throw new Exception();
                            }
                        }
                    }
                }

                
                result.Signers = Names;
                using (var stream = new MemoryStream())
                {
                    signedFile.SignedContent.Write(stream);
                    result.SignedContent = stream.ToArray();
                }
                return ReadSignedDocument(result.SignedContent, validateSignature, result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public byte[] RemoveSignedDocument(byte[] signedDocument)
        {
            byte[] fileSenzaFirme = new byte[signedDocument.Length];

            try
            {
                using (var reader = new PdfReader(signedDocument))
                {
                    var fields = reader.AcroFields;
                    var sInfos = fields.GetSignatureNames();

                    if (sInfos.Count > 0) // è firmato
                    {
                        Stream streamExtracted = fields.ExtractRevision(sInfos[0]);
                        using (var ms = new MemoryStream())
                        {
                            streamExtracted.CopyTo(ms);
                            fileSenzaFirme = ms.ToArray();
                        }
                    }
                    else
                        throw new Exception("Il file non contiene firme digitali");
                }

                return fileSenzaFirme;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class SignatureResult
    {
        public List<string> Signers { get; set; }
        public bool SignaturesValid { get; set; }
        public byte[] SignedContent { get; set; }
        public string SignedContentType { get; set; }
    }


}
