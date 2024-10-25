using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using SiarLibrary;
using SiarBLL;

namespace web.Private.PPagamento
{
    public partial class PianoInvestimenti : SiarLibrary.Web.DomandaPagamentoPage
    {
        PianoInvestimentiCollection investimenti;
        PagamentiRichiestiCollection pagamenti_richiesti;
        PagamentiRichiestiFemCollection pagamenti_richiesti_fem;
        PagamentiRichiestiCollectionProvider prichiesti_provider;
        PagamentiRichiestiFemCollectionProvider prichiesti_fem_provider;
        PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.PianoInvestimenti premiocc = null;
        BandoTipoInvestimentiCollection tipo_investimenti = null;

        IntegrazioniPerDomandaDiPagamentoCollectionProvider integrazione_provider;
        IntegrazioniPerDomandaDiPagamento integrazione_selezionata = null;
        IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider;
        IntegrazioneSingolaDiDomanda integrazione_singola_selezionata = null;
        int id_integrazione_di_domanda_singola;

        decimal costo_investimenti = 0,
                contributo_investimenti = 0,
                pag_inv_costo_richiesto = 0,
                pag_inv_contributo_richiesto = 0,
                pag_inv_contributo_ammesso = 0;

        decimal costo_brevetti = 0,
                contributo_brevetti = 0,
                pag_brev_costo_richiesto = 0,
                pag_brev_contributo_richiesto = 0,
                pag_brev_contributo_ammesso = 0;

        private bool strumenti_finanziari = false, nascondiPinv = false;

        #region Indici colonne dgInvestimenti  

        private int col_Numero = 0,
            col_Programmazione = 1,
            col_Descrizione = 2,
            col_SettoreProduttivo = 3,
            col_CostoTotInvestimento = 4,
            col_ContributoAmmesso = 5,
            col_PercContributoAmmesso = 6,
            col_ImportoPagRichiesto = 7,
            col_ContributoPagRichiesto = 8,
            col_ContributoPagAmmissibile = 9,
            col_PercRendicontazione = 10,
            col_Integrazione = 11;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            imgMostraPiano.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");

            investimenti_provider = new PianoInvestimentiCollectionProvider(PagamentoProvider.DbProviderObj);
            prichiesti_provider = new PagamentiRichiestiCollectionProvider(PagamentoProvider.DbProviderObj);
            prichiesti_fem_provider = new PagamentiRichiestiFemCollectionProvider(PagamentoProvider.DbProviderObj);
            /*if (DomandaPagamento.CodTipo != "SLD")*/
            tbAmmissibilitaRendicontazione.Visible = false;
            if (Progetto.IdProgIntegrato == null)
            {
                btnDettaglioMisura.Visible = false;
            }
            tipo_investimenti = new BandoTipoInvestimentiCollectionProvider().GetTipoInvestimentiProgetto(Progetto.IdBando, true);

            if (DomandaPagamento.TpAppaltoStrumentiFinanziari)
                strumenti_finanziari = true;

            string nascodiDiv = "";
            nascodiDiv = new BandoConfigCollectionProvider().GetBandoConfig_NascondiPInv(Progetto.IdBando);
            if (nascodiDiv == "True")
            {
                PianoInvestimentiAggregazioneDomanda.Visible = false;
                PianoInvestimentiCodificaDomanda.Visible = false;
                PianoInvestimentiInterventoDomanda.Visible = false;
            }

        }

