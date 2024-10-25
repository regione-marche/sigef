using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Bandi
{
    public partial class BandoVarianti : SiarLibrary.Web.BandoPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "riepilogo_bando";
            base.OnPreInit(e);
        }

        SiarBLL.BandoTipoVariantiCollectionProvider bandotipovarianti_provider;
        SiarBLL.BandoRequisitiVarianteCollectionProvider bandorequisiti_provider;
        SiarBLL.RequisitiVarianteCollectionProvider requisiti_provider;
        SiarLibrary.RequisitiVariante requisito_selezionato;


        SiarLibrary.BandoRequisitiVarianteCollection bandoReqColl = new SiarLibrary.BandoRequisitiVarianteCollection();
        SiarLibrary.BandoTipoVariantiCollection tipoVarColl = new SiarLibrary.BandoTipoVariantiCollection();
        SiarBLL.BandoRequisitiVarianteCollectionProvider bandoReqProv = new SiarBLL.BandoRequisitiVarianteCollectionProvider();
        SiarBLL.RequisitiVarianteCollectionProvider reqVarProv = new SiarBLL.RequisitiVarianteCollectionProvider();
        SiarBLL.VariantiCollectionProvider vProv = new SiarBLL.VariantiCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            //throw new Exception("dove cazzo salvo data e operatore di modifica una volta pubblicato? conviene su bando varianti");
            //AbilitaModifica = ResponsabileDiMisura;
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbVarianti.Visible = false;
                    int id_requisito;
                    if (int.TryParse(hdnIdRequisito.Value, out id_requisito))
                    {
                        if (requisiti_provider == null) requisiti_provider = new SiarBLL.RequisitiVarianteCollectionProvider();
                        requisito_selezionato = requisiti_provider.GetById(id_requisito);
                        if (requisito_selezionato != null) Caricarequisito();
                    }
                    break;
                default:
                    tbRequisiti.Visible = false;
                    if (bandotipovarianti_provider == null) bandotipovarianti_provider = new SiarBLL.BandoTipoVariantiCollectionProvider();
                    dg.DataSource = bandotipovarianti_provider.FindByIdBando(Bando.IdBando);
                    dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                    dg.DataBind();

                    if (!string.IsNullOrEmpty(hdnCodTipoVariante.Value))
                    {
                        if (bandorequisiti_provider == null) bandorequisiti_provider = new SiarBLL.BandoRequisitiVarianteCollectionProvider();
                        SiarLibrary.BandoRequisitiVarianteCollection brvcoll = bandorequisiti_provider.FindByBandoTipo(Bando.IdBando, hdnCodTipoVariante.Value);
                        if (brvcoll.FiltroMisura(txtDMisuraCerca.Text).Count > 0)
                            dgRequisitiVariante.DataSource = brvcoll.FiltroMisura(txtDMisuraCerca.Text);
                        else
                        {
                            dgRequisitiVariante.DataSource = brvcoll;
                            txtDMisuraCerca.Text = string.Empty;
                        }

                        dgRequisitiVariante.ItemDataBound += new DataGridItemEventHandler(dgRequisitiVariante_ItemDataBound);
                        dgRequisitiVariante.DataBind();
                        tbRequisitiVariante.Visible = true;
                    }
                    break;
            }
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.BandoTipoVarianti bt = (SiarLibrary.BandoTipoVarianti)dgi.DataItem;
                e.Item.Cells[3].Text = "<input type='button' style='width:90px' class='ButtonGrid' value='Dettaglio' onclick=\"caricaTipoVariante('"
                    + bt.CodTipo + "')\" />";
                if (bt.IdBando != null)
                {
                    string testo_check = e.Item.Cells[2].Text;
                    e.Item.Cells[2].Text = testo_check.Replace("<input", "<input checked");
                }
                if (bt.CodTipo == hdnCodTipoVariante.Value)
                {
                    e.Item.Cells[0].Style.Add("background-color", "#fefeee");
                    string testo_cella = e.Item.Cells[0].Text;
                    e.Item.Cells[0].Text = "<table width='100%'><tr><td width='30px'><img src='../../../images/config.ico' alt='Tipologia attualmente selezionata' /></td><td>"
                        + testo_cella + "</td></tr></table>";
                }
            }
        }

        void dgRequisitiVariante_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.BandoRequisitiVariante r = (SiarLibrary.BandoRequisitiVariante)dgi.DataItem;
                if (r.IdBando != null)
                {
                    string testo_check = e.Item.Cells[8].Text;
                    e.Item.Cells[8].Text = testo_check.Replace("<input", "<input checked");

                    if (r.Obbligatorio)
                    {
                        testo_check = e.Item.Cells[4].Text;
                        e.Item.Cells[4].Text = testo_check.Replace("<input", "<input checked");
                    }
                    if (r.RequisitoDiPresentazione)
                    {
                        testo_check = e.Item.Cells[5].Text;
                        e.Item.Cells[5].Text = testo_check.Replace("<input", "<input checked");
                    }
                    if (r.RequisitoDiIstruttoria)
                    {
                        testo_check = e.Item.Cells[6].Text;
                        e.Item.Cells[6].Text = testo_check.Replace("<input", "<input checked");
                    }
                }
                else
                {
                    e.Item.Cells[4].Text = e.Item.Cells[4].Text.Replace("checked", "");
                    e.Item.Cells[5].Text = e.Item.Cells[5].Text.Replace("checked", "");
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("checked", "");
                    e.Item.Cells[8].Text = e.Item.Cells[8].Text.Replace("checked", "");
                }
            }
        }
        protected void btnSalvaTipoVariante_Click(object sender, EventArgs e)
        {
            try
            {
                bandotipovarianti_provider = new SiarBLL.BandoTipoVariantiCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.BandoTipoVariantiCollection tipologie_esistenti = bandotipovarianti_provider.FindByIdBando(Bando.IdBando);
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dg.Columns[2]).GetSelected();
                SiarLibrary.BandoTipoVarianti nuova_tipologia;
                bool avviso_domande_presentate = false;
                foreach (SiarLibrary.BandoTipoVarianti t in tipologie_esistenti)
                {
                    bool selezionata = false;
                    foreach (string s in selezionati) if (s == t.CodTipo) { selezionata = true; break; }
                    if (t.IdBando == null)
                    {
                        if (!selezionata) continue;
                        nuova_tipologia = new SiarLibrary.BandoTipoVarianti();
                        nuova_tipologia.IdBando = Bando.IdBando;
                        nuova_tipologia.CodTipo = t.CodTipo;
                    }
                    else
                    {
                        if (SiarLibrary.DbStaticProvider.GetDomandePresentateBandoTipoVariante(Bando.IdBando, t.CodTipo, BandoProvider.DbProviderObj) > 0)
                        {
                            avviso_domande_presentate = true;
                            continue;
                        }
                        nuova_tipologia = t;
                        if (!selezionata)
                        {
                            bandorequisiti_provider = new SiarBLL.BandoRequisitiVarianteCollectionProvider(BandoProvider.DbProviderObj);
                            bandorequisiti_provider.DeleteCollection(bandorequisiti_provider.Find(Bando.IdBando, nuova_tipologia.CodTipo));
                            bandotipovarianti_provider.Delete(nuova_tipologia);
                            continue;
                        }
                    }
                    int num_massimo = 0;
                    int.TryParse(Request.Form["NumeroMassimo" + nuova_tipologia.CodTipo + "_text"], out num_massimo);
                    nuova_tipologia.NumeroMassimo = num_massimo;
                    bandotipovarianti_provider.Save(nuova_tipologia);
                }
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Tipologie di varianti salvate correttamente." +
                    (avviso_domande_presentate ? "<br /> Attenzione: almeno una tipologia non è stata modificata perchè già utilizzata." : ""));
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
        protected void btnSalvaRequisitiVariante_Click(object sender, EventArgs e)
        {
            string[] requisiti_selezionati = ((SiarLibrary.Web.CheckColumn)dgRequisitiVariante.Columns[8]).GetSelected();
            if (requisiti_selezionati.Length == 0) { ShowError("Nessun requisito selezionato. Impossibile continuare."); return; }
            if (string.IsNullOrEmpty(hdnCodTipoVariante.Value) || new SiarBLL.BandoTipoVariantiCollectionProvider().Find(Bando.IdBando, hdnCodTipoVariante.Value)
                .Count == 0) { ShowError("Nessuna tipologia di variante selezionata."); return; }
            if (SiarLibrary.DbStaticProvider.GetDomandePresentateBandoTipoVariante(Bando.IdBando, hdnCodTipoVariante.Value, BandoProvider.DbProviderObj) > 0)
            { ShowError("Non è possibile modificare la tipologia di variante selezionata in quanto esistono domande presentate."); return; }
            try
            {
                string chkObbligatori = Request.Form["chkRequisitoObbligatorio"], chkPresentazione = Request.Form["chkRequisitoPresentazione"],
                    chkIstruttoria = Request.Form["chkRequisitoIstruttoria"];
                bandorequisiti_provider = new SiarBLL.BandoRequisitiVarianteCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                bandorequisiti_provider.DeleteCollection(bandorequisiti_provider.Find(Bando.IdBando, hdnCodTipoVariante.Value));
                int salvataggio_requisiti_tralasciati = 0;
                SiarLibrary.BandoRequisitiVarianteCollection requisiti_esistenti_multimisura = bandorequisiti_provider.
                    FindRequisitiEsistentiXMultimisura(Bando.IdBando, hdnCodTipoVariante.Value);
                foreach (string s in requisiti_selezionati)
                {
                    int id_requisito;
                    if (!int.TryParse(s, out id_requisito)) throw new Exception("Nessun requisito selezionato. Impossibile continuare.");
                    if (requisiti_esistenti_multimisura.SubSelect(null, null, s, null, null, null, null).Count > 0)
                    {

                        salvataggio_requisiti_tralasciati++;
                        continue;
                    }
                    SiarLibrary.BandoRequisitiVariante requisito = new SiarLibrary.BandoRequisitiVariante();
                    requisito.IdBando = Bando.IdBando;
                    requisito.CodTipo = hdnCodTipoVariante.Value;
                    requisito.IdRequisito = id_requisito;
                    requisito.Obbligatorio = TrovaStringa(s, chkObbligatori);
                    requisito.RequisitoDiIstruttoria = TrovaStringa(s, chkIstruttoria);
                    requisito.RequisitoDiPresentazione = TrovaStringa(s, chkPresentazione);
                    requisito.Ordine = new SiarLibrary.NullTypes.IntNT(Request.Form["txtRequisitoOrdine" + s + "_text"]);
                    bandorequisiti_provider.Save(requisito);
                }
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Requisiti salvati correttamente." + (salvataggio_requisiti_tralasciati > 0 ? "<br /> N.B: nr."
                    + salvataggio_requisiti_tralasciati.ToString() + " requisiti non salvati perchè associati ad altre disposizioni di misura." : ""));
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
        private bool TrovaStringa(string stringa_cercata, string stringa_in_cui_cercare)
        {
            if (stringa_in_cui_cercare == null) return false;
            if (stringa_in_cui_cercare.IndexOf(",") < 0 && stringa_cercata == stringa_in_cui_cercare) return true;
            if (stringa_in_cui_cercare.IndexOf("," + stringa_cercata + ",") >= 0) return true;
            if (stringa_in_cui_cercare.IndexOf(stringa_cercata + ",") == 0) return true;
            int indice = stringa_in_cui_cercare.IndexOf("," + stringa_cercata);
            if (indice >= 0 && indice == (stringa_in_cui_cercare.Length - (stringa_cercata.Length + 1))) return true;
            return false;
        }
        protected void btnCaricaTipoVariante_Click(object sender, EventArgs e)
        {

        }
        #region nuovo requisito

        protected void btnCaricaRequisito_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
        }

        private void Caricarequisito()
        {
            if (requisito_selezionato != null)
            {
                txtDescrizione.Text = requisito_selezionato.Descrizione;
                txtMisura.Text = requisito_selezionato.Misura;
                txtQueryLungaSQL.Text = requisito_selezionato.QueryEval;
                txtQueryInsertLunga.Text = requisito_selezionato.QueryInsert;
                txtValoreMassimo.Text = requisito_selezionato.ValMassimo;
                txtValoreMinimo.Text = requisito_selezionato.ValMinimo;
                chkAutomatico.Checked = requisito_selezionato.Automatico;
                btnEliminaRequisito.Enabled = AbilitaModifica;
                btnSalvaRequisito.Enabled = AbilitaModifica;
            }
            else btnEliminaRequisito.Enabled = false;
        }

        protected void btnEliminaRequisito_Click(object sender, EventArgs e)
        {
            int id_requisito;
            if (!int.TryParse(hdnIdRequisito.Value, out id_requisito)) { ShowError("Nessun requisito selezionato per la modifica."); return; }
            try
            {
                bandorequisiti_provider = new SiarBLL.BandoRequisitiVarianteCollectionProvider(BandoProvider.DbProviderObj);
                requisiti_provider = new SiarBLL.RequisitiVarianteCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.RequisitiVariante requisito = requisiti_provider.GetById(id_requisito);
                if (requisito == null) throw new Exception("Nessun requisito selezionato.");
                if (bandorequisiti_provider.Select(null, null, id_requisito, null, null, null, null).Count > 0)
                    throw new Exception("Impossibile eliminare il requisito, perché associato ad un bando.");
                requisiti_provider.Delete(requisito);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Requisito eliminato correttamente.");
                PulisciCampiRequisito();
                hdnIdRequisito.Value = null;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaRequisito_Click(object sender, EventArgs e)
        {
            try
            {
                requisiti_provider = new SiarBLL.RequisitiVarianteCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.RequisitiVariante requisito;
                int id_requisito;
                if (int.TryParse(hdnIdRequisito.Value, out id_requisito))
                {
                    requisito = requisiti_provider.GetById(id_requisito);
                    if (requisito == null) throw new Exception("Nessun requisito selezionato per la modifica.");
                    bandorequisiti_provider = new SiarBLL.BandoRequisitiVarianteCollectionProvider(BandoProvider.DbProviderObj);
                    if (bandorequisiti_provider.Select(null, null, id_requisito, null, null, null, null).Count > 0)
                        throw new Exception("Impossibile modificare il requisito, perché associato ad un bando.");
                }
                else requisito = new SiarLibrary.RequisitiVariante();
                requisito.Automatico = chkAutomatico.Checked;
                requisito.Descrizione = txtDescrizione.Text;
                requisito.QueryEval = txtQueryLungaSQL.Text.Replace("`", "\'");
                requisito.QueryInsert = txtQueryInsertLunga.Text.Replace("`", "\'");
                requisito.ValMinimo = txtValoreMinimo.Text;
                requisito.ValMassimo = txtValoreMassimo.Text;
                requisito.Misura = txtMisura.Text;
                requisiti_provider.Save(requisito);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Requisito salvato correttamente.");
                hdnIdRequisito.Value = requisito.IdRequisito;
                requisito_selezionato = requisito;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        private void PulisciCampiRequisito()
        {
            txtDescrizione.Text = string.Empty;
            txtMisura.Text = string.Empty;
            txtQueryLungaSQL.Text = string.Empty;
            txtQueryInsertLunga.Text = string.Empty;
            chkAutomatico.Checked = false;
            txtValoreMassimo.Text = string.Empty;
            txtValoreMinimo.Text = string.Empty;
            btnEliminaRequisito.Enabled = false;
        }

        #endregion
        protected void btnDMisuraCerca_Click(object sender, EventArgs e)
        {

        }
    }
}
