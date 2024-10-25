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

using System.Linq;

namespace web.CONTROLS
{
    public partial class PianoInvestimentiCodificaDomanda : SiarLibrary.Web.SigefUserControl
    {
        public SiarLibrary.Operatore Operatore { get { return ((SiarLibrary.Web.PrivatePage)Page).Operatore; } }
        public bool AbilitaModifica { get { return ((SiarLibrary.Web.PrivatePage)Page).AbilitaModifica; } }
        private bool strumenti_finanziari = false;

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
            get { return ((SiarLibrary.Web.DomandaPagamentoPage)Page).DomandaPagamento; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);

            var utAppalto = new BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(Progetto.IdBando);

            if (utAppalto != null && utAppalto == "Strumenti finanziari")

                strumenti_finanziari = true;
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
                    SiarBLL.VpianoInvestimentiCodificaCollectionProvider cod_prov = new SiarBLL.VpianoInvestimentiCodificaCollectionProvider();

                    SiarLibrary.VpianoInvestimentiCodificaCollection cod_coll = new VpianoInvestimentiCodificaCollection();

                    cod_coll = cod_prov.GetPianoInvestimentiCodificaDomanda(Progetto.IdProgetto, DomandaDiPagamento.IdDomandaPagamento);
                    if (cod_coll.Count == 0)
                        dBoxCodifica.Visible = false;
                    else
                    {
                        //imgMostraCodifica.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
                        dBoxCodifica.Visible = true;
                        dgCodifica.DataSource = cod_coll;
                        dgCodifica.ItemDataBound += new DataGridItemEventHandler(dgCodifica_ItemDataBound);
                        dgCodifica.DataBind();
                    }
                    ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("espandiCodificaPost();");

                }
            }
            base.OnPreRender(e);
        }


        decimal TotContributo = 0, TotCosto = 0, TotCostoRichiesto = 0, TotContributoRichiesto = 0, TotCostoAmmesso = 0, TotContributoAmmesso = 0;
        void dgCodifica_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                VpianoInvestimentiCodifica pr = (VpianoInvestimentiCodifica)e.Item.DataItem;
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

                    testo_cella += "<td style='width:700px;border:0;padding-right:8px;cursor:pointer;'><span style='font-weight:bold;' >" + pr.Descrizioneriga + "</span></td></tr></table>";

                    e.Item.Attributes.Add("onclick", "espandiCodifica('" + pr.Pathlabel + "');");

                    e.Item.Style["cursor"] = "pointer";



                    if (!strumenti_finanziari)

                    {

                        TotCostoRichiesto += pr.ImpRichiestosum;

                        TotContributoRichiesto += pr.ContrRichiestosum;

                        TotCostoAmmesso += pr.ImpAmmessosum;

                        TotContributoAmmesso += pr.ContrAmmessosum;

                    }

                    else

                    {

                        var inv_codifica_list = new PianoInvestimentiCollectionProvider()

                            .Find(null, Progetto.IdProgetto, null, pr.Id, null, null, null)

                            .ToArrayList<SiarLibrary.PianoInvestimenti>();

                        var pag_ric_fem_list = new PagamentiRichiestiFemCollectionProvider()

                            .Find(null, null, null, Progetto.IdProgetto, DomandaDiPagamento.IdDomandaPagamento, null)

                            .ToArrayList<PagamentiRichiestiFem>();



                        var pag_domanda_list = (from i in inv_codifica_list

                                                join pag in pag_ric_fem_list on i.IdInvestimento equals pag.IdInvestimento

                                                select pag);



                        var richiesto = pag_domanda_list.Sum(i => i.ImportoRichiesto ?? 0);

                        var ammesso = pag_domanda_list.Sum(i => i.ImportoAmmesso ?? 0);



                        e.Item.Cells[4].Text = string.Format("{0:c}", richiesto); // richiesto + " €";

                        e.Item.Cells[5].Text = string.Format("{0:c}", richiesto); //richiesto + " €";

                        e.Item.Cells[6].Text = string.Format("{0:c}", ammesso); //ammesso + " €";

                        e.Item.Cells[6].Text = string.Format("{0:c}", ammesso); //ammesso + " €";



                        TotCostoRichiesto += richiesto;

                        TotContributoRichiesto += richiesto;

                        TotCostoAmmesso += ammesso;

                        TotContributoAmmesso += ammesso;

                    }



                    TotContributo += pr.Contributo;

                    TotCosto += pr.Costo;



                    e.Item.Cells[10].Text = "";

                    e.Item.Style["background-color"] = " rgb(208, 208, 208)";

                }
                else

                {

                    e.Item.Style["background-color"] = "rgb(224, 224, 224)";

                    SiarLibrary.PianoInvestimenti inv = investimenti_provider.GetById(pr.Id);

                    string descrizione = "<b>Dettaglio:</b> " + inv.DettaglioInvestimenti
                    + "<br /><b>Descrizione:</b> " + inv.Descrizione;
                    
                    if ((new SiarBLL.BandoProgrammazioneCollectionProvider().Find(Progetto.IdBando, null, null, null)).Count > 1)
                    {
                        SiarLibrary.Zprogrammazione intervento = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(inv.IdProgrammazione);
                        descrizione += "<br /><b> Intervento: </b > " + intervento.Codice + " " + intervento.Descrizione;
                    }

                    SiarLibrary.Bando bando_ = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);

                    if (bando_.Aggregazione)

                    {

                        if (inv.IdImpresaAggregazione != null)

                        {

                            SiarLibrary.Impresa impresa_aggr = new SiarBLL.ImpresaCollectionProvider().GetById(inv.IdImpresaAggregazione);

                            descrizione += "<br />Impresa: <b>" + impresa_aggr.RagioneSociale + " - " + impresa_aggr.CodiceFiscale + "</b>";

                            if (impresa_aggr.CodAteco2007 != null && impresa_aggr.CodAteco2007 != "")

                                descrizione += " - Ateco: " + impresa_aggr.CodAteco2007;

                        }

                    }

                    else

                    {

                        string[] Aggregazione = new string[2];

                        Aggregazione = investimenti_provider.GetImpresaAggregazioneInvestimento(inv.IdInvestimento);

                        if (Aggregazione[0] != null && Aggregazione[1] != null && Aggregazione[0] != "" && Aggregazione[1] != "")

                        {

                            descrizione += "<br />Impresa: <b>" + Aggregazione[0] + " - " + Aggregazione[1] + "</b>";

                            SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);

                            if (impresa.CodAteco2007 != null && impresa.CodAteco2007 != "")

                                descrizione += " - Ateco: " + impresa.CodAteco2007;

                        }

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



                    PagamentiRichiestiCollection pagamenti_richiesti = new PagamentiRichiestiCollectionProvider().Find(null, null, pr.IdProgetto, DomandaDiPagamento.IdDomandaPagamento); ;

                    PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(pr.Id);



                    bool in_integrazione = false;

                    if (pagamenti.Count > 0)

                    {

                        var pbeneficiario_attuali = new SiarBLL.PagamentiBeneficiarioCollectionProvider().Find(pagamenti[0].IdPagamentoRichiesto, null, null, null, null, null);

                        foreach (PagamentiBeneficiario pag_ben in pbeneficiario_attuali)

                        {

                            var giustificativo = new SiarBLL.GiustificativiCollectionProvider().GetById(pag_ben.IdGiustificativo);

                            if (giustificativo != null && giustificativo.InIntegrazione != null && giustificativo.InIntegrazione)

                            {

                                in_integrazione = true;

                                break;

                            }

                        }

                    }

                    if (!in_integrazione)

                        e.Item.Cells[10].Text = "";



                    string page;



                    if (!strumenti_finanziari) 

                    { 

                        decimal importo_pagamento_richiesti = 0;

                        for (int i = 0; i < investimenti.Count; i++)

                        {

                            if (investimenti[i].IdInvestimento == pr.Id)

                                decimal.TryParse(investimenti[i].AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);

                        }

                        importo_pagamento_richiesti += pr.ImpRichiestosum;



                        if (pr.Costo > 0)

                            e.Item.Cells[8].Text = String.Format("{0:N}", Math.Round(100 * importo_pagamento_richiesti / pr.Costo, 2, MidpointRounding.AwayFromZero));



                        page = "PagamentoInvestimento.aspx";

                    }

                    else

                    {

                        var pag_ric_fem_list = new PagamentiRichiestiFemCollectionProvider()

                            .Find(null, null, inv.IdInvestimento, Progetto.IdProgetto, DomandaDiPagamento.IdDomandaPagamento, null)

                            .ToArrayList<PagamentiRichiestiFem>();



                        var richiesto = pag_ric_fem_list.Sum(i => i.ImportoRichiesto ?? 0);

                        var ammesso = pag_ric_fem_list.Sum(i => i.ImportoAmmesso ?? 0);



                        e.Item.Cells[4].Text = richiesto + " €";

                        e.Item.Cells[5].Text = richiesto + " €";

                        e.Item.Cells[6].Text = ammesso + " €";

                        e.Item.Cells[7].Text = ammesso + " €";



                        if (pr.Costo > 0)

                            e.Item.Cells[8].Text = String.Format("{0:N}", Math.Round(100 * richiesto / pr.Costo, 2, MidpointRounding.AwayFromZero));



                        page = "PagamentoInvestimentoFem.aspx";

                    }



                    e.Item.Cells[9].Text = "<a href='" + page + "?idinv=" + pr.Id.ToString() + "' ><img src='" + pathImages + "' style='width:24px;height:24px;cursor:pointer' alt='Visualizza investimento'/></a>";

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

                    {

                        if (TotContributo < contributo_quota_fissa)

                            contributo_quota_fissa = TotContributo;

                        else

                            contributo_quota_fissa = q.Quota;

                    }

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

                    e.Item.Cells[2].Text = string.Format("{0:c}", TotContributo);



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

                    if (!importoFisso)

                    {

                        if ((contributo_calcolato - contributo_erogato) < TotContributoRichiesto)

                            e.Item.Cells[5].Text = "** " + String.Format("{0:c}", contributo_calcolato - contributo_erogato);

                        else

                            e.Item.Cells[5].Text = String.Format("{0:c}", TotContributoRichiesto);

                        SiarLibrary.DomandaDiPagamentoEsportazione esp = null;

                        esp = dom_pag_esp.GetById(DomandaDiPagamento.IdDomandaPagamento, Progetto.IdProgetto);

                        if (esp != null)

                            e.Item.Cells[7].Text = "** " + string.Format("{0:c}", esp.ImportoAmmesso);

                        else

                            e.Item.Cells[7].Text = string.Format("{0:c}", TotContributoAmmesso);

                    }

                    else

                    {

                        if ((contributo_calcolato - contributo_erogato) < TotContributoRichiesto)

                            e.Item.Cells[5].Text = "*** " + String.Format("{0:c}", contributo_calcolato - contributo_erogato);

                        else

                            e.Item.Cells[5].Text = String.Format("{0:c}", TotContributoRichiesto);

                        SiarLibrary.DomandaDiPagamentoEsportazione esp = null;

                        esp = dom_pag_esp.GetById(DomandaDiPagamento.IdDomandaPagamento, Progetto.IdProgetto);

                        if (esp != null)

                            e.Item.Cells[7].Text = "*** " + string.Format("{0:c}", esp.ImportoAmmesso > contributo_calcolato ? contributo_calcolato : esp.ImportoAmmesso);

                        else

                            e.Item.Cells[7].Text = string.Format("{0:c}", TotContributoAmmesso);

                    }

                }

                else

                {

                    e.Item.Cells[5].Text = string.Format("{0:c}", TotContributoRichiesto);

                    e.Item.Cells[7].Text = string.Format("{0:c}", TotContributoAmmesso);

                }





                e.Item.Cells[4].Text = string.Format("{0:c}", TotCostoRichiesto);

                //e.Item.Cells[5].Text = string.Format("{0:c}", TotContributoRichiesto);

                e.Item.Cells[6].Text = string.Format("{0:c}", TotCostoAmmesso);

                //e.Item.Cells[7].Text = string.Format("{0:c}", TotContributoAmmesso);

            }

        }
    }
}