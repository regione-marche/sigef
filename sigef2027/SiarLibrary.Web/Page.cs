using System;
using System.Web;

using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using SiarBLL;
using System.Linq;

namespace SiarLibrary.Web
{
    public class Page : System.Web.UI.Page
    {
        public static readonly string PATH_PPAGAMENTO = VirtualPathUtility.ToAbsolute("~/Private/PPagamento/");
        public static readonly string PATH_PVARIANTE = VirtualPathUtility.ToAbsolute("~/Private/PPagamento/Variante/");
        public static readonly string PATH_IPAGAMENTO = VirtualPathUtility.ToAbsolute("~/Private/IPagamento/");
        public static readonly string PATH_IVARIANTE = VirtualPathUtility.ToAbsolute("~/Private/IPagamento/IVariante/");
        public static readonly string PATH_IMAGES = VirtualPathUtility.ToAbsolute("~/Images/");
        public static readonly string PATH_PDOMANDA = VirtualPathUtility.ToAbsolute("~/Private/PDomanda/");
        public static readonly string PATH_VALIDAZIONELOTTI = VirtualPathUtility.ToAbsolute("~/Private/IPagamento/");
        public static readonly string PATH_ISTRUTTORIA = VirtualPathUtility.ToAbsolute("~/Private/Istruttoria/");
        public static readonly string PATH_PRIVATE = VirtualPathUtility.ToAbsolute("~/Private/");
        public static readonly string PATH_PUBLIC = VirtualPathUtility.ToAbsolute("~/Public/");
        public static readonly string PATH_PSR_BANDI = VirtualPathUtility.ToAbsolute("~/Private/Psr/Bandi/");
        public static readonly string PATH_MODIFICA = VirtualPathUtility.ToAbsolute("~/Private/ModificaDati/");
        public static readonly string PATH_CONTROLS = VirtualPathUtility.ToAbsolute("~/CONTROLS/");
        public static readonly string PATH_CONTROLLI = VirtualPathUtility.ToAbsolute("~/Private/Controlli/");
        public static readonly string PATH_COVID = VirtualPathUtility.ToAbsolute("~/Private/COVID/");
        public static readonly string PATH_FEM = VirtualPathUtility.ToAbsolute("~/Private/Fem/");
        public static readonly string PATH_ADMIN = VirtualPathUtility.ToAbsolute("~/Private/admin/");

        private ValidationSummary _vSummary;
        string _funzione;

        [System.ComponentModel.DefaultValue("")]
        public string Funzione
        {
            get { return _funzione; }
            set
            {
                if (value == "")
                    _funzione = null;
                else
                    _funzione = value;
            }
        }

        public string FunzioneMenu
        {
            get
            {
                if (Master != null)
                    return Master.GetType().GetProperty("FunzionePagina").GetValue(Master, null).ToString();
                return null;
            }
            set
            {
                if (Master != null)
                    Master.GetType().GetProperty("FunzionePagina").SetValue(Master, value, null);
            }
        }

        #region attributi
        [AttributeUsage(AttributeTargets.Class)]
        public class OperatoreNotRequiredAttribute : Attribute
        { }
        #endregion

        public Page() : base() { }

        protected internal object _dataSource;
        [System.ComponentModel.Browsable(false)]
        public object DataSource
        {
            get { return _dataSource; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            HtmlForm form = (HtmlForm)base.Controls[0].Controls[3];
            form.Attributes.Add("autocomplete", "off");

            if (Page.Validators.Count > 0)
            {
                Page.Validate();
                //_vSummary = new ValidationSummary();
                //_vSummary.EnableViewState = false;
                //_vSummary.ShowMessageBox = false;
                //_vSummary.ShowSummary = false;
                //form.Controls.Add(_vSummary);
            }

            showHelp();

            if (!IsPostBack)
            {
                if (Session["siar_session_message_onload"] != null)
                {
                    string messaggio_sessione = Session["siar_session_message_onload"].ToString();
                    if (messaggio_sessione.StartsWith("+")) ShowMessage(messaggio_sessione.Substring(1));
                    else ShowError(messaggio_sessione.Substring(1));
                    Session["siar_session_message_onload"] = null;
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["show_error"])) ShowError(Request.QueryString["show_error"]);
                else if (!string.IsNullOrEmpty(Request.QueryString["show_message"])) ShowMessage(Request.QueryString["show_message"]);
            }
#if(DEBUG)
            _execJsCode = "$(document).bind('keydown',function(e){mostraCoordinateMouse(e);}).bind('keyup',function(e){if(divCoordinateMouse)$(divCoordinateMouse).hide();});" + _execJsCode;
#endif

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "scptPageExecJsCode", "$(document).ready(function(){" + _execJsCode + "});", true);
            base.OnPreRender(e);
        }

        private void showHelp()
        {
            try
            {
                PageHelpCollection hh = new SiarBLL.PageHelpCollectionProvider().Find(this.GetType().BaseType.FullName, null, true);
                PageHelpCollection elenco_documenti = new PageHelpCollection();
                foreach (SiarLibrary.PageHelp h in hh)
                {
                    bool visualizza_documento = true;
                    // se non ci sono parametri lo visualizzo
                    if (!string.IsNullOrEmpty(h.Parametri))
                    {
                        string[] elenco_parametri = h.Parametri.Value.Split('|');
                        bool[] parametri_trovati = new bool[elenco_parametri.Length];
                        for (int j = 0; j < elenco_parametri.Length; j++)
                        {
                            string[] specifiche_classe = elenco_parametri[j].Split('.');
                            object classe_trovata = null;
                            for (int i = 0; i < Session.Count; i++)
                                if (Session[i] != null && specifiche_classe[0] == Session[i].GetType().FullName.Replace("SiarLibrary.", "").Replace("SiarLibrary.Web.", ""))
                                {
                                    classe_trovata = Session[i]; break; // la classe trovata e' l'i-esimo elemento della sessione
                                }
                            if (classe_trovata != null)
                            {
                                // se non e' specificato il valore di nessuna proprieta' lo visualizzo
                                if (specifiche_classe.Length == 1) parametri_trovati[j] = true;
                                else
                                {
                                    string[] specifiche_proprieta = specifiche_classe[1].Split('=');
                                    if (specifiche_proprieta.Length == 2)
                                    {
                                        System.Reflection.PropertyInfo pi = classe_trovata.GetType().GetProperty(specifiche_proprieta[0]);
                                        if (pi != null)
                                        {
                                            object val = pi.GetValue(classe_trovata, null);
                                            if (val != null && val.ToString() == specifiche_proprieta[1]) parametri_trovati[j] = true;
                                        }
                                    }
                                }
                            }
                        }
                        foreach (bool b in parametri_trovati) if (!b) { visualizza_documento = false; break; }
                    }
                    if (visualizza_documento) elenco_documenti.Add(h);
                }
                if (elenco_documenti.Count > 0) RegisterClientScriptBlock("sjsHelpOnline(" + elenco_documenti.ConvertToJSonObject() + ");");
            }
            catch { }
        }

