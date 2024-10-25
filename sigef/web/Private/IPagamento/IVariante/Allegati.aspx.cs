using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento.IVariante
{
    public partial class Allegati : SiarLibrary.Web.IstruttoriaVariantePage
    {
        SiarBLL.ProgettoComunicazioniCollectionProvider progCom_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarBLL.ProgettoComunicazioniDocumentiCollectionProvider progComDoc_provider = new SiarBLL.ProgettoComunicazioniDocumentiCollectionProvider();
        SiarBLL.VariantiAllegatiCollectionProvider allegati_provider;
        SiarLibrary.VariantiAllegatiCollection allegatiColl = new SiarLibrary.VariantiAllegatiCollection();
        SiarLibrary.ProgettoComunicazioniCollection progCom_Coll;
        SiarLibrary.ProgettoComunicazioniDocumenti pcDoc;

        System.Collections.Generic.Dictionary<string, string> valori_esiti = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            allegati_provider = new SiarBLL.VariantiAllegatiCollectionProvider(VarianteProvider.DbProviderObj);
            allegatiColl = allegati_provider.Find(Variante.IdVariante, null, null);
            valori_esiti = SiarLibrary.DbStaticProvider.GetEsitiStep();
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtNumProtocollo.Text = Variante.SegnaturaAllegati;
            dgAllegati.DataSource = allegatiColl;
            dgAllegati.ItemDataBound += new DataGridItemEventHandler(dgAllegati_ItemDataBound);
            dgAllegati.SetTitoloNrElementi();
            dgAllegati.DataBind();

            progCom_Coll = progCom_provider.Find(Progetto.IdBando, Variante.IdProgetto, null, Variante.IdVariante, null, "P");
            dgComunicazioniInviate.DataSource = progCom_Coll;
            dgComunicazioniInviate.ItemDataBound += new DataGridItemEventHandler(dgComunicazioniInviate_ItemDataBound);
            dgComunicazioniInviate.SetTitoloNrElementi();
            dgComunicazioniInviate.DataBind();

            if (Variante.CodTipo.FindValueIn("VI", "AR"))
            {
                ShowError("Non sono previsti allegati per la tipologia della presente variante.");
                btnSalva.Enabled = btnRichiestaCertificazione.Enabled =btnRichiestaDocumentiIntegrativi.Enabled = false;
            }
            base.OnPreRender(e);
        }

        void dgAllegati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.VariantiAllegati allegato = (SiarLibrary.VariantiAllegati)dgi.DataItem;
                switch (allegato.Formato.Value)
                {
                    case "C": e.Item.Cells[2].Text = allegato.Descrizione.IsNullAlt(allegato.Descrizione); e.Item.Cells[3].Text = ""; break;
                    case "D": e.Item.Cells[2].Text = "<b>Categoria:</b> " + allegato.TipologiaDocumento + "<br><b>Breve descrizione:</b> " + allegato.Descrizione; break;
                    case "S": e.Item.Cells[2].Text = "<b>Categoria:</b> " + allegato.TipologiaDocumento + "<br><b>Estremi documento:</b> "
                                               + "<br /><b>Nr.</b> " + allegato.Numero + " <b>del</b> " + allegato.Data + "<br /><b>Presso:</b> " + allegato.Ente
                                               + "<br /><b>Descrizione:</b> " + allegato.Descrizione;
                        e.Item.Cells[3].Text = ""; break;
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
                string esito = "Richiesta Inviata"; string url = "RichiestaCertificazioneVariante";
                SiarLibrary.ProgettoComunicazioni c = (SiarLibrary.ProgettoComunicazioni)e.Item.DataItem;
                if (string.IsNullOrEmpty(c.Segnatura)) esito = (c.PredispostaAllaFirma ? "Predisposta alla firma" : "In lavorazione");
                e.Item.Cells[5].Text = esito;
                if (c.CodTipo == "DNT") url = "RichiestaDocumentiIntegrativiVariante";
                e.Item.Cells[6].Text = "<input type='button' class='ButtonGrid' style='width:70px' " +
                    "onclick=\"location='" + url + ".aspx?idcom=" + c.Id + "'\" value='Dettaglio' />";
            }
        }


        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                VarianteProvider.DbProviderObj.BeginTran();
                foreach (SiarLibrary.VariantiAllegati a in allegatiColl)
                {
                    string codEsito = null, note = null;
                    foreach (string s in Request.Form.AllKeys)
                    {
                        if (s.EndsWith("lstEsito" + a.IdAllegato)) codEsito = Request.Form[s];
                        else if (s.EndsWith("txtNote" + a.IdAllegato + "_text")) note = Request.Form[s];
                    }
                    a.CodEsito = codEsito;
                    a.NoteIstruttore = note;
                    allegati_provider.Save(a);
                }
                Variante.SegnaturaAllegati = txtNumProtocollo.Text;
                VarianteProvider.AggiornaVarianteIstruttoria(Variante, Operatore);
                ShowMessage("Salvataggio completato.");
                VarianteProvider.DbProviderObj.Commit();
            }
            catch (Exception ex) { VarianteProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnRichiestaCertificazione_Click(object sender, EventArgs e)
        {
            string ente = null;
            SiarLibrary.VariantiAllegati alleg;
            try
            {
                string[] als = ((SiarLibrary.Web.CheckColumn)dgAllegati.Columns[6]).GetSelected();
                if (als.Length == 0) throw new Exception("Attenzione! Selezionare almeno un allegato.");
                foreach (string a in als)
                {
                    int id_all = int.Parse(a);
                    alleg = new SiarLibrary.VariantiAllegati();
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
                pc.IdProgetto = Variante.IdProgetto;
                pc.IdVariante = Variante.IdVariante;
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
                    pcDoc.IdVarianteAllegati = id_all;
                    progComDoc_provider.Save(pcDoc);
                }
                Redirect("RichiestaCertificazioneVariante.aspx" + "?idcom=" + pc.Id);
            }
            catch (Exception ex) { ShowError(ex); }
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
                            formato = Request.Form[s]; if (formato == "S") throw new Exception("Attenzione, NON è possibile selezionare le dichiarazioni sostitutive.");
                            break;
                        }
                }
                SiarLibrary.ProgettoComunicazioni pc = new SiarLibrary.ProgettoComunicazioni();
                pc.IdProgetto = Variante.IdProgetto;
                pc.IdVariante = Variante.IdVariante;
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
                    pcDoc.IdVarianteAllegati = id_all;
                    progComDoc_provider.Save(pcDoc);
                }
                Redirect("RichiestaDocumentiIntegrativiVariante.aspx" + "?idcom=" + pc.Id);
            }
            catch (Exception ex) { ShowError(ex); }
        }


    }
}