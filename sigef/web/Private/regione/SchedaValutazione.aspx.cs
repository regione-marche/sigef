using System;
using System.Web.UI.WebControls;

namespace web.Private.regione
{
    public partial class SchedaValutazione : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Scheda_valutazione";
            base.OnPreInit(e);
        }

        SiarBLL.SchedaValutazioneCollectionProvider scheda_provider = new SiarBLL.SchedaValutazioneCollectionProvider();
        SiarLibrary.SchedaValutazione scheda_selezionata = null;
        SiarBLL.SchedaXPrioritaCollectionProvider sxp_provider;
        SiarLibrary.SchedaXPrioritaCollection priorita = null;
        bool bando_associato = false;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                sxp_provider = new SiarBLL.SchedaXPrioritaCollectionProvider(scheda_provider.DbProviderObj);
                int id_scheda_selezionata;
                if (!IsPostBack && int.TryParse(Request.QueryString["ids"], out id_scheda_selezionata))
                {
                    hdnIdSchedaValutazione.Value = id_scheda_selezionata.ToString();
                    ucSiarNewTab.TabSelected = 2;
                }

                if (int.TryParse(hdnIdSchedaValutazione.Value, out id_scheda_selezionata))
                    scheda_selezionata = scheda_provider.GetById(id_scheda_selezionata);
                if (scheda_selezionata != null)
                {
                    SiarLibrary.BandoCollection bandi = new SiarBLL.BandoCollectionProvider().Find(null, null, null, null, null, null, null, null, null);
                    foreach (SiarLibrary.Bando b in bandi)
                        if (b.IdSchedaValutazione == scheda_selezionata.IdSchedaValutazione) { bando_associato = true; break; }
                    if (bando_associato) AbilitaModifica = false;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (ucSiarNewTab.TabSelected == 2)
            {
                ucSiarNewTab.Width = tbDettaglio.Width;
                tbRicerca.Visible = false;
                lstCaricaSchedaTemplate.FlagTemplate = true;
                lstCaricaSchedaTemplate.DataBind();

                if (scheda_selezionata == null)
                {
                    btnEliminaScheda.Enabled = false;
                    if (priorita == null) priorita = sxp_provider.GetPrioritaBySchedaValutazione(null, txtFiltroMisura.Text, txtFiltroDescrizione2.Text);
                }
                else
                {
                    txtDescrizione.Text = scheda_selezionata.Descrizione;
                    txtParoleChiave.Text = scheda_selezionata.ParoleChiave;
                    chkTemplate.Checked = scheda_selezionata.FlagTemplate;
                    txtValMinimo.Text = scheda_selezionata.ValoreMin;
                    txtValMax.Text = scheda_selezionata.ValoreMax;
                    if (priorita == null) priorita = sxp_provider.GetPrioritaBySchedaValutazione(scheda_selezionata.IdSchedaValutazione, txtFiltroMisura.Text, txtFiltroDescrizione2.Text);
                }

                System.Collections.ArrayList selezionate = new System.Collections.ArrayList(), val_massimo = new System.Collections.ArrayList(),
                    visibili = new System.Collections.ArrayList(), val_massimo_speciale = new System.Collections.ArrayList();
                foreach (SiarLibrary.SchedaXPriorita p in priorita)
                {
                    if (p.IdSchedaValutazione != null)
                    {
                        string id_priorita = p.IdPriorita.Value.ToString();
                        selezionate.Add(id_priorita);
                        if (p.IsMax) val_massimo.Add(id_priorita);
                        if (p.Selezionabile) visibili.Add(id_priorita);
                        bool is_max_speciale;
                        bool.TryParse(p.AdditionalAttributes["IS_MAX_SPECIALE"], out is_max_speciale);
                        if (is_max_speciale) val_massimo_speciale.Add(id_priorita);
                    }
                }
                ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[7]).SetSelected(val_massimo);
                ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[8]).SetSelected(visibili);
                ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[10]).SetSelected(selezionate);
                ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[12]).SetSelected(val_massimo_speciale);

                dgPriorita.DataSource = priorita;
                dgPriorita.Titolo = "Elementi trovati: " + priorita.Count.ToString();
                dgPriorita.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
                dgPriorita.DataBind();
            }
            else
            {
                ucSiarNewTab.Width = tbRicerca.Width;
                tbDettaglio.Visible = false;
                string ricerca_descrizione = (!string.IsNullOrEmpty(txtRicercaDescrizione.Text) ? "%" + txtRicercaDescrizione.Text + "%" : null),
                    ricerca_parole_chiave = (!string.IsNullOrEmpty(txtRicercaParoleChiave.Text) ? "%" + txtRicercaParoleChiave.Text + "%" : null);
                SiarLibrary.SchedaValutazioneCollection schede = scheda_provider.Find(null, chkRicercaTemplate.Checked, ricerca_descrizione, ricerca_parole_chiave);
                dg.DataSource = schede;
                dg.Titolo = "Elementi trovati: " + schede.Count.ToString();
                dg.DataBind();
            }

            base.OnPreRender(e);
        }

        void dgPriorita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].RowSpan = e.Item.Cells[1].RowSpan = e.Item.Cells[2].RowSpan = e.Item.Cells[3].RowSpan = e.Item.Cells[4].RowSpan =
                    e.Item.Cells[5].RowSpan = e.Item.Cells[6].RowSpan = e.Item.Cells[7].RowSpan = e.Item.Cells[8].RowSpan = e.Item.Cells[9].RowSpan =
                    e.Item.Cells[10].RowSpan = 2;
                e.Item.Cells[11].ColumnSpan = 2;
                e.Item.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[11].Text = "PRIORITA SPECIALE</td></tr><tr class='TESTA'><td>Priorita Selezionata (*)";
            }
            else if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                SiarLibrary.SchedaXPriorita p = (SiarLibrary.SchedaXPriorita)e.Item.DataItem;
                //Priorita speciali
                if (scheda_selezionata != null)
                {
                    int id_priorita_speciale;
                    if (int.TryParse(p.AdditionalAttributes["ID_PRIORITA_SPECIALE"], out id_priorita_speciale))
                    {
                        e.Item.Cells[11].Text = "<span id='idPrioritaSpeciale" + p.IdPriorita + "' class='IntegerBox'><input type='text' NoCurrency='true' id='idPrioritaSpeciale"
                            + p.IdPriorita + "_text' name='idPrioritaSpeciale" + p.IdPriorita + "_text' value='" + id_priorita_speciale.ToString()
                            + "' style='text-align:right;WIDTH:60px' ></span>";
                    }
                }
            }
        }

        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            SiarLibrary.PrioritaSpecialeCollection  pspec = new SiarLibrary.PrioritaSpecialeCollection() ; 
            try
            {
                ctrlBandoAssociato();
                SiarBLL.PrioritaSpecialeCollectionProvider pspeciali_provider = new SiarBLL.PrioritaSpecialeCollectionProvider(scheda_provider.DbProviderObj);
                scheda_provider.DbProviderObj.BeginTran();

                bool nuova_scheda = false;
                if (scheda_selezionata == null)
                {
                    scheda_selezionata = new SiarLibrary.SchedaValutazione();
                    nuova_scheda = true;
                }
                scheda_selezionata.Descrizione = txtDescrizione.Text;
                scheda_selezionata.FlagTemplate = chkTemplate.Checked;
                scheda_selezionata.ValoreMax = txtValMax.Text;
                scheda_selezionata.ValoreMin = txtValMinimo.Text;
                scheda_selezionata.ParoleChiave = txtParoleChiave.Text;
                scheda_provider.Save(scheda_selezionata);
                hdnIdSchedaValutazione.Value = scheda_selezionata.IdSchedaValutazione;

                if (!nuova_scheda)
                {
                    pspec = pspeciali_provider.Find(scheda_selezionata.IdSchedaValutazione, null, null);
                    pspeciali_provider.DeleteCollection(pspec);
                    sxp_provider.DeleteCollection(sxp_provider.Find(scheda_selezionata.IdSchedaValutazione, null, null, null, null));
                }

                string[] priorita_selezionate = ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[10]).GetSelected();
                string[] priorita_visibili = ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[8]).GetSelected();
                string[] priorita_valore_massimo = ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[7]).GetSelected();
                string[] priorita_speciale_valore_massimo = ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[12]).GetSelected();
                foreach (string id in priorita_selezionate)
                {
                    SiarLibrary.SchedaXPriorita p = new SiarLibrary.SchedaXPriorita();
                    p.IdSchedaValutazione = scheda_selezionata.IdSchedaValutazione;
                    p.IdPriorita = id;
                    p.Ordine = Request.Form["Ordine" + id + "_text"];
                    p.Peso = Request.Form["Peso" + id + "_text"];
                    p.AiutoAddizionale = Request.Form["AiutoAddizionale" + id + "_text"];
                    bool selezionabile = false;
                    foreach (string v in priorita_visibili) if (v == id) { selezionabile = true; break; }
                    p.Selezionabile = selezionabile;
                    bool valore_massimo = false;
                    foreach (string m in priorita_valore_massimo) if (m == id) { valore_massimo = true; break; }
                    p.IsMax = valore_massimo;
                    sxp_provider.Save(p);

                    // priorita speciali
                    int id_priorita_speciale =0 ;
                    if ( Request.Form["idPrioritaSpeciale" + p.IdPriorita + "_text"] != null ) 
                            int.TryParse(Request.Form["idPrioritaSpeciale" + p.IdPriorita + "_text"].Replace (".",""), out id_priorita_speciale);
                    else if(pspec.SubSelect(p.IdSchedaValutazione, p.IdPriorita ,null,null).Count >0 ) 
                        id_priorita_speciale = pspec.SubSelect(p.IdSchedaValutazione, p.IdPriorita,null,null)[0].IdPrioritaSelezionata ;
                    
                    if(id_priorita_speciale >0){
                        SiarLibrary.PrioritaSpeciale ps = new SiarLibrary.PrioritaSpeciale();
                        ps.IdSchedaValutazione = p.IdSchedaValutazione;
                        ps.IdPriorita = p.IdPriorita;
                        ps.IdPrioritaSelezionata = id_priorita_speciale;
                        bool is_max_speciale = false;
                        foreach (string ms in priorita_speciale_valore_massimo)
                            if (ms == id) { is_max_speciale = true; break; }
                        ps.IsMax = is_max_speciale;
                        pspeciali_provider.Save(ps);
                    }
                }

                scheda_provider.DbProviderObj.Commit();
                txtFiltroMisura.Text = string.Empty;
                ShowMessage("Scheda di valutazione salvata correttamente.");
            }
            catch (Exception ex) { scheda_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaScheda_Click(object sender, EventArgs e)
        {
            try
            {
                ctrlBandoAssociato();
                if (scheda_selezionata == null) ShowError("Per proseguire è necessario selezionare la scheda di valutazione desiderata.");
                else
                {
                    SiarBLL.PrioritaSpecialeCollectionProvider pspeciali_provider = new SiarBLL.PrioritaSpecialeCollectionProvider(scheda_provider.DbProviderObj);
                    scheda_provider.DbProviderObj.BeginTran();
                    pspeciali_provider.DeleteCollection(pspeciali_provider.Find(scheda_selezionata.IdSchedaValutazione, null, null));
                    sxp_provider.DeleteCollection(sxp_provider.Find(scheda_selezionata.IdSchedaValutazione, null, null, null, null));
                    scheda_provider.Delete(scheda_selezionata);
                    scheda_provider.DbProviderObj.Commit();

                    ShowMessage("Scheda valutazione eliminata correttamente.");
                    ucSiarNewTab.TabSelected = 1;
                    btnNuovo_Click(sender, e);
                }
            }
            catch (Exception ec)
            {
                scheda_provider.DbProviderObj.Rollback();
                ShowError(ec);//"Impossibile eliminare la scheda. E' associata al bando.");
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
        }

        protected void btnFiltra_Click(object sender, EventArgs e)
        {

        }

        protected void btnCarica_Click(object sender, EventArgs e)
        {
            try
            {
                int id_scheda_template;
                if (!int.TryParse(lstCaricaSchedaTemplate.SelectedValue, out id_scheda_template)) ShowError("Selezionare il modello da caricare.");
                else priorita = sxp_provider.GetPrioritaBySchedaValutazione(id_scheda_template, txtFiltroMisura.Text, txtFiltroDescrizione2.Text);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovo_Click(object sender, EventArgs e)
        {
            hdnIdSchedaValutazione.Value = "";
            txtValMinimo.Text = "";
            txtValMax.Text = "";
            txtDescrizione.Text = "";
            txtParoleChiave.Text = "";
            chkTemplate.Checked = false;
            scheda_selezionata = null;
            btnSalva.Enabled = true;
        }

        private void ctrlBandoAssociato()
        {
            if (scheda_selezionata != null && bando_associato)
                throw new Exception("Impossibile modificare la scheda valutazione perche associata ad un bando.");
        }
    }
}