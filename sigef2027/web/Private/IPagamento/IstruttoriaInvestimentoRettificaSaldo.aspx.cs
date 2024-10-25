using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaInvestimentoRettificaSaldo : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        decimal importo_investimento_richiesto = 0, importo_spese_richieste = 0, importo_investimento_ammesso = 0,
            importo_spese_ammesse = 0, totale_sanzioni = 0;
        SiarLibrary.PianoInvestimenti _investimento;
        SiarLibrary.PagamentiRichiesti prichiesto;
        SiarLibrary.PagamentiBeneficiarioCollection pbeneficiario_attuali;
        SiarLibrary.PagamentiBeneficiarioCollection pbeneficiario_precedenti;
        SiarBLL.PagamentiRichiestiCollectionProvider prichiesti_provider;
        SiarBLL.PagamentiBeneficiarioCollectionProvider pbeneficiario_provider;
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarBLL.SanzioniCollectionProvider sanzioni_provider;
        SiarLibrary.SanzioniCollection sanzioni_assegnate;
        SiarBLL.NoteCollectionProvider note_provider;
        SiarBLL.IntegrazioniPerDomandaDiPagamentoCollectionProvider integrazione_provider;
        SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider;
        bool AltreFonti;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            try
            {
                integrazione_provider = new SiarBLL.IntegrazioniPerDomandaDiPagamentoCollectionProvider();
                integrazione_singola_provider = new SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider();
                prichiesti_provider = new SiarBLL.PagamentiRichiestiCollectionProvider(PagamentoProvider.DbProviderObj);
                pbeneficiario_provider = new SiarBLL.PagamentiBeneficiarioCollectionProvider(PagamentoProvider.DbProviderObj);
                sanzioni_provider = new SiarBLL.SanzioniCollectionProvider(PagamentoProvider.DbProviderObj);
                note_provider = new SiarBLL.NoteCollectionProvider(PagamentoProvider.DbProviderObj);
                investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(PagamentoProvider.DbProviderObj);
                int id_investimento;
                if (int.TryParse(Request.QueryString["idinv"], out id_investimento))
                    _investimento = investimenti_provider.GetById(id_investimento);
                if (_investimento == null) throw new Exception("L`investimento selezionato non è valido.");
                ctrlSessione();
                if (_investimento.CodTipoInvestimento == 2 && _investimento.CostoInvestimento > 0)
                    _investimento.QuotaContributoRichiesto = Math.Round(100 * _investimento.ContributoRichiesto / _investimento.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                lnkInvestimento.HRef = "javascript:mostraStoricoInvestimento(" + _investimento.IdInvestimento + ")";

                SiarLibrary.PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, _investimento.IdInvestimento, null, DomandaPagamento.IdDomandaPagamento);
                if (prichiesti.Count > 0) prichiesto = prichiesti[0];


                string UtStrumFin = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_UtStrumFin(Progetto.IdBando);
                if (UtStrumFin == "True") AltreFonti = true;
                else
                    AltreFonti = false;
                if (AltreFonti)
                {
                    tdAmmessoAltreFonti.Visible = true;
                    tdRichiestoAltreFonti.Visible = true;
                }
                else
                {
                    tdRichiestoAltreFonti.Visible = false;
                    tdAmmessoAltreFonti.Visible = false;
                }
            }
            catch (Exception ex) { Redirect("IstruttoriaPianoInvestimenti.aspx", ex.Message, true); }
        }

        private void ctrlSessione()
        {
            if (_investimento.IdProgetto != Progetto.IdProgetto)
            {
                SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(_investimento.IdProgetto);
                if (p == null || p.IdProgIntegrato != Progetto.IdProgetto) throw new Exception("L'investimento selezionato non è valido.");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Request.QueryString["redir"] == "revisione") btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag="
                + DomandaPagamento.IdDomandaPagamento + "'";
            if (prichiesto == null)
            {
                SiarLibrary.PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, _investimento.IdInvestimento, null, DomandaPagamento.IdDomandaPagamento);
                if (prichiesti.Count > 0) prichiesto = prichiesti[0];
            }
            if (prichiesto != null)
            {
                //ricarico prichiesto
                prichiesto = prichiesti_provider.GetById(prichiesto.IdPagamentoRichiesto);

                if (pbeneficiario_attuali == null)
                    pbeneficiario_attuali = pbeneficiario_provider.Find(prichiesto.IdPagamentoRichiesto, null, null, null, null, null);
                dgPagamenti.DataSource = pbeneficiario_attuali;
                lblNumeroPagamenti.Text = pbeneficiario_attuali.Count.ToString();
                dgPagamenti.ItemDataBound += new DataGridItemEventHandler(dgPagamenti_ItemDataBound);
            }
            else
            {
                dgPagamenti.Titolo = "Pagamento non ancora richiesto.";
                lblNumeroPagamenti.Text = "0";
            }
            dgPagamenti.DataBind();

            //Giustificativi precedenti
            string numeroGiust = null;
            if (txtNumeroGiu.Text != "" && txtNumeroGiu.Text != null)
                numeroGiust = txtNumeroGiu.Text;

            pbeneficiario_precedenti = pbeneficiario_provider.GetPagamentiDomandeDiPagamento(_investimento.IdInvestimento, numeroGiust);
            dgPagamentiPrecedenti.DataSource = pbeneficiario_precedenti;
            lblNumeroPagamentiPrec.Text = pbeneficiario_precedenti.Count.ToString();
            dgPagamentiPrecedenti.ItemDataBound += new DataGridItemEventHandler(dgPagamentiPrecedenti_ItemDataBound);
            dgPagamentiPrecedenti.DataBind();

            popolaInvestimento();
            //getDisavanzo();

            base.OnPreRender(e);
        }

        private void popolaInvestimento()
        {
            // investimento
            if (_investimento.IdPrioritaSettoriale != null)
                tbInvestimento.Rows[0].Cells[1].InnerHtml = "<img src='../../images/star_red.gif' />";
            if (_investimento.CodVariazione != null) tbInvestimento.Rows[0].Cells[2].InnerHtml = "<b>(" + _investimento.CodVariazione + ")</b>";
            tbInvestimento.Rows[0].Cells[3].InnerHtml = "<b>" + _investimento.Misura + "</b>";
            tbInvestimento.Rows[1].Cells[0].InnerHtml = "<b>Settore produttivo: </b> non specificato";
            if (_investimento.SettoreProduttivo != null) tbInvestimento.Rows[1].Cells[0].InnerHtml = "<b>Settore produttivo: </b>"
                + _investimento.SettoreProduttivo.ToString().ToUpper();
            tbInvestimento.Rows[2].Cells[0].InnerHtml = "<b>Codifica: </b>" + _investimento.CodificaInvestimento;
            tbInvestimento.Rows[3].Cells[0].InnerHtml = "<b>Dettaglio: </b>" + _investimento.DettaglioInvestimenti;
            tbInvestimento.Rows[4].Cells[0].InnerHtml = "<b>Descrizione: </b>" + _investimento.Descrizione;

            if (_investimento.IdImpresaAggregazione != null)
            {
                SiarLibrary.Impresa impresa_aggr = new SiarBLL.ImpresaCollectionProvider().GetById(_investimento.IdImpresaAggregazione);
                tbInvestimento.Rows[5].Cells[0].InnerHtml = "<b>Impresa: </b>" + impresa_aggr.RagioneSociale + " - " + impresa_aggr.CodiceFiscale;
            }


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
            txtQuotaAiuto.Text = string.Format("{0:N12}", Math.Round(_investimento.QuotaContributoRichiesto.Value, 12, MidpointRounding.AwayFromZero));
            //if (_investimento.Mobile == null || _investimento.Mobile) txtImportoComputoMetricoAmmesso.ReadOnly = true;
            //else btnSalva.OnClientClick = "if(document.getElementById('ctl00_cphContenuto_txtImportoComputoMetricoAmmesso_text').value==''){alert(\'Importo computo metrico obbligatorio.\');return stopEvent(event);}";

            //totali richiesti fino ad ora
            decimal storico_contributo_richiesto = SiarLibrary.DbStaticProvider.GetStoricoContributoRichiestoInvestimento(_investimento.IdInvestimento,
                DomandaPagamento.IdDomandaPagamento, PagamentoProvider.DbProviderObj),
                storico_importo_richiesto = SiarLibrary.DbStaticProvider.GetStoricoImportoRichiestoInvestimento(_investimento.IdInvestimento,
                DomandaPagamento.IdDomandaPagamento, PagamentoProvider.DbProviderObj);
            txtStoricoContributoRichiesto.Text = string.Format("{0:n}", storico_contributo_richiesto);
            txtStoricoImportoRichiesto.Text = string.Format("{0:n}", storico_importo_richiesto);
            if (storico_importo_richiesto > 0)
            {
                txtStoricoRichiestoQuota.Text = string.Format("{0:N12}", 100 * storico_contributo_richiesto / storico_importo_richiesto);
                decimal spese_generali = _investimento.SpeseGenerali != null && /*nota (*)*/_investimento.CodTipoInvestimento != 2 ? _investimento.SpeseGenerali.Value : 0;
                if (_investimento.CostoInvestimento + spese_generali > 0)
                    txtCompletamentoInvestimento.Text = string.Format("{0:N12}", 100 * storico_importo_richiesto / (_investimento.CostoInvestimento.Value + spese_generali));
                else txtCompletamentoInvestimento.Text = "0";
            }

            btnSalva.Enabled = false;

            if (prichiesto != null)
            {
                decimal ammontare_richiesto_lavori_in_economia = 0, ammontare_ammesso_lavori_in_economia = 0;
                foreach (SiarLibrary.PagamentiBeneficiario pb in pbeneficiario_attuali)
                {
                    if (pb.CodTipo == "LEC")
                    {
                        ammontare_richiesto_lavori_in_economia += pb.ImportoRichiesto;
                        if (prichiesto.Ammesso && pb.ImportoAmmesso != null) ammontare_ammesso_lavori_in_economia += pb.ImportoAmmesso;
                    }
                }
                txtImportoRichiestoLavoriInEconomia.Text = string.Format("{0:N}", Math.Round(ammontare_richiesto_lavori_in_economia, 2, MidpointRounding.AwayFromZero));
                if (prichiesto.ImportoRichiesto > 0) txtQuotaRichiestoLavoriInEconomia.Text = string.Format("{0:N}", Math.Round(100 *
                    ammontare_richiesto_lavori_in_economia / prichiesto.ImportoRichiesto, 2, MidpointRounding.AwayFromZero));
                txtImportoComputoMetrico.Text = prichiesto.ImportoComputoMetrico;
                txtImportoTotaleRichiesto.Text = prichiesto.ImportoRichiesto;
                txtContributoTotaleRichiesto.Text = prichiesto.ContributoRichiesto;
                txtContributoRichiestoAltreFonti.Text = prichiesto.ContributoRichiestoAltreFonti;
                txtImportoInvestimento.Text = string.Format("{0:N}", Math.Round(importo_investimento_richiesto, 2, MidpointRounding.AwayFromZero));
                txtImportoSpeseTecniche.Text = string.Format("{0:N}", Math.Round(importo_spese_richieste, 2, MidpointRounding.AwayFromZero));
                if (prichiesto.Ammesso)
                {
                    tbInvestimento.Rows[0].Cells[0].InnerHtml += "<img src='../../images/visto.gif' alt='Investimento ammesso'/>";
                    txtImportoComputoMetricoAmmesso.Text = prichiesto.ImportoComputoMetricoAmmesso;
                    txtImportoTotaleAmmesso.Text = prichiesto.ImportoAmmesso;
                    txtContributoTotaleAmmesso.Text = prichiesto.ContributoAmmesso;
                    txtContributoAmmessoAltreFonti.Text = prichiesto.ContributoAmmessoAltreFonti;
                    decimal contributo_ammesso_finale = 0;
                    contributo_ammesso_finale += prichiesto.ContributoAmmesso;
                    if (sanzioni_assegnate != null)
                    {
                        foreach (SiarLibrary.Sanzioni sanz in sanzioni_assegnate) if (sanz.Ammontare != null) contributo_ammesso_finale -= sanz.Ammontare;
                    }
                    txtContributoAmmessoFinale.Text = string.Format("{0:n}", Math.Round(contributo_ammesso_finale, 2, MidpointRounding.AwayFromZero));
                    txtImportoAmmessoLavoriInEconomia.Text = string.Format("{0:N}", Math.Round(ammontare_ammesso_lavori_in_economia, 2, MidpointRounding.AwayFromZero));
                    if (prichiesto.ImportoAmmesso > 0) txtQuotaAmmessoLavoriInEconomia.Text = string.Format("{0:N}", Math.Round(100 *
                           ammontare_ammesso_lavori_in_economia / prichiesto.ImportoAmmesso, 2, MidpointRounding.AwayFromZero));
                    txtImportoInvestimentoAmmesso.Text = string.Format("{0:N}", Math.Round(importo_investimento_ammesso, 2, MidpointRounding.AwayFromZero));
                    txtImportoSpeseTecnicheAmmesse.Text = string.Format("{0:N}", Math.Round(importo_spese_ammesse, 2, MidpointRounding.AwayFromZero));
                    txtValutazioneLunga.Text = prichiesto.NoteIstruttore;
                    btnSalva.Enabled = AbilitaModifica;

                }


                //txtCostoDaAssegnare.Text = prichiesto.ImportoDisavanzoCostiAmmessi;
                //txtContributoDaAssegnare.Text = prichiesto.ContributoDisavanzoCostiAmmessi;
            }
        }

        #region funzioni_commentate

        //private void getDisavanzo()
        //{
        //    // mi serve l'investimento attuale
        //    // non vanno bene le spese richieste, devo sempre verificare quelle ammesse
        //    decimal storico_spese_richieste = 0;
        //    decimal.TryParse(txtStoricoImportoRichiesto.Text, out storico_spese_richieste);

        //    decimal importo_investimento_attuale_richiesto = 0;
        //    decimal.TryParse(txtImportoInvestimento.Text, out importo_investimento_attuale_richiesto);

        //    decimal importo_investimento_ammesso = 0;
        //    decimal.TryParse(txtImportoInvestimentoAmmesso.Text, out importo_investimento_ammesso);

        //    decimal totale_ammesso = 0;
        //    decimal.TryParse(txtImportoTotaleAmmesso.Text, out totale_ammesso);

        //    // un metodo che mi calcola questo ed eventualmente mi dice quanto ho riassegnato. Lo vedo da pagamenti richiesti
        //    decimal totale_ammesso_investimento_altre_domdande = getTotaleImportoAmmessoInvestimentoAltreDomande();

        //    // a questo sopra devo guardare tutte le eventuali varianti per l'investimento
        //    if (_investimento.IdVariante != null)
        //    {
        //        decimal totale_ammesso_investimento_altre_domdande_varianti = getTotaleImportoAmmessoInvestimentoAltreDomandeVarianti(_investimento, 0);
        //        totale_ammesso_investimento_altre_domdande += totale_ammesso_investimento_altre_domdande_varianti;
        //    }

        //    // se prendo solo il costo investimento della domanda attuale mi perdo i vecchi e quindi mi perdo il disavanzo
        //    if (totale_ammesso + totale_ammesso_investimento_altre_domdande > _investimento.CostoInvestimento)
        //    {
        //        decimal disavanzo = totale_ammesso + totale_ammesso_investimento_altre_domdande - _investimento.CostoInvestimento;
        //        if (disavanzo > _investimento.CostoInvestimento * 10 / 100)
        //            disavanzo = _investimento.CostoInvestimento * 10 / 100;
        //        txtDisavanzoInvestimento.Text = string.Format("{0:N}", Math.Round(disavanzo, 2, MidpointRounding.AwayFromZero));
        //        txtDisavanzoInvestimentoContributo.Text = string.Format("{0:N}", Math.Round(disavanzo * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero));
        //    }
        //    else
        //    {
        //        txtDisavanzoInvestimento.Text = string.Format("{0:N}", "0,00");
        //        txtDisavanzoInvestimentoContributo.Text = string.Format("{0:N}", "0,00");
        //    }

        //    decimal totale_importi_economia = 0;
        //    decimal totale_contributi_economia = 0;
        //    decimal pag_inv_importo_ammesso = 0;
        //    decimal pag_inv_contributo_ammesso = 0;
        //    // decimal pag_inv_importo_richiesto = 0;
        //    decimal pag_inv_contributo_richiesto = 0;
        //    SiarLibrary.PianoInvestimentiCollection investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
        //    SiarLibrary.PagamentiRichiestiCollection pagamenti_richiesti = prichiesti_provider.Find(null, null, Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
        //    foreach (SiarLibrary.PianoInvestimenti f in investimenti.FiltroTipoInvestimento(1))
        //    {
        //        decimal importo_pagamento_ammesso = 0;
        //        SiarLibrary.PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(f.IdInvestimento);
        //        if (pagamenti.Count > 0)
        //        {
        //            if (pagamenti[0].ImportoAmmesso != null)
        //            {
        //                pag_inv_importo_ammesso += pagamenti[0].ImportoAmmesso;
        //                importo_pagamento_ammesso = pagamenti[0].ImportoAmmesso;
        //            }
        //            if (pagamenti[0].ContributoAmmesso != null)
        //                pag_inv_contributo_ammesso += pagamenti[0].ContributoAmmesso;
        //            pag_inv_contributo_richiesto += pagamenti[0].ContributoRichiesto;
        //        }

        //        decimal importo_pagamento_richiesti = 0;
        //        decimal.TryParse(f.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
        //        if (f.CostoInvestimento > importo_pagamento_ammesso + importo_pagamento_richiesti)
        //        {
        //            decimal economia_spesa = f.CostoInvestimento - importo_pagamento_richiesti - importo_pagamento_ammesso;
        //            if (economia_spesa > f.CostoInvestimento * 10 / 100)
        //                economia_spesa = f.CostoInvestimento * 10 / 100;
        //            totale_importi_economia += economia_spesa;
        //            decimal economia_contributo = economia_spesa * f.QuotaContributoRichiesto / 100;
        //            if (economia_contributo > f.ContributoRichiesto * 10 / 100)
        //                economia_contributo = f.ContributoRichiesto * 10 / 100;
        //            // if (pagamenti.Count > 0)
        //            totale_contributi_economia += economia_contributo;
        //        }
        //    }

        //    decimal totale_contributi_riassegnati_domanda = getTotalePagamentiRiassegnatiDomanda(null, DomandaPagamento.IdDomandaPagamento);
        //    decimal totale_contributi_riassegnati_investimento = getTotalePagamentiRiassegnatiInvestimento(null, _investimento.IdInvestimento);

        //    txtEconomieDaCoprire.Text = string.Format("{0:N}", Math.Round(totale_contributi_economia, 2, MidpointRounding.AwayFromZero));
        //    txtEconomieScoperte.Text = string.Format("{0:N}", Math.Round(totale_contributi_economia = totale_contributi_economia - totale_contributi_riassegnati_domanda, 2, MidpointRounding.AwayFromZero));
        //    txtImportoRiassegnatoInvestimento.Text = string.Format("{0:N}", Math.Round(totale_contributi_riassegnati_investimento, 2, MidpointRounding.AwayFromZero));
        //}

        //private decimal getTotaleImportoAmmessoInvestimentoAltreDomande()
        //{
        //    SiarBLL.PagamentiRichiestiCollectionProvider prc = new SiarBLL.PagamentiRichiestiCollectionProvider();
        //    SiarLibrary.PagamentiRichiestiCollection pagamentiRichiestiAmmessi = prc.Find(null, _investimento.IdInvestimento, Progetto.IdProgetto, null);

        //    decimal importoAmmesso = 0;
        //    foreach (SiarLibrary.PagamentiRichiesti p in pagamentiRichiestiAmmessi)
        //    {
        //        if (p.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento)
        //        {
        //            SiarLibrary.DomandaDiPagamento d = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(p.IdDomandaPagamento);
        //            if (d.Approvata != null && d.Approvata && d.SegnaturaApprovazione != null)
        //                importoAmmesso += p.ImportoAmmesso;
        //        }
        //    }

        //    return importoAmmesso;
        //}

        //private decimal getTotaleImportoAmmessoInvestimentoAltreDomandeVarianti(PianoInvestimenti investimento, decimal importoAmmesso)
        //{

        //    if (investimento.IdVariante != null)
        //    {
        //        SiarBLL.PagamentiRichiestiCollectionProvider prc = new SiarBLL.PagamentiRichiestiCollectionProvider();
        //        SiarLibrary.PagamentiRichiestiCollection pagamentiRichiestiAmmessi = prc.Find(null, investimento.IdInvestimentoOriginale, Progetto.IdProgetto, null);

        //        foreach (SiarLibrary.PagamentiRichiesti p in pagamentiRichiestiAmmessi)
        //        {
        //            if (p.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento)
        //            {
        //                SiarLibrary.DomandaDiPagamento d = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(p.IdDomandaPagamento);
        //                if (d.Approvata != null && d.Approvata && d.SegnaturaApprovazione != null)
        //                    importoAmmesso += p.ImportoAmmesso;
        //            }
        //        }

        //        if (investimento.IdInvestimentoOriginale != null)
        //        {
        //            SiarLibrary.PianoInvestimenti inv = new SiarBLL.PianoInvestimentiCollectionProvider().GetById(investimento.IdInvestimentoOriginale);
        //            if (inv.IdVariante != investimento.IdVariante)
        //            {
        //                getTotaleImportoAmmessoInvestimentoAltreDomandeVarianti(inv, importoAmmesso);
        //            }
        //        }

        //    }

        //    return importoAmmesso;
        //}

        //public decimal getTotalePagamentiRiassegnatiDomanda(decimal? cifraCorrenteDaEscludere, int idDomanda)
        //{
        //    decimal totale_contributi_riassegnati_investimento = 0;
        //    SiarLibrary.PagamentiRichiestiCollection pagamenti_richiesti_totali_investimento = prichiesti_provider.Find(null, null, Progetto.IdProgetto, idDomanda);
        //    foreach (SiarLibrary.PagamentiRichiesti p in pagamenti_richiesti_totali_investimento)
        //    {
        //        if (p.ContributoDisavanzoCostiAmmessi != null)
        //            totale_contributi_riassegnati_investimento += p.ContributoDisavanzoCostiAmmessi;
        //    }
        //    decimal corrente = 0;
        //    if (cifraCorrenteDaEscludere != null)
        //        corrente = cifraCorrenteDaEscludere.Value;
        //    return totale_contributi_riassegnati_investimento - corrente;
        //}

        //public decimal getTotalePagamentiRiassegnatiInvestimento(decimal? cifraCorrenteDaEscludere, int idInvestimento)
        //{
        //    decimal totale_contributi_riassegnati_investimento = 0;
        //    SiarLibrary.PagamentiRichiestiCollection pagamenti_richiesti_totali_investimento = prichiesti_provider.Find(null, idInvestimento, Progetto.IdProgetto, null);
        //    foreach (PagamentiRichiesti p in pagamenti_richiesti_totali_investimento)
        //    {
        //        var dom = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(p.IdDomandaPagamento);

        //        if (!dom.Annullata && p.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento && p.ContributoDisavanzoCostiAmmessi != null)
        //            totale_contributi_riassegnati_investimento += p.ContributoDisavanzoCostiAmmessi;
        //    }
        //    decimal corrente = 0;
        //    if (cifraCorrenteDaEscludere != null)
        //        corrente = cifraCorrenteDaEscludere.Value;
        //    return totale_contributi_riassegnati_investimento - corrente;
        //}

        //private bool checkAltreDomandeProgetto(SiarLibrary.NullTypes.IntNT intNT)
        //{
        //    // se ci sono altre domande di pagamento controllo che siano tutte firmate altrimenti non posso spalmare nessuna cifra.
        //    SiarLibrary.DomandaDiPagamentoCollection domande = new SiarBLL.DomandaDiPagamentoCollectionProvider().Find(null, null, DomandaPagamento.IdProgetto, null);
        //    bool ok = true;
        //    if (domande.Count > 1)
        //    {
        //        foreach (SiarLibrary.DomandaDiPagamento d in domande)
        //        {
        //            if (d.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento)
        //            {
        //                if (d.SegnaturaApprovazione == null && !d.Annullata && d.SegnaturaAnnullamento == null)
        //                    ok = false;
        //            }
        //        }
        //    }
        //    return ok;
        //}

        #endregion

        #region datagrid

        decimal tot_imponibile_rett = 0, tot_Importo_richiesto_rett = 0, tot_contributo_richiesto_rett = 0, tot_importo_ammesso_rett = 0, tot_contributo_ammesso_rett = 0;

        void dgPagamenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                dgi.Cells[1].ColumnSpan = 3;
                dgi.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[1].Text += "GIUSTIFICATIVO</td><td align=center colspan=2>VARIAZIONE AMMESSA</td><td></td></tr><tr class=TESTA><td>Riferimenti";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.PagamentiBeneficiario pag = (SiarLibrary.PagamentiBeneficiario)dgi.DataItem;
                //if (pag.CostituisceVariante) dgi.Cells[6].Text = "(V)";
                if (pag.LavoriInEconomia) dgi.Cells[1].Text = "<b>Tipo:</b> " + pag.TipoGiustificativo + " <BR /><b>Descrizione:</b> " + pag.Descrizione;
                else
                {
                    // visualizzo il dettaglio solo se giustificativo reale e non lavori in economia
                    dgi.Cells[1].Text = "<b>Tipo:</b> " + pag.TipoGiustificativo + " nr. " + pag.Numero + " data: " + pag.Data
                       + "<BR /><b>D.D.T:</b> nr." + pag.NumeroDoctrasporto + " data: " + pag.DataDoctrasporto
                       + " <BR /><b>Oggetto spesa:</b> " + pag.Descrizione;
                    dgi.Cells[2].Text = "<img src='../../images/acrobat.gif' alt='Visualizza documento' title='Visualizza documento'"
                        + "style='cursor:pointer' onclick=\"" + (pag.IdFile == null ? "SNCVisualizzaReport('rptGiustificativo',1,'IdGiustificativo=" + pag.IdGiustificativo + "');"
                        : "SNCUFVisualizzaFile(" + pag.IdFile + ");") + "\" />";
                }

                if (pag.SpesaTecnicaRichiesta) importo_spese_richieste += pag.ImportoRichiesto;
                else importo_investimento_richiesto += pag.ImportoRichiesto;
                if (pag.ImportoAmmesso != null)
                {
                    //totale 
                    tot_importo_ammesso_rett += pag.ImportoAmmesso;

                    if (pag.SpesaTecnicaAmmessa != null && pag.SpesaTecnicaAmmessa) importo_spese_ammesse += pag.ImportoAmmesso;
                    else importo_investimento_ammesso += pag.ImportoAmmesso;
                    decimal contributo_ammesso = Math.Round(pag.ImportoAmmesso.Value * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
                    if (pag.ContributoAmmesso == null)
                    {
                        dgi.Cells[5].Text = string.Format("{0:c}", contributo_ammesso);
                        tot_contributo_ammesso_rett += contributo_ammesso;
                    }
                    else
                        tot_contributo_ammesso_rett += pag.ContributoAmmesso;
                }

                //decimal contributo_calcolato = Math.Round(pag.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
                //dgi.Cells[5].Text = string.Format("{0:c}", contributo_calcolato);

                //CheckBox chkRichiesta = new CheckBox(), chkAmmessa = new CheckBox();
                //chkRichiesta.ID = "chkSpesaTecnicaRichiesta" + pag.IdPagamentoBeneficiario;
                //chkRichiesta.Checked = pag.SpesaTecnicaRichiesta;
                //chkRichiesta.Enabled = false;
                //dgi.Cells[6].Controls.Add(chkRichiesta);
                //chkAmmessa.ID = "chkSpesaTecnicaAmmessa" + pag.IdPagamentoBeneficiario;
                //chkAmmessa.Enabled = false;
                //chkAmmessa.Checked = (pag.SpesaTecnicaAmmessa != null && pag.SpesaTecnicaAmmessa);
                //dgi.Cells[10].Controls.Add(chkAmmessa);

                //string url_modifica = "$('[id$=hdnIdPagamentoBeneficiario]').val(" + pag.IdPagamentoBeneficiario
                //    + ");$('[id$=btnPost]').click();";
                //dgi.Cells[9].Text = "<input type='button' class='ButtonGrid' style='width:70px' onclick=\"" + url_modifica + "\" value='"
                //    + (AbilitaModifica ? "Istruisci" : "Dettaglio") + "' />";

                dgi.Cells[6].Text = "<a href=\"javascript:eliminaPagamentoBen(" + pag.IdPagamentoBeneficiario + ");\"><img src='../../images/xdel.gif' alt='Elimina pagamento'></a>";

                //calcolo totali
                tot_imponibile_rett += pag.Imponibile;
                tot_Importo_richiesto_rett += pag.ImportoRichiesto;
                //tot_contributo_richiesto += contributo_calcolato;
            }
            else
            {

                e.Item.Cells[3].Text = string.Format("{0:c}", tot_imponibile_rett);
                //e.Item.Cells[4].Text = string.Format("{0:c}", tot_Importo_richiesto);
                //e.Item.Cells[5].Text = string.Format("{0:c}", tot_contributo_richiesto);
                e.Item.Cells[4].Text = string.Format("{0:c}", tot_importo_ammesso_rett);
                e.Item.Cells[5].Text = string.Format("{0:c}", tot_contributo_ammesso_rett);
            }
        }

        decimal tot_imponibile = 0, tot_Importo_richiesto = 0, tot_contributo_richiesto = 0, tot_importo_ammesso = 0, tot_contributo_ammesso = 0;
        void dgPagamentiPrecedenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                
                dgi.Cells[0].ColumnSpan = 2;
                dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[0].Text += "DOMANDA DI PAGAMENTO</td><td colspan=3 align=center>GIUSTIFICATIVO</td><td colspan=2 align=center>PAGAMENTO RICHIESTO</td><td align=center colspan=2>PAGAMENTO AMMESSO</td><td></td></tr><tr class=TESTA><td>ID";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.PagamentiBeneficiario pag = (SiarLibrary.PagamentiBeneficiario)dgi.DataItem;
                //if (pag.CostituisceVariante) dgi.Cells[6].Text = "(V)";
                if (pag.LavoriInEconomia) dgi.Cells[2].Text = "<b>Tipo:</b> " + pag.TipoGiustificativo + " <BR /><b>Descrizione:</b> " + pag.Descrizione;
                else
                {
                    // visualizzo il dettaglio solo se giustificativo reale e non lavori in economia
                    dgi.Cells[2].Text = "<b>Tipo:</b> " + pag.TipoGiustificativo + " nr. " + pag.Numero + " data: " + pag.Data
                       + "<BR /><b>D.D.T:</b> nr." + pag.NumeroDoctrasporto + " data: " + pag.DataDoctrasporto
                       + " <BR /><b>Oggetto spesa:</b> " + pag.Descrizione;
                    dgi.Cells[3].Text = "<img src='../../images/acrobat.gif' alt='Visualizza documento' title='Visualizza documento'"
                        + "style='cursor:pointer' onclick=\"" + (pag.IdFile == null ? "SNCVisualizzaReport('rptGiustificativo',1,'IdGiustificativo=" + pag.IdGiustificativo + "');"
                        : "SNCUFVisualizzaFile(" + pag.IdFile + ");") + "\" />";
                }

                if (pag.SpesaTecnicaRichiesta) importo_spese_richieste += pag.ImportoRichiesto;
                else importo_investimento_richiesto += pag.ImportoRichiesto;
                if (pag.ImportoAmmesso != null)
                {
                    //totale 
                    tot_importo_ammesso += pag.ImportoAmmesso;

                    if (pag.SpesaTecnicaAmmessa != null && pag.SpesaTecnicaAmmessa) importo_spese_ammesse += pag.ImportoAmmesso;
                    else importo_investimento_ammesso += pag.ImportoAmmesso;
                    decimal contributo_ammesso = Math.Round(pag.ImportoAmmesso.Value * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
                    if (pag.ContributoAmmesso == null)
                    {
                        dgi.Cells[7].Text = string.Format("{0:c}", contributo_ammesso);
                        tot_contributo_ammesso += contributo_ammesso;
                    }
                    else
                        tot_contributo_ammesso += pag.ContributoAmmesso;
                }

                decimal contributo_calcolato = Math.Round(pag.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
                dgi.Cells[6].Text = string.Format("{0:c}", contributo_calcolato);

                //CheckBox chkRichiesta = new CheckBox(), chkAmmessa = new CheckBox();
                //chkRichiesta.ID = "chkSpesaTecnicaRichiesta" + pag.IdPagamentoBeneficiario;
                //chkRichiesta.Checked = pag.SpesaTecnicaRichiesta;
                //chkRichiesta.Enabled = false;
                //dgi.Cells[6].Controls.Add(chkRichiesta);
                //chkAmmessa.ID = "chkSpesaTecnicaAmmessa" + pag.IdPagamentoBeneficiario;
                //chkAmmessa.Enabled = false;
                //chkAmmessa.Checked = (pag.SpesaTecnicaAmmessa != null && pag.SpesaTecnicaAmmessa);
                //dgi.Cells[10].Controls.Add(chkAmmessa);
                string url_modifica = "$('[id$=hdnIdPagamentoBeneficiario]').val(" + pag.IdPagamentoBeneficiario
                    + ");$('[id$=btnPost]').click();";
                dgi.Cells[9].Text = "<input type='button' class='ButtonGrid' style='width:70px' onclick=\"" + url_modifica + "\" value='"
                    + (AbilitaModifica ? "Modifica" : "Dettaglio") + "' />";
                //calcolo totali
                tot_imponibile += pag.Imponibile;
                tot_Importo_richiesto += pag.ImportoRichiesto;
                tot_contributo_richiesto += contributo_calcolato;

                SiarLibrary.PagamentiRichiesti pg = prichiesti_provider.GetById(pag.IdPagamentoRichiesto);
                SiarLibrary.DomandaDiPagamento ddp = PagamentoProvider.GetById(pg.IdDomandaPagamento);
                dgi.Cells[0].Text = ddp.IdDomandaPagamento;
                dgi.Cells[1].Text = ddp.CodTipo;

            }
            else
            {

                e.Item.Cells[4].Text = string.Format("{0:c}", tot_imponibile);
                e.Item.Cells[5].Text = string.Format("{0:c}", tot_Importo_richiesto);
                e.Item.Cells[6].Text = string.Format("{0:c}", tot_contributo_richiesto);
                e.Item.Cells[7].Text = string.Format("{0:c}", tot_importo_ammesso);
                e.Item.Cells[8].Text = string.Format("{0:c}", tot_contributo_ammesso);
            }
        }

        #endregion

        #region button

        protected void btnSaveRichiesto_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, _investimento.IdInvestimento, null,
                    DomandaPagamento.IdDomandaPagamento);
                if (prichiesti.Count > 0) prichiesto = prichiesti[0];
                if (prichiesto == null) throw new Exception("Si è verificato un errore nella procedura.");
                PagamentoProvider.DbProviderObj.BeginTran();
                SalvaPagamentoRichiesto();

                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Dati di pagamento salvati correttamente.");
            }
            catch (Exception ex) { prichiesti_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnAmmettiPagamento_Click(object sender, EventArgs e)
        {
            string messaggio = "Istruttoria del pagamento salvata correttamente.";
            try
            {
                int check;
                if (!int.TryParse(hdnIdPagamentoBeneficiario.Text, out check)) throw new Exception("Si è verificato un errore nella procedura.");
                SiarLibrary.PagamentiBeneficiario pagben = pbeneficiario_provider.GetById(check);
                prichiesto = prichiesti_provider.GetById(pagben.IdPagamentoRichiesto);
                if (prichiesto == null) throw new Exception("Si è verificato un errore nella procedura.");

                decimal old_importo = (pagben.ImportoAmmesso != null ? pagben.ImportoAmmesso.Value : 0);
                decimal importo_giustificativo = pagben.Imponibile + ((pagben.IvaNonRecuperabile ? Math.Round(pagben.Imponibile.Value * pagben.Iva / 100, 2, MidpointRounding.AwayFromZero) : 0));
                decimal new_importo = 0, importo_nonresp = 0;
                decimal.TryParse(txtIPImportoAmmesso.Text, out new_importo);
                decimal.TryParse(txtIPImportoNonresp.Text, out importo_nonresp);

                if (new_importo > importo_giustificativo) throw new Exception("Importo ammesso non valido perchè maggiore dell`imponibile del giustificativo.");
                if (new_importo > pagben.ImportoRichiesto) throw new Exception("Importo ammesso non valido perchè maggiore di quello richiesto.");
                if (importo_nonresp > pagben.ImportoRichiesto - new_importo) throw new Exception("Importo non ammesso a non responsabilita' non valido perchè maggiore dello scostamento.");


                decimal importo_disponibile_giustificativo = SiarLibrary.DbStaticProvider.GetAmmontareDisponibileGiustificativo(
                    pagben.IdGiustificativo, importo_giustificativo + old_importo, true, PagamentoProvider.DbProviderObj);
                if (new_importo > importo_disponibile_giustificativo)
                {
                    new_importo = importo_disponibile_giustificativo;
                    messaggio = "L`importo inserito supera l`ammontare disponibile per il giustificativo selezionato, è stato troncato.";
                }
                if (new_importo < 0 || importo_nonresp < 0) throw new Exception("Nessuno degli importi imputabili può essere negativo.");

                decimal quotaImporto = Math.Round(Convert.ToDecimal(txtIPContributoQuota.Text), 12, MidpointRounding.AwayFromZero);
                decimal Contributo = Math.Round(Convert.ToDecimal(txtIPContributoAmmesso.Text), 2, MidpointRounding.AwayFromZero);
                decimal ContributoCalcolato = Math.Round(new_importo * quotaImporto / 100, 2, MidpointRounding.AwayFromZero);
                decimal ContributoRichiesto = Math.Round(pagben.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);

                if ((new_importo < pagben.ImportoRichiesto || ContributoCalcolato < ContributoRichiesto) && string.IsNullOrEmpty(chklIPMotivazioniRiduzione.SelectedValue))
                    throw new Exception("Si richiede di specificare le motivazioni della riduzione per gli importi non ammessi.");
                if ((new_importo < pagben.ImportoRichiesto || ContributoCalcolato < ContributoRichiesto) && chklIPMotivazioniRiduzione.SelectedValue == "ALT" && (txtIPNoteAggiuntive.Text == null || txtIPNoteAggiuntive.Text == ""))
                    throw new Exception("Si richiede di specificare nelle note la motivazioni della riduzione per gli importi.");
                if (new_importo == pagben.ImportoRichiesto && ContributoCalcolato == ContributoRichiesto && !string.IsNullOrEmpty(chklIPMotivazioniRiduzione.SelectedValue))
                    throw new Exception("Le motivazioni della riduzione di spese sono valide solo per gli importi non ammessi.");

                PagamentoProvider.DbProviderObj.BeginTran();

                pagben.ImportoAmmesso = new_importo;
                pagben.QuotaContributoAmmesso = txtIPContributoQuota.Text;

                if (ContributoCalcolato == Contributo)
                    pagben.ContributoAmmesso = txtIPContributoAmmesso.Text;
                else
                    pagben.ContributoAmmesso = ContributoCalcolato;

                pagben.ImportoNonammNonresp = txtIPImportoNonresp.Text;
                pagben.SpesaTecnicaAmmessa = chkIPSpesaTecnica.Checked;
                pagben.CodRiduzione = chklIPMotivazioniRiduzione.SelectedValue;

                SiarLibrary.Note motivazioni = new SiarLibrary.Note();
                if (pagben.MotivazioneRiduzione != null) motivazioni = note_provider.GetById(pagben.MotivazioneRiduzione);
                if (!string.IsNullOrEmpty(txtIPNoteAggiuntive.Text))
                {
                    motivazioni.Testo = txtIPNoteAggiuntive.Text;
                    note_provider.Save(motivazioni);
                    pagben.MotivazioneRiduzione = motivazioni.Id;
                }
                else if (motivazioni.Id != null)
                {
                    note_provider.Delete(motivazioni);
                    pagben.MotivazioneRiduzione = null;
                }
                pbeneficiario_provider.Save(pagben);

                SalvaPagamentoRichiesto();
                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); messaggio = "Attenzione! " + ex.Message.ToCleanJsString(); }
            finally
            {
                btnPost_Click(sender, e);
                //RegisterClientScriptBlock("alert('" + messaggio + "');"); 
                if (messaggio.Equals("Istruttoria del pagamento salvata correttamente."))
                    ShowMessage(messaggio);
                else
                    ShowError(messaggio);
            }
        }


        private void SalvaPagamentoRichiesto()
        {
            decimal importo_investimento = 0, contributo_investimento = 0, importo_spese_tecniche = 0, impcomputometrico = 1000000000, importo_lavori_in_economia = 0;
            if (prichiesto.IdPagamentoRichiesto != null)
            {
                pbeneficiario_attuali = pbeneficiario_provider.Find(prichiesto.IdPagamentoRichiesto, null, null, null, null, null);
                foreach (SiarLibrary.PagamentiBeneficiario pb in pbeneficiario_attuali)
                {
                    if (pb.ImportoAmmesso != null)
                    {
                        if (pb.SpesaTecnicaAmmessa) importo_spese_tecniche += pb.ImportoAmmesso;
                        else importo_investimento += pb.ImportoAmmesso;
                        if (pb.CodTipo == "LEC") importo_lavori_in_economia += pb.ImportoAmmesso;
                    }
                    if (pb.ContributoAmmesso != null)
                    {
                        contributo_investimento += pb.ContributoAmmesso;
                    }
                }
            }
            // memorizzo il richiesto non troncato
            prichiesto.ImportoAmmesso = importo_investimento + importo_spese_tecniche;
            prichiesto.ImportoRichiesto = importo_investimento + importo_spese_tecniche;

            #region calcolo il contributo
            //suddivido il contributo tra costo investimento e spese tecniche (mutuo 112 niente spese tecniche)           
            decimal contributo_spese_tecniche_richiesto = 0;
            if (_investimento.SpeseGenerali != null && importo_spese_tecniche > _investimento.SpeseGenerali) importo_spese_tecniche = _investimento.SpeseGenerali;
            if (_investimento.CodTipoInvestimento != 2 && _investimento.QuotaSpeseGenerali != null && _investimento.QuotaSpeseGenerali > 0)
            {
                decimal max_spese_tecniche_investimento = (_investimento.CostoInvestimento * _investimento.QuotaSpeseGenerali / 100);
                if (importo_spese_tecniche > max_spese_tecniche_investimento) importo_spese_tecniche = max_spese_tecniche_investimento;
                contributo_spese_tecniche_richiesto = Math.Round(importo_spese_tecniche * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            }
            // tronco l'importo su cui calcolare il contributo per evitare che prenda anche la capienza delle spese tecniche
            if (importo_investimento > _investimento.CostoInvestimento) importo_investimento = _investimento.CostoInvestimento;
            //decimal contributo_costo_investimento_calcolato = Math.Round(importo_investimento * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            decimal contributo_costo_investimento_calcolato = contributo_investimento;
            decimal contributo_calcolato = contributo_costo_investimento_calcolato + contributo_spese_tecniche_richiesto;

            // controllo il disponibile per l'investimento
            decimal contributo_disponibile = _investimento.ContributoRichiesto.Value - SiarLibrary.DbStaticProvider.GetAmmontareErogatoInvestimento(
                _investimento.IdInvestimento, DomandaPagamento.IdDomandaPagamento, PagamentoProvider.DbProviderObj);
            if (contributo_disponibile < 0) contributo_disponibile = 0;
            if (contributo_calcolato > contributo_disponibile) contributo_calcolato = contributo_disponibile;





            //if (contributo_calcolato > 0)
            //{
            //    //controllo disponibile di progetto correlato 
            //    decimal contributo_disponibile_domanda = PagamentoProvider.CalcoloContributoAmmessoDisponibilePagamento(_investimento.IdProgetto,
            //        DomandaPagamento.IdDomandaPagamento, _investimento.CodTipoInvestimento, prichiesto.IdPagamentoRichiesto);
            //    if (contributo_calcolato > contributo_disponibile_domanda) contributo_calcolato = contributo_disponibile_domanda;
            //    // controllo sul richiesto
            //    if (contributo_calcolato > prichiesto.ContributoRichiesto) contributo_calcolato = prichiesto.ContributoRichiesto;
            //}

            #endregion

            //decimal costoDaAssegnare = 0;
            //decimal.TryParse(txtCostoDaAssegnare.Text, out costoDaAssegnare);

            //decimal economieDaCoprire = 0;
            //decimal.TryParse(txtEconomieDaCoprire.Text, out economieDaCoprire);

            //decimal contributoDisavanzoVecchio = 0;
            //if (prichiesto.ContributoDisavanzoCostiAmmessi != null)
            //    contributoDisavanzoVecchio = prichiesto.ContributoDisavanzoCostiAmmessi;
            //decimal contributoDisavanzoAttuale = costoDaAssegnare * _investimento.QuotaContributoRichiesto / 100;

            //decimal economieScoperte = economieDaCoprire - (getTotalePagamentiRiassegnatiDomanda(contributoDisavanzoVecchio, DomandaPagamento.IdDomandaPagamento) + contributoDisavanzoAttuale);

            //decimal disavanzoInvestimento = 0;
            //decimal.TryParse(txtDisavanzoInvestimento.Text, out disavanzoInvestimento);

            //decimal contributiRiassegnatiInvestimento = 0;
            //decimal.TryParse(txtImportoRiassegnatoInvestimento.Text, out contributiRiassegnatiInvestimento);

            //bool altreDomandeOk = checkAltreDomandeProgetto(DomandaPagamento.IdProgetto);


            //// contributo dispoibile - contributo riassegnato - contributo da assegnare deve essere >= 0
            //decimal contributoDisponibile = disavanzoInvestimento * _investimento.QuotaContributoRichiesto / 100;
            //decimal contributoDaAssegnare = costoDaAssegnare * _investimento.QuotaContributoRichiesto / 100;

            //if (costoDaAssegnare > disavanzoInvestimento) { throw new Exception("Non si possono assegnare più fondi di quelli a disposizione."); }
            //if (costoDaAssegnare * _investimento.QuotaContributoRichiesto / 100 > economieDaCoprire || economieScoperte < 0) { throw new Exception("Il contributo non può superare il massimo assegnabile."); }
            //if (contributoDisponibile - contributiRiassegnatiInvestimento - contributoDaAssegnare < 0) { throw new Exception("I contributi in disavanzo totali disponibili per l'investimento sono stati esauriti tra tutte le domande di pagamento presentate. Modificare l'importo."); }
            //if (costoDaAssegnare > 0 && !altreDomandeOk) { throw new Exception("Non si possono assegnare fondi se ci sono altre domande di pagamento per il progetto che non sono ancora state istruite."); }

            //prichiesto.ImportoDisavanzoCostiAmmessi = costoDaAssegnare;
            //prichiesto.ContributoDisavanzoCostiAmmessi = costoDaAssegnare * _investimento.QuotaContributoRichiesto / 100;

            prichiesto.ImportoDisavanzoCostiAmmessi = 0;
            prichiesto.ContributoDisavanzoCostiAmmessi = 0;

            prichiesto.ContributoAmmesso = contributo_calcolato;
            prichiesto.ContributoRichiesto = contributo_calcolato;

            if (AltreFonti)
                //prichiesto.ContributoAmmessoAltreFonti = Math.Round((prichiesto.ImportoAmmesso + costoDaAssegnare) * _investimento.QuotaContributoAltreFonti / 100, 2, MidpointRounding.AwayFromZero);
                prichiesto.ContributoAmmessoAltreFonti = Math.Round((prichiesto.ImportoAmmesso ) * _investimento.QuotaContributoAltreFonti / 100, 2, MidpointRounding.AwayFromZero);
            else
                prichiesto.ContributoAmmessoAltreFonti = null;

            prichiesto.Ammesso = true;
            prichiesto.DataValutazione = DateTime.Now;
            prichiesto.Istruttore = Operatore.Utente.CfUtente;
            prichiesto.NoteIstruttore = txtValutazioneLunga.Text;
            prichiesti_provider.Save(prichiesto);
        }

        

        #region mostra pagamento beneficiario

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.PagamentiBeneficiario pagben = null;
                int check;
                if (int.TryParse(hdnIdPagamentoBeneficiario.Text, out check)) pagben = pbeneficiario_provider.GetById(check);
                if (pagben == null) throw new Exception("Si è verificato un errore nella procedura.");
                CaricaDatiPagamento(pagben);
            }
            catch (Exception ex) { RegisterClientScriptBlock("chiudiPopup();"); ShowError(ex); }
        }

        private void CaricaDatiPagamento(SiarLibrary.PagamentiBeneficiario pagben)
        {
            System.Collections.Generic.Dictionary<string, string> tipi_riduzione = SiarLibrary.DbStaticProvider.
                   GetTipiRiduzionePagamento(true, pagben.CodTipo == "LEC");
            SiarLibrary.Note motivazioni = null;
            if (pagben.MotivazioneRiduzione != null)
                motivazioni = new SiarBLL.NoteCollectionProvider().GetById(pagben.MotivazioneRiduzione);

            txtGSData.Text = pagben.Data;
            txtGSNumero.Text = pagben.Numero;
            txtGSImponibile.Text = pagben.Imponibile;
            txtGSOggetto.Text = pagben.Descrizione;
            txtIPImportoRichiesto.Text = pagben.ImportoRichiesto;
            decimal contributo_richiesto = Math.Round(pagben.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            txtIPContributoRichiesto.Text = contributo_richiesto.ToString();
            chkIPSpesaTecnicaRichiesta.Checked = pagben.SpesaTecnicaRichiesta;
            chkIPVariazione.Checked = pagben.CostituisceVariante;
            chklIPMotivazioniRiduzione.BindItems(tipi_riduzione);
            chklIPMotivazioniRiduzione.SelectedValue = pagben.CodRiduzione;
            txtIPNoteAggiuntive.Text = null;
            if (motivazioni != null) txtIPNoteAggiuntive.Text = motivazioni.Testo;

            if (pagben.ImportoAmmesso != null)
            {
                txtIPImportoAmmesso.Text = pagben.ImportoAmmesso;
                chkIPSpesaTecnica.Checked = (pagben.SpesaTecnicaAmmessa != null && pagben.SpesaTecnicaAmmessa);
                decimal contributo_ammesso = 0;
                if (pagben.ContributoAmmesso != null)
                    contributo_ammesso = pagben.ContributoAmmesso;
                else
                    contributo_ammesso = Math.Round(pagben.ImportoAmmesso.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
                txtIPContributoAmmesso.Text = string.Format("{0:N}", contributo_ammesso);
                if (pagben.QuotaContributoAmmesso != null)
                    txtIPContributoQuota.Text = string.Format("{0:N12}", pagben.QuotaContributoAmmesso);
                else
                    txtIPContributoQuota.Text = string.Format("{0:N12}", _investimento.QuotaContributoRichiesto);
                decimal importo_nonammesso = pagben.ImportoRichiesto - pagben.ImportoAmmesso;
                txtIPImportoNonAmmesso.Text = string.Format("{0:N}", importo_nonammesso);
                txtIPContributoNonAmmesso.Text = string.Format("{0:N}", contributo_richiesto - contributo_ammesso);
                if (pagben.ImportoNonammNonresp != null)
                {
                    txtIPImportoNonresp.Text = pagben.ImportoNonammNonresp;
                    txtIPContributoNonresp.Text = string.Format("{0:N}", Math.Round(pagben.ImportoNonammNonresp * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero));
                }
                else { txtIPImportoNonresp.Text = txtIPContributoNonresp.Text = ""; }
            }
            else
            {
                txtIPImportoAmmesso.Text = txtIPImportoNonAmmesso.Text = txtIPContributoAmmesso.Text = txtIPContributoNonAmmesso.Text =
                    txtIPImportoNonresp.Text = txtIPContributoNonresp.Text = "";
                chkIPSpesaTecnica.Checked = false;
                //Ripropongo gli stessi valori del pagamento, contributo e percentuale richiesta
                txtIPContributoQuota.Text = string.Format("{0:N12}", _investimento.QuotaContributoRichiesto);
                txtIPImportoAmmesso.Text = pagben.ImportoRichiesto;
                txtIPContributoAmmesso.Text = contributo_richiesto.ToString();

            }
            /* 25/02/2015 commentata perche per ora non visibile
            if (pagben.ImportoAmmessoContr != null)
            {
                txtIPImportoAmmessoInLoco.Text = pagben.ImportoAmmessoContr;
                chkIPSpesaTecnicaInLoco.Checked = (pagben.SpesaTecnicaAmmessaContr != null && pagben.SpesaTecnicaAmmessaContr);
                decimal contributo_ammesso_inloco = Math.Round(pagben.ImportoAmmessoContr.Value * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
                txtIPContributoAmmessoInLoco.Text = string.Format("{0:N}", contributo_ammesso_inloco);
                decimal importo_nonammesso_inloco = pagben.ImportoRichiesto - pagben.ImportoAmmessoContr;
                txtIPImportoNonAmmessoContr.Text = string.Format("{0:N}", importo_nonammesso_inloco);
                txtIPContributoNonAmmessoContr.Text = string.Format("{0:N}", contributo_richiesto - contributo_ammesso_inloco);
                if (pagben.ImportoNonammContrNonresp != null)
                {
                    txtIPImportoNonrespInLoco.Text = pagben.ImportoNonammContrNonresp;
                    txtIPContributoNonrespInLoco.Text = string.Format("{0:N}",
                        Math.Round(pagben.ImportoNonammContrNonresp * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero));
                }
                else { txtIPImportoNonrespInLoco.Text = ""; txtIPContributoNonrespInLoco.Text = ""; }
            }*/

            //RegisterClientScriptBlock("mostraPopupTemplate('divIstPagForm','divBKGMessaggio');");
            var giu = new SiarBLL.GiustificativiCollectionProvider().GetById(pagben.IdGiustificativo);
            modalePagamento.Utente = Operatore.Utente;
            modalePagamento.Domanda = DomandaPagamento;
            modalePagamento.Giustificativo = giu;
            modalePagamento.PagamentoBeneficiario = pagben;
            modalePagamento.PagamentiRichiesti = prichiesto;
            modalePagamento.PianoInvestimento = _investimento;
            RegisterClientScriptBlock(modalePagamento.Mostra);
            
        }



        #endregion

        protected void btnEliminaPag_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Progetto progetto = new SiarBLL.ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);
                if (new SiarBLL.BandoResponsabiliCollectionProvider().Find(progetto.IdBando, Operatore.Utente.IdUtente, null, true, true).Count == 0)
                    throw new Exception("Non si hanno i permessi.");
                SiarLibrary.PagamentiBeneficiario pagben_del = null;
                int check;
                if (int.TryParse(hdnIdPagamentoBeneficiarioDel.Text, out check)) pagben_del = pbeneficiario_provider.GetById(check);
                if (pagben_del == null) 
                    throw new Exception("Si è verificato un errore nella procedura.");
                if(DomandaPagamento.SegnaturaApprovazione != "" || DomandaPagamento.SegnaturaApprovazione != null)
                    throw new Exception("La richiesta di concessione di ulteriori contributi è gia stata istruita. Impossibile eliminare.");
                pbeneficiario_provider.Delete(pagben_del);
                hdnIdPagamentoBeneficiarioDel.Text = "";
                SalvaPagamentoRichiesto();
                ShowMessage("Pagamento eliminato correttamente.");
            }
            catch (Exception ex) { pbeneficiario_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnFiltra_Click(object sender, EventArgs e) { dgPagamentiPrecedenti.SetPageIndex(0); }

        #endregion
    }
}
