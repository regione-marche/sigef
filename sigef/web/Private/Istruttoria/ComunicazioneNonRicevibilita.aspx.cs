using SiarBLL;
using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class ComunicazioneNonRicevibilita : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ricevibilita_domande";
            base.OnPreInit(e);
        }
        SiarBLL.BandoResponsabiliCollectionProvider resp_provider = new SiarBLL.BandoResponsabiliCollectionProvider();
        SiarBLL.CollaboratoriXBandoCollectionProvider coll_provider = new SiarBLL.CollaboratoriXBandoCollectionProvider();
        SiarBLL.ProgettoSegnatureCollectionProvider segnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider();

        int domande_non_comunicate = 0;
        ArrayList province_abilitate = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaComunicazione.DocumentoFirmatoEvent = btnPostBack_Click;
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstProvincia.DataBind();

            #region abilita modifica

            SiarLibrary.BandoResponsabiliCollection responsabili = resp_provider.Find(Bando.IdBando, Operatore.Utente.IdUtente, null, false, true);
            foreach (SiarLibrary.BandoResponsabili r in responsabili)
                province_abilitate.Add(r.Provincia);

            #endregion

            SiarLibrary.CollaboratoriXBandoCollection progetti_istruttore = coll_provider.GetCollabBandoDatiProgettoImpresa(Bando.IdBando,
                null, null, lstProvincia.SelectedValue, "Q");
            dg.DataSource = progetti_istruttore;
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            lblDomande.Text = ((SiarLibrary.CollaboratoriXBandoCollection)dg.DataSource).Count.ToString();
            lblComunicazioni.Text = domande_non_comunicate.ToString();
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CollaboratoriXBando c = (SiarLibrary.CollaboratoriXBando)e.Item.DataItem;
                dgi.Cells[1].Text = "NUMERO: <b>" + c.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; Partita iva/Codice fiscale: <b>" + c.AdditionalAttributes["CUAA"]
                    + "<br />Rag.soc:</b> " + c.AdditionalAttributes["RAGIONE_SOCIALE"] + "<br /><b>Sede:</b> " + c.AdditionalAttributes["COMUNE"]
                    + " (" + c.AdditionalAttributes["SIGLA"] + ") - " + c.AdditionalAttributes["CAP"];
                dgi.Cells[2].Text = c.AdditionalAttributes["PROVINCIA_DI_PRESENTAZIONE"];
                dgi.Cells[3].Text = c.AdditionalAttributes["STATO"];
                SiarLibrary.ProgettoSegnature segnatura = segnature_provider.GetById(c.IdProgetto, "NRI");
                if (segnatura == null)
                {
                    if (AbilitaModifica && province_abilitate.Contains(c.Provincia)) dgi.Cells[4].Text = "<a href=\"javascript:firmaDocumento("
                        + c.IdProgetto + ");\"> firma e protocolla la comunicazione </a>";
                    domande_non_comunicate++;
                }
                else dgi.Cells[4].Text = "<a href=\"javascript:sncAjaxCallVisualizzaProtocollo('" + segnatura.Segnatura + "');\">" + segnatura.Segnatura + "</a>";
            }
        }
        protected void btnFirmaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                if (!int.TryParse(hdnIdProgetto.Text, out id_progetto)) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                if (segnature_provider.Find(id_progetto, "NRI", null, null).Count > 0)
                    throw new Exception("La comunicazione di ricevibilita per la domanda " + id_progetto + " è gia' stata effettuata.");
                ucFirmaComunicazione.loadDocumento(((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, id_progetto.ToString());
            }
            catch (Exception ex) { ShowError(ex); }

        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaComunicazione.FileFirmato)) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                if (!string.IsNullOrEmpty(hdnIdProgetto.Text))
                {
                    SiarLibrary.Progetto progetto = new SiarBLL.ProgettoCollectionProvider().GetById(hdnIdProgetto.Text);
                    if (progetto != null)
                    {
                        if (segnature_provider.Find(progetto.IdProgetto, "NRI", null, null).Count == 0)
                        {
                            SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                            if (impresa != null)
                            {
                                SiarLibrary.Protocollo comunicazione = new SiarLibrary.Protocollo(Bando.CodEnte);
                                comunicazione.setCorrispondente(impresa, progetto.IdProgetto, "destinatario");
                                comunicazione.setDocumento("comunicazione_non_ricevibilita_domanda_nr_" + progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaComunicazione.FileFirmato));

                                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione);
                                string oggetto = "Comunicazione di non ricevibilita domanda di aiuto nr. " + progetto.IdProgetto
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
                                    segnatura_comunicazione.CodTipo = "NRI";
                                    segnatura_comunicazione.Operatore = Operatore.Utente.CfUtente;
                                    segnature_provider.Save(segnatura_comunicazione);
                                    ShowMessage("Comunicazione di non ricevibilità firmata e protocollata correttamente.");
                                }
                                catch (Exception ex)
                                {
                                    string oggettoEmail = "Errore in comunicazione di non ricevibilita domande";
                                    string testEmail = "Domanda: " + progetto.IdProgetto + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                                    EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                                    throw ex;
                                }
                            }
                            else ShowError("L'impresa titolare della domanda è inesistente. Impossibile continuare.");
                        }
                        else ShowError("La comunicazione di ricevibilita per la domanda " + progetto.IdProgetto + " è gia' stata effettuata.");
                    }
                    else ShowError("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per e segnalare il problema urgentemente.");
                }
                else ShowError("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per e segnalare il problema urgentemente.");
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaComunicazione.FileFirmato = null; }
        }
    }
}