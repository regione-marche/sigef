using System;

namespace web.Private.Psr.Monitoraggio
{
    public partial class tp : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.ZtpCollectionProvider tp_provider = new SiarBLL.ZtpCollectionProvider();
        SiarLibrary.ZtpCollection sl = new SiarLibrary.ZtpCollection();

        SiarLibrary.Ztp tipologia_selezionata = null;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "Tipologia_di_Progetto";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_tipologia;
            if (int.TryParse(hdnIdTp.Value, out id_tipologia))
                tipologia_selezionata = tp_provider.GetById(id_tipologia);

            Form.DefaultButton = btnCerca.UniqueID;
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbDettaglio.Visible = true;
                    ucSiarNewTab.Width = tbDettaglio.Width;
                    lstProgrammazione.AttivazioneBandi = true;
                    lstProgrammazione.DataBind();

                    if (tipologia_selezionata != null)
                    {
                        txtCodice.Text = tipologia_selezionata.Codice;
                        txtCodice.ReadOnly = true;
                        txtDescrizione.Text = tipologia_selezionata.Descrizione;
                        lstProgrammazione.SelectedValue = tipologia_selezionata.IdProgrammazione;
                    }

                    break;
                default:
                    tbElenco.Visible = true;
                    ucSiarNewTab.Width = tbElenco.Width;
                    // 
                    // Se non già valorizzati scrivo nei campi di ricerca i valori degli hidden
                    if (!string.IsNullOrEmpty(hdnCercaCodice.Value) && string.IsNullOrEmpty(txtCercaCodice.Text))
                        txtCercaCodice.Text = hdnCercaCodice.Value;
                    if (!string.IsNullOrEmpty(hdnCercaDescrizione.Value) && string.IsNullOrEmpty(txtCercaDescrizione.Text))
                        txtCercaDescrizione.Text = hdnCercaDescrizione.Value;

                    // Se non è compilato il campo da ricercare eseguo la query generica senza parametri.
                    if (!string.IsNullOrEmpty(txtCercaCodice.Text) && !string.IsNullOrEmpty(txtCercaDescrizione.Text))
                        sl = tp_provider.Find(null, txtCercaCodice.Text, "%"+txtCercaDescrizione.Text+"%");
                    else if (!string.IsNullOrEmpty(txtCercaCodice.Text) && string.IsNullOrEmpty(txtCercaDescrizione.Text))
                        sl = tp_provider.Find(null, txtCercaCodice.Text, null);
                    else if (string.IsNullOrEmpty(txtCercaCodice.Text) && !string.IsNullOrEmpty(txtCercaDescrizione.Text))
                        sl = tp_provider.Find(null, null, "%" + txtCercaDescrizione.Text+"%");
                    else
                        sl = tp_provider.Find(null, null, null);
                    // 
                    dg.DataSource = sl;
                    dg.Titolo = "Elementi trovati: " + sl.Count;
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

                if (tipologia_selezionata == null) tipologia_selezionata = new SiarLibrary.Ztp();

                // TODO: controllare se la tipologia è utilizzata in chiave in altre maschere
                //else if (new SiarBLL.AllegatiXDomandaCollectionProvider().Find(allegato_selezionato.IdAllegato, null, null).Count > 0)
                //    throw new Exception("Non è possibile modificare l'allegato selezionato perché già utilizzato nei bandi.");

                if (string.IsNullOrEmpty(lstProgrammazione.SelectedValue)) throw new Exception("E' obbligatorio specificare la programmazione!");
                tipologia_selezionata.Codice = txtCodice.Text;
                tipologia_selezionata.Descrizione = txtDescrizione.Text;
                tipologia_selezionata.IdProgrammazione = lstProgrammazione.SelectedValue;
                tp_provider.Save(tipologia_selezionata);
                ShowMessage("Tipo progetto salvato correttamente.");
                hdnIdTp.Value = tipologia_selezionata.Id;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                // Controllo che sia abilitata la modifica del record
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (tipologia_selezionata == null) throw new Exception("Nessun tipo progetto selezionato, impossibile continuare.");
                
                // TODO: controllare se la tipologia è utilizzata in chiave in altre maschere
                //if (new SiarBLL.AllegatiXDomandaCollectionProvider().Find(tipologia_selezionata.IdAllegato, null, null).Count > 0)
                //    throw new Exception("Non è possibile eliminare l'allegato selezionato perché già utilizzato nei bandi.");
                
                tp_provider.Delete(tipologia_selezionata);
                ShowMessage("Tipo progetto eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
                tipologia_selezionata = null;
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
