using SiarBLL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class ComunicazioneFinanziabilita : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        SiarBLL.BandoResponsabiliCollectionProvider resp_provider = new SiarBLL.BandoResponsabiliCollectionProvider();
        SiarBLL.VistruttoriaDomandeCollectionProvider istruttoria_provider = new SiarBLL.VistruttoriaDomandeCollectionProvider();
        SiarBLL.ProgettoSegnatureCollectionProvider segnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider();
        int domande_non_comunicate = 0;

        protected void Page_Load(object sender, EventArgs e) { ucFirmaComunicazione.DocumentoFirmatoEvent = btnPostBack_Click; }

        protected override void OnPreRender(EventArgs e)
        {
            lstProvincia.DataBind();
            lstStato.DataBinding += new EventHandler(lstStato_DataBind);
            lstStato.DataBind();


            AbilitaModifica = (AbilitaModifica && resp_provider.Find(Bando.IdBando,
                 Operatore.Utente.IdUtente, null, true, true ).Count > 0);

            SiarLibrary.VistruttoriaDomandeCollection progetti_istruttore = istruttoria_provider.FindComunicazioni(Bando.IdBando, "CF", null,
                lstProvincia.SelectedValue, (string.IsNullOrEmpty(lstStato.SelectedValue) ? "F" : lstStato.SelectedValue));
            dg.DataSource = progetti_istruttore;
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            lblDomande.Text = ((SiarLibrary.VistruttoriaDomandeCollection)dg.DataSource).Count.ToString();
            lblComunicazioni.Text = domande_non_comunicate.ToString();
            base.OnPreRender(e);
        }

        void lstStato_DataBind(object sender, EventArgs e)
        {
            lstStato.Items.Clear();
            lstStato.Items.Add(new ListItem("Finanziabile", "F"));
            lstStato.Items.Add(new ListItem("Non finanziabile", "N"));
            foreach (ListItem li in lstStato.Items)
                if (li.Value == lstStato.SelectedValue) li.Selected = true;
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.VistruttoriaDomande c = (SiarLibrary.VistruttoriaDomande)e.Item.DataItem;
                dgi.Cells[1].Text = "NUMERO: <b>" + c.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; Partita iva/Codice fiscale: <b>" + c.Cuaa
                    + "<br />Rag.soc:</b> " + c.RagioneSociale
                    + "<br /><b>Sede:</b> " + c.Comune + " (" + c.Sigla + ") - " + c.Cap;

                if (string.IsNullOrEmpty(c.AdditionalAttributes["CodTipoComunicazione"]))
                {
                    if (AbilitaModifica)
                        dgi.Cells[4].Text = "<a href=\"javascript:firmaDocumento(" + c.IdProgetto + ");\"> firma e protocolla la comunicazione </a>";
                    domande_non_comunicate++;
                }
                else dgi.Cells[4].Text = c.AdditionalAttributes["SegnaturaComunicazione"] + "<BR />" + "<b><a href=\"javascript:viewProtocollo('"
                    + c.AdditionalAttributes["SegnaturaComunicazione"] + "');\">visualizza</a></b>";
            }
        }
        protected void btnFirmaComunicazione_Click(object sender, EventArgs e)
        {

            int id_progetto;
            try
            {
                if (string.IsNullOrEmpty(hdnIdProgetto.Text) || !int.TryParse(hdnIdProgetto.Text, out id_progetto))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);
                if (p == null) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");

                SiarLibrary.VistruttoriaDomandeCollection progetti_istruttoria = istruttoria_provider.Find(Bando.IdBando, p.IdProgetto, null, null, null, null, null, null, null);
                if (progetti_istruttoria.FiltroIstruttoria(null, null, null, "F", null, null).Count > 0)
                {
                    ucFirmaComunicazione.TipoDocumento = "COMUNICAZIONE_FINANZIABILITA";
                }
                else if (progetti_istruttoria.FiltroIstruttoria(null, null, null, "N", null, null).Count > 0)
                {
                    ucFirmaComunicazione.TipoDocumento = "COMUNICAZIONE_NON_FINANZIABILITA";
                    ucFirmaComunicazione.Titolo = "COMUNICAZIONE DI NON FINANZIABILITA`";
                }
                else throw new Exception("La domanda selezionata non si trova nello stato necessario alla firma del rapporto istruttorio.");

                if (!istruttoria_provider.FindAttoXComunicazione(id_progetto, (string.IsNullOrEmpty(lstStato.SelectedValue) ? "F" : lstStato.SelectedValue)))
                    throw new Exception("Non è presente l'atto di finanziabilità. Si prega di contattare l'helpdesk.");
                ucFirmaComunicazione.loadDocumento(((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, id_progetto.ToString());
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                if (string.IsNullOrEmpty(ucFirmaComunicazione.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");

                if (int.TryParse(hdnIdProgetto.Text, out id_progetto))
                {
                    SiarLibrary.Progetto progetto = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);
                    if (progetto != null)
                    {
                        if (progetto.CodStato == "F")
                        {
                            if (segnature_provider.Find(progetto.IdProgetto, "CFI", null, null).Count == 0)
                            {
                                #region protocollo
                                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                                if (impresa != null)
                                {
                                    SiarLibrary.Protocollo comunicazione = new SiarLibrary.Protocollo(Bando.CodEnte);
                                    comunicazione.setCorrispondente(impresa, progetto.IdProgetto, "destinatario");
                                    comunicazione.setDocumento("comunicazione_finanziabilita_domanda_nr_" + progetto.IdProgetto + ".pdf",
                                       Convert.FromBase64String(ucFirmaComunicazione.FileFirmato));

                                    string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione);
                                    string oggetto = "Comunicazione di finanziabilità domanda di aiuto nr. " + progetto.IdProgetto
                                        + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: "
                                        + Bando.DataScadenza + "\n" + ss[3] 
                                        + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                                        + "\n Ragione sociale: " + impresa.RagioneSociale;
                                    string segnatura = comunicazione.ProtocolloUscita(oggetto, ss[4], true);
                                    try
                                    {
                                        SiarLibrary.ProgettoSegnature segnatura_comunicazione = new SiarLibrary.ProgettoSegnature();
                                        segnatura_comunicazione.Segnatura = segnatura;
                                        segnatura_comunicazione.IdProgetto = progetto.IdProgetto;
                                        segnatura_comunicazione.Data = System.DateTime.Now;
                                        segnatura_comunicazione.CodTipo = "CFI";
                                        segnatura_comunicazione.Operatore = Operatore.Utente.CfUtente;
                                        segnature_provider.Save(segnatura_comunicazione);
                                        ShowMessage("Comunicazione di finanziabilità firmata e protocollata correttamente.");
                                    }
                                    catch (Exception ex)
                                    {
                                        string oggettoEmail = "Errore durante la comunicazione di finanziabilità";
                                        string testEmail = "Domanda: "
                                            + progetto.IdProgetto + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                                        EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                                        ShowError(ex);
                                    }
                                }
                                else ShowError("L'impresa titolare della domanda è inesistente. Impossibile continuare.");
                                #endregion
                            }
                            else ShowError("La comunicazione di finanziabilità per la domanda " + progetto.IdProgetto
                                + " è gia' stata effettuata.");
                        }
                        else
                        {
                            if (segnature_provider.Find(progetto.IdProgetto, "CFN", null, null).Count == 0)
                            {
                                #region protocollo
                                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                                if (impresa != null)
                                {
                                    SiarLibrary.Protocollo comunicazione = new SiarLibrary.Protocollo(Bando.CodEnte);
                                    comunicazione.setCorrispondente(impresa, progetto.IdProgetto, "destinatario");
                                    comunicazione.setDocumento("comunicazione_non_finanziabilita_domanda_nr_" + progetto.IdProgetto + ".pdf",
                                        Convert.FromBase64String(ucFirmaComunicazione.FileFirmato));

                                    string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione);
                                    string oggetto = "Comunicazione di non finanziabilità domanda di aiuto nr. " + progetto.IdProgetto
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
                                        segnatura_comunicazione.CodTipo = "CFN";
                                        segnatura_comunicazione.Operatore = Operatore.Utente.CfUtente;
                                        segnature_provider.Save(segnatura_comunicazione);
                                        ShowMessage("Comunicazione di non finanziabilità firmata e protocollata correttamente.");
                                    }
                                    catch (Exception ex)
                                    {
                                        string oggettoEmail = "Errore durante la comunicazione di non finanziabilità";
                                        string testEmail = "Domanda: "
                                            + progetto.IdProgetto + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                                        EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                                        ShowError(ex);
                                    }
                                }
                                else ShowError("L'impresa titolare della domanda è inesistente. Impossibile continuare.");
                                #endregion
                            }
                            else ShowError("La comunicazione di non finanziabilità per la domanda " + progetto.IdProgetto + " è gia' stata effettuata.");
                        }
                    }
                    else ShowError("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema urgentemente.");
                }
                else ShowError("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema urgentemente.");
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaComunicazione.FileFirmato = null; }
        }

        protected void btnViewProtocollo_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Protocollo doc = new SiarLibrary.Protocollo(Bando.CodEnte);
                byte[] report = doc.RicercaProtocollo(hdnSegnatura.Text, true);
                Session["doc"] = report;
                RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}