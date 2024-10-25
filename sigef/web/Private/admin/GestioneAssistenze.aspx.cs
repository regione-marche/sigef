using SiarLibrary.NullTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class GestioneAssistenze : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.AssistenzaUtentiCollectionProvider assistenzaProvider = new SiarBLL.AssistenzaUtentiCollectionProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gestione_assistenze";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            cmbSelTipoAssistenza.DataBind();

            cmbOperatoriAssistenza.DataBind();

            string idProgetto = null;
            string idPass = null;
            BoolNT inLavorazione = null;
            BoolNT risolta = null;
            IntNT idOperatore = null;


            if (!string.IsNullOrEmpty(txtFilterIdProgettoConsulente.Text))
            {
                idProgetto = txtFilterIdProgettoConsulente.Text;
            }

            if (!string.IsNullOrEmpty(txtFilterPassId.Text))
            {
                idPass = txtFilterPassId.Text;
            }

            if (chkInLavorazioneFilter.Checked)
            {
                inLavorazione = true;
                risolta = false;
            }

            if (cmbOperatoriAssistenza.SelectedIndex != -1)
            {
                idOperatore = cmbOperatoriAssistenza.SelectedValue;
            }




            SiarLibrary.AssistenzaUtentiCollection assistenze = assistenzaProvider.Find(null, idProgetto, null, null, inLavorazione, risolta, idOperatore, idPass);

            dgRichiesteAssistenza.DataSource = assistenze;
            dgRichiesteAssistenza.ItemDataBound += new DataGridItemEventHandler(dgRichiesteAssistenza_ItemDataBound);
            dgRichiesteAssistenza.DataBind();

            dgRichiesteAssistenza.Titolo = "Elementi trovati: " + assistenze.Count;

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
                    e.Item.Cells[8].Text = "";
                }
                if (assistenza.Gestita)
                    dgi.Cells[10].Text = dgi.Cells[10].Text.Replace("input ", "input checked ");
                else
                    dgi.Cells[10].Text = dgi.Cells[10].Text.Replace("checked", "");
                if (assistenza.Risolta)
                    dgi.Cells[11].Text = dgi.Cells[11].Text.Replace("input ", "input checked ");
                else
                    dgi.Cells[11].Text = dgi.Cells[11].Text.Replace("checked", "");
            }
        }

        protected void btnRicerca_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            svuotaCampi();
        }

        public void svuotaCampi()
        {
            txtFilterIdProgettoConsulente.Text = string.Empty;
            txtFilterPassId.Text = string.Empty;
            chkInLavorazioneFilter.Checked = false;
            cmbOperatoriAssistenza.SelectedIndex = -1;
        }

        protected void btnDettaglioAassistenzaPost_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.AssistenzaUtenti assistenza = assistenzaProvider.GetById(hdnAssistenzaSelezionata.Value);
                cmbSelTipoAssistenza.SelectedValue = assistenza.CodTipoRichiesta;
                txtNome.Text = assistenza.Nome;
                txtCognome.Text = assistenza.Cognome;
                txtEmail.Text = assistenza.Email;
                txtIdProgetto.Text = assistenza.IdProgetto;
                txtTitolo.Text = assistenza.Titolo;
                txtDescrizione.Text = assistenza.Descrizione;
                txtPiva.Text = assistenza.Cuaa;
                txtCf.Text = assistenza.CodiceFiscale;

                SiarBLL.AssistenzaUtentiAllegatiCollectionProvider allegatiProvider = new SiarBLL.AssistenzaUtentiAllegatiCollectionProvider();

                SiarLibrary.AssistenzaUtentiAllegatiCollection allegatiAssistenza = allegatiProvider.Find(null, assistenza.Id);

                if (allegatiAssistenza.Count > 0)
                {
                    ufcNAAllegato.IdFile = allegatiAssistenza[0].IdAllegato;
                }

                txtPASS.Text = assistenza.PassId;
                txtNoteHelpDesk.Text = assistenza.NoteHelpDesk;
                chkGesita.Checked = assistenza.Gestita;
                chkRisolta.Checked = assistenza.Risolta;

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(hdnAssistenzaSelezionata.Value))
                    throw new Exception("Prima di salvare è necessario selezionare una richiesta di assistenza");
                assistenzaProvider.DbProviderObj.BeginTran();
                SiarLibrary.AssistenzaUtenti assistenza = assistenzaProvider.GetById(hdnAssistenzaSelezionata.Value);

                if (chkGesita.Checked)
                {
                    assistenza.DataGestione = DateTime.Now;

                    if (assistenza.Gestita == null || assistenza.Gestita == false)
                    {
                        SiarLibrary.Email em = new SiarLibrary.Email("Avviso presa in carico richiesta di assistenza SIGEF con oggetto: " + assistenza.Titolo,
                    "<html><body>Si comunica che la richieste di assistenza in oggetto è stata presa in carico dall'help desk del SIGEF e risulta in lavorazione. Quando la stessa verrà risolta le verrà nuovamente notificato tramite email."
                + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                + "<br />Si prega di non rispondere a questa email.</body></html>");
                        em.SetHtmlBodyMessage(true);
                        string[] destinatari = new string[1];
                        destinatari[0] = assistenza.Email;
                        em.SendNotification(destinatari, new string[] { });
                    }
                }
                else
                    assistenza.DataGestione = null;

                assistenza.Gestita = chkGesita.Checked;

                if (chkRisolta.Checked)
                {
                    assistenza.DataRisoluzione = DateTime.Now;

                    if (assistenza.Risolta == null || assistenza.Risolta == false)
                    {
                        SiarLibrary.Email em = new SiarLibrary.Email("Avviso risoluzione richiesta di assistenza SIGEF con oggetto: " + assistenza.Titolo,
                    "<html><body>Si comunica che la richieste di assistenza in oggetto è stata marcata come risolta dall'help desk del SIGEF. L'help desk ha inoltre aggiunto le seguenti note:<br />" + txtNoteHelpDesk.Text
                + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                + "<br />Si prega di non rispondere a questa email.</body></html>");
                        em.SetHtmlBodyMessage(true);
                        string[] destinatari = new string[1];
                        destinatari[0] = assistenza.Email;
                        em.SendNotification(destinatari, new string[] { });
                    }
                }
                else
                    assistenza.DataRisoluzione = null;

                assistenza.Risolta = chkRisolta.Checked;

                assistenza.PassId = txtPASS.Text;
                assistenza.NoteHelpDesk = txtNoteHelpDesk.Text;
                assistenza.IdOperatoreGestione = Operatore.Utente.IdUtente;
                assistenzaProvider.Save(assistenza);

                assistenzaProvider.DbProviderObj.Commit();
                ShowMessage("Richiesta di assistenza inserita correttamente.");
            }
            catch (Exception ex) { ShowError(ex); assistenzaProvider.DbProviderObj.Rollback(); }
        }
    }
}