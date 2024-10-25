using System;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary.Extensions;

namespace web.Private.Istruttoria
{
    public partial class ComunicazioneNonAmmissibilita : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        SiarBLL.ProgettoSegnatureCollectionProvider segnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider();
        SiarBLL.ProgettoComunicazioniCollectionProvider comunicazioni_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        bool show_div_decreto = false;
        SiarLibrary.Atti decreto_selezionato = null;
        int definitive_non_comunicate = 0, provvisorie_non_comunicate = 0, nr_domande_senza_atto = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaComunicazione.DocumentoFirmatoEvent = btnPostBack_Click;
            AbilitaModifica = (AbilitaModifica && new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstProvincia.DataBind();
            SiarLibrary.ProgettoSegnatureCollection comunicazioni = comunicazioni_provider.GetComunicazioniNonAmmissibilita(Bando.IdBando,
                lstProvincia.SelectedValue, null);
            dg.DataSource = comunicazioni;
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            lblDomande.Text = comunicazioni.Count.ToString();
            lblComunicazioni.Text = provvisorie_non_comunicate.ToString();
            lblProvvedimenti.Text = definitive_non_comunicate.ToString();
            if (nr_domande_senza_atto == 0) btnDecreto.Enabled = false;

            if (show_div_decreto)
            {
                lstAttoDefinizione.DataBind();
                lstAttoRegistro.DataBind();
                lstAttoOrgIstituzionale.DataBind();
                lstAttoTipo.DataBind();
                if (decreto_selezionato != null)
                {
                    hdnIdAtto.Value = decreto_selezionato.IdAtto;
                    txtAttoDescrizione.Text = decreto_selezionato.Descrizione;
                    lstAttoOrgIstituzionale.SelectedValue = decreto_selezionato.CodOrganoIstituzionale;
                    if (!string.IsNullOrEmpty(decreto_selezionato.CodTipo))
                    {
                        lstAttoTipo.SelectedValue = decreto_selezionato.CodTipo;
                        lstAttoTipo.Enabled = false;
                    }
                    txtAttoBurNumero.Text = decreto_selezionato.NumeroBur;
                    txtAttoBurData.Text = decreto_selezionato.DataBur;
                }
                else hdnIdAtto.Value = null;

                RegisterClientScriptBlock("mostraPopupTemplate('divDecreto','divBKGMessaggio');");
            }
            else
            {
                pulisciCampiDecreto();
                ((SiarLibrary.Web.CheckColumn)dg.Columns[6]).ClearSelected();
            }
            base.OnPreRender(e);
        }

