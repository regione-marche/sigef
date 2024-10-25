using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace web.Private.CertificazioneSpesa
{
    public partial class LottidiControllo : SiarLibrary.Web.CertificazioneSpesaPage
    {
        SiarBLL.CertspDomandePagamentoCollectionProvider cdomande_provider = new SiarBLL.CertspDomandePagamentoCollectionProvider();
        SiarBLL.CertspParametriXLottoCollectionProvider parametri_provider = new SiarBLL.CertspParametriXLottoCollectionProvider();
        SiarBLL.CertspLocoLottoCollectionProvider lotto_provider = new SiarBLL.CertspLocoLottoCollectionProvider();
        SiarLibrary.CertspLocoLotto lotto_selezionato;
        SiarLibrary.CertspDomandePagamentoCollection domande_selezionate;
        SiarLibrary.UtentiCollection operatori_adc;


        protected void Page_Load(object sender, EventArgs e)
        {
            int id_lotto;
            if (!IsPostBack && int.TryParse(Request.QueryString["idlotto"], out id_lotto)) hdnIdLotto.Value = id_lotto.ToString();
            if (int.TryParse(hdnIdLotto.Value, out id_lotto)) lotto_selezionato = lotto_provider.GetById(id_lotto);
            //hdnIdLotto.Text = "";
            if (!IsPostBack && Request.QueryString["action"] == "pag_non_selezionata")
                ShowError("Nessuna domanda di pagamento selezionata per il controllo.");
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstProgrammazione.AttivazioneBandi = true;
            lstProgrammazione.DataBind();
            SiarLibrary.CertspLocoLottoCollection lotti_controllo;
            if (lotto_selezionato == null)
            {
                lotti_controllo = lotto_provider.Find(null, lstProgrammazione.SelectedValue, null);
                dgLotti.Titolo = "Elementi trovati: " + lotti_controllo.Count.ToString();
            }
            else
            {
                lotti_controllo = new SiarLibrary.CertspLocoLottoCollection();
                lotti_controllo.Add(lotto_selezionato);
            }
            dgLotti.DataSource = lotti_controllo;
            dgLotti.ItemDataBound += new DataGridItemEventHandler(dgLotti_ItemDataBound);
            dgLotti.DataBind();
            bindControlli();
            base.OnPreRender(e);
        }

        private void bindControlli()
        {
            ucSiarNewTab.Visible = lotto_selezionato != null;
            tableDomande.Visible = ucSiarNewTab.TabSelected == 1 && lotto_selezionato != null;
            tableParametri.Visible = ucSiarNewTab.TabSelected == 2 && lotto_selezionato != null;
            if (lotto_selezionato != null)
            {
                switch (ucSiarNewTab.TabSelected)
                {
                    case 1:
                        ucSiarNewTab.Width = tableDomande.Width;
                        if (domande_selezionate == null) domande_selezionate = cdomande_provider.Find(lotto_selezionato.Id, null, null);
                        dgDomande.DataSource = domande_selezionate;
                        lblNumeroDomande.Text = domande_selezionate.Count.ToString();
                        if (domande_selezionate.Count > 0)
                        {
                            dgDomande.ItemDataBound += new DataGridItemEventHandler(dgDomande_ItemDataBound);
                            dgDomande.MostraTotale(4, "ContributoRichiesto");
                        }
                        dgDomande.DataBind();
                        btnCampione.Enabled = AbilitaModifica && domande_selezionate.Count > 0 && lotto_selezionato.NumeroEstrazioni == 0 && !lotto_selezionato.ControlloConcluso;
                        btnEstrazioneAggiuntiva.Enabled = AbilitaModifica && domande_selezionate.Count > 0 /*&& lotto_selezionato.NumeroEstrazioni > 0*/ && !lotto_selezionato.ControlloConcluso;
                        btnSalvaOperatori.Enabled = AbilitaModifica && lotto_selezionato.NumeroEstrazioni > 0 && !lotto_selezionato.ControlloConcluso;
                        btnSelezionaDomande.Enabled = btnEliminaLotto.Enabled = AbilitaModifica && lotto_selezionato.NumeroEstrazioni == 0 && !lotto_selezionato.ControlloConcluso;
                        break;
                    case 2:
                        if (lotto_selezionato.NumeroEstrazioni > 0) btnSalvaParametri.Enabled = false;
                        ucSiarNewTab.Width = tableParametri.Width;
                        SiarLibrary.CertspParametriXLottoCollection parametri_lotto = parametri_provider.FindByIdLotto(lotto_selezionato.Id);
                        dgParametri.DataSource = parametri_lotto;
                        dgParametri.ItemDataBound += new DataGridItemEventHandler(dgParametri_ItemDataBound);
                        dgParametri.DataBind();
                        break;
                }
            }
        }

        private void bindCollectionOperatori(ListItemCollection lista_items_combo, string operatore_assegnato)
        {
            if (operatori_adc == null) operatori_adc = new SiarBLL.UtentiCollectionProvider().Find(null, null, null, "AdC", null, null, null);
            lista_items_combo.Add(new ListItem("", ""));
            foreach (SiarLibrary.Utenti u in operatori_adc)
            {
                ListItem li = new ListItem(u.Nominativo, u.CfUtente);
                if (li.Value == operatore_assegnato) li.Selected = true;
                lista_items_combo.Add(li);
            }
        }

        void dgDomande_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CertspDomandePagamento cdp = (SiarLibrary.CertspDomandePagamento)e.Item.DataItem;
                e.Item.Cells[2].Text = "<img src='../../images/acrobat.gif' alt='Visualizza la domanda' onclick=\"SNCVisualizzaReport('rptDomandaPagamento',1,'IdDomandaPagamento="
                    + cdp.IdDomandaPagamento + "');\" onmouseover=\"this.style.cursor='pointer';\" />";
                if (cdp.SelezionataXControllo)
                {
                    HtmlSelect combo = new HtmlSelect();
                    combo.ID = "lstOperatori" + cdp.IdDomandaPagamento;
                    bindCollectionOperatori(combo.Items, cdp.OperatoreAssegnato);
                    e.Item.Cells[7].Controls.Add(combo);
                }

                #region colonna valore di rischio

                HtmlTable tb = new HtmlTable();
                tb.Attributes.Add("class", "tabella");
                tb.Width = "100%";
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                td.Width = "50%";
                if (cdp.ValoreDiRischio == null)
                {
                    td.InnerHtml = "<font color=grey>n.d.</font>";
                    btnCampione.Attributes.Add("onclick", "alert('Prima di estrarre il campione è necessario calcolare il valore di rischio per ogni domanda del lotto.');return false;");
                    btnEstrazioneAggiuntiva.Attributes.Add("onclick", "alert('Prima di estrarre il campione è necessario calcolare il valore di rischio per ogni domanda del lotto.');return false;");
                }
                else td.InnerText = string.Format("{0:0}", cdp.ValoreDiRischio.Value) + (string.IsNullOrEmpty(cdp.ClasseDiRischio) ? "" : "  ("
                    + cdp.ClasseDiRischio + ")");
                tr.Cells.Add(td);

                HtmlTableCell td2 = new HtmlTableCell();
                td2.Width = "50%";
                td2.InnerHtml = "<a href='javascript:mostraParametriXDomanda(" + cdp.IdDomandaPagamento
                    + ")'><img src='../../images/lente.ico' alt='Calcola valore di rischio' /></a>";
                tr.Cells.Add(td2);
                tb.Rows.Add(tr);
                e.Item.Cells[6].Controls.Add(tb);

                #endregion

                #region colonna estrazione a campione

                if (cdp.SelezionataXControllo)
                {
                    HtmlTable tbe = new HtmlTable();
                    tbe.Width = "100%";
                    tbe.Attributes.Add("class", "tabella");
                    HtmlTableRow tre = new HtmlTableRow();
                    HtmlTableCell tde = new HtmlTableCell();
                    tde.Width = "50%";
                    tde.Style.Add("font-weight", "bold");
                    tde.Style.Add("color", "green");
                    tde.InnerText = "SI";
                    tre.Cells.Add(tde);

                    HtmlTableCell tde2 = new HtmlTableCell();
                    tde2.Width = "50%";
                    tde2.InnerText = cdp.TipoEstrazione;
                    tde2.Attributes.Add("class", "testoRosso");
                    tre.Cells.Add(tde2);
                    tbe.Rows.Add(tre);
                    e.Item.Cells[5].Controls.Add(tbe);
                }

                #endregion

                if (cdp.SelezionataXControllo)
                {
                    HtmlInputButton btn = new HtmlInputButton();
                    btn.Attributes.Add("class", "ButtonGrid");
                    btn.Value = cdp.ControlloConcluso ? "Visualizza" : "Avvia controllo";
                    btn.Attributes.Add("onclick", "location='ControlloDomande.aspx?idlotto=" + cdp.IdLotto + "&idpag=" + cdp.IdDomandaPagamento + "'");
                    e.Item.Cells[8].Controls.Add(btn);
                }
            }
        }

        void dgParametri_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CertspParametriXLotto l = (SiarLibrary.CertspParametriXLotto)e.Item.DataItem;
                if (l.IdLotto != null) e.Item.Cells[4].Text = e.Item.Cells[4].Text.Replace("<input", "<input checked");
            }
        }

        void dgLotti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CertspLocoLotto l = (SiarLibrary.CertspLocoLotto)e.Item.DataItem;
                e.Item.Cells[8].Text = "<input type='checkbox' onclick='chkClick(" + l.Id + ",this);' " +
                    ((lotto_selezionato != null && l.Id == lotto_selezionato.Id) ? "checked" : "") + "/>";
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            //usata per il post sulle check dei lotti
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            lotto_selezionato = null;
            hdnIdLotto.Value = null;
        }

        protected void btnCreaLotto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(lstProgrammazione.SelectedValue))
                    throw new Exception("Per proseguire è necessario selezionare la programmazione sulla quale si intende creare il nuovo lotto di controllo.");
                SiarLibrary.CertspLocoLotto lotto = new SiarLibrary.CertspLocoLotto();
                lotto.DataCreazione = DateTime.Now;
                lotto.DataModifica = DateTime.Now;
                lotto.Operatore = Operatore.Utente.IdUtente;
                lotto.IdProgrammazione = lstProgrammazione.SelectedValue;
                lotto_provider.Save(lotto);
                lotto_selezionato = lotto_provider.GetById(lotto.Id);
                hdnIdLotto.Value = lotto.Id;
                ShowMessage("Lotto di controllo creato correttamente");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaLotto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (lotto_selezionato == null) throw new Exception("Nessun lotto selezionato. Impossibile continuare.");
                if (lotto_selezionato.NumeroEstrazioni > 0) throw new Exception("Non è possibile eliminare un lotto di cui sia stato estratto il campione.");
                lotto_provider.DbProviderObj.BeginTran();
                SiarBLL.CertspParametriXDomandaCollectionProvider parametridomanda_provider = new SiarBLL.CertspParametriXDomandaCollectionProvider(lotto_provider.DbProviderObj);
                parametridomanda_provider.DeleteCollection(parametridomanda_provider.Find(null, null, lotto_selezionato.Id, null));
                SiarBLL.CertspParametriXLottoCollectionProvider parametrilotto_provider = new SiarBLL.CertspParametriXLottoCollectionProvider(lotto_provider.DbProviderObj);
                parametrilotto_provider.DeleteCollection(parametrilotto_provider.Find(lotto_selezionato.Id, null, null, null));
                SiarBLL.CertspDomandePagamentoCollectionProvider domande_provider = new SiarBLL.CertspDomandePagamentoCollectionProvider(lotto_provider.DbProviderObj);
                domande_provider.DeleteCollection(domande_provider.Find(lotto_selezionato.Id, null, null));
                lotto_provider.Delete(lotto_selezionato);
                lotto_provider.DbProviderObj.Commit();
                lotto_selezionato = null;
                hdnIdLotto.Value = null;
                ShowMessage("Lotto di controllo eliminato correttamente.");
            }
            catch (Exception ex) { parametri_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaParametri_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (lotto_selezionato == null) throw new Exception("Nessun lotto selezionato. Impossibile continuare.");
                if (lotto_selezionato.NumeroEstrazioni > 0) throw new Exception("Non è possibile modificare i parametri del lotto una volta che sia stato estratto il campione.");
                parametri_provider.DbProviderObj.BeginTran();

                // annullo il valore di rischio gia' calcolato
                SiarBLL.CertspDomandePagamentoCollectionProvider domande_provider = new SiarBLL.CertspDomandePagamentoCollectionProvider(parametri_provider.DbProviderObj);
                SiarLibrary.CertspDomandePagamentoCollection domande_lotto = domande_provider.Find(lotto_selezionato.Id, null, null);
                foreach (SiarLibrary.CertspDomandePagamento d in domande_lotto)
                {
                    d.ClasseDiRischio = null;
                    d.OrdineClasseDiRischio = null;
                    d.ValoreDiRischio = null;
                    d.TipoEstrazione = null;
                    d.SelezionataXControllo = 0;
                    d.OperatoreAssegnato = null;
                    domande_provider.Save(d);
                }
                // elimino i singoli valori calcolati
                SiarBLL.CertspParametriXDomandaCollectionProvider parametridomanda_provider = new SiarBLL.CertspParametriXDomandaCollectionProvider(parametri_provider.DbProviderObj);
                parametridomanda_provider.DeleteCollection(parametridomanda_provider.Find(null, null, lotto_selezionato.Id, null));
                // elimino i parametri dal lotto
                parametri_provider.DeleteCollection(parametri_provider.Find(lotto_selezionato.Id, null, null, null));

                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgParametri.Columns[4]).GetSelected();
                foreach (string s in selezionati)
                {
                    SiarLibrary.CertspParametriXLotto nuovo = new SiarLibrary.CertspParametriXLotto();
                    nuovo.IdLotto = lotto_selezionato.Id;
                    nuovo.IdParametro = s;
                    //nuovo.PesoReale = peso_reale_parametro;
                    parametri_provider.Save(nuovo);
                }
                parametri_provider.DbProviderObj.Commit();
                ShowMessage("Parametri salvati correttamente.");
            }
            catch (Exception ex) { parametri_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSelezionaDomande_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (lotto_selezionato == null) throw new Exception("Nessun lotto selezionato. Impossibile continuare.");
                domande_selezionate = cdomande_provider.CreaElencoDomandeXControlliLoco(lotto_selezionato.Id);
                if (domande_selezionate.Count == 0) throw new Exception("Nessuna domanda di pagamento è stata attualmente predisposta a controllo. Elenco non creato.");
                lotto_selezionato.DataModifica = DateTime.Now;
                lotto_selezionato.Operatore = Operatore.Utente.IdUtente;
                lotto_provider.Save(lotto_selezionato);
                ShowMessage("Elenco di controllo creato correttamente. Sono state selezionate n. " + domande_selezionate.Count.ToString() + " domande di pagamento.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCampione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (lotto_selezionato == null) throw new Exception("Nessun lotto selezionato. Impossibile continuare.");
                int numero_domande_estratte = cdomande_provider.EstraiCampioneDomandeXControlliLoco(lotto_selezionato.Id, Operatore.Utente.IdUtente, false);
                switch (numero_domande_estratte)
                {
                    case -3:
                        ShowError("Prima di estrarre il campione è necessario calcolare il valore di rischio per ogni domanda del lotto.");
                        break;
                    case -2:
                        ShowError("Per estrarre il campione delle domande è necessario selezionare i parametri di rischio afferenti al lotto selezionato.");
                        ucSiarNewTab.TabSelected = 2;
                        break;
                    case -1:
                        ShowError("Si è verificato un errore nell`estrazione del campione delle domande.");
                        break;
                    case 0:
                        ShowError("Nessuna domanda estratta a campione per il lotto selezionato.");
                        break;
                    default:
                        lotto_selezionato.NumeroEstrazioni++;
                        ShowMessage("Nr. " + numero_domande_estratte.ToString() + " domande estratte a campione. Ora è possibile procedere con i controlli.");
                        break;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEstrazioneAggiuntiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (lotto_selezionato == null) throw new Exception("Nessun lotto selezionato. Impossibile continuare.");
                int numero_domande_estratte = cdomande_provider.EstraiCampioneDomandeXControlliLoco(lotto_selezionato.Id, Operatore.Utente.IdUtente, true);
                switch (numero_domande_estratte)
                {
                    case -3:
                        ShowError("Prima di estrarre il campione è necessario calcolare il valore di rischio per ogni domanda del lotto.");
                        break;
                    case -2:
                        ShowError("Per estrarre il campione delle domande è necessario selezionare i parametri di rischio afferenti al lotto selezionato.");
                        ucSiarNewTab.TabSelected = 2;
                        break;
                    case -1:
                        ShowError("Si è verificato un errore nell`estrazione del campione delle domande.");
                        break;
                    case 0:
                        ShowError("Nessuna domanda estratta in aggiunta al campione per il lotto selezionato.");
                        break;
                    default:
                        lotto_selezionato.NumeroEstrazioni++;
                        ShowMessage("Nr. " + numero_domande_estratte.ToString() + " domande estratte in aggiunta al campione.");
                        break;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaOperatori_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (lotto_selezionato == null) throw new Exception("Nessun lotto selezionato. Impossibile continuare.");
                domande_selezionate = cdomande_provider.Find(lotto_selezionato.Id, null, null);
                foreach (string s in Request.Form.AllKeys)
                {
                    int indice = s.IndexOf("lstOperatori");
                    if (indice >= 0)
                    {
                        string id_domanda_pagamento = s.Replace("lstOperatori", "").Substring(indice);
                        SiarLibrary.CertspDomandePagamento domanda = domande_selezionate.SubSelect(null, lotto_selezionato.Id, id_domanda_pagamento, null, null, null, null, null, null, null, null, null, null, null)[0];
                        domanda.OperatoreAssegnato = Request.Form[s];
                        cdomande_provider.Save(domanda);
                    }
                }
                ShowMessage("Operatori registrati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        #region punteggio domanda

        protected void btnCaricaParametriDomanda_Click(object sender, EventArgs e)
        {
            try
            {
                if (lotto_selezionato == null) throw new Exception("Nessun lotto selezionato. Impossibile continuare.");
                int id_domanda;
                if (!int.TryParse(hdnIdDomandaPagamento.Text, out id_domanda)) throw new Exception("Nessuna domanda di pagamento selezionata.");
                if (lotto_selezionato.NumeroEstrazioni > 0) btnCalcolaPunteggioDomanda.Enabled = false;
                SiarLibrary.CertspParametriXDomandaCollection parametri = new SiarBLL.CertspParametriXDomandaCollectionProvider().
                    GetListaParametriLotto(lotto_selezionato.Id, id_domanda);
                if (parametri.Count > 0)
                {
                    dgParametriDomanda.ItemDataBound += new DataGridItemEventHandler(dgParametriDomanda_ItemDataBound);
                    dgParametriDomanda.DataSource = parametri;
                }
                else
                {
                    lblParametriDomandaMessaggio.Text = "<b>Nessun parametro associato al lotto a cui appartiene la domanda selezionata.</b><br /><br />";
                    btnCalcolaPunteggioDomanda.Enabled = false;
                }
                dgParametriDomanda.DataBind();
                RegisterClientScriptBlock("mostraPopupTemplate('divParametriDomanda','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        int totale_punteggio_domanda = 0;
        void dgParametriDomanda_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CertspParametriXDomanda p = (SiarLibrary.CertspParametriXDomanda)e.Item.DataItem;
                if (!p.Manuale) e.Item.Cells[2].Text = e.Item.Cells[2].Text.Replace("<input type='text'",
                    "<input readonly='true' style='background-color:#dddddd' type='text'");
                if (p.IdDomandaPagamento != null && p.Punteggio != null) totale_punteggio_domanda += p.Punteggio;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.CssClass = "TotaliFooter";
                e.Item.Cells[0].Text = "";
                e.Item.Cells[1].Text = "TOTALE";
                e.Item.Cells[2].Text = "<input readonly='true' type='text' value=\"" + totale_punteggio_domanda.ToString()
                    + "\" style='background-color:#dddddd;text-align:right;WIDTH:60px' >";
            }
        }

        protected void btnCalcolaPunteggioDomanda_Click(object sender, EventArgs e)
        {
            SiarBLL.CertspParametriXDomandaCollectionProvider paramdomanda_provider = new SiarBLL.CertspParametriXDomandaCollectionProvider();
            try
            {
                int id_domanda;
                int counter = 0;
                int punteggio_totale = 0;

                if (!AbilitaModifica)
                {
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                }
                if (lotto_selezionato == null)
                {
                    throw new Exception("Nessun lotto selezionato. Impossibile continuare.");
                }
                if (!int.TryParse(hdnIdDomandaPagamento.Text, out id_domanda))
                {
                    throw new Exception("Nessuna domanda di pagamento selezionata.");
                }

                //carico la collection per aggiornare i punteggio totali delle domande
                if (domande_selezionate == null)
                {
                    domande_selezionate = cdomande_provider.Find(lotto_selezionato.Id, null, null);
                }

                paramdomanda_provider.DbProviderObj.BeginTran();
                paramdomanda_provider.DeleteCollection(paramdomanda_provider.Find(id_domanda, null, lotto_selezionato.Id, null));
                SiarLibrary.CertspParametriXDomandaCollection parametri = paramdomanda_provider.GetListaParametriLotto(lotto_selezionato.Id, id_domanda);                
                
                System.Data.IDbCommand cmd;
                foreach (SiarLibrary.CertspParametriXDomanda p in parametri)
                {
                    counter++;
                    p.MarkAsNew();
                    p.IdDomandaPagamento = id_domanda;
                    p.DataValutazione = DateTime.Now;
                    p.Operatore = Operatore.Utente.IdUtente;
                    if (p.Manuale)
                    {
                        int punteggio_manuale;
                        int.TryParse(Request.Form["txtPunteggioParametroDomanda" + p.IdParametro + "_text"], out punteggio_manuale);
                        p.Punteggio = punteggio_manuale;
                    }
                    else
                    {
                        if (p.QuerySql == null)
                        {
                            throw new Exception("Impossibile calcolare il punteggio del parametro n. " +
                                                counter.ToString() +
                                                " per mancanza della procedura informatica relativa.");
                        }
                        cmd = paramdomanda_provider.DbProviderObj.GetCommand();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = p.QuerySql;
                        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_LOTTO", lotto_selezionato.Id.Value));
                        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda));
                        object result = paramdomanda_provider.DbProviderObj.ExecuteScalar(cmd);
                        paramdomanda_provider.DbProviderObj.Close();
                        int punteggio_domanda;
                        if (int.TryParse(result.ToString(), out punteggio_domanda))
                        {
                            p.Punteggio = punteggio_domanda;
                        }
                    }
                    paramdomanda_provider.Save(p);
                    punteggio_totale += p.Punteggio;
                }

                SiarLibrary.CertspDomandePagamento dom = domande_selezionate.SubSelect(null, 
                                                                                       lotto_selezionato.Id, 
                                                                                       id_domanda, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null, 
                                                                                       null)[0];
                dom.ValoreDiRischio = punteggio_totale;
                dom.Operatore = Operatore.Utente.IdUtente;
                dom.DataModifica = DateTime.Now;
                cdomande_provider.Save(dom);

                paramdomanda_provider.DbProviderObj.Commit();
                lblParametriDomandaMessaggio.Text = "Punteggio calcolato correttamente.";
                btnCaricaParametriDomanda_Click(sender, e);

            }
            catch (Exception ex) 
            { 
                paramdomanda_provider.DbProviderObj.Rollback(); 
                lblParametriDomandaMessaggio.Text = "Attenzione! " + ex.Message; 
            }
        }

        #endregion
    }
}
