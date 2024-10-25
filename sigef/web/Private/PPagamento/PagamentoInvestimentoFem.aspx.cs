using System;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Extensions;
using SiarBLL;
using System.Linq;

namespace web.Private.PPagamento
{
    public partial class PagamentoInvestimentoFem : SiarLibrary.Web.DomandaPagamentoPage
    {
        decimal importo_investimento_richiesto = 0, importo_spese_richieste = 0, importo_investimento_ammesso = 0,
            importo_spese_ammesse = 0;

        SiarLibrary.PianoInvestimenti _investimento;
        ContrattiFem _contratto_selezionato;
        Giustificativi _giustificativo_selezionato;
        PagamentiRichiestiFem _pagamento_fem_selezionato;
        PagamentiRichiestiFem _pagamento_fem_eliminare;

        PianoInvestimentiCollectionProvider piano_provider;
        PagamentiRichiestiFemCollectionProvider pag_ric_fem_provider;
        ContrattiFemCollectionProvider contratti_provider;
        GiustificativiCollectionProvider giustificativi_provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                VworkflowPagamentoCollection workflow = new VworkflowPagamentoCollectionProvider().Find(null, "PINVE", null, null);
                ucWorkflowPagamento.WorkflowCorrente = workflow[0];
                ucWorkflowPagamento.ProseguiUrl = workflow[0].Url;

                InizializzaProvider();

                ucZoomLoaderContrattiPagati.KeySearch += "|IdDomandaPagamento:" + DomandaPagamento.IdDomandaPagamento + ":h";
                ucZoomLoaderGiustificativiPagati.KeySearch += "|IdDomandaPagamento:" + DomandaPagamento.IdDomandaPagamento + ":h";

                int id_investimento = 0;
                if (int.TryParse(Request.QueryString["idinv"], out id_investimento))
                    _investimento = piano_provider.GetById(id_investimento);
                if (_investimento == null)
                    throw new Exception("L'investimento selezionato non è valido.");

                ctrlSessione();
                if (_investimento.CodTipoInvestimento == 2 && _investimento.CostoInvestimento > 0) //vedi nota (*)
                    _investimento.QuotaContributoRichiesto = Math.Round(100 * _investimento.ContributoRichiesto / _investimento.CostoInvestimento, 2, MidpointRounding.AwayFromZero);

                AbilitaModifica = AbilitaModifica && DomandaPagamento.IdFidejussione == null;

                imgDettaglioInvestimento.Attributes.Add("onclick", "SNCVisualizzaReport('rptInvestimentoOriginale',1,'IdInvestimento=" + _investimento.IdInvestimento + "');");

                //string UtStrumFin = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_UtStrumFin(Progetto.IdBando);
                //if (UtStrumFin == "True")
                //    AltreFonti = true;
                //else
                //    AltreFonti = false;

                //if (AltreFonti)
                //{
                //    tdRichiestoAltreFonti.Visible = true;
                //    tdAmmessoAltreFonti.Visible = true;
                //}
                //else
                //{
                //    tdRichiestoAltreFonti.Visible = false;
                //    tdAmmessoAltreFonti.Visible = false;
                //}

