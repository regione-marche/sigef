using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using RnaManager;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.NullTypes;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaPianoInvestimenti : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarLibrary.PianoInvestimentiCollection investimenti;
        SiarLibrary.PagamentiRichiestiCollection pagamenti_richiesti;
        SiarBLL.PagamentiRichiestiCollectionProvider prichiesti_provider;
        SiarBLL.PagamentiRichiestiFemCollectionProvider prichiesti_fem_provider;
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
        SiarLibrary.PianoInvestimenti premiocc = null;
        SiarLibrary.BandoTipoInvestimentiCollection tipo_investimenti = null;

        decimal pag_inv_disavanzo_totale = 0, pag_inv_disavanzo_totale_contributo = 0;

        //Gestione recupero parziale anticipo 
        SiarBLL.DomandaDiPagamentoCollectionProvider domanda_pagamento_provider = null;
        SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider domanda_esportazione_provider = null;
        SiarBLL.BandoTipoInvestimentiCollectionProvider bando_tipo_investimenti = null;
        SiarBLL.ProgettoCollectionProvider progetto_provider = null;
        bool gestione_recupero_anticipo;
        decimal anticipo_rimasto, importo_max, quota_max, importo_parziale_max, ammontare_anticipo;

        private bool strumenti_finanziari = false, nascondiPinv = false;

        int idDomandaPagamentoAnticipo = 0;

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
            col_ImportoPagAmmissibile = 9,
            col_ContributoPagAmmissibile = 10,
            col_PercRendicontazione = 11,
            col_Disavanzo = 12,
            col_DisavanzoContributo = 13,
            col_ContributoExtra = 14,
            col_RimanenzaDaAssegnare = 15,
            col_PercRendicontazioneAmmissibile = 16,
            col_Integrazione = 17;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ucVisure.Progetto = Progetto;
            imgMostraPiano.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            if (Progetto.IdProgIntegrato == null) btnDettaglioMisura.Visible = false;
            prichiesti_provider = new SiarBLL.PagamentiRichiestiCollectionProvider(investimenti_provider.DbProviderObj);
            prichiesti_fem_provider = new SiarBLL.PagamentiRichiestiFemCollectionProvider(investimenti_provider.DbProviderObj);
            tipo_investimenti = new SiarBLL.BandoTipoInvestimentiCollectionProvider().GetTipoInvestimentiProgetto(Progetto.IdBando, true);

            domanda_pagamento_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
            domanda_esportazione_provider = new SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider();
            bando_tipo_investimenti = new SiarBLL.BandoTipoInvestimentiCollectionProvider();
            progetto_provider = new SiarBLL.ProgettoCollectionProvider();
            gestione_recupero_anticipo = false;
            anticipo_rimasto = importo_max = quota_max = importo_parziale_max = ammontare_anticipo = 0;

            if (DomandaPagamento.TpAppaltoStrumentiFinanziari)
                strumenti_finanziari = true;

            string nascodiDiv = "";
            nascodiDiv = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_NascondiPInv(Bando.IdBando);
            if (nascodiDiv == "True")
            {
                PianoInvestimentiAggregazioneDomandaIstruttoria.Visible = false;
                PianoInvestimentiCodificaDomandaIstruttoria.Visible = false;
                PianoInvestimentiInterventoDomandaIstruttoria.Visible = false;
            }
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
            if (investimenti.Count > 0)
            {
                tableInvestimenti.Visible = true;
                //inv_supp = investimenti.FiltroTipoInvestimento(1); 
                dgInvestimenti.DataSource = investimenti;
                if (investimenti.Count == 0) dgInvestimenti.Titolo = "Nessun elemento trovato.";
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
            //    if (inv_supp.Count == 0) dgBrevetti.Titolo = "Nessun elemento trovato."; 
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
            //    if (inv_supp.Count == 0) dgFidejussione.Titolo = "Nessun elemento trovato."; 
            //    else dgFidejussione.ItemDataBound += new DataGridItemEventHandler(dgFidejussione_ItemDataBound); 
            //    dgFidejussione.DataBind(); 
            //} 

            ////mutuo 
            //if (tipo_investimenti.FiltroCodiceTipo(2).Count > 0) 
            //{ 
            //    tableMutuo.Visible = true; 
            //    inv_supp = investimenti.FiltroTipoInvestimento(2); 
            //    dgMutuo.DataSource = inv_supp; 
            //    if (inv_supp.Count == 0) dgMutuo.Titolo = "Nessun elemento trovato."; 
            //    else dgMutuo.ItemDataBound += new DataGridItemEventHandler(dgMutuo_ItemDataBound); 
            //    dgMutuo.DataBind(); 
            //} 

            //// premio in conto capitale 
            //if (tipo_investimenti.FiltroCodiceTipo(3).Count > 0 && DomandaPagamento.CodTipo == "SLD") 
            //{ 
            //    tablePremio.Visible = true; 
            //    premiocc = investimenti_provider.CalcoloPremioSaldo(DomandaPagamento.IdDomandaPagamento, 1); 
            //    decimal anticipo_percepito = 0; 
            //    //calcolo l'anticipo erogato 
            //    SiarLibrary.DomandaDiPagamentoCollection anticipo = PagamentoProvider.Find(null, "ANT", Progetto.IdProgetto, null).FiltroApprovata(true); 
            //    if (anticipo.Count > 0) 
            //    { 
            //        SiarLibrary.AnticipiRichiestiCollection anticipi = new SiarBLL.AnticipiRichiestiCollectionProvider().Find(null, 
            //            anticipo[0].IdDomandaPagamento, Progetto.IdBando); 
            //        if (anticipi.Count > 0) anticipo_percepito = anticipi[0].ContributoAmmesso; 
            //    } 
            //    txtPCCAmmontare.Text = premiocc != null ? premiocc.CostoInvestimento : 0; 
            //    txtPCCAnticipo.Text = anticipo_percepito.ToString(); 
            //    txtPCCRimanente.Text = (premiocc != null ? premiocc.CostoInvestimento - anticipo_percepito : 0).ToString(); 
            //    //foreach (SiarLibrary.BandoProgrammazione bp in disposizioni_attuative) 
            //    //{ 
            //    //    if (Progetto.IdProgetto == new SiarLibrary.NullTypes.IntNT(bp.AdditionalAttributes["IdProgetto"])) 
            //    //    { 
            //    //        txtPCCProgrammazione.Text = bp.Codice; 
            //    //        break; 
            //    //    } 
            //    //} 
            //} 
            imgRedStar.Src = Request.ApplicationPath + "/images/star_red.gif";
            bindTotali();

            VerificaGestioneParzialeAnticipo(DomandaPagamento);
            if (AbilitaModifica && gestione_recupero_anticipo && !DomandaPagamento.CodTipo.Equals("ANT"))
            {
                txtRecuperoAnticipo.ReadOnly = false;
                btnModificaRecuperoAnticipo.Enabled = true;
            }
            else
            {
                txtRecuperoAnticipo.ReadOnly = true;
                btnModificaRecuperoAnticipo.Enabled = false;
            }

            var responsabili_list = new SiarBLL.BandoResponsabiliCollectionProvider()
                .Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, 1)
                .ToArrayList<SiarLibrary.BandoResponsabili>();
            if (responsabili_list.Count == 0 || !AbilitaModifica)
                btnAccorpamentoInvestimenti.Disabled = true;

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
                if (f.IdPrioritaSettoriale != null) dgi.Cells[col_Numero].Text = "<img src='" + Request.ApplicationPath + "/images/star_red.gif'><br /><br />" + dgi.Cells[col_Numero].Text;
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
                    SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);
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

                if (f.NonCofinanziato) e.Item.Cells[5].Text = "(*)";
                decimal importo_pagamento_richiesti, quota_completamento = 0, quota_completamento_ammesso = 0, costo_investimento = f.CostoInvestimento.Value + (f.SpeseGenerali ?? 0), spese_ammesse = 0;

                decimal.TryParse(f.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);

                if (!strumenti_finanziari)
                {
                    // importo_pagamento_richiesti rappresenta il totale dei pagamenti già richiesti 
                    SiarLibrary.PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(f.IdInvestimento);
                    if (pagamenti.Count > 0)
                    {
                        // devo aggiungere il pagamento richiesto attuale non contato dalla query 
                        importo_pagamento_richiesti += pagamenti[0].ImportoRichiesto;
                        pag_inv_costo_richiesto += pagamenti[0].ImportoRichiesto;
                        pag_inv_contributo_richiesto += pagamenti[0].ContributoRichiesto;
                        dgi.Cells[col_ImportoPagRichiesto].Text = string.Format("{0:c}", pagamenti[0].ImportoRichiesto);
                        dgi.Cells[col_ContributoPagRichiesto].Text = string.Format("{0:c}", pagamenti[0].ContributoRichiesto);
                        dgi.Cells[col_ImportoPagAmmissibile].Text = string.Format("{0:c}", pagamenti[0].ImportoAmmesso);

                        // VERIFICARE SE DEVE ESSERE DIVERSO DA NULL??? 
                        if (pagamenti[0].ImportoAmmesso != null)
                            pag_inv_importo_ammesso += pagamenti[0].ImportoAmmesso;
                        if (pagamenti[0].ContributoAmmesso != null)
                        {
                            dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pagamenti[0].ContributoAmmesso);
                            pag_inv_contributo_ammesso += pagamenti[0].ContributoAmmesso;
                        }
                        if (pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                        {
                            dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pagamenti[0].ContributoDisavanzoCostiAmmessi);
                            pag_inv_disavanzo_assengato += pagamenti[0].ContributoDisavanzoCostiAmmessi;
                        }
                        else
                            dgi.Cells[col_ContributoExtra].Text = "0,00";
                    }
                    else
                        dgi.Cells[col_ContributoExtra].Text = "0,00";

                    if (costo_investimento > 0 && pagamenti.Count > 0)
                    {
                        quota_completamento = Math.Round(100 * importo_pagamento_richiesti / costo_investimento, 12, MidpointRounding.AwayFromZero);
                        decimal importoAmmessoInvestimento = 0;
                        if (pagamenti[0].ImportoAmmesso != null)
                            importoAmmessoInvestimento = pagamenti[0].ImportoAmmesso;
                        quota_completamento_ammesso = Math.Round(100 * (importoAmmessoInvestimento + (importo_pagamento_richiesti - pagamenti[0].ImportoRichiesto)) / costo_investimento, 12, MidpointRounding.AwayFromZero);
                        spese_ammesse = importoAmmessoInvestimento + (importo_pagamento_richiesti - pagamenti[0].ImportoRichiesto);
                    }

                    costo_investimenti += costo_investimento;
                    contributo_investimenti += f.ContributoRichiesto;
                    dgi.Cells[col_CostoTotInvestimento].Text = string.Format("{0:c}", costo_investimento);
                    dgi.Cells[col_PercRendicontazione].Text = string.Format("{0:N12}", quota_completamento);
                    dgi.Cells[col_PercRendicontazioneAmmissibile].Text = string.Format("{0:N12}", quota_completamento_ammesso);

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

                        dgi.Cells[col_Disavanzo].Text = string.Format("{0:c}", disavanzo);
                        dgi.Cells[col_Disavanzo].ForeColor = System.Drawing.Color.Green;
                        dgi.Cells[col_DisavanzoContributo].Text = string.Format("{0:c}", disavanzo_contributo);
                        dgi.Cells[col_DisavanzoContributo].ForeColor = System.Drawing.Color.Green;
                        // questa è la somma totale dei disavanzi che così calcolata rientra sempre nel 10% del totale 
                        decimal contributoDisavanzoCostiAmmessi = 0;
                        if (pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                            decimal.TryParse(pagamenti[0].ContributoDisavanzoCostiAmmessi, out contributoDisavanzoCostiAmmessi);
                        dgi.Cells[col_RimanenzaDaAssegnare].Text = string.Format("{0:c}", disavanzo_contributo - contributoDisavanzoCostiAmmessi);
                        dgi.Cells[col_RimanenzaDaAssegnare].ForeColor = System.Drawing.Color.Green;

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

                        dgi.Cells[col_Disavanzo].Text = string.Format("{0:c}", disavanzo);
                        dgi.Cells[col_Disavanzo].ForeColor = System.Drawing.Color.Red;
                        dgi.Cells[col_DisavanzoContributo].Text = string.Format("{0:c}", disavanzo_contributo);
                        dgi.Cells[col_DisavanzoContributo].ForeColor = System.Drawing.Color.Red;
                        // questa è la somma totale dei disavanzi che così calcolata rientra sempre nel 10% del totale 
                        decimal contributoDisavanzoCostiAmmessi = 0;
                        if (pagamenti.Count > 0 && pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                            decimal.TryParse(pagamenti[0].ContributoDisavanzoCostiAmmessi, out contributoDisavanzoCostiAmmessi);
                        dgi.Cells[col_RimanenzaDaAssegnare].Text = string.Format("{0:c}", disavanzo_contributo + contributoDisavanzoCostiAmmessi);
                        dgi.Cells[col_RimanenzaDaAssegnare].ForeColor = System.Drawing.Color.Red;

                        pag_inv_disavanzo_totale += disavanzo;
                        pag_inv_disavanzo_totale_contributo += disavanzo_contributo;
                    }
                    else
                    {
                        dgi.Cells[col_Disavanzo].Text = string.Format("{0:c}", 0);
                        dgi.Cells[col_DisavanzoContributo].Text = string.Format("{0:c}", 0);
                    }
                }
                else
                {
                    dgi.Cells[col_SettoreProduttivo].Text = dgi.Cells[col_SettoreProduttivo].Text.Replace("IstruttoriaInvestimento.aspx", "IstruttoriaInvestimentoFem.aspx");

                    var pagamenti_fem = prichiesti_fem_provider.Find(null, null, f.IdInvestimento, f.IdProgetto, DomandaPagamento.IdDomandaPagamento, null);

                    if (pagamenti_fem.Count > 0)
                    {
                        var pagamenti_fem_list = pagamenti_fem.ToArrayList<SiarLibrary.PagamentiRichiestiFem>();

                        // devo aggiungere il pagamento richiesto attuale non contato dalla query 
                        var importo_richiesto = pagamenti_fem_list.Sum<SiarLibrary.PagamentiRichiestiFem>(p => p.ImportoRichiesto ?? 0.00);
                        var importo_ammesso = pagamenti_fem_list.Sum<SiarLibrary.PagamentiRichiestiFem>(p => p.ImportoAmmesso ?? 0.00);

                        importo_pagamento_richiesti += importo_richiesto; // pagamenti_richiesti_fem[0].ImportoRichiesto; 
                        pag_inv_costo_richiesto += importo_richiesto; // pagamenti[0].ImportoRichiesto; 
                        pag_inv_contributo_richiesto += importo_richiesto; // pagamenti[0].ContributoRichiesto; 
                        dgi.Cells[col_ImportoPagRichiesto].Text = string.Format("{0:c}", importo_richiesto); //string.Format("{0:c}", pagamenti[0].ImportoRichiesto); 
                        dgi.Cells[col_ContributoPagRichiesto].Text = string.Format("{0:c}", importo_richiesto); //string.Format("{0:c}", pagamenti[0].ContributoRichiesto); 
                        dgi.Cells[col_ImportoPagAmmissibile].Text = string.Format("{0:c}", importo_ammesso); //string.Format("{0:c}", pagamenti[0].ImportoAmmesso); 

                        pag_inv_importo_ammesso += importo_ammesso;
                        pag_inv_contributo_ammesso += importo_ammesso;
                        dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", importo_ammesso); // string.Format("{0:c}", pagamenti[0].ContributoAmmesso); 

                        dgi.Cells[col_ContributoExtra].Text = "0,00";

                        if (costo_investimento > 0)
                        {
                            quota_completamento = Math.Round(100 * importo_pagamento_richiesti / costo_investimento, 12, MidpointRounding.AwayFromZero);
                            decimal importoAmmessoInvestimento = 0;
                            importoAmmessoInvestimento = importo_ammesso;
                            quota_completamento_ammesso = Math.Round(100 * (importoAmmessoInvestimento + (importo_pagamento_richiesti - importo_richiesto)) / costo_investimento, 12, MidpointRounding.AwayFromZero);
                            spese_ammesse = importoAmmessoInvestimento + (importo_pagamento_richiesti - importo_richiesto);
                        }
                    }
                    else
                        dgi.Cells[col_ContributoExtra].Text = "0,00";


                    costo_investimenti += costo_investimento;
                    contributo_investimenti += f.ContributoRichiesto;
                    dgi.Cells[col_CostoTotInvestimento].Text = string.Format("{0:c}", costo_investimento);
                    dgi.Cells[col_PercRendicontazione].Text = string.Format("{0:N12}", quota_completamento);
                    dgi.Cells[col_PercRendicontazioneAmmissibile].Text = string.Format("{0:N12}", quota_completamento_ammesso);

                    dgi.Cells[col_Disavanzo].Text = string.Format("{0:c}", 0);
                    dgi.Cells[col_DisavanzoContributo].Text = string.Format("{0:c}", 0);
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
                {
                    contributo_calcolato = contributo_quota_fissa;
                    if (contributo_investimenti > contributo_quota_fissa)
                        dgi.Cells[col_ContributoAmmesso].Text = String.Format("{0:c}", contributo_quota_fissa);
                    else
                        dgi.Cells[col_ContributoAmmesso].Text = String.Format("{0:c}", contributo_investimenti);
                }
                if (contributo_calcolato != null && contributo_calcolato < contributo_investimenti && !importoFisso)
                    dgi.Cells[col_ContributoAmmesso].Text = "** " + String.Format("{0:c}", contributo_calcolato.Value);
                else if (importoFisso && contributo_investimenti > contributo_quota_fissa)
                    dgi.Cells[col_ContributoAmmesso].Text = "*** " + String.Format("{0:c}", contributo_quota_fissa);
                else dgi.Cells[col_ContributoAmmesso].Text = string.Format("{0:c}", contributo_investimenti);

                //controllo se il progetto ha un massimale di contributo, e al massimale le altre domande di pagamento gia istruite 
                //qui devo tenere conto del disavanzo già dato                
                if (contributo_calcolato != null && contributo_calcolato < (contributo_investimenti + pag_inv_disavanzo_assengato))
                {
                    //calcolo il contributo gia erogato nelle precedenti domande di pagamento  
                    decimal contributo_erogato = 0;
                    SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider dom_pag_esp = new SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider();
                    SiarLibrary.DomandaDiPagamentoCollection dom_coll = new SiarBLL.DomandaDiPagamentoCollectionProvider().Find(null, null, Progetto.IdProgetto, null);
                    foreach (SiarLibrary.DomandaDiPagamento dp in dom_coll)
                    {
                        if (dp.IdDomandaPagamento < DomandaPagamento.IdDomandaPagamento &&
                            dp.Approvata == true && dp.SegnaturaApprovazione != null && dp.SegnaturaApprovazione != "")
                        {
                            SiarLibrary.DomandaDiPagamentoEsportazione esp_coll = dom_pag_esp.GetById(dp.IdDomandaPagamento, Progetto.IdProgetto);
                            contributo_erogato += esp_coll.ImportoAmmesso;
                        }
                    }
                    decimal contributo_rimanenza = contributo_calcolato - contributo_erogato;
                    if (contributo_rimanenza < pag_inv_contributo_richiesto)
                        dgi.Cells[col_ContributoPagRichiesto].Text = "** " + String.Format("{0:c}", contributo_rimanenza);
                    else
                        dgi.Cells[col_ContributoPagRichiesto].Text = String.Format("{0:c}", pag_inv_contributo_richiesto);


                    if (contributo_rimanenza < (pag_inv_contributo_ammesso + pag_inv_disavanzo_assengato))
                    {
                        if (importoFisso)
                        {
                            if (contributo_rimanenza < pag_inv_contributo_ammesso)
                            {
                                dgi.Cells[col_ContributoPagAmmissibile].Text = "*** " + String.Format("{0:c}", contributo_rimanenza);
                                if (pag_inv_disavanzo_assengato > 0)
                                    dgi.Cells[col_ContributoExtra].Text = "** " + string.Format("{0:c}", 0);
                                else
                                    dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato);
                            }
                            else
                            {
                                dgi.Cells[col_ContributoPagAmmissibile].Text = String.Format("{0:c}", pag_inv_contributo_ammesso);
                                if (contributo_rimanenza - pag_inv_contributo_ammesso < pag_inv_disavanzo_assengato)
                                    dgi.Cells[col_ContributoExtra].Text = "*** " + string.Format("{0:c}", contributo_rimanenza - pag_inv_contributo_ammesso);
                                else
                                    dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato);
                            }
                        }
                        else
                        {
                            if (contributo_rimanenza < pag_inv_contributo_ammesso)
                            {
                                dgi.Cells[col_ContributoPagAmmissibile].Text = "** " + String.Format("{0:c}", contributo_rimanenza);
                                if (pag_inv_disavanzo_assengato > 0)
                                    dgi.Cells[col_ContributoExtra].Text = "** " + string.Format("{0:c}", 0);
                                else
                                    dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato);
                            }
                            else
                            {
                                dgi.Cells[col_ContributoPagAmmissibile].Text = String.Format("{0:c}", pag_inv_contributo_ammesso);
                                if (contributo_rimanenza - pag_inv_contributo_ammesso < pag_inv_disavanzo_assengato)
                                    dgi.Cells[col_ContributoExtra].Text = "** " + string.Format("{0:c}", contributo_rimanenza - pag_inv_contributo_ammesso);
                                else
                                    dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato);
                            }
                        }


                    }
                    else
                    {
                        dgi.Cells[col_ContributoPagAmmissibile].Text = String.Format("{0:c}", pag_inv_contributo_ammesso);
                        dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato);
                    }
                }
                else
                {
                    dgi.Cells[col_ContributoPagRichiesto].Text = string.Format("{0:c}", pag_inv_contributo_richiesto);
                    dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_contributo_ammesso);
                    dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato);
                }


                dgi.Cells[col_CostoTotInvestimento].Text = string.Format("{0:c}", costo_investimenti);
                dgi.Cells[col_PercContributoAmmesso].Text = string.Format("{0:N}", Math.Round(quota, 2, MidpointRounding.AwayFromZero));
                dgi.Cells[col_ImportoPagRichiesto].Text = string.Format("{0:c}", pag_inv_costo_richiesto);
                //dgi.Cells[col_ContributoPagRichiesto].Text = string.Format("{0:c}", pag_inv_contributo_richiesto); 
                dgi.Cells[col_ImportoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_importo_ammesso);
                //dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_contributo_ammesso); 
                //dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato); 
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
            bool valori_computo_metrico_inseriti = true;

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

            SiarLibrary.DbProvider db = investimenti_provider.DbProviderObj;
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
            txtErogatoQuota.Text = string.Format("{0:N12}", Math.Round(100 * contributo_erogato / totale_contributo_progetto, 12, MidpointRounding.AwayFromZero));
            txtErogatoDisavanzo.Text = string.Format("{0:N}", Math.Round(getTotalePagamentiRiassegnati(), 2, MidpointRounding.AwayFromZero));
            txtTotaleContributo.Text = totale_contributo_progetto;
            txtTotaleInvestimenti.Text = totale_costo_investimenti;

            if (!strumenti_finanziari)
            {
                foreach (SiarLibrary.PagamentiRichiesti pr in pagamenti_richiesti)
                {
                    totale_contributo_richiesto += pr.ContributoRichiesto.Value;
                    totale_importo_richiesto += pr.ImportoRichiesto.Value;
                    // if (pr.ContributoAmmesso != null) totale_contributo_ammissibile += pr.ContributoAmmesso.Value; 
                    if (pr.ImportoAmmesso != null)
                    {
                        totale_importo_ammesso += pr.ImportoAmmesso.Value;
                    }
                    //controllo il computometrico 
                    SiarLibrary.PianoInvestimenti i = investimenti.CollectionGetById(pr.IdInvestimento);
                    if (i.Mobile != null && !i.Mobile && pr.ImportoComputoMetricoAmmesso == null && valori_computo_metrico_inseriti)
                    {
                        valori_computo_metrico_inseriti = false;
                    }
                }
            }
            else
            {
                var pag_ric_fem_list = new SiarBLL.PagamentiRichiestiFemCollectionProvider()
                    .Find(null, null, null, DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null)
                    .ToArrayList<SiarLibrary.PagamentiRichiestiFem>();

                totale_importo_richiesto = pag_ric_fem_list.Sum(p => p.ImportoRichiesto ?? 0);
                totale_contributo_richiesto = totale_importo_richiesto;
                totale_importo_ammesso = pag_ric_fem_list.Sum(p => p.ImportoAmmesso ?? 0);
                totale_contributo_ammesso = totale_importo_ammesso;
                totale_contributo_ammissibile = totale_importo_ammesso;
            }
            if (premiocc != null)
            {
                SiarLibrary.PianoInvestimenti premio_richiesto = investimenti_provider.CalcoloPremioSaldo(DomandaPagamento.IdDomandaPagamento, 0);
                if (premio_richiesto != null && premio_richiesto.CostoInvestimento != null) // ammontare memorizzato sul costo  
                {
                    totale_contributo_richiesto += Math.Round(premio_richiesto.CostoInvestimento.Value, 2, MidpointRounding.AwayFromZero);
                }
            }
            txtTotaleImportoRichiesto.Text = totale_importo_richiesto;
            txtQuotaImportoRichiesta.Text = string.Format("{0:N12}", Math.Round(totale_importo_richiesto * 100 / totale_costo_investimenti, 12, MidpointRounding.AwayFromZero));
            txtTotaleContributoRichiesto.Text = totale_contributo_richiesto;
            txtQuotaContributoRichiesta.Text = string.Format("{0:N12}", Math.Round(totale_contributo_richiesto * 100 / totale_contributo_progetto, 12, MidpointRounding.AwayFromZero));
            txtTotaleImportoAmmesso.Text = totale_importo_ammesso;
            txtQuotaImportoAmmessa.Text = string.Format("{0:N12}", Math.Round(totale_importo_ammesso * 100 / totale_costo_investimenti, 12, MidpointRounding.AwayFromZero));

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
            txtQuotaContributoAmmessa.Text = string.Format("{0:N12}", Math.Round(totale_contributo_ammesso * 100 / totale_contributo_progetto, 12, MidpointRounding.AwayFromZero));
            txtImportoSanzione.Text = importo_sanzione;
            txtRecuperoAnticipo.Text = recupero_anticipo;

            // controllo massimali di pagamento 
            /*  commentata perche superflua 
            string errore = null; 
            if (!valori_computo_metrico_inseriti) errore = "Attenzione! E` obbligatorio inserire il valore del computo metrico per ognuno degli investimenti FISSI per cui si richiede il pagamento."; 
            else 
            { 
            * else errore = PagamentoProvider.ControlloMassimaliDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento); 
            } 
            ShowError(errore);*/

            //controllo se è stato superato il contributo concesso in graduatoria
            //per ora faccio un controllo "stupido" in base al contributo ammissibile, le sanzioni e il recupero anticipo
            if ((totale_contributo_ammissibile - importo_sanzione - recupero_anticipo) != totale_contributo_ammesso)
                divContributoAmmessoRidottoGradutatoria.Visible = true;
            else
                divContributoAmmessoRidottoGradutatoria.Visible = false;
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

        protected void VerificaGestioneParzialeAnticipo(SiarLibrary.DomandaDiPagamento domanda_di_pagamento)
        {
            try
            {
                var progetto = progetto_provider.GetById(domanda_di_pagamento.IdProgetto);
                var bandi_tipi_collection = bando_tipo_investimenti.Find(progetto.IdBando, 8, null);
                var listBandiTipi = bandi_tipi_collection.ToArrayList<SiarLibrary.BandoTipoInvestimenti>();

                if (bandi_tipi_collection.Count > 0)
                {
                    importo_max = listBandiTipi.Sum(b => b.ImportoMax ?? new decimal(0));
                    quota_max = listBandiTipi.Sum(b => b.QuotaMax ?? new decimal(0));

                    if (!(importo_max == 0 && quota_max == 0))
                    {
                        var domanda_anticipo_collection = domanda_pagamento_provider.Find(null, "ANT", progetto.IdProgetto, null);
                        var domanda_anticipo = domanda_anticipo_collection
                            .ToArrayList<DomandaDiPagamento>()
                            .Where(d => d.Annullata == false)
                            .FirstOrDefault();

                        if (domanda_anticipo != null)
                        {
                            idDomandaPagamentoAnticipo = domanda_anticipo.IdDomandaPagamento;

                            var esportazione_collection = domanda_esportazione_provider.Find(domanda_anticipo.IdDomandaPagamento, progetto.IdProgetto, null);
                            var domanda_esportazione = esportazione_collection.Count > 0 ? esportazione_collection[0] : null;

                            if (domanda_esportazione != null)
                            {
                                //ammontare_anticipo += listDomandeEsportazione 
                                //            .Where(d => d.CodTipo == "ANT") 
                                //            .Sum(d => d.ImportoAmmesso ?? new decimal(0)); 

                                ammontare_anticipo = domanda_esportazione.ImportoAmmesso;
                                importo_parziale_max = ammontare_anticipo * quota_max / 100; //traduco la % in importo 
                                gestione_recupero_anticipo = true;
                            }
                            else
                                btnModificaRecuperoAnticipo.ToolTip = "Non è possibile modificare l'importo perchè non è stato trovato dalla domanda.";
                        }
                        else
                            btnModificaRecuperoAnticipo.ToolTip = "Non è possibile modificare l'importo perchè non è stata presentata la richiesta di anticipo.";
                    }
                    else
                        btnModificaRecuperoAnticipo.ToolTip = "Non è possibile modificare l'importo perchè il bando non ha l'importo massimo e la quota massima per la gestione del recupero.";
                }
                else
                    btnModificaRecuperoAnticipo.ToolTip = "Non è possibile modificare l'importo perchè tale funzionalità non è prevista da bando.";
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        protected void btnModificaRecuperoAnticipo_Click(object sender, EventArgs e)
        {
            try
            {
                var domanda_pagamento_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                var domanda_di_pagamento = domanda_pagamento_provider.GetById(DomandaPagamento.IdDomandaPagamento);

                VerificaGestioneParzialeAnticipo(domanda_di_pagamento);
                if (gestione_recupero_anticipo)
                {
                    decimal recupero_anticipo_nuovo = decimal.Parse(txtRecuperoAnticipo.Text);

                    if (recupero_anticipo_nuovo >= 0)
                        ModificaRecuperoAnticipo(domanda_di_pagamento, recupero_anticipo_nuovo);
                    else
                        ShowMessage("Non è possibile recuperare un importo negativo.");
                }
                else
                    ShowError("Non è possibile modificare il recupero parziale.");
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        protected void ModificaRecuperoAnticipo(SiarLibrary.DomandaDiPagamento domanda_di_pagamento, decimal recupero_anticipo_nuovo)
        {
            try
            {
                VerificaGestioneParzialeAnticipo(domanda_di_pagamento);
                if (gestione_recupero_anticipo)
                {
                    var progetto = progetto_provider.GetById(domanda_di_pagamento.IdProgetto);
                    var esportazione_collection = domanda_esportazione_provider.Find(domanda_di_pagamento.IdDomandaPagamento, progetto.IdProgetto, null);
                    var domanda_esportazione = esportazione_collection.Count > 0 ? esportazione_collection[0] : null;

                    decimal anticipo_recuperato = 0, anticipo_da_recuperare = 0;

                    if (!domanda_di_pagamento.CodTipo.Equals("ANT") && domanda_esportazione != null)
                    {
                        //Calcolo il recupero dell'anticipo 
                        var domande_pagamento_collection = domanda_pagamento_provider.Find(null, null, domanda_di_pagamento.IdProgetto, null);

                        var listDomandePagamento = domande_pagamento_collection.ToArrayList<SiarLibrary.DomandaDiPagamento>();
                        var listDomandePagamentoPrecedenti = listDomandePagamento
                            .Where(d => d.Approvata == true)
                            .Where(d => d.Annullata == false)
                            .Where(d => d.IdDomandaPagamento < domanda_di_pagamento.IdDomandaPagamento);

                        foreach (SiarLibrary.DomandaDiPagamento domanda_pagamento_ciclo in listDomandePagamentoPrecedenti)
                        {
                            var domande_esportazione_collection = domanda_esportazione_provider.Find(domanda_pagamento_ciclo.IdDomandaPagamento, domanda_pagamento_ciclo.IdProgetto, null);
                            var listDomandeEsportazione = domande_esportazione_collection.ToArrayList<SiarLibrary.DomandaDiPagamentoEsportazione>();
                            anticipo_recuperato += listDomandeEsportazione.Sum(d => d.ImportoRecuperoAnticipo);
                        }

                        DecimalNT spese_disposizione_irregolarita = 0.00;

                        if (idDomandaPagamentoAnticipo != null 
                            && idDomandaPagamentoAnticipo != 0)
                        {
                            var pagamentiIrregolaritaList = new PagamentiIrregolaritaCollectionProvider()
                                .Find(null, null, idDomandaPagamentoAnticipo, null, null, null)
                                .ToArrayList<PagamentiIrregolarita>();
                                //.Sum(s => s.ImportoIrregolareConcesso);
                            
                            spese_disposizione_irregolarita = pagamentiIrregolaritaList.Count() > 0
                                ? pagamentiIrregolaritaList.Sum(s => s.ImportoIrregolareConcesso)
                                : 0;
                        }

                        if (ammontare_anticipo > 0)
                        {
                            anticipo_da_recuperare = ammontare_anticipo - anticipo_recuperato - spese_disposizione_irregolarita;

                            if (anticipo_da_recuperare < 0)
                                anticipo_da_recuperare = 0;

                            if (anticipo_da_recuperare > 0 && domanda_di_pagamento.CodTipo.Equals("SAL"))
                            {
                                if (importo_max > 0 && anticipo_da_recuperare > importo_max)
                                    anticipo_da_recuperare = importo_max;

                                if (importo_parziale_max > 0 && anticipo_da_recuperare > importo_parziale_max)
                                    anticipo_da_recuperare = importo_parziale_max;
                            }

                            if (anticipo_da_recuperare <= 0)
                                ShowError("E' già stato recuperato tutto l'anticipo o è recuperabile solo in fase di saldo.");
                            else
                            {
                                if (anticipo_da_recuperare < recupero_anticipo_nuovo)
                                {
                                    txtRecuperoAnticipo.ToolTip = "Massimo importo recuperabile dall'anticipo = " + anticipo_da_recuperare.ToString() + " €.";
                                    ShowError("Non è possibile recuperare più di " + anticipo_da_recuperare.ToString() + " € dall'anticipo.");
                                }
                                else
                                {
                                    anticipo_rimasto = anticipo_da_recuperare - recupero_anticipo_nuovo;

                                    domanda_esportazione.ImportoRecuperoAnticipo = recupero_anticipo_nuovo;
                                    domanda_esportazione.ImportoAmmesso = domanda_esportazione.ImportoAmmissibile - domanda_esportazione.ImportoSanzione - recupero_anticipo_nuovo;
                                    if (domanda_esportazione.ImportoAmmesso < 0)
                                        domanda_esportazione.ImportoAmmesso = 0;

                                    domanda_esportazione_provider.Save(domanda_esportazione);

                                    ModificaRecuperoAnticipoDomandePagamentoSuccessive(domanda_di_pagamento, anticipo_rimasto);

                                    ShowMessage("Recupero anticipo aggiornato.");
                                }
                            }
                        }
                        else
                            ShowError("Non è presente nessun anticipo o l'importo dell'anticipo è a 0.");
                    }
                    else
                        ShowError("La domanda di contributo è un anticipo o non si sono verificati i requisiti.");
                }
                else
                    ShowError("Non è possibile modificare il recupero parziale.");
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        protected void ModificaRecuperoAnticipoDomandePagamentoSuccessive(SiarLibrary.DomandaDiPagamento domanda_di_pagamento, decimal anticipo_rimasto)
        {
            try
            {
                decimal anticipo_nuovo = 0;
                var domande_pagamento_collection = domanda_pagamento_provider.Find(null, null, domanda_di_pagamento.IdProgetto, null);

                var listDomandePagamento = domande_pagamento_collection.ToArrayList<SiarLibrary.DomandaDiPagamento>();
                var listDomandePagamentoSuccessive = listDomandePagamento
                    .Where(d => d.Approvata == true)
                    .Where(d => d.Annullata == false)
                    .Where(d => d.IdDomandaPagamento > domanda_di_pagamento.IdDomandaPagamento)
                    .OrderBy(d => d.IdDomandaPagamento);

                if (listDomandePagamentoSuccessive.Count() > 0)
                {
                    foreach (SiarLibrary.DomandaDiPagamento dom in listDomandePagamentoSuccessive)
                    {
                        var esportazione_collection = domanda_esportazione_provider.Find(dom.IdDomandaPagamento, dom.IdProgetto, null);
                        var domanda_esportazione = esportazione_collection.Count > 0 ? esportazione_collection[0] : null;

                        if (domanda_esportazione != null && domanda_esportazione.ImportoRecuperoAnticipo != null)
                        {
                            anticipo_nuovo += domanda_esportazione.ImportoRecuperoAnticipo;
                            if (anticipo_rimasto > importo_parziale_max)
                            {
                                anticipo_nuovo = importo_parziale_max;
                                anticipo_rimasto -= importo_parziale_max;
                            }
                            else
                            {
                                anticipo_nuovo = anticipo_rimasto;
                                anticipo_rimasto = 0;
                            }

                            domanda_esportazione.ImportoRecuperoAnticipo = anticipo_nuovo;
                            domanda_esportazione.ImportoAmmesso = domanda_esportazione.ImportoAmmissibile - domanda_esportazione.ImportoSanzione - anticipo_nuovo;

                            if (domanda_esportazione.ImportoAmmesso < 0)
                                domanda_esportazione.ImportoAmmesso = 0;

                            domanda_esportazione_provider.Save(domanda_esportazione);
                        }
                    }
                }
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }
    }
}