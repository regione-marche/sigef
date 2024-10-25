using System;

namespace web.Private.PDomanda
{
    public partial class BusinessPlan : SiarLibrary.Web.ProgettoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "contratto_filiera")
                ShowError("Problemi nella stampa del contratto di filiera: " + Request.QueryString["err"]);
            if (Request.QueryString["action"] == "quadro_mutuo")
                ShowError("Problemi nella stampa del dettaglio della richiesta del mutuo: " + Request.QueryString["err"]);
            if (Request.QueryString["action"] == "fascicolo_non_presente")
                ShowError("L'azienda non è titolare di un fascicolo aziendale in corso di validità."); 
            AbilitaModifica = !Progetto.FlagDefinitivo;
            SiarLibrary.BusinessPlanCollection sezioni = new SiarBLL.BusinessPlanCollectionProvider().Find(Progetto.IdBando);
            dg.DataSource = sezioni;
            if (sezioni.Count == 0) dg.Titolo = "Non è richiesta la compilazione di nessuna sezione aggiuntiva in questa pagina.";
            else dg.Titolo = "Sezioni elencate: " + sezioni.Count.ToString();            
            dg.DataBind();

            if (Bando.Aggregazione)
            {
                btnPrev.Value = "<<< (6/8)";
                btnCurrent.Value = "(7/8)";
                btnGo.Value = "(8/8) >>>";
            }
        }
    }
}