        private string _execJsCode = "sAjaxAddUpdateProgressHandlers();addEventHandlersMainFunction();";
        public void RegisterClientScriptBlock(string js_function) { if (_execJsCode.IndexOf(js_function) < 0)_execJsCode += js_function; }

        public void ShowMessage(SiarLibrary.TextMessageCodes c) { ShowMessage(SiarLibrary.TextProvider.Get(c)); }

        public void ShowMessage(string messaggio) { RegisterClientScriptBlock("mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);"); }

        public void ShowError(SiarLibrary.TextErrorCodes c) { ShowError(SiarLibrary.TextProvider.Get(c)); }

        public void ShowError(string messaggio, string errore) { RegisterClientScriptBlock("mostraPopupMessaggio('" + errore.ToCleanJsString() + "',1);"); }

        public void ShowError(string errore) { ShowError("Attenzione!", errore); }

        public void ShowError(Exception eccezione)
        {
            if (eccezione.Message == "Object reference not set to an instance of an object.") ShowError(SiarLibrary.TextErrorCodes.GenericoConLink);
            else ShowError(eccezione.Message.ToCleanJsString());
        }

        public void ShowErrorFull(Exception eccezione)
        {
            if (eccezione.Message == "Object reference not set to an instance of an object.") ShowError(SiarLibrary.TextErrorCodes.GenericoConLink);
            else ShowError(eccezione.Message.ToFullJsString());
        }

#if(DEBUG)
        protected override void OnUnload(EventArgs e)
        {
            GC.Collect();
            base.OnUnload(e);
        }
#endif
        public void Redirect(string url)
        {
            OnUnload(EventArgs.Empty);
            Response.Redirect(url, true);
        }

        public void Redirect(string url, bool endResponse)
        {
            OnUnload(EventArgs.Empty);
            Response.Redirect(url, endResponse);
        }

        public void Redirect(string url, string messaggio_onload, bool is_error)
        {
            Session["siar_session_message_onload"] = (is_error ? "-" : "+") + messaggio_onload.ToCleanJsString();
            Redirect(url);
        }