        protected override void OnPreRender(EventArgs e)
        {
            investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
            // pagamenti richiesti nella presente domanda di pagamento (non compresi nella query del piano investimento) 
            pagamenti_richiesti = prichiesti_provider.Find(null, null, Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
            pagamenti_richiesti_fem = prichiesti_fem_provider.Find(null, null, null, Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento, null);
            PianoInvestimentiCollection inv_supp = null;

            //investimenti ordinari 
            if (investimenti.Count > 0)
            {
                tableInvestimenti.Visible = true;
                //inv_supp = investimenti.FiltroTipoInvestimento(1); 
                dgInvestimenti.DataSource = investimenti;
                if (investimenti.Count == 0)
                {
                    dgInvestimenti.Titolo = "Nessun elemento trovato.";
                }
                else
                {
                    dgInvestimenti.ItemDataBound += new DataGridItemEventHandler(dgInvestimenti_ItemDataBound);
                    dgInvestimenti.MostraTotale("DataField", 4, 5, 6);
                    tbLegendaInvestimenti.Visible = true;
                }
                dgInvestimenti.DataBind();
            }

            //// brevetti e licenze 
            //if (tipo_investimenti.FiltroCodiceTipo(5).Count > 0) 
            //{ 
            //    tableBrevetti.Visible = true; 
            //    inv_supp = investimenti.FiltroTipoInvestimento(5); 
            //    dgBrevetti.DataSource = inv_supp; 
            //    if (inv_supp.Count == 0) 
            //    { 
            //        dgBrevetti.Titolo = "Nessun elemento trovato."; 
            //    } 
            //    else 
            //    { 
            //        dgBrevetti.ItemDataBound += new DataGridItemEventHandler(dgBrevetti_ItemDataBound); 
            //        dgBrevetti.MostraTotale("DataField", 2, 3); 
            //    } 
            //    dgBrevetti.DataBind(); 
            //} 

            //// fidejussione 
            //if (tipo_investimenti.FiltroCodiceTipo(4).Count > 0) 
            //{ 
            //    tableFidejussione.Visible = true; 
            //    inv_supp = investimenti.FiltroTipoInvestimento(4); 
            //    dgFidejussione.DataSource = inv_supp; 
            //    if (inv_supp.Count == 0) 
            //    { 
            //        dgFidejussione.Titolo = "Nessun elemento trovato."; 
            //    } 
            //    else 
            //    { 
            //        dgFidejussione.ItemDataBound += new DataGridItemEventHandler(dgFidejussione_ItemDataBound); 
            //    } 
            //    dgFidejussione.DataBind(); 
            //} 

            ////mutuo 
            //if (tipo_investimenti.FiltroCodiceTipo(2).Count > 0) 
            //{ 
            //    tableMutuo.Visible = true; 
            //    inv_supp = investimenti.FiltroTipoInvestimento(2); 
            //    dgMutuo.DataSource = inv_supp; 
            //    if (inv_supp.Count == 0) 
            //    { 
            //        dgMutuo.Titolo = "Nessun elemento trovato."; 
            //    } 
            //    else 
            //    { 
            //        dgMutuo.ItemDataBound += new DataGridItemEventHandler(dgMutuo_ItemDataBound); 
            //    } 
            //    dgMutuo.DataBind(); 
            //} 

            //// premio in conto capitale 
            //if (tipo_investimenti.FiltroCodiceTipo(3).Count > 0 && DomandaPagamento.CodTipo == "SLD") 
            //{ 
            //    tablePremio.Visible = true; 
            //    premiocc = investimenti_provider.CalcoloPremioSaldo(DomandaPagamento.IdDomandaPagamento, 0); 
            //    decimal anticipo_percepito = 0; 
            //    //calcolo l'anticipo erogato 
            //    DomandaDiPagamentoCollection anticipo = PagamentoProvider.Find(null, "ANT", Progetto.IdProgetto, null).FiltroApprovata(true); 
            //    if (anticipo.Count > 0) 
            //    { 
            //        AnticipiRichiestiCollection anticipi = new AnticipiRichiestiCollectionProvider().Find(null, 
            //                                                               anticipo[0].IdDomandaPagamento, Progetto.IdBando); 
            //        if (anticipi.Count > 0) 
            //        { 
            //            anticipo_percepito = anticipi[0].ContributoAmmesso; 
            //        } 
            //    } 
            //    txtPCCAmmontare.Text = premiocc != null ? premiocc.CostoInvestimento : 0; 
            //    txtPCCAnticipo.Text  = anticipo_percepito.ToString(); 
            //    txtPCCRimanente.Text = (premiocc != null ? premiocc.CostoInvestimento - anticipo_percepito : 0).ToString(); 
            //    //foreach (BandoProgrammazione bp in disposizioni_attuative) 
            //    //{ 
            //    //    if (Progetto.IdProgetto == new NullTypes.IntNT(bp.AdditionalAttributes["IdProgetto"])) 
            //    //    { 
            //    //        txtPCCProgrammazione.Text = bp.Codice; 
            //    //        break; 
            //    //    } 
            //    //} 
            //} 
            imgRedStar.Src = Request.ApplicationPath + "/images/star_red.gif";
            bindTotali();

            if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
                riempiCampiIntegrazione();

            base.OnPreRender(e);
        }

        private void riempiCampiIntegrazione()
        {
            integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
            integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();

            if (Session["id_integrazione_domanda"] != null)
                integrazione_selezionata = integrazione_provider.GetById(int.Parse(Session["id_integrazione_domanda"].ToString()));
            else
            {
                var integrazioni_collection = integrazione_provider.Find(null, DomandaPagamento.IdDomandaPagamento, false, null);
                integrazione_selezionata = integrazioni_collection[0];
            }

            integrazione_selezionata = integrazione_provider.GetById(integrazione_selezionata.IdIntegrazioneDomandaDiPagamento);

            if (integrazione_selezionata.SegnaturaIstruttore == null)
                Redirect(PATH_PPAGAMENTO + "GestioneLavori.aspx", "L'istruttore sta preparando una richiesta di integrazioni, impossibile accedere", true);

            if (int.TryParse(hdnIdIntegrazioneSingolaSelezionata.Value, out id_integrazione_di_domanda_singola))
                integrazione_singola_selezionata = integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola);

            var integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, null, null, null, null);
            var integrazioni_singole_list = integrazioni_singole_collection.ToArrayList<IntegrazioneSingolaDiDomanda>();

