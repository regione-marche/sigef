using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using RnaManager;
using SiarBLL;
using SiarLibrary;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaPianoInvestimentiRettificaSaldo : SiarLibrary.Web.IstruttoriaPagamentoPage
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

        private bool  nascondiPinv = false;

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
            col_PercRendicontazione = 11;
            //col_Disavanzo = 12,
            //col_DisavanzoContributo = 13,
            //col_ContributoExtra = 14,
            //col_RimanenzaDaAssegnare = 15,
            //col_PercRendicontazioneAmmissibile = 16,
            //col_Integrazione = 17;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            loadIntestazione();

            imgMostraPiano.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            
            prichiesti_provider = new SiarBLL.PagamentiRichiestiCollectionProvider(investimenti_provider.DbProviderObj);
            prichiesti_fem_provider = new SiarBLL.PagamentiRichiestiFemCollectionProvider(investimenti_provider.DbProviderObj);
            tipo_investimenti = new SiarBLL.BandoTipoInvestimentiCollectionProvider().GetTipoInvestimentiProgetto(Progetto.IdBando, true);

            domanda_pagamento_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
            domanda_esportazione_provider = new SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider();
            bando_tipo_investimenti = new SiarBLL.BandoTipoInvestimentiCollectionProvider();
            progetto_provider = new SiarBLL.ProgettoCollectionProvider();
            gestione_recupero_anticipo = false;
            anticipo_rimasto = importo_max = quota_max = importo_parziale_max = ammontare_anticipo = 0;

            ucFirmaDocumento.DocumentoFirmatoEvent = btnFirmaPost_Click;

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
            if (new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0)
            {
                if(DomandaPagamento.SegnaturaApprovazione == null)
                {
                    btnFirma.Enabled = true;
                    btnElimina.Enabled = true;
                }
                    
                else
                {
                    btnFirma.Enabled = false;
                    btnElimina.Enabled = false;
                    btnElimina.Visible = false;
                }
            }
            else
            {
                btnFirma.Enabled = false;
                btnElimina.Enabled = false;
            }
                

            base.OnPreRender(e);
        }

        public void loadIntestazione()
        {
            lblTipoPagamento.Text = DomandaPagamento.Descrizione;
            lblStatoPagamento.Text = (DomandaPagamento.SegnaturaApprovazione == null ? "Provvisoria" : "Rilasciata");
            lblOperatore.Text = DomandaPagamento.Istruttore;
            lblNumero.Text = Progetto.IdProgetto;
            lblStato.Text = Progetto.Stato;
            SiarLibrary.Impresa _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
            if (_impresa != null)
            {
                lblCodiceFiscale.Text = _impresa.CodiceFiscale;
                lblRagioneSociale.Text = _impresa.RagioneSociale;
            }
            SiarLibrary.ProgettoStoricoCollection ps = new SiarBLL.ProgettoStoricoCollectionProvider().Find(Progetto.IdProgetto, "L", null);
            if (ps.Count > 0) ucSNCVPPDomanda.Segnatura = ps[0].Segnatura;
            if (DomandaPagamento.SegnaturaApprovazione == null)
                ucSNCVPPagamento.Enabled = false;
            else
                ucSNCVPPagamento.Segnatura = DomandaPagamento.SegnaturaApprovazione;
            ucVRPDomandaAttuale.ReportName = "rptModelloDomanda" + new SiarBLL.ModelloDomandaCollectionProvider().Find(null, Progetto.IdBando, null)[0].IdDomanda;
            ucVRPDomandaAttuale.ReportParameters = "ID_Domanda=" + Progetto.IdProgetto;
            
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
                    //if (pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                    //{
                    //    dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pagamenti[0].ContributoDisavanzoCostiAmmessi);
                    //    pag_inv_disavanzo_assengato += pagamenti[0].ContributoDisavanzoCostiAmmessi;
                    //}
                    //else
                    //    dgi.Cells[col_ContributoExtra].Text = "0,00";
                }
                //else
                //    dgi.Cells[col_ContributoExtra].Text = "0,00";

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
                //dgi.Cells[col_PercRendicontazioneAmmissibile].Text = string.Format("{0:N12}", quota_completamento_ammesso);

                // importo pagamenti richiesti sarebbe il totale dei pagamenti richiesti finora, compreso il corrente, per l'investimento 
                // se questo valore è maggiore del costo dell'investimento significa che ho un disavanzo e posso andarlo a spalmare su  
                // altri investimenti. Quindi lo mostro in griglia 
                //if (spese_ammesse > costo_investimento)
                //{
                //    decimal disavanzo = 0;
                //    decimal disavanzo_contributo = 0;
                //    // se il disavanzo è minore del 110% vuol dire che è nella soglia del 10% quindi lo calcolo come differenza 
                //    if (quota_completamento_ammesso <= 110)
                //        disavanzo = spese_ammesse - costo_investimento;
                //    // altrimenti lo calcolo come massimo 10% del costo dell'investimento 
                //    else
                //        disavanzo = costo_investimento * 10 / 100;

                //    disavanzo_contributo = disavanzo * f.QuotaContributoRichiesto / 100;

                //    dgi.Cells[col_Disavanzo].Text = string.Format("{0:c}", disavanzo);
                //    dgi.Cells[col_Disavanzo].ForeColor = System.Drawing.Color.Green;
                //    dgi.Cells[col_DisavanzoContributo].Text = string.Format("{0:c}", disavanzo_contributo);
                //    dgi.Cells[col_DisavanzoContributo].ForeColor = System.Drawing.Color.Green;
                //    // questa è la somma totale dei disavanzi che così calcolata rientra sempre nel 10% del totale 
                //    decimal contributoDisavanzoCostiAmmessi = 0;
                //    if (pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                //        decimal.TryParse(pagamenti[0].ContributoDisavanzoCostiAmmessi, out contributoDisavanzoCostiAmmessi);
                //    dgi.Cells[col_RimanenzaDaAssegnare].Text = string.Format("{0:c}", disavanzo_contributo - contributoDisavanzoCostiAmmessi);
                //    dgi.Cells[col_RimanenzaDaAssegnare].ForeColor = System.Drawing.Color.Green;

                //    pag_inv_disavanzo_totale += disavanzo;
                //    pag_inv_disavanzo_totale_contributo += disavanzo_contributo;

                //}
                //else if (spese_ammesse < costo_investimento)
                //{
                //    decimal disavanzo = 0;
                //    decimal disavanzo_contributo = 0;
                //    // se il disavanzo è minore del 110% vuol dire che è nella soglia del 10% quindi lo calcolo come differenza 
                //    if (quota_completamento_ammesso >= 90)
                //        disavanzo = -(costo_investimento - spese_ammesse);
                //    // altrimenti lo calcolo come massimo 10% del costo dell'investimento 
                //    else
                //        disavanzo = -costo_investimento * 10 / 100;

                //    disavanzo_contributo = disavanzo * f.QuotaContributoRichiesto / 100;

                //    dgi.Cells[col_Disavanzo].Text = string.Format("{0:c}", disavanzo);
                //    dgi.Cells[col_Disavanzo].ForeColor = System.Drawing.Color.Red;
                //    dgi.Cells[col_DisavanzoContributo].Text = string.Format("{0:c}", disavanzo_contributo);
                //    dgi.Cells[col_DisavanzoContributo].ForeColor = System.Drawing.Color.Red;
                //    // questa è la somma totale dei disavanzi che così calcolata rientra sempre nel 10% del totale 
                //    decimal contributoDisavanzoCostiAmmessi = 0;
                //    if (pagamenti.Count > 0 && pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                //        decimal.TryParse(pagamenti[0].ContributoDisavanzoCostiAmmessi, out contributoDisavanzoCostiAmmessi);
                //    dgi.Cells[col_RimanenzaDaAssegnare].Text = string.Format("{0:c}", disavanzo_contributo + contributoDisavanzoCostiAmmessi);
                //    dgi.Cells[col_RimanenzaDaAssegnare].ForeColor = System.Drawing.Color.Red;

                //    pag_inv_disavanzo_totale += disavanzo;
                //    pag_inv_disavanzo_totale_contributo += disavanzo_contributo;
                //}
                //else
                //{
                //    dgi.Cells[col_Disavanzo].Text = string.Format("{0:c}", 0);
                //    dgi.Cells[col_DisavanzoContributo].Text = string.Format("{0:c}", 0);
                //}
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
                if (contributo_calcolato != null && contributo_calcolato < contributo_investimenti)
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
                                dgi.Cells[col_ContributoPagAmmissibile].Text = "*** " + String.Format("{0:c}", contributo_rimanenza);
                            else
                                dgi.Cells[col_ContributoPagAmmissibile].Text = String.Format("{0:c}", pag_inv_contributo_ammesso);
                        }
                        else
                        {
                            if (contributo_rimanenza < pag_inv_contributo_ammesso)
                                dgi.Cells[col_ContributoPagAmmissibile].Text = "** " + String.Format("{0:c}", contributo_rimanenza);
                            else
                                dgi.Cells[col_ContributoPagAmmissibile].Text = String.Format("{0:c}", pag_inv_contributo_ammesso);
                        }


                    }
                    else
                    {
                        dgi.Cells[col_ContributoPagAmmissibile].Text = String.Format("{0:c}", pag_inv_contributo_ammesso);
                        
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
                dgi.Cells[col_ImportoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_importo_ammesso);
                //dgi.Cells[col_ContributoPagAmmissibile].Text = string.Format("{0:c}", pag_inv_contributo_ammesso); 
                //dgi.Cells[col_ContributoExtra].Text = string.Format("{0:c}", pag_inv_disavanzo_assengato); 
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

        protected void btnFirma_Click(object sender, EventArgs e)
        {

            domanda_pagamento_provider.DeterminaImportoErogabileDomandaPagamento(DomandaPagamento,true, Operatore);
            ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, DomandaPagamento.IdDomandaPagamento);
        }

        protected void btnFirmaPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                SiarLibrary.Impresa imp = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);

                SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(Bando.CodEnte);
                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                documento_interno.setDocumento("istruttoria_rettifica_saldo_domanda_"
                      + Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
                string oggetto = "Istruttoria ULTERIORI CONTRIBUTI per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                        + "\n Partita iva/Codice fiscale: " + imp.Cuaa 
                        + "\n Ragione sociale: " + imp.RagioneSociale
                        + "\n N° Domanda: " + Progetto.IdProgetto;
                string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                SiarLibrary.VstatiProceduraliCollection stati = new SiarBLL.VstatiProceduraliCollectionProvider().
                    Find(null, DomandaPagamento.CodFase, null/*Progetto.Ordine*/);
                if (stati.Count == 0) throw new Exception("si è verificato un errore sul server. Impossibile continuare");
                if (DomandaPagamento.SegnaturaApprovazione == null)
                {    
                        DomandaPagamento.Approvata = true;
                        DomandaPagamento.SegnaturaApprovazione = identificativo_paleo.Replace("ID:", "").Trim();
                        DomandaPagamento.Segnatura = identificativo_paleo.Replace("ID:", "").Trim();
                        DomandaPagamento.CfIstruttore = Operatore.Utente.CfUtente;
                        DomandaPagamento.DataApprovazione = DateTime.Now;
                        PagamentoProvider.Save(DomandaPagamento);
                    
                }

                btnFirma.Enabled = false;
                ShowMessage("Istruttoria domanda di concessione ulteriori contributi firmata e protocollata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }

        SiarBLL.DomandaDiPagamentoCollectionProvider dom_prov = new SiarBLL.DomandaDiPagamentoCollectionProvider();

        protected void btnEliminaRettifica_Click(object sender, EventArgs e)
        {
            try
            {
                //Session["evita_controllo_date_sessione"] = "true";
                dom_prov.DbProviderObj.BeginTran();

                SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider esp_prov = new DomandaDiPagamentoEsportazioneCollectionProvider(dom_prov.DbProviderObj);
                SiarBLL.PagamentiRichiestiCollectionProvider rich_prov = new SiarBLL.PagamentiRichiestiCollectionProvider(dom_prov.DbProviderObj);
                SiarBLL.PagamentiBeneficiarioCollectionProvider ben_prov = new SiarBLL.PagamentiBeneficiarioCollectionProvider(dom_prov.DbProviderObj);


                SiarLibrary.PagamentiRichiestiCollection pag_rich_col = rich_prov.Find(null, null, Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
                foreach(SiarLibrary.PagamentiRichiesti r in pag_rich_col)
                {
                    SiarLibrary.PagamentiBeneficiarioCollection pag_ben_coll = ben_prov.Find(r.IdPagamentoRichiesto, null, Progetto.IdProgetto, null, null, null);
                    foreach(SiarLibrary.PagamentiBeneficiario b in pag_ben_coll)
                    {
                        ben_prov.Delete(b);
                    }
                    rich_prov.Delete(r);
                }
                
                SiarLibrary.DomandaDiPagamentoEsportazioneCollection esp_coll = esp_prov.Find(DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto, null);
                foreach(SiarLibrary.DomandaDiPagamentoEsportazione esp in esp_coll)
                {
                    esp_prov.Delete(esp);
                }
                
                SiarLibrary.DomandaDiPagamento ddp = dom_prov.GetById(DomandaPagamento.IdDomandaPagamento);
                dom_prov.Delete(DomandaPagamento);
                dom_prov.DbProviderObj.Commit();

                //Response.Redirect(PATH_PPAGAMENTO+ "GestioneLavori.aspx",  false);
            }
            catch (Exception ex)
            { 
                dom_prov.DbProviderObj.Rollback();
                ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); 
            }
            finally
            {
                Session["domanda_pagamento"] = null;
                ((SiarLibrary.Web.PrivatePage)Page).Redirect("../PPagamento/GestioneLavori.aspx?iddom="+Progetto.IdProgetto.ToString());
            }
        }
    }
}