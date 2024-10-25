using SiarBLL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class ComunicazioneEsitoIstruttorio : SiarLibrary.Web.IstruttoriaPage
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
            AbilitaModifica = (AbilitaModifica && resp_provider.Find(Bando.IdBando,Operatore.Utente.IdUtente , null, true, true ).Count > 0);

            SiarLibrary.VistruttoriaDomandeCollection progetti_istruttore = istruttoria_provider.
                FindComunicazioni(Bando.IdBando, "CEI", txtNrDomanda.Text, lstProvincia.SelectedValue, "A");
            dg.DataSource = progetti_istruttore;
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            lblDomande.Text = ((SiarLibrary.VistruttoriaDomandeCollection)dg.DataSource).Count.ToString();
            lblComunicazioni.Text = domande_non_comunicate.ToString();
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.VistruttoriaDomande c = (SiarLibrary.VistruttoriaDomande)e.Item.DataItem;
                dgi.Cells[1].Text = "NUMERO: <b>" + c.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; Partita iva/Codice fiscale: <b>" + c.Cuaa
                    + "<br />Rag.soc:</b> " + c.RagioneSociale + "<br /><b>Sede:</b> " + c.Comune + " ("
                    + c.Sigla + ") - " + c.Cap;
                if (string.IsNullOrEmpty(c.AdditionalAttributes["CodTipoComunicazione"]))
                {
                    if (AbilitaModifica)
                    {
                        if (c.SegnaturaRi != null) dgi.Cells[4].Text = "<a href=\"javascript:firmaDocumento(" + c.IdProgetto + ");\"> firma e protocolla la comunicazione </a>";
                        else dgi.Cells[4].Text = "<a href=\"javascript:if(confirm('Attenzione!\nNon è stato firmato il rapporto istruttorio per questa domanda. Continuare?')){firmaDocumento("
                            + c.IdProgetto + ");}\">firma e protocolla la comunicazione</a>";
                    }
                    domande_non_comunicate++;
                }
                else dgi.Cells[4].Text = c.AdditionalAttributes["SegnaturaComunicazione"] + "<BR />" + "<b><a href=\"javascript:viewProtocollo('"
                    + c.AdditionalAttributes["SegnaturaComunicazione"] + "');\">visualizza</a></b>";
            }
        }

        protected void btnFirmaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(hdnIdProgetto.Text))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                if ((segnature_provider.Find(hdnIdProgetto.Text, "CEI", null, null).Count) > 0)
                    throw new Exception("La comunicazione di esito istruttorio per la domanda " + hdnIdProgetto.Text + " è gia' stata effettuata.");
                ucFirmaComunicazione.loadDocumento(((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, hdnIdProgetto.Text);
            }
            catch (Exception ex) { ShowError(ex); }

        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaComunicazione.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                if (!string.IsNullOrEmpty(hdnIdProgetto.Text))
                {
                    SiarLibrary.Progetto progetto = new SiarBLL.ProgettoCollectionProvider().GetById(hdnIdProgetto.Text);
                    if (progetto != null)
                    {
                        if (segnature_provider.Find(progetto.IdProgetto, "CEI", null, null).Count == 0)
                        {
                            SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                            if (impresa != null)
                            {
                                SiarLibrary.Protocollo comunicazione = new SiarLibrary.Protocollo(Bando.CodEnte);
                                comunicazione.setCorrispondente(impresa, progetto.IdProgetto, "destinatario");
                                comunicazione.setDocumento("comunicazione_esito_istruttorio_domanda_nr_" + progetto.IdProgetto + ".pdf",
                                    Convert.FromBase64String(ucFirmaComunicazione.FileFirmato));

                                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione );
                                string oggetto = "Comunicazione di esito istruttorio domanda di aiuto nr. " + progetto.IdProgetto
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
                                    segnatura_comunicazione.Data = DateTime.Now;
                                    segnatura_comunicazione.CodTipo = "CEI";
                                    segnatura_comunicazione.Operatore = Operatore.Utente.CfUtente;
                                    segnature_provider.Save(segnatura_comunicazione);
                                    ShowMessage("Comunicazione di esito istruttorio firmata e protocollata correttamente.");
                                }
                                catch (Exception ex)
                                {
                                    string oggettoEmail = "Errore durante la comunicazione di esito istruttorio";
                                    string testEmail = "Domanda: " + progetto.IdProgetto + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                                    EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                                    ShowError(ex);
                                }
                            }
                            else ShowError("L'impresa titolare della domanda è inesistente. Impossibile continuare.");
                        }
                        else ShowError("La comunicazione di esito istruttorio per la domanda " + progetto.IdProgetto + " è gia' stata effettuata.");
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "viewProtocolloScript", "window.open('../../VisualizzaDocumento.aspx');", true);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }
    }
}