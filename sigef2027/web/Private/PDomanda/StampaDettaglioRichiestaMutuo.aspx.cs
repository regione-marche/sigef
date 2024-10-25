using System;

namespace web.Private.PDomanda
{
    public partial class StampaDettaglioRichiestaMutuo : SiarLibrary.Web.ProgettoPage
     {
         protected void Page_Load(object sender, EventArgs e)
         {
             try
             {
                 SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
                 byte[] quadro = rt.getReportByName("rptQuadroRichiestaMutuo", new string[] { "ID_Domanda=" + Progetto.IdProgetto });
                 if (quadro == null && quadro.Length == 0) throw new Exception("Il documento è inesistente.");
                 Session["doc"] = quadro;
                 rt.Dispose();

             }
             catch (Exception ex) { Redirect("BusinessPlan.aspx?action=quadro_mutuo&err=" + ex.Message); }
         }
    }
}
