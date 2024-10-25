using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System.Linq;
using System.Web;
using System.Configuration;
using SiarLibrary.Extensions;

public partial class ucChecklistGenerica : UserControl
{
    DbProvider dbProvider = new DbProvider();

    private EsitoIstanzaChecklistGenericoCollectionProvider esiti_provider = new EsitoIstanzaChecklistGenericoCollectionProvider();
    private IstanzaChecklistGenericaCollectionProvider istanza_provider = new IstanzaChecklistGenericaCollectionProvider();
    private VoceXChecklistGenericaCollectionProvider voci_x_check_provider = new VoceXChecklistGenericaCollectionProvider();
    private ChecklistGenericaCollectionProvider checklist_provider = new ChecklistGenericaCollectionProvider();
    private SchedaXChecklistCollectionProvider schede_x_checklist_provider = new SchedaXChecklistCollectionProvider();
    private VoceXChecklistGenericaCollection voci_x_check_collection;
    private EsitoIstanzaChecklistGenericoCollection esiti_collection;

    private bool colValoreVisibile = false;
    private bool colValoreMinVisibile = false;
    private bool colValoreMaxVisibile = false;

    #region Indici colonne datagrid

    private int col_Num = 0,
        col_Descrizione = 1,
        col_Commento = 2,
        col_Obbligatorio = 3,
        col_Esito = 4,
        col_Valore = 5,
        col_ValMinimo = 6,
        col_ValMassimo = 7,
        col_Azione = 8,
        col_Note = 9;

    #endregion

    public bool NoteColumnVisible
    {
        set { dgVociXCheck.Columns[col_Note].Visible = value; dgVociXCheck.Style["width"] = "800px"; }
    }

    public bool ButtonSalvaSchedaVisibile
    {
        set { btnSalvaScheda.Visible = value; }
    }

    private bool _mostraOperazioniMassive;
    public bool MostraOperazioniMassive
    {
        get { return _mostraOperazioniMassive; }
        set { _mostraOperazioniMassive = value; }
    }

    private string _defaultRedirect;
    public string DefaultRedirect
    {
        get { return _defaultRedirect; }
        set { _defaultRedirect = value; }
    }

    /// <summary>
    /// Codice della Fase procedurale associata alla checklist
    /// </summary>
    private string _Fase;
    public string Fase
    {
        get { return _Fase; }
        set { _Fase = value; }
    }

    /// <summary>
    /// Codice dello stato in cui il progetto deve trovarsi affinchè 
    /// sia abilitata la verifica della checklist
    /// </summary>
    private string _Stato;
    public string Stato
    {
        get { return _Stato; }
        set { _Stato = value; }
    }

    private bool _revisione = false;
    public bool Revisione
    {
        get { return _revisione; }
        set { _revisione = value; }
    }

    private Progetto _progetto;
    public Progetto Progetto
    {
        get { return _progetto; }
        set { _progetto = value; }
    }

    private IntNT _idCheckList;
    public IntNT IdCheckList
    {
        get { return _idCheckList; }
        set { _idCheckList = value; }
    }

    private IntNT _idDomandaPagamento;
    public IntNT IdDomandaPagamento
    {
        get { return _idDomandaPagamento; }
        set { _idDomandaPagamento = value; }
    }

    private IstanzaChecklistGenerica _istanzaCheckListPadre;
    public IstanzaChecklistGenerica IstanzaCheckListPadre
    {
        get { return _istanzaCheckListPadre; }
        set { _istanzaCheckListPadre = value; }
    }

    private IstanzaChecklistGenerica _istanzaCheckListGenerica;
    public IstanzaChecklistGenerica IstanzaCheckListGenerica
    {
        get { return _istanzaCheckListGenerica; }
        set { _istanzaCheckListGenerica = value; }
    }

    private ChecklistGenerica _checkListGenerica;
    public ChecklistGenerica CheckListGenerica
    {
        get { return _checkListGenerica; }
        set { _checkListGenerica = value; }
    }

    private IntNT _idTestataChecklist;
    public IntNT IdTestataChecklist
    {
        get { return _idTestataChecklist; }
        set { _idTestataChecklist = value; }
    }

