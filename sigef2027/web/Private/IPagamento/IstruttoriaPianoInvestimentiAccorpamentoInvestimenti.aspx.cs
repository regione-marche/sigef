using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaPianoInvestimentiAccorpamentoInvestimenti : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarLibrary.PianoInvestimentiCollection investimenti;
        SiarLibrary.PagamentiRichiestiCollection pagamenti_richiesti;
        SiarBLL.PagamentiRichiestiCollectionProvider prichiesti_provider;
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
        SiarLibrary.PianoInvestimenti premiocc = null;
        SiarLibrary.BandoTipoInvestimentiCollection tipo_investimenti = null;

        decimal pag_inv_disavanzo_totale = 0, pag_inv_disavanzo_totale_contributo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Progetto.IdProgIntegrato == null) 
            //    btnDettaglioMisura.Visible = false;
            prichiesti_provider = new SiarBLL.PagamentiRichiestiCollectionProvider(investimenti_provider.DbProviderObj);
            tipo_investimenti = new SiarBLL.BandoTipoInvestimentiCollectionProvider().GetTipoInvestimentiProgetto(Progetto.IdBando, true);
            RegisterClientScriptBlock("abilitaScroll();");
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Request.QueryString["redir"] == "revisione")
                btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag=" + DomandaPagamento.IdDomandaPagamento + "'";

            investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
            // pagamenti richiesti nella presente domanda di pagamento (non compresi nella query del piano investimento)
            pagamenti_richiesti = prichiesti_provider.Find(null, null, Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
            SiarLibrary.PianoInvestimentiCollection inv_supp = null;
            //investimenti ordinari
            if (tipo_investimenti.FiltroCodiceTipo(1).Count > 0)
            {
                tableInvestimenti.Visible = true;
                inv_supp = investimenti.FiltroTipoInvestimento(1);
                dgInvestimenti.DataSource = inv_supp;
                if (inv_supp.Count == 0) dgInvestimenti.Titolo = "Nessun elemento trovato.";
                else
                {
                    dgInvestimenti.ItemDataBound += new DataGridItemEventHandler(dgInvestimenti_ItemDataBound);
                    dgInvestimenti.MostraTotale("DataField", 4, 5, 6);
                    tbLegendaInvestimenti.Visible = true;
                }
                dgInvestimenti.DataBind();
            }

            // brevetti e licenze
            if (tipo_investimenti.FiltroCodiceTipo(5).Count > 0)
            {
                tableBrevetti.Visible = true;
                inv_supp = investimenti.FiltroTipoInvestimento(5);
                dgBrevetti.DataSource = inv_supp;
                if (inv_supp.Count == 0) dgBrevetti.Titolo = "Nessun elemento trovato.";
                else
                {
                    dgBrevetti.ItemDataBound += new DataGridItemEventHandler(dgBrevetti_ItemDataBound);
                    dgBrevetti.MostraTotale("DataField", 2, 3);
                }
                dgBrevetti.DataBind();
            }

            // fidejussione
            if (tipo_investimenti.FiltroCodiceTipo(4).Count > 0)
            {
                tableFidejussione.Visible = true;
                inv_supp = investimenti.FiltroTipoInvestimento(4);
                dgFidejussione.DataSource = inv_supp;
                if (inv_supp.Count == 0) dgFidejussione.Titolo = "Nessun elemento trovato.";
                else dgFidejussione.ItemDataBound += new DataGridItemEventHandler(dgFidejussione_ItemDataBound);
                dgFidejussione.DataBind();
            }

            //mutuo
            if (tipo_investimenti.FiltroCodiceTipo(2).Count > 0)
            {
                tableMutuo.Visible = true;
                inv_supp = investimenti.FiltroTipoInvestimento(2);
                dgMutuo.DataSource = inv_supp;
                if (inv_supp.Count == 0) dgMutuo.Titolo = "Nessun elemento trovato.";
                else dgMutuo.ItemDataBound += new DataGridItemEventHandler(dgMutuo_ItemDataBound);
                dgMutuo.DataBind();
            }

            // premio in conto capitale
            if (tipo_investimenti.FiltroCodiceTipo(3).Count > 0 && DomandaPagamento.CodTipo == "SLD")
            {
                tablePremio.Visible = true;
                premiocc = investimenti_provider.CalcoloPremioSaldo(DomandaPagamento.IdDomandaPagamento, 1);
                decimal anticipo_percepito = 0;
                //calcolo l'anticipo erogato
                SiarLibrary.DomandaDiPagamentoCollection anticipo = PagamentoProvider.Find(null, "ANT", Progetto.IdProgetto, null).FiltroApprovata(true);
                if (anticipo.Count > 0)
                {
                    SiarLibrary.AnticipiRichiestiCollection anticipi = new SiarBLL.AnticipiRichiestiCollectionProvider().Find(null,
                        anticipo[0].IdDomandaPagamento, Progetto.IdBando);
                    if (anticipi.Count > 0) anticipo_percepito = anticipi[0].ContributoAmmesso;
                }
                txtPCCAmmontare.Text = premiocc != null ? premiocc.CostoInvestimento : 0;
                txtPCCAnticipo.Text = anticipo_percepito.ToString();
                txtPCCRimanente.Text = (premiocc != null ? premiocc.CostoInvestimento - anticipo_percepito : 0).ToString();
                //foreach (SiarLibrary.BandoProgrammazione bp in disposizioni_attuative)
                //{
                //    if (Progetto.IdProgetto == new SiarLibrary.NullTypes.IntNT(bp.AdditionalAttributes["IdProgetto"]))
                //    {
                //        txtPCCProgrammazione.Text = bp.Codice;
                //        break;
                //    }
                //}
            }
            imgRedStar.Src = Request.ApplicationPath + "/images/star_red.gif";

            if (!AbilitaModifica)
                btnAccorporaVociPiano.Enabled = false;

            base.OnPreRender(e);
        }

        decimal costo_investimenti = 0, contributo_investimenti = 0, pag_inv_costo_richiesto = 0, pag_inv_contributo_richiesto = 0,
            pag_inv_contributo_ammesso = 0, pag_inv_importo_ammesso = 0, pag_inv_disavanzo_assengato = 0;
        void dgInvestimenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;            

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti f = (SiarLibrary.PianoInvestimenti)dgi.DataItem;
                if (f.IdPrioritaSettoriale != null) dgi.Cells[0].Text = "<img src='" + Request.ApplicationPath + "/images/star_red.gif'><br /><br />" + dgi.Cells[0].Text;
                dgi.Cells[2].Text = "<b>Codifica:</b> " + f.CodificaInvestimento + "<br /><b>Dettaglio:</b> " + f.DettaglioInvestimenti
                    + "<br /><b>Descrizione:</b> " + f.Descrizione;
                //Aggregazione
                string[] Aggregazione = new string[2];
                Aggregazione = investimenti_provider.GetImpresaAggregazioneInvestimento(f.IdInvestimento);
                if (Aggregazione[0] != null && Aggregazione[1] != null && Aggregazione[0] != "" && Aggregazione[1] != "")
                {
                    dgi.Cells[2].Text += "<br /><b>Impresa: </b>" + Aggregazione[0] + " - " + Aggregazione[1];
                    SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);
                    if (impresa.CodAteco2007 != null && impresa.CodAteco2007 != "")
                        dgi.Cells[2].Text += " - Ateco: " + impresa.CodAteco2007;
                }
                if (f.NonCofinanziato) e.Item.Cells[5].Text = "(*)";
                decimal importo_pagamento_richiesti, quota_completamento = 0, quota_completamento_ammesso = 0, costo_investimento = f.CostoInvestimento.Value + (f.SpeseGenerali ?? 0), spese_ammesse = 0;

                // importo_pagamento_richiesti rappresenta il totale dei pagamenti già richiesti
                decimal.TryParse(f.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                SiarLibrary.PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(f.IdInvestimento);
                if (pagamenti.Count > 0)
                {
                    // devo aggiungere il pagamento richiesto attuale non contato dalla query
                    importo_pagamento_richiesti += pagamenti[0].ImportoRichiesto;
                    pag_inv_costo_richiesto += pagamenti[0].ImportoRichiesto;
                    pag_inv_contributo_richiesto += pagamenti[0].ContributoRichiesto;
                    dgi.Cells[7].Text = string.Format("{0:c}", pagamenti[0].ImportoRichiesto);
                    dgi.Cells[8].Text = string.Format("{0:c}", pagamenti[0].ContributoRichiesto);
                    dgi.Cells[9].Text = string.Format("{0:c}", pagamenti[0].ImportoAmmesso);

                    // VERIFICARE SE DEVE ESSERE DIVERSO DA NULL???
                    if (pagamenti[0].ImportoAmmesso != null)
                        pag_inv_importo_ammesso += pagamenti[0].ImportoAmmesso;
                    if (pagamenti[0].ContributoAmmesso != null)
                    {
                        dgi.Cells[10].Text = string.Format("{0:c}", pagamenti[0].ContributoAmmesso);
                        pag_inv_contributo_ammesso += pagamenti[0].ContributoAmmesso;
                    }
                    if (pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                    {
                        dgi.Cells[14].Text = string.Format("{0:c}", pagamenti[0].ContributoDisavanzoCostiAmmessi);
                        pag_inv_disavanzo_assengato += pagamenti[0].ContributoDisavanzoCostiAmmessi;
                    }
                    else
                        dgi.Cells[14].Text = "0,00";
                }
                else
                    dgi.Cells[14].Text = "0,00";
                if (costo_investimento > 0 && pagamenti.Count > 0)
                {
                    quota_completamento = Math.Round(100 * importo_pagamento_richiesti / costo_investimento, 2, MidpointRounding.AwayFromZero);
                    decimal importoAmmessoInvestimento = 0;
                    if (pagamenti[0].ImportoAmmesso != null)
                        importoAmmessoInvestimento = pagamenti[0].ImportoAmmesso;
                    quota_completamento_ammesso = Math.Round(100 * (importoAmmessoInvestimento + (importo_pagamento_richiesti - pagamenti[0].ImportoRichiesto)) / costo_investimento, 2, MidpointRounding.AwayFromZero);
                    spese_ammesse = importoAmmessoInvestimento + (importo_pagamento_richiesti - pagamenti[0].ImportoRichiesto);
                }
                costo_investimenti += costo_investimento;
                contributo_investimenti += f.ContributoRichiesto;
                dgi.Cells[4].Text = string.Format("{0:c}", costo_investimento);
                dgi.Cells[11].Text = string.Format("{0:N}", quota_completamento);
                dgi.Cells[16].Text = string.Format("{0:N}", quota_completamento_ammesso);

                // importo pagamenti richiesti sarebbe il totale dei pagamenti richiesti finora, compreso il corrente, per l'investimento
                // se questo valore è maggiore del costo dell'investimento significa che ho un disavanzo e posso andarlo a spalmare su 
                // altri investimenti. Quindi lo mostro in griglia
                if (spese_ammesse > costo_investimento)
                {
                    decimal disavanzo = 0;
                    decimal disavanzo_contributo = 0;
                    // se il disavanzo è minore del 110% vuol dire che è nella soglia del 10% quindi lo calcolo come differenza
                    if (quota_completamento_ammesso <= 110)
                        disavanzo = spese_ammesse - costo_investimento;
                    // altrimenti lo calcolo come massimo 10% del costo dell'investimento
                    else
                        disavanzo = costo_investimento * 10 / 100;

                    disavanzo_contributo = disavanzo * f.QuotaContributoRichiesto / 100;

                    dgi.Cells[12].Text = string.Format("{0:c}", disavanzo);
                    dgi.Cells[12].ForeColor = System.Drawing.Color.Green;
                    dgi.Cells[13].Text = string.Format("{0:c}", disavanzo_contributo);
                    dgi.Cells[13].ForeColor = System.Drawing.Color.Green;
                    // questa è la somma totale dei disavanzi che così calcolata rientra sempre nel 10% del totale
                    decimal contributoDisavanzoCostiAmmessi = 0;
                    if (pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                        decimal.TryParse(pagamenti[0].ContributoDisavanzoCostiAmmessi, out contributoDisavanzoCostiAmmessi);
                    dgi.Cells[15].Text = string.Format("{0:c}", disavanzo_contributo - contributoDisavanzoCostiAmmessi);
                    dgi.Cells[15].ForeColor = System.Drawing.Color.Green;

                    pag_inv_disavanzo_totale += disavanzo;
                    pag_inv_disavanzo_totale_contributo += disavanzo_contributo;

                }
                else if (spese_ammesse < costo_investimento)
                {
                    decimal disavanzo = 0;
                    decimal disavanzo_contributo = 0;
                    // se il disavanzo è minore del 110% vuol dire che è nella soglia del 10% quindi lo calcolo come differenza
                    if (quota_completamento_ammesso >= 90)
                        disavanzo = -(costo_investimento - spese_ammesse);
                    // altrimenti lo calcolo come massimo 10% del costo dell'investimento
                    else
                        disavanzo = -costo_investimento * 10 / 100;

                    disavanzo_contributo = disavanzo * f.QuotaContributoRichiesto / 100;

                    dgi.Cells[12].Text = string.Format("{0:c}", disavanzo);
                    dgi.Cells[12].ForeColor = System.Drawing.Color.Red;
                    dgi.Cells[13].Text = string.Format("{0:c}", disavanzo_contributo);
                    dgi.Cells[13].ForeColor = System.Drawing.Color.Red;
                    // questa è la somma totale dei disavanzi che così calcolata rientra sempre nel 10% del totale
                    decimal contributoDisavanzoCostiAmmessi = 0;
                    if (pagamenti.Count > 0 && pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                        decimal.TryParse(pagamenti[0].ContributoDisavanzoCostiAmmessi, out contributoDisavanzoCostiAmmessi);
                    dgi.Cells[15].Text = string.Format("{0:c}", disavanzo_contributo + contributoDisavanzoCostiAmmessi);
                    dgi.Cells[15].ForeColor = System.Drawing.Color.Red;

                    pag_inv_disavanzo_totale += disavanzo;
                    pag_inv_disavanzo_totale_contributo += disavanzo_contributo;
                }
                else
                {
                    dgi.Cells[12].Text = string.Format("{0:c}", 0);
                    dgi.Cells[13].Text = string.Format("{0:c}", 0);
                }
            }
            else if (dgi.ItemType == ListItemType.Footer)
            {
                decimal quota = 0;
                if (costo_investimenti > 0) quota = 100 * contributo_investimenti / costo_investimenti;

                // se il bando è a importo fisso il contributo totale lo devo cambiare                
                bool importoFisso = false;
                SiarLibrary.BandoConfigCollection config = new SiarBLL.BandoConfigCollectionProvider().Find(Progetto.IdBando, "QUOTAFISSA", null, true, null);
                decimal contributo_quota_fissa = 0;
                if (config.Count > 0)
                {
                    importoFisso = true;
                    SiarLibrary.BandoImpreseQuotaFissa q = new SiarBLL.BandoImpreseQuotaFissaCollectionProvider().Find(Progetto.IdBando, Progetto.IdImpresa, null, true)[0];
                    if (q != null)
                        contributo_quota_fissa = q.Quota;
                }

                SiarLibrary.NullTypes.DecimalNT contributo_calcolato = investimenti_provider.
                    CalcoloContributoInvestimentiProgetto(Progetto.IdProgetto, true, investimenti[0].IdVariante);
                if (importoFisso)
                    contributo_calcolato = contributo_quota_fissa;
                if (contributo_calcolato != null && contributo_calcolato < contributo_investimenti && !importoFisso)
                    dgi.Cells[5].Text = "** " + String.Format("{0:c}", contributo_calcolato.Value);
                else if (importoFisso)
                    dgi.Cells[5].Text = "*** " + String.Format("{0:c}", contributo_calcolato.Value);
                else dgi.Cells[5].Text = string.Format("{0:c}", contributo_investimenti);

                dgi.Cells[4].Text = string.Format("{0:c}", costo_investimenti);
                dgi.Cells[6].Text = string.Format("{0:N}", Math.Round(quota, 2, MidpointRounding.AwayFromZero));
                dgi.Cells[7].Text = string.Format("{0:c}", pag_inv_costo_richiesto);
                dgi.Cells[8].Text = string.Format("{0:c}", pag_inv_contributo_richiesto);
                dgi.Cells[9].Text = string.Format("{0:c}", pag_inv_importo_ammesso);
                dgi.Cells[10].Text = string.Format("{0:c}", pag_inv_contributo_ammesso);
                dgi.Cells[14].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato);
            }
        }

        decimal costo_brevetti = 0, contributo_brevetti = 0, pag_brev_costo_richiesto = 0, pag_brev_contributo_richiesto = 0,
            pag_brev_contributo_ammesso = 0;
        void dgBrevetti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti inv = (SiarLibrary.PianoInvestimenti)dgi.DataItem;
                decimal importo_pagamento_richiesti, quota_completamento = 0;
                decimal.TryParse(inv.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                SiarLibrary.PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(inv.IdInvestimento);
                if (pagamenti.Count > 0)
                {
                    // devo aggiungere il pagamento richiesto attuale non contato dalla query
                    importo_pagamento_richiesti += pagamenti[0].ImportoRichiesto;
                    pag_brev_costo_richiesto += pagamenti[0].ImportoRichiesto;
                    pag_brev_contributo_richiesto += pagamenti[0].ContributoRichiesto;
                    dgi.Cells[5].Text = string.Format("{0:c}", pagamenti[0].ImportoRichiesto);
                    dgi.Cells[6].Text = string.Format("{0:c}", pagamenti[0].ContributoRichiesto);
                    if (pagamenti[0].ContributoAmmesso != null)
                    {
                        dgi.Cells[7].Text = string.Format("{0:c}", pagamenti[0].ContributoAmmesso);
                        pag_brev_contributo_ammesso += pagamenti[0].ContributoAmmesso;
                    }
                }
                if (inv.CostoInvestimento > 0) quota_completamento = Math.Round(100 * importo_pagamento_richiesti / inv.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                costo_brevetti += inv.CostoInvestimento;
                contributo_brevetti += inv.ContributoRichiesto;
                dgi.Cells[8].Text = string.Format("{0:N}", quota_completamento);
            }
            else if (dgi.ItemType == ListItemType.Footer)
            {
                decimal quota = 0;
                if (costo_brevetti > 0) quota = 100 * contributo_brevetti / costo_brevetti;

                dgi.Cells[4].Text = string.Format("{0:N}", Math.Round(quota, 2, MidpointRounding.AwayFromZero));
                dgi.Cells[5].Text = string.Format("{0:c}", pag_brev_costo_richiesto);
                dgi.Cells[6].Text = string.Format("{0:c}", pag_brev_contributo_richiesto);
                dgi.Cells[7].Text = string.Format("{0:c}", pag_brev_contributo_ammesso);
            }
        }

        void dgMutuo_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti inv = (SiarLibrary.PianoInvestimenti)dgi.DataItem;
                decimal importo_pagamento_richiesti, quota_completamento = 0;
                decimal.TryParse(inv.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                SiarLibrary.PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(inv.IdInvestimento);
                if (pagamenti.Count > 0)
                {
                    // devo aggiungere il pagamento richiesto attuale non contato dalla query
                    importo_pagamento_richiesti += pagamenti[0].ImportoRichiesto;
                    dgi.Cells[5].Text = string.Format("{0:c}", pagamenti[0].ImportoRichiesto);
                    dgi.Cells[6].Text = string.Format("{0:c}", pagamenti[0].ContributoRichiesto);
                    if (pagamenti[0].ContributoAmmesso != null)
                        dgi.Cells[7].Text = string.Format("{0:c}", pagamenti[0].ContributoAmmesso);
                }
                if (inv.CostoInvestimento > 0) quota_completamento = Math.Round(100 * importo_pagamento_richiesti / inv.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                dgi.Cells[8].Text = string.Format("{0:N}", quota_completamento);
            }
        }

        void dgFidejussione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti inv = (SiarLibrary.PianoInvestimenti)e.Item.DataItem;
                decimal importo_pagamento_richiesti, quota_completamento = 0;
                decimal.TryParse(inv.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                SiarLibrary.PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(inv.IdInvestimento);
                if (pagamenti.Count > 0)
                {
                    // devo aggiungere il pagamento richiesto attuale non contato dalla query
                    importo_pagamento_richiesti += pagamenti[0].ImportoRichiesto;
                    pag_brev_costo_richiesto += pagamenti[0].ImportoRichiesto;
                    pag_brev_contributo_richiesto += pagamenti[0].ContributoRichiesto;
                    e.Item.Cells[5].Text = string.Format("{0:c}", pagamenti[0].ImportoRichiesto);
                    e.Item.Cells[6].Text = string.Format("{0:c}", pagamenti[0].ContributoRichiesto);
                    if (pagamenti[0].ContributoAmmesso != null)
                    {
                        e.Item.Cells[7].Text = string.Format("{0:c}", pagamenti[0].ContributoAmmesso);
                        pag_brev_contributo_ammesso += pagamenti[0].ContributoAmmesso;
                    }
                }
                if (inv.CostoInvestimento > 0) quota_completamento = Math.Round(100 * importo_pagamento_richiesti / inv.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                costo_brevetti += inv.CostoInvestimento;
                contributo_brevetti += inv.ContributoRichiesto;
                e.Item.Cells[8].Text = string.Format("{0:N}", quota_completamento);
            }
        }

        public decimal getTotalePagamentiRiassegnati()
        {
            decimal totale_contributi_riassegnati = 0;
            SiarLibrary.PagamentiRichiestiCollection pagamenti_richiesti_totali = prichiesti_provider.Find(null, null, Progetto.IdProgetto, null);
            foreach (SiarLibrary.PagamentiRichiesti p in pagamenti_richiesti_totali)
            {
                SiarLibrary.DomandaDiPagamento d = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(p.IdDomandaPagamento);
                if (p.ContributoDisavanzoCostiAmmessi != null && d.Approvata != null && d.Approvata)
                    totale_contributi_riassegnati += p.ContributoDisavanzoCostiAmmessi;
            }
            return totale_contributi_riassegnati;
        }

        protected void btnDettaglioMisura_Click(object sender, EventArgs e)
        {
            dgDettaglioMisura.DataSource = new SiarLibrary.NotAutogeneratedClasses.RiepilogoImportiDomandaPagamentoCollectionProvider()
                .GetRiepilogoImportiXMisura(DomandaPagamento.IdDomandaPagamento);
            dgDettaglioMisura.MostraTotale("DataField", 1, 2, 3, 4, 5, 7, 8, 9);
            dgDettaglioMisura.ItemDataBound += new DataGridItemEventHandler(dgDettaglioMisura_ItemDataBound);
            dgDettaglioMisura.DataBind();
            RegisterClientScriptBlock("mostraPopupTemplate('divIstPagForm','divBKGMessaggio');");
        }

        void dgDettaglioMisura_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].RowSpan = 2;
                e.Item.Cells[1].ColumnSpan = 2;
                e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[1].Text = "DOMANDA DI AIUTO</td><td colspan=7 align=center>DOMANDA DI PAGAMENTO</td></tr><tr class='TESTA'><td>Costo totale";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.NotAutogeneratedClasses.RiepilogoImportiDomandaPagamento r = (SiarLibrary.NotAutogeneratedClasses.
                    RiepilogoImportiDomandaPagamento)e.Item.DataItem;
                if (r.ContributoRichiesto == null || r.ContributoRichiesto <= 0) e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                else if (r.ContributoAmmissibile != null && r.ContributoTotaleProgettoCorrelato != null)
                {
                    decimal quota = 0;
                    if (r.ContributoTotaleProgettoCorrelato > 0) Math.Round((100 * r.ContributoAmmissibile) / r.ContributoTotaleProgettoCorrelato, 2, MidpointRounding.AwayFromZero);
                    e.Item.Cells[6].Text = string.Format("{0:n}", quota);
                }
            }
        }

        protected void btnEstrai_Click(object sender, EventArgs e)
        {
            try
            {
                string parametri = "";
                parametri += "IdProgetto=" + Progetto.IdProgetto;
                parametri += "|CodQuery=" + "INVESTIMENTI_DOMANDA_PAGAMENTO";
                parametri += "|IdDomandaPagamento=" + DomandaPagamento.IdDomandaPagamento;

                string jsFunction = "SNCVisualizzaReport('rptPianoInvestimenti', 2, '" + parametri + "');";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunction, true);
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        protected void btnAccorporaVociPiano_Click(object sender, EventArgs e)
        {
            try
            {
                var responsabili_list = new SiarBLL.BandoResponsabiliCollectionProvider()
                    .Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, 1)
                    .ToArrayList<SiarLibrary.BandoResponsabili>();
                if (responsabili_list.Count == 0)
                    throw new Exception("Solo il Responsabile del bando può accorpare gli investimenti.");

                SiarLibrary.PianoInvestimenti voceX = null;
                SiarLibrary.PianoInvestimenti voceY = null;
                string errore = "";

                int indiceX, indiceY;
                if (int.TryParse(txtVoceAccorpamentoX.Text, out indiceX))
                {
                    if (int.TryParse(txtVoceAccorpamentoY.Text, out indiceY))
                    {
                        errore = SiarBLL.AccorpamentoInvestimentiUtility.RecuperaVociAccorpamento(DomandaPagamento, indiceX, indiceY, ref voceX, ref voceY);

                        if (errore != null && errore.Equals(""))
                        {
                            errore = SiarBLL.AccorpamentoInvestimentiUtility.GeneraAccorpamentoInvestimenti(DomandaPagamento, voceX, voceY, Operatore.Utente);

                            if (errore != null && errore.Equals(""))
                            {
                                errore = SiarBLL.AccorpamentoInvestimentiUtility.AccorpaVociPiano(DomandaPagamento, ref voceX, ref voceY, txtDescrizioneAccorpamento.Text);

                                if (errore != null && errore.Equals(""))
                                {
                                    ShowMessage("Voci del piano accorpate con successo.");
                                    RegisterClientScriptBlock("hideModaleCaricamento();");
                                }
                                else
                                    throw new Exception(errore);
                            }
                            else
                                throw new Exception(errore);
                        }
                        else
                            throw new Exception(errore);
                    }
                    else
                        throw new Exception("Inserire la voce Y.");
                }
                else
                    throw new Exception("Inserire la voce X.");
            }
            catch (Exception ex)
            {
                ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex);
                RegisterClientScriptBlock("hideModaleCaricamento();");
            }
        }
    }
}