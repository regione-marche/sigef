using System;
using System.Collections.Generic;
using System.Linq;

namespace FirmaRemotaManager
{
    internal partial class CallWS
    {
        private svcCalamaioRemoteSign.SignServicesPortTypeClient _client { get; set; }

        public CallWS() {
            _client = new svcCalamaioRemoteSign.SignServicesPortTypeClient();
        }

        internal FirmaRemotaResponse ArubaSingleRemoteSign(FirmaRemotaRequest Request)
        {
            var response = new FirmaRemotaResponse();

            try
            {
                var resp = _client.hsmSignature(Request.Configuration, Request.CfFirmatario, Request.Pin, Request.Otp, Request.Domain, Request.File);

                response.IdSignedFile = Request.IdFile;
                response.NomeFile = Request.NomeFile;
                response.SignedFile = resp.signedDocument;
                response.result = resp.success;
                response.ErrorCode = resp.errorCode;
                response.ErrorDescription = resp.errorDescription;

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal List<FirmaRemotaResponse> ArubaMultipleRemoteSign(List<FirmaRemotaRequest> Request)
        {
            var response = new List<FirmaRemotaResponse>();

            try
            {
                var resp = _client.hsmMultiSignature(Request.FirstOrDefault().Configuration, Request.FirstOrDefault().CfFirmatario, Request.FirstOrDefault().Pin, Request.FirstOrDefault().Otp, Request.FirstOrDefault().Domain, Request.Select(p => p.File).ToArray());

                for (int i = 0; i < resp.signedDocuments.Count(); i++)
                {
                    var signedDocument = resp.signedDocuments[i];
                    var req = Request[i];

                    var r = new FirmaRemotaResponse();
                    r.IdSignedFile = req.IdFile;
                    r.NomeFile = req.NomeFile;
                    r.SignedFile = signedDocument;
                    r.result = resp.success;
                    r.ErrorCode = resp.errorCode;
                    r.ErrorDescription = resp.errorDescription;
                    response.Add(r);
                }

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
