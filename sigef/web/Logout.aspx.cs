
using SiarBLL;
using SiarLibrary;
using SiarLibrary.Web;
using System.Configuration;

namespace web
{
    public partial class Logout : SiarLibrary.Web.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //if (ConfigurationManager.AppSettings["IngressiContingentatiAbilitati"] == "true")
            //{
            //    LogAccessiCollectionProvider accessi_provider = new LogAccessiCollectionProvider();

            //    if (Operatore != null && Operatore.Utente != null && Operatore.Utente.IdUtente != null)
            //    {
            //        var accessi_utente_coll = accessi_provider.GetLoginAppesiUtente(Operatore.Utente.IdUtente);

            //        if (accessi_utente_coll.Count > 0)
            //            accessi_provider.RiempiDataLogout(Operatore.Utente.IdUtente);
            //    }

            //}

            var impostazioni_provider = new ImpostazioniCollectionProvider();
            var istanzaSigef = ConfigurationManager.AppSettings["IstanzaSigef"];

            if (impostazioni_provider.GetIngressiContingentatiAbilitati(istanzaSigef))
            {
                LogAccessiCollectionProvider accessi_provider = new LogAccessiCollectionProvider();

                if (Operatore != null && Operatore.Utente != null && Operatore.Utente.IdUtente != null)
                {
                    var accessi_utente_coll = accessi_provider.GetLoginAppesiUtente(istanzaSigef, Operatore.Utente.IdUtente);

                    if (accessi_utente_coll.Count > 0)
                        accessi_provider.RiempiDataLogout(istanzaSigef, Operatore.Utente.IdUtente);
                }

            }

#if(!DEBUG)
            CohesionSSO cs = new CohesionSSO(Request, Response, Session);
            cs.LogoutFE();
#else 
            Session.Abandon();
            Session.Clear();
#endif
        }

        public Operatore Operatore
        {
            get { return (Operatore)(Session["OperatoreAlias"] ?? Session["Operatore"]); }
        }
    }
}