                //if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
                //    ucWorkflowPagamento.InIntegrazione = true;
            }
            catch (Exception ex)
            {
                Redirect("PianoInvestimenti.aspx", ex.Message, true);
            }
        }

        private void InizializzaProvider()
        {
            piano_provider = new PianoInvestimentiCollectionProvider(PagamentoProvider.DbProviderObj);
            pag_ric_fem_provider = new PagamentiRichiestiFemCollectionProvider(PagamentoProvider.DbProviderObj);
            contratti_provider = new ContrattiFemCollectionProvider(PagamentoProvider.DbProviderObj);
            giustificativi_provider = new GiustificativiCollectionProvider(PagamentoProvider.DbProviderObj);
        }

        private void CaricaHidden()
        {
            int id_contratto;
            if (int.TryParse(ucZoomLoaderContrattiPagati.SelectedValue, out id_contratto))
                _contratto_selezionato = contratti_provider.GetById(id_contratto);

            int id_giustificativo;
            if (int.TryParse(ucZoomLoaderGiustificativiPagati.SelectedValue, out id_giustificativo))
                _giustificativo_selezionato = giustificativi_provider.GetById(id_giustificativo);

            int id_pagamento;
            if (int.TryParse(hdnIdPagamentoFem.Value, out id_pagamento))
                _pagamento_fem_selezionato = pag_ric_fem_provider.GetById(id_pagamento);

            int id_pagamento_el;
            if (int.TryParse(hdnIdPagamentoFemEliminare.Value, out id_pagamento_el))
                _pagamento_fem_eliminare = pag_ric_fem_provider.GetById(id_pagamento_el);
        }

        private void ctrlSessione()
        {
            if (_investimento.IdProgetto != Progetto.IdProgetto)
            {
                Progetto p = new ProgettoCollectionProvider().GetById(_investimento.IdProgetto);

                if (p == null || p.IdProgIntegrato != Progetto.IdProgetto)
                    throw new Exception("L'investimento selezionato non è valido.");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            CaricaHidden();

            PagamentiRichiestiFemCollection prichiesti = pag_ric_fem_provider.Find(null, null, _investimento.IdInvestimento, DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null); 

            if (prichiesti.Count > 0)
            {
                dgPagamenti.DataSource = prichiesti;
                lblNumeroContratti.Text = prichiesti.Count.ToString();
                dgPagamenti.ItemDataBound += new DataGridItemEventHandler(dgPagamenti_ItemDataBound);
                dgPagamenti.MostraTotale("DataField", 4, 6);
                dgPagamenti.MostraTotale("Importo", 5);

                if(prichiesti[0].Ammesso && DomandaPagamento.Approvata != null)
                {
                    tableValutazione.Visible = true;
                    txtValutazioneLunga.Text = prichiesti[0].NoteIstruttore;
                }
            }
            else
            {
                dgPagamenti.Titolo = "Pagamento non ancora richiesto.";
                lblNumeroContratti.Text = "0";
            }

            dgPagamenti.DataBind();

            popolaInvestimento();

            if ((AbilitaModifica && TipoModifica == 2) || (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione))
            {
                lnkNuovoContratto.HRef = "javascript:" + ucZoomLoaderContrattiPagati.SearchFunction;
                lnkNuovoGiustificativo.HRef = "javascript:" + ucZoomLoaderGiustificativiPagati.SearchFunction;
            }
            else
            {
                lnkNuovoGiustificativo.HRef = "javascript:alert('Modifica della domanda di pagamento disabilitata.');";
                lnkNuovoContratto.HRef = "javascript:alert('Modifica della domanda di pagamento disabilitata.');";
            }

            //if (prichiesto != null && prichiesto.Ammesso && DomandaPagamento.Approvata != null)
            //{
            //    tableValutazione.Visible = true;
            //    txtValutazioneLunga.Text = prichiesto.NoteIstruttore;
            //}

            base.OnPreRender(e);
        }

        decimal tot_imponibile = 0, tot_Importo_richiesto = 0, tot_contributo_richiesto = 0, tot_importo_ammesso = 0, tot_contributo_ammesso = 0,
            tot_importi = 0;

        void dgPagamenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_Tipologia = 1,
                col_Riferimenti = 2,
                col_Segnatura = 3,
                col_ImportoContratto = 4,
                col_ImportoRichiesto = 5,
                col_ImportoAmmesso = 6,
                col_Elimina = 7;

            DataGridItem dgi = (DataGridItem)e.Item;

            if (e.Item.ItemType == ListItemType.Header)
            {
                //dgi.Cells[0].RowSpan = 2;
                //dgi.Cells[1].ColumnSpan = 3;
                //dgi.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                //dgi.Cells[1].Text += "GIUSTIFICATIVO</td><td colspan=3 align=center>PAGAMENTO RICHIESTO</td><td align=center colspan=2>PAGAMENTO AMMESSO</td><td colspan=2></td></tr><tr class=TESTA><td>Riferimenti";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                PagamentiRichiestiFem pag = (PagamentiRichiestiFem)dgi.DataItem;

                if (pag.IdContratto != null)
                {
                    dgi.Cells[col_Tipologia].Text = "Contratto";
                    dgi.Cells[col_Riferimenti].Text =
                        "<b>Id contratto:</b> " + pag.IdContratto
                        + "<br /><b>Data contratto:</b> " + pag.DataContratto
                        + "<br /><b>Segnatura:</b> " + pag.SegnaturaContratto;
                    tot_importi += pag.ImportoContratto;
                }
                else if (pag.IdGiustificativo != null)
                {
                    var giustificativo = giustificativi_provider.GetById(pag.IdGiustificativo);

                    dgi.Cells[col_Tipologia].Text = "Giustificativo";
                    dgi.Cells[col_Riferimenti].Text =
                        "<b>Id giustificativo:</b> " + pag.IdGiustificativo
                        + "<br /><b>Data giustificativo:</b> " + pag.DataGiustificativo
                        + "<br /><b>Numero:</b> " + pag.NumeroGiustificativo;
                    dgi.Cells[col_Segnatura].Text = "<img src='../../images/acrobat.gif' alt='Visualizza documento' title='Visualizza documento'"
                        + "style='cursor:pointer' onclick=\"" + (giustificativo.IdFile == null ? "SNCVisualizzaReport('rptGiustificativo',1,'IdGiustificativo=" + pag.IdGiustificativo + "');"
                        : "SNCUFVisualizzaFile(" + giustificativo.IdFile + ");") + "\" />";
                    var max_imponibile = pag.ImponibileGiustificativo;
                    if (pag.IvaNonRecuperabileGiustificativo != null && pag.IvaNonRecuperabileGiustificativo)
                        max_imponibile = Math.Round(max_imponibile * (pag.IvaGiustificativo + 100) / 100, 2, MidpointRounding.AwayFromZero);
                    dgi.Cells[col_ImportoContratto].Text = string.Format("{0:c}", max_imponibile);
                    tot_importi += max_imponibile;
                }

                if(pag.IdImpresaContratto != null)
                    dgi.Cells[col_Riferimenti].Text += "<br /><b>Impresa:</b> " + pag.ImpresaContratto;

                if(DomandaPagamento != null 
                    && (DomandaPagamento.Segnatura != null || DomandaPagamento.Annullata == true))
                {
                    dgi.Cells[col_ImportoRichiesto].Enabled = false;
                    dgi.Cells[col_ImportoAmmesso].Enabled = false;
                    dgi.Cells[col_Elimina].Text = dgi.Cells[col_Elimina].Text.Replace(">", "disabled='disabled'>");
                }
            }
            else
            {
                dgi.Cells[col_ImportoContratto].Text = string.Format("{0:c}", tot_importi);
            }
        }

        private void popolaInvestimento()
        {
            // investimento
            if (_investimento.IdPrioritaSettoriale != null)
                tbInvestimento.Rows[0].Cells[1].InnerHtml += "<img src='../../images/star_red.gif' />";

            if (_investimento.CodVariazione != null)
                tbInvestimento.Rows[0].Cells[2].InnerHtml += "<b>(" + _investimento.CodVariazione + ")</b>";

            tbInvestimento.Rows[0].Cells[3].InnerHtml = "<b>" + _investimento.Misura + "</b>";

            if (_investimento.SettoreProduttivo != null)
                tbInvestimento.Rows[1].Cells[0].InnerHtml += "<b>Settore produttivo: </b>" + _investimento.SettoreProduttivo.ToString().ToUpper();

            tbInvestimento.Rows[2].Cells[0].InnerHtml = "<b>Codifica: </b>" + _investimento.CodificaInvestimento;
            tbInvestimento.Rows[3].Cells[0].InnerHtml = "<b>Dettaglio: </b>" + _investimento.DettaglioInvestimenti;
            tbInvestimento.Rows[4].Cells[0].InnerHtml = "<b>Descrizione: </b>" + _investimento.Descrizione;
            lblSpeseTecniche.Text = "Spese tecniche:";

            txtCostoInvestimento.Text = _investimento.CostoInvestimento;
            txtSpeseTecniche.Text = _investimento.SpeseGenerali;

            if (_investimento.CodTipoInvestimento == 2)
            {
                lblSpeseTecniche.Text = "Ammontare del mutuo:";
                txtCostoInvestimento.Text = _investimento.SpeseGenerali;
                txtSpeseTecniche.Text = _investimento.CostoInvestimento;
                lblFormulaCompletamento.Text = "(C/B)";
            }

            txtContributoAmmesso.Text = _investimento.ContributoRichiesto;
            txtQuotaAiuto.Text = _investimento.QuotaContributoRichiesto;

            //totali richiesti fino ad ora
            var pag_rich_inv_list = pag_ric_fem_provider.Find(null, null, _investimento.IdInvestimento, DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null)
                .ToArrayList<PagamentiRichiestiFem>();

            var importoTotaleRichiesto = pag_rich_inv_list
                .Sum(p => p.ImportoRichiesto ?? 0);
            if (importoTotaleRichiesto > 0)
            {
                var contributoTotaleRichiesto = importoTotaleRichiesto * _investimento.QuotaContributoRichiesto / 100;
                if (contributoTotaleRichiesto > _investimento.ContributoRichiesto)
                    contributoTotaleRichiesto = _investimento.ContributoRichiesto;

                txtImportoTotaleRichiesto.Text = importoTotaleRichiesto.ToString();
                txtContributoTotaleRichiesto.Text = contributoTotaleRichiesto.ToString();
            }

            //var importoTotaleAmmesso = pag_rich_inv_list
            //    .Select(p => p.ImportoAmmesso)
            //    .DefaultIfEmpty(0)
            //    .Sum();
            var importoTotaleAmmesso = pag_rich_inv_list
                .Sum(p => p.ImportoAmmesso ?? 0);
            if (importoTotaleAmmesso > 0)
            {
                var contributoTotaleAmmesso = importoTotaleAmmesso * _investimento.QuotaContributoRichiesto / 100;
                if (contributoTotaleAmmesso > _investimento.ContributoRichiesto)
                    contributoTotaleAmmesso = _investimento.ContributoRichiesto;

                txtImportoTotaleAmmesso.Text = importoTotaleAmmesso.ToString();
                txtContributoTotaleAmmesso.Text = contributoTotaleAmmesso.ToString();
            }

            txtImportoComputoMetrico.Text = null;
            txtImportoInvestimento.Text = null;
            txtImportoSpeseTecniche.Text = null;

            btnSalva.Enabled = AbilitaModifica; 
        }

        private PagamentiRichiestiFem popolaNuovoPagamento()
        {
            var new_pagamento = new PagamentiRichiestiFem();
            new_pagamento.DataInserimento = DateTime.Now;
            new_pagamento.CfInserimento = Operatore.Utente.CfUtente;
            new_pagamento.IdInvestimento = _investimento.IdInvestimento;
            new_pagamento.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;

            if (_contratto_selezionato != null && _contratto_selezionato.IdContrattoFem != null)
            {
                new_pagamento.IdContratto = _contratto_selezionato.IdContrattoFem;
                new_pagamento.ImportoRichiesto = _contratto_selezionato.Importo;
            }
            else if (_giustificativo_selezionato != null && _giustificativo_selezionato.IdGiustificativo != null)
            {
                new_pagamento.IdGiustificativo = _giustificativo_selezionato.IdGiustificativo;
                if (_giustificativo_selezionato.IvaNonRecuperabile != null && _giustificativo_selezionato.IvaNonRecuperabile)
                    new_pagamento.ImportoRichiesto = Math.Round(_giustificativo_selezionato.Imponibile * (_giustificativo_selezionato.Iva + 100) / 100, 2, MidpointRounding.AwayFromZero);
                else
                    new_pagamento.ImportoRichiesto = _giustificativo_selezionato.Imponibile;
            }

            return new_pagamento;
        }

        /// <summary>
        /// inserimento nuovo pagamento da contratto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAggiungiPagamentoContratto_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();
                CaricaHidden();

                if (_contratto_selezionato != null)
                {
                    PagamentoProvider.DbProviderObj.BeginTran();

                    var pagamento = popolaNuovoPagamento();
                    pag_ric_fem_provider.Save(pagamento);
                    PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                    PagamentoProvider.DbProviderObj.Commit();
                    ucZoomLoaderContrattiPagati.UnselectItem();
                    hdnIdPagamentoFem.Value = null;

                    ShowMessage("Pagamento associato correttamente.");
                }
                else
                    throw new Exception("Contratto non selezionato.");
            }
            catch (Exception ex)
            {
                PagamentoProvider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }

        /// <summary>
        /// inserimento nuovo pagamento da giustificativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAggiungiPagamentoGiustificativo_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();
                CaricaHidden();

                if (_giustificativo_selezionato != null)
                {
                    PagamentoProvider.DbProviderObj.BeginTran();

                    var pagamento = popolaNuovoPagamento();
                    pag_ric_fem_provider.Save(pagamento);
                    PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                    PagamentoProvider.DbProviderObj.Commit();
                    ucZoomLoaderGiustificativiPagati.UnselectItem();
                    hdnIdPagamentoFem.Value = null;

                    ShowMessage("Pagamento associato correttamente.");
                }
                else
                    throw new Exception("Giustificativo non selezionato.");
            }
            catch (Exception ex)
            {
                PagamentoProvider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }

        /// <summary>
        /// elimina il pagamento selezionato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();
                CaricaHidden();

                if (_pagamento_fem_eliminare != null)
                {
                    if (DomandaPagamento.Segnatura != null)
                        throw new Exception("Impossibile modificare i dati di una domanda firmata.");

                    if (DomandaPagamento.Annullata == true)
                        throw new Exception("Impossibile modificare i dati di una domanda annullata.");

                    PagamentoProvider.DbProviderObj.BeginTran();

                    pag_ric_fem_provider.Delete(_pagamento_fem_eliminare);
                    PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                    PagamentoProvider.DbProviderObj.Commit();
                    hdnIdPagamentoFemEliminare.Value = null;

                    ShowMessage("Pagamento eliminato correttamente.");
                }
                else
                    throw new Exception("Pagamento non selezionato.");
            }
            catch (Exception ex)
            {
                PagamentoProvider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }

        /// <summary>
        /// bottone salva generale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRichiesto_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();

                var pag_richiesti_inv = pag_ric_fem_provider.Find(null, null, _investimento.IdInvestimento, DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null);
                foreach (PagamentiRichiestiFem pag in pag_richiesti_inv)
                {
                    var text_richiesto = Request.Form["ImportoRichiesto" + pag.IdPagamentoRichiestoFem.ToString() + "_text"];
                    if (text_richiesto == null || text_richiesto == "")
                        throw new Exception("Non è stato inserito l'importo richiesto per il contratto con id " + pag.IdContratto + ". Correggere l'importo ammesso e riprovare.");

                    var imp_richiesto = Convert.ToDecimal(text_richiesto);
                    if (pag.IdContratto != null)
                    {
                        if (imp_richiesto < 0)
                            throw new Exception("Non è possibile richiedere un importo negativo per il contratto con id " + pag.IdContratto + ". Correggere gli importi richiesti e riprovare.");

                        if (imp_richiesto > pag.ImportoContratto)
                            throw new Exception("Non è possibile richiedere un importo maggiore di quello del contratto con id " + pag.IdContratto + ". Correggere gli importi richiesti e riprovare.");
                    }
                    else if (pag.IdGiustificativo != null)
                    {
                        if (imp_richiesto < 0)
                            throw new Exception("Non è possibile richiedere un importo negativo per il giustificativo con id " + pag.IdGiustificativo + ". Correggere gli importi richiesti e riprovare.");

                        var max_imponibile = pag.ImponibileGiustificativo;
                        if (pag.IvaNonRecuperabileGiustificativo != null && pag.IvaNonRecuperabileGiustificativo)
                            max_imponibile = Math.Round(max_imponibile * (pag.IvaGiustificativo + 100) / 100, 2, MidpointRounding.AwayFromZero);
                        if (imp_richiesto > max_imponibile)
                            throw new Exception("Non è possibile richiedere un importo maggiore di quello del giustificativo con id " + pag.IdGiustificativo + ". Correggere gli importi richiesti e riprovare.");
                    }

                    if (pag.ImportoRichiesto != imp_richiesto)
                    {
                        pag.DataModifica = DateTime.Now;
                        pag.CfModifica = Operatore.Utente.CfUtente;
                        pag.ImportoRichiesto = imp_richiesto;
                        pag_ric_fem_provider.Save(pag);
                    }
                }

                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Dati di richiesta pagamento salvati correttamente.");
            }
            catch (Exception ex)
            {
                PagamentoProvider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }
    }
}