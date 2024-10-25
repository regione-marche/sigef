using System;

namespace web.Private.PDomanda
{
    public partial class ChecklistPresentazione : SiarLibrary.Web.ProgettoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucChecklist.Progetto = Progetto;
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                string esito = ucChecklist.VerificaChecklist();
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                switch (esito)
                {
                    case "SI":
                        ShowMessage("Checklist verificata correttamente. La domanda soddisfa tutti i requisiti necessari per essere presentata.");
                        break;
                    case "NO": throw new Exception("La domanda non soddisfa tutti i requisiti obbligatori imposti dalla checklist.");
                    default: throw new Exception(esito);
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}