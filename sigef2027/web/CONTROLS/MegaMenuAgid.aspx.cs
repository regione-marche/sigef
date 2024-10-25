using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SiarLibrary;

namespace web.CONTROLS
{
    public partial class MegaMenuAgid : System.Web.UI.Page
    {
        int _idprofilo = -1;
        bool ie6_browser = false;
        //HtmlTable tabMenu = new HtmlTable();
        HtmlGenericControl tabMenu = new HtmlGenericControl("ul");


        private string FunzioneMenu { get { return Request.Params["funcmenu"]; } }
        private string FunzionePagina { get { return Request.Params["funcpagina"]; } }
        SiarLibrary.Funzionalita fpadre = new SiarLibrary.Funzionalita(), fnonno = new SiarLibrary.Funzionalita(), froot = new SiarLibrary.Funzionalita();
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
            tabMenu.Attributes.Add("class", "navbar-nav");

            HtmlGenericControl areaPubblica = new HtmlGenericControl("li");
            areaPubblica.Attributes.Add("class", "nav-item dropdown megamenu");

            HtmlGenericControl aAreaPubblica = new HtmlGenericControl("a");
            aAreaPubblica.Attributes.Add("class", "nav-link dropdown-toggle");
            aAreaPubblica.Attributes.Add("href", "#");
            aAreaPubblica.Attributes.Add("data-bs-toggle", "dropdown");
            aAreaPubblica.Attributes.Add("aria-expanded", "false");
            aAreaPubblica.Attributes.Add("id", "megamenuSigef");

            HtmlGenericControl spanAreaPubblica = new HtmlGenericControl("span");
            spanAreaPubblica.InnerText = "Area pubblica";


            HtmlGenericControl svgAreaPubblica = new HtmlGenericControl("svg");
            svgAreaPubblica.Attributes.Add("class", "icon icon-xs");

            HtmlGenericControl useAreaPubblica = new HtmlGenericControl("use");
            useAreaPubblica.Attributes.Add("href", "/web/bootstrap-italia/svg/sprites.svg#it-expand");

            tabMenu.Controls.Add(areaPubblica);
            areaPubblica.Controls.Add(aAreaPubblica);
            aAreaPubblica.Controls.Add(spanAreaPubblica);
            aAreaPubblica.Controls.Add(svgAreaPubblica);
            svgAreaPubblica.Controls.Add(useAreaPubblica);

            scriviAreaPubblica(areaPubblica);

            scriviMenu();
            if (_idprofilo <= 0)
            {
                HtmlGenericControl login = new HtmlGenericControl("li");
                login.Attributes.Add("class", "nav-item");

                HtmlGenericControl aLogin = new HtmlGenericControl("a");
                aLogin.Attributes.Add("class", "nav-link");
                aLogin.Attributes.Add("onclick", "location='" + Request.ApplicationPath + "/private/welcome.aspx'");
                aLogin.InnerText = "Login";

                login.Controls.Add(aLogin);
                tabMenu.Controls.Add(login);
            }
            else
            {
                HtmlGenericControl logout = new HtmlGenericControl("li");
                logout.Attributes.Add("class", "nav-item");

                HtmlGenericControl aLogout = new HtmlGenericControl("a");
                aLogout.Attributes.Add("class", "nav-link");

                aLogout.Attributes.Add("onclick", "location='" + Request.ApplicationPath + "/Logout.aspx'");
                aLogout.InnerText = "Logout";
                logout.Controls.Add(aLogout);
                tabMenu.Controls.Add(logout);
            }
        }

