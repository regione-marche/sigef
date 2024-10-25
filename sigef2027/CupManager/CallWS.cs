using System;

namespace CupManager
{
    internal partial class CallWS
    {
        public byte[] Response { get; set; }
        public byte[] Request { get; set; }
        public svcCUP.esitoElaborazioneCUP_Type EsitoWS { get; set; }


        public void CallRichiestaCUP()
        {
            byte[] responseWS;
            svcCUP.esitoElaborazioneCUP_Type esito;

            try
            {
                svcCUP.ElaborazioniCUPClient client = new CupManager.svcCUP.ElaborazioniCUPClient("cup_bind_RichiestaGenerazioneCUP");
                client.RichiestaRispostaSincrona_RichiestaGenerazioneCUP("Richiesta CUP", Request, out esito, out responseWS);

                EsitoWS = esito;
                Response = responseWS;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
