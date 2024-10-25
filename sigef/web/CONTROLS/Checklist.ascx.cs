using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Checklist : System.Web.UI.UserControl
{
    private SiarBLL.IterProgettoCollectionProvider iter_provider = new SiarBLL.IterProgettoCollectionProvider();
    private SiarBLL.CheckListXStepCollectionProvider cxs_provider = new SiarBLL.CheckListXStepCollectionProvider();
    SiarLibrary.CheckListXStepCollection steps;
    SiarLibrary.IterProgettoCollection esiti_progetto;
    SiarLibrary.DbProvider dbProvider = new SiarLibrary.DbProvider();

    public bool NoteColumnVisible
    {
        set { dgSteps.Columns[5].Visible = value; dgSteps.Style["width"] = "800px"; }
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

    private SiarLibrary.Progetto _progetto;
    public SiarLibrary.Progetto Progetto
    {
        get { return _progetto; }
        set { _progetto = value; }
    }

    private SiarLibrary.NullTypes.IntNT _idCheckList;
    public SiarLibrary.NullTypes.IntNT IdCheckList
    {
        get { return _idCheckList; }
        set { _idCheckList = value; }
    }

    private SiarLibrary.NullTypes.IntNT _idDomandaPagamento;
    public SiarLibrary.NullTypes.IntNT IdDomandaPagamento
    {
        get { return _idDomandaPagamento; }
        set { _idDomandaPagamento = value; }
    }

    /// <summary>
    /// elenco degli step della checklist che contengono un url per la modifica dei dati
    /// </summary>
    public ArrayList StepDiReindirizzamento
    {
        get
        {
            ArrayList _stepDiReindirizzamento = new ArrayList();
            if (steps != null)
            {
                foreach (SiarLibrary.CheckListXStep cxs in steps)
                    if (cxs.Url != null)
                        if (!_stepDiReindirizzamento.Contains(cxs.Url.Value))
                            _stepDiReindirizzamento.Add(cxs.Url.Value);
            }
            return _stepDiReindirizzamento;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (_progetto == null) ((SiarLibrary.Web.PrivatePage)Page).Redirect(DefaultRedirect, "Per proseguire è necessario selezionare la domanda di aiuto.", true);
        SiarLibrary.StepXBandoCollection checklists = new SiarBLL.StepXBandoCollectionProvider().Find(_progetto.IdBando, null, null, _Fase);
        if (checklists.Count > 0) _idCheckList = checklists[0].IdCheckList;
        else ((SiarLibrary.Web.PrivatePage)Page).Redirect(DefaultRedirect, "Impossibile eseguire i controlli sugli step operativi perche' la check list cercata non e' ancora stata approntata. Contattare il proprio responsabile di misura.", true);
        steps = cxs_provider.Find(_idCheckList, null, null, null, null, null, null);
        esiti_progetto = iter_provider.Find(_progetto.IdProgetto, null, null, null, _progetto.IdBando, _Fase, null);
        // Esecuzione Code Method            
        if (IsPostBack && Request.Form["__EVENTTARGET"] == "ExecuteStepMethod")
        {
            string codeMethodName = Request.Form["__EVENTARGUMENT"].Substring(0, Request.Form["__EVENTARGUMENT"].IndexOf("_"));
            string IdStep = Request.Form["__EVENTARGUMENT"].Replace(codeMethodName + "_", string.Empty);
            EseguiMetodoStep(codeMethodName, Convert.ToInt32(IdStep));
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        dgSteps.DataSource = steps;
        dgSteps.DataBind();
        base.OnPreRender(e);
    }

    public string VerificaChecklist()
    {
        string esito = "SI";
        try
        {
            // ricalcolo i valori
            foreach (SiarLibrary.CheckListXStep cxs in steps)
            {
                SiarLibrary.IterProgetto iterprogetto = esiti_progetto.CollectionGetById(_progetto.IdProgetto, cxs.IdStep);
                if (iterprogetto == null) insertIterProgetto(cxs);
                else
                {
                    string esitoStep = calcolaEsitoStep(cxs);
                    // condizione per l'aggiornamento dell'esito: se non e' uno step con codemetod
                    if (cxs.CodeMethod == null) iterprogetto.CodEsito = esitoStep;

                    iterprogetto.Data = DateTime.Now;
                    iterprogetto.CfOperatore = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
                    iterprogetto.Note = Request.Form["txtAreaLungaCKL" + cxs.IdStep + "_text"];
                    //iterprogetto.Revisione = _revisione;
                    iter_provider.Save(iterprogetto);
                }
            }
            //controllo se positivi
            esiti_progetto = iter_provider.Find(_progetto.IdProgetto, null, null, null, _progetto.IdBando, _Fase, null);
            foreach (SiarLibrary.CheckListXStep cxs in steps)
            {
                SiarLibrary.IterProgetto iter = esiti_progetto.CollectionGetById(_progetto.IdProgetto, cxs.IdStep);
                //modificato per gestire il valore vuoto sulla combo degli esiti degli step
                bool esito_positivo = (iter.CodEsito != null && iter.EsitoPositivoIstruttore != null && iter.EsitoPositivoIstruttore);
                if (cxs.Obbligatorio && !esito_positivo)
                {
                    esito = "NO";
                    break;
                }
            }
        }
        catch (Exception ex) { esito = ex.Message; }
        return esito;
    }

    private void insertIterProgetto(SiarLibrary.CheckListXStep cxs)
    {
        SiarLibrary.IterProgetto iterprogetto = new SiarLibrary.IterProgetto();
        iterprogetto.IdStep = cxs.IdStep;
        iterprogetto.IdProgetto = _progetto.IdProgetto;
        if (cxs.CodeMethod == null) iterprogetto.CodEsito = calcolaEsitoStep(cxs);
        else iterprogetto.CodEsito = "NO"; // in insert il metodo step non e' stato eseguito quindi imposto l'esito negativo
        iterprogetto.Data = DateTime.Now;
        iterprogetto.CfOperatore = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
        iterprogetto.Note = Request.Form["txtAreaLungaCKL" + cxs.IdStep + "_text"];
        //iterprogetto.Revisione = _revisione;
        iter_provider.Save(iterprogetto);
    }

    private string calcolaEsitoStep(SiarLibrary.CheckListXStep step)
    {
        if (step.Automatico)
            return (VerificaStepAutomatico(step) ? "SI" : "NO");
        else
        {
            string retval = null;
            //cerco l'hidden che come valore ha l'uniqueid della combo corrispondente allo step
            string nome_hidden = "hdnEsitoStep" + step.IdStep;
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
    private void EseguiMetodoStep(string codeMethodName, int IdStep)
    {
        try
        {
            SiarLibrary.IterProgetto iter = iter_provider.GetById(_progetto.IdProgetto, IdStep);
            if (iter == null)
            {
                iter = new SiarLibrary.IterProgetto();
                iter.IdProgetto = _progetto.IdProgetto;
                iter.IdStep = IdStep;
            }
            // Eseguo il metodo via reflection
            Assembly actionsAssembly = Assembly.LoadFrom(Server.MapPath("../../bin/SiarActions.dll"));
            Type actionsClassType = actionsAssembly.GetType("SiarActions.StepProvider");
            object esito = actionsClassType.InvokeMember(codeMethodName, BindingFlags.Default | BindingFlags.InvokeMethod,
                                                         null, actionsClassType, new object[] { _progetto.IdProgetto.Value });
            SiarActions.StepResult risultato = (SiarActions.StepResult)esito;
            iter.Data = DateTime.Now;
            iter.CfOperatore = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
            iter.CodEsito = (risultato.Esito ? "SI" : "NO");
            //iter.Note=
            //iter.Revisione = _revisione;
            iter_provider.Save(iter);
            if (risultato.Esito)
                ((SiarLibrary.Web.PrivatePage)Page).ShowMessage(risultato.Descrizione);
            else ((SiarLibrary.Web.PrivatePage)Page).ShowError("L'esecuzione dell'azione per lo step selezionato non e' andata a buon fine.<br />Dettaglio errore: " + risultato.Descrizione);
        }
        catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
    }

    /// <summary>
    /// Esegue la query per la verifica di uno step automatico
    /// </summary>
    /// <param name="step"></param>
    /// <returns>True se lo step è verificato</returns>
    private bool VerificaStepAutomatico(SiarLibrary.CheckListXStep step)
    {
        try
        {
            decimal queryResult = 0;
            if (!string.IsNullOrEmpty(step.QuerySql))
            {
                #region eseguo la query
                System.Data.IDbCommand cmd = dbProvider.GetCommand();
                cmd.CommandText = step.QuerySql;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdProgetto", _progetto.IdProgetto.Value));

                //System.Data.SqlClient.SqlParameter IdProgettoParam = new System.Data.SqlClient.SqlParameter("IdProgetto", SqlDbType.Int);
                //IdProgettoParam.Value = _progetto.IdProgetto.Value;
                //cmd.Parameters.Insert(0, IdProgettoParam);
                if (IdDomandaPagamento != null)
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdDomandaPagamento", IdDomandaPagamento.Value));

                dbProvider.InitDatareader(cmd);
                if (dbProvider.DataReader.Read()) Decimal.TryParse(dbProvider.DataReader.GetValue(0).ToString(), out queryResult);

                // Possono essere ritornati più recordset -> L'ultimo rappresenta il risultato dello Step
                while (dbProvider.DataReader.NextResult())
                {
                    if (dbProvider.DataReader.Read()) Decimal.TryParse(dbProvider.DataReader.GetValue(0).ToString(), out queryResult);
                }
                dbProvider.Close();
                #endregion

                if (step.ValMinimo == null && step.ValMassimo == null) return bool.Parse(queryResult.ToString());
                else
                {
                    // Il valore ritornato dalla query deve essere compreso tra i valori Min e Max possibili
                    decimal valoreMin;
                    decimal valoreMax;
                    Decimal.TryParse(step.ValMinimo, out valoreMin);
                    Decimal.TryParse(step.ValMassimo, out valoreMax);

                    if (step.ValMinimo == null && step.ValMassimo != null)
                    {
                        if (queryResult <= valoreMax) return true;
                        else return false;
                    }
                    else if (step.ValMinimo != null && step.ValMassimo == null)
                    {
                        if (queryResult >= valoreMin) return true;
                        else return false;
                    }
                    else if (step.ValMassimo != null && step.ValMinimo != null)
                    {
                        if (queryResult >= valoreMin && queryResult <= valoreMax) return true;
                        else return false;
                    }
                    else return false;
                }
            }
            return false;
        }
        catch { return false; }
    }

    protected void dgSteps_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            SiarLibrary.CheckListXStep step = (SiarLibrary.CheckListXStep)dgi.DataItem;
            SiarLibrary.IterProgetto iterProgetto = esiti_progetto.CollectionGetById(_progetto.IdProgetto, step.IdStep);
            SiarLibrary.Web.ComboSiNo comboEsitoStep = (SiarLibrary.Web.ComboSiNo)dgi.Cells[3].FindControl("lstEsitoStep");
            if (comboEsitoStep != null)
            {
                #region hidden con nome combo
                HtmlInputHidden hdn = new HtmlInputHidden();
                //hdn.Attributes.Add("runat", "server");
                hdn.ID = "hdnEsitoStep" + step.IdStep;
                hdn.Value = comboEsitoStep.UniqueID;
                dgi.Cells[3].Controls.Add(hdn);
                #endregion
            }

            #region textarea note
            if (iterProgetto != null)
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(dgi.Cells[5].Text);
                System.Xml.XmlNode nodo = doc.GetElementsByTagName("textarea").Item(0);
                nodo.InnerText = iterProgetto.Note;
                dgi.Cells[5].Text = doc.InnerXml;
            }
            #endregion

            #region Url
            if (!string.IsNullOrEmpty(step.Url))
            {
                HyperLink newHL = new HyperLink();
                newHL.Text = "Pagina di modifica dei dati";
                newHL.NavigateUrl = step.Url + "&iddom=" + _progetto.IdProgetto;
                dgi.Cells[4].Controls.Add(newHL);
            }
            #endregion

            if (step.Automatico)
            {
                dgi.Cells[3].Text = string.Empty; // nascondo la combo
                // Rendering Esito Step Verificato
                if (iterProgetto != null)
                {
                    if (iterProgetto.CodEsito == "SI") dgi.Cells[3].Text = "<span style=\"color: #0b9007;\">SI</span>";
                    else if (iterProgetto.CodEsito == "NO") dgi.Cells[3].Text = "<span style=\"color: #be0202;\">NO</span>";
                    else dgi.Cells[3].Text = iterProgetto.CodEsito;
                }
                #region Rendering "Esegui Metodo"

                // Esecuzione Metodo
                if (!string.IsNullOrEmpty(step.CodeMethod))
                {
                    if (!(iterProgetto != null && iterProgetto.EsitoPositivoIstruttore))
                    {
                        LinkButton CodeMethodLinkButton = new LinkButton();
                        CodeMethodLinkButton.Text = "Esegui Azione";
                        CodeMethodLinkButton.CommandName = step.CodeMethod;
                        if (((SiarLibrary.Web.PrivatePage)Page).AbilitaModifica)
                            CodeMethodLinkButton.Attributes["onclick"] = "javascript:if(confirm('Eseguire l`azione?')){__doPostBack('ExecuteStepMethod','" + step.CodeMethod + "_" + step.IdStep + "');}";
                        else CodeMethodLinkButton.Attributes["onclick"] = "javascript:alert('Non si hanno i privilegi per effettuare modifiche.');";
                        dgi.Cells[4].Controls.Add(CodeMethodLinkButton);
                        dgi.Cells[4].Controls.Add(new LiteralControl("<br/>"));
                    }
                }
                #endregion
            }
            else
            {
                if (iterProgetto != null && comboEsitoStep != null)
                {
                    ListItem li = comboEsitoStep.Items.FindByValue(iterProgetto.CodEsito);
                    if (li != null) li.Selected = true;
                }
            }
        }
    }
}
