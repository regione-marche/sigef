using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Bandi
{
    public partial class ModelloDomanda : SiarLibrary.Web.BandoPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "riepilogo_bando";
            base.OnPreInit(e);
        }

        SiarBLL.AllegatiXDomandaCollectionProvider allegati_provider;
        SiarBLL.DichiarazioniXDomandaCollectionProvider dichiarazioni_provider;
        SiarBLL.QuadriXDomandaCollectionProvider quadri_provider;
        SiarLibrary.ModelloDomanda modello;
        SiarBLL.ModelloDomandaCollectionProvider modprov;

        protected void Page_Load(object sender, EventArgs e)
        {
            modprov = new SiarBLL.ModelloDomandaCollectionProvider(BandoProvider.DbProviderObj);
            dichiarazioni_provider = new SiarBLL.DichiarazioniXDomandaCollectionProvider(BandoProvider.DbProviderObj);
            quadri_provider = new SiarBLL.QuadriXDomandaCollectionProvider(BandoProvider.DbProviderObj);
            allegati_provider = new SiarBLL.AllegatiXDomandaCollectionProvider(BandoProvider.DbProviderObj);
            if (Bando.IdModelloDomanda != null) modello = modprov.GetById(Bando.IdModelloDomanda);
            AbilitaModifica = AbilitaModifica && TipoModifica == 2;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (modello == null)
            {
                ucSiarNewTab.Visible = false;
                tableQuadri.Visible = false;
                tableDichiarazioni.Visible = false;
                tableAllegati.Visible = false;
                btnStampa.Enabled = false;
                btnSalvaReport.Enabled = false;
            }
            else
            {
                txtDenominazione.Text = modello.Denominazione;
                txtDescrizioneLunga.Text = modello.Descrizione;
                string filtro_misura = null, descrizione = null;
                switch (ucSiarNewTab.TabSelected)
                {
                    case 2:
                        #region dichiarazioni
                        tableDichiarazioni.Visible = true;
                        filtro_misura = txtDMisuraCerca.Text;
                        descrizione = txtDescrizioneDichiarazione.Text; 
                        SiarLibrary.DichiarazioniXDomandaCollection dd = dichiarazioni_provider.GetDichiarazioniModelloDomanda(modello.IdDomanda, filtro_misura, descrizione);
                        dgDichiarazioni.DataSource = dd;
                        dgDichiarazioni.ItemDataBound += new DataGridItemEventHandler(dgDichiarazioni_ItemDataBound);
                        dgDichiarazioni.DataBind();
                        #endregion
                        break;
                    case 3:
                        #region allegati
                        tableAllegati.Visible = true;
                        filtro_misura = txtAMisuraCerca.Text;
                        if (!string.IsNullOrEmpty(filtro_misura) && filtro_misura.Length > 10) filtro_misura = filtro_misura.Substring(0, 10);
                        SiarLibrary.AllegatiXDomandaCollection cc = allegati_provider.GetAllegatiModelloDomanda(modello.IdDomanda, filtro_misura);
                        dgAllegati.DataSource = cc;
                        dgAllegati.ItemDataBound += new DataGridItemEventHandler(dgAllegati_ItemDataBound);
                        dgAllegati.DataBind();
                        #endregion
                        break;
                    default:
                        #region quadri report
                        tableQuadri.Visible = true;
                        SiarLibrary.QuadriXDomandaCollection qq = quadri_provider.GetQuadriModelloDomanda(modello.IdDomanda);
                        dgQuadri.DataSource = qq;
                        dgQuadri.ItemDataBound += new DataGridItemEventHandler(dgQuadri_ItemDataBound);
                        dgQuadri.DataBind();
                        #endregion
                        break;
                }
            }
            base.OnPreRender(e);
        }

        void dgQuadri_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.QuadriXDomanda quadro = (SiarLibrary.QuadriXDomanda)dgi.DataItem;
                if (quadro.IdDomanda != null) dgi.Cells[4].Text = dgi.Cells[4].Text.Replace("<input", "<input checked");
            }
        }

        void dgDichiarazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.DichiarazioniXDomanda dichiarazione = (SiarLibrary.DichiarazioniXDomanda)dgi.DataItem;
                if (dichiarazione.IdDomanda != null)
                {
                    dgi.Cells[6].Text = dgi.Cells[6].Text.Replace("<input", "<input checked");
                    if (dichiarazione.Obbligatorio)
                        dgi.Cells[4].Text = dgi.Cells[4].Text.Replace("<input", "<input checked");
                }
                else
                    dgi.Cells[4].Text = dgi.Cells[4].Text.Replace("checked", "");
            }
        }

        void dgAllegati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.AllegatiXDomanda allegato = (SiarLibrary.AllegatiXDomanda)dgi.DataItem;
                if (allegato.IdDomanda != null) dgi.Cells[4].Text = dgi.Cells[4].Text.Replace("<input", "<input checked");
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                BandoProvider.DbProviderObj.BeginTran();
                if (modello == null)
                {
                    modello = new SiarLibrary.ModelloDomanda();
                    modello.IdBando = Bando.IdBando;
                }
                modello.Denominazione = txtDenominazione.Text;
                modello.Descrizione = txtDescrizioneLunga.Text;
                modprov.Save(modello);

                Bando.IdModelloDomanda = modello.IdDomanda;
                BandoProvider.Save(Bando);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Modello di report della domanda salvato correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaQuadri_Click(object sender, EventArgs e)
        {
            string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgQuadri.Columns[4]).GetSelected();
            if (selezionati.Length == 0) { ShowError("Occorre selezionare almeno un quadro."); return; }
            if (modello == null || modello.IdDomanda == null) { ShowError("Il modello di report non e' stato registrato correttamente."); return; }
            SiarBLL.QuadriXDomandaCollectionProvider qxdprov = new SiarBLL.QuadriXDomandaCollectionProvider();
            qxdprov.DbProviderObj.BeginTran();
            try
            {
                qxdprov.DeleteCollection(qxdprov.Find(null, modello.IdDomanda, null));
                foreach (string s in selezionati)
                {
                    SiarLibrary.QuadriXDomanda qxd = new SiarLibrary.QuadriXDomanda();
                    qxd.IdDomanda = modello.IdDomanda;
                    qxd.IdQuadro = s;
                    int ordine;
                    if (!int.TryParse(Request.Form["OrdineQuadro" + s.ToString() + "_text"], out ordine)) ordine = selezionati.Length + 1;
                    qxd.Ordine = ordine;
                    qxdprov.Save(qxd);
                }
                qxdprov.DbProviderObj.Commit();
                ShowMessage("Quadri salvati correttamente.");
            }
            catch (Exception ex) { qxdprov.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaDichiarazioni_Click(object sender, EventArgs e)
        {
            string[] selezionate = ((SiarLibrary.Web.CheckColumn)dgDichiarazioni.Columns[6]).GetSelected();
            string[] obbligatorie = ((SiarLibrary.Web.CheckColumn)dgDichiarazioni.Columns[4]).GetSelected();
            if (selezionate.Length == 0) { ShowError("Occorre selezionare almeno una dichiarazione."); return; }
            if (modello == null || modello.IdDomanda == null) { ShowError("Il modello di report non e' stato registrato correttamente."); return; }
            SiarBLL.DichiarazioniXDomandaCollectionProvider dichiarazioni_provider = new SiarBLL.DichiarazioniXDomandaCollectionProvider();
            dichiarazioni_provider.DbProviderObj.BeginTran();
            try
            {
                dichiarazioni_provider.DeleteCollection(dichiarazioni_provider.Find(null, modello.IdDomanda));
                foreach (string s in selezionate)
                {
                    SiarLibrary.DichiarazioniXDomanda dxd = new SiarLibrary.DichiarazioniXDomanda();
                    dxd.IdDomanda = modello.IdDomanda;
                    dxd.IdDichiarazione = s;
                    dxd.Obbligatorio = false;
                    foreach (string o in obbligatorie)
                        if (o == s) { dxd.Obbligatorio = true; break; }
                    int ordine;
                    if (!int.TryParse(Request.Form["OrdineDichiarazione" + s.ToString() + "_text"], out ordine)) ordine = selezionate.Length + 1;
                    dxd.Ordine = ordine;
                    dichiarazioni_provider.Save(dxd);
                }
                dichiarazioni_provider.DbProviderObj.Commit();
                ShowMessage("Dichiarazioni salvate correttamente.");
                txtDMisuraCerca.Text = null; txtDescrizioneDichiarazione.Text = null;
                dgDichiarazioni.CurrentPageIndex = 0;
            }
            catch (Exception ex) { dichiarazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaAllegati_Click(object sender, EventArgs e)
        {
            try
            {
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgAllegati.Columns[4]).GetSelected();
                if (modello == null || modello.IdDomanda == null) throw new Exception("Il modello di report non e' stato registrato correttamente.");

                BandoProvider.DbProviderObj.BeginTran();
                allegati_provider.DeleteCollection(allegati_provider.Find(null, modello.IdDomanda, null));
                foreach (string s in selezionati)
                {
                    SiarLibrary.AllegatiXDomanda axd = new SiarLibrary.AllegatiXDomanda();
                    axd.IdDomanda = modello.IdDomanda;
                    axd.IdAllegato = s;
                    int ordine;
                    if (!int.TryParse(Request.Form["OrdineAllegato" + s.ToString() + "_text"], out ordine)) ordine = selezionati.Length + 1;
                    axd.Ordine = ordine;
                    allegati_provider.Save(axd);
                }
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Allegati salvati correttamente.");
                txtAMisuraCerca.Text = null;
                dgAllegati.SetPageIndex(0);
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (modello != null)
                {
                    new SiarLibrary.Web.ReportTemplates().RegistraModelloDomanda(modello.IdDomanda);
                    ShowMessage("Report salvato correttamente.");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnStampa_Click(object sender, EventArgs e)
        {
            try
            {
                if (modello != null)
                {
                    SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
                    byte[] report = rt.getReportByName("rptModelloDomanda" + modello.IdDomanda, SiarLibrary.Web.ReportFormat.PDF, null);
                    rt.Dispose();
                    Session.Add("doc", report);
                    RegisterClientScriptBlock("window.open('../../../VisualizzaDocumento.aspx');");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDMisuraCerca_Click(object sender, EventArgs e) { dgDichiarazioni.CurrentPageIndex = 0; }

        protected void btnAMisuraCerca_Click(object sender, EventArgs e) { dgAllegati.CurrentPageIndex = 0; }
    }
}