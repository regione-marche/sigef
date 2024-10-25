using System;
using System.Collections.Generic;

namespace FirmaRemotaManager
{
    public partial class FirmaRemotaOperazioni
    {
        public FirmaRemotaResponse ArubaSingleRemoteSign(FirmaRemotaRequest Request)
        {
            var response = new FirmaRemotaResponse();
            try
            {
                var ws = new CallWS();
                response = ws.ArubaSingleRemoteSign(Request);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<FirmaRemotaResponse> ArubaMultiRemoteSign(List<FirmaRemotaRequest> Request)
        {
            var response = new List<FirmaRemotaResponse>();
  
            try
            {
                foreach(FirmaRemotaRequest req in Request)
                {
                    var resp = this.ArubaSingleRemoteSign(req);
                    response.Add(resp);
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<FirmaRemotaResponse> ArubaMultiRemoteSignWs(List<FirmaRemotaRequest> Request)
        {
            var response = new List<FirmaRemotaResponse>();
            try
            {
                var ws = new CallWS();
                response = ws.ArubaMultipleRemoteSign(Request);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
