using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using SiarLibrary;
using SiarBLL;
using System.Linq;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaInvestimentoFem : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        decimal importo_investimento_richiesto = 0, importo_spese_richieste = 0, importo_investimento_ammesso = 0,
            importo_spese_ammesse = 0, totale_sanzioni = 0;
        SiarLibrary.PianoInvestimenti _investimento;
        PianoInvestimentiCollectionProvider investimenti_provider;
        NoteCollectionProvider note_provider;

        PagamentiRichiestiFemCollectionProvider pag_ric_fem_provider;
        PagamentiRichiestiFem _pagamento_fem_salvataggio;

        bool AltreFonti;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();
                
                int id_investimento;
                if (int.TryParse(Request.QueryString["idinv"], out id_investimento))
                    _investimento = investimenti_provider.GetById(id_investimento);
                if (_investimento == null)
                    throw new Exception("L`investimento selezionato non è valido.");
                ctrlSessione();
                if (_investimento.CodTipoInvestimento == 2 && _investimento.CostoInvestimento > 0)
                    _investimento.QuotaContributoRichiesto = Math.Round(100 * _investimento.ContributoRichiesto / _investimento.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                lnkInvestimento.HRef = "javascript:mostraStoricoInvestimento(" + _investimento.IdInvestimento + ")";
                
                //string UtStrumFin = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_UtStrumFin(Progetto.IdBando);
                //if (UtStrumFin == "True") AltreFonti = true;
                //else
                //    AltreFonti = false;
                //if (AltreFonti)
                //{
                //    tdAmmessoAltreFonti.Visible = true;
                //    tdRichiestoAltreFonti.Visible = true;
                //}
                //else
                //{
                //    tdRichiestoAltreFonti.Visible = false;
                //    tdAmmessoAltreFonti.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                Redirect("IstruttoriaPianoInvestimenti.aspx", ex.Message, true);
            }
        }

        private void InizializzaProvider()
        {
            investimenti_provider = new PianoInvestimentiCollectionProvider(PagamentoProvider.DbProviderObj);
            pag_ric_fem_provider = new PagamentiRichiestiFemCollectionProvider(PagamentoProvider.DbProviderObj);
            note_provider = new SiarBLL.NoteCollectionProvider(PagamentoProvider.DbProviderObj);
        }

        private void CaricaHidden()
        {
            //int id_pagamento;
            //if (int.TryParse(hdnIdPagamentoFem.Value, out id_pagamento))
            //    _pagamento_fem_selezionato = pag_ric_fem_provider.GetById(id_pagamento);

            int id_pagamento_el;
            if (int.TryParse(hdnIdPagamentoFemSalvataggio.Value, out id_pagamento_el))
                _pagamento_fem_salvataggio = pag_ric_fem_provider.GetById(id_pagamento_el);
        }

        private void ctrlSessione()
        {
            if (_investimento.IdProgetto != Progetto.IdProgetto)
            {
                var p = new ProgettoCollectionProvider().GetById(_investimento.IdProgetto);
                if (p == null || p.IdProgIntegrato != Progetto.IdProgetto)
                    throw new Exception("L'investimento selezionato non è valido.");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Request.QueryString["redir"] == "revisione")
                btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag=" + DomandaPagamento.IdDomandaPagamento + "'";

            var pag_rich_fem_coll = pag_ric_fem_provider.Find(null, null, _investimento.IdInvestimento, DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null);
            dgPagamenti.DataSource = pag_rich_fem_coll;
            lblNumeroPagamenti.Text = pag_rich_fem_coll.Count.ToString();
            dgPagamenti.ItemDataBound += new DataGridItemEventHandler(dgPagamenti_ItemDataBound);
            dgPagamenti.MostraTotale("DataField", 4, 5);
            dgPagamenti.MostraTotale("Importo", 6);
            dgPagamenti.DataBind();

            popolaInvestimento();

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
                col_Salva = 7;

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
                    dgi.Cells[col_Tipologia].Text = "Giustificativo";
                    dgi.Cells[col_Riferimenti].Text =
                        "<b>Id giustificativo:</b> " + pag.IdGiustificativo
                        + "<br /><b>Data giustificativo:</b> " + pag.DataGiustificativo
                        + "<br /><b>Numero:</b> " + pag.NumeroGiustificativo;
                    dgi.Cells[col_Segnatura].Text = "";
                    var max_imponibile = pag.ImponibileGiustificativo;
                    if (pag.IvaNonRecuperabileGiustificativo != null && pag.IvaNonRecuperabileGiustificativo)
                        max_imponibile = Math.Round(max_imponibile * (pag.IvaGiustificativo + 100) / 100, 2, MidpointRounding.AwayFromZero);
                    dgi.Cells[col_ImportoContratto].Text = string.Format("{0:c}", max_imponibile);
                    tot_importi += max_imponibile;
                }

                if (pag.IdImpresaContratto != null)
                    dgi.Cells[col_Riferimenti].Text += "<br /><b>Impresa:</b> " + pag.ImpresaContratto;

                if (DomandaPagamento != null
                    && (DomandaPagamento.SegnaturaApprovazione != null || DomandaPagamento.Annullata == true))
                {
                    dgi.Cells[col_ImportoRichiesto].Enabled = false;
                    dgi.Cells[col_ImportoAmmesso].Enabled = false;
                    dgi.Cells[col_Salva].Text = dgi.Cells[col_Salva].Text.Replace(">", "disabled='disabled'>");
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

            if (pag_rich_inv_list.First().NoteIstruttore != null)
                txtValutazioneLunga.Text = pag_rich_inv_list.First().NoteIstruttore;

            //btnSalva.Enabled = AbilitaModifica;
        }

        private bool checkAltreDomandeProgetto(SiarLibrary.NullTypes.IntNT intNT)
        {
            // se ci sono altre domande di pagamento controllo che siano tutte firmate altrimenti non posso spalmare nessuna cifra.
            DomandaDiPagamentoCollection domande = new DomandaDiPagamentoCollectionProvider().Find(null, null, DomandaPagamento.IdProgetto, null);
            bool ok = true;
            if (domande.Count > 1)
            {
                foreach (DomandaDiPagamento d in domande)
                {
                    if (d.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento)
                    {
                        if (d.SegnaturaApprovazione == null && !d.Annullata && d.SegnaturaAnnullamento == null)
                            ok = false;
                    }
                }
            }
            return ok;
        }

        private void SalvaPagamentiRichiesti()
        {
            var pag_rich_fem_coll = pag_ric_fem_provider.Find(null, null, _investimento.IdInvestimento, DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null);

            foreach(PagamentiRichiestiFem pag in pag_rich_fem_coll)
            {
                var text_ammesso = Request.Form["ImportoAmmesso" + pag.IdPagamentoRichiestoFem.ToString() + "_text"];
                if (text_ammesso == null || text_ammesso == "")
                    throw new Exception("Non è stato inserito l'importo ammesso per il contratto con id " + pag.IdContratto + ". Correggere l'importo ammesso e riprovare.");

                var imp_ammesso = Convert.ToDecimal(text_ammesso);
                if (imp_ammesso < 0)
                    throw new Exception("Non è possibile ammettere un importo negativo per il contatto con id " + pag.IdContratto + ". Correggere l'importo ammesso e riprovare.");
                if (imp_ammesso > pag.ImportoRichiesto)
                    throw new Exception("Non è possibile richiedere un importo maggiore del richiesto per il contatto con id " + pag.IdContratto + ". Correggere l'importo ammesso e riprovare.");

                if(pag.ImportoAmmesso != imp_ammesso)
                    pag.ImportoAmmesso = imp_ammesso;

                pag.Ammesso = true;
                pag.DataValutazione = DateTime.Now;
                pag.CfIstruttore = Operatore.Utente.CfUtente;
                pag.NoteIstruttore = txtValutazioneLunga.Text;
                pag_ric_fem_provider.Save(pag);
            }
        }

        /// <summary>
        /// salva il pagamento selezionato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();
                CaricaHidden();

                if (_pagamento_fem_salvataggio != null)
                {
                    PagamentoProvider.DbProviderObj.BeginTran();

                    var text_ammesso = Request.Form["ImportoAmmesso" + _pagamento_fem_salvataggio.IdPagamentoRichiestoFem.ToString() + "_text"];
                    if (text_ammesso == null || text_ammesso == "")
                        throw new Exception("Non è stato inserito l'importo ammesso per il contratto con id " + _pagamento_fem_salvataggio.IdContratto + ". Correggere l'importo ammesso e riprovare.");

                    var imp_ammesso = Convert.ToDecimal(text_ammesso);
                    if (imp_ammesso < 0)
                        throw new Exception("Non è possibile ammettere un importo negativo. Correggere l'importo ammesso e riprovare.");
                    if (imp_ammesso > _pagamento_fem_salvataggio.ImportoRichiesto)
                        throw new Exception("Non è possibile richiedere un importo maggiore del richiesto. Correggere l'importo ammesso e riprovare.");

                    if (_pagamento_fem_salvataggio.ImportoAmmesso != imp_ammesso)
                    {
                        _pagamento_fem_salvataggio.DataValutazione = DateTime.Now;
                        _pagamento_fem_salvataggio.DataModifica = DateTime.Now;
                        _pagamento_fem_salvataggio.CfIstruttore = Operatore.Utente.CfUtente;
                        _pagamento_fem_salvataggio.CfModifica = Operatore.Utente.CfUtente;
                        _pagamento_fem_salvataggio.Ammesso = true;
                        _pagamento_fem_salvataggio.ImportoAmmesso = imp_ammesso;
                        pag_ric_fem_provider.Save(_pagamento_fem_salvataggio);
                    }

                    PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                    PagamentoProvider.DbProviderObj.Commit();
                    hdnIdPagamentoFemSalvataggio.Value = null;

                    ShowMessage("Pagamento salvato correttamente.");
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

        protected void btnSaveRichiesto_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();

                PagamentoProvider.DbProviderObj.BeginTran();
                SalvaPagamentiRichiesti();
                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Dati di pagamento salvati correttamente.");
            }
            catch (Exception ex)
            {
                pag_ric_fem_provider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }
    }
}