        private void pulisciCampiDecreto()
        {
            txtAttoData.Text = "";
            txtAttoNumero.Text = "";
            lstAttoRegistro.ClearSelection();
            lstAttoTipo.ClearSelection();
            lstAttoOrgIstituzionale.ClearSelection();
            txtAttoDescrizione.Text = "";
            txtAttoBurData.Text = "";
            txtAttoBurNumero.Text = "";
            txtAttoDataXComunicazione.Text = "";
            hdnIdAtto.Value = "";
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoSegnature c = (SiarLibrary.ProgettoSegnature)e.Item.DataItem;
                e.Item.Cells[1].Text = "ID: <b>" + c.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; P.Iva: <b>" + c.AdditionalAttributes["PIVA"]
                    + "<br />Rag.soc:</b> " + c.AdditionalAttributes["RAGIONE_SOCIALE"] + "<br /><b>Sede:</b> " + c.AdditionalAttributes["SEDE"];
                e.Item.Cells[2].Text = c.AdditionalAttributes["PROVINCIA"];
                e.Item.Cells[3].Text = c.AdditionalAttributes["STATO"];

                // non ammissibilita provvisoria
                string nap_segnatura = c.AdditionalAttributes["NAP_SEGNATURA"], url = "", btn_text = "Visualizza";
                if (!string.IsNullOrEmpty(nap_segnatura)) url = "sncAjaxCallVisualizzaProtocollo('" + nap_segnatura + "');";
                else
                {
                    provvisorie_non_comunicate++;
                    url = "firmaDocumento(" + c.IdProgetto + ",'NAP');"; btn_text = "Invia la comunicazione";
                    if (string.IsNullOrEmpty(c.AdditionalAttributes["SEGNATURA_RI"]))
                        url = "if(confirm('Attenzione! Non è stato firmato il rapporto istruttorio per questa domanda. Continuare?'))" + url;
                    if (!AbilitaModifica) url = "alert('L`operatore non è abilitato all`operazione selezionata.');";
                }
                e.Item.Cells[4].Text = "<input type=button class=ButtonGrid style='width:135px' value='" + btn_text + "' onclick=\"" + url + "\" />";

                int id_atto = 0;
                int.TryParse(c.AdditionalAttributes["ID_ATTO"], out id_atto);
                if (id_atto > 0) e.Item.Cells[6].Text = "<input type=button class=ButtonGrid style='width:135px' value='" + c.AdditionalAttributes["ATTO"] 
                    + "' onclick=\"visualizzaAtto(" + id_atto + ");\" />";
                else nr_domande_senza_atto++;

                // definitiva
                string nad_segnatura = c.AdditionalAttributes["NAD_SEGNATURA"];
                if (!string.IsNullOrEmpty(nad_segnatura))
                {
                    btn_text = "Visualizza";
                    url = "sncAjaxCallVisualizzaProtocollo('" + nad_segnatura + "');";
                    if (string.IsNullOrEmpty(nap_segnatura)) e.Item.Cells[4].Text = "Non inviata";
                }
                else
                {
                    definitive_non_comunicate++;
                    url = "firmaDocumento(" + c.IdProgetto + ",'NAD');"; btn_text = "Invia la comunicazione";
                    if (string.IsNullOrEmpty(c.AdditionalAttributes["SEGNATURA_RI"]))
                        url = "if(confirm('Attenzione! Non è stato firmato il rapporto istruttorio per questa domanda. Continuare?'))" + url;
                    if (id_atto <= 0) url = "alert('Per proseguire è necessario indicare il decreto di non ammissibilità.');";
                    if (!AbilitaModifica) url = "alert('Attenzione! L`utente non è abilitato all`operazione selezionata.');";
                }
                e.Item.Cells[5].Text = "<input type=button class=ButtonGrid style='width:135px' value='" + btn_text + "' onclick=\"" + url + "\" />";
            }
        }

        protected void btnFirmaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_progetto;
                if (!int.TryParse(hdnIdProgetto.Text, out id_progetto) || string.IsNullOrEmpty(hdnTipoSegnatura.Text))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                switch (hdnTipoSegnatura.Text)
                {
                    case "NAP":
                        ucFirmaComunicazione.TipoDocumento = "NON_AMMISSIBILITA_PROV";
                        ucFirmaComunicazione.Titolo = "FIRMA COMUNICAZIONE NON AMMISSIBILITA`";
                        break;
                    case "NAD":
                        ucFirmaComunicazione.TipoDocumento = "NON_AMMISSIBILITA_DEF";
                        ucFirmaComunicazione.Titolo = "FIRMA DELLA PROVVEDIMENTO DI NON AMMISSIBILITA`";
                        break;
                    default:
                        throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                }
                if (segnature_provider.Find(id_progetto, hdnTipoSegnatura.Text, null, null).Count > 0)
                    throw new Exception("La comunicazione di non ammissibilita per la domanda " + id_progetto + " è gia' stata effettuata.");
                ucFirmaComunicazione.loadDocumento(Operatore.Utente.CfUtente, id_progetto.ToString());
            }
            catch (Exception ex) { ShowError(ex); }

        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(ucFirmaComunicazione.FileFirmato) || string.IsNullOrEmpty(hdnTipoSegnatura.Text) || !hdnTipoSegnatura.Text.FindValueIn("NAP", "NAD"))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                SiarLibrary.Progetto progetto = null;
                int id_progetto;
                if (int.TryParse(hdnIdProgetto.Text, out id_progetto)) progetto = new SiarBLL.ProgettoCollectionProvider().GetById(hdnIdProgetto.Text);
                if (progetto == null) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per e segnalare il problema urgentemente.");
                if (segnature_provider.Find(progetto.IdProgetto, hdnTipoSegnatura.Text, null, null).Count > 0)
                    throw new Exception("La comunicazione di non ammissibilita per la domanda " + progetto.IdProgetto + " è gia' stata effettuata.");
                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                if (impresa == null) throw new Exception("L'impresa titolare della domanda è inesistente. Impossibile continuare.");

                SiarLibrary.Protocollo comunicazione = new SiarLibrary.Protocollo(Bando.CodEnte);
                comunicazione.setCorrispondente(impresa, progetto.IdProgetto, "destinatario");
                comunicazione.setDocumento("comunicazione_non_ammissibilita_domanda_nr_" + progetto.IdProgetto + ".pdf",
                    Convert.FromBase64String(ucFirmaComunicazione.FileFirmato));

                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione);
                string oggetto = "Comunicazione di non ammissibilita domanda di aiuto nr. " + progetto.IdProgetto
                    + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: " + Bando.DataScadenza + "\n" + ss[3] 
                    + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                    + "\n Ragione sociale: " + impresa.RagioneSociale;
                string segnatura = comunicazione.ProtocolloUscita(oggetto, ss[4], true);
                try
                {
                    SiarLibrary.ProgettoSegnature segnatura_comunicazione = new SiarLibrary.ProgettoSegnature();
                    segnatura_comunicazione.Segnatura = segnatura;
                    segnatura_comunicazione.IdProgetto = progetto.IdProgetto;
                    segnatura_comunicazione.Data = DateTime.Now;
                    segnatura_comunicazione.CodTipo = hdnTipoSegnatura.Text;
                    segnatura_comunicazione.Operatore = Operatore.Utente.CfUtente;
                    segnature_provider.Save(segnatura_comunicazione);
                    ShowMessage("Comunicazione di non ammissibilita firmata e protocollata correttamente.");
                }
                catch (Exception ex)
                {
                    string oggettoEmail = "Errore in comunicazione di non ammissibilita domande";
                    string testEmail = "Domanda: " + progetto.IdProgetto + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                    EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                    ShowError(ex);
                }
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaComunicazione.FileFirmato = null; }
        }

        protected void btnDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string[] domande_selezionate = ((SiarLibrary.Web.CheckColumn)dg.Columns[6]).GetSelected();
                if (domande_selezionate.Length == 0) throw new Exception("Per proseguire è necessario selezionare almeno una domanda.");
                show_div_decreto = true;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                show_div_decreto = true;
                int numero;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;
                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                // controllo che l'atto sia registrato su db, altrimenti lo importo
                SiarLibrary.AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0) atti_provider.Save(atti_trovati[0]);
                }
                if (atti_trovati.Count > 0) decreto_selezionato = atti_trovati[0];
                else ShowMessage("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaDecreto_Click(object sender, EventArgs e)
        {
            SiarBLL.ProgettoStoricoCollectionProvider pstorico_provider = new SiarBLL.ProgettoStoricoCollectionProvider();
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_atto;
                if (!int.TryParse(hdnIdAtto.Value, out id_atto)) throw new Exception("Per proseguire è necessario specificare un atto.");
                string[] domande_selezionate = ((SiarLibrary.Web.CheckColumn)dg.Columns[6]).GetSelected();
                if (domande_selezionate.Length == 0) throw new Exception("Per proseguire è necessario selezionare almeno una domanda.");
                if (string.IsNullOrEmpty(lstAttoTipo.SelectedValue)) throw new Exception("Per proseguire è necessario specificare la tipologia dell'atto.");
                SiarLibrary.Atti a = atti_provider.GetById(id_atto);
                if (a == null) throw new Exception("L'atto selezionato non è valido.");
                if (a.CodTipo == null)
                {
                    a.CodTipo = lstAttoTipo.SelectedValue;
                    atti_provider.Save(a);
                }

                pstorico_provider.DbProviderObj.BeginTran();
                foreach (string s in domande_selezionate)
                {
                    SiarLibrary.ProgettoStorico ps = null;
                    int id_progetto;
                    if (int.TryParse(s, out id_progetto))
                    {
                        SiarLibrary.ProgettoStoricoCollection cc = pstorico_provider.Find(id_progetto, "B", null);
                        if (cc.Count > 0) ps = cc[0];
                    }
                    if (ps == null) throw new Exception("Almeno una delle domande selezionate non è valida.");
                    ps.IdAtto = a.IdAtto;
                    pstorico_provider.Save(ps);
                }
                pstorico_provider.DbProviderObj.Commit();
                RegisterClientScriptBlock("chiudiPopup();");
                ShowMessage("L'atto è stato correttamente associato a " + domande_selezionate.Length + " domande.");
            }
            catch (Exception ex) { pstorico_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}