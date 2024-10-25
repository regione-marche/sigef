using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using SiarLibrary.Extensions;
using System.Collections.Generic;
using SiarLibrary;
using SiarBLL;
using System.Web;



namespace web.CONTROLS
{
    public partial class PianoInvestimentiAggregazioneDomandaIstruttoria : System.Web.UI.UserControl
    {
        public SiarLibrary.Operatore Operatore { get { return ((SiarLibrary.Web.PrivatePage)Page).Operatore; } }
        public bool AbilitaModifica { get { return ((SiarLibrary.Web.PrivatePage)Page).AbilitaModifica; } }

        public SiarLibrary.Progetto Progetto
        {
            get
            {
                SiarLibrary.Progetto p = null;
                int id_progetto;
                if (int.TryParse(Request.QueryString["iddom"], out id_progetto)) p = ProgettoProvider.GetById(id_progetto);
                else if (Session["_progetto"] != null) p = (SiarLibrary.Progetto)Session["_progetto"];
                return p;
            }
            set { Session["_progetto"] = value; }
        }

        public SiarLibrary.Varianti Variante
        {
            get
            {
                SiarLibrary.Varianti v = null;
                int id_variante;
                if (int.TryParse(Request.QueryString["idvar"], out id_variante)) v = new SiarBLL.VariantiCollectionProvider().GetById(id_variante);
                else if (Session["_variante"] != null) v = (SiarLibrary.Varianti)Session["_variante"];
                return v;
            }
            set { Session["_variante"] = value; }
        }

        //public SiarLibrary.DomandaDiPagamento DomandaDiPagamento
        //{
        //    get
        //    {
        //        SiarLibrary.DomandaDiPagamento d = null;
        //        int id_domanda;
        //        if (int.TryParse(Request.QueryString["idpag"], out id_domanda)) d = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(id_domanda);
        //        else if (Session["_domandaPagamento"] != null) d = (SiarLibrary.DomandaDiPagamento)Session["_domandaPagamento"];
        //        return d;
        //    }
        //    set { Session["_domandaPagamento"] = value; }
        //}

        private SiarLibrary.DomandaDiPagamento DomandaDiPagamento
        {
            get { return ((SiarLibrary.Web.IstruttoriaPagamentoPage)Page).DomandaPagamento; }
        }


        private SiarBLL.ProgettoCollectionProvider _progettoProvider;
        public SiarBLL.ProgettoCollectionProvider ProgettoProvider
        {
            get
            {
                if (_progettoProvider == null) _progettoProvider = new SiarBLL.ProgettoCollectionProvider();
                return _progettoProvider;
            }
            set { _progettoProvider = value; }
        }

        private string _codiceFase;
        public string CodiceFase
        {
            get { return _codiceFase; }
            set { _codiceFase = value; }
        }

        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.PianoInvestimentiCollection investimenti;
        string PATH_IMAGES = VirtualPathUtility.ToAbsolute("~/Images/");
        protected void Page_Load(object sender, EventArgs e)
        {
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Progetto != null)
            {
                string nascodiDiv = "";
                nascodiDiv = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_NascondiPInv(Progetto.IdBando);
                if (nascodiDiv != "True")
                {

                    investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(Progetto.IdProgetto, DomandaDiPagamento.IdDomandaPagamento);
                    SiarBLL.VpianoInvestimentiAggregazioneDettaglioCollectionProvider aggr_prov = new SiarBLL.VpianoInvestimentiAggregazioneDettaglioCollectionProvider();
                    SiarLibrary.VpianoInvestimentiAggregazioneDettaglioCollection aggr_coll = new VpianoInvestimentiAggregazioneDettaglioCollection();
                    aggr_coll = aggr_prov.GetPianoInvestimentiAggregazioneDomanda(Progetto.IdProgetto, DomandaDiPagamento.IdDomandaPagamento);
                    if (aggr_coll.Count == 0)
                        dBoxAggregazione.Visible = false;
                    else
                    {
                           
                            //imgMostraAggregazioni.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
                            dBoxAggregazione.Visible = true;
                            dgAggregazione.DataSource = aggr_coll;
                            dgAggregazione.ItemDataBound += new DataGridItemEventHandler(dgAggregazione_ItemDataBound);
                            dgAggregazione.DataBind();
                        
                    }
                    ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("espandiAggregazionePost();");
                }
            }
            base.OnPreRender(e);
        }


