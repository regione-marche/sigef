using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class Menu : System.Web.UI.Page
    {
        int _idprofilo = -1;
        bool ie6_browser = false;
        HtmlTable tabMenu = new HtmlTable();

        private string FunzioneMenu { get { return Request.Params["funcmenu"]; } }
        private string FunzionePagina { get { return Request.Params["funcpagina"]; } }
        private SiarLibrary.Operatore Operatore
        {
            get { return (SiarLibrary.Operatore)(Session["OperatoreAlias"] ?? Session["Operatore"]); }
        }

        private SiarLibrary.FunzionalitaCollection MenuOperatore
        {
            get
            {
                if (Session["FUNZIONALITA_OPERATORE"] == null && _idprofilo > 0)
                    Session["FUNZIONALITA_OPERATORE"] = new SiarBLL.FunzionalitaCollectionProvider().GetMenuOperatore(_idprofilo);
                return ((SiarLibrary.FunzionalitaCollection)Session["FUNZIONALITA_OPERATORE"]) ??
                    new SiarBLL.FunzionalitaCollectionProvider().GetMenuOperatore(_idprofilo);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            Response.ClearHeaders();
            Response.ClearContent();
            if (Request.Browser.Type == "IE6") ie6_browser = true;
            if (Operatore != null) _idprofilo = Operatore.Utente.IdProfilo;
            htmlMenu();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter hWriter = new HtmlTextWriter(sw);
            tabMenu.RenderControl(hWriter);
            Response.Write(sb.ToString());
            Response.End();
        }

        private void htmlMenu()
        {
            tabMenu.CellPadding = 0;
            tabMenu.CellSpacing = 0;
            tabMenu.Width = "160px";
            tabMenu.Attributes.Add("class", "Menu");
            scriviMenu();
            if (_idprofilo <= 0)
            {
                #region login
                HtmlTableCell tl = new HtmlTableCell();
                tl.Align = "left";
                tl.Attributes.Add("onclick", "location='" + Request.ApplicationPath + "/private/welcome.aspx'");
                tl.InnerHtml = "&nbsp;Login";
                HtmlTableRow rl = new HtmlTableRow();
                rl.Attributes.Add("class", "livello3");
                rl.Controls.AddAt(0, tl);
                tabMenu.Controls.AddAt(0, rl);
                #endregion
            }
            else
            {
                #region logout
                HtmlTableCell to = new HtmlTableCell();
                to.Align = "left";
                to.Attributes.Add("onclick", "location='" + Request.ApplicationPath + "/Logout.aspx'");
                to.InnerHtml = "&nbsp;Log out";
                HtmlTableRow ro = new HtmlTableRow();
                ro.Attributes.Add("class", "livello3");
                ro.Controls.Add(to);
                tabMenu.Controls.AddAt(0, ro);
                #endregion
            }
        }

        private void scriviMenu()
        {
            SiarLibrary.FunzionalitaCollection menu_operatore = MenuOperatore;
            SiarLibrary.Funzionalita fpadre = new SiarLibrary.Funzionalita(), fnonno = new SiarLibrary.Funzionalita();
            if (!string.IsNullOrEmpty(FunzionePagina))
            {
                SiarLibrary.FunzionalitaCollection figli = menu_operatore.SubSelect(null, null, null, FunzionePagina, null, null, null, null);
                if (figli.Count > 0) fpadre = menu_operatore.CollectionGetById(figli[0].Padre);
                if (fpadre != null) fnonno = menu_operatore.CollectionGetById(fpadre.Padre);
            }

            int figlio_del_nonno = -1;
            foreach (SiarLibrary.Funzionalita f in menu_operatore)
            {
                #region scrivo le celle
                if (f.FlagMenu)
                {
                    HtmlTableCell t = new HtmlTableCell();
                    t.ID = f.DescMenu;
                    t.InnerHtml = f.Descrizione;
                    HtmlTableRow r = new HtmlTableRow();
                    switch (f.Livello.Value)
                    {
                        case 0:
                            r.Attributes.Add("class", "livello0");
                            break;
                        case 1:
                            r.Attributes.Add("class", "livello1");
                            t.Attributes.Add("onclick", "loadMenu(" + f.CodFunzione + ");");
                            if (f.Descrizione.Equals("Cruscotto"))
                                t.Attributes.Add("onclick", "location='" + Request.ApplicationPath + f.Link + "'");
                            break;
                        case 2:
                            r.Attributes.Add("class", "livello2");
                            t.Attributes.Add("onclick", "loadMenu(" + f.CodFunzione + ");");
                            if (f.Padre.ToString() == FunzioneMenu)
                            {
                                bool b = !bool.Parse(f.AdditionalAttributes["Aperto"]);
                                f.AdditionalAttributes["Aperto"] = b.ToString();
                                figlio_del_nonno = f.CodFunzione;
                            }
                            if (f.CodFunzione == fpadre.CodFunzione || (fnonno != null && f.Padre == fnonno.CodFunzione))
                                f.AdditionalAttributes["Aperto"] = bool.TrueString;
                            r.Style["display"] = "none";
                            if (bool.Parse(f.AdditionalAttributes["Aperto"]))
                                r.Style["display"] = "";
                            break;
                        default:
                            if (f.DescMenu == FunzionePagina)
                            {
                                r.Attributes.Add("class", "livello3Selected");
                                f.AdditionalAttributes["Aperto"] = bool.TrueString;
                            }
                            else
                            {
                                r.Attributes.Add("class", "livello3");
                                if (fpadre != null && f.Padre == fpadre.CodFunzione) f.AdditionalAttributes["Aperto"] = bool.TrueString;
                                else if (f.Padre.ToString() == FunzioneMenu)
                                {
                                    bool b = !bool.Parse(f.AdditionalAttributes["Aperto"]);
                                    f.AdditionalAttributes["Aperto"] = b.ToString();
                                }
                                else if (f.Padre == figlio_del_nonno) f.AdditionalAttributes["Aperto"] = bool.FalseString;
                            }
                            t.Align = "left";
                            t.Attributes.Add("onclick", "location='" + Request.ApplicationPath + f.Link + "'");
                            r.Style["display"] = "none";
                            if (bool.Parse(f.AdditionalAttributes["Aperto"]))
                                r.Style["display"] = "";
                            break;
                    }
                    r.Controls.Add(t);
                    tabMenu.Controls.Add(r);
                }
                #endregion
            }
        }
    }
}