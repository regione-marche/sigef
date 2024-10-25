using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.Istruttoria
{
    public partial class AllegatiEsiti : SiarLibrary.Web.IstruttoriaPage
    {
        SiarBLL.ProgettoAllegatiCollectionProvider allegati_provider = new SiarBLL.ProgettoAllegatiCollectionProvider();
        SiarLibrary.ProgettoAllegatiCollection allegati;
        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
        SiarBLL.ProgettoComunicazioniCollectionProvider progCom_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarBLL.ProgettoComunicazioniAllegatiCollectionProvider progComAll_provider = new SiarBLL.ProgettoComunicazioniAllegatiCollectionProvider();
        SiarLibrary.ProgettoComunicazioniCollection progCom_Coll;

        SiarLibrary.Progetto _progetto = null;
        System.Collections.Generic.Dictionary<string, string> valori_esiti = null;
        int id_progetto;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Request.QueryString["iddom"], out id_progetto)) _progetto = progetto_provider.GetById(id_progetto);
                if (_progetto == null || _progetto.IdBando != Bando.IdBando || (_progetto.IdProgIntegrato != null && _progetto.IdProgIntegrato != _progetto.IdProgetto))
                    throw new Exception("La domanda di aiuto selezionata non è valida.");
                ucInfoDomanda.Progetto = _progetto;
                controlloOperatoreStatoProgetto();
                allegati = allegati_provider.Find(_progetto.IdProgetto, null);

                valori_esiti = SiarLibrary.DbStaticProvider.GetEsitiStep();
            }
            catch (Exception ex) { Redirect("Ammissibilita.aspx", ex.Message, true); }
        }

        private void controlloOperatoreStatoProgetto()
        {
            if (AbilitaModifica)
            {
                if (!_progetto.CodStato.FindValueIn("L", "I") && !ucInfoDomanda.DomandaInRiesame
                    && !ucInfoDomanda.DomandaInRevisione && !ucInfoDomanda.DomandaInRicorso) AbilitaModifica = false;
                else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, _progetto.IdProgetto,
                        Operatore.Utente.IdUtente, null, true).Count == 0) AbilitaModifica = false;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            dgAllegato.DataSource = allegati;
            dgAllegato.ItemDataBound += new DataGridItemEventHandler(dgAllegato_ItemDataBound);
            dgAllegato.SetTitoloNrElementi();
            dgAllegato.DataBind();
            txtNumProtocollo.Text = _progetto.SegnaturaAllegati;

            progCom_Coll = progCom_provider.Find(null, id_progetto, null, null, null, "P").FiltroComunicazioniDomandaAiuto (true,true);
            dgComunicazioniInviate.DataSource = progCom_Coll;
            dgComunicazioniInviate.ItemDataBound += new DataGridItemEventHandler(dgComunicazioniInviate_ItemDataBound);
            dgComunicazioniInviate.SetTitoloNrElementi();
            dgComunicazioniInviate.DataBind();
            base.OnPreRender(e);
        }

        void dgAllegato_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoAllegati a = (SiarLibrary.ProgettoAllegati)e.Item.DataItem;
                switch (a.CodTipo.Value)
                {
                    case "C": e.Item.Cells[2].Text = a.Allegato.IsNullAlt(a.DescrizioneBreve); e.Item.Cells[3].Text = ""; break;
                    case "D": e.Item.Cells[2].Text = "<b>Categoria:</b> " + a.Allegato + "<br><b>Breve descrizione:</b> " + a.DescrizioneBreve; break;
                    case "S":
                        e.Item.Cells[2].Text = "<b>Categoria:</b> " + a.Allegato + "<br><b>Estremi documento:</b> "
                                               + "<br /><b>Nr.</b> " + a.Numero + " <b>del</b> " + a.Data + "<br /><b>Presso:</b> " + a.Ente
                                               + "<br /><b>Descrizione:</b> " + a.DescrizioneBreve;
                        e.Item.Cells[3].Text = ""; break;
                }
                if (a.GiaPresentato && a.IdFile == null) e.Item.Cells[3].Text = "Già presentato";
                SiarLibrary.Web.Combo lst = new SiarLibrary.Web.Combo();
                lst.ID = "lstEsitoAllegato" + a.Id;
                //lst.Width = new Unit(130);
                lst.Items.Add("");
                foreach (System.Collections.Generic.KeyValuePair<string, string> de in valori_esiti)
                    lst.Items.Add(new ListItem(de.Key, de.Value));
                lst.SelectedValue = a.CodEsitoIstruttoria;
                e.Item.Cells[4].Controls.Add(lst);
                SiarLibrary.Web.TextArea txt = new SiarLibrary.Web.TextArea();
                txt.ID = "txtNoteAllegato" + a.Id;
                txt.Width = new Unit(360);
                txt.Rows = 3;
                txt.Text = a.NoteIstruttoria;
                e.Item.Cells[5].Controls.Add(txt);
            }
        }

        void dgComunicazioniInviate_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoComunicazioni c = (SiarLibrary.ProgettoComunicazioni)e.Item.DataItem;
                if (string.IsNullOrEmpty(c.Segnatura))
                    if (c.PredispostaAllaFirma)
                        e.Item.Cells[5].Text = "Predisposta alla firma";
                    else e.Item.Cells[5].Text = "In lavorazione";
                else e.Item.Cells[5].Text = "Richiesta Inviata";
                string url = "RichiestaCertificazione";
                if (c.CodTipo == "DNT") url = "RichiestaDocumentiIntegrativi";
                e.Item.Cells[6].Text = "<input type='button' class='btn btn-secondary py-1' " +
                    "onclick=\"location='" + url + ".aspx?idcom=" + c.Id + "'\" value='Dettaglio' />";
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SiarLibrary.ProgettoAllegati a in allegati)
                {
                    string cod_esito = null, note = null;
                    foreach (string s in Request.Form.AllKeys)
                    {
                        if (s.EndsWith("lstEsitoAllegato" + a.Id)) cod_esito = Request.Form[s];
                        else if (s.EndsWith("txtNoteAllegato" + a.Id + "_text")) note = Request.Form[s];
                    }
                    a.CodEsitoIstruttoria = cod_esito;
                    a.NoteIstruttoria = note;
                }
                allegati_provider.SaveCollection(allegati);
                // commentata perche' non c'e' piu' la busta chiusa ma gli allegati sono digitali
                //_progetto.SegnaturaAllegati = txtNumProtocollo.Text;
                //new SiarBLL.ProgettoCollectionProvider(allXprogettoProvider.DbProviderObj).Save(_progetto);
                ShowMessage("Istruttoria degli allegati salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRichiestaCertificazione_Click(object sender, EventArgs e)
        {
            try
            {
                string[] als = ((SiarLibrary.Web.CheckColumnAgid)dgAllegato.Columns[6]).GetSelected();
                if (als.Length == 0)
                    throw new Exception("Attenzione! Selezionare almeno un allegato.");
                string ente = null;
                foreach (string a in als)
                {
                    int id_all = int.Parse(a);
                    SiarLibrary.ProgettoAllegati alleg = new SiarLibrary.ProgettoAllegati();
                    alleg = allegati_provider.GetById(a);
                    if (alleg != null)
                    {
                        if (alleg.CodTipo != "S")
                            throw new Exception("Attenzione, è possibile selezionare solo le dichiarazioni sostitutive.");
                        if (alleg.IdComune.IsNullAlt(alleg.CodEnteEmettitore) != null)
                        {
                            if (ente != null)
                            {
                                if (ente != alleg.IdComune.IsNullAlt(alleg.CodEnteEmettitore))
                                    throw new Exception("Attenzione, è possibile selezionare solo dichiarazioni per lo stesso ente.");
                            }
                            else ente = alleg.IdComune.IsNullAlt(alleg.CodEnteEmettitore);
                        }
                    }
                }
                SiarLibrary.ProgettoComunicazioni pc = new SiarLibrary.ProgettoComunicazioni();
                pc.IdProgetto = id_progetto;
                pc.CodTipo = "RCC"; // cambiare in base al tipo di comunicazione 
                pc.PredispostaAllaFirma = false;
                pc.Direzione = "P";
                pc.Data = DateTime.Now;
                pc.Operatore = Operatore.Utente.IdUtente;
                progCom_provider.Save(pc);
                foreach (string a in als)
                {
                    SiarLibrary.ProgettoComunicazioniAllegati pcAll = new SiarLibrary.ProgettoComunicazioniAllegati();
                    int id_all = int.Parse(a);
                    pcAll.IdComunicazione = pc.Id;
                    pcAll.IdProgettoAllegati = id_all;
                    progComAll_provider.Save(pcAll);
                }
                Redirect("RichiestaCertificazione.aspx" + "?idcom=" + pc.Id);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected void btnRichiestaDocumentiIntegrativi_Click(object sender, EventArgs e)
        {
            try
            {
                string[] als = ((SiarLibrary.Web.CheckColumnAgid)dgAllegato.Columns[6]).GetSelected();
                foreach (string a in als)
                {
                    int id_all = int.Parse(a);
                    SiarLibrary.ProgettoAllegati alleg = new SiarLibrary.ProgettoAllegati();
                    alleg = allegati_provider.GetById(a);
                    if (alleg != null)
                    {
                        if (alleg.CodTipo == "S")
                            throw new Exception("Attenzione, NON è possibile selezionare le dichiarazioni sostitutive.");
                    }
                }
                SiarLibrary.ProgettoComunicazioni pc = new SiarLibrary.ProgettoComunicazioni();
                pc.IdProgetto = id_progetto;
                pc.CodTipo = "DNT"; // cambiare in base al tipo di comunicazione 
                pc.PredispostaAllaFirma = false;
                pc.Direzione = "P";
                pc.Data = DateTime.Now;
                pc.Operatore = Operatore.Utente.IdUtente;
                progCom_provider.Save(pc);
                foreach (string a in als)
                {
                    SiarLibrary.ProgettoComunicazioniAllegati pcAll = new SiarLibrary.ProgettoComunicazioniAllegati();
                    int id_all = int.Parse(a);
                    pcAll.IdComunicazione = pc.Id;
                    pcAll.IdProgettoAllegati = id_all;
                    progComAll_provider.Save(pcAll);
                }
                Redirect("RichiestaDocumentiIntegrativi.aspx" + "?idcom=" + pc.Id);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}
