using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaAllegati : SiarLibrary.Web.IstruttoriaPagamentoPage
    {

        SiarBLL.ProgettoComunicazioniCollectionProvider progCom_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarBLL.ProgettoComunicazioniDocumentiCollectionProvider progComDoc_provider = new SiarBLL.ProgettoComunicazioniDocumentiCollectionProvider();
        SiarBLL.DomandaPagamentoAllegatiCollectionProvider allegati_provider;
        SiarLibrary.DomandaPagamentoAllegatiCollection allegati;
        SiarLibrary.ProgettoComunicazioniCollection progCom_Coll;
        SiarLibrary.ProgettoComunicazioniDocumenti pcDoc;
        SiarBLL.IntegrazioniPerDomandaDiPagamentoCollectionProvider integrazione_provider;
        SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider;

        System.Collections.Generic.Dictionary<string, string> valori_esiti = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            allegati_provider = new SiarBLL.DomandaPagamentoAllegatiCollectionProvider(PagamentoProvider.DbProviderObj);
            allegati = allegati_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
            valori_esiti = SiarLibrary.DbStaticProvider.GetEsitiStep();
            integrazione_provider = new SiarBLL.IntegrazioniPerDomandaDiPagamentoCollectionProvider();
            integrazione_singola_provider = new SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Request.QueryString["redir"] == "revisione") btnBack.Attributes["onclick"] = "javascript:location='Revisionedomande.aspx?&idpag="
                + DomandaPagamento.IdDomandaPagamento + "'";
            txtNumProtocollo.ReadOnly = DomandaPagamento.CodTipo != "ANT";
            txtNumProtocollo.Text = DomandaPagamento.SegnaturaAllegati;
            dgAllegati.DataSource = allegati;
            if (allegati.Count == 0) btnSalva.Enabled = false;
            dgAllegati.ItemDataBound += new DataGridItemEventHandler(dgAllegati_ItemDataBound);
            dgAllegati.SetTitoloNrElementi();
            dgAllegati.DataBind();

            progCom_Coll = progCom_provider.Find(Bando.IdBando, DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null, null, "P");
            dgComunicazioniInviate.DataSource = progCom_Coll;
            dgComunicazioniInviate.ItemDataBound += new DataGridItemEventHandler(dgComunicazioniInviate_ItemDataBound);
            dgComunicazioniInviate.SetTitoloNrElementi();
            dgComunicazioniInviate.DataBind();

            txtDataIntegrazione.Text = new SiarLibrary.NullTypes.DatetimeNT(DateTime.Now);

            if (AbilitaModifica)
                trIntegrazioneDomanda.Visible = true;

            base.OnPreRender(e);
        }

        void dgAllegati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.DomandaPagamentoAllegati allegato = (SiarLibrary.DomandaPagamentoAllegati)dgi.DataItem;

                switch (allegato.Formato.Value)
                {
                    case "C":
                        e.Item.Cells[2].Text += "<b>Breve descrizione:</b> " + allegato.Descrizione;
                        if(allegato.DataInserimento != null)
                            e.Item.Cells[2].Text += "<br><b>Data inserimento:</b> " + allegato.DataInserimento;

                        e.Item.Cells[3].Text = "";

                        break;
                    case "D":
                        e.Item.Cells[2].Text += 
                            "<b>Categoria:</b> " + allegato.TipologiaDocumento 
                            + "<br><b>Breve descrizione:</b> " + allegato.Descrizione;
                        if (allegato.DataInserimento != null)
                            e.Item.Cells[2].Text += "<br><b>Data inserimento:</b> " + allegato.DataInserimento;

                        break;
                    case "S":
                        e.Item.Cells[2].Text += 
                            "<b>Categoria:</b> " + allegato.TipologiaDocumento 
                            + "<br><b>Estremi documento:</b> "
                            + "<br /><b>Nr.</b> " + allegato.Numero + " <b>del</b> " + allegato.Data 
                            + "<br /><b>Presso:</b> " + allegato.Ente
                            + "<br /><b>Descrizione:</b> " + allegato.Descrizione;
                        if (allegato.DataInserimento != null)
                            e.Item.Cells[2].Text += "<br><b>Data inserimento:</b> " + allegato.DataInserimento;

                        e.Item.Cells[3].Text = "";
                        break;
                }
                //Formato allegato
                HiddenField hd = new HiddenField();
                hd.ID = "hdnFormato" + allegato.IdAllegato;
                hd.Value = allegato.Formato.Value;
                dgi.Cells[4].Controls.Add(hd);
                //ComboEsitoStep
                SiarLibrary.Web.ComboEsiti cb = new SiarLibrary.Web.ComboEsiti();
                cb.ID = "lstEsito" + allegato.IdAllegato;
                cb.DataBind();
                cb.SelectedValue = allegato.CodEsito;
                dgi.Cells[4].Controls.Add(cb);

                //testo area
                SiarLibrary.Web.TextArea ta = new SiarLibrary.Web.TextArea();
                ta.Rows = 3;
                ta.Width = new Unit(360);
                ta.ID = "txtNote" + allegato.IdAllegato;
                ta.Text = allegato.NoteIstruttore;
                dgi.Cells[5].Controls.Add(ta);
            }
        }
        void dgComunicazioniInviate_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string esito = "Richiesta Inviata"; string url = "RichiestaCertificazione";
                SiarLibrary.ProgettoComunicazioni c = (SiarLibrary.ProgettoComunicazioni)e.Item.DataItem;
                if (string.IsNullOrEmpty(c.Segnatura)) esito = (c.PredispostaAllaFirma ? "Predisposta alla firma" : "In lavorazione");
                e.Item.Cells[5].Text = esito;
                if (c.CodTipo == "DNT") url = "RichiestaDocumentiIntegrativi";
                e.Item.Cells[6].Text = "<input type='button' class='ButtonGrid' style='width:70px' " +
                    "onclick=\"location='" + url + ".aspx?idcom=" + c.Id + "'\" value='Dettaglio' />";
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();
                //aggiorno la segnatura
                DomandaPagamento.SegnaturaAllegati = txtNumProtocollo.Text;
                PagamentoProvider.Save(DomandaPagamento);
                //salvo le valutazioni
                foreach (SiarLibrary.DomandaPagamentoAllegati all in allegati)
                {
                    string codEsito = null, note = null;
                    foreach (string s in Request.Form.AllKeys)
                    {
                        if (s.EndsWith("lstEsito" + all.IdAllegato)) codEsito = Request.Form[s];
                        else if (s.EndsWith("txtNote" + all.IdAllegato + "_text")) note = Request.Form[s];
                    }
                    all.CodEsito = codEsito;
                    all.NoteIstruttore = note;
                    all.CfModifica = Operatore.Utente.CfUtente;
                    all.DataModifica = DateTime.Now;
                    allegati_provider.Save(all);
                }
                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Valutazione degli allegati salvata corettamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnRichiestaCertificazione_Click(object sender, EventArgs e)
        {
            string ente = null;
            SiarLibrary.DomandaPagamentoAllegati alleg;
            try
            {
                string[] als = ((SiarLibrary.Web.CheckColumn)dgAllegati.Columns[6]).GetSelected();
                if (als.Length == 0) throw new Exception("Attenzione! Selezionare almeno un allegato.");
                foreach (string a in als)
                {
                    int id_all = int.Parse(a);
                    alleg = new SiarLibrary.DomandaPagamentoAllegati();
                    alleg = allegati_provider.GetById(a);
                    if (alleg != null)
                    {
                        if (alleg.Formato != "S") throw new Exception("Attenzione, è possibile richiedere la certificazione solo per le dichiarazioni sostitutive.");
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
                pc.IdProgetto = DomandaPagamento.IdProgetto;
                pc.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                pc.CodTipo = "RCC"; // cambiare in base al tipo di comunicazione 
                pc.PredispostaAllaFirma = false;
                pc.Direzione = "P";
                pc.Data = DateTime.Now;
                pc.Operatore = Operatore.Utente.IdUtente;
                progCom_provider.Save(pc);
                foreach (string a in als)
                {
                    pcDoc = new SiarLibrary.ProgettoComunicazioniDocumenti();
                    int id_all = int.Parse(a);
                    pcDoc.IdComunicazione = pc.Id;
                    pcDoc.IdDomandaPagamentoAllegati = id_all;
                    progComDoc_provider.Save(pcDoc);
                }
                Redirect("RichiestaCertificazione.aspx" + "?idcom=" + pc.Id);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRichiediIntegrazioneAllegati_Click(object sender, EventArgs e)
        {
            string error = SiarBLL.IntegrazioniDomandaPagamentoUtility.creaNuovaIntegrazione(DomandaPagamento, "ALL", Operatore.Utente,
                        txtNoteIntegrazioneAllegati.Text, txtDataIntegrazione.Text);

            if (error != null && error.Equals(""))
                ShowMessage("Richiesta di integrazione allegati inserita.");
            else
                ShowError(error);
        }

        protected void btnRichiestaDocumentiIntegrativi_Click(object sender, EventArgs e)
        {
            int id_all; string formato = "";
            try
            {
                string[] als = ((SiarLibrary.Web.CheckColumn)dgAllegati.Columns[6]).GetSelected();
                foreach (string a in als)
                {
                    id_all = int.Parse(a);
                    foreach (string s in Request.Form.AllKeys)
                        if (s.EndsWith("hdnFormato" + id_all))
                        {
                            formato = Request.Form[s]; 
                            if (formato == "S") throw new Exception("Attenzione, NON è possibile richiedere documenti integrativi per le dichiarazioni sostitutive(S).");
                            break;
                        }
                }
                SiarLibrary.ProgettoComunicazioni pc = new SiarLibrary.ProgettoComunicazioni();
                pc.IdProgetto = DomandaPagamento.IdProgetto;
                pc.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                pc.CodTipo = "DNT"; // cambiare in base al tipo di comunicazione 
                pc.PredispostaAllaFirma = false;
                pc.Direzione = "P";
                pc.Data = DateTime.Now;
                pc.Operatore = Operatore.Utente.IdUtente;
                progCom_provider.Save(pc);
                foreach (string a in als)
                {
                    pcDoc = new SiarLibrary.ProgettoComunicazioniDocumenti();
                    id_all = int.Parse(a);
                    pcDoc.IdComunicazione = pc.Id;
                    pcDoc.IdDomandaPagamentoAllegati = id_all;
                    progComDoc_provider.Save(pcDoc);
                }
                Redirect("RichiestaDocumentiIntegrativi.aspx" + "?idcom=" + pc.Id);
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}