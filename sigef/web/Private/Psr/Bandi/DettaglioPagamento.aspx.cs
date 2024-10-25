using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Bandi
{
    public partial class DettaglioPagamento : SiarLibrary.Web.BandoPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "riepilogo_bando";
            base.OnPreInit(e);
        }

        int nr_requisiti_associati = 0;
        SiarBLL.BandoTipoPagamentoCollectionProvider tpagamenti_provider;
        SiarBLL.BandoRequisitiPagamentoCollectionProvider bando_requisiti_provider;
        SiarBLL.RequisitiPagamentoCollectionProvider requisiti_provider;
        SiarLibrary.RequisitiPagamento requisito_selezionato;
        SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider plurivalori_provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            //throw new Exception("dove cazzo salvo data e operatore di modifica una volta pubblicato? conviene su bando pagamento");
            //AbilitaModifica = TipoModifica > 1;
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbPagamenti.Visible = false;
                    if (requisito_selezionato != null) CaricaRequisito();
                    else
                    {
                        int id_requisito;
                        if (int.TryParse(hdnIdRequisito.Value, out id_requisito))
                        {
                            requisiti_provider = new SiarBLL.RequisitiPagamentoCollectionProvider();
                            requisito_selezionato = requisiti_provider.GetById(id_requisito);
                            if (requisito_selezionato == null) ShowError("Nessun requisito selezionato per la modifica.");
                            else CaricaRequisito();
                        }
                        else PulisciCampiRequisito();
                    }
                    foreach (ListItem rb in rblTipologia.Items) rb.Attributes.Add("onclick", "ctrlCheckBoxTipologie(this,event);");
                    break;
                default:
                    tbRequisiti.Visible = false;
                    if (tpagamenti_provider == null) tpagamenti_provider = new SiarBLL.BandoTipoPagamentoCollectionProvider();
                    SiarLibrary.BandoTipoPagamentoCollection tpagamenti = tpagamenti_provider.FindByIdBando(Bando.IdBando);
                    dgTipoPagamento.DataSource = tpagamenti;
                    dgTipoPagamento.ItemDataBound += new DataGridItemEventHandler(dgTipoPagamento_ItemDataBound);
                    dgTipoPagamento.DataBind();
                    if (!string.IsNullOrEmpty(hdnTipoPagamento.Value))
                    {
                        SiarLibrary.BandoTipoPagamentoCollection tipi_selezionati = tpagamenti.SubSelect(null, hdnTipoPagamento.Value, null, null, null, null, null, null);
                        if (tipi_selezionati.Count == 0) ShowError("Nessuna tipologia selezionata.");
                        else
                        {
                            tbRequisitiBando.Visible = true;
                            lblTipoPagamento.Text = tipi_selezionati[0].Descrizione;
                            if (bando_requisiti_provider == null) bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider();
                            SiarLibrary.BandoRequisitiPagamentoCollection requisiti = bando_requisiti_provider.FindByIdBandoTipo(Bando.IdBando, hdnTipoPagamento.Value);
                            if (requisiti.FiltroMisura(txtMisuraCerca.Text).Count > 0) requisiti = requisiti.FiltroMisura(txtMisuraCerca.Text);
                            dgRequisiti.DataSource = requisiti;
                            dgRequisiti.Titolo = "<br /><br /><em>Elementi trovati: " + requisiti.Count.ToString() + "</em>";
                            dgRequisiti.ItemDataBound += new DataGridItemEventHandler(dgRequisiti_ItemDataBound);
                            dgRequisiti.DataBind();
                        }
                    }
                    break;
            }
            base.OnPreRender(e);
        }
        protected void btnMisuraCerca_Click(object sender, EventArgs e) { }

        #region tipi pagamento

        protected void btnSalvaTipoPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                string[] tipi_selezionati = ((SiarLibrary.Web.CheckColumn)dgTipoPagamento.Columns[7]).GetSelected();

                if (tipi_selezionati.Length >0)
                {
                    if (string.IsNullOrEmpty(hdnTipoPagamento.Value))
                    { ShowError("Selezionare la tipologia dei pagamenti ('Dettaglio') per poter salvare i requisiti successivamente."); return; }
                }
                tpagamenti_provider = new SiarBLL.BandoTipoPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.BandoTipoPagamentoCollection tipi_pagamento = tpagamenti_provider.FindByIdBando(Bando.IdBando);
                string avviso_domande_presentate = "";

                SiarBLL.BandoConfigCollectionProvider bandoConfigCollectionProvider = new SiarBLL.BandoConfigCollectionProvider();
                List<string> naturaCup = bandoConfigCollectionProvider.GetBandoConfig_NaturaCupList(Bando.IdBando);

                bool isPorFesr = new SiarBLL.ZprogrammazioneCollectionProvider().isPorFesr(Bando.IdProgrammazione);

                foreach (SiarLibrary.BandoTipoPagamento tipo in tipi_pagamento)
                {
                    // non salvo se sono state presentate domande di pagamento
                    if (SiarLibrary.DbStaticProvider.GetDomandePresentateBandoTipoPagamento(Bando.IdBando, tipo.CodTipo, BandoProvider.DbProviderObj) > 0)
                    {
                        avviso_domande_presentate += "<br /> - " + tipo.Descrizione;
                        continue;
                    }
                    bool selezionata = false;
                    foreach (string s in tipi_selezionati) if (s == tipo.CodTipo) { selezionata = true; break; }
                    if (tipo.IdBando == null)
                    {
                        if (!selezionata) continue;
                        tipo.MarkAsNew();
                        tipo.IdBando = Bando.IdBando;
                        tipo.CodTipo = tipo.CodTipo;
                    }
                    else if (!selezionata)
                    {
                        bando_requisiti_provider.DeleteCollection(bando_requisiti_provider.Find(Bando.IdBando, tipo.CodTipo, null));
                        tpagamenti_provider.Delete(tipo);
                        break;
                    }

                    String codTipoPolizza = null;
                    foreach (String s in Request.Form.AllKeys)
                    {
                        if (s.EndsWith("cmbPolizza_" + tipo.CodTipo))
                        {
                            codTipoPolizza = Request.Form[s];
                            break;
                        }
                    }
                    if (String.IsNullOrEmpty(codTipoPolizza))
                    {
                        throw new Exception("Per ogni tipologia di pagamento selezionata è necessario specificare un tipo di Polizza");
                    }
                    tipo.CodTipoPolizza = codTipoPolizza;

                    SiarLibrary.NullTypes.DecimalNT importo_max = new SiarLibrary.NullTypes.DecimalNT(Request.Form["ImportoMax" + tipo.CodTipo + "_text"].Replace(".", ""));
                    SiarLibrary.NullTypes.DecimalNT importo_min = new SiarLibrary.NullTypes.DecimalNT(Request.Form["ImportoMin" + tipo.CodTipo + "_text"].Replace(".", ""));
                    SiarLibrary.NullTypes.DecimalNT quota_max = new SiarLibrary.NullTypes.DecimalNT(Request.Form["QuotaMax" + tipo.CodTipo + "_text"].Replace(".", ""));
                    SiarLibrary.NullTypes.DecimalNT quota_min = new SiarLibrary.NullTypes.DecimalNT(Request.Form["QuotaMin" + tipo.CodTipo + "_text"].Replace(".", ""));
                    SiarLibrary.NullTypes.IntNT numero = new SiarLibrary.NullTypes.IntNT(Request.Form["Numero" + tipo.CodTipo + "_text"].Replace(".", ""));
                    if (importo_max != null && importo_max > 0) tipo.ImportoMax = importo_max;
                    if (importo_min != null && importo_min > 0) tipo.ImportoMin = importo_min;
                    if (quota_max != null && quota_max > 0) tipo.QuotaMax = quota_max;
                    if (quota_min != null && quota_min > 0) tipo.QuotaMin = quota_min;
                    if (numero != null && numero > 0) tipo.Numero = numero;
                    else tipo.Numero = 1;

                    if (isPorFesr && !SiarLibrary.ControlliNaturaCup.ControllaTipoDomandePagamentoByNaturaCupBando(naturaCup, quota_max, codTipoPolizza, tipo))
                    {
                        throw new Exception("La natura cup del bando non permette di salvare la configurazione degli anticipi attuale.");
                    }

                    tpagamenti_provider.Save(tipo);
                }
                BandoProvider.DbProviderObj.Commit();
                string[] requisiti_selezionati = ((SiarLibrary.Web.CheckColumn)dgRequisiti.Columns[8]).GetSelected();

                 ShowMessage("Modifiche salvate correttamente." + (string.IsNullOrEmpty(avviso_domande_presentate) ? "" :
                    "<br />NB. nessuna modifica salvata invece per le seguenti tipologie in quanto hanno domande di pagamento presentate:" + avviso_domande_presentate)
                    + ((requisiti_selezionati.Length == 0) &&(tipi_selezionati.Length>0) ? "<br /><br />ATTENZIONE! Nessun requisito selezionato, si rischia di consentire la presentazione della domanda di pagamento senza poter effetuare controlli" : ""));
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnCaricaPagamento_Click(object sender, EventArgs e)
        {
            //mi serve solo il post?
            ((SiarLibrary.Web.CheckColumn)dgRequisiti.Columns[4]).ClearSelected();
            ((SiarLibrary.Web.CheckColumn)dgRequisiti.Columns[5]).ClearSelected();
            ((SiarLibrary.Web.CheckColumn)dgRequisiti.Columns[6]).ClearSelected();
            ((SiarLibrary.Web.CheckColumn)dgRequisiti.Columns[8]).ClearSelected();
        }

        void dgTipoPagamento_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.BandoTipoPagamento bt = (SiarLibrary.BandoTipoPagamento)e.Item.DataItem;
                e.Item.Cells[8].Text = "<input type='button' style='width:90px' class='ButtonGrid' value='Dettaglio' onclick=\"caricaPagamento('"
                    + bt.CodTipo + "')\" />";
                if (bt.IdBando != null)
                {
                    string testo_check = e.Item.Cells[7].Text;
                    e.Item.Cells[7].Text = testo_check.Replace("<input", "<input checked");
                }
                if (bt.CodTipo == hdnTipoPagamento.Value)
                {
                    e.Item.Cells[0].Style.Add("background-color", "#fefeee");
                    string testo_cella = e.Item.Cells[0].Text;
                    e.Item.Cells[0].Text = "<table width='100%'><tr><td width='30px' style='border:0'><img src='../../../images/config.ico' alt='Tipologia attualmente selezionata' /></td><td style='border:0'>"
                        + testo_cella + "</td></tr></table>";
                }

                SiarLibrary.Web.ComboTipoPolizza cmbPolizza = new SiarLibrary.Web.ComboTipoPolizza();
                cmbPolizza.ID = "cmbPolizza_" + bt.CodTipo;
                cmbPolizza.DataBind();
                cmbPolizza.SelectedValue = bt.CodTipoPolizza;
                e.Item.Cells[6].Controls.Add(cmbPolizza);
            }
        }

        #endregion

        #region requisiti x bando
        void dgRequisiti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer) lblTipoPagamento.Text = "(di cui " + nr_requisiti_associati.ToString() + " associati al "
                + lblTipoPagamento.Text + ")";
            else if (e.Item.ItemType != ListItemType.Header)
            {
                SiarLibrary.BandoRequisitiPagamento r = (SiarLibrary.BandoRequisitiPagamento)e.Item.DataItem;
                if (r.IdBando != null)
                {
                    nr_requisiti_associati++;
                    string testo_includi = e.Item.Cells[8].Text;
                    e.Item.Cells[8].Text = testo_includi.Replace("<input", "<input checked");
                    if (r.Obbligatorio)
                    {
                        string testo_obbligatorio = e.Item.Cells[4].Text;
                        e.Item.Cells[4].Text = testo_obbligatorio.Replace("<input", "<input checked");
                    }
                    if (r.RequisitoDiControllo)
                    {
                        string testo_req_di_controllo = e.Item.Cells[5].Text;
                        e.Item.Cells[5].Text = testo_req_di_controllo.Replace("<input", "<input checked");
                    }
                    if (r.RequisitoDiInserimento)
                    {
                        string testo_req_di_inserimento = e.Item.Cells[6].Text;
                        e.Item.Cells[6].Text = testo_req_di_inserimento.Replace("<input", "<input checked");
                    }
                }
            }
        }

        protected void btnSalvaRequisitiBando_Click(object sender, EventArgs e)
        {
            string[] requisiti_selezionati = ((SiarLibrary.Web.CheckColumn)dgRequisiti.Columns[8]).GetSelected();
            if (requisiti_selezionati.Length == 0) { ShowError("Nessun requisito selezionato. Impossibile continuare."); return; }
            if (string.IsNullOrEmpty(hdnTipoPagamento.Value) || new SiarBLL.BandoTipoPagamentoCollectionProvider().Find(Bando.IdBando, hdnTipoPagamento.Value, null)
                .Count == 0) { ShowError("Nessuna tipologia di pagamento selezionata."); return; }
            if (SiarLibrary.DbStaticProvider.GetDomandePresentateBandoTipoPagamento(Bando.IdBando, hdnTipoPagamento.Value, BandoProvider.DbProviderObj) > 0)
            { ShowError("Non è possibile modificare la tipologia di pagamento selezionata in quanto esistono domande di pagamento presentate."); return; }
            try
            {
                string chkObbligatori = Request.Form["chkRequisitoObbligatorio"], chkInserimento = Request.Form["chkRequisitoInserimento"],
                    chkControllo = Request.Form["chkRequisitoControllo"];
                bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                bando_requisiti_provider.DeleteCollection(bando_requisiti_provider.Find(Bando.IdBando, hdnTipoPagamento.Value, null));
                int salvataggio_requisiti_tralasciati = 0;
                SiarLibrary.BandoRequisitiPagamentoCollection requisiti_esistenti_multimisura = bando_requisiti_provider.
                    FindRequisitiEsistentiXMultimisura(Bando.IdBando, hdnTipoPagamento.Value);
                foreach (string s in requisiti_selezionati)
                {
                    int id_requisito;
                    if (!int.TryParse(s, out id_requisito)) throw new Exception("Nessun requisito selezionato. Impossibile continuare.");
                    if (requisiti_esistenti_multimisura.SubSelect(null, null, s, null, null, null, null).Count > 0)
                    {
                        salvataggio_requisiti_tralasciati++;
                        continue;
                    }
                    SiarLibrary.BandoRequisitiPagamento requisito = new SiarLibrary.BandoRequisitiPagamento();
                    requisito.IdBando = Bando.IdBando;
                    requisito.CodTipo = hdnTipoPagamento.Value;
                    requisito.IdRequisito = id_requisito;
                    requisito.Obbligatorio = TrovaStringa(s, chkObbligatori);
                    requisito.RequisitoDiControllo = TrovaStringa(s, chkControllo);
                    requisito.RequisitoDiInserimento = TrovaStringa(s, chkInserimento);
                    requisito.Ordine = new SiarLibrary.NullTypes.IntNT(Request.Form["txtRequisitoOrdine" + s + "_text"]);
                    bando_requisiti_provider.Save(requisito);
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

        #endregion

        #region modifica requisito

        protected void btnCaricaRequisito_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
            int id_requisito;
            if (!int.TryParse(hdnIdRequisito.Value, out id_requisito)) ShowError("Nessun requisito selezionato per la modifica.");
        }

        private void CaricaRequisito()
        {
            if (requisito_selezionato != null)
            {
                txtDescrizione.Text = requisito_selezionato.Descrizione;
                txtMisura.Text = requisito_selezionato.Misura;
                txtQueryLungaSQL.Text = requisito_selezionato.QueryEval;
                txtQueryInsertLunga.Text = requisito_selezionato.QueryInsert;
                if (requisito_selezionato.TestoArea) rblTipologia.SelectedValue = "A";
                else if (requisito_selezionato.Datetime) rblTipologia.SelectedValue = "D";
                else if (requisito_selezionato.Numerico) rblTipologia.SelectedValue = "N";
                else if (requisito_selezionato.Plurivalore) rblTipologia.SelectedValue = "P";
                else if (requisito_selezionato.TestoSemplice) rblTipologia.SelectedValue = "T";
                else if (!string.IsNullOrEmpty(requisito_selezionato.Url))
                {
                    rblTipologia.SelectedValue = "U";
                    trUrl.Style["display"] = "";
                    txtUrl.Text = requisito_selezionato.Url;
                }
                else trUrl.Style["display"] = "none";
                btnEliminaRequisito.Enabled = AbilitaModifica;
                btnSalvaRequisito.Enabled = AbilitaModifica;
                if (requisito_selezionato.Plurivalore) CaricaPlurivalori();
            }
            else btnEliminaRequisito.Enabled = false;
        }

        private void PulisciCampiRequisito()
        {
            txtDescrizione.Text = string.Empty;
            txtMisura.Text = string.Empty;
            txtQueryLungaSQL.Text = string.Empty;
            txtQueryInsertLunga.Text = string.Empty;
            txtUrl.Text = string.Empty;
            trUrl.Style["display"] = "none";
            rblTipologia.SelectedValue = null;
            hdnIdPlurivalore.Value = string.Empty;
            tbPlurivalori.Visible = false;
            btnEliminaRequisito.Enabled = false;
        }

        protected void btnSalvaRequisito_Click(object sender, EventArgs e)
        {
            try
            {
                requisiti_provider = new SiarBLL.RequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.RequisitiPagamento requisito;
                int id_requisito;
                if (int.TryParse(hdnIdRequisito.Value, out id_requisito))
                {
                    requisito = requisiti_provider.GetById(id_requisito);
                    if (requisito == null) throw new Exception("Nessun requisito selezionato per la modifica.");
                    bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                    if (bando_requisiti_provider.Find(null, null, id_requisito).Count > 0)
                        throw new Exception("Impossibile modificare il requisito, perché associato ad un bando.");
                }
                else requisito = new SiarLibrary.RequisitiPagamento();
                requisito.Descrizione = txtDescrizione.Text;
                requisito.Misura = txtMisura.Text;
                requisito.Url = txtUrl.Text;
                requisito.QueryEval = txtQueryLungaSQL.Text.Replace("`", "\'");
                requisito.QueryInsert = txtQueryInsertLunga.Text.Replace("`", "\'");
                requisito.Numerico = rblTipologia.SelectedValue == "N";
                requisito.Plurivalore = rblTipologia.SelectedValue == "P";
                requisito.TestoArea = rblTipologia.SelectedValue == "A";
                requisito.TestoSemplice = rblTipologia.SelectedValue == "T";
                requisito.Datetime = rblTipologia.SelectedValue == "D";

                // Se il requisito non è più plurivalore, allora elimino i relativi requisiti plurivalore
                if (!requisito.Plurivalore)
                {
                    plurivalori_provider = new SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider(BandoProvider.DbProviderObj);
                    plurivalori_provider.DeleteCollection(plurivalori_provider.Find(null, id_requisito, null));
                }
                requisiti_provider.Save(requisito);
                hdnIdRequisito.Value = requisito.IdRequisito;
                requisito_selezionato = requisito;
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Requisito di pagamento salvato correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaRequisito_Click(object sender, EventArgs e)
        {
            int id_requisito;
            if (!int.TryParse(hdnIdRequisito.Value, out id_requisito)) { ShowError("Nessun requisito selezionato per la modifica."); return; }
            try
            {
                plurivalori_provider = new SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider(BandoProvider.DbProviderObj);
                bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                requisiti_provider = new SiarBLL.RequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.RequisitiPagamento requisito = requisiti_provider.GetById(id_requisito);
                if (requisito == null) throw new Exception("Nessun requisito selezionato.");
                if (bando_requisiti_provider.Find(null, null, id_requisito).Count > 0)
                    throw new Exception("Impossibile eliminare il requisito, perché associato ad un bando.");
                plurivalori_provider.DeleteCollection(plurivalori_provider.Find(null, id_requisito, null));
                requisiti_provider.Delete(requisito);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Requisito eliminato correttamente.");
                PulisciCampiRequisito();
                hdnIdRequisito.Value = null;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        #endregion

        #region plurivalori

        private void CaricaPlurivalori()
        {
            tbPlurivalori.Visible = true;
            if (plurivalori_provider == null) plurivalori_provider = new SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider();
            SiarLibrary.RequisitiPagamentoPlurivaloreCollection plurivalori = plurivalori_provider.Find(null, requisito_selezionato.IdRequisito, null);
            dgValoriMultipli.Titolo = "<em>Elementi trovati: " + plurivalori.Count.ToString() + "</em>";
            dgValoriMultipli.DataSource = plurivalori;
            dgValoriMultipli.ItemDataBound += new DataGridItemEventHandler(dgValoriMultipli_ItemDataBound);
            dgValoriMultipli.DataBind();
            btnEliminaValore.Enabled = AbilitaModifica && !string.IsNullOrEmpty(hdnIdPlurivalore.Value);
        }

        void dgValoriMultipli_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.RequisitiPagamentoPlurivalore v = (SiarLibrary.RequisitiPagamentoPlurivalore)e.Item.DataItem;
                e.Item.Cells[3].Text = "<input type='button' style='width:90px' class='ButtonGrid' value='Dettaglio' onclick=\"caricaPlurivalore('"
                    + v.IdValore + "')\" />";
            }
        }

        protected void btnCaricaPlurivalore_Click(object sender, EventArgs e)
        {
            int id_plurivalore;
            if (!int.TryParse(hdnIdPlurivalore.Value, out id_plurivalore)) ShowError("Nessun valore selezionato.");
            else
            {
                plurivalori_provider = new SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider();
                SiarLibrary.RequisitiPagamentoPlurivalore valore = plurivalori_provider.GetById(id_plurivalore);
                if (valore == null) ShowError("Nessun valore selezionato.");
                else
                {
                    txtCodiceValoreMupltiplo.Text = valore.Codice;
                    txtdescValoreMultiplo.Text = valore.Descrizione;
                }
            }
        }

        protected void btnAssociaValoreMultiplo_Click(object sender, EventArgs e)
        {
            int id_requisito;
            if (!int.TryParse(hdnIdRequisito.Value, out id_requisito)) ShowError("Nessun requisito selezionato.");
            else
            {
                try
                {
                    plurivalori_provider = new SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider(BandoProvider.DbProviderObj);
                    bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                    requisiti_provider = new SiarBLL.RequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    if (requisiti_provider.GetById(id_requisito) == null) throw new Exception("Nessun requisito selezionato.");
                    if (bando_requisiti_provider.Find(null, null, id_requisito).Count > 0)
                        throw new Exception("Impossibile salvare il valore, perché il requisito di pagamento relativo è associato ad un bando.");

                    SiarLibrary.RequisitiPagamentoPlurivalore valore;
                    int id_plurivalore;
                    if (int.TryParse(hdnIdPlurivalore.Value, out id_plurivalore))
                    {
                        valore = plurivalori_provider.GetById(id_plurivalore);
                        if (valore == null) throw new Exception("Nessun valore selezionato.");
                    }
                    else
                    {
                        valore = new SiarLibrary.RequisitiPagamentoPlurivalore();
                        valore.IdRequisito = id_requisito;
                    }
                    valore.Descrizione = txtdescValoreMultiplo.Text;
                    valore.Codice = txtCodiceValoreMupltiplo.Text;
                    plurivalori_provider.Save(valore);
                    BandoProvider.DbProviderObj.Commit();
                    ShowMessage("Valore associato correttamente al requisito selezionato.");
                    hdnIdPlurivalore.Value = valore.IdValore;
                }
                catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
            }
        }

        protected void btnEliminaValoreMultipli_Click(object sender, EventArgs e)
        {
            int id_requisito, id_plurivalore;
            if (!int.TryParse(hdnIdRequisito.Value, out id_requisito)) ShowError("Nessun requisito selezionato.");
            else if (!int.TryParse(hdnIdPlurivalore.Value, out id_plurivalore)) ShowError("Nessun valore selezionato.");
            else
            {
                try
                {
                    plurivalori_provider = new SiarBLL.RequisitiPagamentoPlurivaloreCollectionProvider(BandoProvider.DbProviderObj);
                    bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                    requisiti_provider = new SiarBLL.RequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    if (requisiti_provider.GetById(id_requisito) == null) throw new Exception("Nessun requisito selezionato.");
                    if (bando_requisiti_provider.Find(null, null, id_requisito).Count > 0)
                        throw new Exception("Impossibile salvare il valore, perché il requisito di pagamento relativo è associato ad un bando.");

                    SiarLibrary.RequisitiPagamentoPlurivalore valore = plurivalori_provider.GetById(id_plurivalore);
                    if (valore == null) throw new Exception("Nessun valore selezionato.");
                    plurivalori_provider.Delete(valore);
                    BandoProvider.DbProviderObj.Commit();
                    ShowMessage("Valore eliminato correttamente.");
                    hdnIdPlurivalore.Value = string.Empty;
                    txtCodiceValoreMupltiplo.Text = string.Empty;
                    txtdescValoreMultiplo.Text = string.Empty;
                }
                catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
            }
        }

        #endregion
    }
}
