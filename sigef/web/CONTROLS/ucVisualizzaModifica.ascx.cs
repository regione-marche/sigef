using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;
using SiarLibrary.Web;

namespace web.CONTROLS
{
    public partial class ucVisualizzaModifica : SigefUserControl
    {
        BandoProgrammazioneCollectionProvider bando_prog_provider;
        SchedaXPrioritaCollectionProvider scheda_provider;
        ValoriPrioritaCollectionProvider valori_provider;
        PrioritaXProgettoCollectionProvider priorita_prog_provider;
        BandoRequisitiPagamentoCollectionProvider requisiti_provider;
        ModificaDatiGeneraleCollectionProvider modifica_dati_provider;

        private ProgettoCollectionProvider _progettoProvider;
        public ProgettoCollectionProvider ProgettoProvider
        {
            get
            {
                if (_progettoProvider == null) _progettoProvider = new ProgettoCollectionProvider();
                return _progettoProvider;
            }
            set { _progettoProvider = value; }
        }

        private ModificaDatiGenerale _modificaDatiGenerale;
        public ModificaDatiGenerale ModificaDati
        {
            get { return _modificaDatiGenerale; }
            set { _modificaDatiGenerale = value; }
        }

        #region Indici colonne priorita

        private int col_Pri_Numero = 0,
            col_Pri_Descrizione = 1,
            col_Pri_Valore = 2,
            col_Pri_Id = 3;

        #endregion

        #region Indici colonne requisiti

        private int col_Req_Numero = 0,
            col_Req_Descrizione = 1,
            col_Req_Valore = 2,
            col_Req_Id = 3;

        #endregion

        #region Indici colonne indicatori

        private int col_Ind_Numero = 0,
            col_Ind_Intervento = 1,
            col_Ind_IndicatoreCodice = 2,
            col_Ind_IndicatoreDesc = 3,
            col_Ind_ValoreProgrammatoRichiesto = 4,
            col_Ind_ValoreProgrammatoAmmesso = 5,
            col_Ind_ValoreRealizzatoRichiesto = 6,
            col_Ind_ValoreRealizzatoAmmesso = 7,
            col_Ind_UnitaMisura = 8,
            col_Ind_Richiedibile = 9;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_modificaDatiGenerale != null)
                ucDatiDomanda.Progetto = ProgettoProvider.GetById(_modificaDatiGenerale.IdProgetto);
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();

