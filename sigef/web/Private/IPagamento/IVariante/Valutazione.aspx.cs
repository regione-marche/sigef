using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SiarBLL;

namespace web.Private.IPagamento.IVariante
{
    public partial class Valutazione : SiarLibrary.Web.IstruttoriaVariantePage
    {
        SiarBLL.ProgettoValutazioneCollectionProvider valutazione_provider = new SiarBLL.ProgettoValutazioneCollectionProvider();
        SiarBLL.VariantiXPrioritaCollectionProvider variantiXpriotita_provider = null;

        SiarBLL.NoteCollectionProvider note_provider;
        SiarBLL.PrioritaCollectionProvider priorita_provider = new SiarBLL.PrioritaCollectionProvider();
        SiarBLL.ProgettoValutatoriCollectionProvider valutatori_progetto_provider = new SiarBLL.ProgettoValutatoriCollectionProvider();
        SiarBLL.BandoValutatoriCollectionProvider valutatori_bando_provider = new SiarBLL.BandoValutatoriCollectionProvider();

        SiarLibrary.ProgettoValutazione valutazione = null;
        SiarLibrary.BandoValutatoriCollection bando_valutatori = null;
        SiarLibrary.ProgettoValutatoriCollection progetto_valutatori = null;
        SiarLibrary.BandoValutatori operatore_valutazione = null;
        SiarLibrary.ProgettoValutatori progetto_valutatore = null;


        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ipagamento_varianti";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            variantiXpriotita_provider = new SiarBLL.VariantiXPrioritaCollectionProvider(valutazione_provider.DbProviderObj);
            note_provider = new SiarBLL.NoteCollectionProvider(valutazione_provider.DbProviderObj);
            if (Variante == null)
                Redirect("Riepilogo.aspx", "La variante selezionata non è valida.", true);
            // progetto in uno stato non ancora ricevibile
            else
            {
                AbilitaModifica = false;
                SiarLibrary.ProgettoValutazioneCollection vCollection = valutazione_provider.Find(Variante.IdProgetto, Variante.IdVariante, null, null, false);
                if (vCollection.Count == 0) Redirect("Riepilogo.aspx", "La variante non è stata ancora predisposta alla valutazione.", true);

                else
                {
                    valutazione = vCollection[0];
                    // controllo se l'utente corrente è valutatore del bando in oggetto

                    bando_valutatori = valutatori_bando_provider.Find(null, Progetto.IdBando, null, null, null);
                    progetto_valutatori = valutatori_progetto_provider.Find(valutazione.Id, null);
                    SiarLibrary.BandoValutatoriCollection bvc = bando_valutatori.SubSelect(null, Progetto.IdBando,
                            Operatore.Utente.IdUtente, null, null, null, null, null);
                    if (bvc.Count > 0)
                    {
                        operatore_valutazione = bvc[0];
                        var progettoValutatoriCollection = progetto_valutatori.SubSelect(null, null, operatore_valutazione.IdValutatore, true, null);
                        if (progettoValutatoriCollection.Count > 0)
                        {
                            progetto_valutatore = progettoValutatoriCollection[0];
                            AbilitaModifica = valutazione.OrdineFirma == 0 && operatore_valutazione.Presidente;
                            ucFirmaDocumento.DocumentoFirmatoEvent = btnProtocolla_Click;
                        }
                    }
                    else if (Operatore.Utente.Profilo == "Membro del comitato di valutazione")
                        Redirect("../pdomanda/ricercadomanda.aspx", "L'utente non dispone dei permessi per visualizzare la pagina.", true);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.VariantiXPrioritaCollection variantiXpriorita = variantiXpriotita_provider.GetVariantiPerPriorita(Variante.IdVariante);
            dgPriorita.DataSource = variantiXpriorita;
            dgPriorita.Titolo = "Elementi trovati: " + variantiXpriorita.Count.ToString();
            dgPriorita.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
            dgPriorita.MostraTotalePunteggio("DataField", 2);
            dgPriorita.DataBind();

            SiarLibrary.ProgettoValutatoriCollection valutatori = valutatori_progetto_provider.GetValutatoriProgetto(valutazione.Id);
            dgValutatori.DataSource = valutatori;
            dgValutatori.Titolo = "Elementi trovati: " + valutatori.Count.ToString();
            dgValutatori.ItemDataBound += new DataGridItemEventHandler(dgValutatori_ItemDataBound);
            dgValutatori.DataBind();

            if (Variante.SegnaturaApprovazione != null)
            {
                btnSalvaValutazione.Enabled = false;
                btnSalvaValutatori.Enabled = false;
            }

            if (valutazione.IdNote != null)
            {
                SiarLibrary.Note n = note_provider.GetById(valutazione.IdNote);
                if (n != null) txtNote.Text = n.Testo;
            }

            btnVariante.Attributes.Add("onclick", "location='FirmaRichiesta.aspx?idVar="
                + Variante.IdVariante + "&iddom=" + Variante.IdProgetto + "'");
            if (valutazione.Segnatura != null)
            {
                btnVisualizzaVerbale.Disabled = false;
                btnVisualizzaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + valutazione.Segnatura + "');");
            }
            base.OnPreRender(e);
        }

