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
    public partial class PianoInvestimentiCodifica : SiarLibrary.Web.SigefUserControl
    {
        public SiarLibrary.Operatore Operatore { get { return ((SiarLibrary.Web.PrivatePage)Page).Operatore; } }
        public bool AbilitaModifica { get { return ((SiarLibrary.Web.PrivatePage)Page).AbilitaModifica; } }

        public int id_intervento  { get; set; } 

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
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Progetto != null)
            {
                string nascodiDiv = "";
                nascodiDiv = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_NascondiPInv(Progetto.IdBando);
                if (nascodiDiv != "True")
                {
                    SiarBLL.VpianoInvestimentiCodificaCollectionProvider cod_prov = new SiarBLL.VpianoInvestimentiCodificaCollectionProvider();
                    SiarLibrary.VpianoInvestimentiCodificaCollection cod_coll = cod_prov.GetPianoInvestimentiCodifica(Progetto.IdProgetto, CodiceFase);

                    if (CodiceFase == "PDOMANDA" || CodiceFase == "IDOMANDA")
                        cod_coll = cod_prov.GetPianoInvestimentiCodificaIntervento(Progetto.IdProgetto, CodiceFase, id_intervento);
                    else
                        cod_coll = cod_prov.GetPianoInvestimentiCodificaVarianteIntervento(Progetto.IdProgetto, CodiceFase, Variante.IdVariante, id_intervento);

                    if (cod_coll.Count == 0)
                        dBoxCodifica.Visible = false;
                    else
                    {

                        imgMostraCodifica.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
                        dBoxCodifica.Visible = true;
                        dgCodifica.DataSource = cod_coll;
                        dgCodifica.ItemDataBound += new DataGridItemEventHandler(dgCodifica_ItemDataBound);
                        dgCodifica.DataBind();
                    }
                    ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("espandiAggregazionePost();");
                }

            }
            base.OnPreRender(e);
        }


        decimal TotContributo = 0, TotCosto = 0;
        void dgCodifica_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.VpianoInvestimentiCodifica pr = (SiarLibrary.VpianoInvestimentiCodifica)e.Item.DataItem;
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
                    e.Item.Attributes.Add("onclick", "espandiCodifica('" + pr.Pathlabel + "');");
                    e.Item.Style["cursor"] = "pointer";
                    TotContributo += pr.Contributo;
                    TotCosto += pr.Costo;
                    e.Item.Style["background-color"] = " rgb(208, 208, 208)";
                }
                else
                {
                    SiarLibrary.PianoInvestimenti inv = investimenti_provider.GetById(pr.Id);
                    string codive_var = "";
                    if (_codiceFase.FindValueIn("PVARIANTE", "IVARIANTE") && inv.CodVariazione != null)
                    {
                        codive_var = " <b>(" + inv.CodVariazione + ")</b>";
                        switch (inv.CodVariazione)
                        {
                            case "A": for (int i = 0; i < 4; i++) { e.Item.Cells[i].Style.Add("text-decoration", "line-through"); e.Item.Cells[i].Style.Add("color", "black"); } break;
                            case "E": for (int i = 1; i < 4; i++) e.Item.Cells[i].Style.Add("color", "green"); break;
                            case "M": for (int i = 1; i < 4; i++) e.Item.Cells[i].Style.Add("color", "red"); break;
                            case "N": for (int i = 1; i < 4; i++) e.Item.Cells[i].Style.Add("color", "blue"); break;
                            case "V": for (int i = 1; i < 4; i++) e.Item.Cells[i].Style.Add("color", "FFA500"); break;
                        }
                    }
                    
                    string descrizione = "Dettaglio: <b>" + inv.DettaglioInvestimenti + "</b><br />Descrizione: <b>" + inv.Descrizione + "</b>";
                    
                    if((new SiarBLL.BandoProgrammazioneCollectionProvider().Find(Progetto.IdBando,null,null,null)).Count > 1 )
                    {
                        SiarLibrary.Zprogrammazione intervento = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(inv.IdProgrammazione);
                        descrizione += "<br /> Intervento: <b> " + intervento.Codice+" "+intervento.Descrizione + " </b> ";
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

                    testo_cella += "<td style='width:30px;border:0'>" + codive_var + "</td><td style='width:700px;border:0;padding-right:8px'>" + descrizione + "</td></tr></table>";
                    string pathImages = "../../images/lente.png";
                    if (CodiceFase.FindValueIn("PVARIANTE", "IVARIANTE"))
                        pathImages = "../../../images/lente.png";
                    e.Item.Cells[4].Text = "<a href='InvestimentiFondoPerduto.aspx?idpcurrent=" + pr.IdProgetto.ToString() + "&idinv=" + pr.Id.ToString() + "' ><img src='" + pathImages + "' style='width:24px;height:24px;cursor:pointer' alt='Visualizza investimento'/></a>";
                    e.Item.Style["background-color"] = "rgb(224, 224, 224)";
                }
                e.Item.Cells[3].Text = String.Format("{0:N}", Math.Round(quota, 2, MidpointRounding.AwayFromZero));
                e.Item.Cells[0].Text = testo_cella;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                // se il bando è a importo fisso il contributo totale lo devo cambiare                
                bool importoFisso = false;
                SiarLibrary.BandoConfigCollection config = new SiarBLL.BandoConfigCollectionProvider().Find(Progetto.IdBando, "QUOTAFISSA", null, true, null);
                decimal contributo_quota_fissa = 0;
                if (config.Count > 0)
                {
                    importoFisso = true;
                    SiarLibrary.BandoImpreseQuotaFissaCollection q = new SiarBLL.BandoImpreseQuotaFissaCollectionProvider().Find(Progetto.IdBando, Progetto.IdImpresa, null, true);
                    if (q != null && q.Count > 0)
                        contributo_quota_fissa = q[0].Quota;
                }

                e.Item.Cells[1].Text = string.Format("{0:c}", TotCosto);
                if (!importoFisso)
                    e.Item.Cells[2].Text = string.Format("{0:c}", TotContributo);
                else
                {
                    if (contributo_quota_fissa < TotContributo)
                        e.Item.Cells[2].Text = string.Format("{0:c}", contributo_quota_fissa);
                    else
                        e.Item.Cells[2].Text = string.Format("{0:c}", TotContributo);
                }                

                if (_codiceFase == "PDOMANDA") investimenti = investimenti_provider.GetSituazionePianoInvestimenti(Progetto.IdProgetto);
                else if (_codiceFase == "IDOMANDA") investimenti = investimenti_provider.GetPianoInvestimentiIstruttoria(Progetto.IdProgetto);
                else /*if (_codiceFase == "PVARIANTE")*/ investimenti = investimenti_provider.GetPianoInvestimentiVariante(Progetto.IdProgetto, Variante.IdVariante);

                SiarLibrary.NullTypes.DecimalNT contributo_calcolato = investimenti_provider.
                    CalcoloContributoInvestimentiProgetto(Progetto.IdProgetto, Progetto.CodStato != "P", investimenti[0].IdVariante);
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
            }
        }
    }
}