            if (integrazioni_singole_list
                    .Where(i => i.CodTipoIntegrazione == "ALL")
                    .Count() < 1)
                btnAllegati.Visible = false;
            if (integrazioni_singole_list
                    .Where(i => i.CodTipoIntegrazione == "GIU")
                    .Count() < 1
                    && integrazioni_singole_list
                        .Where(i => i.CodTipoIntegrazione == "PAG")
                        .Count() < 1)
                btnSpese.Visible = false;

            //var integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "INV", null, null, null);
            integrazioni_singole_collection = integrazioni_singole_collection.SubSelect(null, null, "INV", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            if (integrazione_singola_selezionata != null)
            {
                trDettaglioIntegrazioneSingolaSelezionata.Visible = true;
                integrazioni_singole_collection = integrazioni_singole_collection.SubSelect(id_integrazione_di_domanda_singola, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                trDettaglioIntegrazioneSingolaSelezionata.Visible = true;
                riempiCampiIntegrazioneSingola();
            }

            dgIntegrazioni.DataSource = integrazioni_singole_collection;
            dgIntegrazioni.SetTitoloNrElementi();
            dgIntegrazioni.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgIntegrazioni_ItemDataBound);
            dgIntegrazioni.DataBind();

            abilitaComponentiIntegrazione();
        }

        protected void abilitaComponentiIntegrazione()
        {
            ucWorkflowPagamento.InIntegrazione = true;
            trIntegrazioniRichieste.Visible = true;
        }

        protected void riempiCampiIntegrazioneSingola()
        {
            //Campi istruttore 
            txtDataRichiesta.Text = integrazione_singola_selezionata.DataRichiestaIntegrazioneIstruttore;
            txtTipoIntegrazione.Text = integrazione_singola_selezionata.DescrizioneTipoIntegrazione;
            txtNoteSingolaIntegrazioneIstruttore.Text = integrazione_singola_selezionata.NoteIntegrazioneIstruttore;
            comboCompletataSingolaIntegrazioneDomandaIstruttore.ClearSelection();
            string val_istruttore = "false";
            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore)
                val_istruttore = "true";
            comboCompletataSingolaIntegrazioneDomandaIstruttore.Items.FindByValue(val_istruttore).Selected = true;

