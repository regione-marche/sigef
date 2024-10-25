using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SiarBLL;

namespace web.Private.Istruttoria
{
    public partial class ChecklistRevisione : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "revisione_domande";
            base.OnPreInit(e);
        }

        SiarBLL.ProgettoSegnatureCollectionProvider segnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider();
        SiarBLL.IterProgettoCollectionProvider iter_provider = new SiarBLL.IterProgettoCollectionProvider();
        SiarLibrary.IterProgettoCollection iter;
        SiarLibrary.ProgettoSegnature documento_revisione;

        protected void Page_Load(object sender, EventArgs e)
        {
            int iddomanda;
            if (Int32.TryParse(Request.QueryString["iddom"], out iddomanda))
            {
                ucFirmaRevisione.DocumentoFirmatoEvent = btnPostBack_Click;
                ucInfoDomanda.Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(iddomanda);
                iter = iter_provider.Find(iddomanda, null, null, null, Bando.IdBando, "A", null);
                documento_revisione = segnature_provider.GetById(iddomanda, "REV");
                if (documento_revisione != null) lblIdPaleo.Text = documento_revisione.Segnatura;
                else btnVisualizza.Enabled = false;
                SiarLibrary.BandoResponsabiliCollection revisore = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando,
                  null, ucInfoDomanda.Progetto.ProvinciaDiPresentazione , null, true ) ;
                //SiarLibrary.ResponsabiliXBandoCollection revisore = new SiarBLL.ResponsabiliXBandoCollectionProvider().Find(null, Bando.IdBando,
                //    null, null, null).FiltroProvincia(ucInfoDomanda.Progetto.ProvinciaDiPresentazione, null);
                // filtro provincia non corretto dovrebbe prendere la provincia di assegnazione di istruttori della domanda
                if (revisore.Count == 0) Redirect("RevisioneDomande.aspx");
                else
                {
                    AbilitaModifica = (AbilitaModifica && documento_revisione == null
                        &&  Operatore.Utente.IdUtente == revisore[0].IdUtente );
                    btnDefinitiva.Disabled = !AbilitaModifica;
                }
            }
            else Redirect("RevisioneDomande.aspx");
        }

        protected override void OnPreRender(EventArgs e)
        {
            dgSteps.DataSource = iter;
            dgSteps.DataBind();
            base.OnPreRender(e);
        }

        protected void dgSteps_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.IterProgetto step = (SiarLibrary.IterProgetto)dgi.DataItem;
                dgi.Cells[4].Text = "<b>Esito:</b> " + step.EsitoIstruttore + "<br /><b>Note:</b> "
                    + (step.Note != null ? "<a href=\"javascript:showPopupNote(" + step.Ordine + ")\">Visualizza</a><input type='hidden' id='hdnNoteStep" + step.Ordine + "' value=\"" + step.Note + "\">" : "non presenti");

                SiarLibrary.Web.ComboSiNo comboEsitoStep = (SiarLibrary.Web.ComboSiNo)dgi.Cells[6].FindControl("lstEsitoStep");
                if (comboEsitoStep != null)
                {
                    #region hidden con nome combo
                    HtmlInputHidden hdn = new HtmlInputHidden();
                    hdn.ID = "hdnEsitoStep" + step.IdStep;
                    hdn.Value = comboEsitoStep.UniqueID;
                    dgi.Cells[6].Controls.Add(hdn);
                    #endregion
                    if (step.CodEsitoRevisore != null)
                    {
                        ListItem li = comboEsitoStep.Items.FindByValue(step.CodEsitoRevisore);
                        if (li != null) li.Selected = true;
                    }
                    if (step.NoteRevisore != null)
                    {
                        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                        doc.LoadXml(dgi.Cells[7].Text);
                        System.Xml.XmlNode nodo = doc.GetElementsByTagName("textarea").Item(0);
                        nodo.InnerText = step.NoteRevisore;
                        dgi.Cells[7].Text = doc.InnerXml;
                    }
                }
                #region Url
                if (!string.IsNullOrEmpty(step.Url))
                {
                    HyperLink newHL = new HyperLink();
                    newHL.Text = "Pagina di modifica dei dati";
                    newHL.NavigateUrl = step.Url + "&iddom=" + step.IdProgetto;
                    dgi.Cells[5].Controls.Add(newHL);
                }
                #endregion
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (iter != null && iter.Count > 0)
            {
                try
                {
                    foreach (SiarLibrary.IterProgetto step in iter)
                    {
                        string hdn = "hdnEsitoStep" + step.IdStep;
                        foreach (string s in Request.Form.AllKeys)
                        {
                            if (s.EndsWith(hdn))
                            {
                                string nome_combo = Request.Form[s];
                                step.CodEsitoRevisore = Request.Form[nome_combo];
                                break;
                            }
                        }
                        string nome_textarea = "txtAreaLungaCKL" + step.IdStep + "_text";
                        step.NoteRevisore = Request.Form[nome_textarea];
                        step.Revisore = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente;
                        step.DataRevisore = DateTime.Now;
                    }
                    iter_provider.SaveCollection(iter);
                    ShowMessage("Esiti del revisore salvati correttamente.");
                }
                catch (Exception ex) { ShowError(ex); }
            }
        }

        protected void btnFirmaRevisione_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucInfoDomanda.DomandaInRiesame)
                    throw new Exception("La domanda è già in istruttoria per il riesame. Operazione annullata.");
                SiarLibrary.BandoResponsabiliCollection revisore = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando,
                  null, ucInfoDomanda.Progetto.ProvinciaDiPresentazione, null, true);
                //SiarLibrary.ResponsabiliXBandoCollection revisore = new SiarBLL.ResponsabiliXBandoCollectionProvider().Find(null, Bando.IdBando,
                //    null, null, null).FiltroProvincia(ucInfoDomanda.Progetto.ProvinciaDiPresentazione, null);
                if (revisore.Count > 0)
                {
                    if (revisore[0].IdUtente != ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente)
                        throw new Exception("Solo il responsabile provinciale di istruttoria è abilitato alla firma del documento.");
                }
                else
                    throw new Exception("Solo il responsabile provinciale di istruttoria è abilitato alla firma del documento.");

                ucFirmaRevisione.loadDocumento(((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, ucInfoDomanda.Progetto.IdProgetto);
            }
            catch (Exception ex) { ShowError(ex); }

        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaRevisione.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                if (ucInfoDomanda.Progetto != null)
                {
                    if (!ucInfoDomanda.DomandaInRiesame)
                    {
                        if (documento_revisione == null)
                        {
                            SiarLibrary.Protocollo revisione = new SiarLibrary.Protocollo(Bando.CodEnte);
                            revisione.setDocumento("checklist_revisione_domanda_nr_" + ucInfoDomanda.Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaRevisione.FileFirmato));

                            string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, ucInfoDomanda.Progetto.ProvinciaDiPresentazione);
                            var impresa = new SiarBLL.ImpresaCollectionProvider().GetById(ucInfoDomanda.Progetto.IdImpresa);
                            string oggetto = "Checklist di revisione istruttoria della domanda di aiuto nr. " + ucInfoDomanda.Progetto.IdProgetto
                                + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: " + Bando.DataScadenza + "\n" + ss[3] 
                                + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                                + "\n Ragione sociale: " + impresa.RagioneSociale;
                            string identificativo_paleo = revisione.DocumentoInterno(oggetto, ss[4]);

                            bool riapri_domanda = false;
                            foreach (SiarLibrary.IterProgetto i in iter)
                                if (i.CodEsito != i.CodEsitoRevisore) { riapri_domanda = true; break; }
                            try
                            {
                                SiarLibrary.ProgettoSegnature segnatura_revisione = new SiarLibrary.ProgettoSegnature();
                                segnatura_revisione.Segnatura = identificativo_paleo;
                                segnatura_revisione.IdProgetto = ucInfoDomanda.Progetto.IdProgetto;
                                segnatura_revisione.Data = DateTime.Now;
                                segnatura_revisione.RiapriDomanda = riapri_domanda;
                                segnatura_revisione.CodTipo = "REV";
                                segnatura_revisione.Operatore = Operatore.Utente.CfUtente;
                                segnature_provider.Save(segnatura_revisione);
                            }
                            catch (Exception ex)
                            {
                                string oggettoEmail = "Errore in checklist di revisione domande";
                                string testEmail = "Domanda: " + ucInfoDomanda.Progetto.IdProgetto + "\nSegnatura: " + identificativo_paleo + "\n\n" + ex.Message;
                                EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                                ShowError(ex);
                            }
                            ShowMessage("Checklist di revisione firmata e protocollata correttamente. "
                                + (riapri_domanda ? "La domanda è stata riaperta in ammissibilità, è ora possibile reistruirla." :
                                "La checklist salvata conferma tutti gli esiti dell'istruttore, la domanda non verrà riaperta."));
                            btnDefinitiva.Disabled = true;
                            btnSave.Enabled = false;
                            btnVisualizza.Enabled = true;
                            lblIdPaleo.Text = identificativo_paleo.Replace("ID:", "").Trim();
                        }
                        else ShowError("Attenzione!", "La checklist di revisione della domanda è gia' stata resa definitiva. Operazione annullata.");
                    }
                    else ShowError("Attenzione!", "La domanda è già in istruttoria per il riesame. Operazione annullata.");
                }
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaRevisione.FileFirmato = null; }
        }
        protected void btnVisualizza_Click(object sender, EventArgs e)
        {
            try
            {
                documento_revisione = segnature_provider.GetById(ucInfoDomanda.Progetto.IdProgetto, "REV");
                if (documento_revisione == null) throw new Exception("Nessun documento da visualizzare.");
                SiarLibrary.Protocollo doc = new SiarLibrary.Protocollo();
                byte[] b = doc.RicercaProtocollo(documento_revisione.Segnatura, false);
                Session.Add("doc", b);
                RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}