        public void Redirect(string url, string messaggio_onload, bool is_error, bool endResponse)
        {
            Session["siar_session_message_onload"] = (is_error ? "-" : "+") + messaggio_onload.ToCleanJsString();
            Redirect(url, endResponse);
        }
    }

    public class PrivatePage : Page
    {
        public Operatore Operatore { get { return ((MasterPage)Master).Operatore; } }

        private bool _abilitaModifica;
        public bool AbilitaModifica
        {
            get { return _abilitaModifica; }
            set { _abilitaModifica = value; }
        }
        /// <summary>
        /// inserito per domanda pagamento page
        /// valori: 0 non abilitato, 1 sola visualizzazione, 2 inserimento abilitato, 3 istruttoria abilitata
        /// </summary>
        private int _tipoModifica;
        public int TipoModifica
        {
            get { return _tipoModifica; }
            set { _tipoModifica = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            try
            {
                if (Operatore == null) ((MasterPage)Master).SetOperatore(new SiarLibrary.NullTypes.IntNT());
                SiarLibrary.ProfiloXFunzioniCollection pxfcoll = new SiarBLL.ProfiloXFunzioniCollectionProvider().
                    Find(Operatore.Utente.IdProfilo, null, null, FunzioneMenu, null, null, null, null);
                if (string.IsNullOrEmpty(FunzioneMenu) || pxfcoll.Count == 0) 
                    throw new SiarException(TextErrorCodes.UtenteSenzaPermessi);
                if (pxfcoll.Count > 0) 
                    _abilitaModifica = pxfcoll[0].Modifica;

                if (FunzioneMenu != "gestione_sportello_caa" && FunzioneMenu != "Welcome" && Operatore.Utente.CodTipoEnte == "CAA")
                {
                    if (Operatore.UtenteCaa == null || new SiarBLL.CaaSportelloCollectionProvider().Find(Operatore.UtenteCaa.CodiceSportello, Operatore.UtenteCaa.CodEnte, null,
                        null, "R").Count > 0) Response.Redirect(Request.ApplicationPath + "/private/admin/SportelloCaaSelezione.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Redirect(Request.ApplicationPath + "/logout.aspx?show_error=" + ex.Message); 
            }

            base.OnPreInit(e);
        }
    }

    public class ZoomPage : System.Web.UI.Page
    {
        public bool OperatoreAbilitato
        {
            get { return Operatore != null; }
        }

        public SiarLibrary.Operatore Operatore
        {
            get { return (SiarLibrary.Operatore)(Session["OperatoreAlias"] ?? Session["Operatore"]); }
        }

        private bool _abilitaModifica;
        public bool AbilitaModifica
        {
            get { return _abilitaModifica; }
            set { _abilitaModifica = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            if (!OperatoreAbilitato) Response.Write(TextProvider.Get(TextErrorCodes.UtenteSenzaPermessi));
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "scptPageExecJsCode", "$(document).ready(function(){addEventHandlersMainFunction();});", true);
            base.OnPreRender(e);
        }
    }

    public class ModificaPage : PrivatePage

    {

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



        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }



        public DomandaDiPagamento Domanda
        {
            get { return (DomandaDiPagamento)Session["_domanda"]; }
            set { Session["_domanda"] = value; }
        }



        public Varianti Variante
        {
            get { return (Varianti)Session["_variante"]; }
            set { Session["_variante"] = value; }
        }



        public ModificaDatiGenerale ModificaDati

        {

            get { return (ModificaDatiGenerale)Session["_modifica_dati"]; }
            set { Session["_modifica_dati"] = value; }

        }



        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "modifica_generale";
            base.OnPreInit(e);
        }



        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idProgetto;
                if (int.TryParse(Request.QueryString["iddom"], out idProgetto))

                    Progetto = ProgettoProvider.GetById(idProgetto);
              }
            catch (Exception ex)

            {

                Redirect("RicercaDomanda.aspx", ex.Message.ToCleanJsString(), true);

            }

            base.OnLoad(e);
        }

    }
    public enum tipoDecertificazione
    {
        Irregolarita,
        Errore,
        Revoca,
        RecuperoBeneficiario,
        Rinuncia
    }

    public class ProgettoPage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "progetto_dettaglio";
            base.OnPreInit(e);
        }

        /// <summary>
        /// indica se il progetto in sessione fa parte di un progetto integrato o no
        /// </summary>
        public bool IsProgettoIntegrato { get { return Progetto.IdProgetto == Progetto.IdProgIntegrato; } }

        /// <summary>
        /// progetto (integrato) in sessione 
        /// </summary>
        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        /// <summary>
        /// bando relativo
        /// </summary>
        private Bando _bando;
        public Bando Bando
        {
            get
            {
                if (_bando == null && Progetto != null) _bando = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                return _bando;
            }
        }

        /// <summary>
        /// impresa titolare della domanda
        /// </summary>
        private Impresa _azienda;
        public Impresa Azienda
        {
            get
            {
                if (_azienda == null && Progetto != null) _azienda = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                return _azienda;
            }
        }

        /// <summary>
        /// provider non in sessione
        /// </summary>
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

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idProgetto;
                if (int.TryParse(Request.QueryString["iddom"], out idProgetto)) Progetto = ProgettoProvider.GetById(idProgetto);
                if (Progetto == null) throw new Exception("Per proseguire è necessario selezionare la domanda.");
                if (Progetto.IdProgIntegrato != null && Progetto.IdProgIntegrato != Progetto.IdProgetto)
                    throw new Exception("La domanda di aiuto selezionata non è valida.");
                TipoModifica = DbStaticProvider.GetPermessiOperatoreSuProgetto(Progetto.IdProgetto, Operatore.Utente.IdUtente, ProgettoProvider.DbProviderObj);
                AbilitaModifica = AbilitaModifica && TipoModifica == 2 && !Progetto.FirmaPredisposta;
                if (TipoModifica == 0) throw new Exception("Non si hanno i permessi necessari alla visualizzazione della domanda selezionata.");
                this.Master.FindControl("cphContenuto").Controls.AddAt(0, LoadControl("~/controls/DatiDomanda.ascx"));
            }
            catch (Exception ex) { Redirect("RicercaDomanda.aspx", ex.Message.ToCleanJsString(), true); }
            if (Progetto.IdFascicolo == null && Bando.FascicoloRichiesto && !Request.Path.ToLower().Substring(Request.Path.LastIndexOf("/") + 1).FindValueIn("datigenerali.aspx",
                "anagrafica.aspx", "fascicoloaziendale.aspx")) Redirect("fascicoloaziendale.aspx", "Per proseguire è necessario scaricare e congelare il fascicolo aziendale dell'impresa.", true);
            base.OnLoad(e);
        }
    }

    public class DomandaPagamentoPage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "progetto_pagamenti";
            base.OnPreInit(e);
        }

        /// <summary>
        /// Domanda di pagamento in sessione
        /// </summary>
        public DomandaDiPagamento DomandaPagamento
        {
            get { return (DomandaDiPagamento)Session["domanda_pagamento"]; }
            set { Session["domanda_pagamento"] = value; }
        }

        /// <summary>
        /// progetto (integrato) in sessione 
        /// </summary>
        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        /// <summary>
        /// iter procedurale in sessione
        /// </summary>
        public VworkflowPagamentoCollection WorkFlow
        {
            get
            {
                if (Session["WorkflowPagamento"] != null)
                    return (VworkflowPagamentoCollection)Session["WorkflowPagamento"];
                return null;
            }
            set { Session["WorkflowPagamento"] = value; }
        }

        /// <summary>
        /// provider NON in sessione
        /// </summary>
        private SiarBLL.DomandaDiPagamentoCollectionProvider _pagamentoProvider;
        public SiarBLL.DomandaDiPagamentoCollectionProvider PagamentoProvider
        {
            get
            {
                if (_pagamentoProvider == null) _pagamentoProvider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                return _pagamentoProvider;
            }
            set { _pagamentoProvider = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idPagamento;
                if (int.TryParse(Request.QueryString["idpag"], out idPagamento)) DomandaPagamento = PagamentoProvider.GetById(idPagamento);
                if (DomandaPagamento == null) throw new Exception("Per proseguire è necessario selezionare la domanda di pagamento desiderata.");
                if (Progetto == null || Progetto.IdProgetto != DomandaPagamento.IdProgetto)
                    Progetto = new ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);

                VworkflowPagamentoCollection _workflow = new VworkflowPagamentoCollectionProvider().Find(DomandaPagamento.CodTipo, null, null, null);
                if (_workflow.Count == 0) throw new SiarException(TextErrorCodes.GenericoConLink);
                VworkflowPagamentoCollection vpc = _workflow.SubSelect(DomandaPagamento.CodTipo, "FIDEJ", null, null, null, null, null, null, null, null);
                if (vpc.Count > 0)
                {
                    BandoTipoPagamentoCollection btp = new BandoTipoPagamentoCollectionProvider().Find(Progetto.IdBando, DomandaPagamento.CodTipo, null);
                    if (btp.Count > 0 && btp[0].CodTipoPolizza == "F0N")
                    {
                        int ordineTmp = vpc[0].Ordine;
                        _workflow.Remove(vpc[0]);
                        foreach (VworkflowPagamento vp in _workflow)
                        {
                            if (vp.Ordine > ordineTmp)
                                vp.Ordine--;
                        }
                    }
                }

                //Gestione workflow con strumenti finanziari
                if (DomandaPagamento.TpAppaltoStrumentiFinanziari && DomandaPagamento.CodTipo != "ANT")
                {
                    var _workflowList = _workflow.ToArrayList<VworkflowPagamento>();
                    var wContratti = new VworkflowPagamento();
                    wContratti.Url = "ContrattiFemEPagamenti.aspx";
                    wContratti.Descrizione = "Contratti Fem e pagamenti";

                    if (DomandaPagamento.CodTipo == "SAL")
                    {
                        wContratti.Ordine = 3;
                        _workflowList.Insert(3, wContratti);

                        foreach (var flow in _workflowList.Where(w => w.Ordine >= 3 && w.Url != "ContrattiFemEPagamenti.aspx"))
                            flow.Ordine += 1;
                    }
                    else if (DomandaPagamento.CodTipo == "SLD")
                    {
                        wContratti.Ordine = 4;
                        _workflowList.Insert(4, wContratti);

                        foreach (var flow in _workflowList.Where(w => w.Ordine >= 4 && w.Url != "ContrattiFemEPagamenti.aspx"))
                            flow.Ordine += 1;
                    }

                    _workflow = new VworkflowPagamentoCollection();

                    foreach (var flow in _workflowList)
                    {
                        _workflow.Add(flow);
                    }
                }

                //Gestione workflow autovalutazione
                if (DomandaPagamento.RichiedeAutovalutazione //se è attivo il flag per l'autovalutazione nel bando
                    && !(DomandaPagamento.NaturaCup == "06" || DomandaPagamento.NaturaCup == "07")) //e se NON è un aiuto
                {
                    var _workflowList = _workflow.ToArrayList<VworkflowPagamento>();
                    var wAutovalutazione = new VworkflowPagamento();
                    wAutovalutazione.Url = "Autovalutazione.aspx";
                    wAutovalutazione.Descrizione = "Autovalutazione";
                    wAutovalutazione.Obbligatorio = true;

                    var ordine_inserimento = _workflowList.Count - 1; // lo metto sempre prima della firma
                    wAutovalutazione.Ordine = ordine_inserimento;
                    _workflowList.Insert(ordine_inserimento, wAutovalutazione);

                    foreach (var flow in _workflowList.Where(w => w.Ordine >= ordine_inserimento && w.Url != "Autovalutazione.aspx"))
                        flow.Ordine += 1;

                    _workflow = new VworkflowPagamentoCollection();

                    foreach (var flow in _workflowList)
                    {
                        _workflow.Add(flow);
                    }
                }

                WorkFlow = _workflow;

                TipoModifica = DbStaticProvider.GetPermessiOperatoreSuDomandaPagamento(DomandaPagamento.IdDomandaPagamento, Operatore.Utente.IdUtente, PagamentoProvider.DbProviderObj);
                AbilitaModifica = AbilitaModifica && !DomandaPagamento.FirmaPredisposta && TipoModifica == 2;
                if (TipoModifica == 0) throw new Exception("Non si hanno i permessi necessari alla visualizzazione della domanda di pagamento selezionata.");

            }
            catch (Exception ex) { Redirect("../PPagamento/GestioneLavori.aspx", ex.Message, true); }
            base.OnLoad(e);
        }
    }

    public class VariantePage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "progetto_varianti";
            base.OnPreInit(e);
        }

        /// <summary>
        /// progetto (integrato) in sessione 
        /// </summary>
        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        public Varianti Variante
        {
            get { return (Varianti)Session["_variante"]; }
            set { Session["_variante"] = value; }
        }

        /// <summary>
        /// provider NON in sessione
        /// </summary>
        private SiarBLL.VariantiCollectionProvider _varianteProvider;
        public SiarBLL.VariantiCollectionProvider VarianteProvider
        {
            get
            {
                if (_varianteProvider == null) _varianteProvider = new SiarBLL.VariantiCollectionProvider();
                return _varianteProvider;
            }
            set { _varianteProvider = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idVariante;
                if (int.TryParse(Request.QueryString["idvar"], out idVariante)) Variante = VarianteProvider.GetById(idVariante);
                if (Variante == null) throw new Exception("Per proseguire è necessario selezionare la variante desiderata.");
                if (Progetto == null || Progetto.IdProgetto != Variante.IdProgetto)
                    Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(Variante.IdProgetto);
                // controllo su operatore che ha inserito la domanda o sull'istruttore
                TipoModifica = DbStaticProvider.GetPermessiOperatoreSuVariante(Variante.IdVariante, Operatore.Utente.IdUtente,
                    VarianteProvider.DbProviderObj);
                AbilitaModifica = AbilitaModifica && TipoModifica == 2 && !Variante.FirmaPredisposta; ;
                if (TipoModifica == 0) throw new Exception("Non si hanno i permessi necessari alla visualizzazione della variante selezionata.");
                VworkflowVarianteCollection _workflow = new VworkflowVarianteCollection();

                VworkflowVariante riepilogo = new VworkflowVariante();
                riepilogo.Url = "Riepilogo.aspx";
                riepilogo.Ordine = 1;
                riepilogo.Descrizione = "Riepilogo";

                VworkflowVariante modifica = new VworkflowVariante();
                modifica.Url = "PianoInvestimenti.aspx";
                modifica.Ordine = 2;
                modifica.Descrizione = "Modifica investimenti";

                VworkflowVariante allegati = new VworkflowVariante();
                allegati.Url = "Allegati.aspx";
                allegati.Ordine = 3;
                allegati.Descrizione = "Allegati";               

                VworkflowVariante localizzazione = new VworkflowVariante();
                localizzazione.Url = "Localizzazione.aspx";
                localizzazione.Ordine = 4;
                localizzazione.Descrizione = "Localizzazione";

                VworkflowVariante firma = new VworkflowVariante();
                firma.Url = "FirmaRichiesta.aspx";
                firma.Ordine = 5;
                firma.Descrizione = "Firma richiesta";

                _workflow.Add(riepilogo);
                _workflow.Add(modifica);
                _workflow.Add(allegati);                
                _workflow.Add(localizzazione);
                _workflow.Add(firma);

                WorkFlow = _workflow;
            }
            catch (Exception ex) { Redirect("../../PPagamento/GestioneLavori.aspx", ex.Message, true); }
            base.OnLoad(e);
        }

        /// <summary>
        /// iter procedurale in sessione
        /// </summary>
        public VworkflowVarianteCollection WorkFlow
        {
            get
            {
                if (Session["WorkflowVariante"] != null)
                    return (VworkflowVarianteCollection)Session["WorkflowVariante"];
                return null;
            }
            set { Session["WorkflowVariante"] = value; }
        }
    }

    public class IstruttoriaVariantePage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ipagamento_varianti";
            base.OnPreInit(e);
        }
        /// <summary>
        /// progetto (integrato) in sessione 
        /// </summary>
        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        public Varianti Variante
        {
            get { return (Varianti)Session["_variante"]; }
            set { Session["_variante"] = value; }
        }

        /// <summary>
        /// provider NON in sessione
        /// </summary>
        private SiarBLL.VariantiCollectionProvider _varianteProvider;
        public SiarBLL.VariantiCollectionProvider VarianteProvider
        {
            get
            {
                if (_varianteProvider == null) _varianteProvider = new SiarBLL.VariantiCollectionProvider();
                return _varianteProvider;
            }
            set { _varianteProvider = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idVariante;
                if (int.TryParse(Request.QueryString["idvar"], out idVariante)) Variante = VarianteProvider.GetById(idVariante);
                if (Variante == null) throw new Exception("Per proseguire è necessario selezionare la variante desiderata.");
                if (Progetto == null || Progetto.IdProgetto != Variante.IdProgetto)
                    Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(Variante.IdProgetto);
                // controllo su operatore che ha inserito la domanda o sull'istruttore
                TipoModifica = DbStaticProvider.GetPermessiOperatoreSuVariante(Variante.IdVariante, Operatore.Utente.IdUtente,
                    VarianteProvider.DbProviderObj);
                //AbilitaModifica = AbilitaModifica && TipoModifica == 3;

                AbilitaModifica = (AbilitaModifica && !Variante.FirmaPredispostaRup && TipoModifica == 3) || (Variante.FirmaPredispostaRup && new SiarBLL.BandoResponsabiliCollectionProvider().
                   Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0 && Variante.SegnaturaApprovazione == null && !Variante.Annullata);

                if (TipoModifica == 0) throw new Exception("Non si hanno i permessi necessari alla visualizzazione della variante selezionata.");

                VworkflowVarianteCollection _workflow = new VworkflowVarianteCollection();

                VworkflowVariante riepilogo = new VworkflowVariante();
                riepilogo.Url = "Riepilogo.aspx";
                riepilogo.Ordine = 1;
                riepilogo.Descrizione = "Riepilogo";

                VworkflowVariante requisiti = new VworkflowVariante();
                requisiti.Url = "RequisitiSoggettivi.aspx";
                requisiti.Ordine = 2;
                requisiti.Descrizione = "Requsiti Soggettivi";

                VworkflowVariante modifica = new VworkflowVariante();
                modifica.Url = "PianoInvestimenti.aspx";
                modifica.Ordine = 3;
                modifica.Descrizione = "Modifica investimenti";

                VworkflowVariante allegati = new VworkflowVariante();
                allegati.Url = "Allegati.aspx";
                allegati.Ordine = 4;
                allegati.Descrizione = "Allegati";

                VworkflowVariante localizzazione = new VworkflowVariante();
                localizzazione.Url = "Localizzazione.aspx";
                localizzazione.Ordine = 5;
                localizzazione.Descrizione = "Localizzazione";

                VworkflowVariante firma = new VworkflowVariante();
                firma.Url = "FirmaRichiesta.aspx";
                firma.Ordine = 6;
                firma.Descrizione = "Firma richiesta";

                _workflow.Add(riepilogo);
                _workflow.Add(requisiti);
                _workflow.Add(modifica);
                _workflow.Add(allegati);
                _workflow.Add(localizzazione);
                _workflow.Add(firma);

                WorkFlow = _workflow;



            }
            catch (Exception ex) { Redirect("../../PPagamento/GestioneLavori.aspx", ex.Message, true); }
            base.OnLoad(e);
        }


        public VworkflowVarianteCollection WorkFlow
        {
            get
            {
                if (Session["WorkflowVariante"] != null)
                    return (VworkflowVarianteCollection)Session["WorkflowVariante"];
                return null;
            }
            set { Session["WorkflowVariante"] = value; }
        }
    }

    public class ImpresaPage : PrivatePage
    {
        /// <summary>
        /// impresa in sessione, solo alcuni campi sono popolati
        /// </summary>
        public SiarLibrary.Impresa Azienda
        {
            get { return (SiarLibrary.Impresa)Session["_azienda"]; }
            set { Session["_azienda"] = value; }
        }

        /// <summary>
        /// provider NON in sessione
        /// </summary>
        private SiarBLL.ImpresaCollectionProvider _impresaProvider;
        public SiarBLL.ImpresaCollectionProvider ImpresaProvider
        {
            get
            {
                if (_impresaProvider == null) _impresaProvider = new SiarBLL.ImpresaCollectionProvider();
                return _impresaProvider;
            }
            set { _impresaProvider = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int id_impresa;
                if (int.TryParse(Request.QueryString["idimp"], out id_impresa))
                    Azienda = ImpresaProvider.GetById(id_impresa);
                if (Azienda == null) 
                    throw new Exception("Per proseguire è necessario selezionare l'impresa.");
                AbilitaModifica = AbilitaModifica && Azienda.Attiva;
                this.Master.FindControl("cphContenuto").Controls.AddAt(0, LoadControl("~/controls/SezioneImpresa.ascx"));
            }
            catch (Exception ex) { Redirect("~/private/Impresa/ImpresaFind.aspx", ex.Message, true); }
            base.OnLoad(e);
        }
    }

    public class BandoPage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "bando_dettaglio";
            base.OnPreInit(e);
        }

        /// <summary>
        /// bando in sessione 
        /// </summary>
        public SiarLibrary.Bando Bando
        {
            get { return (SiarLibrary.Bando)Session["_bando"]; }
            set { Session["_bando"] = value; }
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

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idbando;
                if (int.TryParse(Request.QueryString["idb"], out idbando)) Bando = BandoProvider.GetById(idbando);
                if (Bando == null) throw new Exception("Per proseguire è necessario selezionare il bando desiderato.");
                if (Operatore.Utente.CodTipoEnte.FindValueIn("GAL", "PR") && Operatore.Utente.CodEnte != Bando.CodEnte)
                    throw new Exception("L'utente non è abilitato alla visualizzazione del bando selezionato.");
                AbilitaModifica = AbilitaModifica && (Operatore.Utente.CodEnte == "%" || new SiarBLL.BandoResponsabiliCollectionProvider().
                    Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0);
                if (AbilitaModifica) TipoModifica = (Bando.CodStato == "P" ? 2 : 3);
                this.Master.FindControl("cphContenuto").Controls.AddAt(0, LoadControl("~/controls/SezioneBando.ascx"));
            }
            catch (Exception ex) { Redirect("~/private/psr/bandi/ricerca.aspx", ex.Message, true); }
            base.OnLoad(e);
        }

        public void AggiornaLogModifica(DbProvider db)
        {
            //if (Bando.CodStato != "P") throw new Exception("Non è più possibile modificare i dati generali del bando.");
            if (Bando.CodStato == "P")
            {
                if (db == null) db = BandoProvider.DbProviderObj;
                SiarBLL.BandoStoricoCollectionProvider storico_provider = new SiarBLL.BandoStoricoCollectionProvider(db);
                SiarLibrary.BandoStorico s = storico_provider.GetById(Bando.IdStoricoUltimo);
                s.Operatore = Operatore.Utente.IdUtente;
                s.Data = DateTime.Now;
                storico_provider.Save(s);
                storico_provider = null;
                Bando = BandoProvider.GetById(Bando.IdBando);
            }
        }
    }

    public class IstruttoriaPage : PrivatePage
    {
        /// <summary>
        /// bando in sessione 
        /// </summary>
        public Bando Bando
        {
            get { return (Bando)Session["_bando"]; }
            set { Session["_bando"] = value; }
        }

        /// <summary> 
        /// progetto in sessione per modifica graduatoria progetto 
        /// </summary> 
        public Progetto ProgettoModificaGraduatoria
        {
            get { return (Progetto)Session["_progettoModifica"]; }
            set { Session["_progettoModifica"] = value; }
        }

        /// <summary> 
        /// graduatoria progetto modifica in sessione per modifica  
        /// </summary> 
        public GraduatoriaProgettoModificheRup GraduatoriaProgettoModifica
        {
            get { return (GraduatoriaProgettoModificheRup)Session["_graduatoriaProgettoModifica"]; }
            set { Session["_graduatoriaProgettoModifica"] = value; }
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

        public string DomandePresentate
        {
            get
            {
                if (string.IsNullOrEmpty(Bando.AdditionalAttributes["DomandePresentate"]))
                    Bando.AdditionalAttributes.Add("DomandePresentate", BandoProvider.GetDomandePresentate(Bando.IdBando).ToString());
                return Bando.AdditionalAttributes["DomandePresentate"];
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idbando;
                if (int.TryParse(Request.QueryString["idb"], out idbando)) Bando = BandoProvider.GetById(idbando);
                if (Bando == null || Bando.DisposizioniAttuative) throw new Exception("Per proseguire è necessario selezionare il bando desiderato.");
                if (Operatore.Utente.CodTipoEnte.FindValueIn("GAL", "PR") && Operatore.Utente.CodEnte != Bando.CodEnte)
                    throw new Exception("L'utente non è abilitato alla visualizzazione del bando selezionato.");
                if (!Bando.InteresseFiliera) this.Master.FindControl("cphContenuto").Controls.AddAt(0, LoadControl("~/controls/" +
                    (Request.FilePath.ToLower().Contains("/ipagamento/") ? "IPagamentoControl.ascx" : "SezioneIstruttoria.ascx")));
            }
            catch (Exception ex) { Redirect("~/private/psr/bandi/ricerca.aspx", ex.Message, true); }
            base.OnLoad(e);
        }
    }

    public class ControlliIrregolaritaPage : PrivatePage
    {
        public SiarLibrary.Progetto Progetto
        {
            get { return (SiarLibrary.Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        public SiarLibrary.RegistroIrregolarita Irregolarita
        {
            get { return (SiarLibrary.RegistroIrregolarita)Session["_irregolarita"]; }
            set { Session["_irregolarita"] = value; }
        }

        public SiarLibrary.RegistroRecupero Recupero
        {
            get { return (SiarLibrary.RegistroRecupero)Session["_recupero"]; }
            set { Session["_recupero"] = value; }
        }

        public SiarLibrary.DomandaDiPagamento DomandaPagamento
        {
            get { return (SiarLibrary.DomandaDiPagamento)Session["_domandaPagamento"]; }
            set { Session["_domandaPagamento"] = value; }
        }
    }

    public class ErrorePage : PrivatePage

    {

        public Bando Bando

        {

            get

            {

                if ((Bando)Session["_bando"] != null)

                    return (Bando)Session["_bando"];

                else if (Progetto != null)

                {

                    var bando = new BandoCollectionProvider().GetById(Progetto.IdBando);



                    if (bando != null)

                    {

                        Session["_bando"] = bando;

                        return (Bando)Session["_bando"];

                    }

                }



                return null;

            }

            set { Session["_bando"] = value; }

        }



        public Progetto Progetto

        {

            get { return (Progetto)Session["_progetto"]; }

            set { Session["_progetto"] = value; }

        }



        public Errore Errore

        {

            get { return (Errore)Session["_errore"]; }

            set { Session["_errore"] = value; }

        }



        protected override void OnPreInit(EventArgs e)

        {

            this.FunzioneMenu = "errori";

            base.OnPreInit(e);

        }

    }

    public class IrregolaritaErroriRinuncePage : PrivatePage
    {
        public Bando Bando
        {
            get

            {

                if ((Bando)Session["_bando"] != null)

                    return (Bando)Session["_bando"];

                else if (Progetto != null)

                {

                    var bando = new BandoCollectionProvider().GetById(Progetto.IdBando);



                    if (bando != null)

                    {

                        Session["_bando"] = bando;

                        return (Bando)Session["_bando"];

                    }

                }



                return null;

            }
            set { Session["_bando"] = value; }
        }

        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        public Irregolarita Irregolarita
        {
            get { return (Irregolarita)Session["_irregolarita"]; }
            set { Session["_irregolarita"] = value; }
        }

        public DomandaDiPagamento DomandaPagamento
        {
            get { return (DomandaDiPagamento)Session["_domandaPagamento"]; }
            set { Session["_domandaPagamento"] = value; }
        }



        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "irregolarita_errori_rinunce";
            base.OnPreInit(e);
        }
    }


    public class RevochePage : PrivatePage
    {

        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        public Revoca Revoca
        {
            get { return (Revoca)Session["_revoca"]; }
            set { Session["_revoca"] = value; }
        }



        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Revoca";
            base.OnPreInit(e);
        }
    }

    public class RinuncePage : PrivatePage
    {

        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        public Rinuncia Rinuncia
        {
            get { return (Rinuncia)Session["_rinuncia"]; }
            set { Session["_rinuncia"] = value; }
        }



        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Rinuncia";
            base.OnPreInit(e);
        }
    }

    public class RecuperoBeneficiarioPage : PrivatePage
    {

        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        public RecuperoBeneficiario RecuperoBeneficiario
        {
            get { return (RecuperoBeneficiario)Session["_recuperoBeneficiario"]; }
            set { Session["_recuperoBeneficiario"] = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "RecuperoBeneficiario";
            base.OnPreInit(e);
        }
    }

    public class FiltroChecklistVoceClassPage : PrivatePage
    {
        public FiltroChecklistVoce FiltroChecklistVoce
        {
            get { return (FiltroChecklistVoce)Session["_filtro_checklist_voce"]; }
            set { Session["_filtro_checklist_voce"] = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "filtro_checklist_voce";
            base.OnPreInit(e);
        }
    }

    public class ChecklistGenericaClassPage : PrivatePage
    {
        public ChecklistGenerica ChecklistGenerica
        {
            get { return (ChecklistGenerica)Session["_checklist_generica"]; }
            set { Session["_checklist_generica"] = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "checklist_generica";
            base.OnPreInit(e);
        }
    }

    public class VoceGenericaPage : PrivatePage
    {
        public VoceGenerica VoceGenerica
        {
            get { return (VoceGenerica)Session["_voce_generica"]; }
            set { Session["_voce_generica"] = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "voce_generica";
            base.OnPreInit(e);
        }
    }

    public class IstruttoriaPagamentoPage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ipagamento_domande";
            base.OnPreInit(e);
        }
        /// <summary>
        /// bando in sessione 
        /// </summary>
        public SiarLibrary.Bando Bando
        {
            get { return (SiarLibrary.Bando)Session["_bando"]; }
            set { Session["_bando"] = value; }
        }

        public SiarLibrary.Progetto Progetto
        {
            get { return (SiarLibrary.Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        /// <summary>
        /// Domanda di pagamento in sessione
        /// </summary>
        public DomandaDiPagamento DomandaPagamento
        {
            get { return (DomandaDiPagamento)Session["domanda_pagamento"]; }
            set { Session["domanda_pagamento"] = value; }
        }

        /// <summary>
        /// Revisione della domanda di pagamento in sessione
        /// </summary>
        //public RevisioneDomandaPagamento RevisioneDomandaPagamento
        //{
        //    get { return (RevisioneDomandaPagamento)Session["revisione_domanda_pagamento"]; }
        //    set { Session["revisione_domanda_pagamento"] = value; }
        //}

        /// <summary>
        /// Testata validazione della domanda di pagamento in sessione
        /// </summary>
        public TestataValidazione TestataValidazione
        {
            get { return (TestataValidazione)Session["testata_validazione"]; }
            set { Session["testata_validazione"] = value; }
        }

        /// <summary>
        /// provider NON in sessione
        /// </summary>
        private SiarBLL.DomandaDiPagamentoCollectionProvider _pagamentoProvider;
        public SiarBLL.DomandaDiPagamentoCollectionProvider PagamentoProvider
        {
            get
            {
                if (_pagamentoProvider == null) _pagamentoProvider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                return _pagamentoProvider;
            }
            set { _pagamentoProvider = value; }
        }

        /// <summary>
        /// provider NON in sessione
        /// </summary>
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

        public string DomandePresentate
        {
            get
            {
                if (string.IsNullOrEmpty(Bando.AdditionalAttributes["DomandePresentate"]))
                    Bando.AdditionalAttributes.Add("DomandePresentate", new SiarBLL.BandoCollectionProvider().GetDomandePresentate(Bando.IdBando).ToString());
                return Bando.AdditionalAttributes["DomandePresentate"];
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idPagamento;
                if (int.TryParse(Request.QueryString["idpag"], out idPagamento)) 
                    DomandaPagamento = PagamentoProvider.GetById(idPagamento);

                if (DomandaPagamento == null) 
                    throw new Exception("Per proseguire è necessario selezionare la domanda di pagamento desiderata.");

                if (Progetto == null || Progetto.IdProgetto != DomandaPagamento.IdProgetto)
                    Progetto = new ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);

                if (Bando == null || Bando.IdBando != Progetto.IdBando) 
                    Bando = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);

                //RevisioneDomandaPagamentoCollection revisioni = new RevisioneDomandaPagamentoCollectionProvider().Find(null, DomandaPagamento.IdDomandaPagamento, null, null, null, null);
                //if (revisioni.Count > 0)
                //    RevisioneDomandaPagamento = revisioni[0];
                //else
                //    RevisioneDomandaPagamento = null;

                var validazioni = new TestataValidazioneCollectionProvider().GetUltimaRevisioneDomandaValida(DomandaPagamento.IdDomandaPagamento);
                if (validazioni.Count > 0)
                    TestataValidazione = validazioni[0];
                else
                    TestataValidazione = null;
                        
                // controllo su operatore che ha inserito la domanda o sull'istruttore
                TipoModifica = DbStaticProvider.GetPermessiOperatoreSuDomandaPagamento(DomandaPagamento.IdDomandaPagamento,
                    ((MasterPage)Master).Operatore.Utente.IdUtente, PagamentoProvider.DbProviderObj);

                AbilitaModifica = (AbilitaModifica && !DomandaPagamento.FirmaPredispostaRup && (TipoModifica == 3 || TipoModifica == 5)) || (DomandaPagamento.FirmaPredispostaRup && new SiarBLL.BandoResponsabiliCollectionProvider().
                    Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0 && DomandaPagamento.SegnaturaApprovazione == null && !DomandaPagamento.Annullata  );
                if (TipoModifica == 0) throw new Exception("Non si hanno i permessi necessari per la visualizzazione della domanda di pagamento selezionata.");
                //this.Master.FindControl("cphContenuto").Controls.AddAt(0, LoadControl("~/controls/IPagamentoControl.ascx"));
            }
            catch (Exception ex) { Redirect("../ipagamento/selezionedomande.aspx", ex.Message, true); }
            base.OnLoad(e);
        }
    }

    public class ControlliValidazionePagePage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "validazione_domanda_pagamento";
            base.OnPreInit(e);
        }
        /// <summary>
        /// bando in sessione 
        /// </summary>
        public Bando Bando
        {
            get { return (Bando)Session["_bando"]; }
            set { Session["_bando"] = value; }
        }

        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        /// <summary>
        /// Domanda di pagamento in sessione
        /// </summary>
        public DomandaDiPagamento DomandaPagamento
        {
            get { return (DomandaDiPagamento)Session["domanda_pagamento"]; }
            set { Session["domanda_pagamento"] = value; }
        }

        /// <summary>
        /// Revisione della domanda di pagamento in sessione
        /// </summary>
        public RevisioneDomandaPagamento RevisioneDomandaPagamento
        {
            get { return (RevisioneDomandaPagamento)Session["revisione_domanda_pagamento"]; }
            set { Session["revisione_domanda_pagamento"] = value; }
        }

        /// <summary>
        /// Testata della validazione della domanda di pagamento in sessione
        /// </summary>
        public TestataValidazione TestataValidazione
        {
            get { return (TestataValidazione)Session["testata_validazione"]; }
            set { Session["testata_validazione"] = value; }
        }

        /// <summary>
        /// provider NON in sessione
        /// </summary>
        private DomandaDiPagamentoCollectionProvider _pagamentoProvider;
        public DomandaDiPagamentoCollectionProvider PagamentoProvider
        {
            get
            {
                if (_pagamentoProvider == null) _pagamentoProvider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                return _pagamentoProvider;
            }
            set { _pagamentoProvider = value; }
        }

        /// <summary>
        /// provider NON in sessione
        /// </summary>
        private ProgettoCollectionProvider _progettoProvider;
        public ProgettoCollectionProvider ProgettoProvider
        {
            get
            {
                if (_progettoProvider == null) _progettoProvider = new SiarBLL.ProgettoCollectionProvider();
                return _progettoProvider;
            }
            set { _progettoProvider = value; }
        }

        public string DomandePresentate
        {
            get
            {
                if (string.IsNullOrEmpty(Bando.AdditionalAttributes["DomandePresentate"]))
                    Bando.AdditionalAttributes.Add("DomandePresentate", new BandoCollectionProvider().GetDomandePresentate(Bando.IdBando).ToString());
                return Bando.AdditionalAttributes["DomandePresentate"];
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int idPagamento;
                if (int.TryParse(Request.QueryString["idpag"], out idPagamento)) 
                    DomandaPagamento = PagamentoProvider.GetById(idPagamento);

                if (DomandaPagamento == null) 
                    throw new Exception("Per proseguire è necessario selezionare la domanda di pagamento desiderata.");

                if (Progetto == null || Progetto.IdProgetto != DomandaPagamento.IdProgetto)
                    Progetto = new ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);

                if (Bando == null || Bando.IdBando != Progetto.IdBando) 
                    Bando = new BandoCollectionProvider().GetById(Progetto.IdBando);

                //Per ora lasciato per compatibilità pagina vecchia
                RevisioneDomandaPagamentoCollection revisioni = new RevisioneDomandaPagamentoCollectionProvider().Find(null,
                    DomandaPagamento.IdDomandaPagamento, null, null, null, null);
                if (revisioni.Count > 0)
                    RevisioneDomandaPagamento = revisioni[0];
                else
                    RevisioneDomandaPagamento = null;

                var validazioni = new TestataValidazioneCollectionProvider().GetUltimaRevisioneDomandaValida(DomandaPagamento.IdDomandaPagamento);
                if (validazioni.Count > 0)
                    TestataValidazione = validazioni[0];
                else
                    TestataValidazione = null;

                // controllo su operatore che ha inserito la domanda o sull'istruttore
                TipoModifica = DbStaticProvider.GetPermessiOperatoreSuDomandaPagamento(DomandaPagamento.IdDomandaPagamento,
                    ((MasterPage)Master).Operatore.Utente.IdUtente, PagamentoProvider.DbProviderObj);

                AbilitaModifica = (AbilitaModifica && !DomandaPagamento.FirmaPredispostaRup && TipoModifica == 3) 
                    || (DomandaPagamento.FirmaPredispostaRup 
                        && new BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0 
                        && DomandaPagamento.SegnaturaApprovazione == null && !DomandaPagamento.Annullata);

                if (TipoModifica == 0) throw new Exception("Non si hanno i permessi necessari per la visualizzazione della domanda di pagamento selezionata.");
            }
            catch (Exception ex) { Redirect(PATH_IPAGAMENTO + "selezionedomande.aspx", ex.Message, true); }
            base.OnLoad(e);
        }
    }

    public class ControlliLocoPage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "controlli_in_loco";
            base.OnPreInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Master.FindControl("cphContenuto").Controls.AddAt(0, LoadControl("~/controls/ControlliLocoControl.ascx"));
            base.OnLoad(e);
        }
    }

    public class CertificazioneSpesaPage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "certificazioni_di_spesa";
            base.OnPreInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Master.FindControl("cphContenuto").Controls.AddAt(0, LoadControl("~/controls/CertificazioneControl.ascx"));
            base.OnLoad(e);
        }
    }

    public class VisitaAziendalePage : PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "visita_aziendale";
            base.OnPreInit(e);
        }

        /// <summary>
        /// Visita aziendale in sessione
        /// </summary>
        public VisiteAziendali VisitaAziendale
        {
            get { return (VisiteAziendali)Session["visita_aziendale"]; }
            set { Session["visita_aziendale"] = value; }
        }

        /// <summary>
        /// Domanda di pagamento in sessione
        /// </summary>
        public DomandaDiPagamento DomandaPagamento
        {
            get { return (DomandaDiPagamento)Session["domanda_pagamento"]; }
            set { Session["domanda_pagamento"] = value; }
        }

        /// <summary>
        /// progetto (integrato) in sessione 
        /// </summary>
        public Progetto Progetto
        {
            get { return (Progetto)Session["_progetto"]; }
            set { Session["_progetto"] = value; }
        }

        private SiarBLL.VisiteAziendaliCollectionProvider _visiteProvider;
        public SiarBLL.VisiteAziendaliCollectionProvider VisiteProvider
        {
            get
            {
                if (_visiteProvider == null) _visiteProvider = new SiarBLL.VisiteAziendaliCollectionProvider();
                return _visiteProvider;
            }
            set { _visiteProvider = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            int idVisita;
            if (int.TryParse(Request.QueryString["idvis"], out idVisita))
            {
                VisiteAziendali visita = VisiteProvider.GetById(idVisita);
                if (visita == null) Redirect("Ricerca.aspx");
                else VisitaAziendale = visita;
            }
            if (VisitaAziendale != null)
            {
                if (DomandaPagamento == null) DomandaPagamento = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(VisitaAziendale.IdDomandaPagamento);
                else if (VisitaAziendale.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento) Redirect("Ricerca.aspx");

                if (Progetto == null) Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);
                else if (Progetto.IdProgetto != DomandaPagamento.IdProgetto) Redirect("Ricerca.aspx");

                if (AbilitaModifica)
                {
                    #region controllo su operatore che ha inserito la domanda o sull'istruttore
                    TipoModifica = DbStaticProvider.GetPermessiOperatoreSuVisitaAziendale(VisitaAziendale.IdVisita,
                        ((MasterPage)Master).Operatore.Utente.IdUtente, VisiteProvider.DbProviderObj);
                    AbilitaModifica = (TipoModifica == 2);
                    if (TipoModifica == 0) Redirect("Ricerca.aspx?action=non_abilitato");
                    #endregion
                }
            }
            else Redirect("Ricerca.aspx?action=visita_notin_session");
            base.OnLoad(e);
        }
    }

    public class SigefUserControl : UserControl
    {
        public static readonly string PATH_PPAGAMENTO = VirtualPathUtility.ToAbsolute("~/Private/PPagamento/");
        public static readonly string PATH_PVARIANTE = VirtualPathUtility.ToAbsolute("~/Private/PPagamento/Variante/");
        public static readonly string PATH_IPAGAMENTO = VirtualPathUtility.ToAbsolute("~/Private/IPagamento/");
        public static readonly string PATH_IVARIANTE = VirtualPathUtility.ToAbsolute("~/Private/IPagamento/IVariante/");
        public static readonly string PATH_IMAGES = VirtualPathUtility.ToAbsolute("~/Images/");
        public static readonly string PATH_PDOMANDA = VirtualPathUtility.ToAbsolute("~/Private/PDomanda/");
        public static readonly string PATH_VALIDAZIONELOTTI = VirtualPathUtility.ToAbsolute("~/Private/IPagamento/");
        public static readonly string PATH_ISTRUTTORIA = VirtualPathUtility.ToAbsolute("~/Private/Istruttoria/");
        public static readonly string PATH_PRIVATE = VirtualPathUtility.ToAbsolute("~/Private/");
        public static readonly string PATH_PUBLIC = VirtualPathUtility.ToAbsolute("~/Public/");
        public static readonly string PATH_PSR_BANDI = VirtualPathUtility.ToAbsolute("~/Private/Psr/Bandi/");
        public static readonly string PATH_MODIFICA = VirtualPathUtility.ToAbsolute("~/Private/ModificaDati/");
        public static readonly string PATH_CONTROLS = VirtualPathUtility.ToAbsolute("~/CONTROLS/");
        public static readonly string PATH_HOME = VirtualPathUtility.ToAbsolute("~/");
        public static readonly string PATH_ADMIN = VirtualPathUtility.ToAbsolute("~/Private/admin/");

        protected MasterPage PageMaster
        {
            get { return (MasterPage)Page.Master; }
        }

        protected Page PagePrivate
        {
            get { return (PrivatePage)Page; }
        }

        private Progetto _progetto;
        public Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        protected Operatore _operatore
        {
            get { return PageMaster.Operatore; }
        }

        public string _funzione_menu
        {
            get
            {
                if (PageMaster != null)
                    return PageMaster.GetType().GetProperty("FunzionePagina").GetValue(PageMaster, null).ToString();
                return null;
            }
            set
            {
                if (PageMaster != null)
                    PageMaster.GetType().GetProperty("FunzionePagina").SetValue(PageMaster, value, null);
            }
        }

        private bool _abilitaModifica;
        public bool AbilitaModifica
        {
            get
            {
                if (_operatore == null)
                    PageMaster.SetOperatore(new SiarLibrary.NullTypes.IntNT());
                ProfiloXFunzioniCollection pxfcoll = new ProfiloXFunzioniCollectionProvider().
                    Find(_operatore.Utente.IdProfilo, null, null, _funzione_menu, null, null, null, null);

                if (string.IsNullOrEmpty(_funzione_menu) || pxfcoll.Count == 0)
                    throw new SiarException(TextErrorCodes.UtenteSenzaPermessi);

                if (pxfcoll.Count > 0)
                    _abilitaModifica = pxfcoll[0].Modifica;

                return _abilitaModifica;
            }
            set { _abilitaModifica = value; }
        }

        protected void Redirect(string url)
        {
            OnUnload(EventArgs.Empty);
            Response.Redirect(url, true);
        }

        protected void Redirect(string url, string messaggio_onload, bool is_error)
        {
            Session["siar_session_message_onload"] = (is_error ? "-" : "+") + messaggio_onload.ToCleanJsString();
            Redirect(url);
        }
    }
}