            if (_modificaDatiGenerale != null)
            {
                txtNote.Text = _modificaDatiGenerale.Note;

                if (_modificaDatiGenerale.TipoModifica == "Indicatori")
                {
                    CaricaModificaIndicatori();

                    divPriorita.Visible = false;
                    divRequisiti.Visible = false;
                }
                else if (_modificaDatiGenerale.TipoModifica == "Priorita")
                {
                    CaricaModificaPriorita();

                    divIndicatori.Visible = false;
                    divRequisiti.Visible = false;
                }
                else if (_modificaDatiGenerale.TipoModifica == "Requisiti")
                {
                    CaricaModificaRequisiti();

                    divIndicatori.Visible = false;
                    divPriorita.Visible = false;
                }
                else
                {
                    divIndicatori.Visible = false;
                    divPriorita.Visible = false;
                    divRequisiti.Visible = false;
                    ((PrivatePage)Page).ShowError("Modifica senza tipologia.");
                }
            }
            else
            {
                divIndicatori.Visible = false;
                divPriorita.Visible = false;
                divRequisiti.Visible = false;
                ((PrivatePage)Page).ShowError("Modifica non caricata correttamente.");
            }

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            bando_prog_provider = new BandoProgrammazioneCollectionProvider(ProgettoProvider.DbProviderObj);
            scheda_provider = new SchedaXPrioritaCollectionProvider(ProgettoProvider.DbProviderObj);
            valori_provider = new ValoriPrioritaCollectionProvider(ProgettoProvider.DbProviderObj);
            priorita_prog_provider = new PrioritaXProgettoCollectionProvider(ProgettoProvider.DbProviderObj);
            requisiti_provider = new BandoRequisitiPagamentoCollectionProvider(ProgettoProvider.DbProviderObj);
            modifica_dati_provider = new ModificaDatiGeneraleCollectionProvider(ProgettoProvider.DbProviderObj);
        }

        private void CaricaModificaIndicatori()
        {
            var istanza_precedente = IstanzaProgettoIndicatori.Deserialize(_modificaDatiGenerale.IstanzaPrecedente);
            dgIndicatoriPrecedenti.ItemDataBound += new DataGridItemEventHandler(dgIndicatori_ItemDataBound);
            dgIndicatoriPrecedenti.DataSource = istanza_precedente.PROGETTO_INDICATORI.PROGETTO_INDICATORI_LIST;
            dgIndicatoriPrecedenti.DataBind();

            var istanza_nuova = IstanzaProgettoIndicatori.Deserialize(_modificaDatiGenerale.IstanzaNuovo);
            dgIndicatoriNuovi.ItemDataBound += new DataGridItemEventHandler(dgIndicatori_ItemDataBound);
            dgIndicatoriNuovi.DataSource = istanza_nuova.PROGETTO_INDICATORI.PROGETTO_INDICATORI_LIST;
            dgIndicatoriNuovi.DataBind();

            //Evidenzio le modifiche
            foreach (DataGridItem dataGridItemOld in dgIndicatoriPrecedenti.Items)
            {
                var riga = dataGridItemOld.ItemIndex;

                var dataGridItemNew = dgIndicatoriNuovi.Items[riga];

                ConfrontaCelle(dataGridItemOld.Cells[col_Ind_ValoreProgrammatoRichiesto], dataGridItemNew.Cells[col_Ind_ValoreProgrammatoRichiesto]);
                ConfrontaCelle(dataGridItemOld.Cells[col_Ind_ValoreProgrammatoAmmesso], dataGridItemNew.Cells[col_Ind_ValoreProgrammatoAmmesso]);
                ConfrontaCelle(dataGridItemOld.Cells[col_Ind_ValoreRealizzatoRichiesto], dataGridItemNew.Cells[col_Ind_ValoreRealizzatoRichiesto]);
                ConfrontaCelle(dataGridItemOld.Cells[col_Ind_ValoreRealizzatoAmmesso], dataGridItemNew.Cells[col_Ind_ValoreRealizzatoAmmesso]);
            }
        }

        private void CaricaModificaPriorita()
        {
            var progetto = new ProgettoCollectionProvider().GetById(_modificaDatiGenerale.IdProgetto);
            var priorita_x_progetto_provider = new PrioritaXProgettoCollectionProvider();

            var istanza_precedente = IstanzaPrioritaXProgetto.Deserialize(_modificaDatiGenerale.IstanzaPrecedente);
            var istanza_precedente_list = istanza_precedente.PRIORITAXPROGETTO.scaricaList();
            var priorita_precedente_collection = new PrioritaXProgettoCollection();
            var priorita_precedente_list_datagrid = new List<PrioritaXProgetto>();

            var istanza_nuova = IstanzaPrioritaXProgetto.Deserialize(_modificaDatiGenerale.IstanzaNuovo);
            var istanza_nuova_list = istanza_nuova.PRIORITAXPROGETTO.scaricaList();
            var priorita_nuova_collection = new PrioritaXProgettoCollection();
            var priorita_nuova_list_datagrid = new List<PrioritaXProgetto>();

            //mi prendo le priorita attualmente collegate al bando
            var disposizioni_attuative = bando_prog_provider.GetDispAttuativeBando(progetto.IdBando, progetto.IdProgetto);
            foreach (BandoProgrammazione d in disposizioni_attuative)
            {
                var priorita_coll = priorita_x_progetto_provider.GetPrioritaDisposizioniAttuative(d.IdDisposizioniAttuative, "D", d.AdditionalAttributes["IdProgetto"]);
                priorita_precedente_collection.AddCollection(priorita_coll);
                priorita_nuova_collection.AddCollection(priorita_coll);
            }
            
            var priorita_precedente_list = priorita_precedente_collection.ToArrayList<PrioritaXProgetto>();
            var priorita_nuova_list = priorita_nuova_collection.ToArrayList<PrioritaXProgetto>();

            // GESTISTO LE PRIORITA PRECEDENTI
            //per ogni priorita trovata associata al bando verifico se ho i valori nell'istanza:
            // se ho la priorita nell'istanza prendo quella
            // altrimenti prendo la priorita del bando (se non ce l'ho vuol dire che non è valorizzata o è stata aggiunta)
            foreach (PrioritaXProgetto p in priorita_precedente_list)
            {
                var coll = istanza_precedente_list
                    .Where(i => i.IdPriorita == p.IdPriorita)
                    .ToList<PrioritaXProgetto>();

                if (coll.Count > 0)
                    priorita_precedente_list_datagrid.Add(coll[0]);
                else
                    priorita_precedente_list_datagrid.Add(p);
            }

            dgPrioritaPrecedenti.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
            dgPrioritaPrecedenti.DataSource = priorita_precedente_list_datagrid;
            dgPrioritaPrecedenti.DataBind();

            // GESTISTO LE PRIORITA NUOVE
            //per ogni priorita trovata associata al bando verifico se ho i valori nell'istanza:
            // se ho la priorita nell'istanza prendo quella
            // altrimenti prendo la priorita del bando (se non ce l'ho vuol dire che non è valorizzata o è stata aggiunta)
            foreach (PrioritaXProgetto p in priorita_nuova_list)
            {
                var coll = istanza_nuova_list
                    .Where(i => i.IdPriorita == p.IdPriorita)
                    .ToList<PrioritaXProgetto>();

                if (coll.Count > 0)
                    priorita_nuova_list_datagrid.Add(coll[0]);
                else
                    priorita_nuova_list_datagrid.Add(p);
            }

            dgPrioritaNuove.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
            dgPrioritaNuove.DataSource = priorita_nuova_list_datagrid;
            dgPrioritaNuove.DataBind();

            //Evidenzio le modifiche
            foreach (DataGridItem dataGridItemNew in dgPrioritaNuove.Items)
            {
                var riga_new = dataGridItemNew.ItemIndex;
                var id_priorita_new = int.Parse(dataGridItemNew.Cells[col_Pri_Id].Text);

                foreach (DataGridItem dataGridItemOld in dgPrioritaPrecedenti.Items)
                {
                    var id_priorita_old = int.Parse(dataGridItemOld.Cells[col_Pri_Id].Text);

                    if (id_priorita_new == id_priorita_old)
                        ConfrontaCelleReplace(dataGridItemOld.Cells[col_Pri_Valore], dataGridItemNew.Cells[col_Pri_Valore]);
                }
            }
        }

        private void CaricaModificaRequisiti()
        {
            var progetto = new ProgettoCollectionProvider().GetById(_modificaDatiGenerale.IdProgetto);
            var domanda = new DomandaDiPagamentoCollectionProvider().GetById(_modificaDatiGenerale.IdDomanda);
            var bando = new BandoCollectionProvider().GetById(progetto.IdBando);
            var bando_requisiti_provider = new BandoRequisitiPagamentoCollectionProvider();
            var pagamento_requisiti_provider = new DomandaPagamentoRequisitiCollectionProvider();

            var istanza_precedente = IstanzaDomandaPagamentoRequisiti.Deserialize(_modificaDatiGenerale.IstanzaPrecedente);
            var istanza_precedente_list = istanza_precedente.DOMANDAPAGAMENTOREQUISITI.scaricaList(); ;
            var requisiti_precedente_collection = new DomandaPagamentoRequisitiCollection();
            var requisiti_precedente_list_datagrid = new List<DomandaPagamentoRequisiti>();

            var istanza_nuova = IstanzaDomandaPagamentoRequisiti.Deserialize(_modificaDatiGenerale.IstanzaNuovo);
            var istanza_nuova_list = istanza_nuova.DOMANDAPAGAMENTOREQUISITI.scaricaList();
            var requisiti_nuova_collection = new DomandaPagamentoRequisitiCollection();
            var requisiti_nuova_list_datagrid = new List<DomandaPagamentoRequisiti>();

            var disposizioni_attuative = bando_prog_provider.GetDispAttuativeBando(progetto.IdBando, progetto.IdProgetto);
            var requisiti_inseriti = requisiti_provider.Find(domanda.IdDomandaPagamento, null, null);

            //mi prendo i requisiti attualmente collegati al bando
            foreach (BandoProgrammazione d in disposizioni_attuative)
            {
                var bando_requisiti_coll = bando_requisiti_provider
                    .Find(d.IdDisposizioniAttuative, domanda.CodTipo, null)
                    .FiltroDiInserimento(true);

                foreach (BandoRequisitiPagamento br in bando_requisiti_coll)
                {
                    var requisito_inserito_coll = pagamento_requisiti_provider.Find(domanda.IdDomandaPagamento, br.IdRequisito, null); //RequisitiInseriti.CollectionGetById(domanda.IdDomandaPagamento, br.IdRequisito);

                    if (requisito_inserito_coll.Count > 0)
                    {
                        requisiti_precedente_collection.AddCollection(requisito_inserito_coll);
                        requisiti_nuova_collection.AddCollection(requisito_inserito_coll);
                    }
                }
            }

            var requisiti_precedente_list = requisiti_precedente_collection.ToArrayList<DomandaPagamentoRequisiti>();
            var requisiti_nuova_list = requisiti_nuova_collection.ToArrayList<DomandaPagamentoRequisiti>();

            // GESTISTO I REQUISITI PRECEDENTI
            //per ogni requisito trovato associato al bando verifico se ho i valori nell'istanza:
            // se ho il requisito nell'istanza prendo quella
            // altrimenti prendo il requsito del bando (se non ce l'ho vuol dire che non è valorizzata o è stata aggiunta)
            foreach (DomandaPagamentoRequisiti p in requisiti_precedente_list)
            {
                var coll = istanza_precedente_list
                    .Where(i => i.IdRequisito == p.IdRequisito)
                    .ToList<DomandaPagamentoRequisiti>();

                if (coll.Count > 0)
                    requisiti_precedente_list_datagrid.Add(coll[0]);
                else
                    requisiti_precedente_list_datagrid.Add(p);
            }

            dgRequisitiPrecedenti.ItemDataBound += new DataGridItemEventHandler(dgRequisiti_ItemDataBound);
            dgRequisitiPrecedenti.DataSource = requisiti_precedente_list_datagrid;
            dgRequisitiPrecedenti.DataBind();

            // GESTISTO I REQUISITI NUOVI
            //per ogni requisito trovato associato al bando verifico se ho i valori nell'istanza:
            // se ho il requisito nell'istanza prendo quella
            // altrimenti prendo il requsito del bando (se non ce l'ho vuol dire che non è valorizzata o è stata aggiunta)
            foreach (DomandaPagamentoRequisiti p in requisiti_nuova_list)
            {
                var coll = istanza_nuova_list
                    .Where(i => i.IdRequisito == p.IdRequisito)
                    .ToList<DomandaPagamentoRequisiti>();

                if (coll.Count > 0)
                    requisiti_nuova_list_datagrid.Add(coll[0]);
                else
                    requisiti_nuova_list_datagrid.Add(p);
            }

            dgRequisitiNuovi.ItemDataBound += new DataGridItemEventHandler(dgRequisiti_ItemDataBound);
            dgRequisitiNuovi.DataSource = requisiti_nuova_list_datagrid;
            dgRequisitiNuovi.DataBind();

            //Evidenzio le modifiche
            foreach (DataGridItem dataGridItemNew in dgRequisitiNuovi.Items)
            {
                var riga_new = dataGridItemNew.ItemIndex;
                var id_requisito_new = int.Parse(dataGridItemNew.Cells[col_Req_Id].Text);

                foreach (DataGridItem dataGridItemOld in dgRequisitiPrecedenti.Items)
                {
                    var id_requisito_old = int.Parse(dataGridItemOld.Cells[col_Req_Id].Text);

                    if (id_requisito_new == id_requisito_old)
                        ConfrontaCelleReplace(dataGridItemOld.Cells[col_Req_Valore], dataGridItemNew.Cells[col_Req_Valore]);
                }
            }
        }

        private void CaricaModificaRequisitiOld()
        {
            var progetto = new ProgettoCollectionProvider().GetById(_modificaDatiGenerale.IdProgetto);
            var domanda = new DomandaDiPagamentoCollectionProvider().GetById(_modificaDatiGenerale.IdDomanda);
            var bando = new BandoCollectionProvider().GetById(progetto.IdBando);

            var istanza_precedente = IstanzaDomandaPagamentoRequisiti.Deserialize(_modificaDatiGenerale.IstanzaPrecedente);
            var istanza_precedente_list = istanza_precedente.DOMANDAPAGAMENTOREQUISITI.DOMANDA_PAGAMENTO_REQUISITI_LIST;

            var requisiti_precedenti_list = new List<BandoRequisitiPagamento>();
            foreach (DOMANDA_PAGAMENTO_REQUISITIType dpr in istanza_precedente_list)
            {
                var r = requisiti_provider.Find(bando.IdBando, domanda.CodTipo, dpr.ID_REQUISITO)[0];
                requisiti_precedenti_list.Add(r);
            }

            istanza_precedente_list = (from i in istanza_precedente_list
                                       join r in requisiti_precedenti_list on i.ID_REQUISITO equals r.IdRequisito.Value
                                       orderby r.Ordine, r.OrdineFase
                                       select i)
                                       .ToList<DOMANDA_PAGAMENTO_REQUISITIType>();

            dgRequisitiPrecedenti.ItemDataBound += new DataGridItemEventHandler(dgRequisiti_ItemDataBound);
            dgRequisitiPrecedenti.DataSource = istanza_precedente_list;
            dgRequisitiPrecedenti.DataBind();

            var istanza_nuova = IstanzaDomandaPagamentoRequisiti.Deserialize(_modificaDatiGenerale.IstanzaNuovo);
            var istanza_nuova_list = istanza_nuova.DOMANDAPAGAMENTOREQUISITI.DOMANDA_PAGAMENTO_REQUISITI_LIST;

            var requisiti_nuovi_list = new List<BandoRequisitiPagamento>();
            foreach (DOMANDA_PAGAMENTO_REQUISITIType dpr in istanza_nuova_list)
            {
                var r = requisiti_provider.Find(bando.IdBando, domanda.CodTipo, dpr.ID_REQUISITO)[0];
                requisiti_nuovi_list.Add(r);
            }

            istanza_nuova_list = (from i in istanza_nuova_list
                                  join r in requisiti_nuovi_list on i.ID_REQUISITO equals r.IdRequisito.Value
                                  orderby r.Ordine, r.OrdineFase
                                  select i)
                                .ToList<DOMANDA_PAGAMENTO_REQUISITIType>();

            dgRequisitiNuovi.ItemDataBound += new DataGridItemEventHandler(dgRequisiti_ItemDataBound);
            dgRequisitiNuovi.DataSource = istanza_nuova_list;
            dgRequisitiNuovi.DataBind();

            //Evidenzio le modifiche
            foreach (DataGridItem dataGridItemNew in dgRequisitiNuovi.Items)
            {
                var riga_new = dataGridItemNew.ItemIndex;
                var id_requisito_new = int.Parse(dataGridItemNew.Cells[col_Req_Id].Text);

                var req_old_list = from pri in istanza_precedente.DOMANDAPAGAMENTOREQUISITI.DOMANDA_PAGAMENTO_REQUISITI_LIST
                                   where pri.ID_REQUISITO == id_requisito_new
                                   select pri;

                if (req_old_list != null && req_old_list.Count() > 0)
                {
                    var req_old = req_old_list.ElementAt(0);

                    foreach (DataGridItem dataGridItemOld in dgRequisitiPrecedenti.Items)
                    {
                        var id_requisito_old = int.Parse(dataGridItemOld.Cells[col_Req_Id].Text);

                        if (id_requisito_new == id_requisito_old)
                            ConfrontaCelleReplace(dataGridItemOld.Cells[col_Req_Valore], dataGridItemNew.Cells[col_Req_Valore]);
                    }
                }
                else
                {
                    var testo = dataGridItemNew.Cells[col_Pri_Valore].Text;

                    CellaVerde(dataGridItemNew.Cells[col_Pri_Valore]);
                }
            }
        }

        private void ConfrontaCelle(TableCell cellaVecchia, TableCell cellaNuova)
        {
            var valore_vecchio = cellaVecchia.Text;
            var valore_nuovo = cellaNuova.Text;

            if (valore_vecchio != valore_nuovo)
            {
                cellaVecchia.ForeColor = System.Drawing.Color.Red;
                cellaNuova.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void ConfrontaCelleReplace(TableCell cellaVecchia, TableCell cellaNuova)
        {
            var valore_vecchio = cellaVecchia.Text;
            var valore_nuovo = cellaNuova.Text;

            if (valore_vecchio != valore_nuovo)
            {
                CellaRossa(cellaVecchia);
                CellaVerde(cellaNuova);
            }
        }

        private void CellaRossa(TableCell tc)
        {
            tc.Text = tc.Text.Replace("color:black;", "color:red;");
        }

        private void CellaVerde(TableCell tc)
        {
            tc.Text = tc.Text.Replace("color:black;", "color:green;");
        }

        #region ItemDataBound

        void dgRequisitiOld_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                var requisito_inserito = (DOMANDA_PAGAMENTO_REQUISITIType)dgi.DataItem;

                var requisito = new RequisitiPagamentoCollectionProvider().GetById(requisito_inserito.ID_REQUISITO);
                e.Item.Cells[col_Req_Descrizione].Text = requisito.Descrizione;

                if (requisito_inserito.PLURIVALORE != null && requisito_inserito.PLURIVALORE == true)
                {
                    string nome_casella = "lblRequisitiPlurivaloreSql" + requisito_inserito.ID_REQUISITO;
                    var valore = valori_provider.GetById(requisito_inserito.ID_VALORE);
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" style=\"display:inline-block;width:120px;color:black;\">"
                         + valore.Descrizione + "</span>";
                }
                else if (requisito_inserito.URL != null && requisito_inserito.URL.Length > 0)
                {
                    e.Item.Cells[col_Req_Valore].Attributes.Add("align", "center");
                    e.Item.Cells[col_Req_Valore].Text = "<a href='" + requisito_inserito.URL + "'>Vai alla pagina di modifica dei dati >>></a>";
                }
                else if (requisito_inserito.NUMERICO != null && requisito_inserito.NUMERICO == true)
                {
                    string nome_casella = "txtRequisitoNumerico" + requisito_inserito.ID_REQUISITO;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack)
                        valore = requisito_inserito.VAL_NUMERICO.ToString();
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"CurrencyBox\" style=\"display:inline-block;width:120px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:right;width:120px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (requisito_inserito.DATETIME != null && requisito_inserito.DATETIME == true)
                {
                    string nome_casella = "txtRequisitoDatetime" + requisito_inserito.ID_REQUISITO;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack && requisito_inserito.VAL_DATA != null)
                        valore = ((DateTime)requisito_inserito.VAL_DATA).ToString("dd/MM/yyyy");
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"DataBox\" style=\"display:inline-block;width:120px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:right;width:120px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (requisito_inserito.TESTO_SEMPLICE != null && requisito_inserito.TESTO_SEMPLICE == true)
                {
                    string nome_casella = "txtRequisitoTestoSemplice" + requisito_inserito.ID_REQUISITO;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack)
                        valore = requisito_inserito.VAL_TESTO;
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"TextBox\" style=\"display:inline-block;width:360px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:left;width:360px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (requisito_inserito.TESTO_AREA != null && requisito_inserito.TESTO_AREA == true)
                {
                    string nome_casella = "txtRequisitoTestoArea" + requisito_inserito.ID_REQUISITO;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack)
                        valore = requisito_inserito.VAL_TESTO;
                    e.Item.Cells[col_Req_Valore].Text = "<span id='" + nome_casella + "' class='TextArea'><textarea id='" + nome_casella + "_text' name='"
                        + nome_casella + "_text' cols='20' rows='3' disabled style='text-align:left;width:360px;color:black;'>" + valore + "</textarea></span>";
                }
                else //checkbox
                {
                    string testo_check = "";
                    if (requisito_inserito != null && requisito_inserito.SELEZIONATO != null && requisito_inserito.SELEZIONATO == true)
                        testo_check = "<input name='chkRequisito" + requisito.IdRequisito + "' type='checkbox' disabled checked value='" + requisito.IdRequisito + "' />";
                    else
                        testo_check = "<input name='chkRequisito" + requisito.IdRequisito + "' type='checkbox' disabled value='" + requisito.IdRequisito + "' />";

                    e.Item.Cells[col_Req_Valore].Text = testo_check;
                }
            }
        }

        void dgRequisiti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                var requisito_inserito = (DomandaPagamentoRequisiti)dgi.DataItem;

                //var requisito = new RequisitiPagamentoCollectionProvider().GetById(requisito_inserito.ID_REQUISITO);
                e.Item.Cells[col_Req_Descrizione].Text = requisito_inserito.Descrizione;

                if (requisito_inserito.Plurivalore != null && requisito_inserito.Plurivalore == true)
                {
                    string nome_casella = "lblRequisitiPlurivaloreSql" + requisito_inserito.IdRequisito;
                    var valore = valori_provider.GetById(requisito_inserito.IdValore);
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" style=\"display:inline-block;width:120px;color:black;\">"
                         + valore.Descrizione + "</span>";
                }
                else if (requisito_inserito.Url != null && requisito_inserito.Url.Value.Length > 0)
                {
                    e.Item.Cells[col_Req_Valore].Attributes.Add("align", "center");
                    e.Item.Cells[col_Req_Valore].Text = "<a href='" + requisito_inserito.Url + "'>Vai alla pagina di modifica dei dati >>></a>";
                }
                else if (requisito_inserito.Numerico != null && requisito_inserito.Numerico == true)
                {
                    string nome_casella = "txtRequisitoNumerico" + requisito_inserito.IdRequisito;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack)
                        valore = requisito_inserito.ValNumerico.ToString();
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"CurrencyBox\" style=\"display:inline-block;width:120px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:right;width:120px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (requisito_inserito.Datetime != null && requisito_inserito.Datetime == true)
                {
                    string nome_casella = "txtRequisitoDatetime" + requisito_inserito.IdRequisito;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack && requisito_inserito.ValData != null)
                        valore = ((DateTime)requisito_inserito.ValData).ToString("dd/MM/yyyy");
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"DataBox\" style=\"display:inline-block;width:120px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:right;width:120px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (requisito_inserito.TestoSemplice != null && requisito_inserito.TestoSemplice == true)
                {
                    string nome_casella = "txtRequisitoTestoSemplice" + requisito_inserito.IdRequisito;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack)
                        valore = requisito_inserito.ValTesto;
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"TextBox\" style=\"display:inline-block;width:360px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:left;width:360px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (requisito_inserito.TestoArea != null && requisito_inserito.TestoArea == true)
                {
                    string nome_casella = "txtRequisitoTestoArea" + requisito_inserito.IdRequisito;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack)
                        valore = requisito_inserito.ValTesto;
                    e.Item.Cells[col_Req_Valore].Text = "<span id='" + nome_casella + "' class='TextArea'><textarea id='" + nome_casella + "_text' name='"
                        + nome_casella + "_text' cols='20' rows='3' disabled style='text-align:left;width:360px;color:black;'>" + valore + "</textarea></span>";
                }
                else //checkbox
                {
                    string testo_check = "";
                    if (requisito_inserito != null && requisito_inserito.Selezionato != null && requisito_inserito.Selezionato == true)
                        testo_check = "<input name='chkRequisito" + requisito_inserito.IdRequisito + "' type='checkbox' disabled checked value='" + requisito_inserito.IdRequisito + "' />";
                    else
                        testo_check = "<input name='chkRequisito" + requisito_inserito.IdRequisito + "' type='checkbox' disabled value='" + requisito_inserito.IdRequisito + "' />";

                    e.Item.Cells[col_Req_Valore].Text = testo_check;
                }
            }
        }

        void dgPriorita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var pp = (PrioritaXProgetto)e.Item.DataItem;

                if (pp.PluriValore != null && pp.PluriValore == true)
                {
                    string nome_casella = "lblPrioritaPlurivalore" + pp.IdPriorita;
                    if (pp.IdValore != null)
                    {
                        var valore = valori_provider.GetById(pp.IdValore);
                        e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" style=\"display:inline-block;width:120px;color:black;\">"
                            + valore.Descrizione + "</span>";
                    }
                    else
                        e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" style=\"display:inline-block;width:120px;color:black;\"> </span>";
                }
                else if (pp.PluriValoreSql != null && pp.PluriValoreSql == true)
                {
                    string valore = "";
                    if (!string.IsNullOrEmpty(pp.ValTesto))
                    {
                        var cc = new ValoriPrioritaCollectionProvider().GetValoriPrioritaSql(pp.IdProgetto, false, pp.IdPriorita, pp.ValTesto);
                        if (cc.Count > 0)
                            valore = cc[0].Descrizione; // ------> testo da valorizzare se il requisito e' gia' stato salvato
                    }

                    string nome_casella = "lblPrioritaPlurivaloreSql" + pp.IdPriorita;
                    e.Item.Cells[col_Req_Valore].Text = "<span id=\"" + nome_casella + "\" style=\"display:inline-block;width:120px;color:black;\">"
                         + valore + "</span>";
                }
                else if (pp.InputNumerico != null && pp.InputNumerico == true)
                {
                    string nome_casella = "txtPriorita" + pp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (pp.Valore != null && !Page.IsPostBack)
                        valore = pp.Valore.ToString();
                    e.Item.Cells[col_Pri_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"CurrencyBox\" style=\"display:inline-block;width:124px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:right;WIDTH:100px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (pp.Datetime != null && pp.Datetime == true)
                {
                    string nome_casella = "txtPriorita" + pp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (pp.ValData != null && !Page.IsPostBack)
                        valore = ((DateTime)pp.ValData).ToString("dd/MM/yyyy");
                    e.Item.Cells[col_Pri_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"DataBox\" style=\"display:inline-block;width:124px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:right;WIDTH:100px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (pp.TestoSemplice != null && pp.TestoSemplice == true)
                {
                    string nome_casella = "txtPriorita" + pp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (pp.ValTesto != null && !Page.IsPostBack)
                        valore = pp.ValTesto;
                    e.Item.Cells[col_Pri_Valore].Text = "<span id=\"" + nome_casella + "\" class=\"TextBox\" style=\"display:inline-block;width:300px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" disabled style=\"text-align:left;WIDTH:300px;color:black;\" value='" + valore + "'/></span>";
                }
                else if (pp.TestoArea != null && pp.TestoArea == true)
                {
                    string nome_casella = "txtPriorita" + pp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (pp.ValTesto != null && !Page.IsPostBack)
                        valore = pp.ValTesto;
                    e.Item.Cells[col_Pri_Valore].Text = "<span id='" + nome_casella + "' class='TextArea'><textarea id='" + nome_casella + "_text' name='"
                        + nome_casella + "_text' cols='20' rows='3' disabled style='text-align:left;width:360px;color:black;'>" + valore + "</textarea></span>";
                }
                else if (pp.IdProgetto != null)
                {
                    string testo_check = "<input name='chkPriorita" + pp.IdPriorita + "' type='checkbox' disabled checked value='" + pp.IdPriorita + "' />";
                    e.Item.Cells[col_Pri_Valore].Text = testo_check;
                }
                else
                {
                    string testo_check = "<input name='chkPriorita" + pp.IdPriorita + "' type='checkbox' disabled value='" + pp.IdPriorita + "' />";
                    e.Item.Cells[col_Pri_Valore].Text = testo_check;
                }
            }
        }

        void dgIndicatori_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var pind = (PROGETTO_INDICATORIType)e.Item.DataItem;
            }
        }

        #endregion
    }
}