        private void scriviAreaPubblica(HtmlGenericControl menuAreaPubblica)
        {
            HtmlGenericControl dropdownMenu = new HtmlGenericControl("div");
            dropdownMenu.Attributes.Add("class", "dropdown-menu");
            dropdownMenu.Attributes.Add("role", "region");
            dropdownMenu.Attributes.Add("aria-labelledby", "megamenuSigef");

            HtmlGenericControl row = new HtmlGenericControl("div");
            row.Attributes.Add("class", "row");

            HtmlGenericControl col = new HtmlGenericControl("div");
            col.Attributes.Add("class", "col-12 col-lg-12");

            HtmlGenericControl lW = new HtmlGenericControl("div");
            lW.Attributes.Add("class", "link-list-wrapper");

            HtmlGenericControl lH = new HtmlGenericControl("div");
            lH.Attributes.Add("class", "link-list-heading");
            lH.InnerText = "Area Pubblica";

            HtmlGenericControl lL = new HtmlGenericControl("ul");
            lL.Attributes.Add("class", "link-list");

            dropdownMenu.Controls.Add(row);
            row.Controls.Add(col);
            col.Controls.Add(lW);
            lW.Controls.Add(lH);

            lW.Controls.Add(lL);

            SiarLibrary.Funzionalita areaPubblica = new SiarBLL.FunzionalitaCollectionProvider().Find(null, "Area_Pubblica", null, null, null, null)[0];
            foreach (SiarLibrary.Funzionalita f in MenuOperatore.SubSelect(null, null, null, null, null, areaPubblica.CodFunzione, null, null))
            {
                if (f.FlagMenu)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");

                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("class", "dropdown-item list-item");
                    a.Attributes.Add("href", Request.ApplicationPath + f.Link);

                    HtmlGenericControl span = new HtmlGenericControl("span");
                    span.InnerText = f.Descrizione;

                    li.Controls.Add(a);
                    a.Controls.Add(span);

                    lL.Controls.Add(li);
                }
            }

