using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SigefAgidPrivate : SiarLibrary.Web.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        Response.AddHeader("Pragma", "no-cache");
        Page.Title = System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"];

        //try
        //{
        //    System.Text.ASCIIEncoding txt_encode = new System.Text.ASCIIEncoding();
        //    if (!string.IsNullOrEmpty(hdnCtrlUserSession.Value) && Session["siar_ctrl_user_session_date"] != null)
        //    {
        //        string data_utente = txt_encode.GetString(Convert.FromBase64String(hdnCtrlUserSession.Value)),
        //            data_sessione = Session["siar_ctrl_user_session_date"].ToString();
        //        DateTime ctrl_data_utente, ctrl_data_sessione;
        //        if ((!DateTime.TryParse(data_utente, out ctrl_data_utente) || !DateTime.TryParse(data_sessione, out ctrl_data_sessione)
        //            || data_sessione != data_utente)
        //            && !(Session["evita_controllo_date_sessione"] != null && Session["evita_controllo_date_sessione"].ToString().Equals("true"))) throw new Exception("");
        //    }
        //    string data_attuale = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss.ffffff");
        //    Session["siar_ctrl_user_session_date"] = data_attuale;
        //    ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("$('[id$=hdnCtrlUserSession]').val('" +
        //        Convert.ToBase64String(txt_encode.GetBytes(data_attuale)) + "');");
        //}
        //catch { ((SiarLibrary.Web.Page)Page).Redirect(Page.Request.ApplicationPath + "/ShowErrorDualBox.htm"); }

        if (Operatore != null && Operatore.Utente.IdProfilo > 0)
        {
            var impostazioni_provider = new SiarBLL.ImpostazioniCollectionProvider();
            var istanzaSigef = ConfigurationManager.AppSettings["IstanzaSigef"];

            if (impostazioni_provider.GetIngressiContingentatiAbilitati(istanzaSigef)) // if (ConfigurationManager.AppSettings["IngressiContingentatiAbilitati"] == "true")
            {
                //var utentiMax = int.Parse(ConfigurationManager.AppSettings["IngressiContingentatiUtentiMax"]);
                var utentiMax = impostazioni_provider.GetIngressiContingentatiUtentiMax(istanzaSigef);
                SiarBLL.LogAccessiCollectionProvider accessi_provider = new SiarBLL.LogAccessiCollectionProvider();
                var utenti_online = accessi_provider.GetUtentiConnessi(istanzaSigef);
                var accessi_utente_coll = accessi_provider.GetLoginAppesiUtente(istanzaSigef, Operatore.Utente.IdUtente);

                // Il controllo non vale per gli amministratori
                if (Operatore.Utente.IdProfilo != 1)
                {
                    // Se abbiamo raggiunto gli utenti massimi e io non sono già loggato vengo reindirizzato facendo logout
                    if (utenti_online == utentiMax && accessi_utente_coll.Count == 0)
                    {
                        string path = HttpContext.Current.Request.Url.AbsolutePath;
                        if (!path.EndsWith("UserLimitReached.aspx")) // Controllo per evitare loop
                        {
                            Session.Abandon();
                            Session.Clear();
                            HttpContext.Current.Response.Redirect("~/UserLimitReached.aspx", true);
                        }
                    }
                    else
                    {
                        if (accessi_utente_coll.Count == 0)
                        {
                            var login = new SiarLibrary.LogAccessi();
                            login.IdUtente = Operatore.Utente.IdUtente;
                            login.IdProfilo = Operatore.Utente.IdProfilo;
                            login.Istanza = istanzaSigef;
                            login.DataLogin = DateTime.Now;
                            accessi_provider.Save(login);
                        }
                    }
                }
            }

            // Lo riverifico perché potrei aver fatto logout dal controllo ingressi contingentati
            if (Operatore != null && Operatore.Utente.IdProfilo > 0)
            {
                loginSection.Visible = false;
                divNomeOperatore.Text = Operatore.Utente.Nominativo; // +" (" + (Operatore.Utente.Ente != null ? Operatore.Utente.Ente : Operatore.Utente.Profilo) + ")";

                if (Operatore.Utente.IdProfilo == 1)
                {
                    divCountUsers.Text = Application["TotalOnlineUsers"].ToString();
                    divCountUsersAccessi.Text = new SiarBLL.LogAccessiCollectionProvider().GetUtentiConnessi(istanzaSigef).ToString();
                }
                else
                    divUser.Visible = false;

                //popolo dropdown ruoli
                SiarBLL.UtentiStoricoCollectionProvider storico_provider = new SiarBLL.UtentiStoricoCollectionProvider();
                SiarLibrary.UtentiStoricoCollection u_coll = storico_provider.Find(Operatore.Utente.IdUtente, null, null, true);
                if (u_coll.Count > 1)
                {
                    ComboRuolo.Visible = true;
                    btnRuolo.Visible = true;
                    ComboRuolo.Items.Clear();
                    foreach (SiarLibrary.UtentiStorico us in u_coll)
                    {
                        ComboRuolo.Items.Add(new ListItem(us.Profilo + (us.Ente != null ? " - " + us.Ente : ""), us.Id));
                    }
                    if (!IsPostBack)
                    {
                        foreach (ListItem li in ComboRuolo.Items)
                            if (li.Value == Operatore.Utente.IdStoricoUltimo) { li.Selected = true; break; }
                    }

                }
                else
                {
                    ComboRuolo.Visible = false;
                    btnRuolo.Visible = false;

                }

#if (DEBUG)
                string db_string = System.Configuration.ConfigurationManager.ConnectionStrings["DB_SIGEF"].ConnectionString;
                divNomeOperatore.Text += " | Database: " + db_string.Remove(db_string.IndexOf(";password")).Remove(0, db_string.IndexOf("catalog=") + 8).ToUpper();
#endif
            }
        }
        else
        {
            ComboRuolo.Visible = false;
            btnRuolo.Visible = false;
            divUser.Visible = false;
            loginSection.Visible = true;
        }

        SiarLibrary.NewsCollection news = new SiarBLL.NewsCollectionProvider().Find(null, null, null);
        //for (int i = 0; i < news.Count; i++)
        //{
        //    if (i > 2) break;
        //    HtmlTableCell td = new HtmlTableCell();
        //    td.InnerText = news[i].Data + " - " + news[i].Titolo;
        //    td.Attributes.Add("onclick", "location='" + Page.Request.ApplicationPath + "/public/newscomunicazioni.aspx'");
        //    HtmlTableRow tr = new HtmlTableRow();
        //    td.Attributes.Add("class", "news");
        //    tr.Cells.Add(td);
        //    tableNews.Rows.Add(tr);
        //}

        //HtmlTableCell td1 = new HtmlTableCell();
        //td1.InnerText = DateTime.Now.ToString();
        //HtmlTableRow tr1 = new HtmlTableRow();
        //td1.Attributes.Add("class", "newsHeader");
        //tr1.Cells.Add(td1);
        //tableNews.Rows.Add(tr1);

        // INTERRUZIONE DI SISTEMA
        foreach (SiarLibrary.News n in news.FiltroInterruzioneDiSistema(true, null, DateTime.Now))
        {
            divManutenzione.Visible = true;
            if (n.DataInizio != null && n.DataFine != null && n.DataFine > DateTime.Now)
            {
                if (n.DataInizio <= DateTime.Now) { Response.Redirect("~/manutenzione.aspx"); break; }
                else if (DateTime.Now.Date == n.DataInizio.Value.Date) { hdnInterruzioneSistema.Value = "S"; break; }
            }
        }
    }

    public string FunzionePagina
    {
        get { return hdnFunzioneMenuPagina.Value; }
        set { hdnFunzioneMenuPagina.Value = value; }
    }
    protected void btnRuolo_Click(object sender, EventArgs e)
    {
            if (ComboRuolo.SelectedValue == "" || ComboRuolo.SelectedValue == null)
                throw new Exception("Selezionare il ruolo dall'elenco");
            SiarBLL.UtentiCollectionProvider utente_provider = new SiarBLL.UtentiCollectionProvider();
            SiarLibrary.Utenti attuale = utente_provider.GetById(Operatore.Utente.IdUtente);
            attuale.IdStoricoUltimo = Convert.ToInt32(ComboRuolo.SelectedValue);
            utente_provider.Save(attuale);
            attuale = utente_provider.GetById(Operatore.Utente.IdUtente);
            SetOperatoreRuolo(attuale);
            Session["FUNZIONALITA_OPERATORE"] = null;
            string path= "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
            Response.Redirect( path+"/Private/welcome.aspx");
    }
}
