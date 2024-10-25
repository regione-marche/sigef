using System;

namespace web.Private.Impresa
{
    public partial class ImpresaDescrizione : SiarLibrary.Web.ImpresaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_business_plan";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // carico tutti i dati dell'impresa
            Azienda = ImpresaProvider.GetById(Azienda.IdImpresa);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Azienda.Descrizione = txtDescrizioneLunga.Text;
                Azienda.Presentazione = txtNoteLunga.Text;
                ImpresaProvider.Save(Azienda);
                Azienda = ImpresaProvider.GetById(Azienda.IdImpresa);
                ShowMessage("Modifiche salvate correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtNoteLunga.Text = Azienda.Presentazione ?? "Forma e composizione societaria:\n\n\nOggetto sociale:\n\n\nBreve storia:\n\n\n"
                + "Struttura organizzativa:\n\n\nCampo di attività:\n\n\nRisultati conseguiti e prospettive di sviluppo:\n\n\n"
                + "Vertice aziendale con l’indicazione dei responsabili della gestione, esperienza dei titolari e/o soci):\n\n\n";
            txtDescrizioneLunga.Text = Azienda.Descrizione ?? "Ubicazione (comune, provincia):\n\n\nOrdinamento produttivo:\n\n\n"
                + "Caratteristiche fisiche prevalenti (giacitura, esposizione, altimetria):\n\n\n"
                + "Fonti di approvvigionamento irriguo e sistema irriguo utilizzato:\n\n\nAltri impianti fissi:\n\n\n";
            base.OnPreRender(e);
        }
    }
}