            menuAreaPubblica.Controls.Add(dropdownMenu);
        }

        private void scriviMenu()
        {
            SiarLibrary.FunzionalitaCollection menu_operatore = MenuOperatore;
            //SiarLibrary.Funzionalita fpadre = new SiarLibrary.Funzionalita(), fnonno = new SiarLibrary.Funzionalita();
            if (!string.IsNullOrEmpty(FunzionePagina))
            {
                SiarLibrary.FunzionalitaCollection figli = menu_operatore.SubSelect(null, null, null, FunzionePagina, null, null, null, null);
                if (figli.Count > 0) fpadre = menu_operatore.CollectionGetById(figli[0].Padre);
                if (fpadre != null) fnonno = menu_operatore.CollectionGetById(fpadre.Padre);
                if (fnonno != null) froot = menu_operatore.CollectionGetById(fnonno.Padre);
            }

            createMenu(tabMenu, null);
        }

        public void createMenu(HtmlGenericControl p, SiarLibrary.Funzionalita padre)
        {
            SiarLibrary.Funzionalita areaRiservata = new SiarBLL.FunzionalitaCollectionProvider().Find(null, "Area_Riservata", null, null, null, null)[0];

            SiarLibrary.FunzionalitaCollection level1 = MenuOperatore.SubSelect(null, null, null, null, null, areaRiservata.CodFunzione, null, null);

            foreach (SiarLibrary.Funzionalita f in level1)
            {
                if (f.FlagMenu)
                {
                    switch (f.DescMenu)
                    {
                        case "cruscotto":
                            HtmlGenericControl cruscotto = new HtmlGenericControl("li");
                            cruscotto.Attributes.Add("class", "nav-item");

                            HtmlGenericControl aCruscotto = new HtmlGenericControl("a");
                            aCruscotto.Attributes.Add("class", "nav-link");

                            aCruscotto.Attributes.Add("href", Request.ApplicationPath + f.Link);
                            aCruscotto.InnerText = f.Descrizione;
                            cruscotto.Controls.Add(aCruscotto);
                            tabMenu.Controls.Add(cruscotto);
                            break;
                        case "domande_psr":
                            HtmlGenericControl areaPsr = new HtmlGenericControl("li");
                            areaPsr.Attributes.Add("class", "nav-item dropdown megamenu");

                            HtmlGenericControl aAreaPsr = new HtmlGenericControl("a");
                            aAreaPsr.Attributes.Add("class", "nav-link dropdown-toggle");
                            aAreaPsr.Attributes.Add("href", "#");
                            aAreaPsr.Attributes.Add("data-bs-toggle", "dropdown");
                            aAreaPsr.Attributes.Add("aria-expanded", "false");
                            aAreaPsr.Attributes.Add("id", "megamenuSigef");

                            HtmlGenericControl spanAreaPsr = new HtmlGenericControl("span");
                            spanAreaPsr.InnerText = f.Descrizione;


                            HtmlGenericControl svgAreaPsr = new HtmlGenericControl("svg");
                            svgAreaPsr.Attributes.Add("class", "icon icon-xs");

                            HtmlGenericControl useAreaPsr = new HtmlGenericControl("use");
                            useAreaPsr.Attributes.Add("href", "/web/bootstrap-italia/svg/sprites.svg#it-expand");

                            HtmlGenericControl dropdownMenu = new HtmlGenericControl("div");
                            dropdownMenu.Attributes.Add("class", "dropdown-menu");
                            dropdownMenu.Attributes.Add("role", "region");
                            dropdownMenu.Attributes.Add("aria-labelledby", "megamenuSigef");

                            HtmlGenericControl row = new HtmlGenericControl("div");
                            row.Attributes.Add("class", "row");

                            tabMenu.Controls.Add(areaPsr);
                            areaPsr.Controls.Add(aAreaPsr);
                            aAreaPsr.Controls.Add(spanAreaPsr);
                            aAreaPsr.Controls.Add(svgAreaPsr);
                            svgAreaPsr.Controls.Add(useAreaPsr);
                            areaPsr.Controls.Add(dropdownMenu);

                            dropdownMenu.Controls.Add(row);

                            foreach (SiarLibrary.Funzionalita s in MenuOperatore.SubSelect(null, null, null, null, null, f.CodFunzione, null, null))
                            {
                                createSubSection(row, s);
                            }
                            break;
                        case "Welcome":
                            break;
                        default:
                            HtmlGenericControl sezione = new HtmlGenericControl("li");
                            sezione.Attributes.Add("class", "nav-item dropdown megamenu");

                            HtmlGenericControl aSezione = new HtmlGenericControl("a");
                            aSezione.Attributes.Add("class", "nav-link dropdown-toggle");
                            aSezione.Attributes.Add("href", "#");
                            aSezione.Attributes.Add("data-bs-toggle", "dropdown");
                            aSezione.Attributes.Add("aria-expanded", "false");
                            aSezione.Attributes.Add("id", "megamenuSigef");

                            HtmlGenericControl spanSezione = new HtmlGenericControl("span");
                            spanSezione.InnerText = f.Descrizione;


                            HtmlGenericControl svgSezione = new HtmlGenericControl("svg");
                            svgSezione.Attributes.Add("class", "icon icon-xs");

                            HtmlGenericControl useSezione = new HtmlGenericControl("use");
                            useSezione.Attributes.Add("href", "/web/bootstrap-italia/svg/sprites.svg#it-expand");

                            tabMenu.Controls.Add(sezione);
                            sezione.Controls.Add(aSezione);
                            aSezione.Controls.Add(spanSezione);
                            aSezione.Controls.Add(svgSezione);
                            svgSezione.Controls.Add(useSezione);

                            createSection(sezione, f);
                            break;
                    }
                }
            }
        }

        private void createSection(HtmlGenericControl menuAreaPrivata, Funzionalita f)
        {
            if (f.FlagMenu)
            {
                HtmlGenericControl dropdownMenu = new HtmlGenericControl("div");
                dropdownMenu.Attributes.Add("class", "dropdown-menu");
                dropdownMenu.Attributes.Add("role", "region");
                dropdownMenu.Attributes.Add("aria-labelledby", "megamenuSigef");

                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes.Add("class", "row");

                HtmlGenericControl col = new HtmlGenericControl("div");
                col.Attributes.Add("class", "col-12 col-lg-12");

                HtmlGenericControl lW = new HtmlGenericControl("div");
                lW.Attributes.Add("class", "link-list-wrapper");

                HtmlGenericControl lH = new HtmlGenericControl("div");
                lH.Attributes.Add("class", "link-list-heading");
                lH.InnerText = f.Descrizione;

                HtmlGenericControl lL = new HtmlGenericControl("ul");
                lL.Attributes.Add("class", "link-list");

                dropdownMenu.Controls.Add(row);
                row.Controls.Add(col);
                col.Controls.Add(lW);
                lW.Controls.Add(lH);

                lW.Controls.Add(lL);

                SiarLibrary.Funzionalita funzionalita = new SiarBLL.FunzionalitaCollectionProvider().Find(null, f.DescMenu, null, null, null, null)[0];
                foreach (SiarLibrary.Funzionalita s in MenuOperatore.SubSelect(null, null, null, null, null, funzionalita.CodFunzione, null, null))
                {
                    if (s.FlagMenu)
                    {
                        HtmlGenericControl li = new HtmlGenericControl("li");

                        HtmlGenericControl a = new HtmlGenericControl("a");
                        if (FunzionePagina == s.DescMenu)
                            a.Attributes.Add("class", "dropdown-item list-item active");
                        else
                            a.Attributes.Add("class", "dropdown-item list-item");
                        a.Attributes.Add("href", Request.ApplicationPath + s.Link);

                        HtmlGenericControl span = new HtmlGenericControl("span");
                        span.InnerText = s.Descrizione;

                        li.Controls.Add(a);
                        a.Controls.Add(span);

                        lL.Controls.Add(li);
                    }
                }

                menuAreaPrivata.Controls.Add(dropdownMenu);
            }
        }

        private void createSubSection(HtmlGenericControl menuAreaPrivata, Funzionalita f)
        {
            if (f.FlagMenu)
            {
                HtmlGenericControl col = new HtmlGenericControl("div");
                col.Attributes.Add("class", "col-lg-4 col-sm-6");

                HtmlGenericControl lW = new HtmlGenericControl("div");
                lW.Attributes.Add("class", "link-list-wrapper");

                HtmlGenericControl lH = new HtmlGenericControl("div");
                lH.Attributes.Add("class", "link-list-heading");
                lH.InnerText = f.Descrizione;

                HtmlGenericControl lL = new HtmlGenericControl("ul");
                lL.Attributes.Add("class", "link-list");

                col.Controls.Add(lW);
                lW.Controls.Add(lH);

                lW.Controls.Add(lL);

                SiarLibrary.Funzionalita funzionalita = new SiarBLL.FunzionalitaCollectionProvider().Find(null, f.DescMenu, null, null, null, null)[0];
                foreach (SiarLibrary.Funzionalita s in MenuOperatore.SubSelect(null, null, null, null, null, funzionalita.CodFunzione, null, null))
                {
                    if (s.FlagMenu)
                    {
                        HtmlGenericControl li = new HtmlGenericControl("li");

                        HtmlGenericControl a = new HtmlGenericControl("a");
                        if (FunzionePagina == s.DescMenu)
                            a.Attributes.Add("class", "dropdown-item list-item active");
                        else
                            a.Attributes.Add("class", "dropdown-item list-item");
                        a.Attributes.Add("href", Request.ApplicationPath + s.Link);

                        HtmlGenericControl span = new HtmlGenericControl("span");
                        span.InnerText = s.Descrizione;

                        li.Controls.Add(a);
                        a.Controls.Add(span);

                        lL.Controls.Add(li);
                    }
                }

                menuAreaPrivata.Controls.Add(col);
            }
        }
    }
}