        decimal TotContributo = 0, TotCosto = 0, TotCostoRichiesto = 0, TotContributoRichiesto = 0,
            TotCostoAmmesso = 0, TotContributoAmmesso = 0, TotDisdavanzo = 0;
        void dgAggregazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.VpianoInvestimentiAggregazioneDettaglio pr = (SiarLibrary.VpianoInvestimentiAggregazioneDettaglio)e.Item.DataItem;
                e.Item.Attributes.Add("id", "dgTrProgr" + pr.Id);
                e.Item.Attributes.Add("PathLabel", pr.Pathlabel);
                e.Item.Attributes.Add("ElemEspanso", "false");
                if (pr.Livello > 1) e.Item.Style["display"] = "none";
                string testo_cella = "<table style='width100%;padding-left:10px' cellpadding=0 cellspacing=0><tr>";
                decimal quota = 0;
                if (pr.Costo != 0)
                    quota = pr.Contributo * 100 / pr.Costo;
                if (pr.Livello == 1)
                {
                    testo_cella += "<td style='width:700px;border:0;padding-right:8px;cursor:pointer;' ><span style='font-weight:bold;' >" + pr.Descrizioneriga + "</span></td></tr></table>";
                    e.Item.Attributes.Add("onclick", "espandiAggregazione('" + pr.Pathlabel + "');");
                    e.Item.Style["cursor"] = "pointer";
                    TotContributo += pr.Contributo;
                    TotCosto += pr.Costo;
                    TotCostoRichiesto += pr.ImpRichiestosum;
                    TotContributoRichiesto += pr.ContrRichiestosum;
                    TotCostoAmmesso += pr.ImpAmmessosum;
                    TotContributoAmmesso += pr.ContrAmmessosum;
                    e.Item.Cells[10].Text = "";
                    e.Item.Style["background-color"] = " rgb(208, 208, 208)";
                }
                else
                {
                    e.Item.Style["background-color"] = "rgb(224, 224, 224)";
                    SiarLibrary.PianoInvestimenti inv = investimenti_provider.GetById(pr.Id);
                    string descrizione = "<b>Codifica:</b> " + inv.CodificaInvestimento + "<br /><b>Dettaglio:</b> " + inv.DettaglioInvestimenti
                    + "<br /><b>Descrizione:</b> " + inv.Descrizione;

                    if ((new SiarBLL.BandoProgrammazioneCollectionProvider().Find(Progetto.IdBando, null, null, null)).Count > 1)
                    {
                        SiarLibrary.Zprogrammazione intervento = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(inv.IdProgrammazione);
                        descrizione += "<br /><b> Intervento: </b > " + intervento.Codice + " " + intervento.Descrizione ;
                    }

                    //Personalizzazione bando 6.2
                    if (Progetto.IdBando == 39)
                    {
                        string linea_intervento = "";
                        linea_intervento = investimenti_provider.GetLineaInterventoInvestimento(inv.IdInvestimento);
                        if (linea_intervento != null && linea_intervento != "")
                            descrizione += "<br /><b>" + linea_intervento + "</b>";
                    }

                    testo_cella += "<td style='width:30px;border:0'></td><td style='width:700px;border:0;padding-right:8px'>" + descrizione + "</td></tr></table>";
                    string pathImages = "../../images/lente.png";
                    e.Item.Cells[14].Text = "<a href='IstruttoriaInvestimento.aspx?idinv=" + pr.Id.ToString() + "' ><img src='" + pathImages + "' style='width:24px;height:24px;cursor:pointer' alt='Visualizza investimento'/></a>";
                    SiarLibrary.PagamentiRichiestiCollection pagamenti_richiesti = new PagamentiRichiestiCollectionProvider().Find(null, null, pr.IdProgetto, DomandaDiPagamento.IdDomandaPagamento); ;
                    SiarLibrary.PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(pr.Id);

                    decimal importo_pagamento_richiesti = 0;
                    for (int i = 0; i < investimenti.Count; i++)
                    {
                        if (investimenti[i].IdInvestimento == pr.Id)
                            decimal.TryParse(investimenti[i].AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                    }
                    //importo_pagamento_richiesti += pr.ImpRichiestosum;




                    decimal quota_completamento = 0, quota_completamento_ammesso = 0, costo_investimento = pr.Costo, spese_ammesse = 0;

                    //// importo_pagamento_richiesti rappresenta il totale dei pagamenti già richiesti
                    //decimal.TryParse(f.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                    //SiarLibrary.PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(f.IdInvestimento);
                    if (pagamenti.Count > 0)
                    {
                        // devo aggiungere il pagamento richiesto attuale non contato dalla query
                        importo_pagamento_richiesti += pagamenti[0].ImportoRichiesto;

                        if (pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                        {
                            e.Item.Cells[11].Text = string.Format("{0:c}", pagamenti[0].ContributoDisavanzoCostiAmmessi);
                            TotDisdavanzo += pagamenti[0].ContributoDisavanzoCostiAmmessi;
                        }
                        else
                            e.Item.Cells[11].Text = "0,00";
                    }
                    else
                        e.Item.Cells[11].Text = "0,00";
                    if (costo_investimento > 0 && pagamenti.Count > 0)
                    {
                        quota_completamento = Math.Round(100 * importo_pagamento_richiesti / costo_investimento, 2, MidpointRounding.AwayFromZero);
                        decimal importoAmmessoInvestimento = 0;
                        if (pagamenti[0].ImportoAmmesso != null)
                            importoAmmessoInvestimento = pagamenti[0].ImportoAmmesso;
                        quota_completamento_ammesso = Math.Round(100 * (importoAmmessoInvestimento + (importo_pagamento_richiesti - pagamenti[0].ImportoRichiesto)) / costo_investimento, 2, MidpointRounding.AwayFromZero);
                        spese_ammesse = importoAmmessoInvestimento + (importo_pagamento_richiesti - pagamenti[0].ImportoRichiesto);
                    }
                    //costo_investimenti += costo_investimento;
                    //contributo_investimenti += f.ContributoRichiesto;
                    //dgi.Cells[4].Text = string.Format("{0:c}", costo_investimento);
                    e.Item.Cells[8].Text = string.Format("{0:N}", quota_completamento);
                    e.Item.Cells[13].Text = string.Format("{0:N}", quota_completamento_ammesso);

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

                        disavanzo_contributo = disavanzo * inv.QuotaContributoRichiesto / 100;

                        e.Item.Cells[9].Text = string.Format("{0:c}", disavanzo);
                        e.Item.Cells[9].ForeColor = System.Drawing.Color.Green;
                        e.Item.Cells[10].Text = string.Format("{0:c}", disavanzo_contributo);
                        e.Item.Cells[10].ForeColor = System.Drawing.Color.Green;
                        // questa è la somma totale dei disavanzi che così calcolata rientra sempre nel 10% del totale
                        decimal contributoDisavanzoCostiAmmessi = 0;
                        if (pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                            decimal.TryParse(pagamenti[0].ContributoDisavanzoCostiAmmessi, out contributoDisavanzoCostiAmmessi);
                        e.Item.Cells[12].Text = string.Format("{0:c}", disavanzo_contributo - contributoDisavanzoCostiAmmessi);
                        e.Item.Cells[12].ForeColor = System.Drawing.Color.Green;



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

                        disavanzo_contributo = disavanzo * inv.QuotaContributoRichiesto / 100;

                        e.Item.Cells[9].Text = string.Format("{0:c}", disavanzo);
                        e.Item.Cells[9].ForeColor = System.Drawing.Color.Red;
                        e.Item.Cells[10].Text = string.Format("{0:c}", disavanzo_contributo);
                        e.Item.Cells[10].ForeColor = System.Drawing.Color.Red;
                        // questa è la somma totale dei disavanzi che così calcolata rientra sempre nel 10% del totale
                        decimal contributoDisavanzoCostiAmmessi = 0;
                        if (pagamenti.Count > 0 && pagamenti[0].ContributoDisavanzoCostiAmmessi != null)
                            decimal.TryParse(pagamenti[0].ContributoDisavanzoCostiAmmessi, out contributoDisavanzoCostiAmmessi);
                        e.Item.Cells[12].Text = string.Format("{0:c}", disavanzo_contributo + contributoDisavanzoCostiAmmessi);
                        e.Item.Cells[12].ForeColor = System.Drawing.Color.Red;


                    }
                    else
                    {
                        e.Item.Cells[9].Text = string.Format("{0:c}", 0);
                        e.Item.Cells[10].Text = string.Format("{0:c}", 0);
                    }

                }

                e.Item.Cells[3].Text = String.Format("{0:N}", Math.Round(quota, 2, MidpointRounding.AwayFromZero));

                e.Item.Cells[0].Text = testo_cella;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[1].Text = string.Format("{0:c}", TotCosto);

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
                    if (contributo_quota_fissa < TotContributo)
                        e.Item.Cells[2].Text = string.Format("{0:c}", contributo_quota_fissa);
                    else
                        e.Item.Cells[2].Text = string.Format("{0:c}", TotContributo);
                }
                if (contributo_calcolato != null && contributo_calcolato < TotContributo && !importoFisso)
                {
                    e.Item.Cells[2].Text = "** " + String.Format("{0:c}", contributo_calcolato.Value);
                    tbLegendaInvestimenti.Visible = true;
                }
                else if (importoFisso && contributo_quota_fissa < TotContributo)
                {
                    e.Item.Cells[2].Text = "*** " + String.Format("{0:c}", contributo_quota_fissa);
                    tbLegendaInvestimenti.Visible = true;
                }
                else
                {
                    e.Item.Cells[2].Text = string.Format("{0:c}", TotContributo);
                }

                //controllo se il progetto ha un massimale di contributo, e al massimale le altre domande di pagamento gia istruite
                if (contributo_calcolato != null && contributo_calcolato < TotContributo)
                {
                    //calcolo il contributo gia erogato nelle precedenti domande di pagamento 
                    decimal contributo_erogato = 0;
                    SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider dom_pag_esp = new SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider();
                    SiarLibrary.DomandaDiPagamentoCollection dom_coll = new SiarBLL.DomandaDiPagamentoCollectionProvider().Find(null, null, Progetto.IdProgetto, null);
                    foreach (SiarLibrary.DomandaDiPagamento dp in dom_coll)
                    {
                        if (dp.IdDomandaPagamento < DomandaDiPagamento.IdDomandaPagamento &&
                            dp.Approvata == true && dp.SegnaturaApprovazione != null && dp.SegnaturaApprovazione != "")
                        {
                            SiarLibrary.DomandaDiPagamentoEsportazione esp_coll = dom_pag_esp.GetById(dp.IdDomandaPagamento, Progetto.IdProgetto);
                            contributo_erogato += esp_coll.ImportoAmmesso;
                        }
                    }
                    decimal contributo_rimanenza = contributo_calcolato - contributo_erogato;
                    if (contributo_rimanenza < TotContributoRichiesto)
                    {
                        if (importoFisso)
                            e.Item.Cells[5].Text = "*** " + String.Format("{0:c}", contributo_rimanenza);
                        else
                            e.Item.Cells[5].Text = "** " + String.Format("{0:c}", contributo_rimanenza);
                    }
                    else
                        e.Item.Cells[5].Text = String.Format("{0:c}", TotContributoRichiesto);


                    if (contributo_rimanenza < (TotContributoAmmesso + TotDisdavanzo))
                    {
                        if (contributo_rimanenza < TotContributoAmmesso)
                        {
                            if (importoFisso)
                                e.Item.Cells[7].Text = "*** " + String.Format("{0:c}", contributo_rimanenza);
                            else
                                e.Item.Cells[7].Text = "** " + String.Format("{0:c}", contributo_rimanenza);
                            if (TotDisdavanzo > 0)
                            {
                                if (importoFisso)
                                    e.Item.Cells[11].Text = "*** " + string.Format("{0:c}", 0);
                                else
                                    e.Item.Cells[11].Text = "** " + string.Format("{0:c}", 0);
                            }
                            else
                                e.Item.Cells[11].Text = string.Format("{0:c}", TotDisdavanzo);
                        }
                        else
                        {
                            e.Item.Cells[7].Text = String.Format("{0:c}", TotContributoAmmesso);
                            if (contributo_rimanenza - TotContributoAmmesso < TotDisdavanzo)
                            {
                                if (importoFisso)
                                    e.Item.Cells[11].Text = "*** " + string.Format("{0:c}", contributo_rimanenza - TotContributoAmmesso);
                                else
                                    e.Item.Cells[11].Text = "** " + string.Format("{0:c}", contributo_rimanenza - TotContributoAmmesso);
                            }
                            else
                                e.Item.Cells[11].Text = string.Format("{0:c}", TotDisdavanzo);
                        }


                    }
                    else
                    {
                        e.Item.Cells[7].Text = String.Format("{0:c}", TotContributoAmmesso);
                        e.Item.Cells[11].Text = string.Format("{0:c}", TotDisdavanzo);
                    }
                }
                else
                {
                    e.Item.Cells[5].Text = string.Format("{0:c}", TotContributoRichiesto);
                    e.Item.Cells[7].Text = string.Format("{0:c}", TotContributoAmmesso);
                    e.Item.Cells[11].Text = string.Format("{0:c}", TotDisdavanzo);
                }

                e.Item.Cells[4].Text = string.Format("{0:c}", TotCostoRichiesto);
                //e.Item.Cells[5].Text = string.Format("{0:c}", TotContributoRichiesto);
                e.Item.Cells[6].Text = string.Format("{0:c}", TotCostoAmmesso);
                //e.Item.Cells[7].Text = string.Format("{0:c}", TotContributoAmmesso);
                //e.Item.Cells[11].Text = string.Format("{0:c}", TotDisdavanzo);



            }
        }
    }
}