using SiarBLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class Valutazione : SiarLibrary.Web.IstruttoriaPage
    {
        SiarBLL.ProgettoValutazioneCollectionProvider valutazione_provider = new SiarBLL.ProgettoValutazioneCollectionProvider();
        SiarBLL.GraduatoriaProgettiDettaglioCollectionProvider graduatoria_provider = null;

        SiarBLL.NoteCollectionProvider note_provider = new SiarBLL.NoteCollectionProvider();
        SiarBLL.PrioritaCollectionProvider priorita_provider = new SiarBLL.PrioritaCollectionProvider();
        SiarBLL.ProgettoValutatoriCollectionProvider valutatori_progetto_provider = new SiarBLL.ProgettoValutatoriCollectionProvider();
        SiarBLL.BandoValutatoriCollectionProvider valutatori_bando_provider = new SiarBLL.BandoValutatoriCollectionProvider();

        SiarLibrary.ProgettoValutazione valutazione = null;
        SiarLibrary.BandoValutatoriCollection bando_valutatori = null;
        SiarLibrary.ProgettoValutatoriCollection progetto_valutatori = null;
        SiarLibrary.BandoValutatori operatore_valutazione = null;
        SiarLibrary.ProgettoValutatori progetto_valutatore = null;
        SiarLibrary.Progetto progetto = null;

        SiarLibrary.ProgettoValutazioneAllegati allegato_selezionato = null;
        SiarBLL.ProgettoValutazioneAllegatiCollectionProvider allegati_provider;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            graduatoria_provider = new SiarBLL.GraduatoriaProgettiDettaglioCollectionProvider(valutazione_provider.DbProviderObj);
            int id_progetto;
            if (int.TryParse(Request.QueryString["iddom"], out id_progetto))
                progetto = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);

            allegati_provider = new SiarBLL.ProgettoValutazioneAllegatiCollectionProvider();
            int id_axp;
            if (int.TryParse(hdnAllegatoSelezionato.Value, out id_axp)) allegato_selezionato = allegati_provider.GetById(id_axp);

            if (progetto == null || ((progetto.IdProgIntegrato != null && progetto.IdProgIntegrato != progetto.IdProgetto)))
                Redirect("Ammissibilita.aspx", "La domanda di aiuto selezionata non è valida.", true);
            // progetto in uno stato non ancora ricevibile
            else
            {
                AbilitaModifica = false;
                SiarLibrary.ProgettoValutazioneCollection vCollection = valutazione_provider.Find(progetto.IdProgetto, null, true, null, false);
                if (vCollection.Count != 0)
                    valutazione = vCollection[0];
                else
                    valutazione = null;
                if (progetto.OrdineFase < 2 || valutazione == null)
                    Redirect("Ammissibilita.aspx", "La domanda di aiuto selezionata si trova in una fase per cui non può ancora essere valutata.", true);
                else
                {
                    ucInfoDomanda.Progetto = progetto;
                    tbFile.Visible = true;
                    hdnIdValutazione.Value = valutazione.Id;
                    // controllo se l'utente corrente è valutatore del bando in oggetto
                    bando_valutatori = valutatori_bando_provider.Find(null, Bando.IdBando, null, null, null);
                    progetto_valutatori = valutatori_progetto_provider.Find(valutazione.Id, null);
                    SiarLibrary.BandoValutatoriCollection bvc = bando_valutatori.SubSelect(null, progetto.IdBando,
                            Operatore.Utente.IdUtente, null, null, null, null, null);
                    if (bvc.Count > 0)
                    {
                        operatore_valutazione = bvc[0];
                        SiarLibrary.ProgettoValutatoriCollection v = progetto_valutatori.SubSelect(null, null, operatore_valutazione.IdValutatore, true, null);
                        if (v.Count > 0)
                            progetto_valutatore = v[0];
                        AbilitaModifica = valutazione.OrdineFirma == 0 && operatore_valutazione.Presidente;
                        ucFirmaDocumento.DocumentoFirmatoEvent = btnProtocolla_Click;
                    }
                    else if (Operatore.Utente.Profilo == "Membro del comitato di valutazione")
                        Redirect("../pdomanda/ricercadomanda.aspx", "L'utente non dispone dei permessi per visualizzare la pagina.", true);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (valutazione.OrdineFirma == 0 && operatore_valutazione != null && operatore_valutazione.Presidente)
            {
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                progetto_provider.CalcoloPunteggiAutomaticiDomandaDiAiuto(progetto.IdProgetto, null, 1, Operatore.Utente.CfUtente);
            }

            SiarLibrary.GraduatoriaProgettiDettaglioCollection graduatorie = graduatoria_provider.GetGraduatoriaProgettiDettaglioValutazione(progetto.IdProgetto);
            dgPriorita.DataSource = graduatorie;
            dgPriorita.Titolo = "Elementi trovati: " + graduatorie.Count.ToString();
            dgPriorita.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
            dgPriorita.MostraTotalePunteggio("DataField", 2);
            dgPriorita.DataBind();

            SiarLibrary.ProgettoValutatoriCollection valutatori = valutatori_progetto_provider.GetValutatoriProgetto(valutazione.Id);
            dgValutatori.DataSource = valutatori;
            dgValutatori.Titolo = "Elementi trovati: " + valutatori.Count.ToString();
            dgValutatori.ItemDataBound += new DataGridItemEventHandler(dgValutatori_ItemDataBound);
            dgValutatori.DataBind();

            SiarLibrary.ProgettoValutazioneAllegatiCollection allegati_domanda = allegati_provider.Find(hdnIdValutazione.Value, progetto.IdProgetto, null);
            dgAllegatiValutazione.DataSource = allegati_domanda;
            dgAllegatiValutazione.Titolo = "Elementi trovati: " + allegati_domanda.Count;
            dgAllegatiValutazione.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgAllegatiValutazione_ItemDataBound);
            dgAllegatiValutazione.DataBind();

            if (valutazione.IdNote != null)
            {
                SiarLibrary.Note n = note_provider.GetById(valutazione.IdNote);
                if (n != null) txtNote.Text = n.Testo;
            }

            btnAmmissibilita.Attributes.Add("onclick", "location='checklistammissibilita.aspx?iddom="
                + progetto.IdProgetto + "'");
            if (valutazione.Segnatura != null)
            {
                btnVisualizzaVerbale.Disabled = false;
                btnVisualizzaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + valutazione.Segnatura + "');");
            }
            if (allegato_selezionato != null)
            {
                txtNADescrizioneBreve.Text = allegato_selezionato.Descrizione;
                ufcNAAllegato.IdFile = allegato_selezionato.IdFile;
            }
            base.OnPreRender(e);
        }

        void dgPriorita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                SiarLibrary.GraduatoriaProgettiDettaglio g = (SiarLibrary.GraduatoriaProgettiDettaglio)e.Item.DataItem;
                e.Item.Cells[1].Text = g.AdditionalAttributes["DESCRIZIONE"];
                string nome_casella = "txtPunteggio" + "_" + g.AdditionalAttributes["ID_PRIORITA"];
                string valore = Request.Form[nome_casella + "_text"];
                if (g.Punteggio != null && !Page.IsPostBack) valore = g.Punteggio;
                string disabled = "";
                if (g.AdditionalAttributes["FLAG_MANUALE"] == "0")
                    disabled = "disabled='disabled'";
                e.Item.Cells[2].Text = "<span id=\"" + nome_casella + "\" class=\"PunteggioBox\" style=\"display:inline-block;width:124px;\">"
                    + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                    + "_text\" style=\"text-align:right;WIDTH:100px;\" " + disabled + " value='" + valore + "'/></span>";
            }
        }

        void dgValutatori_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                SiarLibrary.ProgettoValutatori v = (SiarLibrary.ProgettoValutatori)e.Item.DataItem;
                e.Item.Cells[1].Text = v.AdditionalAttributes["NOMINATIVO"];

                if (v.Presente)
                {
                    if (v.Ordine < valutazione.OrdineFirma + 1)
                    {
                        if (Operatore.Utente.IdUtente == bando_valutatori.SubSelect(v.IdValutatore, null, null, null, null, null, null,
                            null)[0].IdUtente && bando_valutatori.SubSelect(v.IdValutatore, null, null, null, null, null, null,
                            null)[0].Presidente && valutazione.Segnatura == null)
                        {
                            HtmlInputButton btnProtocolla = new HtmlInputButton();
                            btnProtocolla.Value = "Forza protocollo";
                            btnProtocolla.Attributes.Add("class", "Button");
                            btnProtocolla.Attributes.Add("onclick", "protocollaClick();");
                            btnProtocolla.Style.Add("width", "200px");
                            e.Item.Cells[4].Controls.Add(btnProtocolla);
                        }
                        else
                        {
                            e.Item.Cells[4].Text = "<img src='" + Request.ApplicationPath + "/images/visto.gif'>";
                        }
                    }
                    else if (v.Ordine == valutazione.OrdineFirma + 1 && valutazione.Segnatura == null)
                    {
                        if (Operatore.Utente.IdUtente == bando_valutatori.SubSelect(v.IdValutatore, null, null, null, null, null, null,
                            null)[0].IdUtente)
                        {
                            HtmlInputButton btnFirma = new HtmlInputButton();
                            btnFirma.Value = "Firma";
                            btnFirma.Attributes.Add("class", "Button");
                            btnFirma.Attributes.Add("onclick", "firmaClick();");
                            btnFirma.Style.Add("margin-right", "20px");
                            btnFirma.Style.Add("width", "200px");
                            e.Item.Cells[4].Controls.Add(btnFirma);
                        }
                        else if (v.Ordine < progetto_valutatori.Count && progetto_valutatori.SubSelect(null, null, null, null, v.Ordine + 1).Count > 0 &&
                            Operatore.Utente.IdUtente == bando_valutatori.SubSelect(progetto_valutatori.SubSelect(null, null, null, true, v.Ordine + 1)[0].IdValutatore, null, null, null, null, null, null, null)[0].IdUtente && valutazione.Segnatura == null)
                            e.Item.Cells[4].Text = "<img src='" + Request.ApplicationPath + "/images/reload.gif' style='cursor: pointer;' onclick='location.reload();'>";
                        else if (valutazione.Segnatura == null) e.Item.Cells[4].Text = "in attesa di firma";
                    }
                    else if (valutazione.Segnatura == null) e.Item.Cells[4].Text = "in attesa del turno";
                    else e.Item.Cells[4].Text = "firma non più necessaria";
                }

                SiarLibrary.Web.CurrencyBox txt = new SiarLibrary.Web.CurrencyBox();
                txt.ID = "ordineValutatore" + v.IdValutatore;
                txt.Width = new Unit(60);
                if (v.Ordine != null) txt.Text = v.Ordine;
                if (v.Ordine == 1)
                {
                    txt.Enabled = false;
                    txt.ReadOnly = true;
                }
                e.Item.Cells[2].Controls.Add(txt);

                CheckBox chk = new CheckBox();
                chk.ID = "chkPresente" + v.IdValutatore;
                bool b = false;
                if (v.Presente != null) bool.TryParse(v.Presente.ToString(), out b);
                chk.Checked = b;
                if (v.Ordine == 1)
                {
                    chk.Enabled = false;
                }
                e.Item.Cells[3].Controls.Add(chk);
            }
        }

        //void dgValutatori_ItemDataBound(object sender, DataGridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        //    {
        //        SiarLibrary.ProgettoValutatori v = (SiarLibrary.ProgettoValutatori)e.Item.DataItem;
        //        e.Item.Cells[1].Text = v.AdditionalAttributes["NOMINATIVO"];
        //        if (v.Ordine < valutazione.OrdineFirma + 1)
        //            e.Item.Cells[2].Text = "<img src='" + Request.ApplicationPath + "/images/visto.gif'>";
        //        else if (v.Ordine == valutazione.OrdineFirma + 1)
        //        {
        //            if (Operatore.Utente.IdUtente == bando_valutatori.SubSelect(v.IdValutatore, null, null, null, null, null, null,
        //                null)[0].IdUtente)
        //            {
        //                HtmlInputButton btnFirma = new HtmlInputButton();
        //                btnFirma.Value = "Firma";
        //                btnFirma.Attributes.Add("class", "Button");
        //                btnFirma.Attributes.Add("onclick", "firmaClick();");
        //                btnFirma.Style.Add("margin-right", "20px");
        //                btnFirma.Style.Add("width", "200px");
        //                e.Item.Cells[2].Controls.Add(btnFirma);
        //            }
        //            else if (v.Ordine < bando_valutatori.Count && bando_valutatori.SubSelect(null, null, null, null, null, null, null, v.Ordine + 1).Count > 0 && Operatore.Utente.IdUtente == bando_valutatori.SubSelect(null, null, null, null, null, null, null, v.Ordine + 1)[0].IdUtente)
        //                e.Item.Cells[2].Text = "<img src='" + Request.ApplicationPath + "/images/reload.gif' style='cursor: pointer;' onclick='location.reload();'>";
        //            else e.Item.Cells[2].Text = "in attesa di firma";
        //        }
        //        else e.Item.Cells[2].Text = "in attesa del turno";
        //    }
        //}

        protected void btnSalvaValutatori_Click(object sender, EventArgs e)
        {
            try
            {
                valutatori_progetto_provider.DbProviderObj.BeginTran();
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.ProgettoValutatoriCollection nuovi_valutatori = new SiarLibrary.ProgettoValutatoriCollection();
                foreach (SiarLibrary.ProgettoValutatori p in progetto_valutatori)
                {
                    int ordine = 0;
                    bool presente = false;

                    foreach (string s in Request.Form.AllKeys)
                    {
                        if (s.Contains("ordineValutatore" + p.IdValutatore))
                        {
                            string valore = Request.Form[s];
                            if (!string.IsNullOrEmpty(valore))
                            {
                                ordine = int.Parse(valore);
                            }
                            else
                                throw new Exception("Inserire un valore per l'ordine.");
                        }

                        if (s.Contains("chkPresente" + p.IdValutatore))
                        {
                            string valore = Request.Form[s];
                            if (valore == "on") presente = true;
                        }
                    }

                    p.Presente = presente;
                    if (presente)
                        p.Ordine = ordine;
                    else
                        p.Ordine = 0;
                    nuovi_valutatori.Add(p);
                }
                if (checkOrdineCollection(nuovi_valutatori))
                {
                    valutatori_progetto_provider.SaveCollection(nuovi_valutatori);
                    valutatori_progetto_provider.DbProviderObj.Commit();
                    ShowMessage("Valutatori salvati correttamente;");
                }
                else
                    throw new Exception("Inserire i valutatori con un ordine corretto e completo.");
            }
            catch (Exception exc) { valutatori_progetto_provider.DbProviderObj.Rollback(); ShowError(exc); }
        }

        private bool checkOrdineCollection(SiarLibrary.ProgettoValutatoriCollection nuovi_valutatori)
        {
            nuovi_valutatori.Sort("Ordine");
            bool ordineCorretto = true;
            int ordineOld = 0;
            foreach (SiarLibrary.ProgettoValutatori p in nuovi_valutatori)
            {
                if (p.Presente)
                {
                    int diff = p.Ordine - ordineOld;
                    if (diff == 0 || diff > 1)
                        ordineCorretto = false;
                    ordineOld = p.Ordine;
                }
            }
            return ordineCorretto;
        }

        protected void btnSalvaValutazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (ucInfoDomanda.Progetto.CodStato != "I" &&
                ucInfoDomanda.DomandaInRiesame == false &&
                ucInfoDomanda.DomandaInRevisione == false &&
                ucInfoDomanda.DomandaInRicorso == false &&
                ucInfoDomanda.DomandaInIstruttoriaProvinciale == false) throw new Exception("La domanda in oggetto non si trova nello stato procedurale corretto, impossibile continuare.");
                if (valutazione == null) throw new Exception("Il progetto non è stato predisposto alla valutazione, impossibile continuare.");
                valutazione_provider.DbProviderObj.BeginTran();

                SiarLibrary.GraduatoriaProgettiDettaglioCollection graduatorie = graduatoria_provider.
                    GetGraduatoriaProgettiDettaglioValutazione(progetto.IdProgetto);
                graduatoria_provider.DeleteCollection(graduatoria_provider.Find(null, progetto.IdProgetto, null));
                foreach (SiarLibrary.GraduatoriaProgettiDettaglio gp in graduatorie)
                {
                    decimal valore;
                    if (decimal.TryParse(Request.Form["txtPunteggio" + "_" + gp.IdPriorita + "_text"], out valore))
                    {
                        SiarLibrary.GraduatoriaProgettiDettaglio gp_new = new SiarLibrary.GraduatoriaProgettiDettaglio();
                        gp_new.IdPriorita = gp.IdPriorita;
                        gp_new.IdProgetto = progetto.IdProgetto;
                        gp_new.Punteggio = valore;
                        gp_new.DataValutazione = DateTime.Now;
                        gp_new.Operatore = Operatore.Utente.CfUtente;
                        gp_new.ModificaManuale = false;
                        graduatoria_provider.Save(gp_new);
                    }
                }
                valutazione.DataModifica = DateTime.Now;
                valutazione.Operatore = Operatore.Utente.IdUtente;
                if (string.IsNullOrEmpty(txtNote.Text)) valutazione.IdNote = null;
                else
                {
                    SiarLibrary.Note n = null;
                    if (valutazione.IdNote != null) n = note_provider.GetById(valutazione.IdNote);
                    if (n == null) n = new SiarLibrary.Note();
                    n.Testo = txtNote.Text;
                    note_provider.Save(n);
                    valutazione.IdNote = n.Id;
                }
                valutazione_provider.Save(valutazione);
                valutazione_provider.DbProviderObj.Commit();
                ShowMessage("Valutazione salvata correttamente");

            }
            catch (Exception exc) { valutazione_provider.DbProviderObj.Rollback(); ShowError(exc); }
        }

        protected void btnFirma_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucInfoDomanda.Progetto.CodStato != "I" &&
                ucInfoDomanda.DomandaInRiesame == false &&
                ucInfoDomanda.DomandaInRevisione == false &&
                ucInfoDomanda.DomandaInRicorso == false &&
                ucInfoDomanda.DomandaInIstruttoriaProvinciale == false) throw new Exception("La domanda in oggetto non si trova nello stato procedurale corretto, impossibile continuare.");
                if (valutazione == null) throw new Exception("Il progetto non è stato predisposto alla valutazione, impossibile continuare.");
                if (progetto_valutatore == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (valutazione.OrdineFirma > 0)
                {
                    if (valutazione.IdFile != null) ucFirmaDocumento.IdFileFirmato = valutazione.IdFile;
                    else throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                }
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, progetto.IdProgetto);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnForzaProtocollo_Click(object sender, EventArgs e)
        {
            try
            {
                valutazione_provider.DbProviderObj.BeginTran();

                if (ucInfoDomanda.Progetto.CodStato != "I" &&
                ucInfoDomanda.DomandaInRiesame == false &&
                ucInfoDomanda.DomandaInRevisione == false &&
                ucInfoDomanda.DomandaInRicorso == false &&
                ucInfoDomanda.DomandaInIstruttoriaProvinciale == false) throw new Exception("La domanda in oggetto non si trova nello stato procedurale corretto, impossibile continuare.");
                if (valutazione == null) throw new Exception("Il progetto non è stato predisposto alla valutazione, impossibile continuare.");
                if (progetto_valutatore == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (valutazione.OrdineFirma > 0)
                {
                    if (valutazione.IdFile != null) ucFirmaDocumento.IdFileFirmato = valutazione.IdFile;
                    else throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                }

                ucFirmaDocumento.loadDocumentoSenzaFirma(Operatore.Utente.CfUtente, progetto.IdProgetto);

                try
                {
                    SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(Bando.CodEnte);
                    SiarLibrary.ArchivioFile file = new SiarBLL.ArchivioFileCollectionProvider().GetById(valutazione.IdFile);

                    documento_interno.setDocumento("valutazione_domanda_" + progetto.IdProgetto + ".pdf", file.Contenuto);

                    string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione);
                    string oggetto = "Checklist VALUTAZIONE per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                        + "\n Partita IVA: " + ucInfoDomanda.Impresa.Cuaa
                        + "\n Ragione sociale: " + ucInfoDomanda.Impresa.RagioneSociale
                        + "\n N° Domanda SIGEF: " + progetto.IdProgetto;

                    SiarLibrary.ArchivioFileCollection ff = valutazione_provider.GetFileXProtocollazioneNoStreamValutazione(valutazione.Id);

                    System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

                    foreach (SiarLibrary.ArchivioFile f in ff)
                    {
                        try
                        {
                            SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                            all.Descrizione = f.NomeCompleto;
                            all.Documento = new SiarBLL.paleoWebService.File();
                            all.Documento.NomeFile = f.NomeFile;

                            System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                            allegatoProtocollo.Add("allegato", all);
                            allegatoProtocollo.Add("id_file", f.Id);
                            allegatoProtocollo.Add("tipo_origine", "valutazione");
                            allegatoProtocollo.Add("id_origine", valutazione.Id);
                            allegatiProtocollo.Add(allegatoProtocollo);

                        }
                        catch (Exception ex) { }
                    }

                    foreach (SiarLibrary.ArchivioFile f in ff)
                    {
                        try
                        {
                            documento_interno.addAllegato(f.NomeFile, f.HashCode);
                        }
                        catch (Exception ex) { }
                    }

                    string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                    valutazione.Segnatura = identificativo_paleo;

                    string[] doc_number_array;
                    string doc_number = null;

                    doc_number_array = identificativo_paleo.Split('|');
                    doc_number = doc_number_array[0];

                    documento_interno.addAllegatiDocInterno(allegatiProtocollo, identificativo_paleo, doc_number);
                }
                catch (Exception exc)
                {
                    string oggettoEmail = "Errore nella valutazione del progetto nr." + progetto.IdProgetto;
                    string testEmail = "\nErrore: " + exc.Message;
                    EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                    throw;
                }

                valutazione_provider.Save(valutazione);

                valutazione_provider.DbProviderObj.Commit();
                ShowMessage("Valutazione protocollata correttamente dall'Operatore " + Operatore.Utente.Nominativo);
            }
            catch (Exception ex)
            {
                valutazione_provider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }

        //protected void btnProt_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ucInfoDomanda.Progetto.CodStato != "I" &&
        //        ucInfoDomanda.DomandaInRiesame == false &&
        //        ucInfoDomanda.DomandaInRevisione == false &&
        //        ucInfoDomanda.DomandaInRicorso == false &&
        //        ucInfoDomanda.DomandaInIstruttoriaProvinciale == false) throw new Exception("La domanda in oggetto non si trova nello stato procedurale corretto, impossibile continuare.");
        //        if (valutazione == null) throw new Exception("Il progetto non è stato predisposto alla valutazione, impossibile continuare.");
        //        if (operatore_valutazione == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
        //        if (valutazione.OrdineFirma > 0)
        //        {
        //            if (valutazione.IdFile != null) ucFirmaDocumento.IdFileFirmato = valutazione.IdFile;
        //            else throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
        //        }
        //        ucFirmaDocumento.FirmaObbligatoria = false;
        //        ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, progetto.IdProgetto);
        //    }
        //    catch (Exception ex) { ShowError(ex); }
        //}

        protected void btnProtocolla_Click(object sender, EventArgs e)
        {
            try
            {
                if (progetto_valutatore == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (ucInfoDomanda.Progetto.CodStato != "I" &&
                ucInfoDomanda.DomandaInRiesame == false &&
                ucInfoDomanda.DomandaInRevisione == false &&
                ucInfoDomanda.DomandaInRicorso == false &&
                ucInfoDomanda.DomandaInIstruttoriaProvinciale == false) throw new Exception("La domanda in oggetto non si trova nello stato procedurale corretto, impossibile continuare.");
                if (valutazione == null) throw new Exception("Il progetto non è stato predisposto alla valutazione, impossibile continuare.");
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato)) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");

                valutazione_provider.DbProviderObj.BeginTran();

                if (progetto_valutatore.Ordine == valutazione.OrdineFirma + 1)
                {
                    valutazione.OrdineFirma += 1;
                    valutazione.DataModifica = DateTime.Now;
                    valutazione.Operatore = Operatore.Utente.IdUtente;

                    SiarBLL.ArchivioFileCollectionProvider file_provider = new SiarBLL.ArchivioFileCollectionProvider(valutazione_provider.DbProviderObj);
                    SiarLibrary.ArchivioFile af = null;
                    if (valutazione.IdFile != null) af = file_provider.GetById(valutazione.IdFile);
                    else
                    {
                        af = new SiarLibrary.ArchivioFile();
                        af.Tipo = "application/pdf";
                        af.NomeFile = "valutazione_" + valutazione.IdProgetto + ".pdf";
                        af.NomeCompleto = "valutazione_" + valutazione.IdProgetto + ".pdf";
                    }
                    af.Contenuto = Convert.FromBase64String(ucFirmaDocumento.FileFirmato);
                    af.Dimensione = Convert.FromBase64String(ucFirmaDocumento.FileFirmato).Length;

                    HashAlgorithm alg = HashAlgorithm.Create("SHA256");
                    byte[] fileHashValue = alg.ComputeHash(Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
                    string hash_code = BinaryToHex(fileHashValue);

                    af.HashCode = hash_code;
                    file_provider.Save(af);
                    valutazione.IdFile = af.Id;
                }
                else /*if (1 == 2)*/
                    throw new Exception("Non è il turno di firma di questo operatore.");
                if (valutazione.OrdineFirma == progetto_valutatori.SubSelect(null, null, null, true, null).Count)
                {
                    try
                    {
                        SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(Bando.CodEnte);
                        documento_interno.setDocumento("valutazione_domanda_" + progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                        string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione);
                        string oggetto = "Checklist VALUTAZIONE per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                            + "\n Partita IVA: " + ucInfoDomanda.Impresa.Cuaa
                            + "\n Ragione sociale: " + ucInfoDomanda.Impresa.RagioneSociale
                            + "\n N° Domanda SIGEF: " + progetto.IdProgetto;

                        SiarLibrary.ArchivioFileCollection ff = valutazione_provider.GetFileXProtocollazioneNoStreamValutazione(valutazione.Id);

                        System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

                        foreach (SiarLibrary.ArchivioFile f in ff)
                        {
                            try
                            {
                                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                                all.Descrizione = f.NomeCompleto;
                                all.Documento = new SiarBLL.paleoWebService.File();
                                all.Documento.NomeFile = f.NomeFile;

                                System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                                allegatoProtocollo.Add("allegato", all);
                                allegatoProtocollo.Add("id_file", f.Id);
                                allegatoProtocollo.Add("tipo_origine", "valutazione");
                                allegatoProtocollo.Add("id_origine", valutazione.Id);
                                allegatiProtocollo.Add(allegatoProtocollo);

                            }
                            catch (Exception ex) { }
                        }

                        foreach (SiarLibrary.ArchivioFile f in ff)
                        {
                            try
                            {
                                documento_interno.addAllegato(f.NomeFile, f.HashCode);
                            }
                            catch (Exception ex) { }
                        }

                        string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                        valutazione.Segnatura = identificativo_paleo;

                        string[] doc_number_array;
                        string doc_number = null;

                        doc_number_array = identificativo_paleo.Split('|');
                        doc_number = doc_number_array[0];

                        documento_interno.addAllegatiDocInterno(allegatiProtocollo, identificativo_paleo, doc_number);
                    }
                    catch (Exception exc)
                    {
                        string oggettoEmail = "Errore nella valutazione del progetto nr." + progetto.IdProgetto;
                        string testEmail = "\nErrore: " + exc.Message;
                        EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                        throw;
                    }
                }

                valutazione_provider.Save(valutazione);

                valutazione_provider.DbProviderObj.Commit();
                if (valutazione.OrdineFirma < progetto_valutatori.SubSelect(null, null, null, true, null).Count)
                    ShowMessage("Valutazione firmata correttamente dall'Operatore " + Operatore.Utente.Nominativo);
                else ShowMessage("Valutazione firmata e protocollata correttamente dall'Operatore " + Operatore.Utente.Nominativo);
            }
            catch (Exception ex)
            {
                valutazione_provider.DbProviderObj.Rollback();
                ShowError(ex);
            }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }

        void dgAllegatiValutazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoValutazioneAllegati a = (SiarLibrary.ProgettoValutazioneAllegati)e.Item.DataItem;
                if (a.IdFile == null) e.Item.Cells[2].Text = "";
            }
        }

        protected void btnSalvaAllegato_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (allegato_selezionato == null)
                    allegato_selezionato = new SiarLibrary.ProgettoValutazioneAllegati();
                if (ufcNAAllegato.IdFile == null) throw new Exception("Nessun allegato inserito. Impossibile continuare.");
                allegato_selezionato.Descrizione = txtNADescrizioneBreve.Text;
                allegato_selezionato.IdValutazione = hdnIdValutazione.Value;
                allegato_selezionato.IdFile = ufcNAAllegato.IdFile;
                allegato_selezionato.IdProgetto = progetto.IdProgetto;
                allegati_provider.Save(allegato_selezionato);
                ShowMessage("Allegato associato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (allegato_selezionato == null || allegato_selezionato.IdProgetto != progetto.IdProgetto) throw new Exception("L'allegato selezionato non è valido.");
                allegati_provider.Delete(allegato_selezionato);
                ShowMessage("Allegato eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovoPost_Click(object sender, EventArgs e)
        {
            ufcNAAllegato.IdFile = null;
        }

        protected void btnDettaglioAllegatoPost_Click(object sender, EventArgs e) { }

        private string BinaryToHex(byte[] data)
        {
            char[] hex = new char[data.Length * 2];

            for (int iter = 0; iter < data.Length; iter++)
            {
                byte hexChar = ((byte)(data[iter] >> 4));
                hex[iter * 2] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
                hexChar = ((byte)(data[iter] & 0xF));
                hex[(iter * 2) + 1] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
            }
            return new string(hex);
        }

        protected void btnProtocollaAllegati_Click(object sender, EventArgs e)
        {
            try
            {
                int id_valutazione;
                int.TryParse(hdnIdValutazione.Value, out id_valutazione);

                SiarLibrary.ProgettoValutazione v = valutazione_provider.GetById(id_valutazione);

                SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(Bando.CodEnte);
                System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();
                // cerco gli allegati non protocollati

                SiarLibrary.Protocollo doc = new SiarLibrary.Protocollo();

                var docs = doc.GetAllegatiProtocollo(v.Segnatura);

                List<string> hashCodes = new List<string>();


                foreach (SiarBLL.paleoWebService.Allegato f in docs)
                {
                    if (f.Documento.Stream == null)
                        hashCodes.Add(f.Documento.Impronta);
                }

                SiarBLL.ArchivioFileCollectionProvider archivioProvider = new SiarBLL.ArchivioFileCollectionProvider();

                foreach (string s in hashCodes)
                {
                    SiarLibrary.ArchivioFileCollection ff = archivioProvider.Find(null, null, s);
                    if (ff.Count > 0)
                    {
                        var f = ff[0];
                        //protocollo.addAllegato(f.NomeFile + "." + f.Tipo, f.Contenuto, f.Tipo);
                        SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                        all.Descrizione = f.NomeFile;
                        all.Documento = new SiarBLL.paleoWebService.File();
                        all.Documento.NomeFile = f.NomeFile;

                        System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                        allegatoProtocollo.Add("allegato", all);
                        allegatoProtocollo.Add("id_file", f.Id);
                        allegatoProtocollo.Add("tipo_origine", "valutazione");
                        allegatoProtocollo.Add("id_origine", id_valutazione);
                        allegatiProtocollo.Add(allegatoProtocollo);
                    }
                }

                string[] doc_number_array;
                string doc_number = null;

                doc_number_array = v.Segnatura.Value.Split('|');
                doc_number = doc_number_array[0];

                protocolloAll.addAllegatiDocInterno(allegatiProtocollo, v.Segnatura, doc_number);                

                ShowMessage("Allegati protocollati correttamente.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}