    /// <summary>
    /// elenco degli step della checklist che contengono un url per la modifica dei dati
    /// </summary>
    public ArrayList StepDiReindirizzamento
    {
        get
        {
            ArrayList _stepDiReindirizzamento = new ArrayList();

            if (voci_x_check_collection != null)
            {
                foreach (VoceXChecklistGenerica cxs in voci_x_check_collection)
                    if (cxs.UrlVoce != null)
                        if (!_stepDiReindirizzamento.Contains(cxs.UrlVoce.Value))
                            _stepDiReindirizzamento.Add(cxs.UrlVoce.Value);
            }
            return _stepDiReindirizzamento;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (_istanzaCheckListGenerica == null)
        {
            voci_x_check_collection = new VoceXChecklistGenericaCollection();
        }
        else
        {
            _idCheckList = _istanzaCheckListGenerica.IdChecklistGenerica;
            _checkListGenerica = checklist_provider.GetById(_idCheckList);
            string tabNames = "";

            if (!_mostraOperazioniMassive)
                divOperazioniMassive.Visible = false;
            else
                lstEsitoMassivo.DataBind();

            if (!_checkListGenerica.ContieneVociTipo && !_checkListGenerica.SchedaTipo) //se checklist di schede
            {
                var schede_collection = schede_x_checklist_provider.Find(null, _idCheckList, null);
                if (schede_collection.Count == 0)
                    throw new Exception("Nessuna scheda associata alla checklist");

                var testata_provider = new TestataValidazioneCollectionProvider();

                foreach (SchedaXChecklist scheda in schede_collection)
                {
                    var checklist_scheda = checklist_provider.GetById(scheda.IdChecklistFiglio);
                    tabNames += testata_provider.GetDescrizioneTab(checklist_scheda.Descrizione) + "|";
                }

                tabNames = tabNames.Substring(0, tabNames.Length - 1);

                var checklist_selezionata = checklist_provider.GetById(schede_collection[ucSiarNewTab.TabSelected - 1].IdChecklistFiglio);
                                
                var scheda_selezionata = schede_collection
                    .ToArrayList<SchedaXChecklist>()
                    .Where(s => s.Ordine == ucSiarNewTab.TabSelected)
                    .First<SchedaXChecklist>();

                _istanzaCheckListGenerica = istanza_provider.Find(null, checklist_selezionata.IdChecklistGenerica, null, _istanzaCheckListPadre.IdChecklistGenerica, scheda_selezionata.IdSchedaXChecklist)[0];

                voci_x_check_collection = voci_x_check_provider.GetStepByChecklist(checklist_selezionata.IdChecklistGenerica, null);

                esiti_collection = esiti_provider.Find(_istanzaCheckListGenerica.IdIstanzaGenerica, null, null, null, null);

                txtDescrizioneChecklist.Text = checklist_selezionata.Descrizione;
            }
            else if (_checkListGenerica.SchedaTipo) //se scheda 
                throw new Exception("Non è possibile utilizzare una scheda come una checklist di voci");
            else //se checklist normale
            {
                tabNames = _checkListGenerica.Descrizione;

                var checklist_selezionata = _checkListGenerica;
                voci_x_check_collection = voci_x_check_provider.GetStepByChecklist(_idCheckList, null); //steps = cxs_provider.Find(_idCheckList, null, null, null, null, null, null);
                esiti_collection = esiti_provider.Find(_istanzaCheckListGenerica.IdIstanzaGenerica, null, null, null, null); //esiti_progetto = iter_provider.Find(_progetto.IdProgetto, null, null, null, _progetto.IdBando, _Fase, null);

                if (_mostraOperazioniMassive)
                    btnEsitoMassivo.Visible = false;

                txtDescrizioneChecklist.Visible = false;
            }

            ucSiarNewTab.TabNames = tabNames;
            //ucAccordion.DivNames = tabNames;
            //ucAccordion.Contenuto = divContenitoreChecklist;

            // Esecuzione Code Method            
            if (IsPostBack && Request.Form["__EVENTTARGET"] == "ExecuteStepMethod")
            {
                string codeMethodName = Request.Form["__EVENTARGUMENT"].Substring(0, Request.Form["__EVENTARGUMENT"].IndexOf("_"));
                string IdVoce = Request.Form["__EVENTARGUMENT"].Replace(codeMethodName + "_", string.Empty);
                EseguiMetodoVoce(codeMethodName, Convert.ToInt32(IdVoce));
            }
        }

        btnSalvaScheda.Click += btnSalvaScheda_Click;
    }

    protected override void OnPreRender(EventArgs e)
    {
        colValoreVisibile = false;
        colValoreMinVisibile = false;
        colValoreMaxVisibile = false;

        #region Precedentemente in Page_Load

        

        #endregion

        dgVociXCheck.DataSource = voci_x_check_collection;
        dgVociXCheck.DataBind();

        dgVociXCheck.Columns[col_Valore].Visible = colValoreVisibile;
        dgVociXCheck.Columns[col_ValMinimo].Visible = colValoreMinVisibile;
        dgVociXCheck.Columns[col_ValMassimo].Visible = colValoreMaxVisibile;

        base.OnPreRender(e);
    }

    public string VerificaChecklist()
    {
        string esito = "SI";

        try
        {
            // ricalcolo i valori
            foreach (VoceXChecklistGenerica cxs in voci_x_check_collection)
            {
                if(!cxs.TitoloVoce)
                {
                    EsitoIstanzaChecklistGenerico esitoIstanza = null;
                    var esiti_collection = esiti_provider.GetByIstanzaAndVoce(_istanzaCheckListGenerica.IdIstanzaGenerica, cxs.IdVoceGenerica);
                    if (esiti_collection.Count > 0)
                        esitoIstanza = esiti_collection[0];

                    if (esitoIstanza == null)
                        insertEsitoIstanza(cxs);
                    else
                    {
                        string esitoStep = calcolaEsitoVoce(cxs);
                        // condizione per l'aggiornamento dell'esito: se non e' uno step con codemetod
                        if (cxs.CodeMethodVoce == null)
                            verificaValoreEsitoStep(cxs, esitoStep, esitoIstanza);

                        esitoIstanza.DataModifica = DateTime.Now;
                        esitoIstanza.CfModifica = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
                        esitoIstanza.Note = Request.Form["txtAreaLungaCKL" + cxs.IdVoceGenerica + "_text"];
                        //iterprogetto.Revisione = _revisione;
                        esiti_provider.Save(esitoIstanza);
                    }
                }
                //SiarLibrary.IterProgetto iterprogetto = esiti_progetto.CollectionGetById(_progetto.IdProgetto, cxs.IdVoceGenerica);
            }
            //controllo se positivi
            //esiti_progetto = iter_provider.Find(_progetto.IdProgetto, null, null, null, _progetto.IdBando, _Fase, null);
            foreach (VoceXChecklistGenerica cxs in voci_x_check_collection)
            {
                if (!cxs.TitoloVoce)
                {
                    //SiarLibrary.IterProgetto iter = esiti_progetto.CollectionGetById(_progetto.IdProgetto, cxs.IdVoceGenerica);
                    EsitoIstanzaChecklistGenerico esitoIstanza = null;
                    var esiti_collection = esiti_provider.GetByIstanzaAndVoce(_istanzaCheckListGenerica.IdIstanzaGenerica, cxs.IdVoceGenerica);
                    if (esiti_collection.Count > 0)
                        esitoIstanza = esiti_collection[0];

                    //modificato per gestire il valore vuoto sulla combo degli esiti degli step
                    //bool esito_positivo = (esitoIstanza != null && esitoIstanza.CodEsito != null && esitoIstanza.EsitoPositivoRevisore != null && esitoIstanza.EsitoPositivoRevisore);
                    bool esito_positivo = (esitoIstanza.CodEsito != null && esitoIstanza.EsitoPositivo != null && esitoIstanza.EsitoPositivo);

                    if (cxs.Obbligatorio && !esito_positivo)
                    {
                        esito = "NO";
                        break;
                    }
                }
            }
        }
        catch (Exception ex) { esito = ex.Message; }
        return esito;
    }

    public string VerificaChecklistDiSchede()
    {
        string esito = "SI";

        try
        {
            if (!_checkListGenerica.ContieneVociTipo && !_checkListGenerica.SchedaTipo) //se checklist di schede
            {
                var schede_collection = schede_x_checklist_provider.Find(null, _checkListGenerica.IdChecklistGenerica, null);
                if (schede_collection.Count == 0)
                    throw new Exception("Nessuna scheda associata alla checklist");

                foreach (SchedaXChecklist scheda in schede_collection)
                {
                    var checklist_scheda = checklist_provider.GetById(scheda.IdChecklistFiglio);
                    var voci_x_check_scheda_collection = voci_x_check_provider.GetStepByChecklist(checklist_scheda.IdChecklistGenerica, null);

                    // ricalcolo i valori
                    foreach (VoceXChecklistGenerica cxs in voci_x_check_scheda_collection)
                    {
                        if (!cxs.TitoloVoce)
                        {
                            EsitoIstanzaChecklistGenerico esitoIstanza = null;
                            var esiti_collection = esiti_provider.GetByIstanzaAndVoce(_istanzaCheckListGenerica.IdIstanzaGenerica, cxs.IdVoceGenerica);
                            if (esiti_collection.Count > 0)
                                esitoIstanza = esiti_collection[0];

                            if (esitoIstanza == null)
                                insertEsitoIstanza(cxs);
                            else
                            {
                                string esitoStep = calcolaEsitoVoce(cxs);
                                // condizione per l'aggiornamento dell'esito: se non e' uno step con codemetod
                                if (cxs.CodeMethodVoce == null)
                                    verificaValoreEsitoStep(cxs, esitoStep, esitoIstanza);

                                esitoIstanza.DataModifica = DateTime.Now;
                                esitoIstanza.CfModifica = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
                                esitoIstanza.Note = Request.Form["txtAreaLungaCKL" + cxs.IdVoceGenerica + "_text"];
                                esiti_provider.Save(esitoIstanza);
                            }
                        }
                    }

                    //controllo se positivi
                    foreach (VoceXChecklistGenerica cxs in voci_x_check_scheda_collection)
                    {
                        if (!cxs.TitoloVoce)
                        {
                            EsitoIstanzaChecklistGenerico esitoIstanza = null;
                            var esiti_collection = esiti_provider.GetByIstanzaAndVoce(_istanzaCheckListGenerica.IdIstanzaGenerica, cxs.IdVoceGenerica);
                            if (esiti_collection.Count > 0)
                                esitoIstanza = esiti_collection[0];

                            //modificato per gestire il valore vuoto sulla combo degli esiti degli step
                            bool esito_positivo = (esitoIstanza.CodEsito != null && esitoIstanza.EsitoPositivo != null && esitoIstanza.EsitoPositivo);

                            if (cxs.Obbligatorio && !esito_positivo)
                            {
                                esito = "NO";
                                break;
                            }
                        }
                    }
                }
            }
            else if (_checkListGenerica.SchedaTipo) //se scheda 
                esito = "Non è possibile verificare una scheda come una checklist di voci";
            else //se checklist normale
                esito = VerificaChecklist();
        }
        catch (Exception ex)
        {
            esito = ex.Message;
        }

        return esito;
    }

    private void verificaValoreEsitoStep(VoceXChecklistGenerica cxs, string esitoStep, EsitoIstanzaChecklistGenerico esitoIstanza)
    {
        if (esitoStep.Equals("SI") || esitoStep.Equals("NO") || esitoStep.Equals("ND"))
        {
            esitoIstanza.CodEsito = esitoStep;
            esitoIstanza.Valore = null;
        }
        else
        {
            if (esitoStep == null
                || esitoStep.Equals("")
                || (esitoStep != null && !esitoStep.Equals("") && cxs.ValEsitoNegativoVoce != null && cxs.ValEsitoNegativoVoce))
                esitoIstanza.CodEsito = "NO";
            else
                esitoIstanza.CodEsito = "SI";
            esitoIstanza.Valore = esitoStep;
        }
    }

    private void insertEsitoIstanza(VoceXChecklistGenerica cxs)
    {
        var esitoistanza = new EsitoIstanzaChecklistGenerico();
        esitoistanza.IdVoceGenerica = cxs.IdVoceGenerica;
        esitoistanza.IdIstanzaGenerica = _istanzaCheckListGenerica.IdIstanzaGenerica;
        if (cxs.CodeMethodVoce == null)
        {
            //esitoistanza.CodEsito = calcolaEsitoVoce(cxs);
            string codice_esito = calcolaEsitoVoce(cxs);
            verificaValoreEsitoStep(cxs, codice_esito, esitoistanza);
        }
        else 
            esitoistanza.CodEsito = "NO"; // in insert il metodo step non e' stato eseguito quindi imposto l'esito negativo
        esitoistanza.DataInserimento = DateTime.Now;
        esitoistanza.CfInserimento = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
        esitoistanza.Note = Request.Form["txtAreaLungaCKL" + cxs.IdVoceGenerica + "_text"];
        //iterprogetto.Revisione = _revisione;
        esiti_provider.Save(esitoistanza);
    }

    private string calcolaEsitoVoce(VoceXChecklistGenerica voce)
    {
        if (voce.AutomaticoVoce)
        {
            string res_verifica = VerificaVoceAutomatico(voce);
            bool res_bool;
            if (bool.TryParse(res_verifica, out res_bool))
                return (res_bool ? "SI" : "NO");
            return res_verifica;
        }
        else
        {
            string retval = null;
            //cerco l'hidden che come valore ha l'uniqueid della combo corrispondente allo step
            string nome_hidden = "hdnEsitoVoce" + voce.IdVoceGenerica;

            foreach (string s in Request.Form.AllKeys)
            {
                if (s.EndsWith(nome_hidden))
                {
                    //trovo il valore selezionato della combo 
                    string id_combo = Request.Form[s];
                    retval = Request.Form[id_combo];
                    break;
                }
            }
            return retval;
        }
    }

    /// <summary>
    /// Esegue il metodo previsto dallo Step automatico
    /// </summary>
    /// <param name="codeMethodName"></param>
    /// <param name="IdStep"></param>
    /// 
    private void EseguiMetodoVoce(string codeMethodName, int IdVoce)
    {
        try
        {
            //SiarLibrary.IterProgetto iter = iter_provider.GetById(_progetto.IdProgetto, IdStep);
            EsitoIstanzaChecklistGenerico esitoIstanza = null;
            var esiti_collection = esiti_provider.GetByIstanzaAndVoce(_istanzaCheckListGenerica.IdIstanzaGenerica, IdVoce);
            if (esiti_collection.Count > 0) 
                esitoIstanza = esiti_collection[0];

            if (esitoIstanza == null)
            {
                esitoIstanza = new EsitoIstanzaChecklistGenerico();
                esitoIstanza.IdIstanzaGenerica = _istanzaCheckListGenerica.IdIstanzaGenerica;
                esitoIstanza.IdVoceGenerica = IdVoce;
            }
            // Eseguo il metodo via reflection
            Assembly actionsAssembly = Assembly.LoadFrom(Server.MapPath("../../bin/SiarActions.dll"));
            Type actionsClassType = actionsAssembly.GetType("SiarActions.StepProvider");
            object esito = actionsClassType.InvokeMember(codeMethodName, BindingFlags.Default | BindingFlags.InvokeMethod,
                                                         null, actionsClassType, new object[] { _progetto.IdProgetto.Value });
            SiarActions.StepResult risultato = (SiarActions.StepResult)esito;
            esitoIstanza.DataModifica = DateTime.Now;
            esitoIstanza.CfModifica = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
            esitoIstanza.CodEsito = (risultato.Esito ? "SI" : "NO");
            //iter.Note=
            //iter.Revisione = _revisione;
            esiti_provider.Save(esitoIstanza);
            if (risultato.Esito)
                ((SiarLibrary.Web.PrivatePage)Page).ShowMessage(risultato.Descrizione);
            else 
                ((SiarLibrary.Web.PrivatePage)Page).ShowError("L'esecuzione dell'azione per lo step selezionato non e' andata a buon fine.<br />Dettaglio errore: " + risultato.Descrizione);
        }
        catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex.Message); }
    }

    /// <summary>
    /// Esegue la query per la verifica di uno step automatico
    /// </summary>
    /// <param name="step"></param>
    /// <returns>True se lo step è verificato</returns>
    private string VerificaVoceAutomatico(VoceXChecklistGenerica voce)
    {
        try
        {
            string queryResult = "";

            if (!string.IsNullOrEmpty(voce.QuerySqlVoce))
            {
                #region eseguo la query

                System.Data.IDbCommand cmd = dbProvider.GetCommand();
                cmd.CommandText = voce.QuerySqlVoce;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdProgetto", _progetto.IdProgetto.Value));

                if (IdDomandaPagamento != null)
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdDomandaPagamento", IdDomandaPagamento.Value));

                if (IdTestataChecklist != null)
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdTestataControlliLoco", IdTestataChecklist.Value));

                dbProvider.InitDatareader(cmd);
                if (dbProvider.DataReader.Read())
                {
                    //Decimal.TryParse(dbProvider.DataReader.GetValue(0).ToString(), out queryResult);
                    queryResult = dbProvider.DataReader.GetValue(0).ToString();

                    // verifico se sono le voci degli importi delle irregolarità per i controlli in loco 
                    // se lo sono, devo sostituire il . con la , perché non le converte correttamente in decimal
                    if (voce.DescrizioneChecklist.StartsWith("Controlli in loco")
                        && (voce.DescrizioneVoce == "Importo non concesso irregolare"
                            || voce.DescrizioneVoce == "Importo non ammesso irregolare")
                        //&& (voce.IdVoceGenerica == 14 //Importo non concesso irregolare
                        //    || voce.IdVoceGenerica == 46 //Importo non concesso irregolare
                        //    || voce.IdVoceGenerica == 13 //Importo non ammesso irregolare
                        //    || voce.IdVoceGenerica == 45) //Importo non ammesso irregolare
                        )
                        queryResult = queryResult.Replace(".", ","); 
                }

                // Possono essere ritornati più recordset -> L'ultimo rappresenta il risultato dello Step
                while (dbProvider.DataReader.NextResult())
                {
                    if (dbProvider.DataReader.Read()) 
                        //Decimal.TryParse(dbProvider.DataReader.GetValue(0).ToString(), out queryResult);
                        queryResult = dbProvider.DataReader.GetValue(0).ToString();
                }
                dbProvider.Close();

                #endregion

                if (voce.ValMinimoVoce == null && voce.ValMassimoVoce == null)
                {
                    string res_string = queryResult.ToString();
                    bool res_bool;
                    decimal res_double;
                    if (bool.TryParse(res_string, out res_bool))
                        return res_bool.ToString();
                    if (decimal.TryParse(res_string, out res_double))
                        return res_double.ToString();
                    return res_string;
                    //return bool.Parse();
                }
                else
                {
                    // Il valore ritornato dalla query deve essere compreso tra i valori Min e Max possibili
                    decimal valoreMin;
                    decimal valoreMax;
                    decimal queryResultDecimal;
                    Decimal.TryParse(voce.ValMinimoVoce, out valoreMin);
                    Decimal.TryParse(voce.ValMassimoVoce, out valoreMax);
                    Decimal.TryParse(queryResult, out queryResultDecimal);

                    if (voce.ValMinimoVoce == null && voce.ValMassimoVoce != null)
                    {
                        if (queryResultDecimal <= valoreMax) return "true";
                        else return "false";
                    }
                    else if (voce.ValMinimoVoce != null && voce.ValMassimoVoce == null)
                    {
                        if (queryResultDecimal >= valoreMin) return "true";
                        else return "false";
                    }
                    else if (voce.ValMassimoVoce != null && voce.ValMinimoVoce != null)
                    {
                        if (queryResultDecimal >= valoreMin && queryResultDecimal <= valoreMax) return "true";
                        else return "false";
                    }
                    else return "false";
                }
            }
            return "false";
        }
        catch { return "false"; }
    }

    protected void btnSalvaScheda_Click(object sender, EventArgs e)
    {
        try
        {
            string esito = VerificaChecklist();

            ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Dati salvati correttamente");
        }
        catch (Exception ex)
        {
            ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex.Message);
        }
    }

    protected void btnEsitoMassivoScheda_Click(object sender, EventArgs e)
    {
        try
        {
            esiti_provider = new EsitoIstanzaChecklistGenericoCollectionProvider();
            esiti_provider.DbProviderObj.BeginTran();
            var voce_provider = new VoceGenericaCollectionProvider(esiti_provider.DbProviderObj);

            var esiti_collection_save = new EsitoIstanzaChecklistGenericoCollection();

            var esitoStep = lstEsitoMassivo.SelectedValue;

            if (esitoStep.Equals("SI") || esitoStep.Equals("NO") || esitoStep.Equals("ND"))
            {
                foreach (VoceXChecklistGenerica voceXCheck in voci_x_check_collection)
                {
                    var voce = voce_provider.GetById(voceXCheck.IdVoceGenerica);

                    if (voce.Automatico == null || !voce.Automatico)
                    {
                        var esiti_collection = esiti_provider.GetByIstanzaAndVoce(_istanzaCheckListGenerica.IdIstanzaGenerica, voce.IdVoceGenerica);

                        EsitoIstanzaChecklistGenerico esito;

                        if (esiti_collection.Count > 0)
                            esito = esiti_collection[0];
                        else
                        {
                            esito = new EsitoIstanzaChecklistGenerico();
                            esito.DataInserimento = DateTime.Now;
                            esito.CfInserimento = ((SiarLibrary.Web.PrivatePage)Page).Operatore.Utente.CfUtente;
                            esito.IdIstanzaGenerica = _istanzaCheckListGenerica.IdIstanzaGenerica;
                            esito.IdVoceGenerica = voce.IdVoceGenerica;
                            esito.Note = null;
                        }

                        esito.CodEsito = esitoStep;
                        esito.Valore = null;
                        esito.DataModifica = DateTime.Now;
                        esito.CfModifica = ((SiarLibrary.Web.PrivatePage)Page).Operatore.Utente.CfUtente;
                        esiti_collection_save.Add(esito);
                    }
                }

                esiti_provider.SaveCollection(esiti_collection_save);
            }
            else
                throw new Exception("Valore non valido");

            esiti_provider.DbProviderObj.Commit();

            ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Dati scheda salvati correttamente");
        }
        catch (Exception ex)
        {
            esiti_provider.DbProviderObj.Rollback();
            ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex.Message);
        }
    }

    protected void btnEsitoMassivo_Click(object sender, EventArgs e)
    {
        try
        {
            esiti_provider = new EsitoIstanzaChecklistGenericoCollectionProvider();
            esiti_provider.DbProviderObj.BeginTran();

            var esitoStep = lstEsitoMassivo.SelectedValue;

            var voce_provider = new VoceGenericaCollectionProvider(esiti_provider.DbProviderObj);

            var esiti_collection_save = new EsitoIstanzaChecklistGenericoCollection();

            if (esitoStep.Equals("SI") || esitoStep.Equals("NO") || esitoStep.Equals("ND"))
            {
                if (!_checkListGenerica.ContieneVociTipo && !_checkListGenerica.SchedaTipo) //se checklist di schede
                {
                    var schede_collection = schede_x_checklist_provider.Find(null, _idCheckList, null);
                    if (schede_collection.Count == 0)
                        throw new Exception("Nessuna scheda associata alla checklist");

                    foreach (SchedaXChecklist scheda in schede_collection)
                    {
                        var checklist_scheda = checklist_provider.GetById(scheda.IdChecklistFiglio);
                        _istanzaCheckListGenerica = istanza_provider.Find(null, checklist_scheda.IdChecklistGenerica, null, _istanzaCheckListPadre.IdChecklistGenerica, scheda.IdSchedaXChecklist)[0];
                        voci_x_check_collection = voci_x_check_provider.GetStepByChecklist(checklist_scheda.IdChecklistGenerica, null);

                        foreach (VoceXChecklistGenerica voceXCheck in voci_x_check_collection)
                        {
                            var voce = voce_provider.GetById(voceXCheck.IdVoceGenerica);

                            if (voce.Automatico == null || !voce.Automatico)
                            {
                                var esiti_collection = esiti_provider.GetByIstanzaAndVoce(_istanzaCheckListGenerica.IdIstanzaGenerica, voce.IdVoceGenerica);

                                EsitoIstanzaChecklistGenerico esito;

                                if (esiti_collection.Count > 0)
                                    esito = esiti_collection[0];
                                else
                                {
                                    esito = new EsitoIstanzaChecklistGenerico();
                                    esito.DataInserimento = DateTime.Now;
                                    esito.CfInserimento = ((SiarLibrary.Web.PrivatePage)Page).Operatore.Utente.CfUtente;
                                    esito.IdIstanzaGenerica = _istanzaCheckListGenerica.IdIstanzaGenerica;
                                    esito.IdVoceGenerica = voce.IdVoceGenerica;
                                    esito.Note = null;
                                }

                                esito.CodEsito = esitoStep;
                                esito.Valore = null;
                                esito.DataModifica = DateTime.Now;
                                esito.CfModifica = ((SiarLibrary.Web.PrivatePage)Page).Operatore.Utente.CfUtente;
                                esiti_collection_save.Add(esito);
                            }
                        }

                        esiti_provider.SaveCollection(esiti_collection_save);
                    }

                    //metto l'ultima scheda come attiva per evitare il problema di caricamento degli esiti
                    schede_collection = schede_x_checklist_provider.Find(null, _idCheckList, null);
                    ucSiarNewTab.TabSelected = schede_collection.Count;
                }
                else
                    throw new Exception("La checklist non contiene schede");
            }
            else
                throw new Exception("Valore non valido");

            esiti_provider.DbProviderObj.Commit();

            ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Dati checklist salvati correttamente");
        }
        catch (Exception ex)
        {
            esiti_provider.DbProviderObj.Rollback();
            ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex.Message);
        }
    }

    int conteggio = 1;
    protected void dgVociXCheck_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            VoceXChecklistGenerica voce_x_check = (VoceXChecklistGenerica)dgi.DataItem;
            EsitoIstanzaChecklistGenerico esitoIstanza = null;
            
            if (voce_x_check.CommentoVoce != null)
            {
                string mouseOver =
                @"var tooltipText = this.title; " +
                "var toolTipContainer = document.createElement(\"SPAN\"); " +
                "var textNode = document.createTextNode(tooltipText); " +
                "toolTipContainer.appendChild(textNode); " +
                "this.parentNode.insertBefore(toolTipContainer, this.nextSibling); " +
                "toolTipContainer.className = \"customTooltipCss\"; this.title = \"\"; ";

                string mouseOut =
                    @"var controlText = this.nextSibling.childNodes[0].nodeValue; " +
                    "this.parentNode.removeChild(this.nextSibling); " +
                    "this.title = controlText; ";

                //string commento = "<span title=\"COMMENTO\">VALORE</span>";
                string commento = "<span title=\"COMMENTO\" onmouseover='" + mouseOver + "' onmouseout='" + mouseOut + "'>VALORE</span>";
                string cv = voce_x_check.CommentoVoce.ToString().Replace("\"\"", "`");
                commento = commento.Replace("COMMENTO", cv); //.ToString().Replace("\"\"", "`")
                commento = commento.Replace("VALORE", voce_x_check.DescrizioneVoce);
                dgi.Cells[col_Descrizione].Text = commento;

                //string immagine = "<img src='" + VirtualPathUtility.ToAbsolute("~/Images/") + "ifInfo24.png' id='img" + voce_x_check.IdVoceGenerica
                //    + "' style=\" width: 23px; height: 23px;\" title='" + voce_x_check.CommentoVoce + "' />";
                string immagine = "<img src='" + VirtualPathUtility.ToAbsolute("~/Images/") + "ifInfo24.png' id='img" + voce_x_check.IdVoceGenerica
                    + "' style=\" width: 23px; height: 23px;\" title='" + voce_x_check.CommentoVoce + "' onmouseover='" + mouseOver + "' onmouseout='" + mouseOut + "' />";
                dgi.Cells[col_Commento].Text = immagine;
            }
            else
                dgi.Cells[col_Commento].Text = string.Empty;

            if (voce_x_check.TitoloVoce != null && !voce_x_check.TitoloVoce)
            {
                dgi.Cells[col_Num].Text = conteggio.ToString();
                conteggio++;

                var esiti_collection = esiti_provider.GetByIstanzaAndVoce(_istanzaCheckListGenerica.IdIstanzaGenerica, voce_x_check.IdVoceGenerica);
                if (esiti_collection.Count > 0)
                    esitoIstanza = esiti_collection[0];
                SiarLibrary.Web.ComboSiNo comboEsitoVoce = (SiarLibrary.Web.ComboSiNo)dgi.Cells[3].FindControl("lstEsitoVoce");

                if (comboEsitoVoce != null)
                {
                    #region hidden con nome combo
                    HtmlInputHidden hdn = new HtmlInputHidden();
                    //hdn.Attributes.Add("runat", "server");
                    hdn.ID = "hdnEsitoVoce" + voce_x_check.IdVoceGenerica;
                    hdn.Value = comboEsitoVoce.UniqueID;
                    dgi.Cells[col_Esito].Controls.Add(hdn);
                    #endregion
                }

                #region textarea note
                if (esitoIstanza != null)
                {
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.LoadXml(dgi.Cells[col_Note].Text);
                    System.Xml.XmlNode nodo = doc.GetElementsByTagName("textarea").Item(0);
                    nodo.InnerText = esitoIstanza.Note;
                    dgi.Cells[col_Note].Text = doc.InnerXml;
                }
                #endregion

                #region Url
                if (!string.IsNullOrEmpty(voce_x_check.UrlVoce))
                {
                    HyperLink newHL = new HyperLink();
                    newHL.Text = "Pagina di modifica dei dati";
                    string url = voce_x_check.UrlVoce;
                    if (_progetto != null && _progetto.IdProgetto != null)
                        url += "&iddom=" + _progetto.IdProgetto;
                    if (_idDomandaPagamento != null)
                        url += "&idpag=" + _idDomandaPagamento;
                    newHL.NavigateUrl = url;
                    dgi.Cells[col_Azione].Controls.Add(newHL);
                }
                #endregion

                if (voce_x_check.AutomaticoVoce != null && voce_x_check.AutomaticoVoce)
                {
                    dgi.Cells[col_Esito].Text = string.Empty; // nascondo la combo
                                                      // Rendering Esito Step Verificato
                    if (esitoIstanza != null)
                    {
                        string colore_testo_verde = "<span style=\"color: #0b9007;\">VALORE</span>";
                        string colore_testo_rosso = "<span style=\"color: #be0202;\">VALORE</span>";

                        if (esitoIstanza.CodEsito == "SI")
                            dgi.Cells[col_Esito].Text = colore_testo_verde.Replace("VALORE", "SI");
                        else if (esitoIstanza.CodEsito == "NO")
                            dgi.Cells[col_Esito].Text = colore_testo_rosso.Replace("VALORE", "NO");
                        else
                            dgi.Cells[col_Esito].Text = esitoIstanza.CodEsito;

                        if (esitoIstanza.Valore != null)
                        {
                            double val_double;
                            if (double.TryParse(esitoIstanza.Valore, out val_double))
                            {
                                var val_double_currency = string.Format("{0:c}", val_double);

                                if (esitoIstanza.CodEsito == "SI")
                                    dgi.Cells[col_Valore].Text = colore_testo_verde.Replace("VALORE", val_double_currency);
                                else if (esitoIstanza.CodEsito == "NO")
                                    dgi.Cells[col_Valore].Text = colore_testo_rosso.Replace("VALORE", val_double_currency);
                                else
                                    dgi.Cells[col_Valore].Text = val_double_currency;
                            }
                            else
                                dgi.Cells[col_Valore].Text = colore_testo_verde.Replace("VALORE", esitoIstanza.Valore);

                            colValoreVisibile = true;
                        }
                        if (esitoIstanza.ValMinimo != null)
                        {
                            dgi.Cells[col_ValMinimo].Text = esitoIstanza.ValMinimo;
                            colValoreMinVisibile = true;
                        }
                        if (esitoIstanza.ValMassimo != null)
                        {
                            dgi.Cells[col_ValMassimo].Text = esitoIstanza.ValMassimo;
                            colValoreMaxVisibile = true;
                        }
                    }
                    #region Rendering "Esegui Metodo"

                    // Esecuzione Metodo
                    if (!string.IsNullOrEmpty(voce_x_check.CodeMethodVoce))
                    {
                        if (!(esitoIstanza != null && esitoIstanza.EsitoPositivoRevisore))
                        {
                            LinkButton CodeMethodLinkButton = new LinkButton();
                            CodeMethodLinkButton.Text = "Esegui Azione";
                            CodeMethodLinkButton.CommandName = voce_x_check.CodeMethodVoce;
                            if (((SiarLibrary.Web.PrivatePage)Page).AbilitaModifica)
                                CodeMethodLinkButton.Attributes["onclick"] = "javascript:if(confirm('Eseguire l`azione?')){__doPostBack('ExecuteStepMethod','" + voce_x_check.CodeMethodVoce + "_" + voce_x_check.IdVoceGenerica + "');}";
                            else CodeMethodLinkButton.Attributes["onclick"] = "javascript:alert('Non si hanno i privilegi per effettuare modifiche.');";
                            dgi.Cells[col_Azione].Controls.Add(CodeMethodLinkButton);
                            dgi.Cells[col_Azione].Controls.Add(new LiteralControl("<br/>"));
                        }
                    }
                    #endregion
                }
                else
                {
                    if (esitoIstanza != null && comboEsitoVoce != null)
                    {
                        ListItem li = comboEsitoVoce.Items.FindByValue(esitoIstanza.CodEsito);

                        if (li != null) li.Selected = true;
                    }
                }
            }
            else
            {
                dgi.Cells[col_Num].Text = string.Empty;
                dgi.Cells[col_Descrizione].Text = "<b>" + dgi.Cells[col_Descrizione].Text + "</b>";
                dgi.Cells[col_Descrizione].Font.Size = FontUnit.Medium;
                dgi.BackColor = System.Drawing.Color.FromArgb(177, 210, 231); //(137, 187, 219) colore della testa del datagrid
                dgi.Cells[col_Obbligatorio].Text = string.Empty;
                dgi.Cells[col_Esito].Text = string.Empty;
                dgi.Cells[col_Valore].Text = string.Empty;
                dgi.Cells[col_ValMinimo].Text = string.Empty;
                dgi.Cells[col_ValMassimo].Text = string.Empty;
                dgi.Cells[col_Azione].Text = string.Empty;
                dgi.Cells[col_Note].Text = string.Empty;
            }
        }
    }
}