using System;

namespace web.Private.Psr.Monitoraggio
{
    public partial class stp : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.ZstpCollectionProvider stp_provider = new SiarBLL.ZstpCollectionProvider();
        SiarLibrary.ZstpCollection ssl = new SiarLibrary.ZstpCollection();

        SiarLibrary.Zstp sottotipologia_selezionata = null;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "Sottotipologia_di_progetto";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_sottotipologia;
            if (int.TryParse(hdnIdStp.Value, out id_sottotipologia))
                sottotipologia_selezionata = stp_provider.GetById(id_sottotipologia);

            Form.DefaultButton = btnCerca.UniqueID;
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbDettaglio.Visible = true;
                    //ucSiarNewTab.Width = tbDettaglio.Width;
                    lstProgrammazione.AttivazioneBandi = true;
                    lstProgrammazione.DataBind();

                    if (sottotipologia_selezionata != null)
                    {
                        txtCodice.Text = sottotipologia_selezionata.Codice;
                        txtCodice.ReadOnly = true;
                        txtDescrizione.Text = sottotipologia_selezionata.Descrizione;
                        lstProgrammazione.SelectedValue = sottotipologia_selezionata.IdProgrammazione;
                    }

                    break;
                default:
                    tbElenco.Visible = true;
                    //ucSiarNewTab.Width = tbElenco.Width;
                    // 
                    // Se non già valorizzati scrivo nei campi di ricerca i valori degli hidden
                    if (!string.IsNullOrEmpty(hdnCercaCodice.Value) && string.IsNullOrEmpty(txtCercaCodice.Text))
                        txtCercaCodice.Text = hdnCercaCodice.Value;
                    if (!string.IsNullOrEmpty(hdnCercaDescrizione.Value) && string.IsNullOrEmpty(txtCercaDescrizione.Text))
                        txtCercaDescrizione.Text = hdnCercaDescrizione.Value;

                    // Se non è compilato il campo da ricercare eseguo la query generica senza parametri.
                    if (!string.IsNullOrEmpty(txtCercaCodice.Text) && !string.IsNullOrEmpty(txtCercaDescrizione.Text))
                        ssl = stp_provider.Find(null, txtCercaCodice.Text, "%"+txtCercaDescrizione.Text+"%");
                    else if (!string.IsNullOrEmpty(txtCercaCodice.Text) && string.IsNullOrEmpty(txtCercaDescrizione.Text))
                        ssl = stp_provider.Find(null, txtCercaCodice.Text, null);
                    else if (string.IsNullOrEmpty(txtCercaCodice.Text) && !string.IsNullOrEmpty(txtCercaDescrizione.Text))
                        ssl = stp_provider.Find(null, null, "%" + txtCercaDescrizione.Text+"%");
                    else
                        ssl = stp_provider.Find(null, null, null);
                    // 
                    dg.DataSource = ssl;
                    dg.Titolo = "Elementi trovati: " + ssl.Count;
                    dg.DataBind();

                    break;
            }

            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                // Controllo che sia abilitata la modifica del record
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (sottotipologia_selezionata == null) sottotipologia_selezionata = new SiarLibrary.Zstp();

                // TODO: controllare se la tipologia è utilizzata in chiave in altre maschere
                //else if (new SiarBLL.AllegatiXDomandaCollectionProvider().Find(allegato_selezionato.IdAllegato, null, null).Count > 0)
                //    throw new Exception("Non è possibile modificare l'allegato selezionato perché già utilizzato nei bandi.");

                if (string.IsNullOrEmpty(lstProgrammazione.SelectedValue)) throw new Exception("E' obbligatorio specificare la programmazione!");
                sottotipologia_selezionata.Codice = txtCodice.Text;
                sottotipologia_selezionata.Descrizione = txtDescrizione.Text;
                sottotipologia_selezionata.IdProgrammazione = lstProgrammazione.SelectedValue;
                stp_provider.Save(sottotipologia_selezionata);
                ShowMessage("Tipo progetto salvato correttamente.");
                hdnIdStp.Value = sottotipologia_selezionata.Id;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                // Controllo che sia abilitata la modifica del record
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (sottotipologia_selezionata == null) throw new Exception("Nessun sotto tipo progetto selezionato, impossibile continuare.");
                
                // TODO: controllare se la tipologia è utilizzata in chiave in altre maschere
                //if (new SiarBLL.AllegatiXDomandaCollectionProvider().Find(tipologia_selezionata.IdAllegato, null, null).Count > 0)
                //    throw new Exception("Non è possibile eliminare l'allegato selezionato perché già utilizzato nei bandi.");

                stp_provider.Delete(sottotipologia_selezionata);
                ShowMessage("Sotto Tipo progetto eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
                sottotipologia_selezionata = null;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            // Controllo che siano i compilati i campi della ricerca
            if (string.IsNullOrEmpty(txtCercaCodice.Text) && string.IsNullOrEmpty(txtCercaDescrizione.Text))
                ShowError("Specificare i parametri di ricerca.");
            else {
                hdnCercaCodice.Value = txtCercaCodice.Text;
                hdnCercaDescrizione.Value = txtCercaDescrizione.Text;
            }
        }
    }
}