            //Campi beneficiario 
            if (integrazione_singola_selezionata.DataRilascioIntegrazioneBeneficiario == null)
                txtDataRilascio.Text = new SiarLibrary.NullTypes.DatetimeNT(DateTime.Now);
            else
                txtDataRilascio.Text = integrazione_singola_selezionata.DataRilascioIntegrazioneBeneficiario;
            txtNoteSingolaIntegrazioneBeneficiario.Text = integrazione_singola_selezionata.NoteIntegrazioneBeneficiario;
            comboCompletataSingolaIntegrazioneDomandaBeneficiario.ClearSelection();
            string val_beneficario = "false";
            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataBeneficiario != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataBeneficiario)
                val_beneficario = "true";
            comboCompletataSingolaIntegrazioneDomandaBeneficiario.Items.FindByValue(val_beneficario).Selected = true;

            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore)
            {
                txtDataRilascio.Enabled = false;
                txtNoteSingolaIntegrazioneBeneficiario.Enabled = false;
                btnSalvaSingolaIntegrazione.Enabled = false;
                comboCompletataSingolaIntegrazioneDomandaBeneficiario.Enabled = false;
            }
        }

        void dgInvestimenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti f = (SiarLibrary.PianoInvestimenti)dgi.DataItem;
                if (f.IdPrioritaSettoriale != null)
                {
                    dgi.Cells[col_Numero].Text = "<img src='" + Request.ApplicationPath + "/images/star_red.gif'><br /><br />" + dgi.Cells[col_Numero].Text;
                }
                dgi.Cells[col_Descrizione].Text = "<b>Codifica:</b> " + f.CodificaInvestimento + "<br /><b>Dettaglio:</b> " + f.DettaglioInvestimenti
                                    + "<br /><b>Descrizione:</b> " + f.Descrizione;

                if ((new SiarBLL.BandoProgrammazioneCollectionProvider().Find(Progetto.IdBando, null, null, null)).Count > 1)
                {
                    SiarLibrary.Zprogrammazione intervento = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(f.IdProgrammazione);
                    dgi.Cells[col_Descrizione].Text += "<br /><b> Intervento: </b > " + intervento.Codice + " " + intervento.Descrizione;
                }

                //Aggregazione 
                string[] Aggregazione = new string[2];
                Aggregazione = investimenti_provider.GetImpresaAggregazioneInvestimento(f.IdInvestimento);
                if (Aggregazione[0] != null && Aggregazione[1] != null && Aggregazione[0] != "" && Aggregazione[1] != "")
                {
                    dgi.Cells[col_Descrizione].Text += "<br /><b>Impresa: </b>" + Aggregazione[0] + " - " + Aggregazione[1];
                    SiarLibrary.Impresa impresa = new ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);
                    if (impresa.CodAteco2007 != null && impresa.CodAteco2007 != "")
                        dgi.Cells[col_Descrizione].Text += " - Ateco: " + impresa.CodAteco2007;
                }

                //Personalizzazione bando 6.2 
                if (Progetto.IdBando == 39)
                {
                    string linea_intervento = "";
                    linea_intervento = investimenti_provider.GetLineaInterventoInvestimento(f.IdInvestimento);
                    if (linea_intervento != null && linea_intervento != "")
                        dgi.Cells[col_Descrizione].Text += "<br /><b>" + linea_intervento + "</b>";
                }

                if (f.NonCofinanziato)
                {
                    e.Item.Cells[col_ContributoAmmesso].Text = "(*)";
                }
                decimal importo_pagamento_richiesti,
                        quota_completamento = 0,
                        costo_investimento = f.CostoInvestimento.Value + (f.SpeseGenerali ?? 0);
                decimal.TryParse(f.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                bool in_integrazione = false;

                if (!strumenti_finanziari)
                {
                    PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(f.IdInvestimento);
                    if (pagamenti.Count > 0)
                    {
                        // devo aggiungere il pagamento richiesto attuale non contato dalla query 
                        importo_pagamento_richiesti += pagamenti[0].ImportoRichiesto;
                        pag_inv_costo_richiesto += pagamenti[0].ImportoRichiesto;
                        pag_inv_contributo_richiesto += pagamenti[0].ContributoRichiesto;
                        dgi.Cells[col_ImportoPagRichiesto].Text = string.Format("{0:c}", pagamenti[0].ImportoRichiesto);
                        dgi.Cells[col_ContributoPagRichiesto].Text = string.Format("{0:c}", pagamenti[0].ContributoRichiesto);
                        if (pagamenti[0].ContributoAmmesso != null)
                        {
                            dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pagamenti[0].ContributoAmmesso);
                            pag_inv_contributo_ammesso += pagamenti[0].ContributoAmmesso;
                        }
                    }
                    if (costo_investimento > 0)
                    {
                        quota_completamento = Math.Round(100 * importo_pagamento_richiesti / costo_investimento, 2, MidpointRounding.AwayFromZero);
                    }

                    if (pagamenti.Count > 0)
                    {
                        var pbeneficiario_attuali = new PagamentiBeneficiarioCollectionProvider().Find(pagamenti[0].IdPagamentoRichiesto, null, null, null, null, null);
                        foreach (PagamentiBeneficiario pag_ben in pbeneficiario_attuali)
                        {
                            var giustificativo = new GiustificativiCollectionProvider().GetById(pag_ben.IdGiustificativo);
                            if (giustificativo != null && giustificativo.InIntegrazione != null && giustificativo.InIntegrazione)
                            {
                                in_integrazione = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    dgi.Cells[col_SettoreProduttivo].Text = dgi.Cells[col_SettoreProduttivo].Text.Replace("PagamentoInvestimento.aspx", "PagamentoInvestimentoFem.aspx");

                    var pagamenti_fem_coll = prichiesti_fem_provider.Find(null, null, f.IdInvestimento, f.IdProgetto, DomandaPagamento.IdDomandaPagamento, null);

                    if (pagamenti_fem_coll.Count > 0)
                    {
                        var pagamenti_fem_list = pagamenti_fem_coll.ToArrayList<PagamentiRichiestiFem>();

                        // devo aggiungere il pagamento richiesto attuale non contato dalla query 
                        var importo_richiesto = pagamenti_fem_list.Sum<PagamentiRichiestiFem>(p => p.ImportoRichiesto ?? 0.00);
                        var importo_ammesso = pagamenti_fem_list.Sum<PagamentiRichiestiFem>(p => p.ImportoAmmesso ?? 0.00);

                        importo_pagamento_richiesti += importo_richiesto;
                        pag_inv_costo_richiesto += importo_richiesto;
                        pag_inv_contributo_richiesto += importo_richiesto;
                        dgi.Cells[col_ImportoPagRichiesto].Text = string.Format("{0:c}", importo_richiesto);
                        dgi.Cells[col_ContributoPagRichiesto].Text = string.Format("{0:c}", importo_richiesto);

                        dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", importo_ammesso);
                        pag_inv_contributo_ammesso += importo_ammesso;

                    }

                    if (costo_investimento > 0)
                        quota_completamento = Math.Round(100 * importo_pagamento_richiesti / costo_investimento, 2, MidpointRounding.AwayFromZero);
                }

                costo_investimenti += costo_investimento;
                contributo_investimenti += f.ContributoRichiesto;
                dgi.Cells[col_CostoTotInvestimento].Text = string.Format("{0:c}", costo_investimento);
                dgi.Cells[col_PercRendicontazione].Text = string.Format("{0:N}", quota_completamento);

                if (!in_integrazione)
                    dgi.Cells[col_Integrazione].Text = "";
            }
            else if (dgi.ItemType == ListItemType.Footer)
            {
                decimal quota = 0;
                if (costo_investimenti > 0)
                {
                    quota = 100 * contributo_investimenti / costo_investimenti;
                }

                // se il bando è a importo fisso il contributo totale lo devo cambiare                 

                bool importoFisso = false;

                BandoConfigCollection config = new BandoConfigCollectionProvider().Find(Progetto.IdBando, "QUOTAFISSA", null, true, null);

                decimal contributo_quota_fissa = 0;

                if (config.Count > 0)

                {

                    importoFisso = true;

                    BandoImpreseQuotaFissa q = new BandoImpreseQuotaFissaCollectionProvider().Find(Progetto.IdBando, Progetto.IdImpresa, null, true)[0];

                    if (q != null)

                    {

                        if (contributo_investimenti < contributo_quota_fissa)

                            contributo_quota_fissa = contributo_investimenti;

                        else

                            contributo_quota_fissa = q.Quota;

                    }

                }

                SiarLibrary.NullTypes.DecimalNT contributo_calcolato = investimenti_provider.
                        CalcoloContributoInvestimentiProgetto(Progetto.IdProgetto, true, investimenti[0].IdVariante);
                if (importoFisso)
                    contributo_calcolato = contributo_quota_fissa;
                if (contributo_calcolato != null && contributo_calcolato < contributo_investimenti && !importoFisso)
                {
                    dgi.Cells[col_ContributoAmmesso].Text = "** " + String.Format("{0:c}", contributo_calcolato.Value);
                }
                else if (importoFisso && contributo_investimenti > contributo_quota_fissa)
                {
                    dgi.Cells[col_ContributoAmmesso].Text = "*** " + String.Format("{0:c}", contributo_quota_fissa);
                }
                else
                {
                    dgi.Cells[col_ContributoAmmesso].Text = string.Format("{0:c}", contributo_investimenti);
                }

                //controllo se il progetto ha un massimale di contributo, e al massimale le altre domande di pagamento gia istruite 
                if (contributo_calcolato != null && contributo_calcolato < contributo_investimenti)
                {
                    //calcolo il contributo gia erogato nelle precedenti domande di pagamento 
                    decimal contributo_erogato = 0;
                    DomandaDiPagamentoEsportazioneCollectionProvider dom_pag_esp = new DomandaDiPagamentoEsportazioneCollectionProvider();
                    DomandaDiPagamentoCollection dom_coll = new DomandaDiPagamentoCollectionProvider().Find(null, null, Progetto.IdProgetto, null);
                    foreach (DomandaDiPagamento dp in dom_coll)
                    {
                        if (dp.IdDomandaPagamento < DomandaPagamento.IdDomandaPagamento &&
                            dp.Approvata == true && dp.SegnaturaApprovazione != null && dp.SegnaturaApprovazione != "")
                        {
                            DomandaDiPagamentoEsportazione esp_coll = dom_pag_esp.GetById(dp.IdDomandaPagamento, Progetto.IdProgetto);
                            contributo_erogato += esp_coll.ImportoAmmesso;
                        }
                    }
                    if (!importoFisso)
                    {
                        if ((contributo_calcolato - contributo_erogato) < pag_inv_contributo_richiesto)
                            dgi.Cells[col_ContributoPagRichiesto].Text = "** " + String.Format("{0:c}", contributo_calcolato - contributo_erogato);
                        else
                            dgi.Cells[col_ContributoPagRichiesto].Text = String.Format("{0:c}", pag_inv_contributo_richiesto);

                        DomandaDiPagamentoEsportazione esp = null;
                        esp = dom_pag_esp.GetById(DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto);
                        if (esp != null)
                            dgi.Cells[col_ContributoPagAmmissibile].Text = "** " + string.Format("{0:c}", esp.ImportoAmmesso);
                        else
                            dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_contributo_ammesso);
                    }
                    else
                    {

                        if ((contributo_calcolato - contributo_erogato) < pag_inv_contributo_richiesto)

                            dgi.Cells[col_ContributoPagRichiesto].Text = "*** " + String.Format("{0:c}", contributo_calcolato - contributo_erogato);

                        else

                            dgi.Cells[col_ContributoPagRichiesto].Text = String.Format("{0:c}", pag_inv_contributo_richiesto);



                        DomandaDiPagamentoEsportazione esp = null;

                        esp = dom_pag_esp.GetById(DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto);

                        if (esp != null)

                            dgi.Cells[col_ContributoPagAmmissibile].Text = "*** " + string.Format("{0:c}", esp.ImportoAmmesso > contributo_calcolato ? contributo_calcolato : esp.ImportoAmmesso);

                        else

                            dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_contributo_ammesso);

                    }
                }
                else
                {
                    dgi.Cells[col_ContributoPagRichiesto].Text = string.Format("{0:c}", pag_inv_contributo_richiesto);
                    dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_contributo_ammesso);
                }

                dgi.Cells[col_CostoTotInvestimento].Text = string.Format("{0:c}", costo_investimenti);
                dgi.Cells[col_PercContributoAmmesso].Text = string.Format("{0:N}", Math.Round(quota, 2, MidpointRounding.AwayFromZero));
                dgi.Cells[col_ImportoPagRichiesto].Text = string.Format("{0:c}", pag_inv_costo_richiesto);
                //dgi.Cells[col_ContributoPagRichiesto].Text = string.Format("{0:c}", pag_inv_contributo_richiesto); 
                //dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_contributo_ammesso); 
            }
        }

        void dgBrevetti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti inv = (SiarLibrary.PianoInvestimenti)dgi.DataItem;
                decimal importo_pagamento_richiesti, quota_completamento = 0;
                decimal.TryParse(inv.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(inv.IdInvestimento);
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
                if (inv.CostoInvestimento > 0)
                {
                    quota_completamento = Math.Round(100 * importo_pagamento_richiesti / inv.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                }
                costo_brevetti += inv.CostoInvestimento;
                contributo_brevetti += inv.ContributoRichiesto;
                dgi.Cells[8].Text = string.Format("{0:N}", quota_completamento);
            }
            else if (dgi.ItemType == ListItemType.Footer)
            {
                decimal quota = 0;
                if (costo_brevetti > 0)
                {
                    quota = 100 * contributo_brevetti / costo_brevetti;
                }

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
                PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(inv.IdInvestimento);
                if (pagamenti.Count > 0)
                {
                    // devo aggiungere il pagamento richiesto attuale non contato dalla query 
                    importo_pagamento_richiesti += pagamenti[0].ImportoRichiesto;
                    dgi.Cells[5].Text = string.Format("{0:c}", pagamenti[0].ImportoRichiesto);
                    dgi.Cells[6].Text = string.Format("{0:c}", pagamenti[0].ContributoRichiesto);
                    if (pagamenti[0].ContributoAmmesso != null)
                    {
                        dgi.Cells[7].Text = string.Format("{0:c}", pagamenti[0].ContributoAmmesso);
                    }
                }
                if (inv.CostoInvestimento > 0)
                {
                    quota_completamento = Math.Round(100 * importo_pagamento_richiesti / inv.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                }
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
                PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(inv.IdInvestimento);
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
                if (inv.CostoInvestimento > 0)
                {
                    quota_completamento = Math.Round(100 * importo_pagamento_richiesti / inv.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                }
                costo_brevetti += inv.CostoInvestimento;
                contributo_brevetti += inv.ContributoRichiesto;
                e.Item.Cells[8].Text = string.Format("{0:N}", quota_completamento);
            }
        }

        private void bindTotali()
        {
            SiarLibrary.NullTypes.DecimalNT totale_importo_richiesto = 0,
                                            totale_contributo_richiesto = 0,
                                            totale_importo_ammesso = 0,
                                            totale_contributo_ammissibile = 0,
                                            totale_contributo_ammesso = 0,
                                            totale_costo_investimenti = 0,
                                            totale_contributo_progetto = 0,
                                            contributo_erogato = 0,
                                            importo_sanzione = 0,
                                            recupero_anticipo = 0;

            DbProvider db = PagamentoProvider.DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpCalcoloTotaliProgettoXDomandaPagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", Progetto.IdProgetto.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", DomandaPagamento.IdDomandaPagamento.Value));
            db.InitDatareader(cmd);
            if (db.DataReader.Read())
            {
                totale_costo_investimenti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_TOTALE"]);
                totale_contributo_progetto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_TOTALE"]);
                contributo_erogato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_EROGATO"]);
                importo_sanzione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SANZIONE"]);
                recupero_anticipo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RECUPERO_ANTICIPO"]);
                totale_contributo_ammesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
                totale_contributo_ammissibile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMISSIBILE"]);
            }
            db.Close();

            txtErogato.Text = contributo_erogato;
            txtErogatoQuota.Text = totale_contributo_progetto == 0 ? string.Format("{0:N}", 0.00) : string.Format("{0:N}", Math.Round(100 * contributo_erogato / totale_contributo_progetto, 2, MidpointRounding.AwayFromZero));
            txtTotaleContributo.Text = totale_contributo_progetto;
            txtTotaleInvestimenti.Text = totale_costo_investimenti;

            bool valori_computo_metrico_inseriti = true;
            if (!strumenti_finanziari)
            {
                foreach (PagamentiRichiesti pr in pagamenti_richiesti)
                {
                    totale_contributo_richiesto += pr.ContributoRichiesto.Value;
                    totale_importo_richiesto += pr.ImportoRichiesto.Value;
                    //if (pr.ContributoAmmesso != null) totale_contributo_ammissibile += pr.ContributoAmmesso.Value; 
                    if (pr.ImportoAmmesso != null)
                    {
                        totale_importo_ammesso += pr.ImportoAmmesso.Value;
                    }
                    //controllo il computometrico 
                    SiarLibrary.PianoInvestimenti i = investimenti.CollectionGetById(pr.IdInvestimento);
                    if (i != null && i.Mobile != null && !i.Mobile && pr.ImportoComputoMetrico == null && valori_computo_metrico_inseriti)
                    {
                        valori_computo_metrico_inseriti = false;
                    }
                }
            }
            else
            {
                var pag_ric_fem_list = new PagamentiRichiestiFemCollectionProvider()
                    .Find(null, null, null, DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null)
                    .ToArrayList<PagamentiRichiestiFem>();

                totale_importo_richiesto = pag_ric_fem_list.Sum(p => p.ImportoRichiesto ?? 0);
                totale_contributo_richiesto = totale_importo_richiesto;
                totale_importo_ammesso = pag_ric_fem_list.Sum(p => p.ImportoAmmesso ?? 0);
                totale_contributo_ammesso = totale_importo_ammesso;
                totale_contributo_ammissibile = totale_importo_ammesso;
            }
            if (premiocc != null)
            {
                totale_contributo_richiesto += Math.Round(premiocc.CostoInvestimento.Value, 2, MidpointRounding.AwayFromZero);
                /*if (totale_contributo_ammissibile > 0) 
                    totale_contributo_ammissibile += Math.Round(premio.ContributoRichiesto.Value, 2, MidpointRounding.AwayFromZero);*/
            }

            // bandi importo fisso             

            // se il bando è a importo fisso il contributo totale lo devo cambiare                 

            bool importoFisso = false;

            BandoConfigCollection config = new BandoConfigCollectionProvider().Find(Progetto.IdBando, "QUOTAFISSA", null, true, null);

            decimal contributo_quota_fissa = 0;

            if (config.Count > 0)

            {

                importoFisso = true;

                BandoImpreseQuotaFissa q = new BandoImpreseQuotaFissaCollectionProvider().Find(Progetto.IdBando, Progetto.IdImpresa, null, true)[0];

                if (q != null)

                    contributo_quota_fissa = q.Quota;

            }

            txtTotaleImportoRichiesto.Text = totale_importo_richiesto;
            txtQuotaImportoRichiesta.Text = string.Format("{0:N}", Math.Round(totale_importo_richiesto * 100 / totale_costo_investimenti, 2, MidpointRounding.AwayFromZero));
            txtTotaleContributoRichiesto.Text = totale_contributo_richiesto;
            txtQuotaContributoRichiesta.Text = totale_contributo_progetto == 0 ? string.Format("{0:N}", 0.00) : string.Format("{0:N}", Math.Round(totale_contributo_richiesto * 100 / totale_contributo_progetto, 2, MidpointRounding.AwayFromZero));
            if (DomandaPagamento.SegnaturaApprovazione != null)
            {
                txtTotaleImportoAmmesso.Text = totale_importo_ammesso;
                txtQuotaImportoAmmessa.Text = string.Format("{0:N}", Math.Round(totale_importo_ammesso * 100 / totale_costo_investimenti, 2, MidpointRounding.AwayFromZero));

                if (importoFisso)

                {

                    SiarLibrary.NullTypes.DecimalNT contributo_rimanente = 0;

                    if (contributo_quota_fissa > contributo_erogato)

                        contributo_rimanente = contributo_quota_fissa - contributo_erogato;

                    if (totale_contributo_richiesto > contributo_rimanente)

                        totale_contributo_ammissibile = contributo_rimanente;

                }


                txtTotaleContributoAmmissibile.Text = totale_contributo_ammissibile;
                txtTotaleContributoAmmesso.Text = totale_contributo_ammesso;
                txtQuotaContributoAmmessa.Text = totale_contributo_progetto == 0 ? string.Format("{0:N}", 0.00) : string.Format("{0:N}", Math.Round(totale_contributo_ammesso * 100 / totale_contributo_progetto, 2, MidpointRounding.AwayFromZero));
                txtImportoSanzione.Text = importo_sanzione;
                txtRecuperoAnticipo.Text = recupero_anticipo;
            }

            // controllo massimali di pagamento 

            string errore = null;
            if (!valori_computo_metrico_inseriti)
            {
                errore = "Attenzione! E` obbligatorio inserire il valore del computo metrico per ognuno degli investimenti FISSI per cui si richiede il pagamento.";
            }
            else
            {
                errore = PagamentoProvider.ControlloMassimaliDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
            }
            if (!string.IsNullOrEmpty(errore))
            {
                ucWorkflowPagamento.ProseguiMessaggio = "Attenzione! " + errore;
                ucWorkflowPagamento.ProseguiAbilitato = false;
                if (totale_importo_richiesto > 0)
                {
                    ShowError(errore);
                }
            }
        }

        protected void btnDettaglioMisura_Click(object sender, EventArgs e)
        {
            dgDettaglioMisura.DataSource = new SiarLibrary.NotAutogeneratedClasses.RiepilogoImportiDomandaPagamentoCollectionProvider()
                                               .GetRiepilogoImportiXMisura(DomandaPagamento.IdDomandaPagamento);
            dgDettaglioMisura.MostraTotale("DataField", 1, 2, 3, 4, 6, 7, 8, 9);
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
                if (r.ContributoRichiesto == null || r.ContributoRichiesto <= 0)
                {
                    e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                }
                else if (r.ContributoRichiesto != null && r.ContributoTotaleProgettoCorrelato > 0)
                {
                    decimal quota = Math.Round((100 * r.ContributoRichiesto) / r.ContributoTotaleProgettoCorrelato, 2, MidpointRounding.AwayFromZero);
                    e.Item.Cells[5].Text = string.Format("{0:n}", quota);
                }
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            dgIntegrazioni.SetPageIndex(0);
        }

        protected void btnSalvaSingolaIntegrazione_Click(object sender, EventArgs e)
        {
            integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
            if (int.TryParse(hdnIdIntegrazioneSingolaSelezionata.Value, out id_integrazione_di_domanda_singola))
                integrazione_singola_selezionata = integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola);

            if (integrazione_singola_selezionata != null)
            {
                SiarLibrary.NullTypes.BoolNT newValue = comboCompletataSingolaIntegrazioneDomandaBeneficiario.SelectedValue;
                string messaggio = IntegrazioniDomandaPagamentoUtility.salvaSingolaIntegrazioneBeneficiario(integrazione_singola_selezionata, newValue, txtNoteSingolaIntegrazioneBeneficiario.Text, txtDataRilascio.Text);

                if (messaggio.StartsWith("Integrazione"))
                    ShowMessage(messaggio);
                else
                    ShowError(messaggio);
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

                string jsFunction = "SNCVisualizzaReport('rptPianoInvestimentiBeneficiario', 2, '" + parametri + "');";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunction, true);
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        protected void btnAllegati_Click(object sender, EventArgs e)
        {
            Redirect(PATH_PPAGAMENTO + "FirmaRichiesta.aspx");
        }

        protected void btnSpese_Click(object sender, EventArgs e)
        {
            Redirect(PATH_PPAGAMENTO + "SpeseSostenute.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["id_integrazione_domanda"] = null;
            Redirect(PATH_PPAGAMENTO + "IntegrazioniDomandaPagamento.aspx");
        }

        void dgIntegrazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_DataRichiesta = 1,
                col_TipoIntegrazione = 2,
                col_CompletataIntegrazione = 3,
                col_DataRilascioBeneficiario = 4,
                col_CompletataBeneficiario = 5,
                col_DatiGiustificativo = 6,
                col_DatiPagamento = 7,
                col_Apri = 8;

            var dgi = e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var d = (IntegrazioneSingolaDiDomanda)dgi.DataItem;

                if (d.SingolaIntegrazioneCompletataIstruttore != null && d.SingolaIntegrazioneCompletataIstruttore == true)
                    dgi.Cells[col_CompletataIntegrazione].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_CompletataIntegrazione].Text = "<div class=\"negativo\">NO</div>";

                if (d.SingolaIntegrazioneCompletataBeneficiario != null && d.SingolaIntegrazioneCompletataBeneficiario == true)
                    dgi.Cells[col_CompletataBeneficiario].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_CompletataBeneficiario].Text = "<div class=\"negativo\">NO</div>";

                if ((d.DescrizioneTipoIntegrazione != null)
                    && (d.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo") || d.DescrizioneTipoIntegrazione.Equals("Spese sostenute pagamento")))
                {
                    if (d.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo"))
                    {
                        var giustificativo = new GiustificativiCollectionProvider().GetById(d.IdGiustificativo);
                        dgi.Cells[col_DatiGiustificativo].Text = "<b>Numero:</b> " + giustificativo.Numero + "<br /><b>Data:</b> " + giustificativo.Data + "<br /><b>Ragione sociale:</b> " + giustificativo.DescrizioneFornitore + "<br /><b>Oggetto:</b> " + giustificativo.Descrizione;
                        dgi.Cells[col_DatiPagamento].Text = "";
                    }
                    else
                    {
                        var spesa = new SpeseSostenuteCollectionProvider().GetById(d.IdSpesa);
                        dgi.Cells[col_DatiGiustificativo].Text = "<b>Numero:</b> " + spesa.Numero + "<br /><b>Data:</b> " + spesa.Data + "<br /><b>Ragione sociale:</b> " + spesa.DescrizioneFornitore + "<br /><b>Oggetto:</b> " + spesa.Descrizione;
                        dgi.Cells[col_DatiPagamento].Text = "<b>Tipo:</b> " + spesa.TipoPagamento + "<br /><b>Estremi:</b> " + spesa.Estremi;
                    }
                }
                else
                {
                    dgi.Cells[col_DatiGiustificativo].Text = "";
                    dgi.Cells[col_DatiPagamento].Text = "";
                }

                if (integrazione_singola_selezionata != null && d.IdSingolaIntegrazione == integrazione_singola_selezionata.IdSingolaIntegrazione)
                    dgi.Cells[col_Apri].Text = dgi.Cells[col_Apri].Text.Replace("Apri", "Torna elenco");
            }
        }
    }
}