        void dgPriorita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                SiarLibrary.VariantiXPriorita g = (SiarLibrary.VariantiXPriorita)e.Item.DataItem;
                e.Item.Cells[1].Text = g.AdditionalAttributes["DESCRIZIONE"];
                string nome_casella = "txtPunteggio" + "_" + g.AdditionalAttributes["ID_PRIORITA"];
                string valore = Request.Form[nome_casella + "_text"];
                if (g.Punteggio != null && !Page.IsPostBack) valore = g.Punteggio;
                e.Item.Cells[2].Text = "<span id=\"" + nome_casella + "\" class=\"PunteggioBox\" style=\"display:inline-block;width:124px;\">"
                    + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                    + "_text\" style=\"text-align:right;WIDTH:100px;\" value='" + valore + "'/></span>";
            }
        }

        void dgValutatori_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                SiarLibrary.ProgettoValutatori v = (SiarLibrary.ProgettoValutatori)e.Item.DataItem;
                e.Item.Cells[1].Text = v.AdditionalAttributes["NOMINATIVO"];

                //if (v.Presente && Variante.SegnaturaApprovazione == null)
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
                if (Variante.Annullata) throw new Exception("La variante è stata annullata, impossibile continuare.");
                if (valutazione == null) throw new Exception("La variante non è stata predisposta alla valutazione, impossibile continuare.");
                valutazione_provider.DbProviderObj.BeginTran();

                SiarLibrary.VariantiXPrioritaCollection variantiXpriorita = variantiXpriotita_provider.GetVariantiPerPriorita(Variante.IdVariante);
                variantiXpriotita_provider.DeleteCollection(variantiXpriotita_provider.Find(Variante.IdVariante, null));
                foreach (SiarLibrary.VariantiXPriorita vp in variantiXpriorita)
                {
                    decimal valore;
                    if (decimal.TryParse(Request.Form["txtPunteggio" + "_" + vp.IdPriorita + "_text"], out valore))
                    {
                        SiarLibrary.VariantiXPriorita vp_new = new SiarLibrary.VariantiXPriorita();
                        vp_new.IdPriorita = vp.IdPriorita;
                        vp_new.IdProgetto = vp.IdProgetto;
                        vp_new.IdVariante = Variante.IdVariante;
                        vp_new.Punteggio = valore;
                        vp_new.DataValutazione = DateTime.Now;
                        vp_new.Operatore = Operatore.Utente.CfUtente;
                        vp_new.FlagDefinitivo = false;
                        variantiXpriotita_provider.Save(vp_new);
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
                if (Variante.Annullata) throw new Exception("La domanda in oggetto non si trova nello stato procedurale corretto, impossibile continuare.");
                if (valutazione == null) throw new Exception("Il progetto non è stato predisposto alla valutazione, impossibile continuare.");
                if (progetto_valutatore == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (valutazione.OrdineFirma > 0)
                {
                    if (valutazione.IdFile != null) ucFirmaDocumento.IdFileFirmato = valutazione.IdFile;
                    else throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                }
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, Variante.IdProgetto, Variante.IdVariante);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnForzaProtocollo_Click(object sender, EventArgs e)
        {
            try
            {
                valutazione_provider.DbProviderObj.BeginTran();

                if (Variante.Annullata) throw new Exception("La domanda in oggetto non si trova nello stato procedurale corretto, impossibile continuare.");
                if (valutazione == null) throw new Exception("Il progetto non è stato predisposto alla valutazione, impossibile continuare.");
                if (progetto_valutatore == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (valutazione.OrdineFirma > 0)
                {
                    if (valutazione.IdFile != null) ucFirmaDocumento.IdFileFirmato = valutazione.IdFile;
                    else throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                }

                ucFirmaDocumento.loadDocumentoSenzaFirma(Operatore.Utente.CfUtente, Variante.IdProgetto, Variante.IdVariante);

                try
                {
                    SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                    SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(b.CodEnte);
                    SiarLibrary.ArchivioFile file = new SiarBLL.ArchivioFileCollectionProvider().GetById(valutazione.IdFile);
                    documento_interno.setDocumento("valutazione_domanda_" + Variante.IdProgetto + ".pdf", file.Contenuto);

                    string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                    string oggetto = "Checklist VALUTAZIONE per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                        + "\n Partita IVA: " + IVariantiControl.Impresa.Cuaa
                        + "\n Ragione sociale: " + IVariantiControl.Impresa.RagioneSociale
                        + "\n N° Domanda SIGEF: " + Variante.IdProgetto;
                    string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);                   

                    valutazione.Segnatura = identificativo_paleo;
                }
                catch (Exception exc)
                {
                    string oggettoEmail = "Errore nella valutazione del progetto nr." + Variante.IdProgetto;
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

        protected void btnProtocolla_Click(object sender, EventArgs e)
        {
            try
            {
                if (progetto_valutatore == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (Variante.Annullata) throw new Exception("La domanda in oggetto non si trova nello stato procedurale corretto, impossibile continuare.");
                if (valutazione == null) throw new Exception("Il progetto non è stato predisposto alla valutazione, impossibile continuare.");
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato)) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");


                valutazione_provider.DbProviderObj.BeginTran();
                if (progetto_valutatore.Ordine == valutazione.OrdineFirma + 1)
                {
                    valutazione.OrdineFirma += 1;

                    SiarBLL.ArchivioFileCollectionProvider file_provider = new SiarBLL.ArchivioFileCollectionProvider(valutazione_provider.DbProviderObj);
                    SiarLibrary.ArchivioFile af = null;
                    if (valutazione.IdFile != null) af = file_provider.GetById(valutazione.IdFile);
                    else
                    {
                        af = new SiarLibrary.ArchivioFile();
                        af.Tipo = "application/pdf";
                        af.NomeFile = "valutazione_" + valutazione.IdProgetto;
                        af.NomeCompleto = "valutazione progetto " + valutazione.IdProgetto;
                    }
                    af.Contenuto = Convert.FromBase64String(ucFirmaDocumento.FileFirmato);
                    af.Dimensione = Convert.FromBase64String(ucFirmaDocumento.FileFirmato).Length;
                    file_provider.Save(af);
                    valutazione.IdFile = af.Id;
                }
                else
                    throw new Exception("Non è il turno di firma di questo operatore.");
                if (valutazione.OrdineFirma == progetto_valutatori.SubSelect(null, null, null, true, null).Count)
                {
                    try
                    {
                        SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                        SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(b.CodEnte);
                        documento_interno.setDocumento("valutazione_domanda_" + Variante.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                        string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                        string oggetto = "Checklist VALUTAZIONE per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                            + "\n Partita IVA: " + IVariantiControl.Impresa.Cuaa 
                            + "\n Ragione sociale: " + IVariantiControl.Impresa.RagioneSociale
                            + "\n N° Domanda SIGEF: " + Variante.IdProgetto;
                        string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                        valutazione.Segnatura = identificativo_paleo;
                    }
                    catch (Exception exc)
                    {
                        string oggettoEmail = "Errore nella valutazione del progetto nr." + Progetto.IdProgetto;
                        string testEmail = "\nErrore: " + exc.Message;
                        EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                        throw;
                    }
                }

                valutazione.DataModifica = DateTime.Now;
                valutazione.Operatore = Operatore.Utente.IdUtente;
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
    }
}
