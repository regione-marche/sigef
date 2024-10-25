using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using SiarLibrary.Extensions;
using System.Web;
using System.Linq;


namespace web.CONTROLS
{
    public partial class PianoInvestimentiCovid : SiarLibrary.Web.SigefUserControl
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
                else if (Session["id_progetto_covid"] != null) p = ProgettoProvider.GetById(Session["id_progetto_covid"].ToString());
                return p;
            }
            set { Session["id_progetto_covid"] = value; }
        }
        public SiarLibrary.Bando Bando
        {
            get
            {
                SiarLibrary.Bando b = null;
                int id_bando;
                if (int.TryParse(Request.QueryString["idb"], out id_bando)) b = BandoProvider.GetById(id_bando);
                else if (Session["id_bando_covid"] != null) b = BandoProvider.GetById(Session["id_bando_covid"].ToString());
                return b;
            }
            set { Session["id_bando_covid"] = value; }
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

        private SiarBLL.BandoCollectionProvider _bandoProvider;
        public SiarBLL.BandoCollectionProvider BandoProvider
        {
            get
            {
                if (_bandoProvider == null) _bandoProvider = new SiarBLL.BandoCollectionProvider();
                return _bandoProvider;
            }
            set { _bandoProvider = value; }
        }

        private string _codiceFase;
        public string CodiceFase
        {
            get { return _codiceFase; }
            set { _codiceFase = value; }
        }

        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;
        SiarLibrary.BandoProgrammazione disposizione_selezionata = null;
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.PianoInvestimentiCollection investimenti;
        SiarLibrary.BandoTipoInvestimentiCollection tipo_investimenti = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Progetto != null)
            {
                disposizioni_attuative = new SiarBLL.BandoProgrammazioneCollectionProvider().GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);
                int id_da_selezionata;
                int.TryParse(hdnIdDASelezionata.Value, out id_da_selezionata);
                if (disposizioni_attuative.Count == 1) id_da_selezionata = disposizioni_attuative[0].IdDisposizioniAttuative;
                if (id_da_selezionata == 0) tbMisura.Rows[0].Cells[0].Attributes.Add("class", "tdMisura selected");
                foreach (SiarLibrary.BandoProgrammazione da in disposizioni_attuative)
                {
                    HtmlTableCell td = new HtmlTableCell();
                    string css_class = "tdMisura";
                    if (id_da_selezionata > 0 && id_da_selezionata == da.IdDisposizioniAttuative.Value)
                    {
                        disposizione_selezionata = da;
                        css_class += " selected";
                    }
                    td.Attributes.Add("class", css_class);
                    td.Attributes.Add("onclick", "mostraMisura(" + da.IdDisposizioniAttuative + ");");
                    td.InnerText = da.Codice;
                    tbMisura.Rows[0].Cells.Add(td);
                }
                HtmlTableRow tr2 = new HtmlTableRow();
                HtmlTableCell td2 = new HtmlTableCell();
                td2.ColSpan = disposizioni_attuative.Count + 1;
                td2.Attributes.Add("class", "tdMisuraFoot");
                tr2.Cells.Add(td2);
                tbMisura.Rows.Add(tr2);

                if (disposizione_selezionata == null)
                    tipo_investimenti = new SiarBLL.BandoTipoInvestimentiCollectionProvider().GetTipoInvestimentiProgetto(Progetto.IdBando, true);
                else
                {
                    tipo_investimenti = new SiarBLL.BandoTipoInvestimentiCollectionProvider().GetTipoInvestimentiProgetto(disposizione_selezionata.IdDisposizioniAttuative, false);
                    if (_codiceFase == "PDOMANDA" || (_codiceFase == "PVARIANTE" && Variante != null && Variante.CodTipo == "VA"))
                    {
                        foreach (SiarLibrary.BandoTipoInvestimenti tipo in tipo_investimenti)
                        {
                            if (!SiarLibrary.NullTypes.IntNT.FindInValues(tipo.CodTipoInvestimento, 3, 6, 7, 8))
                            {
                                SiarLibrary.Web.Button btn = new SiarLibrary.Web.Button();
                                btn.Style.Add("margin-right", "20px");
                                btn.Text = tipo.Text;
                                btn.Width = new Unit(200);
                                btn.CausesValidation = false;
                                btn.Modifica = true;
                                switch (tipo.CodTipoInvestimento.Value)
                                {
                                    case 4://fidejussione
                                        btn.Click += new EventHandler(btnPolizza_Click);
                                        break;
                                    default://investimenti e mutuo
                                        btn.Click += new EventHandler(btnNuovo_Click);
                                        btn.OnClientClick = "$('[id$=hdnButton]').val('" + tipo.Url + "');";
                                        break;
                                }
                                tdButtons.Controls.Add(btn);
                            }
                        }
                    }
                }
                if (!_codiceFase.FindValueIn("PVARIANTE", "IVARIANTE"))
                {
                    HtmlInputButton btnback = new HtmlInputButton();
                    btnback.Attributes.Add("class", "Button");
                    string url_indietro = "BusinessPlan.aspx";
                    if (_codiceFase == "IDOMANDA") url_indietro = "ChecklistAmmissibilita.aspx?iddom=" + Progetto.IdProgetto;
                    btnback.Attributes.Add("onclick", "location='" + url_indietro + "'");
                    btnback.Style.Add("width", "120px");
                    btnback.Value = "Indietro";
                    tdButtons.Controls.Add(btnback);
                }

                SiarLibrary.Web.Button btnEstrai = new SiarLibrary.Web.Button();
                btnEstrai.Style.Add("margin-right", "20px");
                btnEstrai.Text = "Estrai in XLS";
                btnEstrai.Width = new Unit(140);
                btnEstrai.CausesValidation = false;
                btnEstrai.Click += new EventHandler(btnEstrai_Click);
                tdButtons.Controls.Add(btnEstrai);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            try {
                //Creo gli investimenti
                SiarBLL.BandoProgrammazioneCollectionProvider programmazione_provider = new SiarBLL.BandoProgrammazioneCollectionProvider();
                SiarLibrary.BandoProgrammazione programmazionebando = programmazione_provider.GetProgrammazioneBando(Bando.IdBando, false)[0];
                SiarLibrary.CodificaInvestimentoCollection codifica_investimenti = new SiarLibrary.CodificaInvestimentoCollection();
                SiarBLL.CodificaInvestimentoCollectionProvider codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider();
                codifica_investimenti = codifica_provider.Find(Bando.IdBando, null);
                SiarLibrary.DettaglioInvestimenti dettaglioInvestimenti = new SiarBLL.DettaglioInvestimentiCollectionProvider().FindByIdBando(Bando.IdBando, codifica_investimenti[0].IdCodificaInvestimento)[0];
                //codifica_investimenti = codifica_provider.Find(Bando.IdBando);//leva
                investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                SiarLibrary.CodificaInvestimento cod_inv = new SiarBLL.CodificaInvestimentoCollectionProvider().GetById(codifica_investimenti[0].IdCodificaInvestimento);
                SiarLibrary.ZpsrAlbero zpsrAlbero = new SiarBLL.ZpsrAlberoCollectionProvider().GetById(programmazionebando.CodTipo);

                //SiarLibrary.CovidProgettoAutodichiarazione covidProgettoAutodichiarazione = new SiarBLL.CovidProgettoAutodichiarazioneCollectionProvider().Find(null, Progetto.IdProgetto, Bando.IdBando, null, null)[0];
                //SiarLibrary.CovidAutodichiarazioneRequisiti covidAutodichiarazioneRequisiti = new SiarBLL.CovidAutodichiarazioneRequisitiCollectionProvider().Find(covidProgettoAutodichiarazione.IdAutodichiarazione, "1", null)[0];
                SiarLibrary.Priorita priorita;
                SiarBLL.PrioritaCollectionProvider prioritaCollectionProvider = new SiarBLL.PrioritaCollectionProvider();
                SiarLibrary.PrioritaXProgettoCollection prioritaXProgettoCollection = new SiarBLL.PrioritaXProgettoCollectionProvider().Find(Progetto.IdProgetto, null, null);
                SiarBLL.ValoriPrioritaCollectionProvider valoriPrioritaCollectionProvider = new SiarBLL.ValoriPrioritaCollectionProvider();
                if (prioritaXProgettoCollection.Count == 0)
                    throw new Exception("Nessuna priorità è stata selezionata");

                double contributo_richiesto = 0;
                foreach (SiarLibrary.PrioritaXProgetto pp in prioritaXProgettoCollection)
                {
                    priorita = prioritaCollectionProvider.GetById(pp.IdPriorita);
                    if(priorita.Eval=="Importo_Contributo_Covid")
                    {
                        SiarLibrary.ValoriPriorita valoriPriorita = valoriPrioritaCollectionProvider.GetById(pp.IdValore);
                        contributo_richiesto += double.Parse(valoriPriorita.Punteggio);
                    }
                    else if (priorita.Eval == "Importo_Contributo_Ventilazione")
                    {
                        var num_aule = double.Parse(pp.Valore);
                        var valoriPriorita = valoriPrioritaCollectionProvider.Find(null, priorita.IdPriorita, null);
                        if (valoriPriorita != null)
                            contributo_richiesto += num_aule * double.Parse(valoriPriorita[0].Punteggio);
                    }
                }
                string[] cod_investimenti = new string[0];
                foreach (SiarLibrary.PrioritaXProgetto pp in prioritaXProgettoCollection)
                {
                    priorita = prioritaCollectionProvider.GetById(pp.IdPriorita);
                    if (priorita.Eval == "Criterio_Contributo_Covid")
                    {
                        SiarLibrary.ValoriPriorita valoriPriorita = valoriPrioritaCollectionProvider.GetById(pp.IdValore);
                        if (valoriPriorita.Codice != null)
                        {
                            string codici = valoriPriorita.Codice;
                            cod_investimenti = codici.Split('|');
                        }
                    }
                }

                SiarLibrary.PianoInvestimentiCollection investimentiDaSalvare = new SiarLibrary.PianoInvestimentiCollection();


                if (cod_investimenti.Length == 0)
                {
                    SiarLibrary.PianoInvestimenti inv = new SiarLibrary.PianoInvestimenti
                    {
                        IdProgetto = Progetto.IdProgetto,
                        IdProgrammazione = programmazionebando.IdProgrammazione,
                        Descrizione = codifica_investimenti[0].Descrizione,
                        CodTipoInvestimento = 1,
                        CodStp = "00",
                        IdUnitaMisura = dettaglioInvestimenti.IdUdm,
                        Quantita = 1,
                        CostoInvestimento = contributo_richiesto,
                        SpeseGenerali = 0,
                        ContributoRichiesto = contributo_richiesto,
                        QuotaContributoRichiesto = 100.00,
                        IdCodificaInvestimento = cod_inv.IdCodificaInvestimento,
                        IdDettaglioInvestimento = dettaglioInvestimenti.IdDettaglioInvestimento,
                        DettaglioInvestimenti = dettaglioInvestimenti.Descrizione,
                        CodificaInvestimento = cod_inv.Descrizione,
                        NonCofinanziato = 0,
                        Misura = zpsrAlbero.Descrizione + " " + programmazionebando.Codice
                    };
                    investimentiDaSalvare.Add(inv);
                }
                else
                {
                    foreach(string cod_investimento in cod_investimenti)
                    {
                        cod_inv = codifica_investimenti.ToArrayList<SiarLibrary.CodificaInvestimento>().SingleOrDefault(o => o.Codice == cod_investimento);
                        dettaglioInvestimenti = new SiarBLL.DettaglioInvestimentiCollectionProvider().FindByIdBando(Bando.IdBando, cod_inv.IdCodificaInvestimento)[0];
                        SiarLibrary.PianoInvestimenti inv = new SiarLibrary.PianoInvestimenti
                        {
                            IdProgetto = Progetto.IdProgetto,
                            IdProgrammazione = programmazionebando.IdProgrammazione,
                            Descrizione = cod_inv.Descrizione,
                            CodTipoInvestimento = 1,
                            CodStp = "00",
                            IdUnitaMisura = dettaglioInvestimenti.IdUdm,
                            Quantita = 1,
                            CostoInvestimento = contributo_richiesto,
                            SpeseGenerali = 0,
                            ContributoRichiesto = contributo_richiesto,
                            QuotaContributoRichiesto = 100.00,
                            IdCodificaInvestimento = cod_inv.IdCodificaInvestimento,
                            IdDettaglioInvestimento = dettaglioInvestimenti.IdDettaglioInvestimento,
                            DettaglioInvestimenti = dettaglioInvestimenti.Descrizione,
                            CodificaInvestimento = cod_inv.Descrizione,
                            NonCofinanziato = 0,
                            Misura = zpsrAlbero.Descrizione + " " + programmazionebando.Codice
                        };
                        investimentiDaSalvare.Add(inv);
                    }
                }

                try
                {
                    investimenti_provider.DbProviderObj.BeginTran();
                    SiarLibrary.PianoInvestimentiCollection pianoInvestimentiCollection = investimenti_provider.Find(null, Progetto.IdProgetto, null, null, null, null, null);
                    investimenti_provider.DeleteCollection(pianoInvestimentiCollection);
                    pianoInvestimentiCollection.Clear();
                    foreach(SiarLibrary.PianoInvestimenti investimento in investimentiDaSalvare)
                        investimenti_provider.Save(investimento);
                    investimenti_provider.DbProviderObj.Commit();
                }

                catch (Exception ex) { investimenti_provider.DbProviderObj.Rollback(); }


                if (Progetto != null)
                {

                    if (_codiceFase == "PDOMANDA") investimenti = investimenti_provider.GetSituazionePianoInvestimenti(Progetto.IdProgetto);
                    else if (_codiceFase == "IDOMANDA") investimenti = investimenti_provider.GetPianoInvestimentiIstruttoria(Progetto.IdProgetto);
                    else /*if (_codiceFase == "PVARIANTE")*/ investimenti = investimenti_provider.GetPianoInvestimentiVariante(Progetto.IdProgetto, Variante.IdVariante);
                    // filtro la misura selezionata
                    if (disposizione_selezionata != null) investimenti = investimenti.FiltroProgettoCorrelato(
                        disposizione_selezionata.AdditionalAttributes["IdProgetto"]);
                    //SiarLibrary.PianoInvestimentiCollection inv_supp = null;
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
                        tbLegendaInvestimenti.Visible = false;
                    }


                    imgRedStar.Src = Request.ApplicationPath + "/images/star_red.gif";
                    hdnButton.Value = "";
                }
                base.OnPreRender(e);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
            }

        decimal rata_reintegrazione = 0, costo_totale = 0, spese_tecniche_totali = 0, contributo_totale = 0;
        void dgInvestimenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                SiarLibrary.PianoInvestimenti inv = (SiarLibrary.PianoInvestimenti)dgi.DataItem;
                if (inv.IdPrioritaSettoriale != null) dgi.Cells[0].Text = "<img src='" + Request.ApplicationPath + "/images/star_red.gif'><br /><br />" + dgi.Cells[0].Text;
                if (_codiceFase.FindValueIn("IDOMANDA", "IVARIANTE") && inv.Ammesso != null && inv.Ammesso)
                    dgi.Cells[0].Text = "<img src='" + Request.ApplicationPath + "/images/visto.gif'>&nbsp;&nbsp;" + dgi.Cells[0].Text;
                dgi.Cells[2].Width = 500;



                dgi.Cells[2].Text = "Codifica: <b>" + inv.CodificaInvestimento + "</b><br />Descrizione: <b>" + inv.Descrizione + "</b>";
                SiarLibrary.Bando bando_ = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                if (bando_.Aggregazione)
                {
                    if (inv.IdImpresaAggregazione != null)
                    {
                        SiarLibrary.Impresa impresa_aggr = new SiarBLL.ImpresaCollectionProvider().GetById(inv.IdImpresaAggregazione);
                        dgi.Cells[2].Text += "<br />Impresa: <b>" + impresa_aggr.RagioneSociale + " - " + impresa_aggr.CodiceFiscale + "</b>";
                        if (impresa_aggr.CodAteco2007 != null && impresa_aggr.CodAteco2007 != "")
                            dgi.Cells[2].Text += " - Ateco: " + impresa_aggr.CodAteco2007;
                    }
                }
                else
                {
                    string[] Aggregazione = new string[2];
                    Aggregazione = investimenti_provider.GetImpresaAggregazioneInvestimento(inv.IdInvestimento);
                    if (Aggregazione[0] != null && Aggregazione[1] != null && Aggregazione[0] != "" && Aggregazione[1] != "")
                    {
                        dgi.Cells[2].Text += "<br />Impresa: <b>" + Aggregazione[0] + " - " + Aggregazione[1] + "</b>";
                        SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);
                        if (impresa.CodAteco2007 != null && impresa.CodAteco2007 != "")
                            dgi.Cells[2].Text += " - Ateco: " + impresa.CodAteco2007;
                    }
                }

                //Personalizzazione bando 6.2
                if (Progetto.IdBando == 39)
                {
                    string linea_intervento = "";
                    linea_intervento = investimenti_provider.GetLineaInterventoInvestimento(inv.IdInvestimento);
                    if (linea_intervento != null && linea_intervento != "")
                        dgi.Cells[2].Text += "<br /><b>" + linea_intervento + "</b>";
                }

                if (inv.Mobile == null) inv.Mobile = false;
                if (inv.NonCofinanziato) e.Item.Cells[6].Text = "(*)";
                decimal rata = (inv.Mobile ? (inv.CostoInvestimento.Value + inv.SpeseGenerali.Value) / 10 :
                    (inv.CostoInvestimento.Value + inv.SpeseGenerali.Value) / 30);
                if (inv.CodVariazione != "A")
                {
                    rata_reintegrazione += rata;
                    costo_totale += inv.CostoInvestimento;
                    spese_tecniche_totali += inv.SpeseGenerali;
                    contributo_totale += inv.ContributoRichiesto;
                }

                dgi.Cells[8].Text = String.Format("{0:c}", Math.Round(rata, 2, MidpointRounding.AwayFromZero));
                if (_codiceFase.FindValueIn("PVARIANTE", "IVARIANTE") && inv.CodVariazione != null)
                {
                    dgi.Cells[0].Text += " <b>(" + inv.CodVariazione + ")</b>";
                    switch (inv.CodVariazione)
                    {
                        case "A": for (int i = 2; i < 9; i++) { dgi.Cells[i].Style.Add("text-decoration", "line-through"); dgi.Cells[i].Style.Add("color", "black"); } break;
                        case "E": for (int i = 4; i < 9; i++) dgi.Cells[i].Style.Add("color", "green"); break;
                        case "M": for (int i = 4; i < 9; i++) dgi.Cells[i].Style.Add("color", "red"); break;
                        case "N": for (int i = 4; i < 9; i++) dgi.Cells[i].Style.Add("color", "blue"); break;
                        case "V": for (int i = 4; i < 9; i++) dgi.Cells[i].Style.Add("color", "#FFA500"); break;
                    }
                }
                e.Item.Cells[7].Text = string.Format("{0:N}", Math.Round(inv.QuotaContributoRichiesto, 2, MidpointRounding.AwayFromZero));
            }
            else if (dgi.ItemType == ListItemType.Footer)
            {
                dgi.Cells[4].Text = string.Format("{0:c}", costo_totale);
                dgi.Cells[5].Text = string.Format("{0:c}", spese_tecniche_totali);
                dgi.Cells[6].Text = string.Format("{0:c}", contributo_totale);
                decimal quota = ((costo_totale + spese_tecniche_totali) > 0 ? contributo_totale / (costo_totale + spese_tecniche_totali) * 100 : 0);
                dgi.Cells[7].Text = String.Format("{0:N}", Math.Round(quota, 2, MidpointRounding.AwayFromZero));
                dgi.Cells[8].Text = String.Format("{0:c}", Math.Round(rata_reintegrazione, 2, MidpointRounding.AwayFromZero));

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

                // questo calcolo va fatto solo se il bando non è a importo fisso
                if (!importoFisso)
                {
                    SiarLibrary.NullTypes.DecimalNT contributo_calcolato = investimenti_provider.
                        CalcoloContributoInvestimentiProgetto(Progetto.IdProgetto, Progetto.CodStato != "P", investimenti[0].IdVariante);
                    if (contributo_calcolato != null && contributo_calcolato < contributo_totale)
                        dgi.Cells[6].Text = "** " + String.Format("{0:c}", contributo_calcolato.Value);
                }
                else
                {
                    if (contributo_totale > contributo_quota_fissa)
                        dgi.Cells[6].Text = "*** " + String.Format("{0:c}", contributo_quota_fissa);
                    else
                        dgi.Cells[6].Text = string.Format("{0:c}", contributo_totale);
                }
            }
        }

        decimal costo_brevetti = 0, contributo_brevetti = 0;
        void dgBrevetti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti inv = (SiarLibrary.PianoInvestimenti)e.Item.DataItem;
                if (_codiceFase.FindValueIn("IDOMANDA", "IVARIANTE") && inv.Ammesso != null && inv.Ammesso)
                    e.Item.Cells[0].Text = "<img src='" + Request.ApplicationPath + "/images/visto.gif'>&nbsp;&nbsp;" + e.Item.Cells[0].Text;
                if (inv.CodVariazione != "A")
                {
                    costo_brevetti += inv.CostoInvestimento;
                    contributo_brevetti += inv.ContributoRichiesto;
                }
                if (_codiceFase.FindValueIn("PVARIANTE", "IVARIANTE") && inv.CodVariazione != null)
                {
                    e.Item.Cells[0].Text += " <b>(" + inv.CodVariazione + ")</b>";
                    switch (inv.CodVariazione)
                    {
                        case "A": for (int i = 1; i < 5; i++) { e.Item.Cells[i].Style.Add("text-decoration", "line-through"); e.Item.Cells[i].Style.Add("color", "black"); } break;
                        case "E": for (int i = 2; i < 5; i++) e.Item.Cells[i].Style.Add("color", "green"); break;
                        case "M": for (int i = 2; i < 5; i++) e.Item.Cells[i].Style.Add("color", "red"); break;
                        case "N": for (int i = 2; i < 5; i++) e.Item.Cells[i].Style.Add("color", "blue"); break;
                        case "V": for (int i = 2; i < 5; i++) e.Item.Cells[i].Style.Add("color", "#FFA500"); break;
                    }
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[2].Text = string.Format("{0:c}", costo_brevetti);
                e.Item.Cells[3].Text = string.Format("{0:c}", contributo_brevetti);
                decimal quota = (costo_brevetti > 0 ? contributo_brevetti / costo_brevetti * 100 : 0);
                e.Item.Cells[4].Text = string.Format("{0:N}", Math.Round(quota, 2, MidpointRounding.AwayFromZero));
            }
        }

        void dgMutuo_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti inv = (SiarLibrary.PianoInvestimenti)e.Item.DataItem;
                if (_codiceFase.FindValueIn("IDOMANDA", "IVARIANTE") && inv.Ammesso != null && inv.Ammesso)
                    e.Item.Cells[0].Text = "<img src='" + Request.ApplicationPath + "/images/visto.gif'>&nbsp;&nbsp;" + e.Item.Cells[0].Text;
                if (_codiceFase.FindValueIn("PVARIANTE", "IVARIANTE") && inv.CodVariazione != null)
                {
                    e.Item.Cells[0].Text += " <b>(" + inv.CodVariazione + ")</b>";
                    switch (inv.CodVariazione)
                    {
                        case "A": for (int i = 1; i < 6; i++) { e.Item.Cells[i].Style.Add("text-decoration", "line-through"); e.Item.Cells[i].Style.Add("color", "black"); } break;
                        case "E": for (int i = 2; i < 6; i++) e.Item.Cells[i].Style.Add("color", "green"); break;
                        case "M": for (int i = 2; i < 6; i++) e.Item.Cells[i].Style.Add("color", "red"); break;
                        case "N": for (int i = 2; i < 6; i++) e.Item.Cells[i].Style.Add("color", "blue"); break;
                        case "V": for (int i = 2; i < 6; i++) e.Item.Cells[i].Style.Add("color", "FFA500"); break;
                    }
                }
            }
        }

        void dgFidejussione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti inv = (SiarLibrary.PianoInvestimenti)e.Item.DataItem;
                if (_codiceFase.FindValueIn("IDOMANDA", "IVARIANTE") && inv.Ammesso != null && inv.Ammesso)
                    e.Item.Cells[0].Text = "<img src='" + Request.ApplicationPath + "/images/visto.gif'>&nbsp;&nbsp;" + e.Item.Cells[0].Text;
                SiarLibrary.Web.CurrencyBox cb = new SiarLibrary.Web.CurrencyBox();
                cb.ID = "txtAmmontarePolizzaProg" + inv.IdProgetto;
                cb.NomeCampo = "Importo della polizza";
                cb.Width = new Unit(80);
                cb.Text = inv.CostoInvestimento;
                cb.ReadOnly = !AbilitaModifica || inv.CodVariazione == "A";
                e.Item.Cells[2].Controls.Add(cb);
                if (AbilitaModifica && disposizione_selezionata != null)
                {
                    e.Item.Cells[5].Text = "<img src='" + Request.ApplicationPath + "/images/reload.gif' title='Ricalcola' onclick='calcolaPolizza(" + inv.IdProgetto
                        + ");' style='cursor:pointer' />";
                    if (_codiceFase == "PDOMANDA")
                        e.Item.Cells[5].Text += "<img src='" + Request.ApplicationPath + "/images/xdel.gif' title='Elimina' onclick='deletePolizza(" + inv.IdProgetto
                            + ");' style='cursor:pointer;padding-left:10px' />";
                    else if (_codiceFase == "PVARIANTE" && Variante.CodTipo == "VA")
                    {
                        if (inv.CodVariazione == "A") e.Item.Cells[5].Text = "<a href='javascript:calcolaPolizza(" + inv.IdProgetto + ");'>Ripristina</a>";
                        e.Item.Cells[5].Text += "<img src='" + Request.ApplicationPath + "/images/xdel.gif' title='Annulla la polizza' onclick='deletePolizza(" + inv.IdProgetto
                            + ");' style='cursor:pointer;padding-left:10px' />";
                    }
                }
                if (_codiceFase.FindValueIn("PVARIANTE", "IVARIANTE") && inv.CodVariazione != null)
                {
                    e.Item.Cells[0].Text += " <b>(" + inv.CodVariazione + ")</b>";
                    switch (inv.CodVariazione)
                    {
                        case "A": for (int i = 1; i < 5; i++) { e.Item.Cells[i].Style.Add("text-decoration", "line-through"); e.Item.Cells[i].Style.Add("color", "black"); } break;
                        case "E": for (int i = 2; i < 5; i++) e.Item.Cells[i].Style.Add("color", "green"); break;
                        case "M": for (int i = 2; i < 5; i++) e.Item.Cells[i].Style.Add("color", "red"); break;
                        case "N": for (int i = 2; i < 5; i++) e.Item.Cells[i].Style.Add("color", "blue"); break;
                        case "V": for (int i = 2; i < 5; i++) e.Item.Cells[i].Style.Add("color", "FFA500"); break;
                    }
                }
            }
        }

        protected void btnNuovo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (disposizione_selezionata == null) throw new Exception("Per proseguire è necessario specificare la programmazione di riferimento.");
                int idprogetto = CercaProgettoCorrelato();
                // reindirizzo all'inserimento degli investimenti
                ((SiarLibrary.Web.PrivatePage)Page).Redirect(hdnButton.Value + "?idpcurrent=" + idprogetto.ToString());
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        private int CercaProgettoCorrelato()
        {
            int id_progetto = Progetto.IdProgetto;
            if (Progetto.IdProgetto == Progetto.IdProgIntegrato)
            {
                //se non è valorizzato il campo il progetto correlato non è ancora presente
                if (!int.TryParse(disposizione_selezionata.AdditionalAttributes["IdProgetto"], out id_progetto))
                {
                    try
                    {
                        if (_codiceFase != "PDOMANDA") throw new Exception("Non è possibile eseguire l'operazione richiesta in quanto non prevista dalla domanda di aiuto al momento del rilascio.");
                        ProgettoProvider.DbProviderObj.BeginTran();
                        SiarLibrary.Progetto p = new SiarLibrary.Progetto();
                        p.IdProgIntegrato = Progetto.IdProgetto;
                        p.FlagDefinitivo = false;
                        p.FlagPreadesione = false;
                        p.IdImpresa = Progetto.IdImpresa;
                        p.IdBando = disposizione_selezionata.IdDisposizioniAttuative;
                        p.OperatoreCreazione = Operatore.Utente.IdUtente;
                        p.DataCreazione = DateTime.Now;
                        ProgettoProvider.Save(p);

                        SiarLibrary.ProgettoStorico s = new SiarLibrary.ProgettoStorico();
                        s.IdProgetto = p.IdProgetto;
                        s.CodStato = "P";
                        s.Data = DateTime.Now;
                        s.Operatore = Operatore.Utente.IdUtente;
                        new SiarBLL.ProgettoStoricoCollectionProvider(ProgettoProvider.DbProviderObj).Save(s);
                        p.IdStoricoUltimo = s.Id;
                        ProgettoProvider.Save(p);
                        ProgettoProvider.DbProviderObj.Commit();
                        id_progetto = p.IdProgetto;
                    }
                    catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); throw ex; }
                }
            }
            return id_progetto;
        }

        protected void btnPost_Click(object sender, EventArgs e) { /*usato per il postback delle misure*/ }

        #region fidejussione

        private SiarLibrary.PianoInvestimenti GetPolizzaByIdProgetto(int id_progetto)
        {
            SiarLibrary.PianoInvestimentiCollection polizze = investimenti_provider.Find(null, id_progetto, null, null, null, null, null)
                .FiltroInvestimentoOriginale(Progetto.CodStato == "P").FiltroTipoInvestimento(4);
            if (_codiceFase == "PVARIANTE") polizze = polizze.FiltroVariante(Variante.IdVariante);
            if (polizze.Count > 0) return polizze[0];
            return null;
        }

        protected void btnDelPolizza_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (disposizione_selezionata == null) throw new Exception("Per proseguire è necessario specificare la programmazione di riferimento.");
                SiarLibrary.PianoInvestimenti polizza = GetPolizzaByIdProgetto(CercaProgettoCorrelato());
                if (polizza == null) throw new Exception("La polizza selezionata non è valida.");
                if (_codiceFase == "PDOMANDA")
                {
                    ProgettoProvider.DbProviderObj.BeginTran();
                    investimenti_provider.Delete(polizza);
                    ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                    ProgettoProvider.DbProviderObj.Commit();
                    ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Polizza fidejussoria eliminata correttamente.");
                }
                else if (_codiceFase == "PVARIANTE")
                {
                    if (investimenti_provider.GetContributoPagamentiRichiestiInvestimento(polizza.IdInvestimento, null) > 0)
                        throw new Exception("Impossibile annullare la polizza selezionata perchè è già stata rendicontata in precedenti domande di pagamento.");
                    SiarBLL.VariantiCollectionProvider varianti_provider = new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj);
                    try
                    {
                        investimenti_provider.DbProviderObj.BeginTran();
                        if (polizza.CodVariazione != "N")
                        {
                            polizza.CodVariazione = "A";
                            polizza.DataVariazione = DateTime.Now;
                            polizza.OperatoreVariazione = Operatore.Utente.CfUtente;
                            investimenti_provider.Save(polizza);
                            varianti_provider.AggiornaVariante(Variante, Operatore);
                            investimenti_provider.DbProviderObj.Commit();
                            ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Polizza fidejussoria annullata correttamente.");
                        }
                        else //se e' nuovo lo elimino
                        {
                            investimenti_provider.Delete(polizza);
                            varianti_provider.AggiornaVariante(Variante, Operatore);
                            investimenti_provider.DbProviderObj.Commit();
                            ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Polizza fidejussoria eliminata correttamente.");
                        }
                    }
                    catch (Exception ex) { investimenti_provider.DbProviderObj.Rollback(); ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
                }
                else throw new Exception("Non è possibile in istruttoria eliminare o annullare la polizza fidejussoria richiesta.");
            }
            catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        protected void btnPolizza_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (disposizione_selezionata == null) throw new Exception("Per proseguire è necessario specificare la programmazione di riferimento.");

                int id_progetto = CercaProgettoCorrelato();
                SiarLibrary.PianoInvestimenti polizza = GetPolizzaByIdProgetto(id_progetto);
                if (polizza == null)
                {
                    if (_codiceFase.FindValueIn("IDOMANDA", "IVARIANTE")) throw new Exception("La polizza selezionata non è valida.");
                    polizza = new SiarLibrary.PianoInvestimenti();
                    polizza.CodTipoInvestimento = 4;
                    polizza.IdProgetto = id_progetto;
                    polizza.Descrizione = "Ammontare polizza fidejussoria";
                    // la aggancio alla prima tipologia di intervento della disp attuativa
                    polizza.IdProgrammazione = new SiarBLL.BandoProgrammazioneCollectionProvider().
                        Find(disposizione_selezionata.IdDisposizioniAttuative, null, null, null)[0].Id;
                    if (_codiceFase == "PVARIANTE")
                    {
                        polizza.IdVariante = Variante.IdVariante;
                        polizza.OperatoreVariazione = Operatore.Utente.CfUtente;
                        polizza.DataVariazione = DateTime.Now;
                        polizza.CodVariazione = "N";
                    }
                }
                else
                {
                    string ammontare_inserito = "";
                    foreach (string s in Request.Form.AllKeys)
                        if (s.EndsWith("txtAmmontarePolizzaProg" + polizza.IdProgetto + "_text")) { ammontare_inserito = Request.Form[s]; break; }

                    decimal valore_polizza = 0;
                    if (string.IsNullOrEmpty(ammontare_inserito)) polizza.CostoInvestimento = null;
                    else if (!decimal.TryParse(ammontare_inserito.Replace(".", ""), out valore_polizza) || valore_polizza < 0)
                        throw new Exception("Inserire un importo valido per la polizza fidejussoria.");
                    else polizza.CostoInvestimento = valore_polizza;
                }

                investimenti_provider.DbProviderObj.BeginTran();
                string messaggio_troncamento = investimenti_provider.CalcoloImportiFidejussione(ref polizza, Progetto.CodStato != "P");
                if (_codiceFase == "PDOMANDA") ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                if (_codiceFase.FindValueIn("IDOMANDA", "IVARIANTE"))
                {
                    polizza.DataValutazione = DateTime.Now;
                    polizza.Ammesso = true;
                    polizza.Istruttore = Operatore.Utente.CfUtente;
                }
                if (_codiceFase.FindValueIn("PVARIANTE", "IVARIANTE"))
                {
                    if (polizza.IdInvestimento != null && polizza.ContributoRichiesto <
                        investimenti_provider.GetContributoPagamentiRichiestiInvestimento(polizza.IdInvestimento, Variante.Segnatura == null ? null : Variante.DataModifica))
                        throw new Exception("Impossibile diminuire il contributo richiesto oltre l`ammontare rendicontato nelle precedenti domande di pagamento.");

                    //controllo sull'originale
                    if (polizza.CodVariazione != "N" && polizza.IdInvestimentoOriginale != null)
                    {
                        SiarLibrary.PianoInvestimenti polizza_originale = investimenti_provider.GetById(polizza.IdInvestimentoOriginale);
                        if (polizza.CostoInvestimento > polizza_originale.CostoInvestimento)
                        {
                            if (Variante.CodTipo == "AT")
                                throw new Exception("Sono autorizzati adeguamenti tecnici solo se la spesa per singolo investimento rimane tale o diminuisce. Non sono ammesse maggiorazioni.");
                            polizza.CodVariazione = "M";
                        }
                        else if (polizza.CostoInvestimento < polizza_originale.CostoInvestimento) polizza.CodVariazione = "E";
                        else polizza.CodVariazione = null;
                    }
                    if (_codiceFase == "PVARIANTE") new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj).AggiornaVariante(Variante, Operatore);
                    else new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj).AggiornaVarianteIstruttoria(Variante, Operatore);
                }
                investimenti_provider.Save(polizza);
                investimenti_provider.DbProviderObj.Commit();
                ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Ammontare della polizza fidejussoria calcolato correttamente. " + messaggio_troncamento);
            }
            catch (Exception ex) { investimenti_provider.DbProviderObj.Rollback(); ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        #endregion

        protected void btnEstrai_Click(object sender, EventArgs e)
        {
            try
            {
                string parametri = "";
                parametri += "IdProgetto=" + Progetto.IdProgetto;
                if (_codiceFase == "PDOMANDA")
                {
                    parametri += "|CodQuery=" + "PIANO_INVESTIMENTI";
                }
                else if (_codiceFase == "IDOMANDA")
                {
                    parametri += "|CodQuery=" + "PIANO_INVESTIMENTI_ISTRUTTORIA";
                }
                else /*if (_codiceFase == "PVARIANTE")*/
                {
                    parametri += "|CodQuery=" + "VARIANTE_ATTUALE";
                    parametri += "|IdVarianteAttuale=" + Variante.IdVariante;
                }

                string jsFunction = "SNCVisualizzaReport('rptPianoInvestimenti', 2, '" + parametri + "');";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunction, true);
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }
    }
}
    
