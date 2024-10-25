using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class AssistenzaUtenti : SiarLibrary.Web.ImpresaPage
    {
        SiarBLL.AssistenzaUtentiCollectionProvider assistenzaProvider = new SiarBLL.AssistenzaUtentiCollectionProvider();

        SiarBLL.AssistenzaUtentiAllegatiCollectionProvider allegatiProvider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            cmbSelTipoAssistenza.DataBind();

            cmbProgetti.IdImpresa = Azienda.IdImpresa;
            cmbDomandePagamentoImpresa.IdImpresa = Azienda.IdImpresa;
            cmbProgetti.DataBind();
            cmbDomandePagamentoImpresa.DataBind();

            SiarLibrary.AssistenzaUtentiCollection assistenze = new SiarLibrary.AssistenzaUtentiCollection();

            if (Azienda.IdRapprlegaleUltimo == Operatore.Utente.IdUtente)          
                assistenze = assistenzaProvider.Find(null, null, Azienda.IdImpresa, null, null, null, null, null);
            else
                assistenze = assistenzaProvider.Find(null, null, Azienda.IdImpresa, Operatore.Utente.IdUtente, null, null, null, null);

            dgRichiesteAssistenza.DataSource = assistenze;
            dgRichiesteAssistenza.ItemDataBound += new DataGridItemEventHandler(dgRichiesteAssistenza_ItemDataBound);
            dgRichiesteAssistenza.DataBind();

            dgRichiesteAssistenza.Titolo = "Elementi trovati: " + assistenze.Count;

            SiarLibrary.PersonaFisica utente = new SiarBLL.PersonaFisicaCollectionProvider().GetById(Operatore.Utente.IdPersonaFisica);

            txtNome.Text = utente.Nome;
            txtCognome.Text = utente.Cognome;

            base.OnPreRender(e);
        }

        void dgRichiesteAssistenza_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.AssistenzaUtenti assistenza = (SiarLibrary.AssistenzaUtenti)dgi.DataItem;
                if (assistenza.IdAllegato == null)
                {                    
                    e.Item.Cells[6].Text = "";
                }
                if (assistenza.Gestita)
                    dgi.Cells[7].Text = dgi.Cells[7].Text.Replace("input ", "input checked ");
                else
                    dgi.Cells[7].Text = dgi.Cells[7].Text.Replace("checked", "");
                if (assistenza.Risolta)
                    dgi.Cells[8].Text = dgi.Cells[8].Text.Replace("input ", "input checked ");
                else
                    dgi.Cells[8].Text = dgi.Cells[8].Text.Replace("checked", "");
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_assistenza_utenti";
            base.OnPreInit(e);
        }


        public void clearForm() {
            cmbSelTipoAssistenza.SelectedIndex = -1;
            txtNome.Text = string.Empty;
            txtCognome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbProgetti.SelectedIndex = -1;
            txtTitolo.Text = string.Empty;
            txtDescrizione.Text = string.Empty;
            txtTipoDispositivo.Text = string.Empty;
            txtFornitoreCertificato.Text = string.Empty;
            txtCf.Text = string.Empty;
            txtSo.Text = string.Empty;
            txtBrowser.Text = string.Empty;
            cmbDomandePagamentoImpresa.SelectedIndex = -1;
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                assistenzaProvider.DbProviderObj.BeginTran();
                SiarLibrary.AssistenzaUtenti assistenza = new SiarLibrary.AssistenzaUtenti();
                assistenza.CodTipoRichiesta = cmbSelTipoAssistenza.SelectedValue;
                assistenza.Nome = txtNome.Text;
                assistenza.Cognome = txtCognome.Text;
                assistenza.Email = txtEmail.Text;
                int idProgetto;
                int.TryParse(cmbProgetti.SelectedValue, out idProgetto);
                assistenza.IdProgetto = idProgetto;
                assistenza.Titolo = txtTitolo.Text;

                string datiExtra = "";
                if (cmbSelTipoAssistenza.SelectedValue == "1")
                {
                    datiExtra += "Id Domanda pagamento: " + cmbDomandePagamentoImpresa.SelectedValue + ";" + System.Environment.NewLine;
                }
                else if (cmbSelTipoAssistenza.SelectedValue == "2")
                {
                    datiExtra += "Tipo dispositivo: " + txtTipoDispositivo.Text + ";" + System.Environment.NewLine;
                    datiExtra += "Fornitore del certificato: " + txtFornitoreCertificato.Text + ";" + System.Environment.NewLine;
                    datiExtra += "Codice fiscale utente: " + txtCf.Text + ";" + System.Environment.NewLine;
                    datiExtra += "Sistema operativo e architettura: " + txtSo.Text + ";" + System.Environment.NewLine;
                    datiExtra += "Browser: " + txtBrowser.Text + ";" + System.Environment.NewLine;                    
                }

                assistenza.Descrizione = datiExtra + txtDescrizione.Text;
                assistenza.IdUtenteInserimento = Operatore.Utente.IdUtente;
                assistenza.DataInserimento = DateTime.Now;
                assistenza.IdImpresa = Azienda.IdImpresa;
                assistenza.Gestita = false;
                assistenza.Risolta = false;

                assistenzaProvider.Save(assistenza);

                if (ufcNAAllegato.IdFile != null)
                {
                    allegatiProvider = new SiarBLL.AssistenzaUtentiAllegatiCollectionProvider(assistenzaProvider.DbProviderObj);

                    SiarLibrary.AssistenzaUtentiAllegati allegato = new SiarLibrary.AssistenzaUtentiAllegati();
                    allegato.IdAssistenza = assistenza.Id;
                    allegato.IdAllegato = ufcNAAllegato.IdFile;

                    allegatiProvider.Save(allegato);
                }
                assistenzaProvider.DbProviderObj.Commit();
                ShowMessage("Richiesta di assistenza inserita correttamente.");
                clearForm();
            }
            catch (Exception ex) { ShowError(ex); assistenzaProvider.DbProviderObj.Rollback(); }
        }
    }
}